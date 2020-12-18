Imports System.Deployment.Application
Imports System.Globalization
Imports System.IO
Imports System.Threading

Imports ClosedXML.Excel

Imports iTextSharp.text
Imports iTextSharp.text.pdf

Imports Microsoft.Win32

Imports Spire.Xls

Module Modules
End Module
Public Module Strings
    Public stringinicial As String = ""
    Public stringorganismo As String = ""
    Public stringnumero As String = ""
    Public stringyear As String = ""
End Module
Public Module Debugging
    Public Estadodedepuracion As Boolean = False
    Public Ventanadentro As Boolean = True

    Public Sub VerificadorMysql(ByVal Proceso As String)
        Dim valoresdelectura As String = ""
        'Todo el comando de lectura y sus parametros configurados de forma de poder pegarlos en una consola shell mysql y realizar las pruebas directamente sobre la base de datos
        For x = 0 To SERVIDORMYSQL.COMMANDSQL.Parameters.Count - 1
            If Not IsNothing(SERVIDORMYSQL.COMMANDSQL.Parameters(x).Value) Then
                valoresdelectura = valoresdelectura & "Set " & SERVIDORMYSQL.COMMANDSQL.Parameters(x).ParameterName & "='" & SERVIDORMYSQL.COMMANDSQL.Parameters(x).Value.ToString & "';" & vbCrLf
            Else
                valoresdelectura = valoresdelectura & "Set " & SERVIDORMYSQL.COMMANDSQL.Parameters(x).ParameterName & "='';" & vbCrLf
            End If
        Next
        valoresdelectura = valoresdelectura & SERVIDORMYSQL.COMMANDSQL.CommandText
        '----------------------------------------------------------------------------------------------
        'Todo el comando de inserción o update y sus parametros configurados de forma de poder pegarlos en una consola shell mysql y realizar las pruebas directamente sobre la base de datos
        Dim valoresdeescritura As String = ""
        Try
            For x = 0 To SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Count - 1
                valoresdeescritura = valoresdeescritura & "Set " & SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters(x).ParameterName & "=" & SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters(x).Value.ToString & ";" & vbCrLf
            Next
        Catch ex As Exception
            MessageBox.Show("Error en VerificadorMysql ")
        End Try
        valoresdeescritura = valoresdeescritura & SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText
        debugger.COMMANDSQLrich.Text = valoresdelectura
        debugger.INSERTCOMMANDSQLrich.Text = valoresdeescritura
        'Cargar datos de conexión para poder establecer estado y servidor actual
        debugger.Conexionconsulta.Text = "Servidor:" & ServerActivo & vbCrLf & "Usuario:" & USUARIOactivo & vbCrLf & PWDactivo & vbCrLf & "Base de datos" & DATABASE & vbCrLf & "Puerto:" & PORT
        debugger.Text = "Consulta en: " & Proceso
        If debugger.Visible = False Then
            Mostrardialogo(debugger)
            'debugger.ShowDialog()
        Else
            debugger.Close()
            Mostrardialogo(debugger)
            'debugger.ShowDialog()
        End If
    End Sub

    Public Sub InstallUpdateSyncWithInfo()
        Dim info As UpdateCheckInfo = Nothing
        If (ApplicationDeployment.IsNetworkDeployed) Then
            Dim AD As ApplicationDeployment = ApplicationDeployment.CurrentDeployment
            Try
                info = AD.CheckForDetailedUpdate()
            Catch dde As DeploymentDownloadException
                MessageBox.Show("The new version of the application cannot be downloaded at this time. " + ControlChars.Lf & ControlChars.Lf & "Please check your network connection, or try again later. Error: " + dde.Message)
                Return
            Catch ioe As InvalidOperationException
                MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " & ioe.Message)
                Return
            End Try
            If (info.UpdateAvailable) Then
                Dim doUpdate As Boolean = True
                If (Not info.IsUpdateRequired) Then
                    Dim dr As DialogResult = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel)
                    If (Not System.Windows.Forms.DialogResult.OK = dr) Then
                        doUpdate = False
                    End If
                Else
                    ' Display a message that the app MUST reboot. Display the minimum required version.
                    MessageBox.Show("This application has detected a mandatory update from your current " &
                    "version to version " & info.MinimumRequiredVersion.ToString() &
                    ". The application will now install the update and restart.",
                    "Update Available", MessageBoxButtons.OK,
                    MessageBoxIcon.Information)
                End If
                If (doUpdate) Then
                    Try
                        AD.Update()
                        MessageBox.Show("The application has been upgraded, and will now restart.")
                        Application.Restart()
                    Catch dde As DeploymentDownloadException
                        MessageBox.Show("Cannot install the latest version of the application. " & ControlChars.Lf & ControlChars.Lf & "Please check your network connection, or try again later.")
                        Return
                    End Try
                End If
            End If
        End If
    End Sub

    Public Function Fuenteresolucion() As System.Drawing.Font
        Dim fuente As System.Drawing.Font
        Select Case True
            Case Screen.PrimaryScreen.Bounds.Width > 1900
                fuente = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                   '     MsgBox(Screen.PrimaryScreen.Bounds.Width)
            Case Screen.PrimaryScreen.Bounds.Width > 1600
                fuente = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Case Screen.PrimaryScreen.Bounds.Width > 1200
                fuente = New System.Drawing.Font("Segoe UI", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Case Screen.PrimaryScreen.Bounds.Width > 1020
                fuente = New System.Drawing.Font("Perpetua Titling MT", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                '    MsgBox(Screen.PrimaryScreen.Bounds.Width)
            Case Else
                fuente = New System.Drawing.Font("Perpetua Titling MT", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End Select
        Return fuente
    End Function

End Module
Public Module Manipulaciondedatos

    'debería contener todos aquellos subs y funciones que realizan cambios dentro de la estructura del programa como conversión de claves long en números de expediente, o nombres de columnas donde no es posible utilizar un número o no es práctico hacerlo
    'Esta Función aplica para la configuración 'es_AR', reemplaza los puntos por "" y convierte el valor a decimal
    Public Function S_to_dec(ByVal Valor As String) As Decimal
        Return CDec(Valor.ToString.Replace(".", ""))
    End Function

    Public Function nombredecolumna(ByVal Datagrid As DataGridView, ByVal Nombrecolumna As String) As Integer
        For X = 0 To Datagrid.ColumnCount - 1
            If Datagrid.Columns(X).HeaderText.ToUpper = Nombrecolumna.ToUpper Then
                Return X
                Exit For
            Else
                If X = Datagrid.ColumnCount - 1 Then
                    Return 0
                End If
            End If
        Next
    End Function

    Public Function Claveexpedienteaexpediente(ByRef Claveexpediente As String) As String
        If Claveexpediente.Length > 8 Then
            Return Claveexpediente.Substring(4, 4) & "-" & CType(Claveexpediente.Substring(8, 5), Integer).ToString & "/" & Claveexpediente.Substring(0, 4)
        End If
    End Function

    Public Function Claveexpedienteaexpedientedetalle(ByRef Claveexpedientedetalle As String) As String
        If Claveexpedientedetalle.Length > 8 Then
            Return Claveexpedientedetalle.Substring(4, 4) & "-" & CType(Claveexpedientedetalle.Substring(8, 5), Integer).ToString & "/" & Claveexpedientedetalle.Substring(0, 4)
        End If
    End Function

    Public Function Verificacionexpediente(ByVal claveunica As Long) As DataTable
        Dim borrar As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Claveunica", claveunica)
        Dim consultasql As String = "Select * from expediente where Clave_expediente=@claveunica"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, borrar, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Return borrar
    End Function

    Public Function Verificacionpedidofondo(ByVal clave_pedidofondo As Long) As DataTable
        Dim borrarpedido As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Claveunica", clave_pedidofondo)
        Dim consultasql As String = "Select * from pedido_fondos where Clave_pedidofondo=@claveunica"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, borrarpedido, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Return borrarpedido
    End Function

    Public Function Verificacionmontopedidofondo(ByVal clave_pedidofondo As Long) As String
        Dim borrarpedido As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Claveunica", clave_pedidofondo)
        Dim consultasql As String = "Select case when sum(Monto_pedidofondo)>0 then sum(Monto_pedidofondo) else 0 end as Monto from pedido_fondos where Clave_pedidofondo=@claveunica"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, borrarpedido, System.Reflection.MethodBase.GetCurrentMethod.Name)
        '  MessageBox.Show(borrarpedido.Rows(0).Item(0).ToString)
        Return borrarpedido.Rows(0).Item(0)
    End Function

    Public Function Buscarmaximo_pedidofondo(ByRef Year As Integer) As Int16
        Dim temporal As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Year_pedidofondo", Year)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla,
                             "Select max(N_pedidofondo) from pedido_fondos where Year_pedidofondo=@Year_pedidofondo",
                             temporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Select Case IsDBNull(temporal.Rows(0).Item(0))
            Case True
                Return 1
            Case False
                Return Convert.ToInt16(temporal.Rows(0).Item(0)) + 1
        End Select
    End Function

    Public Function Cantidad_Movimientos_pedidofondo(ByRef Clave_pedidofondo As String) As Integer
        Dim temporal As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", Clave_pedidofondo)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla,
                             "SELECT count(Clave_expediente_detalle) as 'Movimientos' from expediente_detalle where SUBSTR(Clave_expediente_detalle FROM 1 FOR LENGTH(Clave_expediente_detalle)-4)
in (Select clave_expediente from expediente WHERE clave_pedidofondo = @Clave_pedidofondo)",
                             temporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Select Case IsDBNull(temporal.Rows(0).Item(0))
            Case True
                Return 0
            Case False
                Return CType(temporal.Rows(0).Item("Movimientos"), Integer)
        End Select
    End Function

    Public Function Desglose_clave_pedidofondo(ByVal clavepedidofondo As String) As String
        If clavepedidofondo.Length > 7 Then
            Return CType(clavepedidofondo.Substring(8, 5), Integer) & "/" & CType(clavepedidofondo.Substring(0, 4), Integer)
        Else
            Return ("Error en clave" & clavepedidofondo)
        End If
    End Function

    Public Function Encabezadodelyear(ByVal Year As Integer) As String
        Dim Encabezado As String = ""
        Dim TABLATEMPORAL As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@year", Year)
        Inicio.SQLPARAMETROS("CONTADURIA_USUARIOS",
                             "SELECT TEXTO from ENCABEZADO WHERE ANIO=@YEAR",
                             TABLATEMPORAL, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Select Case IsDBNull(TABLATEMPORAL.Rows(0).Item(0))
            Case True
                Encabezado = " "
            Case False
                Encabezado = CType(TABLATEMPORAL.Rows(0).Item("TEXTO"), String)
        End Select
        Return Encabezado
    End Function

    Public Function Divisordedosvariables(ByVal Textooriginal As String) As String()
        Dim Separador As String() = Nothing
        If Textooriginal.Contains("/") Then
            If Not Textooriginal.StartsWith("/") Then
                Separador = Split(Textooriginal, "/")
                Return Separador
            Else
                Textooriginal = "0" & "/" & Date.Now.Year
                Separador = Split(Textooriginal, "/")
                Return Separador
            End If
        End If
    End Function

    Public Function Divisordedosvariablesexpte(ByVal Textooriginal As String) As String()
        Dim Separador As String() = Nothing
        If Textooriginal.Contains("-") Then
            If Not Textooriginal.StartsWith("-") Then
                Separador = Split(Textooriginal, "-")
                Return Separador
            Else
                Textooriginal = "0" & "-" & Date.Now.Year
                Separador = Split(Textooriginal, "-")
                Return Separador
            End If
        End If
    End Function

    Public Function Divisordetresvariables(ByVal Textooriginal As String) As String()
        Dim Separador As String() = Nothing
        If Not Textooriginal = "" Then
            Separador = Split(Textooriginal.Replace("-", "/"), "/")
        End If
        Return Separador
    End Function

    Public Function DIVISORUNIVERSAL(ByVal Textooriginal As String) As String()
        Dim separador As String() = Nothing
        Select Case Textooriginal.Length > 8
            Case True
                separador = Split(Textooriginal.Replace("-", "/"), "/")
            Case False
        End Select
        Return separador
    End Function

    Public Sub CargarenMFyV(ByVal tablareferencia As DataTable, ByVal numerocuenta As String)
        Select Case MsgBox("Desea cargar los datos de fondos y valores ", MsgBoxStyle.YesNo, " ")
            Case MsgBoxResult.Yes
                Dim segundaparte_values As String = ""
                SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "
CREATE TABLE if not exists `mfyv` (
  `FECHA` date DEFAULT NULL,
  `CodInp` int(1) DEFAULT NULL,
  `Cod_orden` int(1) DEFAULT NULL,
  `Nrotransferencia` varchar(255) DEFAULT NULL,
  `Detalle` varchar(255) DEFAULT NULL,
  `CFdo` int(1) DEFAULT NULL,
  `PedidoFondo_N` int(7) DEFAULT NULL,
  `Expediente_N` varchar(255) DEFAULT NULL,
  `Expediente_year` int(4) DEFAULT NULL,
  `clave_expediente` varchar(255) DEFAULT NULL,
  `Ingresos` decimal(15,2) DEFAULT NULL,
  `Egresos` decimal(15,2) DEFAULT NULL,
  `Cuenta_N` varchar(255) DEFAULT NULL,
  `INDICEMD5` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
"
                Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@cuenta", numerocuenta)
                SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "delete from MFyV where Cuenta_N=@cuenta"
                Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
                Dim Cantidaddeinserciones As Integer = 100
                Dim Totaldeinserciones As Integer = 0
                For N = 0 To (tablareferencia.Rows.Count / Cantidaddeinserciones)
                    'Carga los datos y los parametros de consulta
                    For x = 0 To tablareferencia.Rows.Count - 1
                        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO MFyV ("
                        For i = 0 To tablareferencia.Columns.Count - 1
                            If i = tablareferencia.Columns.Count - 1 Then 'Verifica si es la última columna de la tabla
                                SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText += tablareferencia.Columns(i).ColumnName 'no coloca la coma
                                segundaparte_values = "@" & tablareferencia.Columns(i).ColumnName & ""
                            Else
                                SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText += tablareferencia.Columns(i).ColumnName & "," 'coloca la coma y da paso al siguiente
                                segundaparte_values += ","
                            End If
                        Next
                        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText += ") VALUES "
                    Next
                    'Carga los datos y los parametros de consulta
                    For x = 0 To Cantidaddeinserciones - 1
                        If (Totaldeinserciones + x + 1) >= tablareferencia.Rows.Count Then 'Verifica que no se exceda en el loop de carga
                            Exit For
                        Else
                            SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText += "( " 'abre el parentesis de datos
                            For i = 0 To tablareferencia.Columns.Count - 1
                                SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText += "@" & tablareferencia.Columns(i).ColumnName & x   'coloca el nombre del parametro dentro del string de salida
                                If i = tablareferencia.Columns.Count - 1 Then
                                    SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText += ""  'no coloca la coma
                                Else
                                    SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText += "," 'coloca la coma y da paso al siguiente
                                End If
                            Next
                            SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText += ") " 'cierra el parentesis de datos
                            If x = Cantidaddeinserciones - 1 Then   'verifica si ya finalizaron los valores
                                SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText += ";"            'Coloca item de finalización
                            Else
                                If (Totaldeinserciones + x + 2) >= tablareferencia.Rows.Count Then 'Verifica que no se exceda en el loop de carga
                                    SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText += ";"            'Coloca item de finalización
                                    Exit For
                                Else
                                    SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText += ","   'coloca la coma y da paso al siguiente
                                End If
                            End If
                        End If
                    Next
                    For x = 0 To Cantidaddeinserciones - 1
                        For i = 0 To tablareferencia.Columns.Count - 1
                            If (Totaldeinserciones + 1) >= tablareferencia.Rows.Count Then 'Verifica que no se exceda en el loop de carga
                                Exit For
                            Else
                                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@" & tablareferencia.Columns(i).ColumnName & x, tablareferencia.Rows(Totaldeinserciones).Item(i))  'inserta el nombre y valor del parametro
                            End If
                        Next
                        Totaldeinserciones += 1
                    Next
                    Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
                Next
                MessageBox.Show("Finalizado, cargados " & Totaldeinserciones & " Registros")
            Case Else
        End Select
    End Sub

    Public Sub CargarenMFyV_SAFI(ByVal tablareferencia As DataTable, ByVal numerocuenta As String)
        Select Case MsgBox("Desea cargar los datos de fondos y valores ", MsgBoxStyle.YesNo, " ")
            Case MsgBoxResult.Yes
                Dim segundaparte_values As String = ""
                SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "
CREATE TABLE if not exists `mfyv` (
  `FECHA` date DEFAULT NULL,
  `CodInp` int(1) DEFAULT NULL,
  `Cod_orden` int(1) DEFAULT NULL,
  `Nrotransferencia` varchar(255) DEFAULT NULL,
  `Detalle` varchar(255) DEFAULT NULL,
  `CFdo` int(1) DEFAULT NULL,
  `PedidoFondo_N` int(7) DEFAULT NULL,
  `Expediente_N` varchar(255) DEFAULT NULL,
  `Expediente_year` int(4) DEFAULT NULL,
  `clave_expediente` varchar(255) DEFAULT NULL,
  `Ingresos` decimal(15,2) DEFAULT NULL,
  `Egresos` decimal(15,2) DEFAULT NULL,
  `Cuenta_N` varchar(255) DEFAULT NULL,
  `INDICEMD5` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
"
                Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
                Dim Cantidaddeinserciones As Integer = 200
                Dim Totaldeinserciones As Integer = 0
                For N = 0 To (tablareferencia.Rows.Count / Cantidaddeinserciones)
                    'Carga los datos y los parametros de consulta
                    For x = 0 To tablareferencia.Rows.Count - 1
                        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT IGNORE INTO MFyV ("
                        For i = 0 To tablareferencia.Columns.Count - 1
                            If i = tablareferencia.Columns.Count - 1 Then 'Verifica si es la última columna de la tabla
                                SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText += tablareferencia.Columns(i).ColumnName 'no coloca la coma
                                segundaparte_values = "@" & tablareferencia.Columns(i).ColumnName & ""
                            Else
                                SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText += tablareferencia.Columns(i).ColumnName & "," 'coloca la coma y da paso al siguiente
                                segundaparte_values += ","
                            End If
                        Next
                        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText += ") VALUES "
                    Next
                    'Carga los datos y los parametros de consulta
                    For x = 0 To Cantidaddeinserciones - 1
                        If (Totaldeinserciones + x + 1) >= tablareferencia.Rows.Count Then 'Verifica que no se exceda en el loop de carga
                            Exit For
                        Else
                            SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText += "( " 'abre el parentesis de datos
                            For i = 0 To tablareferencia.Columns.Count - 1
                                SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText += "@" & tablareferencia.Columns(i).ColumnName & x   'coloca el nombre del parametro dentro del string de salida
                                If i = tablareferencia.Columns.Count - 1 Then
                                    SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText += ""  'no coloca la coma
                                Else
                                    SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText += "," 'coloca la coma y da paso al siguiente
                                End If
                            Next
                            SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText += ") " 'cierra el parentesis de datos
                            If x = Cantidaddeinserciones - 1 Then   'verifica si ya finalizaron los valores
                                SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText += ";"            'Coloca item de finalización
                            Else
                                If (Totaldeinserciones + x + 2) >= tablareferencia.Rows.Count Then 'Verifica que no se exceda en el loop de carga
                                    SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText += ";"            'Coloca item de finalización
                                    Exit For
                                Else
                                    SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText += ","   'coloca la coma y da paso al siguiente
                                End If
                            End If
                        End If
                    Next
                    For x = 0 To Cantidaddeinserciones - 1
                        For i = 0 To tablareferencia.Columns.Count - 1
                            If (Totaldeinserciones + 1) >= tablareferencia.Rows.Count Then 'Verifica que no se exceda en el loop de carga
                                Exit For
                            Else
                                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@" & tablareferencia.Columns(i).ColumnName & x, tablareferencia.Rows(Totaldeinserciones).Item(i))  'inserta el nombre y valor del parametro
                            End If
                        Next
                        Totaldeinserciones += 1
                    Next
                    If SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Count > 0 Then
                        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
                    Else
                        Totaldeinserciones += (Cantidaddeinserciones) * -1
                    End If
                Next
                MessageBox.Show("Finalizado, cargados " & Totaldeinserciones & " Registros")
            Case Else
        End Select
    End Sub

    Public Function CheckNum(parm_toParseStr As String, parm_cultureName As String) As Decimal
        'Convert the string sent to decimal value and raise an exception if conversion falils
        'Expects string to validate and culture name (e.g. en-US). If culture name not passed, current is used
        'Takes care of the missing feature in try parse, namely when a string of only "." is passed, tryparse
        ' does not convert it to 0.
        Dim style As NumberStyles
        Dim culture As CultureInfo
        Dim result As Decimal
        If String.IsNullOrEmpty(parm_cultureName) Then
            parm_cultureName = Thread.CurrentThread.CurrentCulture.Name
        End If
        'for style see: http://msdn.microsoft.com/en-us/library/system.globalization.numberstyles%28v=vs.110%29.aspx
        style = NumberStyles.Number Or NumberStyles.AllowLeadingSign
        culture = CultureInfo.CreateSpecificCulture(parm_cultureName)
        parm_toParseStr = parm_toParseStr.Trim()
        If String.IsNullOrEmpty(parm_toParseStr) Then
            parm_toParseStr = "0"
        End If
        ' Gets a NumberFormatInfo associated with the passed culture.
        Dim nfi As NumberFormatInfo = New CultureInfo(parm_cultureName, False).NumberFormat
        If parm_toParseStr = "+" OrElse parm_toParseStr = "-" OrElse parm_toParseStr = nfi.CurrencyDecimalSeparator Then
            '+ - and decimal point
            parm_toParseStr = "0"
        End If
        'for tryparse see: http://msdn.microsoft.com/en-us/library/ew0seb73%28v=vs.110%29.aspx?cs-save-lang=1&cs-lang=csharp#code-snippet-2
        If [Decimal].TryParse(parm_toParseStr, style, culture, result) Then
            Return result
        Else
            Throw New ArgumentNullException("Could not convert the passed value of:{0}", parm_toParseStr)
        End If
    End Function

    Public Function Verificarexistenciapedidofondo(ByVal tabla As String, ByVal columna As String, ByVal valoraverificar As String, ByVal codigopedidofondo As String) As Boolean
        Dim temporal As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Valoraverificar", valoraverificar)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_pedidofondo", codigopedidofondo)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select " & columna & " from " & tabla & " where " &
                             columna & "=@Valoraverificar and " & columna & " not in (SELECT " & columna &
                             " from pedido_fondos where clave_pedidofondo=@clave_pedidofondo)",
                             temporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Select Case temporal.Rows.Count > 0
            Case True
                Return True
            Case False
                Return False
            Case Else
                Return False
        End Select
    End Function

    Public Sub VerificarCUIT(ByRef sender As MaskedTextBox, ByVal Cuit As String, ByRef Nombre As Label, Optional ByVal DOMICILIO As Object = Nothing)
        If Not Cuit = "" Then
            Select Case ValidarCuit(Cuit)
                Case True
                    Dim CUIT_datatable As New DataTable
                    sender.BackColor = System.Drawing.Color.LightGreen
                    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@CUIT", Cuit)
                    Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select Proveedor,CUIT,Rubro,DOMICILIOREAL from proveedores Where CUIT=@CUIT", CUIT_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
                    If CUIT_datatable.Rows.Count > 0 Then
                        Nombre.Text = CUIT_datatable.Rows(0).Item("Proveedor").ToString
                        If Not IsNothing(DOMICILIO) Then
                            DOMICILIO.TEXT = CUIT_datatable.Rows(0).Item("DOMICILIOREAL").ToString
                        End If
                    Else
                        Nombre.Text = "Proveedor aún no registrado"
                    End If
                Case False
                    sender.BackColor = System.Drawing.Color.LightCoral
            End Select
        Else
            sender.BackColor = System.Drawing.Color.White
        End If
    End Sub

    Public Sub PROVEEDORESCUIT(ByRef sender As MaskedTextBox, ByVal Cuit As String, ByRef Nombre As Label, Optional ByVal DOMICILIO As Object = Nothing)
        If Not Cuit = "" Then
            Select Case ValidarCuit(Cuit)
                Case True
                    Dim CUIT_datatable As New DataTable
                    sender.BackColor = System.Drawing.Color.LightGreen
                    'CONSULTA AL REGISTRO DE PROVEEDORES
                    Dim prove As RegProveedores() = RespuestaProveedores.DevolverRegistroProveedor(Cuit)
                    Dim Proveedortemporal As New Proveedor
                    If Not IsNothing(prove) Then
                        'MessageBox.Show($" el nombre de este proveedor es {prove(0).companyName.ToString  }")
                        'Los cuits que comienzan en 30,33 y 34 son números de Cuits de empresas, por lo que no deberían llevar nombres de fantasia
                        If prove(0).fantasyName.ToString.Length > 0 And Not (Cuit.ToString.Substring(0, 2) = "30" Or Cuit.ToString.Substring(0, 2) = "33" Or Cuit.ToString.Substring(0, 2) = "34") Then
                            Nombre.Text = $"{prove(0).fantasyName.ToString} de {prove(0).companyName.ToString}"
                        Else
                            Nombre.Text = prove(0).companyName.ToString
                        End If
                        If prove(0).legalAddress(1).ToString.Length > 2 Then
                            DOMICILIO.TEXT = prove(0).legalAddress(1).ToString
                        Else
                            DOMICILIO.TEXT = prove(0).realAddress(1).ToString
                        End If
                        Try
                            Proveedortemporal.updateproveedorregistro(prove(0))
                        Catch ex As Exception
                            MessageBox.Show(ex.Message)
                        End Try
                    Else
                        ' EN CASO DE NO ENCONTRARSE NINGUNO EN LA BASE DE DATOS
                        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@CUIT", Cuit)
                        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select Proveedor,CUIT,Rubro,DOMICILIOREAL from proveedores Where CUIT=@CUIT", CUIT_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
                        If CUIT_datatable.Rows.Count > 0 Then
                            Nombre.Text = CUIT_datatable.Rows(0).Item("Proveedor").ToString
                            If Not IsNothing(DOMICILIO) Then
                                DOMICILIO.TEXT = CUIT_datatable.Rows(0).Item("DOMICILIOREAL").ToString
                            End If
                        Else
                            Nombre.Text = "Proveedor aún no registrado"
                        End If
                    End If
                Case False
                    sender.BackColor = System.Drawing.Color.LightCoral
            End Select
        Else
            sender.BackColor = System.Drawing.Color.White
        End If
    End Sub

    Public Function ValidarCuit(ByVal mk_p_nro As String) As Boolean
        Dim mk_suma As Integer
        Dim mk_valido As Boolean
        If Not mk_p_nro = "99-99999999-9" Then
            mk_p_nro = mk_p_nro.Replace("-", "")
            If Not (mk_p_nro = "") Then
                If IsNumeric(mk_p_nro) Then
                    If mk_p_nro.Length <> 11 Then
                        mk_valido = False
                    Else
                        mk_suma = 0
                        mk_suma += CInt(mk_p_nro.Substring(0, 1)) * 5
                        mk_suma += CInt(mk_p_nro.Substring(1, 1)) * 4
                        mk_suma += CInt(mk_p_nro.Substring(2, 1)) * 3
                        mk_suma += CInt(mk_p_nro.Substring(3, 1)) * 2
                        mk_suma += CInt(mk_p_nro.Substring(4, 1)) * 7
                        mk_suma += CInt(mk_p_nro.Substring(5, 1)) * 6
                        mk_suma += CInt(mk_p_nro.Substring(6, 1)) * 5
                        mk_suma += CInt(mk_p_nro.Substring(7, 1)) * 4
                        mk_suma += CInt(mk_p_nro.Substring(8, 1)) * 3
                        mk_suma += CInt(mk_p_nro.Substring(9, 1)) * 2
                        mk_suma += CInt(mk_p_nro.Substring(10, 1)) * 1
                        If Math.Round(mk_suma / 11, 0) = (mk_suma / 11) Then
                            mk_valido = True
                        Else
                            mk_valido = False
                        End If
                    End If
                Else
                    mk_valido = False
                End If
            Else
                mk_valido = False
            End If
        Else
            mk_valido = True
        End If
        Return (mk_valido)
    End Function

    Public Function GenerarCUIT_DNI(ByVal DNI As Integer, ByVal sexo As String) As String
        Dim DNIstring As String
        Dim arraycuit(10) As Integer
        Dim sumatotal As Integer = 0
        Dim primerdivision As Integer = 0
        Dim CUIT As String = ""
        Dim Sumador1 As Integer = 0
        If sexo.ToUpper = "MASCULINO" Then
            Sumador1 = 0
        Else
            Sumador1 = 28
        End If
        If DNI.ToString.Length = 7 Then
            DNIstring = "0" & DNI.ToString
        Else
            DNIstring = CType(DNI, String)
        End If
        arraycuit(2) = CType(DNIstring.Substring(0, 1), Integer) * 3
        arraycuit(3) = CType(DNIstring.Substring(1, 1), Integer) * 2
        arraycuit(4) = CType(DNIstring.Substring(2, 1), Integer) * 7
        arraycuit(5) = CType(DNIstring.Substring(3, 1), Integer) * 6
        arraycuit(6) = CType(DNIstring.Substring(4, 1), Integer) * 5
        arraycuit(7) = CType(DNIstring.Substring(5, 1), Integer) * 4
        arraycuit(8) = CType(DNIstring.Substring(6, 1), Integer) * 3
        arraycuit(9) = CType(DNIstring.Substring(7, 1), Integer) * 2
        sumatotal = Sumador1 + 10
        For z = 2 To 9
            sumatotal += arraycuit(z)
        Next
        primerdivision = 11 - (sumatotal Mod 11)
        'Calculo del ultimo digito
        If primerdivision > 9 Then
            If primerdivision = 11 Then
                arraycuit(10) = 0
            Else
                arraycuit(10) = 9
            End If
        Else
            arraycuit(10) = primerdivision
        End If
        'calculo de los primero dos digitos
        If (sumatotal Mod 11) = 1 Then
            If sexo.ToUpper = "MASCULINO" Then
                arraycuit(0) = 2
                arraycuit(1) = 3
                '"23"
            Else
                arraycuit(0) = 2
                arraycuit(1) = 3
                '"23"
            End If
        Else
            If sexo.ToUpper = "MASCULINO" Then
                arraycuit(0) = 2
                arraycuit(1) = 0
                '"20"
            Else
                arraycuit(0) = 2
                arraycuit(1) = 7
                '"27"
            End If
        End If
        CUIT = arraycuit(0) & arraycuit(1) & "-" & DNIstring & "-" & arraycuit(10)
        Return CUIT
    End Function

    Public Sub AbrirsitioWEB(url As String)
        Process.Start(Buscarpathdelexplorador(), url)
    End Sub

    Private Function Buscarpathdelexplorador() As String
        Dim key As String = "http\shell\open\command"
        Dim registryKey As RegistryKey = Registry.ClassesRoot.OpenSubKey(key, False)
        Return DirectCast(registryKey.GetValue(Nothing, Nothing), String).Split(""""c)(1)
    End Function

    Public Sub Mostrar_info(ByRef Nombredatos As String, ByRef Consultamysqlsinparametros As String, ByRef Proceso As String)
        Dim tablatemporal As New DataTable
        'MessageBox.Show(Consultamysqlsinparametros)
        SERVIDORMYSQL.COMMANDSQL.CommandText = Consultamysqlsinparametros
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, Consultamysqlsinparametros, tablatemporal, Proceso)
        Dialogo_datos.Datosdialogo_datagridview.DataSource = tablatemporal
        Dialogo_datos.Label_titulo.Text = Nombredatos
        ' Dialogo_datos.ShowDialog()
        Mostrardialogo(Dialogo_datos)
    End Sub

    Public Sub Mostrar_info_retenciones(ByRef Nombredatos As String, ByRef Consultamysqlsinparametros As String, ByRef Proceso As String)
        Dim tablatemporal As New DataTable
        'MessageBox.Show(Consultamysqlsinparametros)
        SERVIDORMYSQL.COMMANDSQL.CommandText = Consultamysqlsinparametros
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, Consultamysqlsinparametros, tablatemporal, Proceso)
        'Dialogoretenciones.Ganancias_datagridview.DataSource = tablatemporal
        '   Dialogoretenciones.Label_expedienteasociados.Text = Nombredatos
        'Dialogoretenciones.ShowDialog()
        Mostrardialogo(Tesoreria_Dialogoretenciones)
    End Sub

    Public Sub Mostrar_datatable(ByRef Nombredatos As String, ByRef tabladedatos As DataTable, ByRef Proceso As String)
        'MessageBox.Show(Consultamysqlsinparametros)
        Dialogo_datos.Datosdialogo_datagridview.DataSource = tabladedatos
        Dialogo_datos.Label_titulo.Text = Nombredatos
        '  Dialogo_datos.ShowDialog()
        Mostrardialogo(Dialogo_datos)
    End Sub

End Module
Public Module Manipulacioninterfaz
    Dim Tiempodetecleo As New Windows.Threading.DispatcherTimer()
    Dim activartimer As Boolean = False
    Dim Buscar_TIMER As TextBox
    Dim Tablatemporal_TIMER As New DataTable
    Dim Datos_Datagridview_TIMER As DataGridView

    Private Sub Tiempodetecleo_Tick(ByVal sender As Object, ByVal e As EventArgs)
        Select Case activartimer
            Case True
                'AQUI VA EL CUERPO DE LA GESTION
                Select Case Buscar_TIMER.Text.Length
                    Case Is = 0
                        'En caso de que el texto buscado sea "", se devuelve la tabla completa
                        Datos_Datagridview_TIMER.DataSource = Tablatemporal_TIMER
                    Case Else
                        'declaración de string de filtro
                        Dim Filtro As String = ""
                        If Not IsNothing(Tablatemporal_TIMER) Then
                            For X = 0 To Tablatemporal_TIMER.Columns.Count - 1
                                Select Case X
                                    Case = 0
                                        'para evaluar si solo tiene una columna
                                        If Tablatemporal_TIMER.Columns.Count - 1 = 0 Then
                                            'si solo tiene una columna no hace falta el conector lógico OR
                                            Filtro = " (CONVERT([" & Tablatemporal_TIMER.Columns(X).ColumnName.ToString & "], 'System.String') like '%" & Buscar_TIMER.Text & "%')"
                                        Else
                                            'con más de una columna debe ir concatenado con el conector lógico OR
                                            Filtro = " (CONVERT([" & Tablatemporal_TIMER.Columns(X).ColumnName.ToString & "], 'System.String') like '%" & Buscar_TIMER.Text & "%') OR  "
                                        End If
                                    Case Is = Tablatemporal_TIMER.Columns.Count - 1
                                        'Ultima columna no hace falta el conector lógico OR
                                        Filtro = Filtro & " (CONVERT([" & Tablatemporal_TIMER.Columns(X).ColumnName.ToString & "], 'System.String') like '%" & Buscar_TIMER.Text & "%') "
                                    Case Else
                                        'Columna desde la x=1 hasta la x=Tablatemporal.Columns.Count-2
                                        Filtro = Filtro & " (CONVERT([" & Tablatemporal_TIMER.Columns(X).ColumnName.ToString & "], 'System.String') like '%" & Buscar_TIMER.Text & "%') OR  "
                                End Select
                            Next
                            Datos_Datagridview_TIMER.DataSource = (New DataView(Tablatemporal_TIMER, Filtro, "[" & Tablatemporal_TIMER.Columns(0).ColumnName.ToString & "] Desc", DataViewRowState.CurrentRows)).ToTable
                        End If
                End Select
                'freno de mano al timer
                Tiempodetecleo.Stop()
                activartimer = False
            Case False
        End Select
    End Sub

    Public Sub Buscar_datagrid_TIMER(ByRef Buscar As TextBox, ByRef Tablatemporal As DataTable, ByRef Datos_Datagridview As DataGridView)
        'tomamos los controles que piden la busqueda, un textbox, un datagridview y una datatable, byref lo convertimos en variables locales.
        Buscar_TIMER = Buscar
        Tablatemporal_TIMER = Tablatemporal
        Datos_Datagridview_TIMER = Datos_Datagridview
        'If Not IsNothing(Datos_Datagridview.DataSource) Then
        '    Datos_Datagridview.DataSource = Nothing
        'End If
        '------------------------------------------------------------------------------
        'Cambiamos la variable de estado del timer a "activado"
        activartimer = True
        'Borramos cualquier instancia anterior del timer
        RemoveHandler Tiempodetecleo.Tick, AddressOf Tiempodetecleo_Tick
        'agregamos la instancia de ejecución del trabajo del timer
        AddHandler Tiempodetecleo.Tick, AddressOf Tiempodetecleo_Tick
        'Tiempo del timer para su ejecución
        Tiempodetecleo.Interval = TimeSpan.FromMilliseconds(50)
        'Iniciamos el Timer
        Tiempodetecleo.Start()
    End Sub

    'sub de busqueda sin timer
    Public Sub Buscar_datagrid(ByRef Buscar As TextBox, ByRef Tablatemporal As DataTable, ByRef Datos_Datagridview As DataGridView)
        Select Case Buscar.Text.Length
            Case Is = 0
                Datos_Datagridview.DataSource = Tablatemporal
            Case Else
                Dim Filtro As String = ""
                For X = 0 To Tablatemporal.Columns.Count - 1
                    Select Case X
                        Case = 0
                            'para evaluar si solo tiene una columna
                            If Tablatemporal.Columns.Count - 1 = 0 Then
                                'si solo tiene una columna no hace falta el conector lógico OR
                                Filtro = " (CONVERT([" & Tablatemporal.Columns(X).ColumnName.ToString & "], 'System.String') like '%" & Buscar.Text & "%')"
                            Else
                                'con más de una columna debe ir concatenado con el conector lógico OR
                                Filtro = " (CONVERT([" & Tablatemporal.Columns(X).ColumnName.ToString & "], 'System.String') like '%" & Buscar.Text & "%') OR  "
                            End If
                        Case Is = Tablatemporal.Columns.Count - 1
                            'Ultima columna no hace falta el conector lógico OR
                            Filtro = Filtro & " (CONVERT([" & Tablatemporal.Columns(X).ColumnName.ToString & "], 'System.String') like '%" & Buscar.Text & "%') "
                        Case Else
                            'Columna desde la x=1 hasta la x=Tablatemporal.Columns.Count-2
                            Filtro = Filtro & " (CONVERT([" & Tablatemporal.Columns(X).ColumnName.ToString & "], 'System.String') like '%" & Buscar.Text & "%') OR  "
                    End Select
                Next
                Datos_Datagridview.DataSource = New DataView(Tablatemporal,
                                  Filtro,
                                  "[" & Tablatemporal.Columns(0).ColumnName.ToString & "] Desc",
                                  DataViewRowState.CurrentRows)
        End Select
    End Sub

    '/sub de busqueda sin timer
    Public Sub Buscar_datagrid_dataview(ByRef Buscar As TextBox, ByRef Tabla As Object, ByRef Datos_Datagridview As DataGridView)
        Dim Filtro As String = ""
        Dim dv As New DataView
        Select Case Tabla.GetType.ToString
            Case Is = "System.Data.DataView"
                Select Case Buscar.Text.Length
                    Case Is = 0
                        Datos_Datagridview.DataSource = Tabla.ToTable
                    Case Else
                        For X = 0 To Tabla.ToTable.Columns.Count - 1
                            Select Case X
                                Case = 0
                                    Filtro = " (CONVERT([" & Tabla.ToTable.Columns(X).ColumnName.ToString & "], 'System.String') like '%" & Buscar.Text & "%') OR  "
                                Case Is = Tabla.ToTable.Columns.Count - 1
                                    Filtro = Filtro & " (CONVERT([" & Tabla.ToTable.Columns(X).ColumnName.ToString & "], 'System.String') like '%" & Buscar.Text & "%') "
                                Case Else
                                    Filtro = Filtro & " (CONVERT([" & Tabla.ToTable.Columns(X).ColumnName.ToString & "], 'System.String') like '%" & Buscar.Text & "%') OR  "
                            End Select
                        Next
                End Select
                dv = New DataView(Tabla.ToTable,
                                Filtro,
                                "[" & Tabla.ToTable.Columns(0).ColumnName.ToString & "] Desc",
                                DataViewRowState.CurrentRows)
            Case Is = "System.Data.DataTable"
                Select Case Buscar.Text.Length
                    Case Is = 0
                        Datos_Datagridview.DataSource = Tabla
                    Case Else
                        For X = 0 To Tabla.Columns.Count - 1
                            Select Case X
                                Case = 0
                                    Filtro = " (CONVERT([" & Tabla.Columns(X).ColumnName.ToString & "], 'System.String') like '%" & Buscar.Text & "%') OR  "
                                Case Is = Tabla.Columns.Count - 1
                                    Filtro = Filtro & " (CONVERT([" & Tabla.Columns(X).ColumnName.ToString & "], 'System.String') like '%" & Buscar.Text & "%') "
                                Case Else
                                    Filtro = Filtro & " (CONVERT([" & Tabla.Columns(X).ColumnName.ToString & "], 'System.String') like '%" & Buscar.Text & "%') OR  "
                            End Select
                        Next
                        dv = New DataView(Tabla,
                                          Filtro,
                                          "[" & Tabla.Columns(0).ColumnName.ToString & "] Desc",
                                          DataViewRowState.CurrentRows)
                End Select
        End Select
        Datos_Datagridview.DataSource = dv
    End Sub

    Public Function Buscar_datatable(ByRef Buscar As TextBox, ByRef Tablatemporal As DataTable) As DataView
        Select Case Buscar.Text.Length
            Case Is = 0
            Case Else
                Dim Filtro As String = ""
                For X = 0 To Tablatemporal.Columns.Count - 1
                    Select Case X
                        Case = 0
                            Filtro = " (CONVERT([" & Tablatemporal.Columns(X).ColumnName.ToString & "], 'System.String') like '%" & Buscar.Text & "%') OR  "
                        Case Is = Tablatemporal.Columns.Count - 1
                            Filtro = Filtro & " (CONVERT([" & Tablatemporal.Columns(X).ColumnName.ToString & "], 'System.String') like '%" & Buscar.Text & "%') "
                        Case Else
                            Filtro = Filtro & " (CONVERT([" & Tablatemporal.Columns(X).ColumnName.ToString & "], 'System.String') like '%" & Buscar.Text & "%') OR  "
                    End Select
                Next
                Return New DataView(Tablatemporal, Filtro, "[" & Tablatemporal.Columns(0).ColumnName.ToString & "] Desc", DataViewRowState.CurrentRows)
        End Select
    End Function

    Public Sub Click_ordenar_columna_Datagridview(ByRef sender As DataGridView, e As DataGridViewCellMouseEventArgs, ByVal Nombrecolumna_click As String, ByVal Nombrecolumna_ordenar As String)
        'Debe ser colocado en el sender.ColumnHeaderMouseClick
        Select Case sender.Columns(e.ColumnIndex).Name.ToUpper
            Case = Nombrecolumna_click.ToUpper
                sender.Columns(nombredecolumna(sender, Nombrecolumna_click)).SortMode = DataGridViewColumnSortMode.NotSortable
                If sender.SortOrder = SortOrder.Ascending Then
                    sender.Sort(sender.Columns(nombredecolumna(sender, Nombrecolumna_ordenar)), System.ComponentModel.ListSortDirection.Descending)
                Else
                    sender.Sort(sender.Columns(nombredecolumna(sender, Nombrecolumna_ordenar)), System.ComponentModel.ListSortDirection.Ascending)
                End If
            Case Else
        End Select
    End Sub

    Public Sub Formatocolumnas(ByRef datagrid As SICyF.Flicker_Datagridview, ByVal tabladedatos As DataTable)
        Dim SCROLLS As ScrollBars = datagrid.ScrollBars
        datagrid.ScrollBars = ScrollBars.None
        For x = 0 To tabladedatos.Columns.Count - 1
            Select Case tabladedatos.Columns(x).DataType.ToString.ToUpper
                Case Is = "SYSTEM.DATETIME"
                    datagrid.Columns(x).DefaultCellStyle.Format = "dd/MM/yyyy"
                Case Is = "SYSTEM.DATE"
                    If tabladedatos.Columns(x).ColumnName.ToString.ToUpper.Contains("CARGADO EL:") Then
                        datagrid.Columns(x).DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss.fff"
                    Else
                        datagrid.Columns(x).DefaultCellStyle.Format = "dd/MM/yyyy"
                    End If
                Case Is = "SYSTEM.DECIMAL"
                    datagrid.Columns(x).DefaultCellStyle.Format = "C"
                    datagrid.Columns(x).DefaultCellStyle.WrapMode = DataGridViewTriState.False
                    'datagrid.Columns(x).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
              '      datagrid.Columns(x).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Case Is = "SYSTEM.INT64"
                    datagrid.Columns(x).DefaultCellStyle.Format = "N0"
                    datagrid.Columns(x).DefaultCellStyle.WrapMode = DataGridViewTriState.False
                    ' datagrid.Columns(x).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
             '       datagrid.Columns(x).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Case Is = "SYSTEM.DBNULL"
                Case Else
                    'MessageBox.Show(Tabladatos.Columns(x).DataType.ToString.ToUpper)
            End Select
            If tabladedatos.Columns(x).ColumnName.ToString.ToUpper.Contains("CLAVE") Then
                datagrid.Columns(x).Visible = False
            End If
        Next
        FastAutoSizeColumns(datagrid)
        'datagrid.CurrentCell = Nothing
        datagrid.ScrollBars = SCROLLS
    End Sub

    Public Sub FastAutoSizeColumns(ByRef targetGrid As DataGridView)
        Dim gridTable = CType(targetGrid.DataSource, DataTable)
        ' Create a graphics object from the target grid. Used for measuring text size.
        Using gfx = targetGrid.CreateGraphics()
            ' Iterate through the columns.
            For i As Integer = 0 To gridTable.Columns.Count - 1
                If targetGrid.Columns(i).Visible Then
                    ' Leverage Linq enumerator to rapidly collect all the rows into a string array, making sure to exclude null values.
                    Dim colStringCollection As String() = gridTable.AsEnumerable().Where(Function(r) r.Field(Of Object)(i) IsNot Nothing).[Select](Function(r) r.Field(Of Object)(i).ToString()).ToArray()
                    ' Sort the string array by string lengths.
                    colStringCollection = colStringCollection.OrderBy(Function(x) x.Length).ToArray()
                    ' Get the last And longest string in the array.
                    If colStringCollection.Length > 0 Then
                        Dim longestColString As String = colStringCollection.Last()
                        ' Use the graphics object to measure the string size.
                        Dim colWidth = gfx.MeasureString(longestColString, targetGrid.Font)
                        'If the calculated width Is larger than the column header width, set the New column width.
                        If colWidth.Width > targetGrid.Columns(i).HeaderCell.Size.Width Then
                            If Not CInt(colWidth.Width) > 300 Then
                                If CInt(colWidth.Width) < 20 Then
                                    targetGrid.Columns(i).Width = targetGrid.Columns(i).HeaderCell.Size.Width
                                Else
                                    targetGrid.Columns(i).Width = CInt(colWidth.Width)
                                End If
                            Else
                                targetGrid.Columns(i).Width = 300
                            End If
                        Else ' Otherwise, set the column width to the header width.
                            targetGrid.Columns(i).Width = targetGrid.Columns(i).HeaderCell.Size.Width
                        End If
                    Else
                        targetGrid.Columns(i).Width = targetGrid.Columns(i).HeaderCell.Size.Width
                    End If
                End If
            Next
        End Using
    End Sub

    Dim Pos As Point

    Public Sub Moverventanasinborde(sender As Object, e As MouseEventArgs, ByRef ventana As Windows.Forms.Form)
        'Sub escrito para poder mover la ventana auxiliar arrastrando el panel de título, requiere handles de todos los elementos dentro del panel y de la variable (   Dim Pos As Point)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ventana.Location += Control.MousePosition - Pos
        End If
        Pos = Control.MousePosition
    End Sub

    Public Sub fondodialogomostrar()
        Dim m_frm As Form = New Form
        With m_frm
            .Opacity = 0.8
            .BackColor = System.Drawing.Color.White
            .ShowIcon = False
            .ShowInTaskbar = False
            .Size = New Size(Inicio.Width, Inicio.Height)
            .StartPosition = FormStartPosition.CenterScreen
            .Dock = DockStyle.Fill
            .FormBorderStyle = FormBorderStyle.None
        End With
        m_frm.Show()
    End Sub

    Public Sub Mostrardialogo(ByRef formulario As System.Windows.Forms.Form)
        Dim m_frm As Form = New Form
        With m_frm
            .Opacity = 0.5
            .TopLevel = False
            .BackColor = System.Drawing.Color.White
            .ShowIcon = False
            .ShowInTaskbar = False
            .Size = New Size(Inicio.Width, Inicio.Height)
            .StartPosition = FormStartPosition.CenterScreen
            .Dock = DockStyle.Fill
            .FormBorderStyle = FormBorderStyle.None
            '.Parent = Inicio
        End With
        m_frm.Show()
        With formulario
            .ShowInTaskbar = True
            .Icon = My.Resources.ic_border_color_black_18dp
        End With
        'If formulario.Visible = False Then
        formulario.ShowDialog()
        '    End If
        If formulario.Visible = True Then
            formulario.ShowDialog()
            m_frm.Visible = False
        Else
            '
        End If
        m_frm.Dispose()
        formulario.Dispose()
    End Sub

    Public Function HexToColor(ByVal hexColor As String) As Color
        If hexColor.IndexOf("#"c) <> -1 Then
            hexColor = hexColor.Replace("#", "")
        End If
        Dim red As Integer = 0
        Dim green As Integer = 0
        Dim blue As Integer = 0
        If hexColor.Length = 6 Then
            red = Integer.Parse(hexColor.Substring(0, 2), NumberStyles.AllowHexSpecifier)
            green = Integer.Parse(hexColor.Substring(2, 2), NumberStyles.AllowHexSpecifier)
            blue = Integer.Parse(hexColor.Substring(4, 2), NumberStyles.AllowHexSpecifier)
        ElseIf hexColor.Length = 3 Then
            red = Integer.Parse(hexColor(0).ToString() + hexColor(0).ToString(), NumberStyles.AllowHexSpecifier)
            green = Integer.Parse(hexColor(1).ToString() + hexColor(1).ToString(), NumberStyles.AllowHexSpecifier)
            blue = Integer.Parse(hexColor(2).ToString() + hexColor(2).ToString(), NumberStyles.AllowHexSpecifier)
        End If
        Return Color.FromArgb(100, red, green, blue)
    End Function

    Public Sub Cargaymodificaciondatatable(ByRef formulario As System.Windows.Forms.Form, ByRef tabladedatos As DataTable, ByRef datagrid As DataGridView)
        Dialogo_ModificarDatatable.CargarDatatable(formulario, tabladedatos, datagrid)
    End Sub

    Public Sub Colorcelda(ByVal Celda As DataGridViewCell, ByVal colorear As System.Drawing.Color)
        Celda.Style.BackColor = colorear
        Celda.Style.ForeColor = Inicio.GetContrastColor(colorear)
        Celda.Style.SelectionBackColor = Celda.Style.ForeColor
        Celda.Style.SelectionForeColor = Celda.Style.BackColor
    End Sub

    Public Sub Colorceldanormal(ByVal Celda As DataGridViewCell)
        Celda.Style.BackColor = System.Drawing.Color.White
        Celda.Style.ForeColor = System.Drawing.Color.Black
        'Celda.Style.SelectionBackColor = Celda.Style.BackColor
        'Celda.Style.SelectionForeColor = Celda.Style.ForeColor
    End Sub

    Public Sub Colorceldaok1(ByVal Celda As DataGridViewCell)
        Celda.Style.BackColor = System.Drawing.Color.LightGreen
        Celda.Style.ForeColor = System.Drawing.Color.Black
        'Celda.Style.SelectionBackColor = Celda.Style.BackColor
        'Celda.Style.SelectionForeColor = Celda.Style.ForeColor
    End Sub

    Public Sub Colorceldaok2(ByVal Celda As DataGridViewCell)
        Celda.Style.BackColor = System.Drawing.Color.Green
        Celda.Style.ForeColor = System.Drawing.Color.White
    End Sub

    Public Sub Colorceldaok3(ByVal Celda As DataGridViewCell)
        Celda.Style.BackColor = System.Drawing.Color.LightSkyBlue
        Celda.Style.ForeColor = System.Drawing.Color.Black
    End Sub

    Public Sub Colorceldano1(ByVal Celda As DataGridViewCell)
        Celda.Style.BackColor = System.Drawing.Color.LightCoral
        Celda.Style.ForeColor = System.Drawing.Color.White
        ' Celda.Style.Font = New System.Drawing.Font(Celda.Style.Font.Name, Celda.Style.Font.SizeInPoints, FontStyle.Regular)
    End Sub

    Public Sub Colorfila(ByVal Fila As DataGridViewRow, ByVal colorear As System.Drawing.Color)
        Fila.DefaultCellStyle.BackColor = colorear
        Fila.DefaultCellStyle.ForeColor = Inicio.GetContrastColor(colorear)
        Fila.DefaultCellStyle.SelectionBackColor = Inicio.GetContrastColor(Fila.DefaultCellStyle.ForeColor)
    End Sub

    Public Sub Colortextbox(ByVal textboxx As TextBox, ByVal colorear As System.Drawing.Color)
        textboxx.BackColor = colorear
        textboxx.ForeColor = Inicio.GetContrastColor(colorear)
    End Sub

    'Mouse y asociados
    Public Sub DataGridView_MouseWheel(ByVal sender As DataGridView, ByVal e As System.Windows.Forms.MouseEventArgs)
        'el form debe estar con keypreview activado.
        If Control.ModifierKeys = (Keys.Control) Then
            sender.SuspendLayout()
            sender.Enabled = False
            '  sender.Visible = False
            Dim scrollLines As Integer = SystemInformation.MouseWheelScrollLines
            Dim valorfuente As Integer = sender.DefaultCellStyle.Font.Size
            Dim fuente As System.Drawing.Font = New System.Drawing.Font(sender.DefaultCellStyle.Font.Name, valorfuente, FontStyle.Regular)
            Inicio.ToolStripDebug.Text = e.Delta.ToString
            Select Case e.Delta
                Case Is > 0 'Scrolling up.
                    fuente = New System.Drawing.Font(sender.DefaultCellStyle.Font.Name, valorfuente + 1, FontStyle.Regular)
                    sender.DefaultCellStyle.Font = fuente
                Case Is < 0  'Scrolling down
                    If valorfuente > 1 Then
                        fuente = New System.Drawing.Font(sender.DefaultCellStyle.Font.Name, valorfuente - 1, FontStyle.Regular)
                        sender.DefaultCellStyle.Font = fuente
                    Else
                        MsgBox("El valor de la fuente es demasiado pequeño")
                    End If
            End Select
            '   sender.Refresh()
            '  sender.Visible = True
            sender.Enabled = True
            sender.ResumeLayout()
        End If
    End Sub

    Public Sub KryptonDataGridView_MouseWheel(ByVal sender As ComponentFactory.Krypton.Toolkit.KryptonDataGridView, ByVal e As System.Windows.Forms.MouseEventArgs)
        'el form debe estar con keypreview activado.
        If Control.ModifierKeys = (Keys.Control) Then
            '  sender.Visible = False
            Dim scrollLines As Integer = SystemInformation.MouseWheelScrollLines
            Dim valorfuente As Single = sender.DefaultCellStyle.Font.Size
            Dim fuente As System.Drawing.Font = New System.Drawing.Font(sender.DefaultCellStyle.Font.Name, valorfuente, FontStyle.Regular)
            Inicio.ToolStripDebug.Text = e.Delta.ToString
            Select Case e.Delta
                Case Is > 0 'Scrolling up.
                    fuente = New System.Drawing.Font(sender.DefaultCellStyle.Font.Name, valorfuente + 1, FontStyle.Regular)
                    sender.DefaultCellStyle.Font = fuente
                Case Is < 0  'Scrolling down
                    fuente = New System.Drawing.Font(sender.DefaultCellStyle.Font.Name, valorfuente - 1, FontStyle.Regular)
                    sender.DefaultCellStyle.Font = fuente
            End Select
            '   sender.Refresh()
            '  sender.Visible = True
        End If
    End Sub

    Public Function ELEGIRCOMBOBOX(ByRef COMBO As ComboBox, ByVal TEXTO As String) As Integer
        Dim RESULTADO As Integer = 0
        If Not TEXTO = "" Then
            For X = 0 To COMBO.Items.Count - 1
                If COMBO.Items.Item(X).ToString = TEXTO Then
                    RESULTADO = X
                    Exit For
                End If
            Next
        End If
        Return RESULTADO
    End Function

    Public Function ELEGIRdatatable(ByRef tabla As DataTable, ByVal TEXTO As String, ByVal columna_comparar As Integer, ByVal columna_resultado As Integer) As String
        Dim RESULTADO As String = ""
        If Not TEXTO = "" Then
            For X = 0 To tabla.Rows.Count - 1
                If tabla.Rows(X).Item(columna_comparar).ToString = TEXTO Then
                    RESULTADO = tabla.Rows(X).Item(columna_resultado).ToString
                    Exit For
                End If
            Next
        End If
        Return RESULTADO
    End Function

    '/Mouse y asociados
End Module
Public Module ARCHIVOS

    Public Function csvToDatatable() As DataTable
        Dim tabla As New System.Data.DataTable
        Dim dialog As New OpenFileDialog()
        Using TryCast(dialog, IDisposable)
            dialog.Filter = "Archivo CSV |*.csv"
            dialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            dialog.Title = "Seleccione el archivo CSV"
            Dim result As DialogResult = dialog.ShowDialog
            If (dialog.SafeFileName.Length > 0) Then
                Dim csvFile As String = dialog.FileName
                Dim workbook As Workbook = New Workbook
                Dim filename As String = ""
                If dialog.SafeFileName.Length < 31 Then
                    filename = dialog.FileName
                Else
                    filename = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString().Substring(0, 12) + ".csv"
                    File.Copy(dialog.FileName, filename)
                End If
                workbook.LoadFromFile(filename, ",")
                Dim worksheet As Worksheet = workbook.Worksheets(0)
                tabla = worksheet.ExportDataTable
                If dialog.FileName <> filename Then
                    File.Delete(filename)
                End If
            End If
        End Using
        'Dim dialog As New OpenFileDialog()
        Return tabla
    End Function

End Module
Public Module Reportesgenerales

    Public Sub PDFDatagridview(ByVal Reporteaimprimir As DataGridView, ByVal Titulo As String, ByVal Horizontal As Boolean, ByVal Tamaniohoja As String)
        Dim Tamanio As Rectangle
        Select Case Tamaniohoja.ToUpper
            Case "LEGAL"
                Tamanio = iTextSharp.text.PageSize.LEGAL
            Case "A4"
                Tamanio = iTextSharp.text.PageSize.A4
            Case Else
                Tamanio = iTextSharp.text.PageSize.LEGAL
        End Select
        If Reporteaimprimir IsNot Nothing Then
            Dim totalcolumnas As Integer = -1
            For V = 0 To Reporteaimprimir.Columns.Count - 1
                If Not Reporteaimprimir.Columns(V).Visible = False Then
                    totalcolumnas = totalcolumnas + 1
                End If
            Next
            Dim Columnasvisibles(totalcolumnas) As Integer
            Dim control As Integer = 0
            For V = 0 To Reporteaimprimir.Columns.Count - 1
                If Reporteaimprimir.Columns(V).Visible = True Then
                    Columnasvisibles(control) = V
                    control = control + 1
                End If
            Next
            'MessageBox.Show(Columnasvisibles.Length - 1)
            Dim Controlguardado As New SaveFileDialog
            Controlguardado.Filter = "ARCHIVO PDF|*.pdf"
            Controlguardado.Title = "Guardar en archivo PDF"
            Controlguardado.ShowDialog()
            If Controlguardado.FileName = "" Then
                MsgBox("Para poder proceder a la creación del archivo se requiere un nombre")
                Exit Sub
            Else
                Dim font12BoldRed As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.UNDERLINE Or iTextSharp.text.Font.BOLDITALIC, BaseColor.RED)
                Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim font10Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim font12Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
                Dim font10Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
                Dim font07Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
                Dim titleFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim FileName As String = Controlguardado.FileName
                Dim paragraph As New Paragraph
                Dim anchototal As Integer = 0
                Dim doc As New Document
                'Selección de orientación de página
                If Horizontal Then
                    doc = New Document(Tamanio.Rotate, 20, 20, 20, 20)
                Else
                    doc = New Document(Tamanio, 20, 20, 20, 20)
                End If
                Dim wri As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(FileName, FileMode.Create))
                Dim ev As New itsEvents2
                wri.PageEvent = ev
                If doc.IsOpen Then
                    doc.Close()
                End If
                doc.Open()
                Dim encabezado As New Paragraph(Autorizaciones.Nombrecompletodelservicio, titleFont)
                Dim PdfTable As PdfPTable = New PdfPTable(Columnasvisibles.Length)
                'Selección de orientación de página
                If Horizontal Then
                    PdfTable.TotalWidth = Tamanio.Rotate.Width - 40
                Else
                    PdfTable.TotalWidth = Tamanio.Width - 40
                End If
                'fix the absolute width of the table
                PdfTable.LockedWidth = True
                'relative col widths in proportions
                Dim widths(0 To Columnasvisibles.Length - 1) As Single
                For i As Integer = 0 To Columnasvisibles.Length - 1
                    anchototal = anchototal + Reporteaimprimir.Columns(Columnasvisibles(i)).Width + 2
                Next
                For i As Integer = 0 To Columnasvisibles.Length - 1
                    widths(i) = CType((Reporteaimprimir.Columns(i).Width / anchototal), Single)
                Next
                PdfTable.HorizontalAlignment = 1 ' 0 --> Left, 1 --> Center, 2 --> Right
                PdfTable.SetWidths(widths)
                PdfTable.SpacingBefore = 12.0F
                'Declaración de celdas.
                Dim PdfPCell As PdfPCell = Nothing
                For X = 0 To Columnasvisibles.Length - 1
                    'Asignación de valores a cada celda como frases.
                    PdfPCell = New PdfPCell(New Phrase(New Chunk(Reporteaimprimir.Columns(Columnasvisibles(X)).HeaderText, font12Bold)))
                    'Alignment of phrase in the pdfcell
                    PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                    'Add pdfcell in pdftable
                    PdfTable.AddCell(PdfPCell)
                Next
                PdfTable.HeaderRows = 1
                'Agregar los datos del datagridview a la tabla
                For rows As Integer = 0 To Reporteaimprimir.Rows.Count - 1
                    For column As Integer = 0 To Columnasvisibles.Length - 1
                        If IsNothing(Reporteaimprimir.Rows(rows).Cells.Item(Columnasvisibles(column)).Value) Then
                            PdfPCell = New PdfPCell(New Phrase("", font07Normal))
                        Else
                            Select Case Reporteaimprimir.Rows(rows).Cells.Item(Columnasvisibles(column)).Value.GetType.ToString.ToUpper
                                Case Is = "SYSTEM.DATETIME"
                                    PdfPCell = New PdfPCell(New Phrase(CType(Reporteaimprimir.Rows(rows).Cells.Item(Columnasvisibles(column)).Value, Date).ToShortDateString, font07Normal))
                                Case Is = "SYSTEM.DECIMAL"
                                    PdfPCell = New PdfPCell(New Phrase(CType(Reporteaimprimir.Rows(rows).Cells.Item(Columnasvisibles(column)).Value, Decimal).ToString("C2"), font07Normal))
                                Case Is = "SYSTEM.DBNULL"
                                    PdfPCell = New PdfPCell(New Phrase("", font07Normal))
                                Case Else
                                    PdfPCell = New PdfPCell(New Phrase(Reporteaimprimir.Rows(rows).Cells.Item(Columnasvisibles(column)).Value.ToString, font07Normal))
                            End Select
                            ' PdfPCell = New PdfPCell(New Phrase(Reporteaimprimir.Rows(rows).Cells.Item(column).Value.ToString(), font09Normal))
                        End If
                        PdfTable.AddCell(PdfPCell)
                    Next
                Next
                'Agregar la tabla al documento
                doc.Add(PdfTable)
                'Verificar intento de agregar firma
                doc.Add(New Paragraph(Autorizaciones.Usuario.Rows(0).Item("Apellidos").ToString & "  " & Autorizaciones.Usuario.Rows(0).Item("nombres").ToString, FontFactory.GetFont("ARIAL", 7, iTextSharp.text.Font.BOLD)))
                doc.AddCreator(Autorizaciones.Usuario.Rows(0).Item("Apellidos").ToString & "  " & Autorizaciones.Usuario.Rows(0).Item("nombres").ToString)
                doc.AddHeader("", Autorizaciones.Nombrecompletodelservicio)
                Dim COLUMNA2 As New ColumnText(wri.DirectContent)
                'the Phrase
                'the lower left x corner (left)
                'the lower left y corner (bottom)
                'the upper right x corner (right)
                'the upper right y corner (top)
                'line height(leading)
                'alignment.
                Dim font14Bolds As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14.0F, iTextSharp.text.Font.BOLD, BaseColor.GRAY)
                COLUMNA2.SetSimpleColumn(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("SICyF", font14Bolds)),
                                        doc.Left, doc.Bottom,
                                      doc.Right, 0,
                                        15, Element.ALIGN_RIGHT)
                COLUMNA2.Go()
                doc.Close()
                Select Case MsgBox("Archivo generado Exitosamente" & vbCrLf & "Desea abrir el archivo generado?", MsgBoxStyle.YesNoCancel, " ")
                    Case MsgBoxResult.Yes
                        System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(Controlguardado.FileName) With {
                                                             .UseShellExecute = True})
                End Select
                'unaTabla.SetWidthPercentage(New Single() {300, 300}, PageSize.A4)
                ''Headers
                'unaTabla.AddCell(New Paragraph("Columna 1"))
                'unaTabla.AddCell(New Paragraph("Columna 2"))
                ''�Le damos un poco de formato?
                'For Each celda As PdfPCell In unaTabla.Rows(0).GetCells
                '    celda.BackgroundColor = BaseColor.LIGHT_GRAY
                '    celda.HorizontalAlignment = 1
                '    celda.Padding = 3
                'Next
                'Dim celda1 As PdfPCell = New PdfPCell(New Paragraph("Celda 1", FontFactory.GetFont("Arial", 10)))
                'Dim celda2 As PdfPCell = New PdfPCell(New Paragraph("Celda 2", FontFactory.GetFont("Arial", 10)))
                'Dim celda3 As PdfPCell = New PdfPCell(New Paragraph("Celda 3", FontFactory.GetFont("Arial", 10)))
                'Dim celda4 As PdfPCell = New PdfPCell(New Paragraph("Celda 4", FontFactory.GetFont("Arial", 10)))
                'unaTabla.AddCell(celda1)
                'unaTabla.AddCell(celda2)
                'unaTabla.AddCell(celda3)
                'unaTabla.AddCell(celda4)
                'doc.Add(unaTabla)
            End If
        End If
    End Sub

    Public Sub HOJALIBROBANCOPDF(ByVal Reporteaimprimir As DataGridView, ByVal Titulo As String, ByVal Horizontal As Boolean, ByVal Tamaniohoja As String, ByVal desde As Date, ByVal hasta As Date, ByVal Cuenta As Cuenta_Bancaria)
        Dim sumatotal As Decimal = 0
        Dim sumapasivos As Decimal = 0
        Dim sumaejercicio As Decimal = 0
        Dim CANTIDAD As Integer = 0
        Dim Tamanio As Rectangle
        Select Case Tamaniohoja.ToUpper
            Case "LEGAL"
                Tamanio = iTextSharp.text.PageSize.LEGAL
            Case "A4"
                Tamanio = iTextSharp.text.PageSize.A4
            Case Else
                Tamanio = iTextSharp.text.PageSize.LEGAL
        End Select
        If Reporteaimprimir IsNot Nothing Then
            Dim totalcolumnas As Integer = -1
            For V = 0 To Reporteaimprimir.Columns.Count - 1
                If Not Reporteaimprimir.Columns(V).Visible = False Then
                    totalcolumnas = totalcolumnas + 1
                End If
            Next
            Dim Columnasvisibles(totalcolumnas) As Integer
            Dim control As Integer = 0
            For V = 0 To Reporteaimprimir.Columns.Count - 1
                If Reporteaimprimir.Columns(V).Visible = True Then
                    Columnasvisibles(control) = V
                    control = control + 1
                End If
            Next
            For V = 0 To Reporteaimprimir.Rows.Count - 1
                sumatotal += Reporteaimprimir.Rows(V).Cells.Item("IMPORTE").Value
                Select Case Reporteaimprimir.Rows(V).Cells.Item("CFdo").Value
                    Case Is = 2
                        sumaejercicio += Reporteaimprimir.Rows(V).Cells.Item("IMPORTE").Value
                    Case Is = 9
                        sumapasivos += Reporteaimprimir.Rows(V).Cells.Item("IMPORTE").Value
                    Case Is = 1
                        sumaejercicio += Reporteaimprimir.Rows(V).Cells.Item("IMPORTE").Value
                End Select
                CANTIDAD += 1
            Next
            'MessageBox.Show(Columnasvisibles.Length - 1)
            Dim Controlguardado As New SaveFileDialog
            With Controlguardado
                Select Case System.IO.Directory.Exists("C:" & "\" & "REPORTES" & "\" & desde.Year & "\LIBRO_BANCO\")
                    Case True
                    Case False
                        System.IO.Directory.CreateDirectory("C:" & "\" & "REPORTES" & "\" & desde.Year & "\LIBRO_BANCO\")
                End Select
                .Filter = "ARCHIVO PDF|*.pdf"
                .Title = "Guardar en archivo PDF"
                If Titulo.Length > 19 Then
                    .FileName = Titulo.Remove(0, 19) & " " & desde.Date.ToString("yyyy-MM-dd") & " AL " & hasta.Date.ToString("yyyy-MM-dd") & ".pdf"
                Else
                    .FileName = Titulo & " " & desde.Date.ToString("yyyy-MM-dd") & " AL " & hasta.Date.ToString("yyyy-MM-dd") & ".pdf"
                End If
                'If Titulo.Length > 19 Then
                '    .FileName = Titulo.Remove(0, 19) & " " & desde.Date.ToString("yyyy-MM-dd") & " AL " & hasta.Date.ToString("yyyy-MM-dd") & ".pdf"
                'Else
                '    .FileName = Titulo.Remove(0, 19) & " " & desde.Date.ToString("yyyy-MM-dd") & " AL " & hasta.Date.ToString("yyyy-MM-dd") & ".pdf"
                'End If
                .RestoreDirectory = True
                .InitialDirectory = "C:" & "\" & "REPORTES" & "\" & desde.Year & "\LIBRO_BANCO\"
            End With
            Controlguardado.Filter = "ARCHIVO PDF|*.pdf"
            Controlguardado.Title = "Guardar en archivo PDF"
            Controlguardado.ShowDialog()
            If Controlguardado.FileName = "" Then
                MsgBox("Para poder proceder a la creación del archivo se requiere un nombre")
                Exit Sub
            Else
                Dim font12BoldRed As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.UNDERLINE Or iTextSharp.text.Font.BOLDITALIC, BaseColor.RED)
                Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim font10Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim font12Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
                Dim font10Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
                Dim font07Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
                Dim titleFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim FileName As String = Controlguardado.FileName
                Dim paragraph As New Paragraph
                Dim anchototal As Integer = 0
                Dim doc As New Document
                'Selección de orientación de página
                If Horizontal Then
                    doc = New Document(Tamanio.Rotate, 20, 20, 20, 20)
                Else
                    doc = New Document(Tamanio, 20, 20, 20, 20)
                End If
                Dim wri As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(FileName, FileMode.Create))
                'Encabezado del reporte en class itseventsx
                Dim ev As New itsEventsX
                Select Case desde = hasta
                    Case True
                        ev.textoencabezado = "Hoja Libro día " & desde.Date.ToShortDateString & "Total = " & sumatotal.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")) &
                            "(EJ=" & sumaejercicio.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")) & ") " & "(RP=" & sumapasivos.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")) & ")"
                    Case False
                        ev.textoencabezado = "Hoja Libro desde " & desde.Date.ToShortDateString & " al " & hasta.Date.ToShortDateString & vbCrLf &
                            "Total= " & sumatotal.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")) &
                            "(EJ=" & sumaejercicio.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")) & ") " & "(RP=" & sumapasivos.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")) & ")"
                End Select
                ev.Tipo_reporte = Titulo
                Dim cuentas() As Cuenta_Bancaria = Nothing
                If Titulo.ToUpper.Contains("SAFI") Then
                    cuentas.Add(New Cuenta_Bancaria)
                    ev.textoencabezado = " "
                    ev.Tipo_reporte = Titulo
                ElseIf Titulo.ToUpper = "HOJA DE LIBRO BANCO RETENCIONES" Then
                    cuentas.Add(New Cuenta_Bancaria)
                    ev.textoencabezado = " "
                    ev.Tipo_reporte = Titulo
                Else
                    cuentas.Add(Cuenta)
                End If
                ev.Cuenta = cuentas
                wri.PageEvent = ev
                If doc.IsOpen Then
                    doc.Close()
                End If
                Try
                    doc.Open()
                Catch ex As Exception
                End Try
                Dim encabezado As New Paragraph(Autorizaciones.Nombrecompletodelservicio, titleFont)
                Dim PdfTable As PdfPTable = New PdfPTable(Columnasvisibles.Length)
                'Selección de orientación de página
                If Horizontal Then
                    PdfTable.TotalWidth = Tamanio.Rotate.Width - 40
                Else
                    PdfTable.TotalWidth = Tamanio.Width - 40
                End If
                'fix the absolute width of the table
                PdfTable.LockedWidth = True
                'relative col widths in proportions
                Dim widths(0 To Columnasvisibles.Length - 1) As Single
                For i As Integer = 0 To Columnasvisibles.Length - 1
                    anchototal = anchototal + Reporteaimprimir.Columns(Columnasvisibles(i)).Width + 2
                Next
                For i As Integer = 0 To Columnasvisibles.Length - 1
                    widths(i) = CType((Reporteaimprimir.Columns(i).Width / anchototal), Single)
                Next
                PdfTable.HorizontalAlignment = 1 ' 0 --> Left, 1 --> Center, 2 --> Right
                PdfTable.SetWidths(widths)
                PdfTable.SpacingBefore = 12.0F
                'Declaración de celdas.
                Dim PdfPCell As PdfPCell = Nothing
                For X = 0 To Columnasvisibles.Length - 1
                    'Asignación de valores a cada celda como frases.
                    PdfPCell = New PdfPCell(New Phrase(New Chunk(Reporteaimprimir.Columns(Columnasvisibles(X)).HeaderText, font10Bold)))
                    'Alignment of phrase in the pdfcell
                    PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                    'Add pdfcell in pdftable
                    PdfTable.AddCell(PdfPCell)
                Next
                PdfTable.HeaderRows = 1
                'Agregar los datos del datagridview a la tabla
                For rows As Integer = 0 To Reporteaimprimir.Rows.Count - 1
                    For column As Integer = 0 To Columnasvisibles.Length - 1
                        If IsNothing(Reporteaimprimir.Rows(rows).Cells.Item(Columnasvisibles(column)).Value) Then
                            PdfPCell = New PdfPCell(New Phrase("", font10Normal))
                        Else
                            Select Case Reporteaimprimir.Rows(rows).Cells.Item(Columnasvisibles(column)).Value.GetType.ToString.ToUpper
                                Case Is = "SYSTEM.DATETIME"
                                    PdfPCell = New PdfPCell(New Phrase(CType(Reporteaimprimir.Rows(rows).Cells.Item(Columnasvisibles(column)).Value, Date).ToShortDateString, font10Normal))
                                Case Is = "SYSTEM.DECIMAL"
                                    PdfPCell = New PdfPCell(New Phrase(CType(Reporteaimprimir.Rows(rows).Cells.Item(Columnasvisibles(column)).Value, Decimal).ToString("C2", Globalization.CultureInfo.GetCultureInfo("es-AR")), font10Normal))
                                Case Is = "SYSTEM.DBNULL"
                                    PdfPCell = New PdfPCell(New Phrase("", font10Normal))
                                Case Else
                                    PdfPCell = New PdfPCell(New Phrase(Reporteaimprimir.Rows(rows).Cells.Item(Columnasvisibles(column)).Value.ToString, font10Normal))
                            End Select
                            ' PdfPCell = New PdfPCell(New Phrase(Reporteaimprimir.Rows(rows).Cells.Item(column).Value.ToString(), font09Normal))
                        End If
                        PdfTable.AddCell(PdfPCell)
                    Next
                Next
                'Agregar la tabla al documento
                doc.Add(PdfTable)
                'Verificar intento de agregar firma
                If Titulo.ToUpper.Contains("REPORTE CARGA SAFI") Or Titulo.ToUpper = "HOJA DE LIBRO BANCO RETENCIONES" Then
                    'TOTALES CUADRO
                    Dim Datosdelista As New List(Of ValueTuple(Of String, Decimal, Decimal, Decimal, Decimal, Integer)) 'NUMERO DE CUENTA, INGRESOS RP, EGRESOS RP, INGRESOS EJ,EGRESOS EJ.
                    Dim Indextuple As Integer = -1
                    Dim cuentasvarias() As Cuenta_Bancaria = Nothing
                    For Each r As DataGridViewRow In Reporteaimprimir.Rows
                        ' Indextuple = -1
                        Indextuple = Datosdelista.FindIndex(Function(X) X.Item1 = r.Cells.Item("cuenta_pedidofondo").Value.ToString)
                        'If Datosdelista.Count = 0 Then
                        '    Datosdelista.Add(ValueTuple.Create(r.Cells.Item("cuenta_pedidofondo").Value.ToString, CType(0, Decimal), CType(0, Decimal), CType(0, Decimal), CType(0, Decimal), CType(0, Integer)))
                        '    Indextuple = 0
                        'Else
                        'End If
                        If Not Indextuple >= 0 Then
                            Datosdelista.Add(ValueTuple.Create(r.Cells.Item("cuenta_pedidofondo").Value.ToString, CType(0, Decimal), CType(0, Decimal), CType(0, Decimal), CType(0, Decimal), CType(0, Integer)))
                            Indextuple = Datosdelista.FindIndex(Function(X) X.Item1 = r.Cells.Item("cuenta_pedidofondo").Value.ToString)
                        End If
                        Select Case r.Cells.Item("CFdo").Value.ToString & r.Cells.Item("codinp").Value.ToString
                            Case Is = "21"
                                'Egresos Ejercicio
                                Datosdelista(Indextuple) = (
                                    Datosdelista(Indextuple).Item1,
                                    Datosdelista(Indextuple).Item2,
                                    Datosdelista(Indextuple).Item3,
                                    Datosdelista(Indextuple).Item4,
                                    Datosdelista(Indextuple).Item5 + CType(r.Cells.Item("importe").Value, Decimal),
                                    Datosdelista(Indextuple).Item6 + 1)
                            Case Is = "11"
                                'Egresos Ejercicio
                                Datosdelista(Indextuple) = (
                                    Datosdelista(Indextuple).Item1,
                                    Datosdelista(Indextuple).Item2,
                                    Datosdelista(Indextuple).Item3,
                                    Datosdelista(Indextuple).Item4,
                                    Datosdelista(Indextuple).Item5 + CType(r.Cells.Item("importe").Value, Decimal),
                                    Datosdelista(Indextuple).Item6 + 1)
                            Case Is = "91"
                                'Egresos Residuos pasivos
                                Datosdelista(Indextuple) = (
                                   Datosdelista(Indextuple).Item1,
                                   Datosdelista(Indextuple).Item2,
                                   Datosdelista(Indextuple).Item3 + CType(r.Cells.Item("importe").Value, Decimal),
                                   Datosdelista(Indextuple).Item4,
                                   Datosdelista(Indextuple).Item5,
                                    Datosdelista(Indextuple).Item6 + 1)
                            Case Is = "23"
                                'Ingresos Ejercicio
                                Datosdelista(Indextuple) = (
                                   Datosdelista(Indextuple).Item1,
                                   Datosdelista(Indextuple).Item2,
                                   Datosdelista(Indextuple).Item3,
                                   Datosdelista(Indextuple).Item4 + CType(r.Cells.Item("importe").Value, Decimal),
                                   Datosdelista(Indextuple).Item5,
                                    Datosdelista(Indextuple).Item6 + 1)
                            Case Is = "93"
                                'Ingresos Residuos pasivos
                                Datosdelista(Indextuple) = (
                                   Datosdelista(Indextuple).Item1,
                                   Datosdelista(Indextuple).Item2 + CType(r.Cells.Item("importe").Value, Decimal),
                                   Datosdelista(Indextuple).Item3,
                                   Datosdelista(Indextuple).Item4,
                                   Datosdelista(Indextuple).Item5,
                                    Datosdelista(Indextuple).Item6 + 1)
                            Case Else
                                MessageBox.Show("VERIFICAR CODIGO DE CLASE E IMPUTACION" & vbCrLf & r.Cells.Item("CFdo").Value.ToString & r.Cells.Item("codinp").Value.ToString)
                        End Select
                    Next
                    For i = 0 To Datosdelista.Count - 1
                        Cuenta.CuentaN = Datosdelista(i).Item1
                        Cuenta.nombre()
                        cuentasvarias.Add(Cuenta)
                    Next
                    Dim Tablatemporal As New DataTable
                    With Tablatemporal
                        .Columns.Add("Desc.", System.Type.GetType("System.String"))
                        .Columns.Add("Cuenta", System.Type.GetType("System.String"))
                        .Columns.Add("Movimientos.", System.Type.GetType("System.Int32"))
                        .Columns.Add("Ingresos RP", System.Type.GetType("System.Decimal"))
                        .Columns.Add("Egresos RP", System.Type.GetType("System.Decimal"))
                        .Columns.Add("Ingresos Ej.", System.Type.GetType("System.Decimal"))
                        .Columns.Add("Egresos Ej.", System.Type.GetType("System.Decimal"))
                        .Columns.Add("Ingresos", System.Type.GetType("System.Decimal"))
                        .Columns.Add("Cargos", System.Type.GetType("System.Decimal"))
                    End With
                    For Each item In Datosdelista
                        Cuenta.CuentaN = item.Item1
                        With item
                            Tablatemporal.Rows.Add(
                                    {
                                    Cuenta.nombre(),
                                    item.Item1,
                                     item.Item6,
                                    item.Item2,
                                    item.Item3,
                                    item.Item4,
                                    item.Item5,
                                    item.Item2 + item.Item4,
                                    item.Item3 + item.Item5
                                                                    })
                        End With
                    Next
                    Dim Tablatotales As PdfPTable = datatabletopdfptable(Tablatemporal, doc, font10Normal.Size)
                    With Tablatotales
                        .SpacingAfter = 4.0F
                        .SpacingBefore = 4.0F
                    End With
                    doc.Add(Tablatotales)
                End If
                doc.Add(New Paragraph(Autorizaciones.Usuario.Rows(0).Item("Apellidos").ToString & "  " & Autorizaciones.Usuario.Rows(0).Item("nombres").ToString, FontFactory.GetFont("ARIAL", 6, iTextSharp.text.Font.BOLD)))
                doc.AddCreator(Autorizaciones.Usuario.Rows(0).Item("Apellidos").ToString & "  " & Autorizaciones.Usuario.Rows(0).Item("nombres").ToString)
                doc.AddHeader("", Autorizaciones.Nombrecompletodelservicio)
                Dim COLUMNA2 As New ColumnText(wri.DirectContent)
                'the Phrase
                'the lower left x corner (left)
                'the lower left y corner (bottom)
                'the upper right x corner (right)
                'the upper right y corner (top)
                'line height(leading)
                'alignment.
                Dim font14Bolds As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14.0F, iTextSharp.text.Font.BOLD, BaseColor.GRAY)
                COLUMNA2.SetSimpleColumn(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("SICyF", font14Bolds)),
                                            doc.Left, doc.Bottom,
                                          doc.Right, 0,
                                            15, Element.ALIGN_RIGHT)
                COLUMNA2.Go()
                doc.Close()
                Select Case MsgBox("Archivo generado Exitosamente" & vbCrLf & "Desea abrir el archivo generado?", MsgBoxStyle.YesNoCancel, " ")
                    Case MsgBoxResult.Yes
                        System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(Controlguardado.FileName) With {
                                                                 .UseShellExecute = True})
                End Select
            End If
        End If
    End Sub

    Public Function PDFDatatable(ByVal Table As DataTable, ByVal widths() As Single, ByVal espacioantes As Single, ByVal Tamaniototal As Single, ByVal Encabezado As Boolean, ByVal Colorencabezado As iTextSharp.text.BaseColor, ByVal tamaniodefuente As Single, Optional ByVal bold As Boolean = False) As iTextSharp.text.pdf.PdfPTable
        If Table IsNot Nothing Then
            Dim totalcolumnas As Integer = Table.Columns.Count
            ' Dim Columnasvisibles(totalcolumnas) As Integer
            Dim control As Integer = 0
            Dim PARRAFOCOMPLETO As New iTextSharp.text.Paragraph()
            Dim font12BoldRed As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.UNDERLINE Or iTextSharp.text.Font.BOLDITALIC, BaseColor.RED)
            Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font10Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font12Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim font10Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim font07Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim font07bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim titleFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim Fuentenormal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, tamaniodefuente, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim fuentebold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, tamaniodefuente, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim PdfTable As PdfPTable = New PdfPTable(totalcolumnas)
            'fix the absolute width of the table
            PdfTable.TotalWidth = Tamaniototal
            PdfTable.SetWidths(widths)
            PdfTable.LockedWidth = True
            'relative col widths in proportions
            ' PdfTable.SetWidths(widths)
            PdfTable.HorizontalAlignment = 1 ' 0 --> Left, 1 --> Center, 2 --> Right
            PdfTable.SpacingBefore = espacioantes
            'Declaración de celdas.
            Dim PdfPCell As PdfPCell = Nothing
            If Encabezado = True Then
                For X = 0 To totalcolumnas - 1
                    'Asignación de valores a cada celda como frases.
                    If bold Then
                        PdfPCell = New PdfPCell(New Phrase(New Chunk(Table.Columns(X).Caption, fuentebold)))
                    Else
                        PdfPCell = New PdfPCell(New Phrase(New Chunk(Table.Columns(X).Caption, Fuentenormal)))
                    End If
                    'Alignment of phrase in the pdfcell
                    PdfPCell.HorizontalAlignment = 1
                    PdfPCell.BackgroundColor = Colorencabezado
                    'Add pdfcell in pdftable
                    PdfTable.AddCell(PdfPCell)
                Next
                PdfTable.HeaderRows = 1
            End If
            'Agregar los datos del DATATABLE a la tabla ITEXTSHARP_PDF
            'If Table.Rows.Count = 1 Then
            '    If Table.Rows(0).Item(Table.Columns.Count - 1) = 0 Then
            '        PdfPCell = Phrasepdf("SIN MOVIMIENTOS", 12, False, 0.5, totalcolumnas - 3, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
            '        PdfTable.AddCell(PdfPCell)
            '    End If
            'Else
            For rows As Integer = 0 To Table.Rows.Count - 1
                For column As Integer = 0 To totalcolumnas - 1
                    If IsNothing(Table.Rows(rows).Item(column)) Then
                        'PARRAFOCOMPLETO.Add((New Phrase("", font07Normal)))
                        PdfPCell = Phrasepdf("", 7, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                    Else
                        Select Case Table.Rows(rows).Item(column).GetType.ToString.ToUpper
                            Case Is = "SYSTEM.DATETIME"
                                'PARRAFOCOMPLETO.Add((New Phrase(CType(Table.Rows(rows).Item(column), Date).ToShortDateString, Fuentenormal)))
                                PdfPCell = Phrasepdf(CType(Table.Rows(rows).Item(column), Date).ToShortDateString, tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                            Case Is = "SYSTEM.DECIMAL"
                                If Not Table.Columns(column).ColumnName.ToUpper = "ALICUOTA" Then
                                    'PARRAFOCOMPLETO.Add((New Phrase(CType(Table.Rows(rows).Item(column), Decimal).ToString("C2", Globalization.CultureInfo.GetCultureInfo("es-AR")), Fuentenormal)))
                                    PdfPCell = Phrasepdf(CType(Table.Rows(rows).Item(column), Decimal).ToString("C2", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_RIGHT, 2, Element.ALIGN_MIDDLE)
                                Else
                                    'PARRAFOCOMPLETO.Add((New Phrase((CType(Table.Rows(rows).Item(column), Decimal) / 100).ToString("P", Globalization.CultureInfo.GetCultureInfo("es-AR")), Fuentenormal)))
                                    PdfPCell = Phrasepdf((CType(Table.Rows(rows).Item(column), Decimal) / 100).ToString("P", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, True, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                                End If
                              '  PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT
                            Case Is = "SYSTEM.DBNULL"
                                'PARRAFOCOMPLETO.Add((New Phrase("", Fuentenormal)))
                                PdfPCell = Phrasepdf("", 7, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                            Case Else
                                'PARRAFOCOMPLETO.Add((New Phrase(Table.Rows(rows).Item(column).ToString, Fuentenormal)))
                                PdfPCell = Phrasepdf(Table.Rows(rows).Item(column).ToString, tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                        End Select
                    End If
                    PdfTable.AddCell(PdfPCell)
                Next
            Next
            ' End If
            'Agregar la tabla al documento
            Return PdfTable
        End If
    End Function

    Public Function PDFDatatablepartidapresupuestaria(ByVal Table As DataTable, ByVal widths() As Single, ByVal espacioantes As Single, ByVal Tamaniototal As Single, ByVal Encabezado As Boolean, ByVal Colorencabezado As iTextSharp.text.BaseColor, ByVal tamaniodefuente As Single, Optional ByVal bold As Boolean = False) As iTextSharp.text.pdf.PdfPTable
        If Table IsNot Nothing Then
            Dim totalcolumnas As Integer = Table.Columns.Count
            Dim listadodepartidas As New List(Of String)
            Dim subtotales As New List(Of Decimal)
            Dim cantidad_subtotales As New List(Of Integer)
            Dim partidaconcatenada As String = Nothing
            For x = 0 To Table.Rows.Count - 1
                For c = 0 To Table.Columns.Count - 3
                    If Not (c = Table.Columns.Count - 3) Then
                        partidaconcatenada += Table.Rows(x).Item(c).ToString & "-"
                    Else
                        partidaconcatenada += Table.Rows(x).Item(c).ToString
                    End If
                Next
                If listadodepartidas.Contains(partidaconcatenada) Then
                    'acumula los subtotales
                    subtotales.Item(listadodepartidas.IndexOf(partidaconcatenada)) += Table.Rows(x).Item(Table.Columns.Count - 1)
                    cantidad_subtotales.Item(listadodepartidas.IndexOf(partidaconcatenada)) += 1
                Else
                    'carga una nueva "cuenta" y su valor correspondiente
                    listadodepartidas.Add(partidaconcatenada)
                    subtotales.Add(Table.Rows(x).Item(Table.Columns.Count - 1))
                    cantidad_subtotales.Add(1)
                End If
                partidaconcatenada = Nothing
            Next
            ' Dim Columnasvisibles(totalcolumnas) As Integer
            Dim control As Integer = 0
            Dim PARRAFOCOMPLETO As New iTextSharp.text.Paragraph()
            Dim font12BoldRed As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.UNDERLINE Or iTextSharp.text.Font.BOLDITALIC, BaseColor.RED)
            Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font10Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font12Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim font10Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim font07Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim font07bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim titleFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim Fuentenormal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, tamaniodefuente, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim fuentebold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, tamaniodefuente, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim PdfTable As PdfPTable = New PdfPTable(totalcolumnas)
            'fix the absolute width of the table
            PdfTable.TotalWidth = Tamaniototal
            PdfTable.SetWidths(widths)
            PdfTable.LockedWidth = True
            'relative col widths in proportions
            ' PdfTable.SetWidths(widths)
            PdfTable.HorizontalAlignment = 1 ' 0 --> Left, 1 --> Center, 2 --> Right
            PdfTable.SpacingBefore = espacioantes
            'Declaración de celdas.
            Dim PdfPCell As PdfPCell = Nothing
            If Encabezado = True Then
                For X = 0 To totalcolumnas - 1
                    'Asignación de valores a cada celda como frases.
                    If bold Then
                        PdfPCell = New PdfPCell(New Phrase(New Chunk(Table.Columns(X).Caption, fuentebold)))
                    Else
                        PdfPCell = New PdfPCell(New Phrase(New Chunk(Table.Columns(X).Caption, Fuentenormal)))
                    End If
                    'Alignment of phrase in the pdfcell
                    PdfPCell.HorizontalAlignment = 1
                    PdfPCell.BackgroundColor = Colorencabezado
                    'Add pdfcell in pdftable
                    PdfTable.AddCell(PdfPCell)
                Next
                PdfTable.HeaderRows = 1
            End If
            Dim PdfPCellsubtotales As PdfPCell = Nothing
            Dim partidacuentaactual As String = ""
            For rows As Integer = 0 To Table.Rows.Count - 1
                partidacuentaactual = Nothing
                For c = 0 To Table.Columns.Count - 3
                    If Not (c = Table.Columns.Count - 3) Then
                        partidacuentaactual += Table.Rows(rows).Item(c).ToString & "-"
                    Else
                        partidacuentaactual += Table.Rows(rows).Item(c).ToString
                    End If
                Next
                For column As Integer = 0 To totalcolumnas - 1
                    If IsNothing(Table.Rows(rows).Item(column)) Then
                        PdfPCell = Phrasepdf("", 7, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                    Else
                        Select Case Table.Rows(rows).Item(column).GetType.ToString.ToUpper
                            Case Is = "SYSTEM.DATETIME"
                                PdfPCell = Phrasepdf(CType(Table.Rows(rows).Item(column), Date).ToShortDateString, tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                            Case Is = "SYSTEM.DECIMAL"
                                If Not Table.Columns(column).ColumnName.ToUpper = "ALICUOTA" Then
                                    If cantidad_subtotales.Item(listadodepartidas.IndexOf(partidacuentaactual)) = 1 Then
                                        PdfPCell = Phrasepdf(CType(Table.Rows(rows).Item(column), Decimal).ToString("C2", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, True, 0.5, 1, 1, Element.ALIGN_RIGHT, 2, Element.ALIGN_MIDDLE)
                                    Else
                                        PdfPCell = Phrasepdf(CType(Table.Rows(rows).Item(column), Decimal).ToString("C2", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_LEFT, 2, Element.ALIGN_MIDDLE)
                                    End If
                                Else
                                    PdfPCell = Phrasepdf((CType(Table.Rows(rows).Item(column), Decimal) / 100).ToString("P", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, True, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                                End If
                            Case Is = "SYSTEM.DBNULL"
                                PdfPCell = Phrasepdf("", 7, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                            Case Else
                                PdfPCell = Phrasepdf(Table.Rows(rows).Item(column).ToString, tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                        End Select
                    End If
                    If IsNothing(partidaconcatenada) Then
                        partidaconcatenada = partidacuentaactual
                    End If
                    If (Not rows = 0) And (partidacuentaactual <> partidaconcatenada) And (cantidad_subtotales.Item(listadodepartidas.IndexOf(partidaconcatenada)) > 1) Then
                        PdfPCellsubtotales = Phrasepdf("Subtotal Partida (" & partidaconcatenada & ")", tamaniodefuente, False, 0.5, totalcolumnas - 2, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                        PdfTable.AddCell(PdfPCellsubtotales)
                        PdfPCellsubtotales = Phrasepdf(CType(subtotales.Item(listadodepartidas.IndexOf(partidaconcatenada)), Decimal).ToString("C2", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, True, 0.5, 2, 1, Element.ALIGN_RIGHT, 2, Element.ALIGN_MIDDLE)
                        PdfTable.AddCell(PdfPCellsubtotales)
                        partidaconcatenada = Nothing
                        PdfPCellsubtotales = Nothing
                    Else
                        partidaconcatenada = partidacuentaactual
                    End If
                    PdfTable.AddCell(PdfPCell)
                Next
            Next
            'Agregar la tabla al documento
            Return PdfTable
        End If
    End Function

    Public Function PDFDatatable_op_arancelamiento(ByVal ordenpago As Ordendepago, ByVal widths() As Single, ByVal espacioantes As Single, ByVal Tamaniototal As Single, ByVal Encabezado As Boolean, ByVal Colorencabezado As iTextSharp.text.BaseColor, ByVal tamaniodefuente As Single, Optional ByVal bold As Boolean = False) As iTextSharp.text.pdf.PdfPTable
        Dim table As New DataTable
        table = ordenpago.DatosOrdenPago
        If table IsNot Nothing Then
            Dim totalcolumnas As Integer = table.Columns.Count
            ' Dim Columnasvisibles(totalcolumnas) As Integer
            Dim control As Integer = 0
            Dim PARRAFOCOMPLETO As New iTextSharp.text.Paragraph()
            Dim font12BoldRed As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.UNDERLINE Or iTextSharp.text.Font.BOLDITALIC, BaseColor.RED)
            Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font10Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font12Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim font10Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim font07Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim font07bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim titleFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim Fuentenormal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, tamaniodefuente, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim fuentebold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, tamaniodefuente, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim PdfTable As PdfPTable = New PdfPTable(totalcolumnas)
            'fix the absolute width of the table
            PdfTable.TotalWidth = Tamaniototal
            PdfTable.SetWidths(widths)
            PdfTable.LockedWidth = True
            'relative col widths in proportions
            ' PdfTable.SetWidths(widths)
            PdfTable.HorizontalAlignment = 1 ' 0 --> Left, 1 --> Center, 2 --> Right
            PdfTable.SpacingBefore = espacioantes
            'Declaración de celdas.
            Dim PdfPCell As PdfPCell = Nothing
            If Encabezado = True Then
                For X = 0 To totalcolumnas - 1
                    'Asignación de valores a cada celda como frases.
                    If bold Then
                        PdfPCell = New PdfPCell(New Phrase(New Chunk(table.Columns(X).Caption, fuentebold)))
                    Else
                        PdfPCell = New PdfPCell(New Phrase(New Chunk(table.Columns(X).Caption, Fuentenormal)))
                    End If
                    'Alignment of phrase in the pdfcell
                    PdfPCell.HorizontalAlignment = 1
                    PdfPCell.BackgroundColor = Colorencabezado
                    'Add pdfcell in pdftable
                    PdfTable.AddCell(PdfPCell)
                Next
                PdfTable.HeaderRows = 1
            End If
            If ordenpago.novalido Then
                Dim PdfPCell2 As PdfPCell = Nothing
                PdfPCell2 = Phrasepdf("SIN MOVIMIENTOS", tamaniodefuente + 4, True, 0.5, PdfTable.NumberOfColumns, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                PdfTable.AddCell(PdfPCell2)
            Else
                For rows As Integer = 0 To table.Rows.Count - 1
                    For column As Integer = 0 To totalcolumnas - 1
                        If IsNothing(table.Rows(rows).Item(column)) Then
                            'PARRAFOCOMPLETO.Add((New Phrase("", font07Normal)))
                            PdfPCell = Phrasepdf(" ", 7, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                        Else
                            Select Case table.Rows(rows).Item(column).GetType.ToString.ToUpper
                                Case Is = "SYSTEM.DATETIME"
                                    'PARRAFOCOMPLETO.Add((New Phrase(CType(Table.Rows(rows).Item(column), Date).ToShortDateString, Fuentenormal)))
                                    PdfPCell = Phrasepdf(CType(table.Rows(rows).Item(column), Date).ToShortDateString, tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                                Case Is = "SYSTEM.DECIMAL"
                                    If Not table.Columns(column).ColumnName.ToUpper = "ALICUOTA" Then
                                        'PARRAFOCOMPLETO.Add((New Phrase(CType(Table.Rows(rows).Item(column), Decimal).ToString("C2", Globalization.CultureInfo.GetCultureInfo("es-AR")), Fuentenormal)))
                                        PdfPCell = Phrasepdf(CType(table.Rows(rows).Item(column), Decimal).ToString("C2", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_RIGHT, 2, Element.ALIGN_MIDDLE)
                                    Else
                                        'PARRAFOCOMPLETO.Add((New Phrase((CType(Table.Rows(rows).Item(column), Decimal) / 100).ToString("P", Globalization.CultureInfo.GetCultureInfo("es-AR")), Fuentenormal)))
                                        PdfPCell = Phrasepdf((CType(table.Rows(rows).Item(column), Decimal) / 100).ToString("P", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, True, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                                    End If
                              '  PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT
                                Case Is = "SYSTEM.DBNULL"
                                    'PARRAFOCOMPLETO.Add((New Phrase("", Fuentenormal)))
                                    PdfPCell = Phrasepdf("", 7, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                                Case Else
                                    'PARRAFOCOMPLETO.Add((New Phrase(Table.Rows(rows).Item(column).ToString, Fuentenormal)))
                                    PdfPCell = Phrasepdf(table.Rows(rows).Item(column).ToString, tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                            End Select
                            ' PdfPCell = New PdfPCell(New Phrase(Reporteaimprimir.Rows(rows).Cells.Item(column).Value.ToString(), font09Normal))
                        End If
                        'PARRAFOCOMPLETO.Alignment = 1
                        'PdfPCell = ((Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0.5)))
                        'PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE
                        ' PdfPCell.UseAscender = True
                        'If Alturaminima > 0 Then
                        '    PdfPCell.MinimumHeight = Alturaminima
                        'Else
                        'End If
                        PdfTable.AddCell(PdfPCell)
                    Next
                Next
            End If
            'Agregar los datos del DATATABLE a la tabla ITEXTSHARP_PDF
            'If Table.Rows.Count = 1 Then
            '    If Table.Rows(0).Item(Table.Columns.Count - 1) = 0 Then
            '        PdfPCell = Phrasepdf("SIN MOVIMIENTOS", 12, False, 0.5, totalcolumnas - 3, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
            '        PdfTable.AddCell(PdfPCell)
            '    End If
            'Else
            'End If
            'Agregar la tabla al documento
            Return PdfTable
        End If
    End Function

    Public Function PDFDatatable_RETENCIONES(ByVal Table As DataTable, ByVal widths() As Single, ByVal espacioantes As Single, ByVal Tamaniototal As Single, ByVal Encabezado As Boolean, ByVal Colorencabezado As iTextSharp.text.BaseColor, ByVal tamaniodefuente As Single, Optional ByVal bold As Boolean = False) As iTextSharp.text.pdf.PdfPTable
        If Table IsNot Nothing Then
            Dim totalcolumnas As Integer = Table.Columns.Count
            ' Dim Columnasvisibles(totalcolumnas) As Integer
            Dim control As Integer = 0
            Dim PARRAFOCOMPLETO As New iTextSharp.text.Paragraph()
            Dim font12BoldRed As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.UNDERLINE Or iTextSharp.text.Font.BOLDITALIC, BaseColor.RED)
            Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font10Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font12Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim font10Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim font07Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim font07bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim titleFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim Fuentenormal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, tamaniodefuente, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim fuentebold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, tamaniodefuente, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim PdfTable As PdfPTable = New PdfPTable(totalcolumnas)
            'fix the absolute width of the table
            PdfTable.TotalWidth = Tamaniototal
            PdfTable.SetWidths(widths)
            PdfTable.LockedWidth = True
            'relative col widths in proportions
            ' PdfTable.SetWidths(widths)
            PdfTable.HorizontalAlignment = 1 ' 0 --> Left, 1 --> Center, 2 --> Right
            PdfTable.SpacingBefore = espacioantes
            Dim textoencabezado As String = ""
            'Declaración de celdas.
            Dim PdfPCell As PdfPCell = Nothing
            If Encabezado = True Then
                For X = 0 To totalcolumnas - 3
                    'Asignación de valores a cada celda como frases.
                    Select Case Table.Columns(X).Caption.ToUpper
                        Case Is = "CONCEPTO"
                            textoencabezado = "IMPUESTO"
                        Case Is = "DETALLE"
                            textoencabezado = "DETALLE"
                        Case Is = "MONTO_RETENIDO"
                            textoencabezado = "RETENCIÓN $"
                        Case Is = "MNI"
                            textoencabezado = "MNI"
                        Case Is = "ALICUOTA"
                            textoencabezado = "ALICUOTA"
                        Case Else
                            textoencabezado = Table.Columns(X).Caption
                    End Select
                    If bold Then
                        PdfPCell = New PdfPCell(New Phrase(New Chunk(textoencabezado, fuentebold)))
                    Else
                        PdfPCell = New PdfPCell(New Phrase(New Chunk(textoencabezado, Fuentenormal)))
                    End If
                    'Alignment of phrase in the pdfcell
                    PdfPCell.HorizontalAlignment = 1
                    PdfPCell.BackgroundColor = Colorencabezado
                    'Add pdfcell in pdftable
                    PdfTable.AddCell(PdfPCell)
                Next
                PdfPCell = New PdfPCell(New Phrase(New Chunk("DESC.", fuentebold)))
                PdfPCell.Colspan = 2
                'Alignment of phrase in the pdfcell
                PdfPCell.HorizontalAlignment = 1
                PdfPCell.BackgroundColor = Colorencabezado
                'Add pdfcell in pdftable
                PdfTable.AddCell(PdfPCell)
                PdfTable.HeaderRows = 1
            End If
            'Agregar los datos del DATATABLE a la tabla ITEXTSHARP_PDF
            For rows As Integer = 0 To Table.Rows.Count - 1
                For column As Integer = 0 To totalcolumnas - 1
                    If IsNothing(Table.Rows(rows).Item(column)) Then
                        PdfPCell = Phrasepdf("", tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                    Else
                        Select Case Table.Rows(rows).Item(column).GetType.ToString.ToUpper
                            Case Is = "SYSTEM.DATETIME"
                                PdfPCell = Phrasepdf(CType(Table.Rows(rows).Item(column), Date).ToShortDateString, tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                            Case Is = "SYSTEM.DECIMAL"
                                If Not Table.Columns(column).ColumnName.ToUpper = "ALICUOTA" Then
                                    PdfPCell = Phrasepdf(CType(Table.Rows(rows).Item(column), Decimal).ToString("C2", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_RIGHT, 2, Element.ALIGN_MIDDLE)
                                Else
                                    If Table.Rows(rows).Item(column) > 49 Then
                                        PdfPCell = Phrasepdf(
                                            (CType(Table.Rows(rows).Item(column), Decimal) / 100).ToString("P", Globalization.CultureInfo.GetCultureInfo("es-AR")) & vbCrLf & " del IVA", tamaniodefuente, True, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                                    Else
                                        PdfPCell = Phrasepdf((CType(Table.Rows(rows).Item(column), Decimal) / 100).ToString("P", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, True, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                                    End If
                                End If
                            Case Is = "SYSTEM.DBNULL"
                                PdfPCell = Phrasepdf("", tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                            Case Else
                                If Table.Columns(column).Caption.ToUpper = "DETALLE" Then
                                    Select Case Table.Rows(rows).Item(0).ToString.ToUpper
                                        Case Is = "GANANCIAS"
                                        Case Is = "SUSS"
                                        Case Is = "IVA"
                                            Table.Rows(rows).Item(column) += vbCrLf & "Agte de Retención por RES.GRAL. 4610/2019 AFIP"
                                        Case Is = "DGR"
                                    End Select
                                End If
                                PdfPCell = Phrasepdf(Table.Rows(rows).Item(column).ToString, tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                        End Select
                    End If
                    PdfTable.AddCell(PdfPCell)
                Next
                '  PdfPCell = New PdfPCell
                ''AGREGA LAS CELDAS CORRESPONDIENTES A LA CODIFICACIÓN DE LA RETENCIÓN
                'Select Case Table.Rows(rows).Item(0).ToString.ToUpper
                '    Case Is = "GANANCIAS"
                '        PdfPCell = Phrasepdf("COD. IMP.:" & Table.Rows(rows).Item("COD_IMPUESTO").ToString, tamaniodefuente - 1, False, 0.5, 2, 1, Element.ALIGN_LEFT, 2, Element.ALIGN_MIDDLE)
                '    Case Is = "SUSS"
                '        PdfPCell = Phrasepdf("COD. IMP.:" & Table.Rows(rows).Item("COD_IMPUESTO").ToString & vbCrLf & "COD. REGIMEN:" & Table.Rows(rows).Item("COD_REGIMEN").ToString, tamaniodefuente - 1, False, 0.5, 2, 1, Element.ALIGN_LEFT, 2, Element.ALIGN_MIDDLE)
                '    Case Is = "IVA"
                '        PdfPCell = Phrasepdf("COD. IMP.:" & Table.Rows(rows).Item("COD_IMPUESTO").ToString & vbCrLf & " Agte de Retención por RES.GRAL. 4610/2019 AFIP", tamaniodefuente - 1, False, 0.5, 2, 1, Element.ALIGN_LEFT, 2, Element.ALIGN_MIDDLE)
                '    Case Is = "DGR"
                '        PdfPCell = Phrasepdf("-", tamaniodefuente - 1, False, 0.5, 2, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                'End Select
                'PdfTable.AddCell(PdfPCell)
            Next
            'Agregar la tabla al documento
            Return PdfTable
        End If
    End Function

    Public Function PDFDatatable_certificado(ByVal Table As DataTable, ByVal widths() As Single, ByVal espacioantes As Single, ByVal Tamaniototal As Single, ByVal Encabezado As Boolean, ByVal Colorencabezado As iTextSharp.text.BaseColor, ByVal tamaniodefuente As Single, Optional ByVal bold As Boolean = False) As iTextSharp.text.pdf.PdfPTable
        If Table IsNot Nothing Then
            Dim totalcolumnas As Integer = Table.Columns.Count
            ' Dim Columnasvisibles(totalcolumnas) As Integer
            Dim control As Integer = 0
            Dim PARRAFOCOMPLETO As New iTextSharp.text.Paragraph()
            Dim font12BoldRed As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.UNDERLINE Or iTextSharp.text.Font.BOLDITALIC, BaseColor.RED)
            Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font10Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font12Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim font10Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim font07Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim font07bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim titleFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim Fuentenormal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, tamaniodefuente, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim fuentebold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, tamaniodefuente, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim PdfTable As PdfPTable = New PdfPTable(totalcolumnas)
            'fix the absolute width of the table
            PdfTable.TotalWidth = Tamaniototal
            PdfTable.SetWidths(widths)
            PdfTable.LockedWidth = True
            'relative col widths in proportions
            ' PdfTable.SetWidths(widths)
            PdfTable.HorizontalAlignment = 1 ' 0 --> Left, 1 --> Center, 2 --> Right
            PdfTable.SpacingBefore = espacioantes
            'Declaración de celdas.
            Dim PdfPCell As PdfPCell = Nothing
            If Encabezado = True Then
                For X = 0 To totalcolumnas - 1
                    'Asignación de valores a cada celda como frases.
                    If bold Then
                        PdfPCell = New PdfPCell(New Phrase(New Chunk(Table.Columns(X).Caption, fuentebold)))
                    Else
                        PdfPCell = New PdfPCell(New Phrase(New Chunk(Table.Columns(X).Caption, Fuentenormal)))
                    End If
                    'Alignment of phrase in the pdfcell
                    PdfPCell.HorizontalAlignment = 1
                    PdfPCell.BackgroundColor = Colorencabezado
                    'Add pdfcell in pdftable
                    PdfTable.AddCell(PdfPCell)
                Next
                PdfTable.HeaderRows = 1
            End If
            'Agregar los datos del DATATABLE a la tabla ITEXTSHARP_PDF
            For rows As Integer = 0 To Table.Rows.Count - 1
                For column As Integer = 0 To totalcolumnas - 1
                    If IsNothing(Table.Rows(rows).Item(column)) Then
                        'PARRAFOCOMPLETO.Add((New Phrase("", font07Normal)))
                        PdfPCell = Phrasepdf("", 7, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                    Else
                        Select Case column
                            Case = 0
                                PdfPCell = Phrasepdf(Table.Rows(rows).Item(column).ToString, tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                            Case = 1
                                PdfPCell = Phrasepdf(Table.Rows(rows).Item(column).ToString, tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                            Case Is > 6
                                PdfPCell = Phrasepdf(Table.Rows(rows).Item(column).ToString, tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                            Case Else
                                PdfPCell = Phrasepdf(CType(Table.Rows(rows).Item(column), Decimal).ToString("C2", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_RIGHT, 2, Element.ALIGN_MIDDLE)
                        End Select
                    End If
                    PdfTable.AddCell(PdfPCell)
                Next
            Next
            Dim SumaNeto As Decimal = 0
            Dim SumaGanancias As Decimal = 0
            Dim SumaSUSS As Decimal = 0
            Dim SumaIVA As Decimal = 0
            Dim SumaDGR As Decimal = 0
            Dim SumaTotal As Decimal = 0
            For x = 0 To Table.Rows.Count - 1
                SumaNeto += Table.Rows(x).Item("Neto")
                SumaGanancias += Table.Rows(x).Item("Ganancias")
                SumaSUSS += Table.Rows(x).Item("SUSS")
                SumaIVA += Table.Rows(x).Item("IVA")
                SumaDGR += Table.Rows(x).Item("DGR")
            Next
            SumaTotal = SumaNeto + SumaGanancias + SumaSUSS + SumaIVA + SumaDGR
            PdfPCell = Phrasepdf("Cant.Pagos:" & Table.Rows.Count, tamaniodefuente, False, 0.5, 2, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
            PdfTable.AddCell(PdfPCell)
            PdfPCell = Phrasepdf(CType(SumaNeto, Decimal).ToString("C2", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente + 1, False, 0.8, 1, 1, Element.ALIGN_RIGHT, 2, Element.ALIGN_MIDDLE)
            PdfTable.AddCell(PdfPCell)
            PdfPCell = Phrasepdf(CType(SumaGanancias, Decimal).ToString("C2", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente + 1, True, 0.8, 1, 1, Element.ALIGN_RIGHT, 2, Element.ALIGN_MIDDLE)
            PdfTable.AddCell(PdfPCell)
            PdfPCell = Phrasepdf(CType(SumaSUSS, Decimal).ToString("C2", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente + 1, True, 0.8, 1, 1, Element.ALIGN_RIGHT, 2, Element.ALIGN_MIDDLE)
            PdfTable.AddCell(PdfPCell)
            PdfPCell = Phrasepdf(CType(SumaIVA, Decimal).ToString("C2", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente + 1, True, 0.8, 1, 1, Element.ALIGN_RIGHT, 2, Element.ALIGN_MIDDLE)
            PdfTable.AddCell(PdfPCell)
            PdfPCell = Phrasepdf(CType(SumaDGR, Decimal).ToString("C2", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente + 1, True, 0.8, 1, 1, Element.ALIGN_RIGHT, 2, Element.ALIGN_MIDDLE)
            PdfTable.AddCell(PdfPCell)
            'Agregar la tabla al documento
            'Agregar la tabla al documento
            Return PdfTable
        End If
    End Function

    Public Function PDFDatatable_OP(ByVal Table As DataTable, ByVal widths() As Single, ByVal espacioantes As Single, ByVal Tamaniototal As Single, ByVal Encabezado As Boolean, ByVal Colorencabezado As iTextSharp.text.BaseColor, ByVal tamaniodefuente As Single, Optional ByVal bold As Boolean = False) As iTextSharp.text.pdf.PdfPTable
        If Table IsNot Nothing Then
            Dim totalcolumnas As Integer = Table.Columns.Count
            ' Dim Columnasvisibles(totalcolumnas) As Integer
            Dim control As Integer = 0
            Dim PARRAFOCOMPLETO As New iTextSharp.text.Paragraph()
            Dim PdfTable As PdfPTable = New PdfPTable(totalcolumnas - 2)
            'fix the absolute width of the table
            PdfTable.TotalWidth = Tamaniototal
            widths = New Single(5) {}
            widths(0) = Convert.ToSingle(Tamaniototal * 0.04) 'Reng.
            widths(1) = Convert.ToSingle(Tamaniototal * 0.075) 'Cant
            widths(2) = Convert.ToSingle(Tamaniototal * 0.075) 'Un.
            widths(3) = Convert.ToSingle(Tamaniototal * 0.55) ' ARTICULOS
            widths(4) = Convert.ToSingle(Tamaniototal * 0.13) ' PREC. UNITARIO
            widths(5) = Convert.ToSingle(Tamaniototal * 0.13) 'PRECIO TOTAL
            PdfTable.SetWidths(widths)
            PdfTable.LockedWidth = True
            'relative col widths in proportions
            ' PdfTable.SetWidths(widths)
            PdfTable.HorizontalAlignment = 1 ' 0 --> Left, 1 --> Center, 2 --> Right
            PdfTable.SpacingBefore = espacioantes
            'Declaración de celdas.
            Dim PdfPCell As PdfPCell = Nothing
            If Encabezado = True Then
                For z = 0 To totalcolumnas - 3
                    'Asignación de valores a cada celda como frases.
                    If bold Then
                        PdfPCell = New PdfPCell(New Phrase(New Chunk(Table.Columns(z).Caption, PDF_fuente_variable(tamaniodefuente, True))))
                    Else
                        PdfPCell = New PdfPCell(New Phrase(New Chunk(Table.Columns(z).Caption, PDF_fuente_variable(tamaniodefuente, False))))
                    End If
                    'Alignment of phrase in the pdfcell
                    PdfPCell.HorizontalAlignment = 1
                    PdfPCell.BackgroundColor = Colorencabezado
                    'Add pdfcell in pdftable
                    PdfTable.AddCell(PdfPCell)
                Next
                PdfTable.HeaderRows = 2
            Else
            End If
            PARRAFOCOMPLETO.Clear()
            With PARRAFOCOMPLETO
                .Add(PDFFIRMAS(Tamaniototal, "Suministros", "Director"))
            End With
            PdfTable.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0.5, 6, 1,, 6)))
            PdfTable.FooterRows = 1
            'Agregar los datos del DATATABLE a la tabla ITEXTSHARP_PDF
            For rows As Integer = 0 To Table.Rows.Count - 1
                'VER LA FORMA DE AGREGAR UN ENCABEZADO, POR EL MOMENTO LA MEJOR OPCIÓN PARECE SER TOMAR LA ULTIMA COLUMNA DEL ELEMENTO DE CARGA Y TRANSFORMARLA EN UN PSEUDO ENCABEZADO
                'POR LO CUAL EL RECORRIDO PASARÍA A SER SIMPLEMENTE DESDE 0 HASTA COLUMNAS -2
                'EVALUAR CONTENIDO DE LA ULTIMA COLUMNA
                If Not Table.Rows(rows).Item(totalcolumnas - 1).ToString = "" And Not IsNothing(Table.Rows(rows).Item(totalcolumnas - 1)) Then
                    PARRAFOCOMPLETO.Clear()
                    PdfPCell = New PdfPCell
                    PARRAFOCOMPLETO.Add((New Phrase(Table.Rows(rows).Item(totalcolumnas - 1), PDF_fuente_variable(tamaniodefuente, True))))
                    PARRAFOCOMPLETO.Alignment = Element.ALIGN_CENTER
                    PdfPCell = ((Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0.5)))
                    PdfPCell.Colspan = PdfTable.NumberOfColumns
                    PdfPCell.Padding = 2
                    PdfTable.AddCell(PdfPCell)
                Else
                End If
                PdfPCell = New PdfPCell
                For column As Integer = 0 To totalcolumnas - 2
                    PARRAFOCOMPLETO.Clear()
                    If IsNothing(Table.Rows(rows).Item(column)) Then
                        PARRAFOCOMPLETO.Add((New Phrase("", PDF_fuente_variable(tamaniodefuente - 3, False))))
                    Else
                        Select Case column.ToString
                            Case Is = "0"
                                PARRAFOCOMPLETO.Add((New Phrase(CType(Table.Rows(rows).Item(column), Decimal).ToString("N0"), PDF_fuente_variable(tamaniodefuente, False))))
                                PARRAFOCOMPLETO.Alignment = Element.ALIGN_CENTER
                            Case Is = "1"
                                If Math.Truncate(Table.Rows(rows).Item(column)) - Table.Rows(rows).Item(column) = 0 Then
                                    PARRAFOCOMPLETO.Add((New Phrase(CType(Table.Rows(rows).Item(column), Decimal).ToString("N0", Globalization.CultureInfo.GetCultureInfo("es-AR")), PDF_fuente_variable(tamaniodefuente, False))))
                                Else
                                    PARRAFOCOMPLETO.Add((New Phrase(CType(Table.Rows(rows).Item(column), Decimal).ToString("N4", Globalization.CultureInfo.GetCultureInfo("es-AR")), PDF_fuente_variable(tamaniodefuente, False))))
                                End If
                                PARRAFOCOMPLETO.Alignment = 1
                            Case Is = "2"
                                PARRAFOCOMPLETO.Add((New Phrase(Table.Rows(rows).Item(column).ToString, PDF_fuente_variable(tamaniodefuente, False))))
                                PARRAFOCOMPLETO.Alignment = 1
                            Case Is = "3"
                                PARRAFOCOMPLETO.Add((New Phrase(Table.Rows(rows).Item(column).ToString, PDF_fuente_variable(tamaniodefuente, False))))
                                PARRAFOCOMPLETO.Alignment = Element.ALIGN_JUSTIFIED
                            Case Is = "4"
                                PARRAFOCOMPLETO.Add((New Phrase(CType(Table.Rows(rows).Item(column), Decimal).ToString("C4", Globalization.CultureInfo.GetCultureInfo("es-AR")), PDF_fuente_variable(tamaniodefuente, False))))
                                PARRAFOCOMPLETO.Alignment = Element.ALIGN_RIGHT
                            Case Is = "5"
                                PARRAFOCOMPLETO.Add((New Phrase(CType(Table.Rows(rows).Item(column), Decimal).ToString("C2", Globalization.CultureInfo.GetCultureInfo("es-AR")), PDF_fuente_variable(tamaniodefuente, False))))
                                PARRAFOCOMPLETO.Alignment = Element.ALIGN_RIGHT
                                'Case Is = "SYSTEM.DATETIME"
                                '    PARRAFOCOMPLETO.Add((New Phrase(CType(Table.Rows(rows).Item(column), Date).ToShortDateString, Fuentenormal)))
                                'Case Is = "SYSTEM.DECIMAL"
                                '    If Not Table.Columns(column).ColumnName.ToUpper = "ALICUOTA" Then
                                '        PARRAFOCOMPLETO.Add((New Phrase(CType(Table.Rows(rows).Item(column), Decimal).ToString("C2"), Fuentenormal)))
                                '    Else
                                '        PARRAFOCOMPLETO.Add((New Phrase((CType(Table.Rows(rows).Item(column), Decimal) / 100).ToString("P"), Fuentenormal)))
                                '    End If
                                '  '  PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT
                                'Case Is = "SYSTEM.DBNULL"
                                '    PARRAFOCOMPLETO.Add((New Phrase("", Fuentenormal)))
                            Case Else
                                PARRAFOCOMPLETO.Add((New Phrase(Table.Rows(rows).Item(column).ToString, PDF_fuente_variable(tamaniodefuente, False))))
                        End Select
                        ' PdfPCell = New PdfPCell(New Phrase(Reporteaimprimir.Rows(rows).Cells.Item(column).Value.ToString(), font09Normal))
                    End If
                    Select Case Table.Rows.Count
                        Case >= 2
                            PARRAFOCOMPLETO.SetLeading(tamaniodefuente, 1)
                        Case Else
                            PARRAFOCOMPLETO.SetLeading(tamaniodefuente, 1.05)
                    End Select
                    ' PdfPCell.UseAscender = True
                    'If Alturaminima > 0 Then
                    '    PdfPCell.MinimumHeight = Alturaminima
                    'Else
                    'End If
                    'caso de que tenga observaciones
                    If column = totalcolumnas - 2 Then
                        'Add pdfcell in pdftable
                        If Not Table.Rows(rows).Item(column).ToString = "" And Not IsNothing(Table.Rows(rows).Item(column)) Then
                            PARRAFOCOMPLETO.Alignment = Element.ALIGN_JUSTIFIED
                            'PdfPCell.Colspan = totalcolumnas - 1   If column = totalcolumnas - 1 Then
                            PdfPCell = ((Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0.5, PdfTable.NumberOfColumns, 1, Element.ALIGN_LEFT, 2, Element.ALIGN_MIDDLE)))
                            PdfTable.AddCell(PdfPCell)
                        Else
                        End If
                    Else
                        PdfPCell.Colspan = 1
                        PdfPCell = ((Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0.5, 1, 1, 1, 3, Element.ALIGN_MIDDLE)))
                        ' PdfPCell.Height =
                        'PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE
                        PdfTable.AddCell(PdfPCell)
                    End If
                Next
            Next
            'Agregar la tabla al documento
            Return PdfTable
        End If
    End Function

    Public Function PDFDatatable_OP2(ByVal Table As DataTable, ByVal widths() As Single, ByVal espacioantes As Single, ByVal Tamaniototal As Single, ByVal impresor As Impresion, ByVal Encabezado As Boolean, ByVal Colorencabezado As iTextSharp.text.BaseColor, Optional ByVal bold As Boolean = False) As iTextSharp.text.pdf.PdfPTable
        If Table IsNot Nothing Then
            Dim totalcolumnas As Integer = Table.Columns.Count
            ' Dim Columnasvisibles(totalcolumnas) As Integer
            Dim control As Integer = 0
            Dim PARRAFOCOMPLETO As New iTextSharp.text.Paragraph()
            Dim PdfTable As PdfPTable = New PdfPTable(totalcolumnas - 2)
            'fix the absolute width of the table
            PdfTable.TotalWidth = Tamaniototal
            widths = New Single(5) {}
            widths(0) = Convert.ToSingle(Tamaniototal * 0.04) 'Reng.
            widths(1) = Convert.ToSingle(Tamaniototal * 0.095) 'Cant
            widths(2) = Convert.ToSingle(Tamaniototal * 0.075) 'Un.
            widths(3) = Convert.ToSingle(Tamaniototal * 0.53) ' ARTICULOS
            widths(4) = Convert.ToSingle(Tamaniototal * 0.13) ' PREC. UNITARIO
            widths(5) = Convert.ToSingle(Tamaniototal * 0.13) 'PRECIO TOTAL
            PdfTable.SetWidths(widths)
            PdfTable.LockedWidth = True
            'relative col widths in proportions
            ' PdfTable.SetWidths(widths)
            PdfTable.HorizontalAlignment = 1 ' 0 --> Left, 1 --> Center, 2 --> Right
            PdfTable.SpacingBefore = espacioantes
            'Declaración de celdas.
            Dim PdfPCell As PdfPCell = Nothing
            If Encabezado = True Then
                For z = 0 To totalcolumnas - 3
                    'Asignación de valores a cada celda como frases.
                    If bold Then
                        PdfPCell = New PdfPCell(New Phrase(New Chunk(Table.Columns(z).Caption, PDF_fuente_variable(impresor.tamaniofuente, True))))
                    Else
                        PdfPCell = New PdfPCell(New Phrase(New Chunk(Table.Columns(z).Caption, PDF_fuente_variable(impresor.tamaniofuente, False))))
                    End If
                    'Alignment of phrase in the pdfcell
                    PdfPCell.HorizontalAlignment = 1
                    PdfPCell.BackgroundColor = Colorencabezado
                    'Add pdfcell in pdftable
                    PdfTable.AddCell(PdfPCell)
                Next
                PdfTable.HeaderRows = 2
            Else
            End If
            PARRAFOCOMPLETO.Clear()
            With PARRAFOCOMPLETO
                .Add(PDFFIRMASv2(Tamaniototal, impresor.Sello_Suministros, impresor.Sello_direccion))
            End With
            PdfTable.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0.5, 6, 1,, 6)))
            PdfTable.FooterRows = 1
            'Agregar los datos del DATATABLE a la tabla ITEXTSHARP_PDF
            For rows As Integer = 0 To Table.Rows.Count - 1
                'VER LA FORMA DE AGREGAR UN ENCABEZADO, POR EL MOMENTO LA MEJOR OPCIÓN PARECE SER TOMAR LA ULTIMA COLUMNA DEL ELEMENTO DE CARGA Y TRANSFORMARLA EN UN PSEUDO ENCABEZADO
                'POR LO CUAL EL RECORRIDO PASARÍA A SER SIMPLEMENTE DESDE 0 HASTA COLUMNAS -2
                'EVALUAR CONTENIDO DE LA ULTIMA COLUMNA
                If Not Table.Rows(rows).Item(totalcolumnas - 1).ToString = "" And Not IsNothing(Table.Rows(rows).Item(totalcolumnas - 1)) Then
                    PARRAFOCOMPLETO.Clear()
                    PdfPCell = New PdfPCell
                    PARRAFOCOMPLETO.Add((New Phrase(Table.Rows(rows).Item(totalcolumnas - 1), PDF_fuente_variable(impresor.tamaniofuente, True))))
                    PARRAFOCOMPLETO.Alignment = Element.ALIGN_CENTER
                    PdfPCell = ((Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0.5)))
                    PdfPCell.Colspan = PdfTable.NumberOfColumns
                    PdfPCell.Padding = 2
                    PdfTable.AddCell(PdfPCell)
                Else
                End If
                PdfPCell = New PdfPCell
                For column As Integer = 0 To totalcolumnas - 2
                    PARRAFOCOMPLETO.Clear()
                    If IsNothing(Table.Rows(rows).Item(column)) Then
                        PARRAFOCOMPLETO.Add((New Phrase("", PDF_fuente_variable(impresor.tamaniofuente - 3, False))))
                    Else
                        Select Case column.ToString
                            Case Is = "0"
                                PARRAFOCOMPLETO.Add((New Phrase(CType(Table.Rows(rows).Item(column), Decimal).ToString("N0"), PDF_fuente_variable(impresor.tamaniofuentetablas, False))))
                                PARRAFOCOMPLETO.Alignment = Element.ALIGN_CENTER
                            Case Is = "1"
                                If Math.Truncate(Table.Rows(rows).Item(column)) - Table.Rows(rows).Item(column) = 0 Then
                                    PARRAFOCOMPLETO.Add((New Phrase(CType(Table.Rows(rows).Item(column), Decimal).ToString("N0", Globalization.CultureInfo.GetCultureInfo("es-AR")), PDF_fuente_variable(impresor.tamaniofuentetablas, False))))
                                Else
                                    PARRAFOCOMPLETO.Add((New Phrase(CType(Table.Rows(rows).Item(column), Decimal).ToString("N" & impresor.decimales, Globalization.CultureInfo.GetCultureInfo("es-AR")), PDF_fuente_variable(impresor.tamaniofuentetablas, False))))
                                End If
                                PARRAFOCOMPLETO.Alignment = 1
                            Case Is = "2"
                                PARRAFOCOMPLETO.Add((New Phrase(Table.Rows(rows).Item(column).ToString, PDF_fuente_variable(impresor.tamaniofuentetablas, False))))
                                PARRAFOCOMPLETO.Alignment = 1
                            Case Is = "3"
                                PARRAFOCOMPLETO.Add((New Phrase(Table.Rows(rows).Item(column).ToString, PDF_fuente_variable(impresor.tamaniofuentetablas, False))))
                                PARRAFOCOMPLETO.Alignment = Element.ALIGN_JUSTIFIED
                            Case Is = "4"
                                PARRAFOCOMPLETO.Add((New Phrase(CType(Table.Rows(rows).Item(column), Decimal).ToString("C" & impresor.decimales, Globalization.CultureInfo.GetCultureInfo("es-AR")), PDF_fuente_variable(impresor.tamaniofuentetablas, False))))
                                PARRAFOCOMPLETO.Alignment = Element.ALIGN_RIGHT
                            Case Is = "5"
                                PARRAFOCOMPLETO.Add((New Phrase(CType(Table.Rows(rows).Item(column), Decimal).ToString("C2", Globalization.CultureInfo.GetCultureInfo("es-AR")), PDF_fuente_variable(impresor.tamaniofuentetablas, False))))
                                PARRAFOCOMPLETO.Alignment = Element.ALIGN_RIGHT
                                'Case Is = "SYSTEM.DATETIME"
                                '    PARRAFOCOMPLETO.Add((New Phrase(CType(Table.Rows(rows).Item(column), Date).ToShortDateString, Fuentenormal)))
                                'Case Is = "SYSTEM.DECIMAL"
                                '    If Not Table.Columns(column).ColumnName.ToUpper = "ALICUOTA" Then
                                '        PARRAFOCOMPLETO.Add((New Phrase(CType(Table.Rows(rows).Item(column), Decimal).ToString("C2"), Fuentenormal)))
                                '    Else
                                '        PARRAFOCOMPLETO.Add((New Phrase((CType(Table.Rows(rows).Item(column), Decimal) / 100).ToString("P"), Fuentenormal)))
                                '    End If
                                '  '  PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT
                                'Case Is = "SYSTEM.DBNULL"
                                '    PARRAFOCOMPLETO.Add((New Phrase("", Fuentenormal)))
                            Case Else
                                PARRAFOCOMPLETO.Add((New Phrase(Table.Rows(rows).Item(column).ToString, PDF_fuente_variable(impresor.tamaniofuente, False))))
                        End Select
                        ' PdfPCell = New PdfPCell(New Phrase(Reporteaimprimir.Rows(rows).Cells.Item(column).Value.ToString(), font09Normal))
                    End If
                    Select Case Table.Rows.Count
                        Case >= 2
                            PARRAFOCOMPLETO.SetLeading(impresor.tamaniofuente, 1)
                        Case Else
                            PARRAFOCOMPLETO.SetLeading(impresor.tamaniofuente, 1.05)
                    End Select
                    ' PdfPCell.UseAscender = True
                    'If Alturaminima > 0 Then
                    '    PdfPCell.MinimumHeight = Alturaminima
                    'Else
                    'End If
                    'caso de que tenga observaciones
                    If column = totalcolumnas - 2 Then
                        'Add pdfcell in pdftable
                        If Not Table.Rows(rows).Item(column).ToString = "" And Not IsNothing(Table.Rows(rows).Item(column)) Then
                            PARRAFOCOMPLETO.Alignment = Element.ALIGN_JUSTIFIED
                            'PdfPCell.Colspan = totalcolumnas - 1   If column = totalcolumnas - 1 Then
                            PdfPCell = ((Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0.5, PdfTable.NumberOfColumns, 1, Element.ALIGN_LEFT, 2, Element.ALIGN_MIDDLE)))
                            PdfTable.AddCell(PdfPCell)
                        Else
                        End If
                    Else
                        PdfPCell.Colspan = 1
                        PdfPCell = ((Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0.5, 1, 1, 1, 3, Element.ALIGN_MIDDLE)))
                        ' PdfPCell.Height =
                        'PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE
                        PdfTable.AddCell(PdfPCell)
                    End If
                Next
            Next
            'Agregar la tabla al documento
            Return PdfTable
        End If
    End Function

    Public Function PDFDatatable_OP_HABERES(ByVal Table As DataTable,
                                            ByVal espacioantes As Single,
                                            ByVal Tamaniototal As Single,
                                            ByVal Colorencabezado As iTextSharp.text.BaseColor,
                                            ByVal tamaniodefuente As Single,
                                            Optional ByVal bold As Boolean = False) As iTextSharp.text.pdf.PdfPTable
        Dim sumatotal As Decimal = 0
        For x = 0 To Table.Rows.Count - 1
            sumatotal += Table.Rows(x).Item("importe")
        Next
        If Table IsNot Nothing Then
            Dim totalcolumnas As Integer = Table.Columns.Count
            Encabezado = True
            ' Dim Columnasvisibles(totalcolumnas) As Integer
            Dim control As Integer = 0
            Dim PARRAFOCOMPLETO As New iTextSharp.text.Paragraph()
            Dim PdfTable As PdfPTable = New PdfPTable(14)
            'fix the absolute width of the table
            PdfTable.TotalWidth = Tamaniototal
            widths = New Single(13) {}
            widths(0) = Convert.ToSingle(Tamaniototal * 0.0375) 'jur.
            widths(1) = Convert.ToSingle(Tamaniototal * 0.0375) 'UO
            widths(2) = Convert.ToSingle(Tamaniototal * 0.07) 'CARAC
            widths(3) = Convert.ToSingle(Tamaniototal * 0.0375) ' FIN
            widths(4) = Convert.ToSingle(Tamaniototal * 0.0425) ' FUN.
            widths(5) = Convert.ToSingle(Tamaniototal * 0.075) 'SECC
            widths(6) = Convert.ToSingle(Tamaniototal * 0.075) 'SECT
            widths(7) = Convert.ToSingle(Tamaniototal * 0.075) ' PDA PCIAL
            widths(8) = Convert.ToSingle(Tamaniototal * 0.075) ' PDA PPAL
            widths(9) = Convert.ToSingle(Tamaniototal * 0.075) 'PDA SUB PAR
            widths(10) = Convert.ToSingle(Tamaniototal * 0.075) 'SCD
            widths(11) = Convert.ToSingle(Tamaniototal * 0.2) 'IMPORTE
            widths(12) = Convert.ToSingle(Tamaniototal * 0.075) 'PREV DEF OP
            widths(13) = Convert.ToSingle(Tamaniototal * 0.2) 'IMPORTE
            PdfTable.SetWidths(widths)
            PdfTable.LockedWidth = True
            'relative col widths in proportions
            ' PdfTable.SetWidths(widths)
            PdfTable.HorizontalAlignment = 1 ' 0 --> Left, 1 --> Center, 2 --> Right
            PdfTable.SpacingBefore = espacioantes
            'Declaración de celdas.
            Dim PdfPCell As PdfPCell = Nothing
            PdfPCell = New PdfPCell
            PARRAFOCOMPLETO.Clear()
            PARRAFOCOMPLETO.Add(New Phrase("AFECTACIÓN", PDF_fuente_variable(tamaniodefuente - 1, True, False)))
            PARRAFOCOMPLETO.SetLeading(tamaniodefuente, 1)
            '  PdfPCell = ((Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0.5, 11, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)))
            PdfPCell.AddElement(New Phrase("AFECTACIÓN", PDF_fuente_variable(tamaniodefuente - 1, True, False)))
            PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
            PdfPCell.Colspan = 12
            PdfTable.AddCell(PdfPCell)
            PARRAFOCOMPLETO.Clear()
            PARRAFOCOMPLETO.Add(New Phrase("DESAFECTACIÓN", PDF_fuente_variable(tamaniodefuente - 1, True, False)))
            PARRAFOCOMPLETO.SetLeading(tamaniodefuente, 1)
            PdfPCell = ((Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0.5, 11, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)))
            PdfPCell.Colspan = 2
            PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
            PdfTable.AddCell(PdfPCell)
            For z = 0 To PdfTable.NumberOfColumns - 1
                'Asignación de valores a cada celda como frases.
                If z > totalcolumnas - 1 Then
                    Select Case z
                        Case 12
                            PARRAFOCOMPLETO.Clear()
                            PARRAFOCOMPLETO.SetLeading(tamaniodefuente, 0)
                            If bold Then
                                PARRAFOCOMPLETO.Add(New Phrase("Prev.", PDF_fuente_variable(tamaniodefuente - 1, True, False)))
                                PARRAFOCOMPLETO.Add(New Phrase(vbNewLine & "Def.", PDF_fuente_variable(tamaniodefuente - 1, True, False)))
                                PARRAFOCOMPLETO.Add(New Phrase(vbNewLine & "O.P.", PDF_fuente_variable(tamaniodefuente - 1, True, False)))
                            Else
                                PARRAFOCOMPLETO.Add(New Phrase("Prev.", PDF_fuente_variable(tamaniodefuente - 1, False, False)))
                                PARRAFOCOMPLETO.Add(New Phrase(vbNewLine & "Def.", PDF_fuente_variable(tamaniodefuente - 1, False, False)))
                                PARRAFOCOMPLETO.Add(New Phrase(vbNewLine & "O.P.", PDF_fuente_variable(tamaniodefuente - 1, False, False)))
                            End If
                            PARRAFOCOMPLETO.SetLeading(tamaniodefuente, 0)
                            PdfPCell = ((Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0.5)))
                            PdfPCell.Colspan = 1
                      '      PdfTable.AddCell(PdfPCell)
                        Case 12
                            PARRAFOCOMPLETO.Clear()
                            If bold Then
                                PARRAFOCOMPLETO.Add(New Phrase("IMPORTE", PDF_fuente_variable(tamaniodefuente - 1, True, False)))
                            Else
                                PARRAFOCOMPLETO.Add(New Phrase("IMPORTE", PDF_fuente_variable(tamaniodefuente - 1, False, False)))
                            End If
                            PARRAFOCOMPLETO.SetLeading(tamaniodefuente, 1)
                            PdfPCell = ((Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0.5)))
                            PdfPCell.Colspan = 1
                            '    PdfTable.AddCell(PdfPCell)
                    End Select
                Else
                    If bold Then
                        PdfPCell = New PdfPCell(New Phrase(New Chunk(Table.Columns(z).Caption, PDF_fuente_variable(tamaniodefuente - 1, True, False))))
                    Else
                        PdfPCell = New PdfPCell(New Phrase(New Chunk(Table.Columns(z).Caption, PDF_fuente_variable(tamaniodefuente - 1, False, False))))
                    End If
                End If
                'Alignment of phrase in the pdfcell
                PdfPCell.HorizontalAlignment = 1
                PdfPCell.BackgroundColor = Colorencabezado
                'Add pdfcell in pdftable
                PdfTable.AddCell(PdfPCell)
            Next
            'Agregar los datos del DATATABLE a la tabla ITEXTSHARP_PDF
            For rows As Integer = 0 To Table.Rows.Count - 1
                For column As Integer = 0 To PdfTable.NumberOfColumns - 1
                    PARRAFOCOMPLETO.Clear()
                    If column > totalcolumnas - 1 Then
                        PARRAFOCOMPLETO.Add((New Phrase(" ", PDF_fuente_variable(tamaniodefuente, False, False))))
                    Else
                        If column = totalcolumnas - 1 Then
                            If IsNothing(Table.Rows(rows).Item(column)) Then
                                PARRAFOCOMPLETO.Add((New Phrase("-", PDF_fuente_variable(tamaniodefuente, False, False))))
                            Else
                                PARRAFOCOMPLETO.Add((New Phrase(CType(Table.Rows(rows).Item(column), Decimal).ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), PDF_fuente_variable(tamaniodefuente + 1, True, False))))
                            End If
                        Else
                            If IsNothing(Table.Rows(rows).Item(column)) Then
                                PARRAFOCOMPLETO.Add((New Phrase(" ", PDF_fuente_variable(tamaniodefuente, False, False))))
                            Else
                                PARRAFOCOMPLETO.Add((New Phrase(Table.Rows(rows).Item(column).ToString, PDF_fuente_variable(tamaniodefuente, False, False))))
                            End If
                        End If
                    End If
                    PARRAFOCOMPLETO.SetLeading(tamaniodefuente, 1)
                    PARRAFOCOMPLETO.Alignment = Element.ALIGN_CENTER
                    PdfPCell = New PdfPCell()
                    PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                    PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE
                    PdfPCell.AddElement(PARRAFOCOMPLETO)
                    PdfPCell.BorderWidth = 0.5
                    PdfPCell.Colspan = 1
                    PdfPCell.PaddingTop = 1
                    PdfPCell.PaddingBottom = 3
                    PdfTable.AddCell(PdfPCell)
                Next
            Next
            'PARRAFOCOMPLETO.Clear()
            'PARRAFOCOMPLETO.Add((New Phrase("TOTAL GENERAL", PDF_fuente_variable(tamaniodefuente, False, False))))
            'PdfPCell = New PdfPCell()
            'PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
            'PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE
            'PdfPCell.AddElement(PARRAFOCOMPLETO)
            'PdfPCell.Colspan = 10
            'PdfTable.AddCell(PdfPCell)
            'PdfTable.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("TOTAL GENERAL", PDF_fuente_variable(tamaniodefuente, True))), 0.5, 11, 1, 2, 1)))
            'Celdapdf_local = New PdfPCell
            'TEXTO = New Paragraph
            'TEXTO.Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk((sumatotal).ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), PDF_fuente_variable(tamaniodefuente + 2, True))))
            'TEXTO.Alignment = Element.ALIGN_RIGHT
            'Celdapdf_local.Colspan = 1
            'Celdapdf_local.AddElement(TEXTO)
            'PdfTable.AddCell(Celdapdf_local)
            'Agregar la tabla al documento
            Return PdfTable
        End If
    End Function

    Public Function PDFDatatablerecibo(ByVal Table As DataTable, ByVal widths() As Single, ByVal espacioantes As Single, ByVal Tamaniototal As Single, ByVal Encabezado As Boolean, ByVal Colorencabezado As iTextSharp.text.BaseColor, ByVal tamaniodefuente As Single, Optional ByVal bold As Boolean = False) As iTextSharp.text.pdf.PdfPTable
        If Table IsNot Nothing Then
            Dim totalcolumnas As Integer = Table.Columns.Count
            ' Dim Columnasvisibles(totalcolumnas) As Integer
            Dim control As Integer = 0
            Dim PARRAFOCOMPLETO As New iTextSharp.text.Paragraph()
            Dim font12BoldRed As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.UNDERLINE Or iTextSharp.text.Font.BOLDITALIC, BaseColor.RED)
            Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font10Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font12Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim font10Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim font07Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim font07bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim titleFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim Fuentenormal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, tamaniodefuente, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim fuentebold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, tamaniodefuente, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim PdfTable As PdfPTable = New PdfPTable(totalcolumnas)
            'fix the absolute width of the table
            PdfTable.TotalWidth = Tamaniototal
            PdfTable.SetWidths(widths)
            PdfTable.LockedWidth = True
            'relative col widths in proportions
            ' PdfTable.SetWidths(widths)
            PdfTable.HorizontalAlignment = 1 ' 0 --> Left, 1 --> Center, 2 --> Right
            PdfTable.SpacingBefore = espacioantes
            'Declaración de celdas.
            Dim PdfPCell As PdfPCell = Nothing
            If Encabezado = True Then
                For X = 0 To totalcolumnas - 1
                    'Asignación de valores a cada celda como frases.
                    If bold Then
                        PdfPCell = New PdfPCell(New Phrase(New Chunk(Table.Columns(X).Caption, fuentebold)))
                    Else
                        PdfPCell = New PdfPCell(New Phrase(New Chunk(Table.Columns(X).Caption, Fuentenormal)))
                    End If
                    'Alignment of phrase in the pdfcell
                    PdfPCell.HorizontalAlignment = 1
                    PdfPCell.BackgroundColor = Colorencabezado
                    'Add pdfcell in pdftable
                    PdfTable.AddCell(PdfPCell)
                Next
                PdfTable.HeaderRows = 1
            End If
            'Agregar los datos del DATATABLE a la tabla ITEXTSHARP_PDF
            For rows As Integer = 0 To Table.Rows.Count - 1
                For column As Integer = 0 To totalcolumnas - 1
                    If IsNothing(Table.Rows(rows).Item(column)) Then
                        'PARRAFOCOMPLETO.Add((New Phrase("", font07Normal)))
                        PdfPCell = Phrasepdf("", tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                    Else
                        If column = 0 Then
                            PdfPCell = Phrasepdf(Table.Rows(rows).Item(column).ToString, tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                        Else
                            PdfPCell = Phrasepdf(CType(Table.Rows(rows).Item(column), Decimal).ToString("C2", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_RIGHT, 2, Element.ALIGN_MIDDLE)
                        End If
                        'Select Case Table.Rows(rows).Item(column).GetType.ToString.ToUpper
                        '    Case Is = "SYSTEM.DATETIME"
                        '        'PARRAFOCOMPLETO.Add((New Phrase(CType(Table.Rows(rows).Item(column), Date).ToShortDateString, Fuentenormal)))
                        '        PdfPCell = Phrasepdf(CType(Table.Rows(rows).Item(column), Date).ToShortDateString, tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                        '    Case Is = "SYSTEM.DECIMAL"
                        '        If Not Table.Columns(column).ColumnName.ToUpper = "ALICUOTA" Then
                        '            'PARRAFOCOMPLETO.Add((New Phrase(CType(Table.Rows(rows).Item(column), Decimal).ToString("C2", Globalization.CultureInfo.GetCultureInfo("es-AR")), Fuentenormal)))
                        '            PdfPCell = Phrasepdf(CType(Table.Rows(rows).Item(column), Decimal).ToString("C2", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_RIGHT, 2, Element.ALIGN_MIDDLE)
                        '        Else
                        '            'PARRAFOCOMPLETO.Add((New Phrase((CType(Table.Rows(rows).Item(column), Decimal) / 100).ToString("P", Globalization.CultureInfo.GetCultureInfo("es-AR")), Fuentenormal)))
                        '            PdfPCell = Phrasepdf((CType(Table.Rows(rows).Item(column), Decimal) / 100).ToString("P", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, True, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                        '        End If
                        '      '  PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT
                        '    Case Is = "SYSTEM.DBNULL"
                        '        'PARRAFOCOMPLETO.Add((New Phrase("", Fuentenormal)))
                        '        PdfPCell = Phrasepdf("", 7, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                        '    Case Else
                        '        'PARRAFOCOMPLETO.Add((New Phrase(Table.Rows(rows).Item(column).ToString, Fuentenormal)))
                        '        PdfPCell = Phrasepdf(Table.Rows(rows).Item(column).ToString, tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
                        'End Select
                        ' PdfPCell = New PdfPCell(New Phrase(Reporteaimprimir.Rows(rows).Cells.Item(column).Value.ToString(), font09Normal))
                    End If
                    'PARRAFOCOMPLETO.Alignment = 1
                    'PdfPCell = ((Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0.5)))
                    'PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE
                    ' PdfPCell.UseAscender = True
                    'If Alturaminima > 0 Then
                    '    PdfPCell.MinimumHeight = Alturaminima
                    'Else
                    'End If
                    PdfTable.AddCell(PdfPCell)
                Next
            Next
            Dim SumaNeto As Decimal = 0
            Dim SumaGanancias As Decimal = 0
            Dim SumaSUSS As Decimal = 0
            Dim SumaIVA As Decimal = 0
            Dim SumaDGR As Decimal = 0
            Dim SumaTotal As Decimal = 0
            For x = 0 To Table.Rows.Count - 1
                SumaNeto += Table.Rows(x).Item("Monto")
                SumaGanancias += Table.Rows(x).Item("Ganancias")
                SumaSUSS += Table.Rows(x).Item("SUSS")
                SumaIVA += Table.Rows(x).Item("IVA")
                SumaDGR += Table.Rows(x).Item("DGR")
            Next
            SumaTotal = SumaNeto + SumaGanancias + SumaSUSS + SumaIVA + SumaDGR
            PdfPCell = Phrasepdf("Cant.Pagos:" & Table.Rows.Count, tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE)
            PdfTable.AddCell(PdfPCell)
            PdfPCell = Phrasepdf(CType(SumaNeto, Decimal).ToString("C2", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente + 1, False, 0.8, 1, 1, Element.ALIGN_RIGHT, 2, Element.ALIGN_MIDDLE)
            PdfTable.AddCell(PdfPCell)
            PdfPCell = Phrasepdf(CType(SumaGanancias, Decimal).ToString("C2", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente + 1, True, 0.8, 1, 1, Element.ALIGN_RIGHT, 2, Element.ALIGN_MIDDLE)
            PdfTable.AddCell(PdfPCell)
            PdfPCell = Phrasepdf(CType(SumaSUSS, Decimal).ToString("C2", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente + 1, True, 0.8, 1, 1, Element.ALIGN_RIGHT, 2, Element.ALIGN_MIDDLE)
            PdfTable.AddCell(PdfPCell)
            PdfPCell = Phrasepdf(CType(SumaIVA, Decimal).ToString("C2", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente + 1, True, 0.8, 1, 1, Element.ALIGN_RIGHT, 2, Element.ALIGN_MIDDLE)
            PdfTable.AddCell(PdfPCell)
            PdfPCell = Phrasepdf(CType(SumaDGR, Decimal).ToString("C2", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente + 1, True, 0.8, 1, 1, Element.ALIGN_RIGHT, 2, Element.ALIGN_MIDDLE)
            PdfTable.AddCell(PdfPCell)
            'Agregar la tabla al documento
            Return PdfTable
        End If
    End Function

    Public Function Sello(ByVal departamento As String, ByRef Fecha As String, ByVal fuente_tamanio As Single) As Paragraph
        Dim Sello_datatable As New DataTable
        Dim PARRAFOCOMPLETO As New iTextSharp.text.Paragraph()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@departamento", departamento)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@fecha", Fecha)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select Nombre_sello,Cargo,
case when isnull(causa) then 'Presente' else Causa END as 'Estado',
case when isnull(causa) then orden else Orden+99 END as Orden
 from
(Select * from contaduria_usuarios.sellos where Departamento=@departamento)A
left JOIN
(select * from personal.presentismo2 where @fecha between SD and ED )B
ON A.Documento=B.documento
order by orden asc",
                             Sello_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
        If Not IsDBNull(departamento) Then
            If departamento = "" And Sello_datatable.Rows.Count = 0 Then
                PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk(" " & vbNewLine, PDF_fuente_variable(fuente_tamanio, False))))
                PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(fuente_tamanio, False))))
            Else
                Select Case departamento.ToUpper
                    Case Is = "RESPONSABLE TRANSF. FONDOS"
                        PARRAFOCOMPLETO.Add(New Phrase(New Chunk("____________________________" & vbNewLine, PDF_fuente_variable(fuente_tamanio, False))))
                        PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk("Responsable Transf. Fondos", PDF_fuente_variable(fuente_tamanio, True))))
                    Case Is = "CONTADOR GENERAL"
                        PARRAFOCOMPLETO.Add(New Phrase(New Chunk("____________________________" & vbNewLine, PDF_fuente_variable(fuente_tamanio, False))))
                        PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk("CONTADOR GENERAL", PDF_fuente_variable(fuente_tamanio, True))))
                    Case Else
                        DialogDialogo_Datagridview.Carga_General(Sello_datatable, "Seleccione la persona que ocupa el cargo de:" & departamento.ToUpper, "Seleccionar persona", "Cancelar")
                        If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) And DialogDialogo_Datagridview.Datosdialogo_datagridview.SelectedRows.Count = 1 Then
                            PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk(Chr(160) & Chr(160) & Chr(160) & Chr(160) & Chr(160) & Chr(160) &
                                                                                             DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item("Nombre_sello").Value.ToString &
                                                                                             Chr(160) & Chr(160) & Chr(160) & Chr(160) & Chr(160) & Chr(160) &
                                                                                             vbNewLine, PDF_fuente_variable(fuente_tamanio, True, True))))
                            Select Case departamento.ToUpper
                                Case Is = "DELEGADO FISCAL"
                                    If Not DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item("Nombre_sello").Value.ToString = "" Then
                                        PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk(DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item("Cargo").Value.ToString & vbNewLine, PDF_fuente_variable(fuente_tamanio - 1, False))))
                                        PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk("CONTADURÍA GENERAL", PDF_fuente_variable(fuente_tamanio - 2, False))))
                                    Else
                                        PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk("____________________________" & vbNewLine, PDF_fuente_variable(fuente_tamanio - 1, False))))
                                        PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk(departamento, PDF_fuente_variable(fuente_tamanio - 2, False))))
                                    End If
                                Case Else
                                    PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk(DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item("Cargo").Value.ToString & vbNewLine, PDF_fuente_variable(fuente_tamanio - 1, False))))
                                    PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk(Autorizaciones.Nombreabreviadodelservicio, PDF_fuente_variable(fuente_tamanio - 3, False))))
                            End Select
                        Else
                            PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk(" " & vbNewLine, PDF_fuente_variable(fuente_tamanio - 1, False))))
                            PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(fuente_tamanio - 2, False))))
                        End If
                End Select
                ''  Dialogo_listbox.Cargalistboxgeneral(listadecuentasbancarias, "Seleccione la cuenta a ser asignada", "Asignar Cuenta Especial", "Borrar asignación")
                'If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
                '    Rubro = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString
                '    PARRAFOCOMPLETO.Add(New Phrase(New Chunk("____________________________" & vbNewLine, font10Normal)))
                '    PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk(DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item("Nombre_sello").Value.ToString & vbNewLine, font08Bold)))
                '    PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk(DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item("Cargo").Value.ToString & vbNewLine, PDF_fuente_variable(6, False))))
                '    If departamento.ToUpper = "DELEGADO FISCAL" Then
                '    Else
                '        PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk(Autorizaciones.Nombrecompletodelservicio, PDF_fuente_variable(6, False))))
                '    End If
                'Else
                'End If
            End If
        End If
        PARRAFOCOMPLETO.SetLeading(10, 0)
        '        PARRAFOCOMPLETO
        PARRAFOCOMPLETO.Alignment = Element.ALIGN_CENTER
        Return PARRAFOCOMPLETO
    End Function

    Public Function Sello_impresion(ByVal SELLOS As Sello) As Paragraph
        Dim PARRAFOCOMPLETO As New iTextSharp.text.Paragraph()
        If Not IsNothing(SELLOS) Then
            If SELLOS.SelloDepartamento = "" Then
                PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk(" " & vbNewLine, PDF_fuente_variable(SELLOS.Sellofuentetamanio, False))))
                PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(SELLOS.Sellofuentetamanio, False))))
            Else
                PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk(Chr(160) & Chr(160) & Chr(160) & Chr(160) & Chr(160) & Chr(160) &
                                                                         SELLOS.Nombre_sello &
                                                                         Chr(160) & Chr(160) & Chr(160) & Chr(160) & Chr(160) & Chr(160) &
                                                                         vbNewLine, PDF_fuente_variable(SELLOS.Sellofuentetamanio, True, True))))
                Select Case SELLOS.SelloDepartamento.ToUpper
                    Case Is = "DELEGADO FISCAL"
                        If Not SELLOS.Nombre_sello = "" Then
                            PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk(SELLOS.Cargo & vbNewLine, PDF_fuente_variable(SELLOS.Sellofuentetamanio - 1, False))))
                            PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk("CONTADURÍA GENERAL", PDF_fuente_variable(SELLOS.Sellofuentetamanio - 2, False))))
                        Else
                            PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk("____________________________" & vbNewLine, PDF_fuente_variable(SELLOS.Sellofuentetamanio - 1, False))))
                            PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk(SELLOS.SelloDepartamento, PDF_fuente_variable(SELLOS.Sellofuentetamanio - 2, False))))
                        End If
                    Case Else
                        PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk(SELLOS.Cargo & vbNewLine, PDF_fuente_variable(SELLOS.Sellofuentetamanio - 1, False))))
                        PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk(Autorizaciones.Nombreabreviadodelservicio, PDF_fuente_variable(SELLOS.Sellofuentetamanio - 3, False))))
                End Select
            End If
        Else
            PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk(" " & vbNewLine, PDF_fuente_variable(SELLOS.Sellofuentetamanio, False))))
            PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(SELLOS.Sellofuentetamanio, False))))
        End If
        PARRAFOCOMPLETO.SetLeading(10, 0)
        '        PARRAFOCOMPLETO
        PARRAFOCOMPLETO.Alignment = Element.ALIGN_CENTER
        Return PARRAFOCOMPLETO
    End Function

    Public Function PDFFIRMAS(
                             ByVal Tamaniototal As Single,
                             ByVal Cargo_izq As String,
                             ByVal Cargo_DER As String,
                             Optional ByVal fuente_tamanio As Single = 10,
                              Optional ByVal MinimumHeight As Single = 60
                             ) As iTextSharp.text.pdf.PdfPTable
        Dim font10BoldSUAVE As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.BOLD, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#f1f2ef")))
        Dim font10Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font10Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font12BoldSUAVE As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#f1f2ef")))
        Dim font12Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim PARRAFOCOMPLETO As New iTextSharp.text.Paragraph()
        Dim tamaniocolumna As Single() = New Single(1) {}
        tamaniocolumna(0) = Convert.ToSingle(Tamaniototal * 0.5)
        tamaniocolumna(1) = Convert.ToSingle(Tamaniototal * 0.5)
        Dim FirmasServicioadm As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(2)
        FirmasServicioadm.TotalWidth = Tamaniototal
        FirmasServicioadm.SetWidths(tamaniocolumna)
        FirmasServicioadm.LockedWidth = True
        'Declaración de celdas.
        Dim PdfPCell As PdfPCell = Nothing
        If Cargo_izq = "" Then
            PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk(" " & vbNewLine, PDF_fuente_variable(fuente_tamanio, True))))
            PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk(" ", font10BoldSUAVE)))
        Else
            PARRAFOCOMPLETO.Add(Sello(Cargo_izq, Date.Now.ToString("yyyy-MM-dd"), fuente_tamanio))
        End If
        PARRAFOCOMPLETO.Alignment = 1
        PdfPCell = (New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
        PdfPCell.VerticalAlignment = 6
        PdfPCell.Border = 0
        PdfPCell.MinimumHeight = MinimumHeight
        FirmasServicioadm.AddCell(PdfPCell)
        PARRAFOCOMPLETO.Clear()
        If Cargo_DER = "" Then
            PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk(" " & vbNewLine, PDF_fuente_variable(fuente_tamanio, False))))
            PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk(" ", font10BoldSUAVE)))
        Else
            PARRAFOCOMPLETO.Add(Sello(Cargo_DER, Date.Now.ToString("yyyy-MM-dd"), fuente_tamanio))
        End If
        PARRAFOCOMPLETO.Alignment = 1
        PdfPCell = (New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
        PdfPCell.VerticalAlignment = 6
        PdfPCell.Border = 0
        PdfPCell.MinimumHeight = 60
        FirmasServicioadm.AddCell(PdfPCell)
        Return FirmasServicioadm
    End Function

    Public Function PDFFIRMASv2(
                         ByVal Tamaniototal As Single,
                        Optional ByVal sello_izq As Sello = Nothing,
                         Optional ByVal sello_der As Sello = Nothing,
                         Optional ByVal MinimumHeight As Single = 60
                         ) As iTextSharp.text.pdf.PdfPTable
        Dim font10BoldSUAVE As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.BOLD, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#f1f2ef")))
        Dim font10Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font10Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font12BoldSUAVE As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#f1f2ef")))
        Dim font12Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim PARRAFOCOMPLETO As New iTextSharp.text.Paragraph()
        Dim tamaniocolumna As Single() = New Single(1) {}
        tamaniocolumna(0) = Convert.ToSingle(Tamaniototal * 0.5)
        tamaniocolumna(1) = Convert.ToSingle(Tamaniototal * 0.5)
        Dim FirmasServicioadm As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(2)
        FirmasServicioadm.TotalWidth = Tamaniototal
        FirmasServicioadm.SetWidths(tamaniocolumna)
        FirmasServicioadm.LockedWidth = True
        'Declaración de celdas.
        Dim PdfPCell As PdfPCell = Nothing
        If IsNothing(sello_izq) Then
            PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk(" " & vbNewLine, PDF_fuente_variable(10, True))))
            PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk(" ", font10BoldSUAVE)))
        Else
            PARRAFOCOMPLETO.Add(Sello_impresion(sello_izq))
        End If
        PARRAFOCOMPLETO.Alignment = 1
        PdfPCell = (New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
        PdfPCell.VerticalAlignment = 6
        PdfPCell.Border = 0
        PdfPCell.MinimumHeight = MinimumHeight
        FirmasServicioadm.AddCell(PdfPCell)
        PARRAFOCOMPLETO.Clear()
        If IsNothing(sello_der) Then
            PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk(" " & vbNewLine, PDF_fuente_variable(10, True))))
            PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk(" ", font10BoldSUAVE)))
        Else
            PARRAFOCOMPLETO.Add(Sello_impresion(sello_der))
        End If
        PARRAFOCOMPLETO.Alignment = 1
        PdfPCell = (New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
        PdfPCell.VerticalAlignment = 6
        PdfPCell.Border = 0
        PdfPCell.MinimumHeight = 60
        FirmasServicioadm.AddCell(PdfPCell)
        Return FirmasServicioadm
    End Function

    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="element">CORRESPONDE AL ELEMENTO ITEXTSHARP</param>
    ''' <param name="Border">TAMAÑO DEL BORDE</param>
    ''' <param name="columnspan">COLUMNAS DE ANCHO</param>
    ''' <param name="rowspan">FILAS DE ALTO</param>
    ''' <param name="ElementALIGN">ALINEACIÓN DEL CONTENIDO</param>
    ''' <returns></returns>
    Public Function Elementopdf_a_Celda_conborde(ByRef element As IElement,
                                                 ByVal Border As Single,
                                                 Optional ByVal columnspan As Integer = 1,
                                                 Optional rowspan As Integer = 1,
                                                 Optional ByVal ElementALIGN As Integer = Element.ALIGN_LEFT,
                                                 Optional ByVal setpadding As Single = 0,
                                                 Optional ByVal ElementALIGNvertical As Integer = Element.ALIGN_MIDDLE) As iTextSharp.text.pdf.PdfPCell
        'Creación de la celda que manejaria cada uno de los cuadros
        Dim Celdatotal As New iTextSharp.text.pdf.PdfPCell
        Celdatotal.AddElement(element)
        Celdatotal.HorizontalAlignment = ElementALIGN
        Celdatotal.VerticalAlignment = ElementALIGNvertical
        Celdatotal.BorderWidth = Border
        Celdatotal.Rowspan = rowspan
        Celdatotal.Colspan = columnspan
        Celdatotal.Padding = setpadding
        Return Celdatotal
    End Function

    ''' <summary>
    ''' Función que devuelve una celda para colocar en una tabla con los siguientes detalles
    ''' </summary>
    ''' <param name="texto">texto en formato string</param>
    ''' <param name="tamaniofuente">tamaño de la letra en single</param>
    ''' <param name="bold">bold en boolean</param>
    ''' <param name="Border">ancho del borde en single</param>
    ''' <param name="columnspan"> columnas de ancho de esta celda</param>
    ''' <param name="rowspan">filas de alto de esta celda</param>
    ''' <param name="alineacionhorizontal"> alineación horizontal, default en left = 0</param>
    ''' <param name="setpadding"> espacio entre el texto y los lados de la celda</param>
    ''' <param name="alineacionvertical"> alineacion vertical, default en middle=5</param>
    ''' <param name="INDENT">sangría en single, default =0 </param>
    ''' <param name="COLORCELDA"> el valor #ffffff corresponde al blanco y #c5c7c0 a una celda con fondo gris claro</param>
    ''' <returns></returns>
    Public Function Phrasepdf(ByVal texto As String, ByVal tamaniofuente As Single,
                              ByVal bold As Boolean,
                              ByVal Border As Single,
                              Optional ByVal columnspan As Integer = 1,
                              Optional rowspan As Integer = 1,
                              Optional ByVal alineacionhorizontal As Integer = Element.ALIGN_LEFT,
                              Optional ByVal setpadding As Single = 0,
                              Optional ByVal alineacionvertical As Integer = Element.ALIGN_MIDDLE,
                              Optional ByVal INDENT As Integer = 0,
                               Optional ByVal COLORCELDA As String = "#ffffff",
                               Optional ByVal LEADING As Single = 1,
                              Optional ByVal UNDERLINE As Boolean = False) As iTextSharp.text.pdf.PdfPCell
        'Creación de la celda que manejaria cada uno de los cuadros
        Dim element As Paragraph = New Paragraph(LEADING, texto, PDF_fuente_variable(tamaniofuente, bold, UNDERLINE))
        '   Dim element As New iTextSharp.text.Phrase(texto, PDF_fuente_variable(tamaniofuente, bold))
        Dim Celdatotal As New iTextSharp.text.pdf.PdfPCell(element) With {
             .BorderWidth = Border,
             .Rowspan = rowspan,
             .Colspan = columnspan,
             .HorizontalAlignment = alineacionhorizontal,
             .VerticalAlignment = alineacionvertical,
             .Padding = setpadding,
             .Indent = INDENT,
             .BackgroundColor = New iTextSharp.text.BaseColor(ColorTranslator.FromHtml(COLORCELDA))
                                 }
        If Celdatotal.BorderWidth > 0 And Celdatotal.BorderWidth < 0.5 Then
            Celdatotal.BorderColor = New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#88806D"))
        End If
        Return Celdatotal
    End Function

    Public Function PhrasepdfSKEW(ByVal texto As String, ByVal tamaniofuente As Single,
                              ByVal bold As Boolean,
                              ByVal Border As Single,
                              Optional ByVal columnspan As Integer = 1,
                              Optional rowspan As Integer = 1,
                              Optional ByVal alineacionhorizontal As Integer = Element.ALIGN_LEFT,
                              Optional ByVal setpadding As Single = 0,
                              Optional ByVal alineacionvertical As Integer = Element.ALIGN_MIDDLE,
                              Optional ByVal SKEW As Single = 0,
                              Optional ByVal UNDERLINE As Boolean = False) As iTextSharp.text.pdf.PdfPCell
        Dim TEXTCHUNK As New iTextSharp.text.Chunk
        TEXTCHUNK = New Chunk(texto, PDF_fuente_variable(tamaniofuente, bold, UNDERLINE))
        TEXTCHUNK.SetSkew(0, SKEW)
        'Dim PARRAFO As New Paragraph
        'PARRAFO.Add(TEXTCHUNK)
        'PARRAFO.Leading = LEADING
        'Creación de la celda que manejaria cada uno de los cuadros
        'Dim element As Paragraph = New Phrase(LEADING, texto, PDF_fuente_variable(tamaniofuente, bold, UNDERLINE))
        Dim Celdatotal As New PdfPCell(New iTextSharp.text.Phrase(TEXTCHUNK))
        With Celdatotal
            .BorderWidth = Border
            .Rowspan = rowspan
            .Colspan = columnspan
            .HorizontalAlignment = alineacionhorizontal
            .VerticalAlignment = alineacionvertical
            .Padding = setpadding
            '.BackgroundColor = New iTextSharp.text.BaseColor(ColorTranslator.FromHtml(COLORCELDA))
        End With
        'Dim element As New iTextSharp.text.Phrase(texto, PDF_fuente_variable(tamaniofuente, bold))
        'With Celdatotal   {
        '     .BorderWidth = Border,
        '     .Rowspan = rowspan,
        '     .Colspan = columnspan,
        '     .HorizontalAlignment = alineacionhorizontal,
        '     .VerticalAlignment = alineacionvertical,
        '     .Padding = setpadding,
        '     .Indent = INDENT
        '     '.BackgroundColor = New iTextSharp.text.BaseColor(ColorTranslator.FromHtml(COLORCELDA))
        '             }
        Return Celdatotal
    End Function

    ''' <summary>
    ''' Función que devuelve una celda con los parametros indicados
    ''' </summary>
    ''' <param name="element">texto as phrase</param>
    ''' <param name="Border">ancho de borde</param>
    ''' <param name="columnspan">columnas de ancho</param>
    ''' <param name="rowspan">filas de alto</param>Y
    ''' <param name="ElementALIGN">alineación de la celda</param>
    ''' <param name="PARRAFOLINEAS">espaciado de parrago</param>
    ''' <param name="COLORCELDA"> el valor #ffffff corresponde al blanco y #c5c7c0 a una celda con fondo gris claro</param>
    ''' <returns></returns>
    Public Function Phrasepdf_a_Celda_conborde(
                                              ByRef element As Phrase,
                                              ByVal Border As Single,
                                              Optional ByVal columnspan As Integer = 1,
                                              Optional rowspan As Integer = 1,
                                              Optional ByVal ElementALIGN As Integer = Element.ALIGN_LEFT,
                                              Optional ByVal PARRAFOLINEAS As Single = 1.5,
                                              Optional ByVal COLORCELDA As String = "#ffffff") As iTextSharp.text.pdf.PdfPCell
        'Creación de la celda que manejaria cada uno de los cuadros
        Dim parrafoquecontiene As Paragraph = New Paragraph
        Dim Celdatotal As New iTextSharp.text.pdf.PdfPCell
        With parrafoquecontiene
            .Add(element)
            .Alignment = ElementALIGN
            .SetLeading(element.Font.Size, PARRAFOLINEAS)
        End With
        With Celdatotal
            .AddElement(parrafoquecontiene)
            .BorderWidth = Border
            .Rowspan = rowspan
            .Colspan = columnspan
            .BackgroundColor = New iTextSharp.text.BaseColor(ColorTranslator.FromHtml(COLORCELDA))
        End With
        If Celdatotal.BorderWidth > 0 And Celdatotal.BorderWidth < 0.5 Then
            Celdatotal.BorderColor = New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#88806D"))
        End If
        Return Celdatotal
    End Function

    Public Function ParrafoPdF(ByVal listadetexto As List(Of iTextSharp.text.Chunk), Optional interlineado As Single = 1.5) As Paragraph
        Dim parrafo As New iTextSharp.text.Paragraph
        For Each texto As iTextSharp.text.Chunk In listadetexto
            parrafo.Add(texto)
        Next
        parrafo.Leading = (interlineado)
        Return parrafo
    End Function

    Public Function PDF_fuente_variable(ByVal Tamanio As Single, ByVal Bold As Boolean, Optional UNDERLINE As Boolean = False) As iTextSharp.text.Font
        Dim FontVariable As iTextSharp.text.Font
        If Bold Then
            If UNDERLINE Then
                FontVariable = New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, Tamanio, Font.BOLD Or Font.UNDERLINE, BaseColor.BLACK)
            Else
                FontVariable = New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, Tamanio, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            End If
        Else
            If UNDERLINE Then
                FontVariable = New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, Tamanio, iTextSharp.text.Font.UNDERLINE, BaseColor.BLACK)
            Else
                FontVariable = New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, Tamanio, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            End If
        End If
        Return FontVariable
    End Function

    'EXPERIMENTAL DEBE SER CORREGIDO
    Public Sub PDFPEDIDODEFONDO(ByVal Reporteaimprimir() As DataGridView, ByVal Titulo As String, ByVal Horizontal As Boolean, ByVal Tamaniohoja As String)
        'ByVal PEDIDOFONDO As PedidoFondos
        Dim Tamanio As Rectangle
        Select Case Tamaniohoja.ToUpper
            Case "LEGAL"
                Tamanio = iTextSharp.text.PageSize.LEGAL
            Case "A4"
                Tamanio = iTextSharp.text.PageSize.A4
            Case Else
                Tamanio = iTextSharp.text.PageSize.LEGAL
        End Select
        '6 CUADROS
        '6 DATAGRIDVIEW -1 CON DATOS RELEVANTES
        '3 CAMPOS DE FIRMAS
        Dim font12BoldRed As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.UNDERLINE Or iTextSharp.text.Font.BOLDITALIC, BaseColor.RED)
        Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font10Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font12Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font10Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font07Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim titleFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim Controlguardado As New SaveFileDialog
        Controlguardado.Filter = "ARCHIVO PDF|*.pdf"
        Controlguardado.Title = "Guardar en archivo PDF"
        Controlguardado.ShowDialog()
        If Controlguardado.FileName = "" Then
            MsgBox("Para poder proceder a la creación del archivo se requiere un nombre")
            Exit Sub
        Else
            Dim FileName As String = Controlguardado.FileName
            ' Dim paragraph As New Paragraph
            Dim anchototal As Integer = 0
            Dim doc As New Document
            'Selección de orientación de página
            If Horizontal Then
                doc = New Document(Tamanio.Rotate, 20, 20, 20, 20)
            Else
                doc = New Document(Tamanio, 20, 20, 20, 20)
            End If
            Dim wri As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(FileName, FileMode.Create))
            Dim ev As New itsEvents2
            wri.PageEvent = ev
            'si el archivo esta abierto, cerrarlo
            If doc.IsOpen Then
                doc.Close()
            End If
            'abrir archivo
            doc.Open()
            'Orden de entrega de fondos
            'Datos pedido de fondos
            'Solicitud de fondos y datagridview de detalle, 2 espacios de firma
            'Certificación de firma de delegado Fiscal 1 espacio de firma
            'Transferencia de la tesorería general 2 espacios de firma
            'Transferido por la tesorería Geenral datagridview con 8 filas
            Dim totalcolumnas As Integer = -1
            For x = 0 To Reporteaimprimir.Count - 1
                totalcolumnas = -1
                For V = 0 To Reporteaimprimir(x).Columns.Count - 1
                    If Not Reporteaimprimir(x).Columns(V).Visible = False Then
                        totalcolumnas = totalcolumnas + 1
                    End If
                Next
                For V = 0 To Reporteaimprimir(x).Columns.Count - 1
                    If Not Reporteaimprimir(x).Columns(V).Visible = False Then
                        totalcolumnas = totalcolumnas + 1
                    End If
                Next
                Dim Columnasvisibles(totalcolumnas) As Integer
                Dim control As Integer = 0
                For V = 0 To Reporteaimprimir(x).Columns.Count - 1
                    If Reporteaimprimir(x).Columns(V).Visible = True Then
                        Columnasvisibles(control) = V
                        control = control + 1
                    End If
                Next
                'MessageBox.Show(Columnasvisibles.Length - 1)
                '6 CUADROS
                '6 DATAGRIDVIEW -1 CON DATOS RELEVANTES
                '3 CAMPOS DE FIRMAS
                'Orden de entrega de fondos
                'Datos pedido de fondos
                'Solicitud de fondos y datagridview de detalle, 2 espacios de firma
                'Certificación de firma de delegado Fiscal 1 espacio de firma
                'Transferencia de la tesorería general 2 espacios de firma
                'Transferido por la tesorería Geenral datagridview con 8 filas
                ' Dim PdfTable As PdfPTable = New PdfPTable(Columnasvisibles.Length)
                'Selección de orientación de página
                'If Horizontal Then
                '    PdfTable.TotalWidth = Tamanio.Rotate.Width - 40
                'Else
                '    PdfTable.TotalWidth = Tamanio.Width - 40
                'End If
                'fix the absolute width of the table
                '  PdfTable.LockedWidth = True
                'relative col widths in proportions
                'Dim widths(0 To Columnasvisibles.Length - 1) As Single
                'For i As Integer = 0 To Columnasvisibles.Length - 1
                '    anchototal = anchototal + Reporteaimprimir.Columns(Columnasvisibles(i)).Width + 2
                'Next
                'For i As Integer = 0 To DTB.Columns.Count - 1
                '    widths(i) = CType((DTB.Columns(i) / anchototal), Single)
                'Next
                '' PdfTable.SetWidths(widths)
                'PdfTable.HorizontalAlignment = 1 ' 0 --> Left, 1 --> Center, 2 --> Right
                'PdfTable.SpacingBefore = 12.0F
                '
                'Encabezado posterior a la imagen del logo
                ''Encabezado posterior a la imagen del logo
                Dim DatosSolicitud As New Paragraph("", titleFont)
                ''Encabezado posterior a la imagen del logo
                'Dim CertificacionDelegadofiscal As New Paragraph("CertificacionDelegadofiscal", titleFont)
                ''Encabezado posterior a la imagen del logo
                'Dim Transferenciatesoreria As New Paragraph("Transferenciatesoreria", titleFont)
                ''Encabezado posterior a la imagen del logo
                'Dim TransferidoTesoreria As New Paragraph("TransferidoTesoreria", titleFont)
                '  doc.Add(Entregadefondos)
                'Agregar la tabla al parrafo
                DatosSolicitud.Add(TablaPDf(Reporteaimprimir(x)))
                'agrega el parrafo al documento
                doc.Add(DatosSolicitud)
                'agrega la parte de delegado fiscal
                'doc.Add(TablaPDf(Reporteaimprimir))
                'agrega la parte de transferencia de tesoreria
                ' doc.Add(Transferenciatesoreria)
                'agrega la parte de transferido de tesoreria
                '   doc.Add(Entregadefondos_tabla)
                '  doc.Add(Entregadefondos_tabla)
            Next
            ''If Reporteaimprimir IsNot Nothing Then
            'Dim totalcolumnas As Integer = -1
            'doc.Add(PdfTable)
            'Verificar intento de agregar firma
            doc.Add(New Paragraph(Autorizaciones.Usuario.Rows(0).Item("Apellidos").ToString & "  " & Autorizaciones.Usuario.Rows(0).Item("nombres").ToString, FontFactory.GetFont("ARIAL", 6, iTextSharp.text.Font.BOLD)))
            doc.AddCreator(Autorizaciones.Usuario.Rows(0).Item("Apellidos").ToString & "  " & Autorizaciones.Usuario.Rows(0).Item("nombres").ToString)
            doc.AddHeader("", Autorizaciones.Nombrecompletodelservicio)
            doc.Close()
            Select Case MsgBox("Archivo generado Exitosamente" & vbCrLf & "Desea abrir el archivo generado?", MsgBoxStyle.YesNoCancel, " ")
                Case MsgBoxResult.Yes
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(Controlguardado.FileName) With {
                                                         .UseShellExecute = True})
            End Select
            'unaTabla.SetWidthPercentage(New Single() {300, 300}, PageSize.A4)
            ''Headers
            'unaTabla.AddCell(New Paragraph("Columna 1"))
            'unaTabla.AddCell(New Paragraph("Columna 2"))
            ''�Le damos un poco de formato?
            'For Each celda As PdfPCell In unaTabla.Rows(0).GetCells
            '    celda.BackgroundColor = BaseColor.LIGHT_GRAY
            '    celda.HorizontalAlignment = 1
            '    celda.Padding = 3
            'Next
            'Dim celda1 As PdfPCell = New PdfPCell(New Paragraph("Celda 1", FontFactory.GetFont("Arial", 10)))
            'Dim celda2 As PdfPCell = New PdfPCell(New Paragraph("Celda 2", FontFactory.GetFont("Arial", 10)))
            'Dim celda3 As PdfPCell = New PdfPCell(New Paragraph("Celda 3", FontFactory.GetFont("Arial", 10)))
            'Dim celda4 As PdfPCell = New PdfPCell(New Paragraph("Celda 4", FontFactory.GetFont("Arial", 10)))
            'unaTabla.AddCell(celda1)
            'unaTabla.AddCell(celda2)
            'unaTabla.AddCell(celda3)
            'unaTabla.AddCell(celda4)
            'doc.Add(unaTabla)
        End If
        'End If
        '
    End Sub

    'Public Sub Sign(ByVal SigReason As String, ByVal SigContact As String, ByVal SigLocation As String, ByVal visible As Boolean)
    '    Dim reader As PdfReader = New PdfReader(Me.inputPDF)
    '    Dim st As PdfStamper = PdfStamper.CreateSignature(reader, New FileStream(Me.outputPDF, FileMode.Create, FileAccess.Write), vbNullChar, Nothing, True)
    'New FileStream(Me.outputPDF, FileMode.Create, FileAccess.Write)
    'vbNullChar
    '    st.MoreInfo = Me.metadata.getMetaData()
    '    st.XmpMetadata = Me.metadata.getStreamedMetaData()
    '    Dim sap As PdfSignatureAppearance = st.SignatureAppearance
    '    sap.SetCrypto(Me.myCert.Akp, Me.myCert.Chain, Nothing, PdfSignatureAppearance.WINCER_SIGNED)
    '    sap.Reason = SigReason
    '    sap.Contact = SigContact
    '    sap.Location = SigLocation
    '    If visible Then sap.SetVisibleSignature(New iTextSharp.text.Rectangle(100, 100, 250, 150), 1, Nothing)
    '    st.Close()
    'End Sub
    'Private Sub processCert()
    '    Dim [alias] As String = Nothing
    '    Dim pk12 As PKCS12Store
    '    pk12 = New PKCS12Store(New FileStream(Me.Path, FileMode.Open, FileAccess.Read), Me.password.ToCharArray())
    '    Dim i As IEnumerator = pk12.aliases()
    '    While i.MoveNext()
    '        [alias] = (CStr(i.Current))
    '        If pk12.isKeyEntry([alias]) Then Exit While
    '    End While
    '    Me.akp = pk12.getKey([alias]).getKey()
    '    Dim ce As X509CertificateEntry() = pk12.getCertificateChain([alias])
    '    Me.chain = New Org.BouncyCastle.X509.X509Certificate(ce.Length - 1) {}
    '    For k As Integer = 0 To ce.Length - 1
    '        chain(k) = ce(k).getCertificate()
    '    Next
    'End Sub
    ''' <summary>
    ''' PDF PARA ORDENES DE PROVISION
    ''' </summary>
    ''' <param name="Ordenprovision"> CLASE ORDEN DE PROVISION</param>
    ''' <param name="Tamaniohoja"> STRING = LEGAL, A4</param>
    ''' <param name="TAMANIOFUENTE">COMO DEFAULT 8</param>
    ''' <param name="TAMANIOFUENTETABLA">COMO DEFAULT 8 </param>
    Public Sub PDF_ordenProvision(
                                 ByVal Ordenprovision As OrdenProvision,
                                 ByVal Tamaniohoja As String,
                                 Optional ByVal TAMANIOFUENTE As Single = 8,
                                 Optional ByVal TAMANIOFUENTETABLA As Single = 8, Optional tamanioscolumna As Single() = Nothing)
        Dim Datos As New DataTable
        'clase
        'itextsharp.pagesize
        'New iTextSharp.text.Font
        'font size
        Dim Doc As New Document(PageSize.LEGAL, 60, 40, 20, 35)
        'Dim FileName As String = FileName
        Dim Anchopagina As Single = Doc.PageSize.Width
        Dim Controlguardado As New SaveFileDialog
        With Controlguardado
            Select Case System.IO.Directory.Exists("C:" & "\" & "Ordenes_de_Provision" & "\" & Ordenprovision.OrdenProvisionYear & "\")
                Case True
                Case False
                    System.IO.Directory.CreateDirectory("C:" & "\" & "Ordenes_de_Provision" & "\" & Ordenprovision.OrdenProvisionYear & "\")
            End Select
            .Filter = "ARCHIVO PDF|*.pdf"
            .Title = "Guardar en archivo PDF"
            .FileName = " OP - " & Ordenprovision.OrdenProvisionNumero & "-" & Ordenprovision.OrdenProvisionYear & ".pdf"
            .RestoreDirectory = True
            .InitialDirectory = "C:" & "\" & "Ordenes_de_Provision" & "\" & Ordenprovision.OrdenProvisionYear & "\"
        End With
        Controlguardado.Filter = "ARCHIVO PDF|*.pdf"
        Controlguardado.Title = "Guardar en archivo PDF"
        Controlguardado.ShowDialog()
        If Controlguardado.FileName = "" Then
            MsgBox("Para poder proceder a la creación del archivo se requiere un nombre")
            Exit Sub
        Else
            Dim FileName As String = Controlguardado.FileName
            Using wri = PdfWriter.GetInstance(Doc, New FileStream(FileName, FileMode.Create))
                '   Dim ev As New itsEventsX
                'Abrir el documento para el uso
                'Insertar una página en blanco nueva
                '    wri.PageEvent = ev
                'Crear tabla General para cargar los bordes
                Dim Tabla_total As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(1)
                Tabla_total.TotalWidth = Anchopagina - Doc.LeftMargin
                Tabla_total.LockedWidth = True
                Dim tamaniocolumna_total As Single() = New Single(0) {}
                tamaniocolumna_total(0) = Convert.ToSingle(Anchopagina - Doc.LeftMargin * 1)
                Tabla_total.SetWidths(tamaniocolumna_total)
                'Creación de la celda que manejaria cada uno de los cuadros
                Dim PARRAFOTOTAL As New iTextSharp.text.Paragraph()
                Dim PARRAFOCOMPLETO As New iTextSharp.text.Paragraph()
                Dim PARRAFOPARCIAL As New iTextSharp.text.Paragraph()
                Dim Phrasetemporal As New iTextSharp.text.Phrase()
                'Crear tabla para manejar los encabezados---------------------------------------------------------------------------------------------
                Dim Encabezadosx As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(2)
                Encabezadosx.TotalWidth = Anchopagina - Doc.LeftMargin
                Encabezadosx.LockedWidth = True
                'Declaración variable de ancho de columnas
                Dim tamaniocolumna As Single() = New Single(1) {}
                tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.2)
                tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.8)
                Encabezadosx.SetWidths(tamaniocolumna)
                'para insertar un espacio entre las celdas
                Dim PdfpCell_espaciovacio As iTextSharp.text.pdf.PdfPCell = New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("", PDF_fuente_variable(TAMANIOFUENTE + 2, False))))
                PdfpCell_espaciovacio.BorderWidth = 0
                PdfpCell_espaciovacio.FixedHeight = 3.0F
                Dim PdfpCell_espaciovacioborde As iTextSharp.text.pdf.PdfPCell = New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("", PDF_fuente_variable(TAMANIOFUENTE + 2, False))))
                PdfpCell_espaciovacioborde.BorderWidth = 0.5
                PdfpCell_espaciovacioborde.FixedHeight = 2.0F
                'crear imagen con logo a la izquierda
                Dim manejadorimagen As iTextSharp.text.Image = Image.GetInstance(My.Resources.Logo, System.Drawing.Imaging.ImageFormat.Jpeg)
                'asignar la imagen itextsharp a la celda
                Dim PdfPCell As iTextSharp.text.pdf.PdfPCell = New PdfPCell(manejadorimagen, True)
                PdfPCell.Rowspan = 2
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_LEFT
                PdfPCell.FixedHeight = 70.0F
                Encabezadosx.AddCell(PdfPCell)
                'Encabezado del año
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Encabezadodelyear(Ordenprovision.fecharealizada_ordenprovision.Year), PDF_fuente_variable(TAMANIOFUENTE + 2, False))))
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.FixedHeight = 25.0F
                Encabezadosx.AddCell(PdfPCell)
                '----------------------NOMBRE DEL SERVICIO ADMINISTRATIVO------------------------------
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Nombrecompletodelservicio.ToUpper, PDF_fuente_variable(TAMANIOFUENTE + 4, True))))
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.FixedHeight = 25.0F
                Encabezadosx.AddCell(PdfPCell)
                '----------------------AGREGA EL ENCABEZADO Completo------------------------------
                ' Frase_total.Clear()
                PARRAFOCOMPLETO.Add(Encabezadosx)
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
                'Tabla_total.AddCell(PdfpCell_espaciovacio)
                ' Doc.Add(Encabezadosx)
                '----------------------ORDEN DE PROVISION DATOS GENERALES-----------------------------
                Dim DatosOrdenprovision As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(3)
                DatosOrdenprovision.TotalWidth = Anchopagina - Doc.LeftMargin
                DatosOrdenprovision.LockedWidth = True
                tamaniocolumna = New Single(2) {}
                tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.2)
                tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.6)
                tamaniocolumna(2) = Convert.ToSingle(Anchopagina * 0.2)
                DatosOrdenprovision.SetWidths(tamaniocolumna)
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(TAMANIOFUENTE + 2, False))))
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                DatosOrdenprovision.AddCell(PdfPCell)
                PARRAFOPARCIAL.Clear()
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("ORDEN DE PROVISIÓN Nº", PDF_fuente_variable(12, True, True)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(" " & Ordenprovision.OrdenProvisionNumero & "/" & Ordenprovision.OrdenProvisionYear & vbNewLine, PDF_fuente_variable(TAMANIOFUENTE + 4, False)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("EXPEDIENTE AUTORIZANTE Nº", PDF_fuente_variable(12, True, True)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(" " & Ordenprovision.Expediente & vbNewLine, PDF_fuente_variable(TAMANIOFUENTE + 4, False)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("INICIADOR:", PDF_fuente_variable(12, True, True)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(" " & Ordenprovision.Iniciador & vbNewLine, PDF_fuente_variable(TAMANIOFUENTE + 4, False)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("DESTINO:", PDF_fuente_variable(12, True, True)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(" " & Ordenprovision.Destino & vbNewLine, PDF_fuente_variable(TAMANIOFUENTE + 4, False)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("LUGAR DE ENTREGA:", PDF_fuente_variable(12, True, True)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(" " & Ordenprovision.LugarEntrega, PDF_fuente_variable(TAMANIOFUENTE + 4, False)))
                PdfPCell = (New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOPARCIAL, 0, 3, 1, 0, 10, Element.ALIGN_CENTER)))
                'PdfPCell.BorderWidth = 0
                'PdfPCell.HorizontalAlignment = Element.ALIGN_LEFT
                DatosOrdenprovision.AddCell(PdfPCell)
                'DatosOrdenprovision.AddCell(PdfpCell_espaciovacioborde)
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(TAMANIOFUENTE + 2, False))))
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.Colspan = 2
                DatosOrdenprovision.AddCell(PdfPCell)
                PARRAFOCOMPLETO.Clear()
                PdfPCell.Colspan = 1
                PARRAFOCOMPLETO.Add(DatosOrdenprovision)
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
                'DATOS DEL PROVEEDOR
                '----------------------AGREGA ORDEN DE PROVISION DATOS GENERALES------------------------------
                tamaniocolumna = New Single(0) {}
                tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 1)
                DatosOrdenprovision = New iTextSharp.text.pdf.PdfPTable(1)
                DatosOrdenprovision.SetWidths(tamaniocolumna)
                PARRAFOPARCIAL.Clear()
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("SEÑOR: ", PDF_fuente_variable(TAMANIOFUENTE + 4, True)))
                Select Case Ordenprovision.Nombre_Fantasia.Length > 2
                    Case True
                        PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(Ordenprovision.Nombre_Fantasia & " de " & Ordenprovision.Nombre, PDF_fuente_variable(TAMANIOFUENTE + 4, False)))
                    Case False
                        PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(Ordenprovision.Nombre, PDF_fuente_variable(TAMANIOFUENTE + 4, False)))
                End Select
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(vbCrLf & "CUIT Nº: ", PDF_fuente_variable(TAMANIOFUENTE + 4, True)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(Ordenprovision.CUIT, PDF_fuente_variable(TAMANIOFUENTE + 4, False)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(vbCrLf & "DOMICILIO: ", PDF_fuente_variable(TAMANIOFUENTE + 4, True)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(Ordenprovision.Domicilio_real, PDF_fuente_variable(TAMANIOFUENTE + 4, False)))
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOPARCIAL, 0, 1, 1, 0, 1, Element.ALIGN_MIDDLE)))
                DatosOrdenprovision.AddCell(PdfpCell_espaciovacioborde)
                PARRAFOPARCIAL.Clear()
                'Sírvase entregar en el término de XX DIAS, conforme lo cotizado en el citado expediente, los árticulos que se detallan a continuación correspondiente a la COMPRA DIRECTA NºXX/XX.
                'Realizada el día XX de XXXXX de 20XX, aprobada por ResDEcreto Nº XX/20XX (fecha)
                Select Case Ordenprovision.fechaobservaciones_ordenprovision.Count > 5
                    Case True
                        PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("Sírvase entregar en el término detallado (**)  ", PDF_fuente_variable(TAMANIOFUENTE + 4, False)))
                    Case False
                        PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("Sírvase entregar en el término de ", PDF_fuente_variable(TAMANIOFUENTE + 4, False)))
                        Select Case Ordenprovision.ValorTiempoEntrega
                            Case Is = 1
                                Select Case Ordenprovision.UnidadTiempoEntrega
                                    Case Is = "DÍAS"
                                        Ordenprovision.UnidadTiempoEntrega = "DÍA"
                                    Case Is = "DÍAS HÁBILES"
                                        Ordenprovision.UnidadTiempoEntrega = "DÍA HÁBIL"
                                    Case Is = "SEMANAS"
                                        Ordenprovision.UnidadTiempoEntrega = "SEMANA"
                                    Case Is = "MESES"
                                        Ordenprovision.UnidadTiempoEntrega = "MES"
                                End Select
                            Case Else
                        End Select
                        PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(Ordenprovision.ValorTiempoEntrega & " " & Ordenprovision.UnidadTiempoEntrega & " ", PDF_fuente_variable(TAMANIOFUENTE + 4, True)))
                End Select
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(", conforme lo cotizado en el citado expediente, los artículos que se detallan a continuación correspondiente a la ", PDF_fuente_variable(TAMANIOFUENTE + 4, False)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(Ordenprovision.TipoOrigen & " Nº " & Ordenprovision.NumeroOrigen & "/" & Ordenprovision.YearOrigen & vbNewLine, PDF_fuente_variable(TAMANIOFUENTE + 4, True)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(" Realizada el día ", PDF_fuente_variable(12, False)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(Ordenprovision.fecharealizada_ordenprovision.ToString("dd", CultureInfo.CreateSpecificCulture("es-AR")) & " DE " &
                                                             Ordenprovision.fecharealizada_ordenprovision.ToString("MMMM", CultureInfo.CreateSpecificCulture("es-AR")).ToUpper & " DE " &
                                                             Ordenprovision.fecharealizada_ordenprovision.ToString("yyyy", CultureInfo.CreateSpecificCulture("es-AR")), PDF_fuente_variable(12, True)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(", aprobada por ", PDF_fuente_variable(TAMANIOFUENTE + 4, False)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(Ordenprovision.TipoInstrumentoLegal & " Nº " & Ordenprovision.NumeroInstrumentoLegal & "/" & Ordenprovision.YearInstrumentoLegal & "(" & Ordenprovision.FechaInstrumentoLegal.ToShortDateString & ")" & vbNewLine, PDF_fuente_variable(TAMANIOFUENTE + 4, True)))
                PARRAFOPARCIAL.Alignment = Element.ALIGN_JUSTIFIED
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOPARCIAL, 0, 1, 1, Element.ALIGN_JUSTIFIED, 1, Element.ALIGN_MIDDLE)))
                Tabla_total.AddCell(PdfpCell_espaciovacio)
                'esto vendría a ser el encabezado de todas las hojas del documento
                Dim encabezado As New itsEventscustom
                encabezado.tablaencabezado = Tabla_total
                Doc.SetMargins(Doc.LeftMargin, Doc.RightMargin, Doc.TopMargin + Tabla_total.TotalHeight, Doc.BottomMargin)
                Doc.Open()
                wri.PageEvent = encabezado
                Doc.NewPage()
                'agrego la tabla total para evitar segmentación de página
                '''''''''''''''Doc.Add(Tabla_total)
                ' PARRAFOTOTAL.Add(Tabla_total)
                Tabla_total = New iTextSharp.text.pdf.PdfPTable(1)
                Tabla_total.TotalWidth = Anchopagina - Doc.LeftMargin
                Tabla_total.LockedWidth = True
                tamaniocolumna_total = New Single(0) {}
                tamaniocolumna_total(0) = Convert.ToSingle(Anchopagina - Doc.LeftMargin * 1)
                Tabla_total.SetWidths(tamaniocolumna_total)
                'para lograr la adaptación completa debo disminuir el margen necesario
                Dim anchoutil As Single = Anchopagina - Doc.LeftMargin
                tamaniocolumna = New Single(7) {}
                tamaniocolumna(0) = Convert.ToSingle(anchoutil * 0.04) 'Reng.
                tamaniocolumna(1) = Convert.ToSingle(anchoutil * 0.04) 'Cant
                tamaniocolumna(2) = Convert.ToSingle(anchoutil * 0.1) 'Un.
                tamaniocolumna(3) = Convert.ToSingle(anchoutil * 0.47) ' ARTICULOS
                tamaniocolumna(4) = Convert.ToSingle(anchoutil * 0.1) ' PREC. UNITARIO
                tamaniocolumna(5) = Convert.ToSingle(anchoutil * 0.12) 'PRECIO TOTAL
                tamaniocolumna(6) = Convert.ToSingle(anchoutil * 0.12) 'Observaciones
                tamaniocolumna(7) = Convert.ToSingle(anchoutil * 0.12) 'ENCABEZADO
                Dim TABLAORDENPROVISION As iTextSharp.text.pdf.PdfPTable = PDFDatatable_OP(
                    Ordenprovision.DATOSORDENPROVISION, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#ffffff")), TAMANIOFUENTE)
                Dim TABLAORDENPROVISION2 As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(TABLAORDENPROVISION.NumberOfColumns)
                TABLAORDENPROVISION2.TotalWidth = TABLAORDENPROVISION.TotalWidth
                TABLAORDENPROVISION2.SetWidths(TABLAORDENPROVISION.AbsoluteWidths)
                TABLAORDENPROVISION2.LockedWidth = True
                Dim Totalsumado As Decimal = 0
                PARRAFOPARCIAL.Clear()
                For X = 0 To Ordenprovision.DATOSORDENPROVISION.Rows.Count - 1
                    Totalsumado += CType(Ordenprovision.DATOSORDENPROVISION.Rows(X).Item(5), Decimal)
                Next
                If Ordenprovision.fechaobservaciones_ordenprovision.Count > 5 Then
                    TABLAORDENPROVISION.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(New iTextSharp.text.Chunk(Ordenprovision.fechaobservaciones_ordenprovision, PDF_fuente_variable(TAMANIOFUENTE + 2, False)), 0.5, 6, 1, iTextSharp.text.Element.ALIGN_JUSTIFIED, 4, Element.ALIGN_TOP)))
                End If
                TABLAORDENPROVISION.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" TOTAL ", PDF_fuente_variable(10, True))), 0.5, 4, 1, iTextSharp.text.Element.ALIGN_RIGHT)))
                TABLAORDENPROVISION.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Totalsumado.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), PDF_fuente_variable(TAMANIOFUENTE + 2, True))), 0.5, 2, 1, Element.ALIGN_CENTER)))
                TABLAORDENPROVISION.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(New iTextSharp.text.Chunk("IMPORTA LA PRESENTE ORDEN DE PROVISIÓN LA SUMA DE PESOS:  " & Inicio.Num2Text(Math.Truncate(Convert.ToDecimal(Totalsumado))) & " CON " &
                ((Convert.ToDecimal(Totalsumado) - Math.Truncate(Convert.ToDecimal(Totalsumado))) * 100).ToString("00") & "/100.-", PDF_fuente_variable(TAMANIOFUENTE + 2, False)), 0.5, 6, 1, Element.ALIGN_RIGHT, 4, Element.ALIGN_TOP)))
                TABLAORDENPROVISION.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(New iTextSharp.text.Chunk("POSADAS," & Ordenprovision.Fechaconfeccionada_ordenprovision.ToString("dd", CultureInfo.CreateSpecificCulture("es-AR")) & " DE " &
                                                                 Ordenprovision.Fechaconfeccionada_ordenprovision.ToString("MMMM", CultureInfo.CreateSpecificCulture("es-AR")).ToUpper & " DE " &
                                                                 Ordenprovision.Fechaconfeccionada_ordenprovision.ToString("yyyy", CultureInfo.CreateSpecificCulture("es-AR")), PDF_fuente_variable(TAMANIOFUENTE + 4, False)), 0.5, 6, 1, Element.ALIGN_RIGHT, 4, Element.ALIGN_TOP)))
                '   TABLAORDENPROVISION.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Iniciales(Ordenprovision.USUARIO), PDF_fuente_variable(6, True))), 0, 6, 1, iTextSharp.text.Element.ALIGN_LEFT, 0)))
                TABLAORDENPROVISION2.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(New iTextSharp.text.Chunk("IMPORTANTE ", PDF_fuente_variable(TAMANIOFUENTE, True)), 0, 3, 1, 2)))
                TABLAORDENPROVISION2.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(New iTextSharp.text.Chunk(" 1) Esta orden deberá acompañar la correspondiente factura por duplicado para su cobro" & vbNewLine &
           "2) Deberá sellarse según lo establecen disposiciones vigentes con el 10% o (Sellado Provincial)", PDF_fuente_variable(TAMANIOFUENTE, False)), 0, 3, 1, 2)))
                'PARRAFOTOTAL.Add(TABLAORDENPROVISION)
                Doc.Add(PARRAFOTOTAL)
                Doc.Add(TABLAORDENPROVISION)
                Doc.Add(TABLAORDENPROVISION2)
                Doc.Add(TABLA_INICIALES(anchoutil, Ordenprovision.USUARIO))
                PARRAFOPARCIAL.Clear()
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("ORIGINAL", PDF_fuente_variable(TAMANIOFUENTE + 6, True)))
                PARRAFOPARCIAL.Alignment = Element.ALIGN_CENTER
                Doc.Add(PARRAFOPARCIAL)
                Doc.NewPage()
                Doc.Add(PARRAFOTOTAL)
                Doc.Add(TABLAORDENPROVISION)
                Doc.Add(TABLAORDENPROVISION2)
                PARRAFOPARCIAL.Clear()
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("DUPLICADO", PDF_fuente_variable(TAMANIOFUENTE + 6, True)))
                PARRAFOPARCIAL.Alignment = Element.ALIGN_CENTER
                Doc.Add(PARRAFOPARCIAL)
                Doc.NewPage()
                Doc.Add(PARRAFOTOTAL)
                Doc.Add(TABLAORDENPROVISION)
                Doc.Add(TABLAORDENPROVISION2)
                PARRAFOPARCIAL.Clear()
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("TRIPLICADO", PDF_fuente_variable(TAMANIOFUENTE + 6, True)))
                PARRAFOPARCIAL.Alignment = Element.ALIGN_CENTER
                Doc.Add(PARRAFOPARCIAL)
                Doc.NewPage()
                Doc.Add(PARRAFOTOTAL)
                Doc.Add(TABLAORDENPROVISION)
                Doc.Add(TABLAORDENPROVISION2)
                PARRAFOPARCIAL.Clear()
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("CUADRUPLICADO", PDF_fuente_variable(TAMANIOFUENTE + 6, True)))
                PARRAFOPARCIAL.Alignment = Element.ALIGN_CENTER
                Doc.Add(PARRAFOPARCIAL)
                Doc.Close()
            End Using
            Select Case MsgBox("Abrir el archivo generado?", MsgBoxStyle.YesNoCancel, " ")
                Case MsgBoxResult.Yes
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(Controlguardado.FileName) With {
                                             .UseShellExecute = True
    })
            End Select
        End If
    End Sub

    Public Sub PDF_ordenProvisionv2(ByVal Ordenprovision As OrdenProvision)
        Dim Datos As New DataTable
        Dim impresor As New Impresion
        impresor.fecha = Ordenprovision.fecharealizada_ordenprovision
        impresor.cargartodoslossellos()
        impresor.tamaniofuente = 11
        impresor.tamaniofuentetitulos = 13
        'clase
        'itextsharp.pagesize
        'New iTextSharp.text.Font
        'font size
        Dialogo_impresion.Cargar_impresion(impresor)
        Dim Doc As New Document(impresor.hoja, impresor.marginleft, impresor.marginright, impresor.margintop, impresor.marginbottom)
        'Dim FileName As String = FileName
        Dim Anchopagina As Single = Doc.PageSize.Width
        Dim Controlguardado As New SaveFileDialog
        With Controlguardado
            Select Case System.IO.Directory.Exists("C:" & "\" & "Ordenes_de_Provision" & "\" & Ordenprovision.OrdenProvisionYear & "\")
                Case True
                Case False
                    System.IO.Directory.CreateDirectory("C:" & "\" & "Ordenes_de_Provision" & "\" & Ordenprovision.OrdenProvisionYear & "\")
            End Select
            .Filter = "ARCHIVO PDF|*.pdf"
            .Title = "Guardar en archivo PDF"
            .FileName = " OP - " & Ordenprovision.OrdenProvisionNumero & "-" & Ordenprovision.OrdenProvisionYear & ".pdf"
            .RestoreDirectory = True
            .InitialDirectory = "C:" & "\" & "Ordenes_de_Provision" & "\" & Ordenprovision.OrdenProvisionYear & "\"
        End With
        Controlguardado.Filter = "ARCHIVO PDF|*.pdf"
        Controlguardado.Title = "Guardar en archivo PDF"
        Controlguardado.ShowDialog()
        If Controlguardado.FileName = "" Then
            MsgBox("Para poder proceder a la creación del archivo se requiere un nombre")
            Exit Sub
        Else
            Dim FileName As String = Controlguardado.FileName
            Using wri = PdfWriter.GetInstance(Doc, New FileStream(FileName, FileMode.Create))
                '   Dim ev As New itsEventsX
                'Abrir el documento para el uso
                'Insertar una página en blanco nueva
                '    wri.PageEvent = ev
                'Crear tabla General para cargar los bordes
                Dim Tabla_total As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(1)
                Tabla_total.TotalWidth = Anchopagina - Doc.LeftMargin
                Tabla_total.LockedWidth = True
                Dim tamaniocolumna_total As Single() = New Single(0) {}
                tamaniocolumna_total(0) = Convert.ToSingle(Anchopagina - Doc.LeftMargin * 1)
                Tabla_total.SetWidths(tamaniocolumna_total)
                'Creación de la celda que manejaria cada uno de los cuadros
                Dim PARRAFOTOTAL As New iTextSharp.text.Paragraph()
                Dim PARRAFOCOMPLETO As New iTextSharp.text.Paragraph()
                Dim PARRAFOPARCIAL As New iTextSharp.text.Paragraph()
                Dim Phrasetemporal As New iTextSharp.text.Phrase()
                'Crear tabla para manejar los encabezados---------------------------------------------------------------------------------------------
                Dim Encabezadosx As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(2)
                Encabezadosx.TotalWidth = Anchopagina - Doc.LeftMargin
                Encabezadosx.LockedWidth = True
                'Declaración variable de ancho de columnas
                Dim tamaniocolumna As Single() = New Single(1) {}
                tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.2)
                tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.8)
                Encabezadosx.SetWidths(tamaniocolumna)
                'para insertar un espacio entre las celdas
                Dim PdfpCell_espaciovacio As iTextSharp.text.pdf.PdfPCell = New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("", PDF_fuente_variable(impresor.tamaniofuente + 2, False))))
                PdfpCell_espaciovacio.BorderWidth = 0
                PdfpCell_espaciovacio.FixedHeight = 3.0F
                Dim PdfpCell_espaciovacioborde As iTextSharp.text.pdf.PdfPCell = New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("", PDF_fuente_variable(impresor.tamaniofuente + 2, False))))
                PdfpCell_espaciovacioborde.BorderWidth = 0.5
                PdfpCell_espaciovacioborde.FixedHeight = 2.0F
                'crear imagen con logo a la izquierda
                Dim manejadorimagen As iTextSharp.text.Image = Image.GetInstance(My.Resources.Logo, System.Drawing.Imaging.ImageFormat.Jpeg)
                'asignar la imagen itextsharp a la celda
                Dim PdfPCell As iTextSharp.text.pdf.PdfPCell = New PdfPCell(manejadorimagen, True)
                PdfPCell.Rowspan = 2
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_LEFT
                PdfPCell.FixedHeight = 70.0F
                Encabezadosx.AddCell(PdfPCell)
                'Encabezado del año
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Encabezadodelyear(Ordenprovision.fecharealizada_ordenprovision.Year), PDF_fuente_variable(impresor.tamaniofuente - 1, False))))
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.FixedHeight = 35.0F
                Encabezadosx.AddCell(PdfPCell)
                '----------------------NOMBRE DEL SERVICIO ADMINISTRATIVO------------------------------
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Nombrecompletodelservicio.ToUpper, PDF_fuente_variable(impresor.tamaniofuentetitulos, True))))
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.FixedHeight = 25.0F
                Encabezadosx.AddCell(PdfPCell)
                '----------------------AGREGA EL ENCABEZADO Completo------------------------------
                ' Frase_total.Clear()
                PARRAFOCOMPLETO.Add(Encabezadosx)
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
                'Tabla_total.AddCell(PdfpCell_espaciovacio)
                ' Doc.Add(Encabezadosx)
                '----------------------ORDEN DE PROVISION DATOS GENERALES-----------------------------
                Dim DatosOrdenprovision As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(3)
                DatosOrdenprovision.TotalWidth = Anchopagina - Doc.LeftMargin
                DatosOrdenprovision.LockedWidth = True
                tamaniocolumna = New Single(2) {}
                tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.1)
                tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.8)
                tamaniocolumna(2) = Convert.ToSingle(Anchopagina * 0.1)
                DatosOrdenprovision.SetWidths(tamaniocolumna)
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(impresor.tamaniofuente + 2, False))))
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                DatosOrdenprovision.AddCell(PdfPCell)
                PARRAFOPARCIAL.Clear()
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("ORDEN DE PROVISIÓN Nº", PDF_fuente_variable(12, True, True)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(" " & Ordenprovision.OrdenProvisionNumero & "/" & Ordenprovision.OrdenProvisionYear & vbNewLine, PDF_fuente_variable(impresor.tamaniofuentetitulos + 1, True)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("EXPEDIENTE AUTORIZANTE Nº", PDF_fuente_variable(12, True, True)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(" " & Ordenprovision.Expediente & vbNewLine, PDF_fuente_variable(impresor.tamaniofuentetitulos, False)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("INICIADOR:", PDF_fuente_variable(12, True, True)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(" " & Ordenprovision.Iniciador & vbNewLine, PDF_fuente_variable(impresor.tamaniofuentetitulos, False)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("DESTINO:", PDF_fuente_variable(12, True, True)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(" " & Ordenprovision.Destino & vbNewLine, PDF_fuente_variable(impresor.tamaniofuentetitulos, False)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("LUGAR DE ENTREGA:", PDF_fuente_variable(12, True, True)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(" " & Ordenprovision.LugarEntrega, PDF_fuente_variable(impresor.tamaniofuentetitulos, False)))
                PdfPCell = (New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOPARCIAL, 0, 3, 1, 0, 10, Element.ALIGN_CENTER)))
                'PdfPCell.BorderWidth = 0
                'PdfPCell.HorizontalAlignment = Element.ALIGN_LEFT
                DatosOrdenprovision.AddCell(PdfPCell)
                'DatosOrdenprovision.AddCell(PdfpCell_espaciovacioborde)
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(impresor.tamaniofuente + 2, False))))
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.Colspan = 2
                DatosOrdenprovision.AddCell(PdfPCell)
                PARRAFOCOMPLETO.Clear()
                PdfPCell.Colspan = 1
                PARRAFOCOMPLETO.Add(DatosOrdenprovision)
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
                'DATOS DEL PROVEEDOR
                '----------------------AGREGA ORDEN DE PROVISION DATOS GENERALES------------------------------
                tamaniocolumna = New Single(0) {}
                tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 1)
                DatosOrdenprovision = New iTextSharp.text.pdf.PdfPTable(1)
                DatosOrdenprovision.SetWidths(tamaniocolumna)
                PARRAFOPARCIAL.Clear()
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("SEÑOR: ", PDF_fuente_variable(impresor.tamaniofuentetitulos, True)))
                Select Case Ordenprovision.Nombre_Fantasia.Length > 2
                    Case True
                        If (Ordenprovision.CUIT.Substring(0, 2) = "30" Or Ordenprovision.CUIT.Substring(0, 2) = "33" Or Ordenprovision.CUIT.Substring(0, 2) = "34") Then
                            PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(Ordenprovision.Nombre, PDF_fuente_variable(impresor.tamaniofuentetitulos, False)))
                        Else
                            PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(Ordenprovision.Nombre_Fantasia & " de " & Ordenprovision.Nombre, PDF_fuente_variable(impresor.tamaniofuentetitulos, False)))
                        End If
                    Case False
                        PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(Ordenprovision.Nombre, PDF_fuente_variable(impresor.tamaniofuentetitulos, False)))
                End Select
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(vbCrLf & "CUIT Nº: ", PDF_fuente_variable(impresor.tamaniofuentetitulos, True)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(Ordenprovision.CUIT, PDF_fuente_variable(impresor.tamaniofuentetitulos, False)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(vbCrLf & "DOMICILIO: ", PDF_fuente_variable(impresor.tamaniofuentetitulos, True)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(Ordenprovision.Domicilio_real, PDF_fuente_variable(impresor.tamaniofuentetitulos, False)))
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOPARCIAL, 0, 1, 1, Element.ALIGN_LEFT, 1, Element.ALIGN_MIDDLE)))
                DatosOrdenprovision.AddCell(PdfpCell_espaciovacioborde)
                PARRAFOPARCIAL.Clear()
                'Sírvase entregar en el término de XX DIAS, conforme lo cotizado en el citado expediente, los árticulos que se detallan a continuación correspondiente a la COMPRA DIRECTA NºXX/XX.
                'Realizada el día XX de XXXXX de 20XX, aprobada por ResDEcreto Nº XX/20XX (fecha)
                Select Case Ordenprovision.fechaobservaciones_ordenprovision.Count > 5
                    Case True
                        PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("Sírvase entregar en el término detallado (**)  ", PDF_fuente_variable(impresor.tamaniofuentetitulos, False)))
                    Case False
                        PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("Sírvase entregar en el término de ", PDF_fuente_variable(impresor.tamaniofuentetitulos, False)))
                        Select Case Ordenprovision.ValorTiempoEntrega
                            Case Is = 1
                                Select Case Ordenprovision.UnidadTiempoEntrega
                                    Case Is = "DÍAS"
                                        Ordenprovision.UnidadTiempoEntrega = "DÍA"
                                    Case Is = "DÍAS HÁBILES"
                                        Ordenprovision.UnidadTiempoEntrega = "DÍA HÁBIL"
                                    Case Is = "SEMANAS"
                                        Ordenprovision.UnidadTiempoEntrega = "SEMANA"
                                    Case Is = "MESES"
                                        Ordenprovision.UnidadTiempoEntrega = "MES"
                                End Select
                            Case Else
                        End Select
                        PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(Ordenprovision.ValorTiempoEntrega & " " & Ordenprovision.UnidadTiempoEntrega & " ", PDF_fuente_variable(impresor.tamaniofuentetitulos, True)))
                End Select
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(", conforme lo cotizado en el citado expediente, los artículos que se detallan a continuación correspondiente a la ", PDF_fuente_variable(impresor.tamaniofuentetitulos, False)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(Ordenprovision.TipoOrigen & " Nº " & Ordenprovision.NumeroOrigen & "/" & Ordenprovision.YearOrigen & vbNewLine, PDF_fuente_variable(impresor.tamaniofuentetitulos, True)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(" Realizada el día ", PDF_fuente_variable(12, False)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(Ordenprovision.fecharealizada_ordenprovision.ToString("dd", CultureInfo.CreateSpecificCulture("es-AR")) & " DE " &
                                                             Ordenprovision.fecharealizada_ordenprovision.ToString("MMMM", CultureInfo.CreateSpecificCulture("es-AR")).ToUpper & " DE " &
                                                             Ordenprovision.fecharealizada_ordenprovision.ToString("yyyy", CultureInfo.CreateSpecificCulture("es-AR")), PDF_fuente_variable(impresor.tamaniofuentetitulos, True)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(", aprobada por ", PDF_fuente_variable(impresor.tamaniofuentetitulos, False)))
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(Ordenprovision.TipoInstrumentoLegal & " Nº " & Ordenprovision.NumeroInstrumentoLegal & "/" & Ordenprovision.YearInstrumentoLegal & "(" & Ordenprovision.FechaInstrumentoLegal.ToShortDateString & ")" & vbNewLine, PDF_fuente_variable(impresor.tamaniofuentetitulos, True)))
                PARRAFOPARCIAL.Alignment = Element.ALIGN_JUSTIFIED
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOPARCIAL, 0, 1, 1, Element.ALIGN_JUSTIFIED, 1, Element.ALIGN_MIDDLE)))
                Tabla_total.AddCell(PdfpCell_espaciovacio)
                'esto vendría a ser el encabezado de todas las hojas del documento
                Dim encabezado As New itsEventscustom
                encabezado.tablaencabezado = Tabla_total
                Doc.SetMargins(Doc.LeftMargin, Doc.RightMargin, Doc.TopMargin + Tabla_total.TotalHeight, Doc.BottomMargin)
                Doc.Open()
                wri.PageEvent = encabezado
                Doc.NewPage()
                'agrego la tabla total para evitar segmentación de página
                '''''''''''''''Doc.Add(Tabla_total)
                ' PARRAFOTOTAL.Add(Tabla_total)
                Tabla_total = New iTextSharp.text.pdf.PdfPTable(1)
                Tabla_total.TotalWidth = Anchopagina - Doc.LeftMargin
                Tabla_total.LockedWidth = True
                tamaniocolumna_total = New Single(0) {}
                tamaniocolumna_total(0) = Convert.ToSingle(Anchopagina - Doc.LeftMargin * 1)
                Tabla_total.SetWidths(tamaniocolumna_total)
                'para lograr la adaptación completa debo disminuir el margen necesario
                Dim anchoutil As Single = Anchopagina - Doc.LeftMargin
                tamaniocolumna = New Single(7) {}
                tamaniocolumna(0) = Convert.ToSingle(anchoutil * 0.04) 'Reng.
                tamaniocolumna(1) = Convert.ToSingle(anchoutil * 0.04) 'Cant
                tamaniocolumna(2) = Convert.ToSingle(anchoutil * 0.1) 'Un.
                tamaniocolumna(3) = Convert.ToSingle(anchoutil * 0.47) ' ARTICULOS
                tamaniocolumna(4) = Convert.ToSingle(anchoutil * 0.1) ' PREC. UNITARIO
                tamaniocolumna(5) = Convert.ToSingle(anchoutil * 0.12) 'PRECIO TOTAL
                tamaniocolumna(6) = Convert.ToSingle(anchoutil * 0.12) 'Observaciones
                tamaniocolumna(7) = Convert.ToSingle(anchoutil * 0.12) 'ENCABEZADO
                Dim TABLAORDENPROVISION As iTextSharp.text.pdf.PdfPTable = PDFDatatable_OP2(
                    Ordenprovision.DATOSORDENPROVISION, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, impresor, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#ffffff")))
                Dim TABLAORDENPROVISION2 As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(TABLAORDENPROVISION.NumberOfColumns)
                TABLAORDENPROVISION2.TotalWidth = TABLAORDENPROVISION.TotalWidth
                TABLAORDENPROVISION2.SetWidths(TABLAORDENPROVISION.AbsoluteWidths)
                TABLAORDENPROVISION2.LockedWidth = True
                Dim Totalsumado As Decimal = 0
                PARRAFOPARCIAL.Clear()
                For X = 0 To Ordenprovision.DATOSORDENPROVISION.Rows.Count - 1
                    Totalsumado += CType(Ordenprovision.DATOSORDENPROVISION.Rows(X).Item(5), Decimal)
                Next
                'TABLAORDENPROVISION.AddCell(PdfpCell_espaciovacioborde)
                'TABLAORDENPROVISION.AddCell(PdfpCell_espaciovacioborde)
                'TABLAORDENPROVISION.AddCell(PdfpCell_espaciovacioborde)
                If Ordenprovision.fechaobservaciones_ordenprovision.Count > 5 Then
                    TABLAORDENPROVISION.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(New iTextSharp.text.Chunk(Ordenprovision.fechaobservaciones_ordenprovision, PDF_fuente_variable(impresor.tamaniofuente + 2, False)), 0.5, 6, 1, iTextSharp.text.Element.ALIGN_JUSTIFIED, 4, Element.ALIGN_TOP)))
                End If
                TABLAORDENPROVISION.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" TOTAL ", PDF_fuente_variable(10, True))), 0.5, 4, 1, iTextSharp.text.Element.ALIGN_RIGHT)))
                TABLAORDENPROVISION.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Totalsumado.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), PDF_fuente_variable(impresor.tamaniofuente + 2, True))), 0.5, 2, 1, Element.ALIGN_CENTER)))
                TABLAORDENPROVISION.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(New iTextSharp.text.Chunk("IMPORTA LA PRESENTE ORDEN DE PROVISIÓN LA SUMA DE PESOS:  " & Inicio.Num2Text(Math.Truncate(Convert.ToDecimal(Totalsumado))) & " CON " &
                ((Convert.ToDecimal(Totalsumado) - Math.Truncate(Convert.ToDecimal(Totalsumado))) * 100).ToString("00") & "/100.-", PDF_fuente_variable(impresor.tamaniofuente + 2, False)), 0.5, 6, 1, Element.ALIGN_RIGHT, 4, Element.ALIGN_TOP)))
                TABLAORDENPROVISION.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(New iTextSharp.text.Chunk("POSADAS," & Ordenprovision.Fechaconfeccionada_ordenprovision.ToString("dd", CultureInfo.CreateSpecificCulture("es-AR")) & " DE " &
                                                                 Ordenprovision.Fechaconfeccionada_ordenprovision.ToString("MMMM", CultureInfo.CreateSpecificCulture("es-AR")).ToUpper & " DE " &
                                                                 Ordenprovision.Fechaconfeccionada_ordenprovision.ToString("yyyy", CultureInfo.CreateSpecificCulture("es-AR")), PDF_fuente_variable(impresor.tamaniofuentetitulos, False)), 0.5, 6, 1, Element.ALIGN_RIGHT, 4, Element.ALIGN_TOP)))
                '   TABLAORDENPROVISION.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Iniciales(Ordenprovision.USUARIO), PDF_fuente_variable(6, True))), 0, 6, 1, iTextSharp.text.Element.ALIGN_LEFT, 0)))
                TABLAORDENPROVISION2.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(New iTextSharp.text.Chunk("IMPORTANTE ", PDF_fuente_variable(impresor.tamaniofuente, True)), 0, 3, 1, 2)))
                TABLAORDENPROVISION2.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(New iTextSharp.text.Chunk(" 1) Esta orden deberá acompañar la correspondiente factura por duplicado para su cobro" & vbNewLine &
           "2) Deberá sellarse según lo establecen disposiciones vigentes con el 10% o (Sellado Provincial)", PDF_fuente_variable(impresor.tamaniofuente, False)), 0, 3, 1, 2)))
                'PARRAFOTOTAL.Add(TABLAORDENPROVISION)
                Doc.Add(PARRAFOTOTAL)
                Doc.Add(TABLAORDENPROVISION)
                Doc.Add(TABLAORDENPROVISION2)
                Doc.Add(TABLA_INICIALES(anchoutil, Ordenprovision.USUARIO))
                PARRAFOPARCIAL.Clear()
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("ORIGINAL", PDF_fuente_variable(impresor.tamaniofuente + 6, True)))
                PARRAFOPARCIAL.Alignment = Element.ALIGN_CENTER
                Doc.Add(PARRAFOPARCIAL)
                Doc.NewPage()
                Doc.Add(PARRAFOTOTAL)
                Doc.Add(TABLAORDENPROVISION)
                Doc.Add(TABLAORDENPROVISION2)
                PARRAFOPARCIAL.Clear()
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("DUPLICADO", PDF_fuente_variable(impresor.tamaniofuente + 6, True)))
                PARRAFOPARCIAL.Alignment = Element.ALIGN_CENTER
                Doc.Add(PARRAFOPARCIAL)
                Doc.NewPage()
                Doc.Add(PARRAFOTOTAL)
                Doc.Add(TABLAORDENPROVISION)
                Doc.Add(TABLAORDENPROVISION2)
                PARRAFOPARCIAL.Clear()
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("TRIPLICADO", PDF_fuente_variable(impresor.tamaniofuente + 6, True)))
                PARRAFOPARCIAL.Alignment = Element.ALIGN_CENTER
                Doc.Add(PARRAFOPARCIAL)
                Doc.NewPage()
                Doc.Add(PARRAFOTOTAL)
                Doc.Add(TABLAORDENPROVISION)
                Doc.Add(TABLAORDENPROVISION2)
                PARRAFOPARCIAL.Clear()
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("CUADRUPLICADO", PDF_fuente_variable(impresor.tamaniofuente + 6, True)))
                PARRAFOPARCIAL.Alignment = Element.ALIGN_CENTER
                Doc.Add(PARRAFOPARCIAL)
                'PARRAFOCOMPLETO.Clear()
                'PARRAFOCOMPLETO.Add(TABLAORDENPROVISION)
                'Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
                'Doc.Add(Tabla_total)
                Doc.Close()
            End Using
            Select Case MsgBox("Abrir el archivo generado?", MsgBoxStyle.YesNoCancel, " ")
                Case MsgBoxResult.Yes
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(Controlguardado.FileName) With {
                                             .UseShellExecute = True
    })
            End Select
        End If
    End Sub

    Public Sub PDF_ORDENPAGO_Pago(ByVal ORDENDEPAGOS As Ordendepago, ByVal Tamaniohoja As String, Optional tamaniodefuente As Single = 12)
        'DATOS DEL DOCUMENTO
        Dim Doc As New Document(PageSize.LEGAL, 40, 20, 20, 20)
        'Dim FileName As String = FileName
        Dim Anchopagina As Single = Doc.PageSize.Width
        Dim Controlguardado As New SaveFileDialog
        With Controlguardado
            Select Case System.IO.Directory.Exists("C:" & "\" & "Ordenes_de_Pago" & "\" & ORDENDEPAGOS.Ordenpago_Year & "\")
                Case True
                Case False
                    System.IO.Directory.CreateDirectory("C:" & "\" & "Ordenes_de_Pago" & "\" & ORDENDEPAGOS.Ordenpago_Year & "\")
            End Select
            .Filter = "ARCHIVO PDF|*.pdf"
            .Title = "Guardar en archivo PDF"
            .FileName = " OP - " & ORDENDEPAGOS.ordenpago_numero & "-" & ORDENDEPAGOS.Ordenpago_Year & ".pdf"
            .RestoreDirectory = True
            .InitialDirectory = "C:" & "\" & "Ordenes_de_Pago" & "\" & ORDENDEPAGOS.Ordenpago_Year & "\"
        End With
        Controlguardado.Filter = "ARCHIVO PDF|*.pdf"
        Controlguardado.Title = "Guardar en archivo PDF"
        Controlguardado.ShowDialog()
        If Controlguardado.FileName = "" Then
            MsgBox("Para poder proceder a la creación del archivo se requiere un nombre")
            Exit Sub
        Else
            Dim FileName As String = Controlguardado.FileName
            'Try
            Using wri = PdfWriter.GetInstance(Doc, New FileStream(FileName, FileMode.Create))
                'Dim ev As New itsEventsNOVALIDOCOMOORDENPAGO
                'ev.NOVALIDO = ORDENDEPAGOS.novalido
                'wri.PageEvent = ev
                'Abrir el documento para el uso
                Doc.Open()
                'Insertar una página en blanco nueva
                Doc.NewPage()
                'ENCABEZADO
                'Crear tabla General para cargar los bordes
                Dim Tabla_total As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(1)
                Tabla_total.TotalWidth = Anchopagina - Doc.LeftMargin
                Tabla_total.LockedWidth = True
                Dim tamaniocolumna_total As Single() = New Single(0) {}
                tamaniocolumna_total(0) = Convert.ToSingle(Anchopagina - Doc.LeftMargin * 1)
                Tabla_total.SetWidths(tamaniocolumna_total)
                'Creación de la celda que manejaria cada uno de los cuadros
                Dim PARRAFOTOTAL As New iTextSharp.text.Paragraph()
                Dim PARRAFOCOMPLETO As New iTextSharp.text.Paragraph()
                Dim PARRAFOPARCIAL As New iTextSharp.text.Paragraph()
                Dim Phrasetemporal As New iTextSharp.text.Phrase()
                'Crear tabla para manejar los encabezados---------------------------------------------------------------------------------------------
                Dim Encabezadosx As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(2)
                Encabezadosx.TotalWidth = Anchopagina - Doc.LeftMargin
                Encabezadosx.LockedWidth = True
                'Declaración variable de ancho de columnas
                Dim tamaniocolumna As Single() = New Single(1) {}
                tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.2)
                tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.8)
                Encabezadosx.SetWidths(tamaniocolumna)
                'para insertar un espacio entre las celdas
                Dim PdfpCell_espaciovacio As iTextSharp.text.pdf.PdfPCell = New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("", PDF_fuente_variable(tamaniodefuente, False))))
                PdfpCell_espaciovacio.BorderWidth = 0
                PdfpCell_espaciovacio.FixedHeight = 5.0F
                Dim PdfpCell_espaciovacioborde As iTextSharp.text.pdf.PdfPCell = New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("", PDF_fuente_variable(tamaniodefuente, False))))
                PdfpCell_espaciovacioborde.BorderWidth = 0.5
                PdfpCell_espaciovacioborde.FixedHeight = 2.0F
                'crear imagen con logo a la izquierda
                Dim manejadorimagen As iTextSharp.text.Image = Image.GetInstance(My.Resources.Logo, System.Drawing.Imaging.ImageFormat.Jpeg)
                'asignar la imagen itextsharp a la celda
                Dim PdfPCell As iTextSharp.text.pdf.PdfPCell = New PdfPCell(manejadorimagen, True)
                PdfPCell.Rowspan = 2
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_LEFT
                PdfPCell.FixedHeight = 70.0F
                Encabezadosx.AddCell(PdfPCell)
                'Encabezado del año
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Encabezadodelyear(ORDENDEPAGOS.ordenpago_fecha.Year), PDF_fuente_variable(8, False))))
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                ' PdfPCell.FixedHeight = 25.0F
                Encabezadosx.AddCell(PdfPCell)
                '----------------------NOMBRE DEL SERVICIO ADMINISTRATIVO------------------------------
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Nombrecompletodelservicio.ToUpper, PDF_fuente_variable(tamaniodefuente + 2, True))))
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.FixedHeight = 25.0F
                Encabezadosx.AddCell(PdfPCell)
                'Encabezadosx.AddCell(PdfpCell_espaciovacioborde)
                With PdfpCell_espaciovacio
                    .FixedHeight = 10.0F
                    .Colspan = Encabezadosx.NumberOfColumns
                End With
                Encabezadosx.AddCell(PdfpCell_espaciovacio)
                '----------------------AGREGA EL ENCABEZADO Completo------------------------------
                ' Frase_total.Clear()
                PARRAFOCOMPLETO.Add(Encabezadosx)
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
                PARRAFOCOMPLETO.Clear()
                'DATOS BÁSICOS ORDEN DE PAGO
                Dim Datosbasicosordenpago As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(4)
                Datosbasicosordenpago.TotalWidth = Anchopagina - Doc.LeftMargin
                Datosbasicosordenpago.LockedWidth = True
                Datosbasicosordenpago.PaddingTop = 5
                tamaniocolumna = New Single(3) {}
                tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.12)
                tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.12)
                tamaniocolumna(2) = Convert.ToSingle(Anchopagina * 0.38)
                tamaniocolumna(3) = Convert.ToSingle(Anchopagina * 0.38)
                Datosbasicosordenpago.SetWidths(tamaniocolumna)
                Datosbasicosordenpago.AddCell(Phrasepdf(" ORDEN DE PAGO ", tamaniodefuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE,, "#c5c7c0"))
                Datosbasicosordenpago.AddCell(Phrasepdf("ORDEN DE PAGO Nº " & ORDENDEPAGOS.ordenpago_numero,
                                                            tamaniodefuente + 6, True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
                'TIPO O TIPOS DE INSTRUMENTO LEGAL
                Dim Tipo_instrumentolegal As New List(Of String)
                Select Case ORDENDEPAGOS.ORDENESPROVISION.Count
                    Case = 0
                        Datosbasicosordenpago.AddCell(Phrasepdf(" ",
                                                                    tamaniodefuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                        Datosbasicosordenpago.AddCell(Phrasepdf(" ",
                                                                    tamaniodefuente, True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
                    Case = 1
                        Datosbasicosordenpago.AddCell(Phrasepdf(ORDENDEPAGOS.ORDENESPROVISION(0).TipoInstrumentoLegal,
                                                                    tamaniodefuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                        Datosbasicosordenpago.AddCell(Phrasepdf(" ", tamaniodefuente,
                                                                    True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
                    Case Else
                        Dim Todostiposlegales As String = ""
                        For X = 0 To ORDENDEPAGOS.ORDENESPROVISION.Count - 1
                            If Not Tipo_instrumentolegal.Contains(ORDENDEPAGOS.ORDENESPROVISION(X).TipoInstrumentoLegal.ToUpper) Then
                                Tipo_instrumentolegal.Add(ORDENDEPAGOS.ORDENESPROVISION(X).TipoInstrumentoLegal.ToUpper)
                                If Tipo_instrumentolegal.Count > 1 Then
                                    Todostiposlegales += "/" & ORDENDEPAGOS.ORDENESPROVISION(X).TipoInstrumentoLegal
                                Else
                                    Todostiposlegales = ORDENDEPAGOS.ORDENESPROVISION(X).TipoInstrumentoLegal
                                End If
                            End If
                        Next
                        If Tipo_instrumentolegal.Count > 1 Then
                            Datosbasicosordenpago.AddCell(Phrasepdf(Todostiposlegales,
                                                                    tamaniodefuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                            Datosbasicosordenpago.AddCell(Phrasepdf(" ", tamaniodefuente,
                                                                    True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
                        Else
                            Datosbasicosordenpago.AddCell(Phrasepdf(ORDENDEPAGOS.ORDENESPROVISION(0).TipoInstrumentoLegal,
                                                                    tamaniodefuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                            Datosbasicosordenpago.AddCell(Phrasepdf(" ", tamaniodefuente,
                                                                    True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
                        End If
                        'For X = 0 To ORDENDEPAGOS.ORDENESPROVISION.Count - 1
                        '    If Not Tipo_instrumentolegal.Contains(ORDENDEPAGOS.ORDENESPROVISION(X).Tipo_instrumentolegal) Then
                        '        Tipo_instrumentolegal.Add(ORDENDEPAGOS.ORDENESPROVISION(X).Tipo_instrumentolegal)
                        '    End If
                        'Next
                        'If Tipo_instrumentolegal.Count > 1 Then
                        '    Datosbasicosordenpago.AddCell(Phrasepdf("* *",
                        '                                            tamaniodefuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                        '    Datosbasicosordenpago.AddCell(Phrasepdf(" ", tamaniodefuente,
                        '                                            True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
                        'Else
                        '    Datosbasicosordenpago.AddCell(Phrasepdf(ORDENDEPAGOS.ORDENESPROVISION(0).Tipo_instrumentolegal,
                        '                                            tamaniodefuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                        '    Datosbasicosordenpago.AddCell(Phrasepdf(" ", tamaniodefuente,
                        '                                            True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
                        'End If
                End Select
                Datosbasicosordenpago.AddCell(Phrasepdf(" AÑO ", tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                Datosbasicosordenpago.AddCell(Phrasepdf(" NÚMERO ", tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                Datosbasicosordenpago.AddCell(Phrasepdf(" ", tamaniodefuente, False, 0, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                'SE EFECTUA UN FORMATO PREVIO PARA MANEJAR LOS CASOS QUE CONTENGAN VARIAS ORDENES DE PROVISION DENTRO DE LA ORDEN DE PAGO..
                Dim numeroinstrumentolegal As New List(Of String)
                Dim anioinstrumentolegal As New List(Of String)
                Dim CONCATENADO As New List(Of String)
                Dim detallenumeroinstrumentolegal As String = ""
                Dim detalleanioinstrumentolegal As String = ""
                Select Case ORDENDEPAGOS.ORDENESPROVISION.Count
                    Case = 0
                        detallenumeroinstrumentolegal = ""
                        detalleanioinstrumentolegal = ""
                            'PdfPCell = New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(tamaniodefuente, True))), 0.5, 2, 1, iTextSharp.text.Element.ALIGN_CENTER, 0))
                    Case = 1
                        detallenumeroinstrumentolegal = ORDENDEPAGOS.ORDENESPROVISION(0).NumeroInstrumentoLegal
                        detalleanioinstrumentolegal = ORDENDEPAGOS.ORDENESPROVISION(0).YearInstrumentoLegal
                        'PdfPCell = New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(ORDENDEPAGOS.ORDENESPROVISION(0).Numero_instrumentolegal, PDF_fuente_variable(tamaniodefuente, False))), 0.5, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0))
                    Case Else
                        For Each op As OrdenProvision In ORDENDEPAGOS.ORDENESPROVISION
                            If Not (CONCATENADO.Contains(op.NumeroInstrumentoLegal & "/" & op.YearInstrumentoLegal)) Then
                                numeroinstrumentolegal.Add(op.NumeroInstrumentoLegal)
                                anioinstrumentolegal.Add(op.YearInstrumentoLegal)
                                CONCATENADO.Add(op.NumeroInstrumentoLegal & "/" & op.YearInstrumentoLegal)
                            End If
                        Next
                        For z = 0 To numeroinstrumentolegal.Count - 1
                            If z = numeroinstrumentolegal.Count - 1 Then
                                detallenumeroinstrumentolegal += numeroinstrumentolegal(z)
                                detalleanioinstrumentolegal += anioinstrumentolegal(z)
                            Else
                                detallenumeroinstrumentolegal += numeroinstrumentolegal(z) & vbCrLf
                                detalleanioinstrumentolegal += anioinstrumentolegal(z) & vbCrLf
                            End If
                        Next
                End Select
                PdfPCell = New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(detalleanioinstrumentolegal, PDF_fuente_variable(tamaniodefuente, False))), 0.5, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0))
                Datosbasicosordenpago.AddCell(PdfPCell)
                PdfPCell = New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(detallenumeroinstrumentolegal, PDF_fuente_variable(tamaniodefuente, False))), 0.5, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0))
                Datosbasicosordenpago.AddCell(PdfPCell)
                PdfPCell = New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(10, False))), 0, 2, 1, iTextSharp.text.Element.ALIGN_CENTER, 0))
                Datosbasicosordenpago.AddCell(PdfPCell)
                PdfPCell = New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(10, False))), 0, 4, 1, iTextSharp.text.Element.ALIGN_CENTER, 0))
                Datosbasicosordenpago.AddCell(PdfPCell)
                'Datosbasicosordenpago.AddCell(PdfpCell_espaciovacio)
                Datosbasicosordenpago.AddCell(Phrasepdf(" EXPEDIENTE ", tamaniodefuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE,, "#c5c7c0"))
                Datosbasicosordenpago.AddCell(Phrasepdf("POSADAS, " & ORDENDEPAGOS.ordenpago_fecha.ToShortDateString, tamaniodefuente + 2, False, 0, 2, 3, Element.ALIGN_CENTER, 4, Element.ALIGN_MIDDLE))
                Datosbasicosordenpago.AddCell(Phrasepdf("LETRA", tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                Datosbasicosordenpago.AddCell(Phrasepdf("NÚMERO", tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                ''LETRA
                'Datosbasicosordenpago.AddCell(Phrasepdf(ORDENDEPAGOS.expediente_op.organismo.ToString, tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 4, Element.ALIGN_MIDDLE))
                ''NUMERO
                'PdfPCell = New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(ORDENDEPAGOS.expediente_op.numero & "-" & ORDENDEPAGOS.expediente_op.year, PDF_fuente_variable(tamaniodefuente, False))), 0.5, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0))
                'Datosbasicosordenpago.AddCell(PdfPCell)
                'NUMERO DE EXPEDIENTE
                Datosbasicosordenpago.AddCell(Phrasepdf(ORDENDEPAGOS.expediente_op.organismo.ToString, tamaniodefuente + 1, True, 0.5, 1, 1, Element.ALIGN_CENTER, 4, Element.ALIGN_MIDDLE))
                Datosbasicosordenpago.AddCell(Phrasepdf(ORDENDEPAGOS.expediente_op.numero & "-" & ORDENDEPAGOS.expediente_op.year, tamaniodefuente + 1, True, 0.5, 1, 1, Element.ALIGN_CENTER, 4, Element.ALIGN_MIDDLE))
                'EXPEDIENTE PRINCIPAL
                If ORDENDEPAGOS.ClaveExpediente_principal.ToString.Length = 13 Then
                    Datosbasicosordenpago.AddCell(Phrasepdf(" Autorizado por: ", tamaniodefuente, False, 0.5, 2, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE))
                    Datosbasicosordenpago.AddCell(Phrasepdf(" ", tamaniodefuente + 2, False, 0, 2, 3, Element.ALIGN_CENTER, 4, Element.ALIGN_MIDDLE))
                    Datosbasicosordenpago.AddCell(Phrasepdf(ORDENDEPAGOS.ClaveExpediente_principal.ToString.Substring(4, 4) & "-" &
                                                     Convert.ToInt32(ORDENDEPAGOS.ClaveExpediente_principal.ToString.Substring(8, 5)) & "/" &
                                                    ORDENDEPAGOS.ClaveExpediente_principal.ToString.Substring(0, 4), tamaniodefuente, False, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                Else
                    Datosbasicosordenpago.AddCell(Phrasepdf("  ", tamaniodefuente, True, 0, 2, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE))
                    Datosbasicosordenpago.AddCell(Phrasepdf(" ", tamaniodefuente + 2, False, 0, 2, 3, Element.ALIGN_CENTER, 4, Element.ALIGN_MIDDLE))
                    Datosbasicosordenpago.AddCell(Phrasepdf(" ", tamaniodefuente, False, 0, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                End If
                PARRAFOCOMPLETO.Add(Datosbasicosordenpago)
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
                'TEXTO DATOS BÁSICOS ORDEN DE PAGO
                PARRAFOPARCIAL.Clear()
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("De acuerdo con la orden precedente se liquida para ser abonado por la Tesorería del " &
                                                                 Autorizaciones.Nombrecompletodelservicio &
                                                                 " a favor de: ", PDF_fuente_variable(tamaniodefuente + 1, False)))
                Dim LISTADECUITS As New List(Of String)
                Select Case ORDENDEPAGOS.ORDENESPROVISION.Count
                    Case = 0
                        PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("           " & vbCrLf, PDF_fuente_variable(tamaniodefuente + 2, True)))
                    Case = 1
                        PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(ORDENDEPAGOS.ORDENESPROVISION(0).Nombre & vbCrLf, PDF_fuente_variable(tamaniodefuente + 2, True)))
                    Case Else
                        For X = 0 To ORDENDEPAGOS.ORDENESPROVISION.Count - 1
                            If Not LISTADECUITS.Contains(ORDENDEPAGOS.ORDENESPROVISION(X).Nombre) Then
                                LISTADECUITS.Add(ORDENDEPAGOS.ORDENESPROVISION(X).Nombre)
                            End If
                        Next
                        If LISTADECUITS.Count > 1 Then
                            PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("Varios Beneficiarios " & vbCrLf, PDF_fuente_variable(tamaniodefuente + 2, True)))
                        Else
                            PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(ORDENDEPAGOS.ORDENESPROVISION(0).Nombre & vbCrLf, PDF_fuente_variable(tamaniodefuente + 2, True)))
                        End If
                End Select
                'CONCEPTO DE'
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("A su orden en concepto de:", PDF_fuente_variable(tamaniodefuente + 2, False)))
                'TIPO DE ORDEN DE PAGO
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(ORDENDEPAGOS.Ordenpago_tipo, PDF_fuente_variable(tamaniodefuente + 2, True)))
                PARRAFOPARCIAL.FirstLineIndent = tamaniocolumna(0) + tamaniocolumna(1)
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOPARCIAL, 0, 1, 1, 0, 3)))
                With PdfpCell_espaciovacio
                    .FixedHeight = 10.0F
                    .Colspan = Tabla_total.NumberOfColumns
                End With
                Tabla_total.AddCell(PdfpCell_espaciovacio)
                'CUADRO DETALLE
                Dim textoprimercuadro As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(6)
                textoprimercuadro.TotalWidth = Anchopagina - Doc.LeftMargin
                textoprimercuadro.LockedWidth = True
                tamaniocolumna = New Single(5) {}
                tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.16)
                tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.16)
                tamaniocolumna(2) = Convert.ToSingle(Anchopagina * 0.16)
                tamaniocolumna(3) = Convert.ToSingle(Anchopagina * 0.16)
                tamaniocolumna(4) = Convert.ToSingle(Anchopagina * 0.16)
                tamaniocolumna(5) = Convert.ToSingle(Anchopagina * 0.18)
                textoprimercuadro.SetWidths(tamaniocolumna)
                'textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(textodetalle, PDF_fuente_variable(tamaniodefuente, False))), 0, 4, 1, iTextSharp.text.Element.ALIGN_JUSTIFIED)))
                textoprimercuadro.AddCell(Phrasepdf(ORDENDEPAGOS.ordenpago_Detalle, tamaniodefuente, False, 0, 6, 1, Element.ALIGN_JUSTIFIED, 3,, 50))
                'DETERMINAR QUE CAMPOS ESTAN COMPLETADOS
                '************************************************************** REFACTORIZAR*****************************************************************************************
                Dim TIENE_EFECTOR As Boolean = False
                Dim TIENE_PERIODO As Boolean = False
                Dim TIENE_DETALLE As Boolean = False
                Dim TIENE_ANTICIPO As Boolean = False
                Dim SUBTOTAL As Decimal = 0
                If ORDENDEPAGOS.ACTAS.Count > 0 Then
                    For Each ACTA In ORDENDEPAGOS.ACTAS
                        If ACTA.ACTARECEPCION_ANTICIPO > 0 Then
                            TIENE_ANTICIPO = True
                        End If
                        If ACTA.ACTARECEPCION_DETALLE.Length > 0 Then
                            TIENE_DETALLE = True
                        End If
                        If ACTA.ACTARECEPCION_EFECTOR.Length > 0 Then
                            TIENE_EFECTOR = True
                        End If
                        If ACTA.ACTARECEPCION_PERIODO.Length > 0 Then
                            TIENE_PERIODO = True
                        End If
                        SUBTOTAL += ACTA.ACTARECEPCION_MONTO + ACTA.ACTARECEPCION_MULTA_MONTO
                    Next
                    If TIENE_ANTICIPO Then
                        textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("O. PROV.", PDF_fuente_variable(tamaniodefuente - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                        textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("ACTA RECEPCION Nº", PDF_fuente_variable(tamaniodefuente, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                        textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("ANTICIPO", PDF_fuente_variable(tamaniodefuente, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                        textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("IMPORTE", PDF_fuente_variable(tamaniodefuente, True))), 0, 2, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                        textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("SALDO A PAGAR", PDF_fuente_variable(tamaniodefuente, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                        For Each ACTAD In ORDENDEPAGOS.ACTAS
                            textoprimercuadro.AddCell(Phrasepdf(
                                                          CType(ACTAD.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(8, 5), Integer) &
                                                          "/" &
                                                          ACTAD.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(0, 4),
                                                          tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 1))
                            textoprimercuadro.AddCell(Phrasepdf(ACTAD.ACTARECEPCION_NUMERO & "/" & ACTAD.ACTARECEPCION_YEAR, tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
                            textoprimercuadro.AddCell(Phrasepdf(ACTAD.ACTARECEPCION_ANTICIPO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
                            textoprimercuadro.AddCell(Phrasepdf(ACTAD.ACTARECEPCION_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, False, 0, 2, 1, Element.ALIGN_CENTER, 2))
                            textoprimercuadro.AddCell(Phrasepdf((ACTAD.ACTARECEPCION_MONTO - ACTAD.ACTARECEPCION_ANTICIPO).ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
                            'Select Case ACTAD.ACTARECEPCION_MULTA_MONTO <> 0
                            '    Case True
                            '        textoprimercuadro.AddCell(Phrasepdf(" ", tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
                            '        textoprimercuadro.AddCell(Phrasepdf(ACTAD.ACTARECEPCION_MULTA_RESOLUCION, tamaniodefuente, False, 0, 2, 1, Element.ALIGN_CENTER, 0))
                            '        textoprimercuadro.AddCell(Phrasepdf(ACTAD.ACTARECEPCION_MULTA_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, False, 0, 3, 1, Element.ALIGN_CENTER, 2))
                            '    Case False
                            'End Select
                        Next
                    Else
                        If TIENE_DETALLE And TIENE_EFECTOR And TIENE_PERIODO Then
                            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("EFECTOR", PDF_fuente_variable(tamaniodefuente - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("PERIODO", PDF_fuente_variable(tamaniodefuente - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("O. PROV.", PDF_fuente_variable(tamaniodefuente - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("ACTA RECEPCION Nº", PDF_fuente_variable(tamaniodefuente - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("DETALLE", PDF_fuente_variable(tamaniodefuente - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("IMPORTE", PDF_fuente_variable(tamaniodefuente - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                            For Each ACTAS In ORDENDEPAGOS.ACTAS
                                textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_EFECTOR, tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
                                textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_PERIODO, tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
                                textoprimercuadro.AddCell(Phrasepdf(
                                                          CType(ACTAS.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(8, 5), Integer) &
                                                          "/" &
                                                          ACTAS.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(0, 4),
                                                          tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 1))
                                textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_NUMERO & "/" & ACTAS.ACTARECEPCION_YEAR, tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
                                textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_DETALLE, tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 1))
                                textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
                                Select Case ACTAS.ACTARECEPCION_MULTA_MONTO <> 0
                                    Case True
                                        textoprimercuadro.AddCell(Phrasepdf(" ", tamaniodefuente, False, 0, 4, 1, Element.ALIGN_CENTER, 0))
                                        textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MULTA_RESOLUCION, tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
                                        textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MULTA_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
                                    Case False
                                End Select
                            Next
                        ElseIf TIENE_DETALLE And TIENE_EFECTOR Then
                            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("EFECTOR", PDF_fuente_variable(tamaniodefuente, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("O. PROV.", PDF_fuente_variable(tamaniodefuente, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("ACTA RECEPCION Nº", PDF_fuente_variable(tamaniodefuente, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("DETALLE", PDF_fuente_variable(tamaniodefuente, True))), 0, 2, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("IMPORTE", PDF_fuente_variable(tamaniodefuente, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                            For Each ACTAS In ORDENDEPAGOS.ACTAS
                                textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_EFECTOR, tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
                                textoprimercuadro.AddCell(Phrasepdf(
                                                          CType(ACTAS.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(8, 5), Integer) &
                                                          "/" &
                                                          ACTAS.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(0, 4),
                                                          tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 1))
                                textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_NUMERO & "/" & ACTAS.ACTARECEPCION_YEAR, tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
                                textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_DETALLE, tamaniodefuente, False, 0, 2, 1, Element.ALIGN_CENTER, 1))
                                textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
                                Select Case ACTAS.ACTARECEPCION_MULTA_MONTO <> 0
                                    Case True
                                        textoprimercuadro.AddCell(Phrasepdf(" ", tamaniodefuente, False, 0, 3, 1, Element.ALIGN_CENTER, 0))
                                        textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MULTA_RESOLUCION, tamaniodefuente, False, 0, 2, 1, Element.ALIGN_CENTER, 0))
                                        textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MULTA_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
                                    Case False
                                End Select
                            Next
                        ElseIf TIENE_DETALLE And TIENE_PERIODO Then
                            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("O. PROV.", PDF_fuente_variable(tamaniodefuente - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("PERIODO", PDF_fuente_variable(tamaniodefuente, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("ACTA RECEPCION Nº", PDF_fuente_variable(tamaniodefuente, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("DETALLE", PDF_fuente_variable(tamaniodefuente, True))), 0, 2, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("IMPORTE", PDF_fuente_variable(tamaniodefuente, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                            For Each ACTAS In ORDENDEPAGOS.ACTAS
                                textoprimercuadro.AddCell(Phrasepdf(
                                                              CType(ACTAS.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(8, 5), Integer) &
                                                              "/" &
                                                              ACTAS.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(0, 4),
                                                              tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 1))
                                textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_PERIODO, tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
                                textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_NUMERO & "/" & ACTAS.ACTARECEPCION_YEAR, tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
                                textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_DETALLE, tamaniodefuente, False, 0, 2, 1, Element.ALIGN_CENTER, 1))
                                textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
                                Select Case ACTAS.ACTARECEPCION_MULTA_MONTO <> 0
                                    Case True
                                        textoprimercuadro.AddCell(Phrasepdf(" ", tamaniodefuente, False, 0, 2, 1, Element.ALIGN_CENTER, 0))
                                        textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MULTA_RESOLUCION, tamaniodefuente, False, 0, 3, 1, Element.ALIGN_CENTER, 0))
                                        textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MULTA_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
                                    Case False
                                End Select
                            Next
                        ElseIf TIENE_DETALLE Then
                            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("O. PROV.", PDF_fuente_variable(tamaniodefuente - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("ACTA RECEPCION Nº", PDF_fuente_variable(tamaniodefuente, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("DETALLE", PDF_fuente_variable(tamaniodefuente, True))), 0, 3, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("IMPORTE", PDF_fuente_variable(tamaniodefuente, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                            For Each ACTAS In ORDENDEPAGOS.ACTAS
                                textoprimercuadro.AddCell(Phrasepdf(
                                                          CType(ACTAS.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(8, 5), Integer) &
                                                          "/" &
                                                          ACTAS.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(0, 4),
                                                          tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 1))
                                textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_NUMERO & "/" & ACTAS.ACTARECEPCION_YEAR, tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
                                textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_DETALLE, tamaniodefuente, False, 0, 3, 1, Element.ALIGN_CENTER, 0))
                                textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
                                Select Case ACTAS.ACTARECEPCION_MULTA_MONTO <> 0
                                    Case True
                                        textoprimercuadro.AddCell(Phrasepdf(" ", tamaniodefuente, False, 0, 2, 1, Element.ALIGN_CENTER, 0))
                                        textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MULTA_RESOLUCION, tamaniodefuente, False, 0, 3, 1, Element.ALIGN_CENTER, 0))
                                        textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MULTA_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
                                    Case False
                                End Select
                            Next
                        Else
                            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("O. PROV.", PDF_fuente_variable(tamaniodefuente - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("ACTA RECEPCION Nº", PDF_fuente_variable(tamaniodefuente, True))), 0, 2, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("IMPORTE", PDF_fuente_variable(tamaniodefuente, True))), 0, 3, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                            For Each ACTAD In ORDENDEPAGOS.ACTAS
                                textoprimercuadro.AddCell(Phrasepdf(
                                                              CType(ACTAD.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(8, 5), Integer) &
                                                              "/" &
                                                              ACTAD.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(0, 4),
                                                              tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 1))
                                textoprimercuadro.AddCell(Phrasepdf(ACTAD.ACTARECEPCION_NUMERO & "/" & ACTAD.ACTARECEPCION_YEAR, tamaniodefuente, False, 0, 2, 1, Element.ALIGN_CENTER, 0))
                                textoprimercuadro.AddCell(Phrasepdf(ACTAD.ACTARECEPCION_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, False, 0, 3, 1, Element.ALIGN_CENTER, 2))
                                Select Case ACTAD.ACTARECEPCION_MULTA_MONTO <> 0
                                    Case True
                                        textoprimercuadro.AddCell(Phrasepdf(" ", tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
                                        textoprimercuadro.AddCell(Phrasepdf(ACTAD.ACTARECEPCION_MULTA_RESOLUCION, tamaniodefuente, False, 0, 2, 1, Element.ALIGN_CENTER, 0))
                                        textoprimercuadro.AddCell(Phrasepdf(ACTAD.ACTARECEPCION_MULTA_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, False, 0, 3, 1, Element.ALIGN_CENTER, 2))
                                    Case False
                                End Select
                            Next
                        End If
                        If ORDENDEPAGOS.ACTAS.Count > 1 Then
                            With PdfpCell_espaciovacio
                                .FixedHeight = 10.0F
                                .Colspan = textoprimercuadro.NumberOfColumns - 2
                            End With
                            textoprimercuadro.AddCell(PdfpCell_espaciovacio)
                            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(tamaniodefuente, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER)))
                            With textoprimercuadro.AddCell(Phrasepdf(SUBTOTAL.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 1))
                                .Border = PdfPCell.TOP_BORDER
                                .BorderWidth = 0.5
                                .PaddingTop = 2
                            End With
                        End If
                    End If
                End If
                If ORDENDEPAGOS.ordenpago_Detalle2.Length > 0 Then
                    textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Observaciones:" & ORDENDEPAGOS.ordenpago_Detalle2, PDF_fuente_variable(tamaniodefuente, False))), 0, textoprimercuadro.NumberOfColumns, 1, iTextSharp.text.Element.ALIGN_CENTER)))
                End If
                '************************************************************** REFACTORIZAR*****************************************************************************************
                With PdfpCell_espaciovacio
                    .FixedHeight = 10.0F
                    .Colspan = textoprimercuadro.NumberOfColumns
                End With
                textoprimercuadro.AddCell(PdfpCell_espaciovacio)
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(textoprimercuadro, 0.5)))
                Dim Totalsumado As Decimal = 0
                'SUMA TOTAL DE PEDIDO DE FONDO Y TEXTO
                For X = 0 To ORDENDEPAGOS.DatosOrdenPago.Rows.Count - 1
                    Totalsumado += CType(ORDENDEPAGOS.DatosOrdenPago.Rows(X).Item(11), Decimal)
                Next
                Tabla_total.AddCell(Phrasepdf(" La suma de Pesos " & Totalsumado.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")) & ".-", tamaniodefuente, True, 0, 1, 1, Element.ALIGN_JUSTIFIED, 2, Element.ALIGN_MIDDLE, 200))
                Tabla_total.AddCell(Phrasepdf("Son Pesos:  " & Inicio.Num2Text(Math.Truncate(Convert.ToDecimal(Totalsumado))) & " CON " &
                    ((Convert.ToDecimal(Totalsumado) - Math.Truncate(Convert.ToDecimal(Totalsumado))) * 100).ToString("00") & "/100.-", tamaniodefuente, False, 0, 11, 1, Element.ALIGN_JUSTIFIED, 2, Element.ALIGN_MIDDLE))
                Tabla_total.AddCell(Phrasepdf(" QUE SE IMPUTARAN DE LA SIGUIENTE MANERA: CUENTA " & CUENTA_PDF(ORDENDEPAGOS.DatosOrdenPago.Rows(0).Item(2)), tamaniodefuente, True, 0, 1, 1, Element.ALIGN_LEFT, 2, Element.ALIGN_MIDDLE, 0))
                'TABLA DE PARTIDAS PRESUPUESTARIAS
                'para lograr la adaptación completa debo disminuir el margen necesario
                Dim anchoutil As Single = Anchopagina - Doc.LeftMargin
                tamaniocolumna = New Single(11) {}
                tamaniocolumna(0) = Convert.ToSingle(anchoutil * 0.05) 'jur.1
                tamaniocolumna(1) = Convert.ToSingle(anchoutil * 0.05) 'UO1
                tamaniocolumna(2) = Convert.ToSingle(anchoutil * 0.0843) 'CARAC
                tamaniocolumna(3) = Convert.ToSingle(anchoutil * 0.0581) ' FIN
                tamaniocolumna(4) = Convert.ToSingle(anchoutil * 0.0581) ' FUN.
                tamaniocolumna(5) = Convert.ToSingle(anchoutil * 0.0681) 'SECC
                tamaniocolumna(6) = Convert.ToSingle(anchoutil * 0.0681) 'SECT
                tamaniocolumna(7) = Convert.ToSingle(anchoutil * 0.0891) ' PDA PCIAL
                tamaniocolumna(8) = Convert.ToSingle(anchoutil * 0.0681) ' PDA PPAL
                tamaniocolumna(9) = Convert.ToSingle(anchoutil * 0.0881) 'PDA SUB PAR
                tamaniocolumna(10) = Convert.ToSingle(anchoutil * 0.0681) 'SCD
                tamaniocolumna(11) = Convert.ToSingle(anchoutil * 0.22) 'IMPORTE
                Dim TABLAORDENDEPAGO As iTextSharp.text.pdf.PdfPTable = PDFDatatable(ORDENDEPAGOS.DatosOrdenPago, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#ffffff")), tamaniodefuente + 1)
                'VISTO LA LIQUIDACIÓN, ORDEN DE PAGO
                Doc.Add(Tabla_total)
                '     Doc.Add(PARRAFOPARCIAL)
                TABLAORDENDEPAGO.SpacingAfter = 1
                Doc.Add(TABLAORDENDEPAGO)
                'Dim COLUMNA As New ColumnText(wri.DirectContent)
                'the Phrase
                'the lower left x corner (left)
                'the lower left y corner (bottom)
                'the upper right x corner (right)
                'the upper right y corner (top)
                'line height(leading)
                'alignment.
                Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.GRAY)
                TABLAORDENDEPAGO = New PdfPTable(10)
                tamaniocolumna = New Single(9) {}
                For x = 0 To 9
                    tamaniocolumna(x) = Convert.ToSingle(anchoutil * 0.1)
                Next
                TABLAORDENDEPAGO.TotalWidth = anchoutil
                TABLAORDENDEPAGO.SetWidths(tamaniocolumna)
                TABLAORDENDEPAGO.LockedWidth = True
                TABLAORDENDEPAGO.AddCell(Phrasepdf(Iniciales(ORDENDEPAGOS.ordenpago_USUARIO), 6, True, 0, 1, 1, Element.ALIGN_LEFT, 0, Element.ALIGN_TOP))
                Doc.Add(TABLAORDENDEPAGO)
                '  Dim TABLAINICIALES As iTextSharp.text.pdf.PdfPTable = PDFDatatable(New DataTable, tamaniocolumna, 1, Anchopagina - Doc.LeftMargin, False, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#ffffff")), 8)
                Doc.Add(TABLA_INICIALES(anchoutil, ORDENDEPAGOS.ordenpago_USUARIO))
                Dim LISTADETEXTO As New List(Of Chunk)
                PARRAFOCOMPLETO.Clear()
                LISTADETEXTO.Add(New Chunk("VISTO: ", PDF_fuente_variable(tamaniodefuente, True)))
                LISTADETEXTO.Add(New Chunk("La liquidación que antecede, téngase por ", PDF_fuente_variable(tamaniodefuente, False)))
                LISTADETEXTO.Add(New Chunk("ORDEN de  PAGO ", PDF_fuente_variable(tamaniodefuente, True)))
                LISTADETEXTO.Add(New Chunk("y abónese de conformidad a la misma. Gírese a la Tesorería para su cumplimiento.", PDF_fuente_variable(tamaniodefuente, False)))
                For Each ITEM As Chunk In LISTADETEXTO
                    PARRAFOCOMPLETO.Add(ITEM)
                Next
                PARRAFOCOMPLETO.Alignment = Element.ALIGN_JUSTIFIED
                Doc.Add(PARRAFOCOMPLETO)
                If Not ORDENDEPAGOS.novalido Then
                    PARRAFOCOMPLETO.Clear()
                    With PARRAFOCOMPLETO
                        .Add(PDFFIRMAS(Anchopagina - Doc.LeftMargin, "CONTABILIDAD", "Director",, 85))
                        .Add(PDFFIRMAS(Anchopagina - Doc.LeftMargin, "DELEGADO FISCAL", "",, 85))
                    End With
                    Doc.Add(PARRAFOCOMPLETO)
                Else
                    'Dim PRUEBA As PdfStamper = Nothing
                    'PRUEBA.AddSignature("PRUEBA",
                    '                    1, Doc.Left, Doc.Bottom, Doc.Right, 55)
                    'With PRUEBA
                    '    .
                    'End With
                    Dim COLUMNA0 As New ColumnText(wri.DirectContent)
                    'the Phrase
                    'the lower left x corner (left)
                    'the lower left y corner (bottom)
                    'the upper right x corner (right)
                    'the upper right y corner (top)
                    'line height(leading)
                    'alignment.
                    COLUMNA0.SetSimpleColumn(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("NO VALIDO COMO ORDEN DE PAGO", PDF_fuente_variable(25, True))),
                                            Doc.Left, Doc.Bottom,
                                          Doc.Right, Doc.PageSize.Height / 3,
                                            15, Element.ALIGN_JUSTIFIED_ALL)
                    COLUMNA0.Go()
                End If
                TABLAORDENDEPAGO = New PdfPTable(10)
                tamaniocolumna = New Single(9) {}
                For x = 0 To 9
                    tamaniocolumna(x) = Convert.ToSingle(anchoutil * 0.1)
                Next
                TABLAORDENDEPAGO.TotalWidth = anchoutil
                TABLAORDENDEPAGO.SetWidths(tamaniocolumna)
                TABLAORDENDEPAGO.LockedWidth = True
                TABLAORDENDEPAGO.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(ORDENDEPAGOS.CLASE_FONDO, PDF_fuente_variable(tamaniodefuente + 4, True))), 0, 10, 1, iTextSharp.text.Element.ALIGN_RIGHT, 0)))
                Doc.Add(TABLAORDENDEPAGO)
                Dim COLUMNA2 As New ColumnText(wri.DirectContent)
                'the Phrase
                'the lower left x corner (left)
                'the lower left y corner (bottom)
                'the upper right x corner (right)
                'the upper right y corner (top)
                'line height(leading)
                'alignment.
                COLUMNA2.SetSimpleColumn(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("SICyF", font12Bold)),
                                        Doc.Left, Doc.Bottom,
                                      Doc.Right, 0,
                                        15, Element.ALIGN_RIGHT)
                COLUMNA2.Go()
                Doc.Close()
            End Using
            Select Case MsgBox("Abrir el archivo generado?", MsgBoxStyle.YesNoCancel, " ")
                Case MsgBoxResult.Yes
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(Controlguardado.FileName) With {
                                                 .UseShellExecute = True
        })
            End Select
            'Catch ex As Exception
            '    MessageBox.Show("NO SE PUDO GENERAR EL ARCHIVO" & vbCrLf & ex.Message)
            'End Try
        End If
    End Sub

    'Public Sub PDF_ORDENPAGO_MULTIPLE(ByVal ORDENDEPAGOS As Ordendepago, ByVal Tamaniohoja As String, Optional tamaniodefuente As Single = 12)
    '    'DATOS DEL DOCUMENTO
    '    Dim Doc As New Document(PageSize.LEGAL, 40, 20, 20, 20)
    '    'Dim FileName As String = FileName
    '    Dim Anchopagina As Single = Doc.PageSize.Width
    '    Dim Controlguardado As New SaveFileDialog
    '    With Controlguardado
    '        Select Case System.IO.Directory.Exists("C:" & "\" & "Ordenes_de_Pago" & "\" & ORDENDEPAGOS.Ordenpago_Year & "\")
    '            Case True
    '            Case False
    '                System.IO.Directory.CreateDirectory("C:" & "\" & "Ordenes_de_Pago" & "\" & ORDENDEPAGOS.Ordenpago_Year & "\")
    '        End Select
    '        .Filter = "ARCHIVO PDF|*.pdf"
    '        .Title = "Guardar en archivo PDF"
    '        .FileName = " OP - " & ORDENDEPAGOS.ordenpago_numero & "-" & ORDENDEPAGOS.Ordenpago_Year & "-" & ORDENDEPAGOS.Ordenpago_tipo & ".pdf"
    '        .RestoreDirectory = True
    '        .InitialDirectory = "C:" & "\" & "Ordenes_de_Pago" & "\" & ORDENDEPAGOS.Ordenpago_Year & "\"
    '    End With
    '    Controlguardado.Filter = "ARCHIVO PDF|*.pdf"
    '    Controlguardado.Title = "Guardar en archivo PDF"
    '    Controlguardado.ShowDialog()
    '    If Controlguardado.FileName = "" Then
    '        MsgBox("Para poder proceder a la creación del archivo se requiere un nombre")
    '        Exit Sub
    '    Else
    '        Dim FileName As String = Controlguardado.FileName
    '        'Try
    '        Using wri = PdfWriter.GetInstance(Doc, New FileStream(FileName, FileMode.Create))
    '            'Dim ev As New itsEvents2
    '            'wri.PageEvent = ev
    '            'Abrir el documento para el uso
    '            Doc.Open()
    '            'Insertar una página en blanco nueva
    '            Doc.NewPage()
    '            'ENCABEZADO
    '            'Crear tabla General para cargar los bordes
    '            Dim Tabla_total As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(1)
    '            Tabla_total.TotalWidth = Anchopagina - Doc.LeftMargin
    '            Tabla_total.LockedWidth = True
    '            Dim tamaniocolumna_total As Single() = New Single(0) {}
    '            tamaniocolumna_total(0) = Convert.ToSingle(Anchopagina - Doc.LeftMargin * 1)
    '            Tabla_total.SetWidths(tamaniocolumna_total)
    '            'Creación de la celda que manejaria cada uno de los cuadros
    '            Dim PARRAFOTOTAL As New iTextSharp.text.Paragraph()
    '            Dim PARRAFOCOMPLETO As New iTextSharp.text.Paragraph()
    '            Dim PARRAFOPARCIAL As New iTextSharp.text.Paragraph()
    '            Dim Phrasetemporal As New iTextSharp.text.Phrase()
    '            'Crear tabla para manejar los encabezados---------------------------------------------------------------------------------------------
    '            Dim Encabezadosx As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(2)
    '            Encabezadosx.TotalWidth = Anchopagina - Doc.LeftMargin
    '            Encabezadosx.LockedWidth = True
    '            'Declaración variable de ancho de columnas
    '            Dim tamaniocolumna As Single() = New Single(1) {}
    '            tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.2)
    '            tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.8)
    '            Encabezadosx.SetWidths(tamaniocolumna)
    '            'para insertar un espacio entre las celdas
    '            Dim PdfpCell_espaciovacio As iTextSharp.text.pdf.PdfPCell = New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("", PDF_fuente_variable(tamaniodefuente, False))))
    '            PdfpCell_espaciovacio.BorderWidth = 0
    '            PdfpCell_espaciovacio.FixedHeight = 5.0F
    '            Dim PdfpCell_espaciovacioborde As iTextSharp.text.pdf.PdfPCell = New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("", PDF_fuente_variable(tamaniodefuente, False))))
    '            PdfpCell_espaciovacioborde.BorderWidth = 0.5
    '            PdfpCell_espaciovacioborde.FixedHeight = 2.0F
    '            'crear imagen con logo a la izquierda
    '            Dim manejadorimagen As iTextSharp.text.Image = Image.GetInstance(My.Resources.Logo, System.Drawing.Imaging.ImageFormat.Jpeg)
    '            'asignar la imagen itextsharp a la celda
    '            Dim PdfPCell As iTextSharp.text.pdf.PdfPCell = New PdfPCell(manejadorimagen, True)
    '            PdfPCell.Rowspan = 2
    '            PdfPCell.BorderWidth = 0
    '            PdfPCell.HorizontalAlignment = Element.ALIGN_LEFT
    '            PdfPCell.FixedHeight = 70.0F
    '            Encabezadosx.AddCell(PdfPCell)
    '            'Encabezado del año
    '            PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Encabezadodelyear(ORDENDEPAGOS.ordenpago_fecha.Year), PDF_fuente_variable(tamaniodefuente, False))))
    '            PdfPCell.BorderWidth = 0
    '            PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
    '            PdfPCell.FixedHeight = 25.0F
    '            Encabezadosx.AddCell(PdfPCell)
    '            '----------------------NOMBRE DEL SERVICIO ADMINISTRATIVO------------------------------
    '            PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Nombrecompletodelservicio.ToUpper, PDF_fuente_variable(tamaniodefuente + 2, True))))
    '            PdfPCell.BorderWidth = 0
    '            PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
    '            PdfPCell.FixedHeight = 25.0F
    '            Encabezadosx.AddCell(PdfPCell)
    '            'Encabezadosx.AddCell(PdfpCell_espaciovacioborde)
    '            With PdfpCell_espaciovacio
    '                .FixedHeight = 10.0F
    '                .Colspan = Encabezadosx.NumberOfColumns
    '            End With
    '            Encabezadosx.AddCell(PdfpCell_espaciovacio)
    '            '----------------------AGREGA EL ENCABEZADO Completo------------------------------
    '            ' Frase_total.Clear()
    '            PARRAFOCOMPLETO.Add(Encabezadosx)
    '            Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
    '            PARRAFOCOMPLETO.Clear()
    '            'DATOS BÁSICOS ORDEN DE PAGO
    '            Dim Datosbasicosordenpago As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(4)
    '            Datosbasicosordenpago.TotalWidth = Anchopagina - Doc.LeftMargin
    '            Datosbasicosordenpago.LockedWidth = True
    '            Datosbasicosordenpago.PaddingTop = 5
    '            tamaniocolumna = New Single(3) {}
    '            tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.12)
    '            tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.12)
    '            tamaniocolumna(2) = Convert.ToSingle(Anchopagina * 0.38)
    '            tamaniocolumna(3) = Convert.ToSingle(Anchopagina * 0.38)
    '            Datosbasicosordenpago.SetWidths(tamaniocolumna)
    '            Datosbasicosordenpago.AddCell(Phrasepdf(" ORDEN DE PAGO ", tamaniodefuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE,, "#c5c7c0"))
    '            Datosbasicosordenpago.AddCell(Phrasepdf("ORDEN DE PAGO Nº " & ORDENDEPAGOS.ordenpago_numero,
    '                                                        tamaniodefuente + 6, True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
    '            'TIPO O TIPOS DE INSTRUMENTO LEGAL
    '            Dim Tipo_instrumentolegal As New List(Of String)
    '            Dim Todostiposlegales As String = ""
    '            Select Case ORDENDEPAGOS.Ordenpago_tipo.ToUpper
    '                Case Is = "ARANCELAMIENTO"
    '                    'EN CASO DE QUE SEA ARANCELAMIENTO NO REQUIERE UN NÚMERO DE INSTRUMENTO LEGAL YA QYUE ESTE ES EL DECRETO 488/2000
    '                    Todostiposlegales = "DECRETO"
    '                    Datosbasicosordenpago.AddCell(Phrasepdf(Todostiposlegales,
    '                                                                tamaniodefuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
    '                    Datosbasicosordenpago.AddCell(Phrasepdf(" ", tamaniodefuente,
    '                    True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
    '                Case Else
    '                    Select Case ORDENDEPAGOS.SINACTAS.Count
    '                        Case = 0
    '                            Datosbasicosordenpago.AddCell(Phrasepdf(" ",
    '                                                                        tamaniodefuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
    '                            Datosbasicosordenpago.AddCell(Phrasepdf(" ",
    '                                                                        tamaniodefuente, True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
    '                        Case = 1
    '                            Datosbasicosordenpago.AddCell(Phrasepdf(ORDENDEPAGOS.SINACTAS(0).Tipo_instrumentolegal,
    '                                                                        tamaniodefuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
    '                            Datosbasicosordenpago.AddCell(Phrasepdf(" ", tamaniodefuente,
    '                                                                        True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
    '                        Case Else
    '                            For X = 0 To ORDENDEPAGOS.SINACTAS.Count - 1
    '                                If Not Tipo_instrumentolegal.Contains(ORDENDEPAGOS.SINACTAS(X).Tipo_instrumentolegal) Then
    '                                    Tipo_instrumentolegal.Add(ORDENDEPAGOS.SINACTAS(X).Tipo_instrumentolegal)
    '                                    If Tipo_instrumentolegal.Count > 1 Then
    '                                        Todostiposlegales += "/" & ORDENDEPAGOS.SINACTAS(X).Tipo_instrumentolegal
    '                                    Else
    '                                        Todostiposlegales = ORDENDEPAGOS.SINACTAS(X).Tipo_instrumentolegal
    '                                    End If
    '                                End If
    '                            Next
    '                            If Tipo_instrumentolegal.Count > 1 Then
    '                                Datosbasicosordenpago.AddCell(Phrasepdf(Todostiposlegales,
    '                                                                        tamaniodefuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
    '                                Datosbasicosordenpago.AddCell(Phrasepdf(" ", tamaniodefuente,
    '                                                                        True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
    '                            Else
    '                                Datosbasicosordenpago.AddCell(Phrasepdf(ORDENDEPAGOS.SINACTAS(0).Tipo_instrumentolegal,
    '                                                                        tamaniodefuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
    '                                Datosbasicosordenpago.AddCell(Phrasepdf(" ", tamaniodefuente,
    '                                                                        True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
    '                            End If
    '                    End Select
    '            End Select
    '            Datosbasicosordenpago.AddCell(Phrasepdf(" AÑO ", tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
    '            Datosbasicosordenpago.AddCell(Phrasepdf(" NÚMERO ", tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
    '            Datosbasicosordenpago.AddCell(Phrasepdf(" ", tamaniodefuente, False, 0, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
    '            'SE EFECTUA UN FORMATO PREVIO PARA MANEJAR LOS CASOS QUE CONTENGAN VARIAS ORDENES DE PROVISION DENTRO DE LA ORDEN DE PAGO..
    '            Dim numeroinstrumentolegal As New List(Of String)
    '            Dim anioinstrumentolegal As New List(Of String)
    '            Dim CONCATENADO As New List(Of String)
    '            Dim BENEFICIARIO As New List(Of String)
    '            Dim detallenumeroinstrumentolegal As String = ""
    '            Dim detalleanioinstrumentolegal As String = ""
    '            Select Case ORDENDEPAGOS.Ordenpago_tipo.ToUpper
    '                Case Is = "ARANCELAMIENTO"
    '                    'EN CASO DE QUE SEA ARANCELAMIENTO NO REQUIERE UN NÚMERO DE INSTRUMENTO LEGAL YA QYUE ESTE ES EL DECRETO 488/2000
    '                    Todostiposlegales = "DECRETO"
    '                    detallenumeroinstrumentolegal = "488"
    '                    detalleanioinstrumentolegal = "2000"
    '                Case Else
    '                    Select Case ORDENDEPAGOS.SINACTAS.Count
    '                        Case = 0
    '                            detallenumeroinstrumentolegal = ""
    '                            detalleanioinstrumentolegal = ""
    '                        'PdfPCell = New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(tamaniodefuente, True))), 0.5, 2, 1, iTextSharp.text.Element.ALIGN_CENTER, 0))
    '                        Case = 1
    '                            detallenumeroinstrumentolegal = ORDENDEPAGOS.SINACTAS(0).Numero_instrumentolegal
    '                            detalleanioinstrumentolegal = ORDENDEPAGOS.SINACTAS(0).Year_instrumento_legal
    '                            'PdfPCell = New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(ORDENDEPAGOS.ORDENESPROVISION(0).Numero_instrumentolegal, PDF_fuente_variable(tamaniodefuente, False))), 0.5, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0))
    '                        Case Else
    '                            For Each op As SINACTARECEPCION In ORDENDEPAGOS.SINACTAS
    '                                If Not (CONCATENADO.Contains(op.Numero_instrumentolegal & "/" & op.Year_instrumento_legal)) Then
    '                                    numeroinstrumentolegal.Add(op.Numero_instrumentolegal)
    '                                    anioinstrumentolegal.Add(op.Year_instrumento_legal)
    '                                    CONCATENADO.Add(op.Numero_instrumentolegal & "/" & op.Year_instrumento_legal)
    '                                End If
    '                            Next
    '                            For z = 0 To numeroinstrumentolegal.Count - 1
    '                                If z = numeroinstrumentolegal.Count - 1 Then
    '                                    detallenumeroinstrumentolegal += numeroinstrumentolegal(z)
    '                                    detalleanioinstrumentolegal += anioinstrumentolegal(z)
    '                                Else
    '                                    detallenumeroinstrumentolegal += numeroinstrumentolegal(z) & vbCrLf
    '                                    detalleanioinstrumentolegal += anioinstrumentolegal(z) & vbCrLf
    '                                End If
    '                            Next
    '                    End Select
    '            End Select
    '            PdfPCell = New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(detalleanioinstrumentolegal, PDF_fuente_variable(tamaniodefuente, False))), 0.5, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0))
    '            Datosbasicosordenpago.AddCell(PdfPCell)
    '            PdfPCell = New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(detallenumeroinstrumentolegal, PDF_fuente_variable(tamaniodefuente, False))), 0.5, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0))
    '            Datosbasicosordenpago.AddCell(PdfPCell)
    '            PdfPCell = New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(10, False))), 0, 2, 1, iTextSharp.text.Element.ALIGN_CENTER, 0))
    '            Datosbasicosordenpago.AddCell(PdfPCell)
    '            PdfPCell = New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(10, False))), 0, 4, 1, iTextSharp.text.Element.ALIGN_CENTER, 0))
    '            Datosbasicosordenpago.AddCell(PdfPCell)
    '            'Datosbasicosordenpago.AddCell(PdfpCell_espaciovacio)
    '            Datosbasicosordenpago.AddCell(Phrasepdf(" EXPEDIENTE ", tamaniodefuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE,, "#c5c7c0"))
    '            Datosbasicosordenpago.AddCell(Phrasepdf("POSADAS, " & ORDENDEPAGOS.ordenpago_fecha.ToShortDateString, tamaniodefuente + 2, False, 0, 2, 3, Element.ALIGN_CENTER, 4, Element.ALIGN_MIDDLE))
    '            Datosbasicosordenpago.AddCell(Phrasepdf("LETRA", tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
    '            Datosbasicosordenpago.AddCell(Phrasepdf("NÚMERO", tamaniodefuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
    '            'NUMERO DE EXPEDIENTE
    '            Datosbasicosordenpago.AddCell(Phrasepdf(ORDENDEPAGOS.expediente_op.organismo.ToString, tamaniodefuente + 1, True, 0.5, 1, 1, Element.ALIGN_CENTER, 4, Element.ALIGN_MIDDLE))
    '            Datosbasicosordenpago.AddCell(Phrasepdf(ORDENDEPAGOS.expediente_op.numero & "-" & ORDENDEPAGOS.expediente_op.year, tamaniodefuente + 1, True, 0.5, 1, 1, Element.ALIGN_CENTER, 4, Element.ALIGN_MIDDLE))
    '            If ORDENDEPAGOS.expediente_op2.claveexpediente > 0 Then
    '                Datosbasicosordenpago.AddCell(Phrasepdf(CType(ORDENDEPAGOS.expediente_op2.claveexpediente.ToString.Substring(4, 4), UInteger).ToString, tamaniodefuente + 1, True, 0.5, 1, 1, Element.ALIGN_CENTER, 4, Element.ALIGN_MIDDLE))
    '                Datosbasicosordenpago.AddCell(Phrasepdf(CType(ORDENDEPAGOS.expediente_op2.claveexpediente.ToString.Substring(8, 5), UInteger) & "-" & CType(ORDENDEPAGOS.expediente_op2.claveexpediente.ToString.Substring(0, 4), UInteger), tamaniodefuente + 1, True, 0.5, 1, 1, Element.ALIGN_CENTER, 4, Element.ALIGN_MIDDLE))
    '            End If
    '            'PdfPCell = New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(ORDENDEPAGOS.expediente_op.numero & "-" & ORDENDEPAGOS.expediente_op.year, PDF_fuente_variable(tamaniodefuente + 1, True))), 0.5, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0))
    '            'Datosbasicosordenpago.AddCell(PdfPCell)
    '            'EXPEDIENTE PRINCIPAL
    '            If ORDENDEPAGOS.ClaveExpediente_principal.ToString.Length = 13 Then
    '                Datosbasicosordenpago.AddCell(Phrasepdf(" Autorizado por: ", tamaniodefuente, False, 0.5, 2, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE))
    '                Datosbasicosordenpago.AddCell(Phrasepdf(" ", tamaniodefuente + 2, False, 0, 2, 3, Element.ALIGN_CENTER, 4, Element.ALIGN_MIDDLE))
    '                Datosbasicosordenpago.AddCell(Phrasepdf(ORDENDEPAGOS.ClaveExpediente_principal.ToString.Substring(4, 4) & "-" &
    '                                                 Convert.ToInt32(ORDENDEPAGOS.ClaveExpediente_principal.ToString.Substring(8, 5)) & "/" &
    '                                                ORDENDEPAGOS.ClaveExpediente_principal.ToString.Substring(0, 4), tamaniodefuente, False, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
    '            Else
    '                Datosbasicosordenpago.AddCell(Phrasepdf("  ", tamaniodefuente, True, 0, 2, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE))
    '                Datosbasicosordenpago.AddCell(Phrasepdf(" ", tamaniodefuente + 2, False, 0, 2, 3, Element.ALIGN_CENTER, 4, Element.ALIGN_MIDDLE))
    '                Datosbasicosordenpago.AddCell(Phrasepdf(" ", tamaniodefuente, False, 0, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
    '            End If
    '            PARRAFOCOMPLETO.Add(Datosbasicosordenpago)
    '            Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
    '            'TEXTO DATOS BÁSICOS ORDEN DE PAGO
    '            PARRAFOPARCIAL.Clear()
    '            PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("De acuerdo con la orden precedente se liquida para ser abonado por la Tesorería del " &
    '                                                             Autorizaciones.Nombrecompletodelservicio &
    '                                                             " a favor de: ", PDF_fuente_variable(tamaniodefuente + 1, False)))
    '            '*******************************************************COMIENZO DE MULTI ORDENES*******************************************************************************
    '            Dim LISTADECUITS As New List(Of String)
    '            Select Case ORDENDEPAGOS.Ordenpago_tipo.ToUpper
    '                Case Is = "BECAS"
    '                    PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("Varios Beneficiarios " & vbCrLf, PDF_fuente_variable(tamaniodefuente + 2, True)))
    '                Case Is = "COMISIÓN BANCARIA"
    '                    PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("BANCO MACRO S.A." & vbCrLf, PDF_fuente_variable(tamaniodefuente + 2, True)))
    '                Case Is = "VIÁTICOS"
    '                    If ORDENDEPAGOS.VIATICOS.Count = 1 Then
    '                        PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(ORDENDEPAGOS.VIATICOS(0).Beneficiario.ToUpper & vbCrLf, PDF_fuente_variable(tamaniodefuente + 2, True)))
    '                    Else
    '                        PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("Varios Beneficiarios " & vbCrLf, PDF_fuente_variable(tamaniodefuente + 2, True)))
    '                    End If
    '                Case Else
    '                    Dim CONTAR As Integer = 0
    '                    Dim ContarCUIT As Integer = 0
    '                    For X = 0 To ORDENDEPAGOS.SINACTAS.Count - 1
    '                        If (ORDENDEPAGOS.SINACTAS(X).CUIT.Length > 8) Then
    '                            ContarCUIT += 1
    '                            If Not LISTADECUITS.Contains(ORDENDEPAGOS.SINACTAS(X).CUIT) Then
    '                                LISTADECUITS.Add(ORDENDEPAGOS.SINACTAS(X).CUIT)
    '                            End If
    '                        End If
    '                    Next
    '                    If LISTADECUITS.Count > 1 Then
    '                        PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("Varios Beneficiarios " & vbCrLf, PDF_fuente_variable(tamaniodefuente + 2, True)))
    '                    Else
    '                        If LISTADECUITS.Count = 0 Then
    '                            'en caso de que no tenga CUITS
    '                            For X = 0 To ORDENDEPAGOS.SINACTAS.Count - 1
    '                                If Not (ORDENDEPAGOS.SINACTAS(X).EFECTOR = "") Then
    '                                    If Not (BENEFICIARIO.Contains(ORDENDEPAGOS.SINACTAS(X).EFECTOR)) Then
    '                                        BENEFICIARIO.Add(ORDENDEPAGOS.SINACTAS(X).EFECTOR)
    '                                    End If
    '                                    ' CONTAR += 1
    '                                End If
    '                            Next
    '                            Select Case BENEFICIARIO.Count
    '                                Case = 0
    '                                Case = 1
    '                                    PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(BENEFICIARIO(0) & vbCrLf, PDF_fuente_variable(tamaniodefuente + 2, True)))
    '                                Case Else
    '                                    PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("Varios Beneficiarios " & vbCrLf, PDF_fuente_variable(tamaniodefuente + 2, True)))
    '                            End Select
    '                        Else
    '                            PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(Proveedor.Nombre_proveedor(LISTADECUITS(0)) & vbCrLf, PDF_fuente_variable(tamaniodefuente + 2, True)))
    '                        End If
    '                    End If
    '            End Select
    '            'CONCEPTO DE'
    '            PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("A su orden en concepto de: ", PDF_fuente_variable(tamaniodefuente + 2, False)))
    '            Select Case ORDENDEPAGOS.Ordenpago_tipo.ToUpper
    '                Case Is = "REDETERMINACIÓN"
    '                    PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("PAGO", PDF_fuente_variable(tamaniodefuente + 2, True)))
    '                'Case Is = "PAGO MULTIPLES EFECTORES"
    '                '    PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("PAGO", PDF_fuente_variable(tamaniodefuente + 2, True)))
    '                Case Is = "BECAS"
    '                    PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("PAGO", PDF_fuente_variable(tamaniodefuente + 2, True)))
    '                Case Is = "COMISIÓN BANCARIA"
    '                    PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("PAGO", PDF_fuente_variable(tamaniodefuente + 2, True)))
    '                Case Is = "TRANSFERENCIA"
    '                    PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("TRANSFERENCIA", PDF_fuente_variable(tamaniodefuente + 2, True)))
    '                Case Is = "ARANCELAMIENTO"
    '                    PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("RENDICIÓN", PDF_fuente_variable(tamaniodefuente + 2, True)))
    '                Case Is = "VIÁTICOS"
    '                    PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("RENDICIÓN VIATICO.-", PDF_fuente_variable(tamaniodefuente + 2, True)))
    '                Case Else
    '                    PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(ORDENDEPAGOS.Ordenpago_tipo, PDF_fuente_variable(tamaniodefuente + 2, True)))
    '            End Select
    '            PARRAFOPARCIAL.FirstLineIndent = tamaniocolumna(0) + tamaniocolumna(1)
    '            Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOPARCIAL, 0, 1, 1, 0, 3)))
    '            With PdfpCell_espaciovacio
    '                .FixedHeight = 10.0F
    '                .Colspan = Tabla_total.NumberOfColumns
    '            End With
    '            Tabla_total.AddCell(PdfpCell_espaciovacio)
    '            '************************************************************************CUADRO DETALLE************************************************************************************************
    '            'Dim textoprimercuadro As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(6)
    '            Dim textoprimercuadro As iTextSharp.text.pdf.PdfPTable = New PdfPTable(1)
    '            textoprimercuadro.TotalWidth = Tabla_total.TotalWidth
    '            textoprimercuadro.LockedWidth = True
    '            Select Case ORDENDEPAGOS.Ordenpago_tipo.ToUpper
    '                Case Is = "ARANCELAMIENTO"
    '                    textoprimercuadro = cuadro_RENDICION(ORDENDEPAGOS, Doc, tamaniodefuente)
    '                'Case Is = "PAGO MULTIPLES EFECTORES"
    '                '    textoprimercuadro = cuadro_RECONOCIMIENTO(ORDENDEPAGOS, Doc, tamaniodefuente)
    '                Case Is = "TRANSFERENCIA"
    '                    textoprimercuadro = cuadro_TRANSFERENCIA(ORDENDEPAGOS, Doc, tamaniodefuente)
    '                Case Is = "RENDICIÓN"
    '                    textoprimercuadro = cuadro_RENDICION(ORDENDEPAGOS, Doc, tamaniodefuente)
    '                Case Is = "RENDICIÓN FINAL"
    '                    textoprimercuadro = cuadro_RENDICION(ORDENDEPAGOS, Doc, tamaniodefuente)
    '                Case Is = "RENDICIÓN PARCIAL"
    '                Case Is = "RECONOCIMIENTO"
    '                    textoprimercuadro = cuadro_RECONOCIMIENTO(ORDENDEPAGOS, Doc, tamaniodefuente)
    '                Case Is = "RECONOCIMIENTO Y REAPROPIACIÓN"
    '                    textoprimercuadro = cuadro_RECONOCIMIENTO_APROPIACION(ORDENDEPAGOS, Doc, tamaniodefuente)
    '                Case Is = "REDETERMINACIÓN"
    '                    textoprimercuadro = cuadro_RECONOCIMIENTO(ORDENDEPAGOS, Doc, tamaniodefuente)
    '                Case Is = "VIÁTICOS"
    '                    textoprimercuadro = cuadro_VIATICOS(ORDENDEPAGOS, Doc, tamaniodefuente)
    '                Case Is = "REPOSICIÓN"
    '                    textoprimercuadro = cuadro_RECONOCIMIENTO(ORDENDEPAGOS, Doc, tamaniodefuente)
    '                Case Is = "CONTRATOS"
    '                    textoprimercuadro = cuadro_RECONOCIMIENTO(ORDENDEPAGOS, Doc, tamaniodefuente)
    '                Case Is = "BECAS"
    '                    textoprimercuadro = cuadro_RECONOCIMIENTO(ORDENDEPAGOS, Doc, tamaniodefuente)
    '                Case Is = "COMISIÓN BANCARIA"
    '                    textoprimercuadro = cuadro_RECONOCIMIENTO(ORDENDEPAGOS, Doc, tamaniodefuente)
    '            End Select
    '            'DETERMINAR QUE CAMPOS ESTAN COMPLETADOS
    '            '************************************************************** REFACTORIZAR*****************************************************************************************
    '            '************************************************************** REFACTORIZAR*****************************************************************************************
    '            Select Case ORDENDEPAGOS.Ordenpago_tipo.ToUpper
    '                Case Is = "ARANCELAMIENTO"
    '                    textoprimercuadro = cuadro_RENDICION(ORDENDEPAGOS, Doc, tamaniodefuente)
    '                Case Is = "RENDICIÓN"
    '                    textoprimercuadro = cuadro_RENDICION(ORDENDEPAGOS, Doc, tamaniodefuente)
    '                Case Is = "RENDICIÓN FINAL"
    '                    textoprimercuadro = cuadro_RENDICION(ORDENDEPAGOS, Doc, tamaniodefuente)
    '                Case Else
    '                    If ORDENDEPAGOS.ordenpago_Detalle2.Length > 0 Then
    '                        textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Observaciones:" & ORDENDEPAGOS.ordenpago_Detalle2, PDF_fuente_variable(tamaniodefuente, False))), 0, textoprimercuadro.NumberOfColumns, 1, iTextSharp.text.Element.ALIGN_JUSTIFIED, 0)))
    '                    End If
    '            End Select
    '            With PdfpCell_espaciovacio
    '                .FixedHeight = 20.0F
    '                .Colspan = textoprimercuadro.NumberOfColumns
    '            End With
    '            textoprimercuadro.AddCell(PdfpCell_espaciovacio)
    '            Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(textoprimercuadro, 0.5)))
    '            Dim Totalsumado As Decimal = 0
    '            'SUMA TOTAL DE PEDIDO DE FONDO Y TEXTO
    '            For X = 0 To ORDENDEPAGOS.DatosOrdenPago.Rows.Count - 1
    '                Totalsumado += CType(ORDENDEPAGOS.DatosOrdenPago.Rows(X).Item(11), Decimal)
    '            Next
    '            'Tabla_total.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" La suma de Pesos " & Totalsumado.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")) & ".-" & vbCrLf, PDF_fuente_variable(tamaniodefuente, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_JUSTIFIED)))
    '            Tabla_total.AddCell(Phrasepdf(" La suma de Pesos " & Totalsumado.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")) & ".-", tamaniodefuente, True, 0, 1, 1, Element.ALIGN_JUSTIFIED, 2, Element.ALIGN_MIDDLE, 200))
    '            'Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(New iTextSharp.text.Chunk("Son Pesos:  " & Inicio.Num2Text(Math.Truncate(Convert.ToDecimal(Totalsumado))) & " CON " &
    '            '((Convert.ToDecimal(Totalsumado) - Math.Truncate(Convert.ToDecimal(Totalsumado))) * 100).ToString("00") & "/100.-", PDF_fuente_variable(tamaniodefuente, False)), 0, 11, 1, Element.ALIGN_JUSTIFIED)))
    '            Tabla_total.AddCell(Phrasepdf("Son Pesos:  " & Inicio.Num2Text(Math.Truncate(Convert.ToDecimal(Totalsumado))) & " CON " &
    '                ((Convert.ToDecimal(Totalsumado) - Math.Truncate(Convert.ToDecimal(Totalsumado))) * 100).ToString("00") & "/100.-", tamaniodefuente, False, 0, 11, 1, Element.ALIGN_JUSTIFIED, 2, Element.ALIGN_MIDDLE))
    '            'Tabla_total.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" QUE SE IMPUTARAN DE LA SIGUIENTE MANERA:", PDF_fuente_variable(tamaniodefuente, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_LEFT)))
    '            If ORDENDEPAGOS.DatosOrdenPago.Rows.Count > 0 Then
    '                Tabla_total.AddCell(Phrasepdf(" QUE SE IMPUTARAN DE LA SIGUIENTE MANERA: CUENTA " & CUENTA_PDF(ORDENDEPAGOS.DatosOrdenPago.Rows(0).Item(2)), tamaniodefuente, True, 0, 1, 1, Element.ALIGN_LEFT, 2, Element.ALIGN_MIDDLE, 0))
    '            Else
    '                Tabla_total.AddCell(Phrasepdf(" QUE SE IMPUTARAN DE LA SIGUIENTE MANERA: CUENTA ARANCELAMIENTO 2-02", tamaniodefuente, True, 0, 1, 1, Element.ALIGN_LEFT, 2, Element.ALIGN_MIDDLE, 0))
    '                ORDENDEPAGOS.DatosOrdenPago.Rows.Add({"_", "_", "2-02", "_", "_", "_", "_", "_", "_", "_", "_", 0})
    '            End If
    '            'Tabla_total.AddCell(Phrasepdf(, tamaniodefuente, True, 0, 1, 1, Element.ALIGN_LEFT, 2, Element.ALIGN_MIDDLE, 0))
    '            'TABLA DE PARTIDAS PRESUPUESTARIAS
    '            'para lograr la adaptación completa debo disminuir el margen necesario
    '            Dim anchoutil As Single = Anchopagina - Doc.LeftMargin
    '            tamaniocolumna = New Single(11) {}
    '            Dim TABLAORDENDEPAGO As iTextSharp.text.pdf.PdfPTable = Nothing
    '            Select Case ORDENDEPAGOS.Ordenpago_tipo.ToUpper
    '                Case Is = "ARANCELAMIENTO"
    '                    tamaniocolumna(0) = Convert.ToSingle(anchoutil * 0.0681) 'jur.
    '                    tamaniocolumna(1) = Convert.ToSingle(anchoutil * 0.0681) 'UO
    '                    tamaniocolumna(2) = Convert.ToSingle(anchoutil * 0.0681) 'CARAC
    '                    tamaniocolumna(3) = Convert.ToSingle(anchoutil * 0.0681) ' FIN
    '                    tamaniocolumna(4) = Convert.ToSingle(anchoutil * 0.0681) ' FUN.
    '                    tamaniocolumna(5) = Convert.ToSingle(anchoutil * 0.0681) 'SECC
    '                    tamaniocolumna(6) = Convert.ToSingle(anchoutil * 0.0681) 'SECT
    '                    tamaniocolumna(7) = Convert.ToSingle(anchoutil * 0.0681) ' PDA PCIAL
    '                    tamaniocolumna(8) = Convert.ToSingle(anchoutil * 0.0681) ' PDA PPAL
    '                    tamaniocolumna(9) = Convert.ToSingle(anchoutil * 0.0681) 'PDA SUB PAR
    '                    tamaniocolumna(10) = Convert.ToSingle(anchoutil * 0.0681) 'SCD
    '                    tamaniocolumna(11) = Convert.ToSingle(anchoutil * 0.25) 'IMPORTE
    '                    TABLAORDENDEPAGO = PDFDatatable_op_arancelamiento(ORDENDEPAGOS, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#ffffff")), tamaniodefuente - 1)
    '                Case Else
    '                    tamaniocolumna(0) = Convert.ToSingle(anchoutil * 0.0681) 'jur.
    '                    tamaniocolumna(1) = Convert.ToSingle(anchoutil * 0.0681) 'UO
    '                    tamaniocolumna(2) = Convert.ToSingle(anchoutil * 0.0681) 'CARAC
    '                    tamaniocolumna(3) = Convert.ToSingle(anchoutil * 0.0681) ' FIN
    '                    tamaniocolumna(4) = Convert.ToSingle(anchoutil * 0.0681) ' FUN.
    '                    tamaniocolumna(5) = Convert.ToSingle(anchoutil * 0.0681) 'SECC
    '                    tamaniocolumna(6) = Convert.ToSingle(anchoutil * 0.0681) 'SECT
    '                    tamaniocolumna(7) = Convert.ToSingle(anchoutil * 0.0681) ' PDA PCIAL
    '                    tamaniocolumna(8) = Convert.ToSingle(anchoutil * 0.0681) ' PDA PPAL
    '                    tamaniocolumna(9) = Convert.ToSingle(anchoutil * 0.0681) 'PDA SUB PAR
    '                    tamaniocolumna(10) = Convert.ToSingle(anchoutil * 0.0681) 'SCD
    '                    tamaniocolumna(11) = Convert.ToSingle(anchoutil * 0.25) 'IMPORTE
    '                    TABLAORDENDEPAGO = PDFDatatable(ORDENDEPAGOS.DatosOrdenPago, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#ffffff")), tamaniodefuente - 1)
    '                    'Case Is = "PAGO"
    '                    '    TABLAORDENDEPAGO = PDFDatatable(ORDENDEPAGOS.DatosOrdenPago, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#ffffff")), tamaniodefuente - 1)
    '                    'Case Is = "TRANSFERENCIA"
    '                    '    TABLAORDENDEPAGO = PDFDatatable(ORDENDEPAGOS.DatosOrdenPago, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#ffffff")), tamaniodefuente - 1)
    '                    'Case Is = "RENDICIÓN"
    '                    '    TABLAORDENDEPAGO = PDFDatatable(ORDENDEPAGOS.DatosOrdenPago, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#ffffff")), tamaniodefuente - 1)
    '                    'Case Is = "RENDICIÓN FINAL"
    '                    '    TABLAORDENDEPAGO = PDFDatatable(ORDENDEPAGOS.DatosOrdenPago, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#ffffff")), tamaniodefuente - 1)
    '                    'Case Is = "RENDICIÓN PARCIAL"
    '                    '    TABLAORDENDEPAGO = PDFDatatable(ORDENDEPAGOS.DatosOrdenPago, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#ffffff")), tamaniodefuente - 1)
    '                    'Case Is = "RECONOCIMIENTO"
    '                    '    TABLAORDENDEPAGO = PDFDatatable(ORDENDEPAGOS.DatosOrdenPago, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#ffffff")), tamaniodefuente - 1)
    '                    'Case Is = "RECONOCIMIENTO Y REAPROPIACIÓN"
    '                    '    TABLAORDENDEPAGO = PDFDatatable(ORDENDEPAGOS.DatosOrdenPago, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#ffffff")), tamaniodefuente - 1)
    '                    'Case Is = "REDETERMINACIÓN"
    '                    '    TABLAORDENDEPAGO = PDFDatatable(ORDENDEPAGOS.DatosOrdenPago, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#ffffff")), tamaniodefuente - 1)
    '                    'Case Is = "VIÁTICOS"
    '                    '    TABLAORDENDEPAGO = PDFDatatable(ORDENDEPAGOS.DatosOrdenPago, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#ffffff")), tamaniodefuente - 1)
    '                    'Case Is = "REPOSICIÓN"
    '                    '    TABLAORDENDEPAGO = PDFDatatable(ORDENDEPAGOS.DatosOrdenPago, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#ffffff")), tamaniodefuente - 1)
    '                    'Case Is = "CONTRATOS"
    '                    '    TABLAORDENDEPAGO = PDFDatatable(ORDENDEPAGOS.DatosOrdenPago, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#ffffff")), tamaniodefuente - 1)
    '                    'Case Is = "BECAS"
    '                    '    TABLAORDENDEPAGO = PDFDatatable(ORDENDEPAGOS.DatosOrdenPago, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#ffffff")), tamaniodefuente - 1)
    '                    'Case Is = "COMISIÓN BANCARIA"
    '                    '    TABLAORDENDEPAGO = PDFDatatable(ORDENDEPAGOS.DatosOrdenPago, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#ffffff")), tamaniodefuente - 1)
    '            End Select
    '            'Select Case ORDENDEPAGOS.Ordenpago_tipo.ToUpper
    '            '    Case Is = "ARANCELAMIENTO"
    '            '        'TOTALES DE PARTIDAS PRESUPUESTARIAS
    '            '        'If ORDENDEPAGOS.novalido Then
    '            '        '    TABLAORDENDEPAGO.AddCell(Phrasepdf(" SIN MOVIMIENTOS ", tamaniodefuente + 3, True, 0, TABLAORDENDEPAGO.NumberOfColumns, 1, Element.ALIGN_RIGHT, 0))
    '            '        'End If
    '            '        If TABLAORDENDEPAGO.Rows.Count > 1 And Not ORDENDEPAGOS.novalido Then
    '            '            With PdfpCell_espaciovacio
    '            '                .FixedHeight = 7.0F
    '            '                .Colspan = TABLAORDENDEPAGO.NumberOfColumns
    '            '            End With
    '            '            TABLAORDENDEPAGO.AddCell(PdfpCell_espaciovacio)
    '            '            TABLAORDENDEPAGO.AddCell(Phrasepdf(" Total: ", tamaniodefuente, True, 0, TABLAORDENDEPAGO.NumberOfColumns - 1, 1, Element.ALIGN_RIGHT, 0))
    '            '            With TABLAORDENDEPAGO.AddCell(Phrasepdf(Totalsumado.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 1))
    '            '                .Border = PdfPCell.TOP_BORDER
    '            '                .BorderWidth = 1
    '            '                .PaddingTop = 0
    '            '            End With
    '            '        End If
    '            '    Case Is = "RENDICIÓN"
    '            '    Case Is = "RENDICIÓN FINAL"
    '            '    Case Else
    '            'End Select
    '            If TABLAORDENDEPAGO.Rows.Count > 1 And Not ORDENDEPAGOS.novalido Then
    '                With PdfpCell_espaciovacio
    '                    .FixedHeight = 7.0F
    '                    .Colspan = TABLAORDENDEPAGO.NumberOfColumns
    '                End With
    '                TABLAORDENDEPAGO.AddCell(PdfpCell_espaciovacio)
    '                TABLAORDENDEPAGO.AddCell(Phrasepdf(" Total: ", tamaniodefuente, True, 0, TABLAORDENDEPAGO.NumberOfColumns - 1, 1, Element.ALIGN_RIGHT, 0))
    '                With TABLAORDENDEPAGO.AddCell(Phrasepdf(Totalsumado.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 1))
    '                    .Border = PdfPCell.TOP_BORDER
    '                    .BorderWidth = 1
    '                    .PaddingTop = 0
    '                End With
    '            End If
    '            'VISTO LA LIQUIDACIÓN, ORDEN DE PAGO
    '            Doc.Add(Tabla_total)
    '            '     Doc.Add(PARRAFOPARCIAL)
    '            Doc.Add(TABLAORDENDEPAGO)
    '            Dim COLUMNA As New ColumnText(wri.DirectContent)
    '            'the Phrase
    '            'the lower left x corner (left)
    '            'the lower left y corner (bottom)
    '            'the upper right x corner (right)
    '            'the upper right y corner (top)
    '            'line height(leading)
    '            'alignment.
    '            'COLUMNA.SetSimpleColumn(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(ORDENDEPAGOS.CLASE_FONDO, PDF_fuente_variable(tamaniodefuente + 6, True))),
    '            '                        (Doc.LeftMargin) + 50, 750,
    '            '                       Doc.GetBottom(0) + (TABLAORDENDEPAGO.TotalHeight / 2), (TABLAORDENDEPAGO.TotalWidth / 2) - Doc.RightMargin,
    '            '                        15, Element.ALIGN_LEFT)
    '            'COLUMNA.Go()
    '            tamaniocolumna = New Single(0) {}
    '            tamaniocolumna(0) = Convert.ToSingle(anchoutil * 1) 'jur.
    '            'Dim TABLAINICIALES As iTextSharp.text.pdf.PdfPTable = PDFDatatable(New DataTable, tamaniocolumna, 1, Anchopagina - Doc.LeftMargin, False, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#ffffff")), 8)
    '            Doc.Add(TABLA_INICIALES(anchoutil, ORDENDEPAGOS.ordenpago_USUARIO))
    '            Dim LISTADETEXTO As New List(Of Chunk)
    '            PARRAFOCOMPLETO.Clear()
    '            Select Case ORDENDEPAGOS.Ordenpago_tipo.ToUpper
    '                Case Is = "ARANCELAMIENTO"
    '                    LISTADETEXTO.Add(New Chunk("VISTO: ", PDF_fuente_variable(tamaniodefuente, True)))
    '                    LISTADETEXTO.Add(New Chunk("La liquidación que antecede, gírese a la Tesorería para su cumplimiento.", PDF_fuente_variable(tamaniodefuente, False)))
    '                Case Else
    '                    LISTADETEXTO.Add(New Chunk("VISTO: ", PDF_fuente_variable(tamaniodefuente, True)))
    '                    LISTADETEXTO.Add(New Chunk("La liquidación que antecede, téngase por ", PDF_fuente_variable(tamaniodefuente, False)))
    '                    LISTADETEXTO.Add(New Chunk("ORDEN de  PAGO ", PDF_fuente_variable(tamaniodefuente, True)))
    '                    LISTADETEXTO.Add(New Chunk("y abónese de conformidad a la misma. Gírese a la Tesorería para su cumplimiento.", PDF_fuente_variable(tamaniodefuente, False)))
    '            End Select
    '            For Each ITEM As Chunk In LISTADETEXTO
    '                PARRAFOCOMPLETO.Add(ITEM)
    '            Next
    '            PARRAFOCOMPLETO.Alignment = Element.ALIGN_JUSTIFIED
    '            Doc.Add(PARRAFOCOMPLETO)
    '            'If Not ORDENDEPAGOS.novalido Then
    '            PARRAFOCOMPLETO.Clear()
    '            With PARRAFOCOMPLETO
    '                .Add(PDFFIRMAS(Anchopagina - Doc.LeftMargin, "CONTABILIDAD", "Director",, 85))
    '                .Add(PDFFIRMAS(Anchopagina - Doc.LeftMargin, "DELEGADO FISCAL", "",, 85))
    '            End With
    '            Doc.Add(PARRAFOCOMPLETO)
    '            'Else
    '            '    Dim COLUMNA0 As New ColumnText(wri.DirectContent)
    '            '    'the Phrase
    '            '    'the lower left x corner (left)
    '            '    'the lower left y corner (bottom)
    '            '    'the upper right x corner (right)
    '            '    'the upper right y corner (top)
    '            '    'line height(leading)
    '            '    'alignment.
    '            '    COLUMNA0.SetSimpleColumn(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("SIN MOVIMIENTOS", PDF_fuente_variable(25, True))),
    '            '                            Doc.Left, Doc.Bottom,
    '            '                          Doc.Right, Doc.PageSize.Height / 3,
    '            '                            15, Element.ALIGN_JUSTIFIED_ALL)
    '            '    COLUMNA0.Go()
    '            'End If
    '            'For Each ITEM As Chunk In LISTADETEXTO
    '            '    PARRAFOCOMPLETO.Add(ITEM)
    '            'Next
    '            'PARRAFOCOMPLETO.Alignment = Element.ALIGN_JUSTIFIED
    '            'Doc.Add(PARRAFOCOMPLETO)
    '            'PARRAFOCOMPLETO.Clear()
    '            'With PARRAFOCOMPLETO
    '            '    .Add(PDFFIRMAS(Anchopagina - Doc.LeftMargin, "CONTABILIDAD", "Director",, 85))
    '            '    .Add(PDFFIRMAS(Anchopagina - Doc.LeftMargin, "DELEGADO FISCAL", "",, 85))
    '            'End With
    '            'Doc.Add(PARRAFOCOMPLETO)
    '            Dim COLUMNA2 As New ColumnText(wri.DirectContent)
    '            'the Phrase
    '            'the lower left x corner (left)
    '            'the lower left y corner (bottom)
    '            'the upper right x corner (right)
    '            'the upper right y corner (top)
    '            'line height(leading)
    '            'alignment.
    '            Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14.0F, iTextSharp.text.Font.BOLD, BaseColor.GRAY)
    '            COLUMNA2.SetSimpleColumn(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("SICyF", font12Bold)),
    '                                    Doc.Left, Doc.Bottom,
    '                                  Doc.Right, 0,
    '                                    15, Element.ALIGN_RIGHT)
    '            COLUMNA2.Go()
    '            Doc.Close()
    '        End Using
    '        Select Case MsgBox("Abrir el archivo generado?", MsgBoxStyle.YesNoCancel, " ")
    '            Case MsgBoxResult.Yes
    '                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(Controlguardado.FileName) With {
    '                                             .UseShellExecute = True
    '    })
    '        End Select
    '        'Catch ex As Exception
    '        '    MessageBox.Show("NO SE PUDO GENERAR EL ARCHIVO" & vbCrLf & ex.Message)
    '        'End Try
    '    End If
    'End Sub
    Public Sub PDF_ORDENPAGO_PagoV2(ByVal ORDENDEPAGOS As Ordendepago)
        'DATOS DEL DOCUMENTO
        Dim impresor As New Impresion
        impresor.fecha = ORDENDEPAGOS.ordenpago_fecha
        impresor.cargartodoslossellos()
        'clase
        'itextsharp.pagesize
        'New iTextSharp.text.Font
        'font size
        impresor.tamaniofuentetitulos = 16
        impresor.tamaniofuente = 12
        impresor.tamaniofuentetablas = 9
        Dialogo_impresion.Cargar_impresion(impresor)
        Dim Doc As New Document(impresor.hoja, impresor.marginleft, impresor.marginright, impresor.margintop, impresor.marginbottom)
        Dim Anchopagina As Single = Doc.PageSize.Width
        Dim Controlguardado As New SaveFileDialog
        With Controlguardado
            Select Case System.IO.Directory.Exists("C:" & "\" & "Ordenes_de_Pago" & "\" & ORDENDEPAGOS.Ordenpago_Year & "\")
                Case True
                Case False
                    System.IO.Directory.CreateDirectory("C:" & "\" & "Ordenes_de_Pago" & "\" & ORDENDEPAGOS.Ordenpago_Year & "\")
            End Select
            .Filter = "ARCHIVO PDF|*.pdf"
            .Title = "Guardar en archivo PDF"
            .FileName = " OP - " & ORDENDEPAGOS.ordenpago_numero & "-" & ORDENDEPAGOS.Ordenpago_Year & ".pdf"
            .RestoreDirectory = True
            .InitialDirectory = "C:" & "\" & "Ordenes_de_Pago" & "\" & ORDENDEPAGOS.Ordenpago_Year & "\"
        End With
        Controlguardado.Filter = "ARCHIVO PDF|*.pdf"
        Controlguardado.Title = "Guardar en archivo PDF"
        Controlguardado.ShowDialog()
        If Controlguardado.FileName = "" Then
            MsgBox("Para poder proceder a la creación del archivo se requiere un nombre")
            Exit Sub
        Else
            Dim FileName As String = Controlguardado.FileName
            'Try
            Using wri = PdfWriter.GetInstance(Doc, New FileStream(FileName, FileMode.Create))
                'Dim ev As New itsEventsNOVALIDOCOMOORDENPAGO
                'ev.NOVALIDO = ORDENDEPAGOS.novalido
                'wri.PageEvent = ev
                'Abrir el documento para el uso
                Doc.Open()
                'Insertar una página en blanco nueva
                Doc.NewPage()
                'ENCABEZADO
                'Crear tabla General para cargar los bordes
                Dim Tabla_total As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(1)
                Tabla_total.TotalWidth = Anchopagina - Doc.LeftMargin
                Tabla_total.LockedWidth = True
                Dim tamaniocolumna_total As Single() = New Single(0) {}
                tamaniocolumna_total(0) = Convert.ToSingle(Anchopagina - Doc.LeftMargin * 1)
                Tabla_total.SetWidths(tamaniocolumna_total)
                'Creación de la celda que manejaria cada uno de los cuadros
                Dim PARRAFOTOTAL As New iTextSharp.text.Paragraph()
                Dim PARRAFOCOMPLETO As New iTextSharp.text.Paragraph()
                Dim PARRAFOPARCIAL As New iTextSharp.text.Paragraph()
                Dim Phrasetemporal As New iTextSharp.text.Phrase()
                'Crear tabla para manejar los encabezados---------------------------------------------------------------------------------------------
                Dim Encabezadosx As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(2)
                Encabezadosx.TotalWidth = Anchopagina - Doc.LeftMargin
                Encabezadosx.LockedWidth = True
                'Declaración variable de ancho de columnas
                Dim tamaniocolumna As Single() = New Single(1) {}
                tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.2)
                tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.8)
                Encabezadosx.SetWidths(tamaniocolumna)
                'para insertar un espacio entre las celdas
                Dim PdfpCell_espaciovacio As iTextSharp.text.pdf.PdfPCell = New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("", PDF_fuente_variable(impresor.tamaniofuente, False))))
                PdfpCell_espaciovacio.BorderWidth = 0
                PdfpCell_espaciovacio.FixedHeight = 5.0F
                Dim PdfpCell_espaciovacioborde As iTextSharp.text.pdf.PdfPCell = New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("", PDF_fuente_variable(impresor.tamaniofuente, False))))
                PdfpCell_espaciovacioborde.BorderWidth = 0.5
                PdfpCell_espaciovacioborde.FixedHeight = 2.0F
                'crear imagen con logo a la izquierda
                Dim manejadorimagen As iTextSharp.text.Image = Image.GetInstance(My.Resources.Logo, System.Drawing.Imaging.ImageFormat.Jpeg)
                'asignar la imagen itextsharp a la celda
                Dim PdfPCell As iTextSharp.text.pdf.PdfPCell = New PdfPCell(manejadorimagen, True)
                PdfPCell.Rowspan = 2
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_LEFT
                PdfPCell.FixedHeight = 70.0F
                Encabezadosx.AddCell(PdfPCell)
                'Encabezado del año
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Encabezadodelyear(ORDENDEPAGOS.ordenpago_fecha.Year), PDF_fuente_variable(impresor.tamaniofuente, False))))
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                ' PdfPCell.FixedHeight = 25.0F
                Encabezadosx.AddCell(PdfPCell)
                '----------------------NOMBRE DEL SERVICIO ADMINISTRATIVO------------------------------
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Nombrecompletodelservicio.ToUpper, PDF_fuente_variable(impresor.tamaniofuente + 2, True))))
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.FixedHeight = 25.0F
                Encabezadosx.AddCell(PdfPCell)
                'Encabezadosx.AddCell(PdfpCell_espaciovacioborde)
                With PdfpCell_espaciovacio
                    .FixedHeight = 10.0F
                    .Colspan = Encabezadosx.NumberOfColumns
                End With
                Encabezadosx.AddCell(PdfpCell_espaciovacio)
                '----------------------AGREGA EL ENCABEZADO Completo------------------------------
                ' Frase_total.Clear()
                PARRAFOCOMPLETO.Add(Encabezadosx)
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
                PARRAFOCOMPLETO.Clear()
                'DATOS BÁSICOS ORDEN DE PAGO
                Dim Datosbasicosordenpago As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(4)
                Datosbasicosordenpago.TotalWidth = Anchopagina - Doc.LeftMargin
                Datosbasicosordenpago.LockedWidth = True
                Datosbasicosordenpago.PaddingTop = 5
                tamaniocolumna = New Single(3) {}
                tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.12)
                tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.12)
                tamaniocolumna(2) = Convert.ToSingle(Anchopagina * 0.38)
                tamaniocolumna(3) = Convert.ToSingle(Anchopagina * 0.38)
                Datosbasicosordenpago.SetWidths(tamaniocolumna)
                Datosbasicosordenpago.AddCell(Phrasepdf(" ORDEN DE PAGO ", impresor.tamaniofuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE,, "#c5c7c0"))
                Datosbasicosordenpago.AddCell(Phrasepdf("ORDEN DE PAGO Nº " & ORDENDEPAGOS.ordenpago_numero,
                                                        impresor.tamaniofuentetitulos, True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
                'TIPO O TIPOS DE INSTRUMENTO LEGAL
                Dim Tipo_instrumentolegal As New List(Of String)
                Select Case ORDENDEPAGOS.ORDENESPROVISION.Count
                    Case = 0
                        Datosbasicosordenpago.AddCell(Phrasepdf(" ",
                                                                    impresor.tamaniofuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                        Datosbasicosordenpago.AddCell(Phrasepdf(" ",
                                                                    impresor.tamaniofuente, True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
                    Case = 1
                        Datosbasicosordenpago.AddCell(Phrasepdf(ORDENDEPAGOS.ORDENESPROVISION(0).TipoInstrumentoLegal,
                                                                    impresor.tamaniofuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                        Datosbasicosordenpago.AddCell(Phrasepdf(" ", impresor.tamaniofuente,
                                                                    True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
                    Case Else
                        Dim Todostiposlegales As String = ""
                        For X = 0 To ORDENDEPAGOS.ORDENESPROVISION.Count - 1
                            If Not Tipo_instrumentolegal.Contains(ORDENDEPAGOS.ORDENESPROVISION(X).TipoInstrumentoLegal.ToUpper) Then
                                Tipo_instrumentolegal.Add(ORDENDEPAGOS.ORDENESPROVISION(X).TipoInstrumentoLegal.ToUpper)
                                If Tipo_instrumentolegal.Count > 1 Then
                                    Todostiposlegales += "/" & ORDENDEPAGOS.ORDENESPROVISION(X).TipoInstrumentoLegal
                                Else
                                    Todostiposlegales = ORDENDEPAGOS.ORDENESPROVISION(X).TipoInstrumentoLegal
                                End If
                            End If
                        Next
                        If Tipo_instrumentolegal.Count > 1 Then
                            Datosbasicosordenpago.AddCell(Phrasepdf(Todostiposlegales,
                                                                    impresor.tamaniofuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                            Datosbasicosordenpago.AddCell(Phrasepdf(" ", impresor.tamaniofuente,
                                                                    True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
                        Else
                            Datosbasicosordenpago.AddCell(Phrasepdf(ORDENDEPAGOS.ORDENESPROVISION(0).TipoInstrumentoLegal,
                                                                    impresor.tamaniofuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                            Datosbasicosordenpago.AddCell(Phrasepdf(" ", impresor.tamaniofuente,
                                                                    True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
                        End If
                        'For X = 0 To ORDENDEPAGOS.ORDENESPROVISION.Count - 1
                        '    If Not Tipo_instrumentolegal.Contains(ORDENDEPAGOS.ORDENESPROVISION(X).Tipo_instrumentolegal) Then
                        '        Tipo_instrumentolegal.Add(ORDENDEPAGOS.ORDENESPROVISION(X).Tipo_instrumentolegal)
                        '    End If
                        'Next
                        'If Tipo_instrumentolegal.Count > 1 Then
                        '    Datosbasicosordenpago.AddCell(Phrasepdf("* *",
                        '                                            impresor.tamaniofuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                        '    Datosbasicosordenpago.AddCell(Phrasepdf(" ", impresor.tamaniofuente,
                        '                                            True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
                        'Else
                        '    Datosbasicosordenpago.AddCell(Phrasepdf(ORDENDEPAGOS.ORDENESPROVISION(0).Tipo_instrumentolegal,
                        '                                            impresor.tamaniofuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                        '    Datosbasicosordenpago.AddCell(Phrasepdf(" ", impresor.tamaniofuente,
                        '                                            True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
                        'End If
                End Select
                Datosbasicosordenpago.AddCell(Phrasepdf(" AÑO ", impresor.tamaniofuente + 2, False, 0.5, 1, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                Datosbasicosordenpago.AddCell(Phrasepdf(" NÚMERO ", impresor.tamaniofuente + 2, False, 0.5, 1, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                Datosbasicosordenpago.AddCell(Phrasepdf(" ", impresor.tamaniofuente + 2, False, 0, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                'SE EFECTUA UN FORMATO PREVIO PARA MANEJAR LOS CASOS QUE CONTENGAN VARIAS ORDENES DE PROVISION DENTRO DE LA ORDEN DE PAGO..
                Dim numeroinstrumentolegal As New List(Of String)
                Dim anioinstrumentolegal As New List(Of String)
                Dim CONCATENADO As New List(Of String)
                Dim detallenumeroinstrumentolegal As String = ""
                Dim detalleanioinstrumentolegal As String = ""
                Select Case ORDENDEPAGOS.ORDENESPROVISION.Count
                    Case = 0
                        detallenumeroinstrumentolegal = ""
                        detalleanioinstrumentolegal = ""
                            'PdfPCell = New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(impresor.tamaniofuente, True))), 0.5, 2, 1, iTextSharp.text.Element.ALIGN_CENTER, 0))
                    Case = 1
                        detallenumeroinstrumentolegal = ORDENDEPAGOS.ORDENESPROVISION(0).NumeroInstrumentoLegal
                        detalleanioinstrumentolegal = ORDENDEPAGOS.ORDENESPROVISION(0).YearInstrumentoLegal
                        'PdfPCell = New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(ORDENDEPAGOS.ORDENESPROVISION(0).Numero_instrumentolegal, PDF_fuente_variable(impresor.tamaniofuente, False))), 0.5, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0))
                    Case Else
                        For Each op As OrdenProvision In ORDENDEPAGOS.ORDENESPROVISION
                            If Not (CONCATENADO.Contains(op.NumeroInstrumentoLegal & "/" & op.YearInstrumentoLegal)) Then
                                numeroinstrumentolegal.Add(op.NumeroInstrumentoLegal)
                                anioinstrumentolegal.Add(op.YearInstrumentoLegal)
                                CONCATENADO.Add(op.NumeroInstrumentoLegal & "/" & op.YearInstrumentoLegal)
                            End If
                        Next
                        For z = 0 To numeroinstrumentolegal.Count - 1
                            If z = numeroinstrumentolegal.Count - 1 Then
                                detallenumeroinstrumentolegal += numeroinstrumentolegal(z)
                                detalleanioinstrumentolegal += anioinstrumentolegal(z)
                            Else
                                detallenumeroinstrumentolegal += numeroinstrumentolegal(z) & vbCrLf
                                detalleanioinstrumentolegal += anioinstrumentolegal(z) & vbCrLf
                            End If
                        Next
                End Select
                PdfPCell = New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(detalleanioinstrumentolegal, PDF_fuente_variable(impresor.tamaniofuente + 2, False))), 0.5, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0))
                Datosbasicosordenpago.AddCell(PdfPCell)
                PdfPCell = New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(detallenumeroinstrumentolegal, PDF_fuente_variable(impresor.tamaniofuente + 2, False))), 0.5, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0))
                Datosbasicosordenpago.AddCell(PdfPCell)
                PdfPCell = New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(impresor.tamaniofuente + 2, False))), 0, 2, 1, iTextSharp.text.Element.ALIGN_CENTER, 0))
                Datosbasicosordenpago.AddCell(PdfPCell)
                PdfPCell = New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(impresor.tamaniofuente + 2, False))), 0, 4, 1, iTextSharp.text.Element.ALIGN_CENTER, 0))
                Datosbasicosordenpago.AddCell(PdfPCell)
                'Datosbasicosordenpago.AddCell(PdfpCell_espaciovacio)
                Datosbasicosordenpago.AddCell(Phrasepdf(" EXPEDIENTE ", impresor.tamaniofuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE,, "#c5c7c0"))
                Datosbasicosordenpago.AddCell(Phrasepdf("POSADAS, " & ORDENDEPAGOS.ordenpago_fecha.ToShortDateString, impresor.tamaniofuente + 2, False, 0, 2, 3, Element.ALIGN_CENTER, 4, Element.ALIGN_MIDDLE))
                Datosbasicosordenpago.AddCell(Phrasepdf("LETRA", impresor.tamaniofuente + 2, False, 0.5, 1, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                Datosbasicosordenpago.AddCell(Phrasepdf("NÚMERO", impresor.tamaniofuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                ''LETRA
                'Datosbasicosordenpago.AddCell(Phrasepdf(ORDENDEPAGOS.expediente_op.organismo.ToString, impresor.tamaniofuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 4, Element.ALIGN_MIDDLE))
                ''NUMERO
                'PdfPCell = New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(ORDENDEPAGOS.expediente_op.numero & "-" & ORDENDEPAGOS.expediente_op.year, PDF_fuente_variable(impresor.tamaniofuente, False))), 0.5, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0))
                'Datosbasicosordenpago.AddCell(PdfPCell)
                'NUMERO DE EXPEDIENTE
                Datosbasicosordenpago.AddCell(Phrasepdf(ORDENDEPAGOS.expediente_op.organismo.ToString, impresor.tamaniofuente + 1, True, 0.5, 1, 1, Element.ALIGN_CENTER, 4, Element.ALIGN_MIDDLE))
                Datosbasicosordenpago.AddCell(Phrasepdf(ORDENDEPAGOS.expediente_op.numero & "-" & ORDENDEPAGOS.expediente_op.year, impresor.tamaniofuente + 1, True, 0.5, 1, 1, Element.ALIGN_CENTER, 4, Element.ALIGN_MIDDLE))
                'EXPEDIENTE PRINCIPAL
                If ORDENDEPAGOS.ClaveExpediente_principal.ToString.Length = 13 Then
                    Datosbasicosordenpago.AddCell(Phrasepdf(" Autorizado por: ", impresor.tamaniofuente, False, 0.5, 2, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE))
                    Datosbasicosordenpago.AddCell(Phrasepdf(" ", impresor.tamaniofuente + 2, False, 0, 2, 3, Element.ALIGN_CENTER, 4, Element.ALIGN_MIDDLE))
                    Datosbasicosordenpago.AddCell(Phrasepdf(ORDENDEPAGOS.ClaveExpediente_principal.ToString.Substring(4, 4) & "-" &
                                                     Convert.ToInt32(ORDENDEPAGOS.ClaveExpediente_principal.ToString.Substring(8, 5)) & "/" &
                                                    ORDENDEPAGOS.ClaveExpediente_principal.ToString.Substring(0, 4), impresor.tamaniofuente, False, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                Else
                    Datosbasicosordenpago.AddCell(Phrasepdf("  ", impresor.tamaniofuente, True, 0, 2, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE))
                    Datosbasicosordenpago.AddCell(Phrasepdf(" ", impresor.tamaniofuente + 2, False, 0, 2, 3, Element.ALIGN_CENTER, 4, Element.ALIGN_MIDDLE))
                    Datosbasicosordenpago.AddCell(Phrasepdf(" ", impresor.tamaniofuente, False, 0, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                End If
                PARRAFOCOMPLETO.Add(Datosbasicosordenpago)
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
                'TEXTO DATOS BÁSICOS ORDEN DE PAGO
                PARRAFOPARCIAL.Clear()
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("De acuerdo con la orden precedente se liquida para ser abonado por la Tesorería del " &
                                                                 Autorizaciones.Nombrecompletodelservicio &
                                                                 " a favor de: ", PDF_fuente_variable(impresor.tamaniofuente + 1, False)))
                Dim LISTADECUITS As New List(Of String)
                Select Case ORDENDEPAGOS.ORDENESPROVISION.Count
                    Case = 0
                        PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("           " & vbCrLf, PDF_fuente_variable(impresor.tamaniofuente + 2, True)))
                    Case = 1
                        PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(ORDENDEPAGOS.ORDENESPROVISION(0).Nombre & vbCrLf, PDF_fuente_variable(impresor.tamaniofuente + 2, True)))
                    Case Else
                        For X = 0 To ORDENDEPAGOS.ORDENESPROVISION.Count - 1
                            If Not LISTADECUITS.Contains(ORDENDEPAGOS.ORDENESPROVISION(X).Nombre) Then
                                LISTADECUITS.Add(ORDENDEPAGOS.ORDENESPROVISION(X).Nombre)
                            End If
                        Next
                        If LISTADECUITS.Count > 1 Then
                            PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("Varios Beneficiarios " & vbCrLf, PDF_fuente_variable(impresor.tamaniofuente + 2, True)))
                        Else
                            PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(ORDENDEPAGOS.ORDENESPROVISION(0).Nombre & vbCrLf, PDF_fuente_variable(impresor.tamaniofuente + 2, True)))
                        End If
                End Select
                'CONCEPTO DE'
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("A su orden en concepto de:", PDF_fuente_variable(impresor.tamaniofuente + 2, False)))
                'TIPO DE ORDEN DE PAGO
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(ORDENDEPAGOS.Ordenpago_tipo, PDF_fuente_variable(impresor.tamaniofuente + 2, True)))
                PARRAFOPARCIAL.FirstLineIndent = tamaniocolumna(0) + tamaniocolumna(1)
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOPARCIAL, 0, 1, 1, 0, 3)))
                With PdfpCell_espaciovacio
                    .FixedHeight = 10.0F
                    .Colspan = Tabla_total.NumberOfColumns
                End With
                Tabla_total.AddCell(PdfpCell_espaciovacio)
                'CUADRO DETALLE
                Dim cantidadcolumnas As Integer = 18
                Dim textoprimercuadro As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(cantidadcolumnas)
                textoprimercuadro.TotalWidth = Anchopagina - Doc.LeftMargin
                textoprimercuadro.LockedWidth = True
                tamaniocolumna = New Single(cantidadcolumnas - 1) {}
                For i = 0 To cantidadcolumnas - 1
                    tamaniocolumna(i) = Convert.ToSingle(Anchopagina / cantidadcolumnas)
                Next
                'tamaniocolumna(1) = Convert.ToSingle(Anchopagina / cantidadcolumnas)
                'tamaniocolumna(2) = Convert.ToSingle(Anchopagina / cantidadcolumnas)
                'tamaniocolumna(3) = Convert.ToSingle(Anchopagina / cantidadcolumnas)
                'tamaniocolumna(4) = Convert.ToSingle(Anchopagina / cantidadcolumnas)
                'tamaniocolumna(5) = Convert.ToSingle(Anchopagina / cantidadcolumnas)
                'tamaniocolumna(6) = Convert.ToSingle(Anchopagina / cantidadcolumnas)
                'tamaniocolumna(7) = Convert.ToSingle(Anchopagina / cantidadcolumnas)
                'tamaniocolumna(8) = Convert.ToSingle(Anchopagina / cantidadcolumnas)
                'tamaniocolumna(9) = Convert.ToSingle(Anchopagina / cantidadcolumnas)
                'tamaniocolumna(10) = Convert.ToSingle(Anchopagina / cantidadcolumnas)
                'tamaniocolumna(11) = Convert.ToSingle(Anchopagina / cantidadcolumnas)
                'tamaniocolumna(12) = Convert.ToSingle(Anchopagina / cantidadcolumnas)
                'tamaniocolumna(13) = Convert.ToSingle(Anchopagina / cantidadcolumnas)
                'tamaniocolumna(14) = Convert.ToSingle(Anchopagina / cantidadcolumnas)
                'tamaniocolumna(15) = Convert.ToSingle(Anchopagina / cantidadcolumnas)
                'tamaniocolumna(16) = Convert.ToSingle(Anchopagina / cantidadcolumnas)
                'tamaniocolumna(17) = Convert.ToSingle(Anchopagina / cantidadcolumnas)
                textoprimercuadro.SetWidths(tamaniocolumna)
                'textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(textodetalle, PDF_fuente_variable(impresor.tamaniofuente, False))), 0, 4, 1, iTextSharp.text.Element.ALIGN_JUSTIFIED)))
                textoprimercuadro.AddCell(Phrasepdf(ORDENDEPAGOS.ordenpago_Detalle, impresor.tamaniofuente, False, 0, cantidadcolumnas, 1, Element.ALIGN_JUSTIFIED, 3,, 50))
                textoprimercuadro.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(texto_cuadroordenpago(ORDENDEPAGOS, impresor, cantidadcolumnas, textoprimercuadro.TotalWidth), 0, cantidadcolumnas)))
                ''DETERMINAR QUE CAMPOS ESTAN COMPLETADOS
                ''************************************************************** REFACTORIZAR*****************************************************************************************
                'Dim TIENE_EFECTOR As Boolean = False
                'Dim TIENE_PERIODO As Boolean = False
                'Dim TIENE_DETALLE As Boolean = False
                'Dim TIENE_ANTICIPO As Boolean = False
                'Dim SUBTOTAL As Decimal = 0
                'If ORDENDEPAGOS.ACTAS.Count > 0 Then
                '    For Each ACTA In ORDENDEPAGOS.ACTAS
                '        If ACTA.ACTARECEPCION_ANTICIPO > 0 Then
                '            TIENE_ANTICIPO = True
                '        End If
                '        If ACTA.ACTARECEPCION_DETALLE.Length > 0 Then
                '            TIENE_DETALLE = True
                '        End If
                '        If ACTA.ACTARECEPCION_EFECTOR.Length > 0 Then
                '            TIENE_EFECTOR = True
                '        End If
                '        If ACTA.ACTARECEPCION_PERIODO.Length > 0 Then
                '            TIENE_PERIODO = True
                '        End If
                '        SUBTOTAL += ACTA.ACTARECEPCION_MONTO + ACTA.ACTARECEPCION_MULTA_MONTO
                '    Next
                '    Dim Con_multa As Boolean = False
                '    For Each ACTAD In ORDENDEPAGOS.ACTAS
                '        If ACTAD.ACTARECEPCION_MULTA_MONTO <> 0 Then
                '            Con_multa = True
                '            Exit For
                '        End If
                '    Next
                '    If TIENE_ANTICIPO And Not Con_multa Then
                '        textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("O. PROV.", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '        textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("ACTA RECEPCION Nº", PDF_fuente_variable(impresor.tamaniofuentetablas, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '        textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("ANTICIPO", PDF_fuente_variable(impresor.tamaniofuentetablas, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '        textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("IMPORTE", PDF_fuente_variable(impresor.tamaniofuentetablas, True))), 0, 3, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '        textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("SALDO A PAGAR", PDF_fuente_variable(impresor.tamaniofuentetablas, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '        For Each ACTAD In ORDENDEPAGOS.ACTAS
                '            textoprimercuadro.AddCell(Phrasepdf(
                '                                          CType(ACTAD.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(8, 5), Integer) &
                '                                          "/" &
                '                                          ACTAD.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(0, 4),
                '                                          impresor.tamaniofuentetablas, False, 0, 1, 1, Element.ALIGN_CENTER, 1))
                '            textoprimercuadro.AddCell(Phrasepdf(ACTAD.ACTARECEPCION_NUMERO & "/" & ACTAD.ACTARECEPCION_YEAR, impresor.tamaniofuentetablas, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
                '            textoprimercuadro.AddCell(Phrasepdf(ACTAD.ACTARECEPCION_ANTICIPO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), impresor.tamaniofuentetablas, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
                '            textoprimercuadro.AddCell(Phrasepdf(ACTAD.ACTARECEPCION_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), impresor.tamaniofuentetablas, False, 0, 3, 1, Element.ALIGN_CENTER, 2))
                '            textoprimercuadro.AddCell(Phrasepdf((ACTAD.ACTARECEPCION_MONTO - ACTAD.ACTARECEPCION_ANTICIPO).ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), impresor.tamaniofuentetablas, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
                '            'Select Case ACTAD.ACTARECEPCION_MULTA_MONTO <> 0
                '            '    Case True
                '            '        textoprimercuadro.AddCell(Phrasepdf(" ", impresor.tamaniofuentetablas, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
                '            '        textoprimercuadro.AddCell(Phrasepdf(ACTAD.ACTARECEPCION_MULTA_RESOLUCION, impresor.tamaniofuentetablas, False, 0, 2, 1, Element.ALIGN_CENTER, 0))
                '            '        textoprimercuadro.AddCell(Phrasepdf(ACTAD.ACTARECEPCION_MULTA_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), impresor.tamaniofuentetablas, False, 0, 3, 1, Element.ALIGN_CENTER, 2))
                '            '    Case False
                '            'End Select
                '        Next
                '    Else
                '        If TIENE_DETALLE And TIENE_EFECTOR And TIENE_PERIODO And Not Con_multa Then
                '            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("EFECTOR", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            If LISTADECUITS.Count > 1 Then
                '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("PROVEEDOR", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            End If
                '            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("PERIODO", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("O. PROV.", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("ACTA RECEPCION Nº", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            If LISTADECUITS.Count > 1 Then
                '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("DETALLE", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            Else
                '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("DETALLE", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0, 2, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            End If
                '            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("IMPORTE", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            For Each ACTAS In ORDENDEPAGOS.ACTAS
                '                textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_EFECTOR, impresor.tamaniofuentetablas, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
                '                If LISTADECUITS.Count > 1 Then
                '                    textoprimercuadro.AddCell(Phrasepdf(nombredevariosproveedores(ORDENDEPAGOS, ACTAS, LISTADECUITS), impresor.tamaniofuentetablas - 1, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
                '                End If
                '                textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_PERIODO, impresor.tamaniofuentetablas, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
                '                textoprimercuadro.AddCell(Phrasepdf(
                '                                          CType(ACTAS.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(8, 5), Integer) &
                '                                          "/" &
                '                                          ACTAS.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(0, 4),
                '                                          impresor.tamaniofuentetablas, False, 0, 1, 1, Element.ALIGN_CENTER, 1))
                '                textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_NUMERO & "/" & ACTAS.ACTARECEPCION_YEAR, impresor.tamaniofuentetablas, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
                '                If LISTADECUITS.Count > 1 Then
                '                    textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_DETALLE, impresor.tamaniofuentetablas, False, 0, 1, 1, Element.ALIGN_CENTER, 1))
                '                Else
                '                    textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_DETALLE, impresor.tamaniofuentetablas, False, 0, 2, 1, Element.ALIGN_CENTER, 1))
                '                End If
                '                textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), impresor.tamaniofuentetablas, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
                '                Select Case ACTAS.ACTARECEPCION_MULTA_MONTO <> 0
                '                    Case True
                '                        textoprimercuadro.AddCell(Phrasepdf(" ", impresor.tamaniofuentetablas, False, 0, 4, 1, Element.ALIGN_CENTER, 0))
                '                        textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MULTA_RESOLUCION, impresor.tamaniofuentetablas, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
                '                        textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MULTA_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), impresor.tamaniofuentetablas, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
                '                    Case False
                '                End Select
                '            Next
                '        ElseIf TIENE_DETALLE And TIENE_EFECTOR And Not Con_multa Then
                '            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("EFECTOR", PDF_fuente_variable(impresor.tamaniofuentetablas, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            If LISTADECUITS.Count > 1 Then
                '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("PROVEEDOR", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            End If
                '            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("O. PROV.", PDF_fuente_variable(impresor.tamaniofuentetablas, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("ACTA RECEPCION Nº", PDF_fuente_variable(impresor.tamaniofuentetablas, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            If LISTADECUITS.Count > 1 Then
                '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("DETALLE", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0, 2, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            Else
                '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("DETALLE", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0, 3, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            End If
                '            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("IMPORTE", PDF_fuente_variable(impresor.tamaniofuentetablas, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            For Each ACTAS In ORDENDEPAGOS.ACTAS
                '                textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_EFECTOR, impresor.tamaniofuentetablas, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
                '                If LISTADECUITS.Count > 1 Then
                '                    textoprimercuadro.AddCell(Phrasepdf(nombredevariosproveedores(ORDENDEPAGOS, ACTAS, LISTADECUITS), impresor.tamaniofuentetablas - 1, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
                '                End If
                '                textoprimercuadro.AddCell(Phrasepdf(
                '                                          CType(ACTAS.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(8, 5), Integer) &
                '                                          "/" &
                '                                          ACTAS.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(0, 4),
                '                                          impresor.tamaniofuentetablas, False, 0, 1, 1, Element.ALIGN_CENTER, 1))
                '                textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_NUMERO & "/" & ACTAS.ACTARECEPCION_YEAR, impresor.tamaniofuentetablas, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
                '                If LISTADECUITS.Count > 1 Then
                '                    textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_DETALLE, impresor.tamaniofuentetablas, False, 0, 2, 1, Element.ALIGN_CENTER, 1))
                '                Else
                '                    textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_DETALLE, impresor.tamaniofuentetablas, False, 0, 3, 1, Element.ALIGN_CENTER, 1))
                '                End If
                '                textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), impresor.tamaniofuentetablas, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
                '                Select Case ACTAS.ACTARECEPCION_MULTA_MONTO <> 0
                '                    Case True
                '                        textoprimercuadro.AddCell(Phrasepdf(" ", impresor.tamaniofuentetablas, False, 0, 3, 1, Element.ALIGN_CENTER, 0))
                '                        textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MULTA_RESOLUCION, impresor.tamaniofuentetablas, False, 0, 2, 1, Element.ALIGN_CENTER, 0))
                '                        textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MULTA_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), impresor.tamaniofuentetablas, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
                '                    Case False
                '                End Select
                '            Next
                '        ElseIf TIENE_DETALLE And TIENE_PERIODO And Not Con_multa Then
                '            If LISTADECUITS.Count > 1 Then
                '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("PROVEEDOR", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            End If
                '            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("O. PROV.", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("PERIODO", PDF_fuente_variable(impresor.tamaniofuentetablas, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("ACTA RECEPCION Nº", PDF_fuente_variable(impresor.tamaniofuentetablas, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            If LISTADECUITS.Count > 1 Then
                '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("DETALLE", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            Else
                '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("DETALLE", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0, 2, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            End If
                '            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("IMPORTE", PDF_fuente_variable(impresor.tamaniofuentetablas, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            For Each ACTAS In ORDENDEPAGOS.ACTAS
                '                If LISTADECUITS.Count > 1 Then
                '                    textoprimercuadro.AddCell(Phrasepdf(nombredevariosproveedores(ORDENDEPAGOS, ACTAS, LISTADECUITS), impresor.tamaniofuentetablas - 1, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
                '                End If
                '                textoprimercuadro.AddCell(Phrasepdf(
                '                                          CType(ACTAS.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(8, 5), Integer) &
                '                                          "/" &
                '                                          ACTAS.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(0, 4),
                '                                          impresor.tamaniofuentetablas, False, 0, 1, 1, Element.ALIGN_CENTER, 1))
                '                textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_PERIODO, impresor.tamaniofuentetablas, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
                '                textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_NUMERO & "/" & ACTAS.ACTARECEPCION_YEAR, impresor.tamaniofuentetablas, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
                '                If LISTADECUITS.Count > 1 Then
                '                    textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_DETALLE, impresor.tamaniofuentetablas, False, 0, 1, 1, Element.ALIGN_CENTER, 1))
                '                Else
                '                    textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_DETALLE, impresor.tamaniofuentetablas, False, 0, 2, 1, Element.ALIGN_CENTER, 1))
                '                End If
                '                textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), impresor.tamaniofuentetablas, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
                '                Select Case ACTAS.ACTARECEPCION_MULTA_MONTO <> 0
                '                    Case True
                '                        textoprimercuadro.AddCell(Phrasepdf(" ", impresor.tamaniofuentetablas, False, 0, 2, 1, Element.ALIGN_CENTER, 0))
                '                        textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MULTA_RESOLUCION, impresor.tamaniofuentetablas, False, 0, 3, 1, Element.ALIGN_CENTER, 0))
                '                        textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MULTA_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), impresor.tamaniofuentetablas, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
                '                    Case False
                '                End Select
                '            Next
                '        ElseIf TIENE_DETALLE And Not Con_multa Then
                '            If LISTADECUITS.Count > 1 Then
                '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("PROVEEDOR", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            End If
                '            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("O. PROV.", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("ACTA RECEPCION Nº", PDF_fuente_variable(impresor.tamaniofuentetablas, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            If LISTADECUITS.Count > 1 Then
                '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("DETALLE", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0, 3, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            Else
                '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("DETALLE", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0, 4, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            End If
                '            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("IMPORTE", PDF_fuente_variable(impresor.tamaniofuentetablas, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            For Each ACTAS In ORDENDEPAGOS.ACTAS
                '                If LISTADECUITS.Count > 1 Then
                '                    textoprimercuadro.AddCell(Phrasepdf(nombredevariosproveedores(ORDENDEPAGOS, ACTAS, LISTADECUITS), impresor.tamaniofuentetablas - 1, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
                '                End If
                '                textoprimercuadro.AddCell(Phrasepdf(
                '                                          CType(ACTAS.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(8, 5), Integer) &
                '                                          "/" &
                '                                          ACTAS.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(0, 4),
                '                                          impresor.tamaniofuentetablas, False, 0, 1, 1, Element.ALIGN_CENTER, 1))
                '                textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_NUMERO & "/" & ACTAS.ACTARECEPCION_YEAR, impresor.tamaniofuentetablas, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
                '                If LISTADECUITS.Count > 1 Then
                '                    textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_DETALLE, impresor.tamaniofuentetablas, False, 0, 3, 1, Element.ALIGN_CENTER, 0))
                '                Else
                '                    textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_DETALLE, impresor.tamaniofuentetablas, False, 0, 4, 1, Element.ALIGN_CENTER, 0))
                '                End If
                '                textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), impresor.tamaniofuentetablas, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
                '                Select Case ACTAS.ACTARECEPCION_MULTA_MONTO <> 0
                '                    Case True
                '                        textoprimercuadro.AddCell(Phrasepdf(" ", impresor.tamaniofuentetablas, False, 0, 2, 1, Element.ALIGN_CENTER, 0))
                '                        textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MULTA_RESOLUCION, impresor.tamaniofuentetablas, False, 0, 3, 1, Element.ALIGN_CENTER, 0))
                '                        textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MULTA_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), impresor.tamaniofuentetablas, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
                '                    Case False
                '                End Select
                '            Next
                '        Else
                '            'total de columnas 7
                '            Dim columnas As Integer = 7
                '            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("O. PROV.", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0, 2, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("ACTA RECEPCION Nº", PDF_fuente_variable(impresor.tamaniofuentetablas, True))), 0, 2, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            For Each ACTAD In ORDENDEPAGOS.ACTAS
                '                If ACTAD.ACTARECEPCION_MULTA_MONTO <> 0 Then
                '                    textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("O. PROV.", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '                    textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("ACTA RECEPCION Nº", PDF_fuente_variable(impresor.tamaniofuentetablas, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '                    columnas = columnas - 6
                '                    Exit For
                '                End If
                '            Next
                '            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("IMPORTE", PDF_fuente_variable(impresor.tamaniofuentetablas, True))), 0, columnas, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                '            For Each ACTAD In ORDENDEPAGOS.ACTAS
                '                textoprimercuadro.AddCell(Phrasepdf(
                '                                              CType(ACTAD.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(8, 5), Integer) &
                '                                              "/" &
                '                                              ACTAD.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(0, 4),
                '                                              impresor.tamaniofuentetablas, False, 0, 2, 1, Element.ALIGN_CENTER, 1))
                '                textoprimercuadro.AddCell(Phrasepdf(ACTAD.ACTARECEPCION_NUMERO & "/" & ACTAD.ACTARECEPCION_YEAR, impresor.tamaniofuentetablas, False, 0, 2, 1, Element.ALIGN_CENTER, 0))
                '                textoprimercuadro.AddCell(Phrasepdf(ACTAD.ACTARECEPCION_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), impresor.tamaniofuentetablas, False, 0, 3, 1, Element.ALIGN_CENTER, 2))
                '                Select Case ACTAD.ACTARECEPCION_MULTA_MONTO <> 0
                '                    Case True
                '                        textoprimercuadro.AddCell(Phrasepdf(" ", impresor.tamaniofuentetablas, False, 0, 2, 1, Element.ALIGN_CENTER, 0))
                '                        textoprimercuadro.AddCell(Phrasepdf(ACTAD.ACTARECEPCION_MULTA_RESOLUCION, impresor.tamaniofuentetablas, False, 0, 2, 1, Element.ALIGN_CENTER, 0))
                '                        textoprimercuadro.AddCell(Phrasepdf(ACTAD.ACTARECEPCION_MULTA_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), impresor.tamaniofuentetablas, False, 0, 3, 1, Element.ALIGN_CENTER, 2))
                '                    Case False
                '                End Select
                '            Next
                '        End If
                '        If ORDENDEPAGOS.ACTAS.Count > 1 Then
                '            With PdfpCell_espaciovacio
                '                .FixedHeight = 10.0F
                '                .Colspan = textoprimercuadro.NumberOfColumns - 2
                '            End With
                '            textoprimercuadro.AddCell(PdfpCell_espaciovacio)
                '            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(impresor.tamaniofuentetablas, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER)))
                '            With textoprimercuadro.AddCell(Phrasepdf(SUBTOTAL.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), impresor.tamaniofuentetablas, False, 0, 1, 1, Element.ALIGN_CENTER, 1))
                '                .Border = PdfPCell.TOP_BORDER
                '                .BorderWidth = 0.5
                '                .PaddingTop = 2
                '            End With
                '        End If
                '    End If
                'End If
                If ORDENDEPAGOS.ordenpago_Detalle2.Length > 0 Then
                    textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Observaciones:" & ORDENDEPAGOS.ordenpago_Detalle2, PDF_fuente_variable(impresor.tamaniofuente, False))), 0, textoprimercuadro.NumberOfColumns, 1, iTextSharp.text.Element.ALIGN_CENTER)))
                End If
                '************************************************************** REFACTORIZAR*****************************************************************************************
                With PdfpCell_espaciovacio
                    .FixedHeight = 10.0F
                    .Colspan = textoprimercuadro.NumberOfColumns
                End With
                textoprimercuadro.AddCell(PdfpCell_espaciovacio)
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(textoprimercuadro, 0.5)))
                Dim Totalsumado As Decimal = 0
                'SUMA TOTAL DE PEDIDO DE FONDO Y TEXTO
                For X = 0 To ORDENDEPAGOS.DatosOrdenPago.Rows.Count - 1
                    Totalsumado += CType(ORDENDEPAGOS.DatosOrdenPago.Rows(X).Item(11), Decimal)
                Next
                Tabla_total.AddCell(Phrasepdf(" La suma de Pesos " & Totalsumado.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")) & ".-", impresor.tamaniofuente, True, 0, 1, 1, Element.ALIGN_JUSTIFIED, 2, Element.ALIGN_MIDDLE, 200))
                Tabla_total.AddCell(Phrasepdf("Son Pesos:  " & Inicio.Num2Text(Math.Truncate(Convert.ToDecimal(Totalsumado))) & " CON " &
                    ((Convert.ToDecimal(Totalsumado) - Math.Truncate(Convert.ToDecimal(Totalsumado))) * 100).ToString("00") & "/100.-", impresor.tamaniofuente, False, 0, 11, 1, Element.ALIGN_JUSTIFIED, 2, Element.ALIGN_MIDDLE))
                Tabla_total.AddCell(Phrasepdf(" QUE SE IMPUTARAN DE LA SIGUIENTE MANERA: CUENTA " & CUENTA_PDF(ORDENDEPAGOS.DatosOrdenPago.Rows(0).Item(2)), impresor.tamaniofuente, True, 0, 1, 1, Element.ALIGN_LEFT, 2, Element.ALIGN_MIDDLE, 0))
                'TABLA DE PARTIDAS PRESUPUESTARIAS
                'para lograr la adaptación completa debo disminuir el margen necesario
                Dim anchoutil As Single = Anchopagina - Doc.LeftMargin
                tamaniocolumna = New Single(11) {}
                tamaniocolumna(0) = Convert.ToSingle(anchoutil * 0.05) 'jur.1
                tamaniocolumna(1) = Convert.ToSingle(anchoutil * 0.05) 'UO1
                tamaniocolumna(2) = Convert.ToSingle(anchoutil * 0.0843) 'CARAC
                tamaniocolumna(3) = Convert.ToSingle(anchoutil * 0.0581) ' FIN
                tamaniocolumna(4) = Convert.ToSingle(anchoutil * 0.0581) ' FUN.
                tamaniocolumna(5) = Convert.ToSingle(anchoutil * 0.0681) 'SECC
                tamaniocolumna(6) = Convert.ToSingle(anchoutil * 0.0681) 'SECT
                tamaniocolumna(7) = Convert.ToSingle(anchoutil * 0.0891) ' PDA PCIAL
                tamaniocolumna(8) = Convert.ToSingle(anchoutil * 0.0681) ' PDA PPAL
                tamaniocolumna(9) = Convert.ToSingle(anchoutil * 0.0681) 'SCD
                tamaniocolumna(10) = Convert.ToSingle(anchoutil * 0.0881) 'PDA SUB PAR
                tamaniocolumna(11) = Convert.ToSingle(anchoutil * 0.22) 'IMPORTE
                Dim TABLAORDENDEPAGO As iTextSharp.text.pdf.PdfPTable = PDFDatatablepartidapresupuestaria(ORDENDEPAGOS.DatosOrdenPago, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#ffffff")), impresor.tamaniofuente + 1)
                'VISTO LA LIQUIDACIÓN, ORDEN DE PAGO
                Doc.Add(Tabla_total)
                '     Doc.Add(PARRAFOPARCIAL)
                If TABLAORDENDEPAGO.Rows.Count > 1 And Not ORDENDEPAGOS.novalido Then
                    With PdfpCell_espaciovacio
                        .FixedHeight = 7.0F
                        .Colspan = TABLAORDENDEPAGO.NumberOfColumns
                    End With
                    TABLAORDENDEPAGO.AddCell(PdfpCell_espaciovacio)
                    TABLAORDENDEPAGO.AddCell(Phrasepdf(" Total: ", impresor.tamaniofuente + 1, True, 0, TABLAORDENDEPAGO.NumberOfColumns - 1, 1, Element.ALIGN_RIGHT, 0))
                    With TABLAORDENDEPAGO.AddCell(Phrasepdf(Totalsumado.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), impresor.tamaniofuente + 1, True, 0, 1, 1, Element.ALIGN_RIGHT, 1))
                        .Border = PdfPCell.TOP_BORDER
                        .BorderWidth = 1
                        .PaddingTop = 0
                    End With
                End If
                TABLAORDENDEPAGO.SpacingAfter = 1
                Doc.Add(TABLAORDENDEPAGO)
                'Dim COLUMNA As New ColumnText(wri.DirectContent)
                'the Phrase
                'the lower left x corner (left)
                'the lower left y corner (bottom)
                'the upper right x corner (right)
                'the upper right y corner (top)
                'line height(leading)
                'alignment.
                Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.GRAY)
                TABLAORDENDEPAGO = New PdfPTable(10)
                tamaniocolumna = New Single(9) {}
                For x = 0 To 9
                    tamaniocolumna(x) = Convert.ToSingle(anchoutil * 0.1)
                Next
                TABLAORDENDEPAGO.TotalWidth = anchoutil
                TABLAORDENDEPAGO.SetWidths(tamaniocolumna)
                TABLAORDENDEPAGO.LockedWidth = True
                TABLAORDENDEPAGO.AddCell(Phrasepdf(Iniciales(ORDENDEPAGOS.ordenpago_USUARIO), 6, True, 0, 1, 1, Element.ALIGN_LEFT, 0, Element.ALIGN_TOP))
                Doc.Add(TABLAORDENDEPAGO)
                '  Dim TABLAINICIALES As iTextSharp.text.pdf.PdfPTable = PDFDatatable(New DataTable, tamaniocolumna, 1, Anchopagina - Doc.LeftMargin, False, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#ffffff")), 8)
                Doc.Add(TABLA_INICIALES(anchoutil, ORDENDEPAGOS.ordenpago_USUARIO))
                Dim LISTADETEXTO As New List(Of Chunk)
                PARRAFOCOMPLETO.Clear()
                LISTADETEXTO.Add(New Chunk("VISTO: ", PDF_fuente_variable(impresor.tamaniofuente, True)))
                LISTADETEXTO.Add(New Chunk("La liquidación que antecede, téngase por ", PDF_fuente_variable(impresor.tamaniofuente, False)))
                LISTADETEXTO.Add(New Chunk("ORDEN de  PAGO ", PDF_fuente_variable(impresor.tamaniofuente, True)))
                LISTADETEXTO.Add(New Chunk("y abónese de conformidad a la misma. Gírese a la Tesorería para su cumplimiento.", PDF_fuente_variable(impresor.tamaniofuente, False)))
                For Each ITEM As Chunk In LISTADETEXTO
                    PARRAFOCOMPLETO.Add(ITEM)
                Next
                PARRAFOCOMPLETO.Alignment = Element.ALIGN_JUSTIFIED
                Doc.Add(PARRAFOCOMPLETO)
                If Not ORDENDEPAGOS.novalido Then
                    PARRAFOCOMPLETO.Clear()
                    With PARRAFOCOMPLETO
                        .Add(PDFFIRMASv2(Anchopagina - Doc.LeftMargin, impresor.Sello_Contabilidad, impresor.Sello_direccion, 85))
                        '   .Add(PDFFIRMAS(Anchopagina - Doc.LeftMargin, "CONTABILIDAD", "Director",, 85))
                        .Add(PDFFIRMASv2(Anchopagina - Doc.LeftMargin, impresor.Sello_Delegadofiscal, Nothing, 85))
                        ' .Add(PDFFIRMAS(Anchopagina - Doc.LeftMargin, "DELEGADO FISCAL", "",, 85))
                    End With
                    Doc.Add(PARRAFOCOMPLETO)
                Else
                    'Dim PRUEBA As PdfStamper = Nothing
                    'PRUEBA.AddSignature("PRUEBA",
                    '                    1, Doc.Left, Doc.Bottom, Doc.Right, 55)
                    'With PRUEBA
                    '    .
                    'End With
                    Dim COLUMNA0 As New ColumnText(wri.DirectContent)
                    'the Phrase
                    'the lower left x corner (left)
                    'the lower left y corner (bottom)
                    'the upper right x corner (right)
                    'the upper right y corner (top)
                    'line height(leading)
                    'alignment.
                    COLUMNA0.SetSimpleColumn(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("NO VALIDO COMO ORDEN DE PAGO", PDF_fuente_variable(25, True))),
                                            Doc.Left, Doc.Bottom,
                                          Doc.Right, Doc.PageSize.Height / 3,
                                            15, Element.ALIGN_JUSTIFIED_ALL)
                    COLUMNA0.Go()
                End If
                TABLAORDENDEPAGO = New PdfPTable(10)
                tamaniocolumna = New Single(9) {}
                For x = 0 To 9
                    tamaniocolumna(x) = Convert.ToSingle(anchoutil * 0.1)
                Next
                TABLAORDENDEPAGO.TotalWidth = anchoutil
                TABLAORDENDEPAGO.SetWidths(tamaniocolumna)
                TABLAORDENDEPAGO.LockedWidth = True
                TABLAORDENDEPAGO.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(ORDENDEPAGOS.CLASE_FONDO, PDF_fuente_variable(impresor.tamaniofuente + 4, True))), 0, 10, 1, iTextSharp.text.Element.ALIGN_RIGHT, 0)))
                Doc.Add(TABLAORDENDEPAGO)
                Dim COLUMNA2 As New ColumnText(wri.DirectContent)
                'the Phrase
                'the lower left x corner (left)
                'the lower left y corner (bottom)
                'the upper right x corner (right)
                'the upper right y corner (top)
                'line height(leading)
                'alignment.
                COLUMNA2.SetSimpleColumn(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("SICyF", font12Bold)),
                                        Doc.Left, Doc.Bottom,
                                      Doc.Right, 0,
                                        15, Element.ALIGN_RIGHT)
                COLUMNA2.Go()
                Doc.Close()
            End Using
            Select Case MsgBox("Abrir el archivo generado?", MsgBoxStyle.YesNoCancel, " ")
                Case MsgBoxResult.Yes
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(Controlguardado.FileName) With {
                                                 .UseShellExecute = True
        })
            End Select
            'Catch ex As Exception
            '    MessageBox.Show("NO SE PUDO GENERAR EL ARCHIVO" & vbCrLf & ex.Message)
            'End Try
        End If
    End Sub

    Private Function nombredevariosproveedores(ByVal ORDENDEPAGOS As Ordendepago, ByVal Actas As ACTARECEPCION, ByVal LISTADECUITS As List(Of String)) As String
        Dim texto As String = ""
        If LISTADECUITS.Count > 1 Then
            For Each oprov As OrdenProvision In ORDENDEPAGOS.ORDENESPROVISION
                If oprov.ClaveOrdenProvision = Actas.ACTARECEPCION_CLAVE_ORDENPROVISION Then
                    texto = oprov.Nombre
                End If
            Next
        End If
        Return texto
    End Function

    Private Function texto_cuadroordenpago(ByVal ordendepagos As Ordendepago, ByVal impresor As Impresion, ByVal cantidadcolumnas As Integer, ByVal Anchototal As Single) As PdfPTable
        Dim Tamaniounitario As Single = 0
        Dim LISTADECUITS As New List(Of String)
        Dim Detalle As Integer = 0
        Dim Efector As Integer = 0
        Dim Periodo As Integer = 0
        Dim Anticipo As Integer = 0
        Dim Multa As Integer = 0
        Dim Multa_resolucion As Integer = 0
        Dim oprov As Integer = 0
        Dim actarecepcion As Integer = 0
        Dim Importe As Integer = 0
        Dim SUBTOTAL As Decimal = 0
        Dim tablapdf As New PdfPTable(cantidadcolumnas)
        tablapdf.TotalWidth = Anchototal - 2
        tablapdf.LockedWidth = True
        tamaniocolumna = New Single(cantidadcolumnas - 1) {}
        For i = 0 To cantidadcolumnas - 1
            tamaniocolumna(i) = Convert.ToSingle(Anchototal / cantidadcolumnas)
        Next
        tablapdf.SetWidths(tamaniocolumna)
        For Each ACTA In ordendepagos.ACTAS
            If Not (LISTADECUITS.Contains(ACTA.ACTARECEPCION_CUIT)) Then
                LISTADECUITS.Add(ACTA.ACTARECEPCION_CUIT)
            End If
            If ACTA.ACTARECEPCION_DETALLE.Length > 0 Then
                Detalle = cantidadcolumnas
            End If
            If ACTA.ACTARECEPCION_EFECTOR.Length > 0 Then
                Efector = cantidadcolumnas
            End If
            If ACTA.ACTARECEPCION_PERIODO.Length > 0 Then
                Periodo = cantidadcolumnas
            End If
            If ACTA.ACTARECEPCION_ANTICIPO > 0 Then
                Anticipo = cantidadcolumnas
            End If
            If ACTA.ACTARECEPCION_MULTA_MONTO <> 0 Then
                Multa = cantidadcolumnas
                Multa_resolucion = cantidadcolumnas
            End If
            If ACTA.ACTARECEPCION_CLAVE_ORDENPROVISION > 0 Then
                oprov = cantidadcolumnas
            End If
            If ACTA.ACTARECEPCION_NUMERO > 0 Then
                actarecepcion = cantidadcolumnas
            End If
            If ACTA.ACTARECEPCION_MONTO > 0 Then
                Importe = cantidadcolumnas
            End If
            SUBTOTAL += ACTA.ACTARECEPCION_MONTO + ACTA.ACTARECEPCION_MULTA_MONTO
        Next
        For Each SINACTA In ordendepagos.SINACTAS
            If Not (LISTADECUITS.Contains(SINACTA.ACTARECEPCION_CUIT)) Then
                LISTADECUITS.Add(SINACTA.ACTARECEPCION_CUIT)
            End If
            If SINACTA.ACTARECEPCION_DETALLE.Length > 0 Then
                Detalle = cantidadcolumnas
            End If
            If SINACTA.ACTARECEPCION_EFECTOR.Length > 0 Then
                Efector = cantidadcolumnas
            End If
            If SINACTA.ACTARECEPCION_PERIODO.Length > 0 Then
                Periodo = cantidadcolumnas
            End If
            If SINACTA.ACTARECEPCION_ANTICIPO > 0 Then
                Anticipo = cantidadcolumnas
            End If
            If SINACTA.ACTARECEPCION_MULTA_MONTO <> 0 Then
                Multa = cantidadcolumnas
                Multa_resolucion = cantidadcolumnas
            End If
            If SINACTA.ACTARECEPCION_CLAVE_ORDENPROVISION > 0 Then
                oprov = cantidadcolumnas
            End If
            If SINACTA.ACTARECEPCION_NUMERO > 0 Then
                actarecepcion = cantidadcolumnas
            End If
            If SINACTA.ACTARECEPCION_MONTO > 0 Then
                Importe = cantidadcolumnas
            End If
            SUBTOTAL += SINACTA.ACTARECEPCION_MONTO + SINACTA.ACTARECEPCION_MULTA_MONTO
        Next
        Dim Listadecolumnas As New List(Of String)
        'tamanio unitario
        If LISTADECUITS.Count > 1 Then
            Tamaniounitario += ((Detalle + Efector + Periodo + Anticipo + Multa + Multa_resolucion + oprov + actarecepcion + Importe + cantidadcolumnas) / cantidadcolumnas)
            Listadecolumnas.Add("Proveedor")
        Else
            Tamaniounitario = ((Detalle + Efector + Periodo + Anticipo + Multa + Multa_resolucion + oprov + actarecepcion + Importe) / cantidadcolumnas)
        End If
        If Tamaniounitario = 0 Then
            Tamaniounitario = cantidadcolumnas * 2
        End If
        'tamanio de cada columna y encabezado
        Dim tamaniounitariocolumna As Integer = Math.Round(cantidadcolumnas / Tamaniounitario)
        Dim TamanioUnitarioColumna_truncar As Integer = Math.Round(cantidadcolumnas / Tamaniounitario) * 2
        Dim numeroocupado As Integer = 0
        If LISTADECUITS.Count > 1 Then
            tablapdf.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Proveedor", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0.4, tamaniounitariocolumna, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
            numeroocupado += tamaniounitariocolumna
        End If
        If Efector > 0 Then
            Select Case tamaniounitariocolumna <= cantidadcolumnas
                Case True
                    tablapdf.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Efector", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0.4, tamaniounitariocolumna, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                    numeroocupado += tamaniounitariocolumna
                Case False
                    tablapdf.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Efector", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0.4, TamanioUnitarioColumna_truncar, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                    numeroocupado += TamanioUnitarioColumna_truncar
            End Select
            Listadecolumnas.Add("Efector")
        End If
        If Periodo > 0 Then
            tablapdf.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Periodo", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0.4, tamaniounitariocolumna, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
            Listadecolumnas.Add("Periodo")
            numeroocupado += tamaniounitariocolumna
        End If
        If oprov > 0 Then
            tablapdf.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("O. Prov.", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0.4, tamaniounitariocolumna, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
            Listadecolumnas.Add("O. Prov.")
            numeroocupado += tamaniounitariocolumna
        End If
        If actarecepcion > 0 Then
            tablapdf.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Acta Recep.", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0.4, tamaniounitariocolumna, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
            Listadecolumnas.Add("Acta Recep.")
            numeroocupado += tamaniounitariocolumna
        End If
        If Detalle > 0 Then
            Select Case tamaniounitariocolumna <= cantidadcolumnas
                Case True
                    tablapdf.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Detalle", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0.4, tamaniounitariocolumna, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                    numeroocupado += tamaniounitariocolumna
                Case False
                    tablapdf.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Detalle", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0.4, TamanioUnitarioColumna_truncar, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                    numeroocupado += TamanioUnitarioColumna_truncar
            End Select
            Listadecolumnas.Add("Detalle")
        End If
        If Anticipo > 0 Then
            tablapdf.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Anticipo", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0.4, tamaniounitariocolumna, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
            Listadecolumnas.Add("Anticipo")
            numeroocupado += tamaniounitariocolumna
        End If
        If Multa > 0 Then
            tablapdf.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Multa", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0.4, tamaniounitariocolumna, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
            Listadecolumnas.Add("Multa")
            numeroocupado += tamaniounitariocolumna
        End If
        If Multa_resolucion > 0 Then
            tablapdf.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Res. Multa", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0.4, tamaniounitariocolumna, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
            Listadecolumnas.Add("Res. Multa")
            numeroocupado += tamaniounitariocolumna
        End If
        If Importe > 0 Then
            tablapdf.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Importe", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, True))), 0.4, cantidadcolumnas - numeroocupado, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
            Listadecolumnas.Add("Importe")
        End If
        '-Carga de datos
        For Each ACTA In ordendepagos.ACTAS
            If LISTADECUITS.Count > 1 Then
                Select Case tamaniounitariocolumna <= cantidadcolumnas
                    Case True
                        tablapdf.AddCell(Phrasepdf(Proveedor.Nombre_proveedor(ACTA.ACTARECEPCION_CUIT), impresor.tamaniofuentetablas, False, 0.4, tamaniounitariocolumna, 1, Element.ALIGN_CENTER, 0))
                    Case False
                        tablapdf.AddCell(Phrasepdf(Proveedor.Nombre_proveedor(ACTA.ACTARECEPCION_CUIT), impresor.tamaniofuentetablas, False, 0.4, TamanioUnitarioColumna_truncar, 1, Element.ALIGN_CENTER, 0))
                End Select
            End If
            If Efector > 0 Then
                Select Case tamaniounitariocolumna <= cantidadcolumnas
                    Case True
                        tablapdf.AddCell(Phrasepdf(ACTA.ACTARECEPCION_EFECTOR, impresor.tamaniofuentetablas, False, 0.4, tamaniounitariocolumna, 1, Element.ALIGN_CENTER, 0))
                    Case False
                        tablapdf.AddCell(Phrasepdf(ACTA.ACTARECEPCION_EFECTOR, impresor.tamaniofuentetablas, False, 0.4, TamanioUnitarioColumna_truncar, 1, Element.ALIGN_CENTER, 0))
                End Select
            End If
            If Periodo > 0 Then
                tablapdf.AddCell(Phrasepdf(ACTA.ACTARECEPCION_PERIODO, impresor.tamaniofuentetablas, False, 0.4, tamaniounitariocolumna, 1, Element.ALIGN_CENTER, 0))
            End If
            If oprov > 0 Then
                tablapdf.AddCell(Phrasepdf(CType(ACTA.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(8, 5), Integer) & "/" & ACTA.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(0, 4), impresor.tamaniofuentetablas, False, 0.4, tamaniounitariocolumna, 1, Element.ALIGN_CENTER, 1))
            End If
            If actarecepcion > 0 Then
                tablapdf.AddCell(Phrasepdf(ACTA.ACTARECEPCION_NUMERO & "/" & ACTA.ACTARECEPCION_YEAR, impresor.tamaniofuentetablas, False, 0.4, tamaniounitariocolumna, 1, Element.ALIGN_CENTER, 0))
            End If
            If Detalle > 0 Then
                Select Case tamaniounitariocolumna <= cantidadcolumnas
                    Case True
                        tablapdf.AddCell(Phrasepdf(ACTA.ACTARECEPCION_DETALLE, impresor.tamaniofuentetablas, False, 0.4, tamaniounitariocolumna, 1, Element.ALIGN_CENTER, 0))
                    Case False
                        tablapdf.AddCell(Phrasepdf(ACTA.ACTARECEPCION_DETALLE, impresor.tamaniofuentetablas, False, 0.4, TamanioUnitarioColumna_truncar, 1, Element.ALIGN_CENTER, 0))
                End Select
            End If
            If Anticipo > 0 Then
                tablapdf.AddCell(Phrasepdf(ACTA.ACTARECEPCION_ANTICIPO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), impresor.tamaniofuentetablas, False, 0.4, tamaniounitariocolumna, 1, Element.ALIGN_CENTER, 2))
            End If
            If Multa > 0 Then
                tablapdf.AddCell(Phrasepdf(ACTA.ACTARECEPCION_MULTA_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), impresor.tamaniofuentetablas, False, 0.4, tamaniounitariocolumna, 1, Element.ALIGN_CENTER, 2))
            End If
            If Multa_resolucion > 0 Then
                tablapdf.AddCell(Phrasepdf(ACTA.ACTARECEPCION_MULTA_RESOLUCION, impresor.tamaniofuentetablas, False, 0.4, tamaniounitariocolumna, 1, Element.ALIGN_CENTER, 0))
            End If
            If Importe <> 0 Then
                tablapdf.AddCell(Phrasepdf(ACTA.ACTARECEPCION_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), impresor.tamaniofuentetablas, False, 0.4, cantidadcolumnas - numeroocupado, 1, Element.ALIGN_CENTER, 2))
            End If
        Next
        Return tablapdf
    End Function

    Public Sub PDF_ORDENPAGO_MULTIPLEv2(ByVal ORDENDEPAGOS As Ordendepago)
        Dim impresor As New Impresion
        impresor.fecha = ORDENDEPAGOS.ordenpago_fecha
        impresor.cargartodoslossellos()
        'clase
        'itextsharp.pagesize
        'New iTextSharp.text.Font
        'font size
        impresor.tamaniofuentetitulos = 16
        impresor.tamaniofuente = 12
        impresor.tamaniofuentetablas = 10
        Dialogo_impresion.Cargar_impresion(impresor)
        Dim Doc As New Document(impresor.hoja, impresor.marginleft, impresor.marginright, impresor.margintop, impresor.marginbottom)
        Dim Anchopagina As Single = Doc.PageSize.Width
        Dim Controlguardado As New SaveFileDialog
        With Controlguardado
            Select Case System.IO.Directory.Exists("C:" & "\" & "Ordenes_de_Pago" & "\" & ORDENDEPAGOS.Ordenpago_Year & "\")
                Case True
                Case False
                    System.IO.Directory.CreateDirectory("C:" & "\" & "Ordenes_de_Pago" & "\" & ORDENDEPAGOS.Ordenpago_Year & "\")
            End Select
            .Filter = "ARCHIVO PDF|*.pdf"
            .Title = "Guardar en archivo PDF"
            .FileName = " OP - " & ORDENDEPAGOS.ordenpago_numero & "-" & ORDENDEPAGOS.Ordenpago_Year & "-" & ORDENDEPAGOS.Ordenpago_tipo & ".pdf"
            .RestoreDirectory = True
            .InitialDirectory = "C:" & "\" & "Ordenes_de_Pago" & "\" & ORDENDEPAGOS.Ordenpago_Year & "\"
        End With
        Controlguardado.Filter = "ARCHIVO PDF|*.pdf"
        Controlguardado.Title = "Guardar en archivo PDF"
        Controlguardado.ShowDialog()
        If Controlguardado.FileName = "" Then
            MsgBox("Para poder proceder a la creación del archivo se requiere un nombre")
            Exit Sub
        Else
            Dim FileName As String = Controlguardado.FileName
            'Try
            Using wri = PdfWriter.GetInstance(Doc, New FileStream(FileName, FileMode.OpenOrCreate))
                'Dim ev As New itsEvents2
                'wri.PageEvent = ev
                'Abrir el documento para el uso
                Doc.Open()
                'Insertar una página en blanco nueva
                Doc.NewPage()
                'ENCABEZADO
                'Crear tabla General para cargar los bordes
                Dim Tabla_total As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(1)
                Tabla_total.TotalWidth = Anchopagina - Doc.LeftMargin
                Tabla_total.LockedWidth = True
                Dim tamaniocolumna_total As Single() = New Single(0) {}
                tamaniocolumna_total(0) = Convert.ToSingle(Anchopagina - Doc.LeftMargin * 1)
                Tabla_total.SetWidths(tamaniocolumna_total)
                'Creación de la celda que manejaria cada uno de los cuadros
                Dim PARRAFOTOTAL As New iTextSharp.text.Paragraph()
                Dim PARRAFOCOMPLETO As New iTextSharp.text.Paragraph()
                Dim PARRAFOPARCIAL As New iTextSharp.text.Paragraph()
                Dim Phrasetemporal As New iTextSharp.text.Phrase()
                'Crear tabla para manejar los encabezados---------------------------------------------------------------------------------------------
                Dim Encabezadosx As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(2)
                Encabezadosx.TotalWidth = Anchopagina - Doc.LeftMargin
                Encabezadosx.LockedWidth = True
                'Declaración variable de ancho de columnas
                Dim tamaniocolumna As Single() = New Single(1) {}
                tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.2)
                tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.8)
                Encabezadosx.SetWidths(tamaniocolumna)
                'para insertar un espacio entre las celdas
                Dim PdfpCell_espaciovacio As iTextSharp.text.pdf.PdfPCell = New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("", PDF_fuente_variable(impresor.tamaniofuente, False))))
                PdfpCell_espaciovacio.BorderWidth = 0
                PdfpCell_espaciovacio.FixedHeight = 5.0F
                Dim PdfpCell_espaciovacioborde As iTextSharp.text.pdf.PdfPCell = New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("", PDF_fuente_variable(impresor.tamaniofuente, False))))
                PdfpCell_espaciovacioborde.BorderWidth = 0.5
                PdfpCell_espaciovacioborde.FixedHeight = 2.0F
                'crear imagen con logo a la izquierda
                Dim manejadorimagen As iTextSharp.text.Image = Image.GetInstance(My.Resources.Logo, System.Drawing.Imaging.ImageFormat.Jpeg)
                'asignar la imagen itextsharp a la celda
                Dim PdfPCell As iTextSharp.text.pdf.PdfPCell = New PdfPCell(manejadorimagen, True)
                PdfPCell.Rowspan = 2
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_LEFT
                PdfPCell.FixedHeight = 70.0F
                Encabezadosx.AddCell(PdfPCell)
                'Encabezado del año
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Encabezadodelyear(ORDENDEPAGOS.ordenpago_fecha.Year), PDF_fuente_variable(impresor.tamaniofuente - 2, False))))
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.FixedHeight = 25.0F
                Encabezadosx.AddCell(PdfPCell)
                '----------------------NOMBRE DEL SERVICIO ADMINISTRATIVO------------------------------
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Nombrecompletodelservicio.ToUpper, PDF_fuente_variable(impresor.tamaniofuente + 2, True))))
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.FixedHeight = 25.0F
                Encabezadosx.AddCell(PdfPCell)
                'Encabezadosx.AddCell(PdfpCell_espaciovacioborde)
                With PdfpCell_espaciovacio
                    .FixedHeight = 10.0F
                    .Colspan = Encabezadosx.NumberOfColumns
                End With
                Encabezadosx.AddCell(PdfpCell_espaciovacio)
                '----------------------AGREGA EL ENCABEZADO Completo------------------------------
                ' Frase_total.Clear()
                PARRAFOCOMPLETO.Add(Encabezadosx)
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
                PARRAFOCOMPLETO.Clear()
                'DATOS BÁSICOS ORDEN DE PAGO
                Dim Datosbasicosordenpago As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(4)
                Datosbasicosordenpago.TotalWidth = Anchopagina - Doc.LeftMargin
                Datosbasicosordenpago.LockedWidth = True
                Datosbasicosordenpago.PaddingTop = 5
                tamaniocolumna = New Single(3) {}
                tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.12)
                tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.12)
                tamaniocolumna(2) = Convert.ToSingle(Anchopagina * 0.38)
                tamaniocolumna(3) = Convert.ToSingle(Anchopagina * 0.38)
                Datosbasicosordenpago.SetWidths(tamaniocolumna)
                Datosbasicosordenpago.AddCell(Phrasepdf(" ORDEN DE PAGO ", impresor.tamaniofuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE,, "#c5c7c0"))
                Datosbasicosordenpago.AddCell(Phrasepdf("ORDEN DE PAGO Nº " & ORDENDEPAGOS.ordenpago_numero,
                                                            impresor.tamaniofuentetitulos, True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
                'TIPO O TIPOS DE INSTRUMENTO LEGAL
                Dim Tipo_instrumentolegal As New List(Of String)
                Dim Todostiposlegales As String = ""
                Select Case ORDENDEPAGOS.Ordenpago_tipo.ToUpper
                    Case Is = "ARANCELAMIENTO"
                        'EN CASO DE QUE SEA ARANCELAMIENTO NO REQUIERE UN NÚMERO DE INSTRUMENTO LEGAL YA QYUE ESTE ES EL DECRETO 488/2000
                        Todostiposlegales = "DECRETO"
                        Datosbasicosordenpago.AddCell(Phrasepdf(Todostiposlegales,
                                                                    impresor.tamaniofuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                        Datosbasicosordenpago.AddCell(Phrasepdf(" ", impresor.tamaniofuente,
                        True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
                    Case Is = "TRANSFERENCIA"
                        'EN CASO DE QUE SEA ARANCELAMIENTO NO REQUIERE UN NÚMERO DE INSTRUMENTO LEGAL YA QYUE ESTE ES EL DECRETO 488/2000
                        Todostiposlegales = "DECRETO"
                        Datosbasicosordenpago.AddCell(Phrasepdf(Todostiposlegales,
                                                                    impresor.tamaniofuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                        Datosbasicosordenpago.AddCell(Phrasepdf(" ", impresor.tamaniofuente,
                        True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
                    Case Is = "VIÁTICOS"
                        Select Case ORDENDEPAGOS.VIATICOS.Count
                            Case = 0
                                Datosbasicosordenpago.AddCell(Phrasepdf(" ",
                                                                            impresor.tamaniofuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                                Datosbasicosordenpago.AddCell(Phrasepdf(" ",
                                                                            impresor.tamaniofuente, True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
                            Case = 1
                                Datosbasicosordenpago.AddCell(Phrasepdf(ORDENDEPAGOS.VIATICOS(0).Tipo_instrumentolegal,
                                                                            impresor.tamaniofuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                                Datosbasicosordenpago.AddCell(Phrasepdf(" ", impresor.tamaniofuente,
                                                                            True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
                            Case Else
                                For X = 0 To ORDENDEPAGOS.VIATICOS.Count - 1
                                    If Not Tipo_instrumentolegal.Contains(ORDENDEPAGOS.VIATICOS(X).Tipo_instrumentolegal) Then
                                        Tipo_instrumentolegal.Add(ORDENDEPAGOS.VIATICOS(X).Tipo_instrumentolegal)
                                        If Tipo_instrumentolegal.Count > 1 Then
                                            Todostiposlegales += "/" & ORDENDEPAGOS.VIATICOS(X).Tipo_instrumentolegal
                                        Else
                                            Todostiposlegales = ORDENDEPAGOS.VIATICOS(X).Tipo_instrumentolegal
                                        End If
                                    End If
                                Next
                                If Tipo_instrumentolegal.Count > 1 Then
                                    Datosbasicosordenpago.AddCell(Phrasepdf(Todostiposlegales,
                                                                            impresor.tamaniofuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                                    Datosbasicosordenpago.AddCell(Phrasepdf(" ", impresor.tamaniofuente,
                                                                            True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
                                Else
                                    Datosbasicosordenpago.AddCell(Phrasepdf(ORDENDEPAGOS.VIATICOS(0).Tipo_instrumentolegal,
                                                                            impresor.tamaniofuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                                    Datosbasicosordenpago.AddCell(Phrasepdf(" ", impresor.tamaniofuente,
                                                                            True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
                                End If
                        End Select
                    Case Else
                        Select Case ORDENDEPAGOS.SINACTAS.Count
                            Case = 0
                                Datosbasicosordenpago.AddCell(Phrasepdf(" ",
                                                                            impresor.tamaniofuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                                Datosbasicosordenpago.AddCell(Phrasepdf(" ",
                                                                            impresor.tamaniofuente, True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
                            Case = 1
                                Datosbasicosordenpago.AddCell(Phrasepdf(ORDENDEPAGOS.SINACTAS(0).Tipo_instrumentolegal,
                                                                            impresor.tamaniofuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                                Datosbasicosordenpago.AddCell(Phrasepdf(" ", impresor.tamaniofuente,
                                                                            True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
                            Case Else
                                For X = 0 To ORDENDEPAGOS.SINACTAS.Count - 1
                                    If Not Tipo_instrumentolegal.Contains(ORDENDEPAGOS.SINACTAS(X).Tipo_instrumentolegal) Then
                                        Tipo_instrumentolegal.Add(ORDENDEPAGOS.SINACTAS(X).Tipo_instrumentolegal)
                                        If Tipo_instrumentolegal.Count > 1 Then
                                            Todostiposlegales += "/" & ORDENDEPAGOS.SINACTAS(X).Tipo_instrumentolegal
                                        Else
                                            Todostiposlegales = ORDENDEPAGOS.SINACTAS(X).Tipo_instrumentolegal
                                        End If
                                    End If
                                Next
                                If Tipo_instrumentolegal.Count > 1 Then
                                    Datosbasicosordenpago.AddCell(Phrasepdf(Todostiposlegales,
                                                                            impresor.tamaniofuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                                    Datosbasicosordenpago.AddCell(Phrasepdf(" ", impresor.tamaniofuente,
                                                                            True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
                                Else
                                    Datosbasicosordenpago.AddCell(Phrasepdf(ORDENDEPAGOS.SINACTAS(0).Tipo_instrumentolegal,
                                                                            impresor.tamaniofuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                                    Datosbasicosordenpago.AddCell(Phrasepdf(" ", impresor.tamaniofuente,
                                                                            True, 0, 2, 1, Element.ALIGN_CENTER, 0, Element.ALIGN_MIDDLE))
                                End If
                        End Select
                End Select
                Datosbasicosordenpago.AddCell(Phrasepdf(" AÑO ", impresor.tamaniofuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                Datosbasicosordenpago.AddCell(Phrasepdf(" NÚMERO ", impresor.tamaniofuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                Datosbasicosordenpago.AddCell(Phrasepdf(" ", impresor.tamaniofuente, False, 0, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                'SE EFECTUA UN FORMATO PREVIO PARA MANEJAR LOS CASOS QUE CONTENGAN VARIAS ORDENES DE PROVISION DENTRO DE LA ORDEN DE PAGO..
                Dim numeroinstrumentolegal As New List(Of String)
                Dim anioinstrumentolegal As New List(Of String)
                Dim CONCATENADO As New List(Of String)
                Dim BENEFICIARIO As New List(Of String)
                Dim detallenumeroinstrumentolegal As String = ""
                Dim detalleanioinstrumentolegal As String = ""
                Select Case ORDENDEPAGOS.Ordenpago_tipo.ToUpper
                    Case Is = "ARANCELAMIENTO"
                        'EN CASO DE QUE SEA ARANCELAMIENTO NO REQUIERE UN NÚMERO DE INSTRUMENTO LEGAL YA QYUE ESTE ES EL DECRETO 488/2000
                        Todostiposlegales = "DECRETO"
                        detallenumeroinstrumentolegal = "488"
                        detalleanioinstrumentolegal = "2000"
                    Case Is = "TRANSFERENCIA"
                        'EN CASO DE QUE SEA TRANSFERENCIA NO REQUIERE UN NÚMERO DE INSTRUMENTO LEGAL YA QUE SON LOS DECRETOS 701/2008 Y 136/2014
                        Todostiposlegales = "DECRETO"
                        numeroinstrumentolegal.AddRange({"071", "136"})
                        anioinstrumentolegal.AddRange({"2008", "2014"})
                    Case Is = "VIÁTICOS"
                        'LA ORDEN DE PAGO DE VIATICOS UTILIZA UNA TABLA DIFERENTE
                        Select Case ORDENDEPAGOS.VIATICOS.Count
                            Case = 0
                                detallenumeroinstrumentolegal = ""
                                detalleanioinstrumentolegal = ""
                            'PdfPCell = New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(impresor.tamaniofuente, True))), 0.5, 2, 1, iTextSharp.text.Element.ALIGN_CENTER, 0))
                            Case = 1
                                detallenumeroinstrumentolegal = ORDENDEPAGOS.VIATICOS(0).Numero_instrumentolegal
                                detalleanioinstrumentolegal = ORDENDEPAGOS.VIATICOS(0).Year_instrumento_legal
                                'PdfPCell = New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(ORDENDEPAGOS.ORDENESPROVISION(0).Numero_instrumentolegal, PDF_fuente_variable(impresor.tamaniofuente, False))), 0.5, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0))
                            Case Else
                                For Each op As VIATICO In ORDENDEPAGOS.VIATICOS
                                    If Not (CONCATENADO.Contains(op.Numero_instrumentolegal & "/" & op.Year_instrumento_legal)) Then
                                        numeroinstrumentolegal.Add(op.Numero_instrumentolegal)
                                        anioinstrumentolegal.Add(op.Year_instrumento_legal)
                                        CONCATENADO.Add(op.Numero_instrumentolegal & "/" & op.Year_instrumento_legal)
                                    End If
                                Next
                        End Select
                    Case Else
                        Select Case ORDENDEPAGOS.SINACTAS.Count
                            Case = 0
                                detallenumeroinstrumentolegal = ""
                                detalleanioinstrumentolegal = ""
                            'PdfPCell = New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(impresor.tamaniofuente, True))), 0.5, 2, 1, iTextSharp.text.Element.ALIGN_CENTER, 0))
                            Case = 1
                                detallenumeroinstrumentolegal = ORDENDEPAGOS.SINACTAS(0).Numero_instrumentolegal
                                detalleanioinstrumentolegal = ORDENDEPAGOS.SINACTAS(0).Year_instrumento_legal
                                'PdfPCell = New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(ORDENDEPAGOS.ORDENESPROVISION(0).Numero_instrumentolegal, PDF_fuente_variable(impresor.tamaniofuente, False))), 0.5, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0))
                            Case Else
                                For Each op As SINACTARECEPCION In ORDENDEPAGOS.SINACTAS
                                    If Not (CONCATENADO.Contains(op.Numero_instrumentolegal & "/" & op.Year_instrumento_legal)) Then
                                        numeroinstrumentolegal.Add(op.Numero_instrumentolegal)
                                        anioinstrumentolegal.Add(op.Year_instrumento_legal)
                                        CONCATENADO.Add(op.Numero_instrumentolegal & "/" & op.Year_instrumento_legal)
                                    End If
                                Next
                        End Select
                End Select
                For z = 0 To numeroinstrumentolegal.Count - 1
                    If z = numeroinstrumentolegal.Count - 1 Then
                        detallenumeroinstrumentolegal += numeroinstrumentolegal(z)
                        detalleanioinstrumentolegal += anioinstrumentolegal(z)
                    Else
                        detallenumeroinstrumentolegal += numeroinstrumentolegal(z) & vbCrLf
                        detalleanioinstrumentolegal += anioinstrumentolegal(z) & vbCrLf
                    End If
                Next
                PdfPCell = New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(detalleanioinstrumentolegal, PDF_fuente_variable(impresor.tamaniofuente, False))), 0.5, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0))
                Datosbasicosordenpago.AddCell(PdfPCell)
                PdfPCell = New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(detallenumeroinstrumentolegal, PDF_fuente_variable(impresor.tamaniofuente, False))), 0.5, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0))
                Datosbasicosordenpago.AddCell(PdfPCell)
                PdfPCell = New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(10, False))), 0, 2, 1, iTextSharp.text.Element.ALIGN_CENTER, 0))
                Datosbasicosordenpago.AddCell(PdfPCell)
                PdfPCell = New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(10, False))), 0, 4, 1, iTextSharp.text.Element.ALIGN_CENTER, 0))
                Datosbasicosordenpago.AddCell(PdfPCell)
                'Datosbasicosordenpago.AddCell(PdfpCell_espaciovacio)
                Datosbasicosordenpago.AddCell(Phrasepdf(" EXPEDIENTE ", impresor.tamaniofuente, True, 0.5, 2, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE,, "#c5c7c0"))
                Datosbasicosordenpago.AddCell(Phrasepdf("POSADAS, " & ORDENDEPAGOS.ordenpago_fecha.ToShortDateString, impresor.tamaniofuente + 2, False, 0, 2, 3, Element.ALIGN_CENTER, 4, Element.ALIGN_MIDDLE))
                Datosbasicosordenpago.AddCell(Phrasepdf("LETRA", impresor.tamaniofuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                Datosbasicosordenpago.AddCell(Phrasepdf("NÚMERO", impresor.tamaniofuente, False, 0.5, 1, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                'NUMERO DE EXPEDIENTE
                Datosbasicosordenpago.AddCell(Phrasepdf(ORDENDEPAGOS.expediente_op.organismo.ToString, impresor.tamaniofuente + 1, True, 0.5, 1, 1, Element.ALIGN_CENTER, 4, Element.ALIGN_MIDDLE))
                Datosbasicosordenpago.AddCell(Phrasepdf(ORDENDEPAGOS.expediente_op.numero & "-" & ORDENDEPAGOS.expediente_op.year, impresor.tamaniofuente + 1, True, 0.5, 1, 1, Element.ALIGN_CENTER, 4, Element.ALIGN_MIDDLE))
                If ORDENDEPAGOS.expediente_op2.claveexpediente > 0 Then
                    Datosbasicosordenpago.AddCell(Phrasepdf(CType(ORDENDEPAGOS.expediente_op2.claveexpediente.ToString.Substring(4, 4), UInteger).ToString, impresor.tamaniofuente + 1, True, 0.5, 1, 1, Element.ALIGN_CENTER, 4, Element.ALIGN_MIDDLE))
                    Datosbasicosordenpago.AddCell(Phrasepdf(CType(ORDENDEPAGOS.expediente_op2.claveexpediente.ToString.Substring(8, 5), UInteger) & "-" & CType(ORDENDEPAGOS.expediente_op2.claveexpediente.ToString.Substring(0, 4), UInteger), impresor.tamaniofuente + 1, True, 0.5, 1, 1, Element.ALIGN_CENTER, 4, Element.ALIGN_MIDDLE))
                    Datosbasicosordenpago.AddCell(Phrasepdf(" ", impresor.tamaniofuente, False, 0, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                End If
                'PdfPCell = New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(ORDENDEPAGOS.expediente_op.numero & "-" & ORDENDEPAGOS.expediente_op.year, PDF_fuente_variable(impresor.tamaniofuente + 1, True))), 0.5, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0))
                'Datosbasicosordenpago.AddCell(PdfPCell)
                'EXPEDIENTE PRINCIPAL
                If ORDENDEPAGOS.ClaveExpediente_principal.ToString.Length = 13 Then
                    '
                    Datosbasicosordenpago.AddCell(Phrasepdf(" Autorizado por: ", impresor.tamaniofuente, False, 0.5, 2, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE))
                    Datosbasicosordenpago.AddCell(Phrasepdf(" ", impresor.tamaniofuente + 2, False, 0, 2, 3, Element.ALIGN_CENTER, 4, Element.ALIGN_MIDDLE))
                    Datosbasicosordenpago.AddCell(Phrasepdf(ORDENDEPAGOS.ClaveExpediente_principal.ToString.Substring(4, 4) & "-" &
                                                     Convert.ToInt32(ORDENDEPAGOS.ClaveExpediente_principal.ToString.Substring(8, 5)) & "/" &
                                                    ORDENDEPAGOS.ClaveExpediente_principal.ToString.Substring(0, 4), impresor.tamaniofuente, False, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                Else
                    Datosbasicosordenpago.AddCell(Phrasepdf("  ", impresor.tamaniofuente, True, 0, 2, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE))
                    Datosbasicosordenpago.AddCell(Phrasepdf(" ", impresor.tamaniofuente + 2, False, 0, 2, 3, Element.ALIGN_CENTER, 4, Element.ALIGN_MIDDLE))
                    Datosbasicosordenpago.AddCell(Phrasepdf(" ", impresor.tamaniofuente, False, 0, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                End If
                PARRAFOCOMPLETO.Add(Datosbasicosordenpago)
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
                'TEXTO DATOS BÁSICOS ORDEN DE PAGO
                PARRAFOPARCIAL.Clear()
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("De acuerdo con la orden precedente se liquida para ser abonado por la Tesorería del " &
                                                                 Autorizaciones.Nombrecompletodelservicio &
                                                                 " a favor de: ", PDF_fuente_variable(impresor.tamaniofuente + 1, False)))
                '*******************************************************COMIENZO DE MULTI ORDENES*******************************************************************************
                Dim LISTADECUITS As New List(Of String)
                Select Case ORDENDEPAGOS.Ordenpago_tipo.ToUpper
                    Case Is = "BECAS"
                        PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("Varios Beneficiarios " & vbCrLf, PDF_fuente_variable(impresor.tamaniofuente + 2, True)))
                    Case Is = "COMISIÓN BANCARIA"
                        PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("BANCO MACRO S.A." & vbCrLf, PDF_fuente_variable(impresor.tamaniofuente + 2, True)))
                    Case Is = "VIÁTICOS"
                        If ORDENDEPAGOS.VIATICOS.Count = 1 Then
                            PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(ORDENDEPAGOS.VIATICOS(0).Beneficiario.ToUpper & vbCrLf, PDF_fuente_variable(impresor.tamaniofuente + 2, True)))
                        Else
                            PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("Varios Beneficiarios " & vbCrLf, PDF_fuente_variable(impresor.tamaniofuente + 2, True)))
                        End If
                    Case Else
                        Dim CONTAR As Integer = 0
                        Dim ContarCUIT As Integer = 0
                        For X = 0 To ORDENDEPAGOS.SINACTAS.Count - 1
                            If (ORDENDEPAGOS.SINACTAS(X).CUIT.Length > 8) Then
                                ContarCUIT += 1
                                If Not LISTADECUITS.Contains(ORDENDEPAGOS.SINACTAS(X).CUIT) Then
                                    LISTADECUITS.Add(ORDENDEPAGOS.SINACTAS(X).CUIT)
                                End If
                            End If
                        Next
                        If LISTADECUITS.Count > 1 Then
                            PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("Varios Beneficiarios " & vbCrLf, PDF_fuente_variable(impresor.tamaniofuente + 2, True)))
                        Else
                            If LISTADECUITS.Count = 0 Then
                                'en caso de que no tenga CUITS
                                For X = 0 To ORDENDEPAGOS.SINACTAS.Count - 1
                                    If Not (ORDENDEPAGOS.SINACTAS(X).EFECTOR = "") Then
                                        If Not (BENEFICIARIO.Contains(ORDENDEPAGOS.SINACTAS(X).EFECTOR)) Then
                                            BENEFICIARIO.Add(ORDENDEPAGOS.SINACTAS(X).EFECTOR)
                                        End If
                                        ' CONTAR += 1
                                    End If
                                Next
                                Select Case BENEFICIARIO.Count
                                    Case = 0
                                    Case = 1
                                        PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(BENEFICIARIO(0) & vbCrLf, PDF_fuente_variable(impresor.tamaniofuente + 2, True)))
                                    Case Else
                                        PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("Varios Beneficiarios " & vbCrLf, PDF_fuente_variable(impresor.tamaniofuente + 2, True)))
                                End Select
                            Else
                                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(Proveedor.Nombre_proveedor(LISTADECUITS(0)) & vbCrLf, PDF_fuente_variable(impresor.tamaniofuente + 2, True)))
                            End If
                        End If
                End Select
                'CONCEPTO DE'
                PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("A su orden en concepto de: ", PDF_fuente_variable(impresor.tamaniofuente + 2, False)))
                Select Case ORDENDEPAGOS.Ordenpago_tipo.ToUpper
                    Case Is = "REDETERMINACIÓN"
                        PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("PAGO", PDF_fuente_variable(impresor.tamaniofuente + 2, True)))
                    'Case Is = "PAGO MULTIPLES EFECTORES"
                    '    PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("PAGO", PDF_fuente_variable(impresor.tamaniofuente + 2, True)))
                    Case Is = "BECAS"
                        PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("PAGO", PDF_fuente_variable(impresor.tamaniofuente + 2, True)))
                    Case Is = "CONTRATOS"
                        PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("PAGO", PDF_fuente_variable(impresor.tamaniofuente + 2, True)))
                    Case Is = "COMISIÓN BANCARIA"
                        PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("PAGO", PDF_fuente_variable(impresor.tamaniofuente + 2, True)))
                    Case Is = "TRANSFERENCIA"
                        PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("TRANSFERENCIA", PDF_fuente_variable(impresor.tamaniofuente + 2, True)))
                    Case Is = "ARANCELAMIENTO"
                        PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("RENDICIÓN", PDF_fuente_variable(impresor.tamaniofuente + 2, True)))
                    Case Is = "VIÁTICOS"
                        PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk("RENDICIÓN VIATICO.-", PDF_fuente_variable(impresor.tamaniofuente + 2, True)))
                    Case Else
                        PARRAFOPARCIAL.Add(New iTextSharp.text.Chunk(ORDENDEPAGOS.Ordenpago_tipo, PDF_fuente_variable(impresor.tamaniofuente + 2, True)))
                End Select
                PARRAFOPARCIAL.FirstLineIndent = tamaniocolumna(0) + tamaniocolumna(1)
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOPARCIAL, 0, 1, 1, 0, 3)))
                With PdfpCell_espaciovacio
                    .FixedHeight = 10.0F
                    .Colspan = Tabla_total.NumberOfColumns
                End With
                Tabla_total.AddCell(PdfpCell_espaciovacio)
                '************************************************************************CUADRO DETALLE************************************************************************************************
                'Dim textoprimercuadro As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(6)
                Dim textoprimercuadro As iTextSharp.text.pdf.PdfPTable = New PdfPTable(1)
                textoprimercuadro.TotalWidth = Tabla_total.TotalWidth
                textoprimercuadro.LockedWidth = True
                Select Case ORDENDEPAGOS.Ordenpago_tipo.ToUpper
                    Case Is = "ARANCELAMIENTO"
                        textoprimercuadro = cuadro_RENDICION(ORDENDEPAGOS, Doc, impresor.tamaniofuentetablas)
                    'Case Is = "PAGO MULTIPLES EFECTORES"
                    '    textoprimercuadro = cuadro_RECONOCIMIENTO(ORDENDEPAGOS, Doc, impresor.tamaniofuente)
                    Case Is = "TRANSFERENCIA"
                        textoprimercuadro = cuadro_TRANSFERENCIA(ORDENDEPAGOS, Doc, impresor.tamaniofuentetablas)
                    Case Is = "RENDICIÓN"
                        textoprimercuadro = cuadro_RENDICION(ORDENDEPAGOS, Doc, impresor.tamaniofuentetablas)
                    Case Is = "RENDICIÓN FINAL"
                        textoprimercuadro = cuadro_RENDICION(ORDENDEPAGOS, Doc, impresor.tamaniofuentetablas)
                    Case Is = "RENDICIÓN PARCIAL"
                    Case Is = "RECONOCIMIENTO"
                        textoprimercuadro = cuadro_RECONOCIMIENTO_APROPIACION(ORDENDEPAGOS, Doc, impresor.tamaniofuentetablas)
                    Case Is = "RECONOCIMIENTO Y REAPROPIACIÓN"
                        textoprimercuadro = cuadro_RECONOCIMIENTO_APROPIACION(ORDENDEPAGOS, Doc, impresor.tamaniofuentetablas)
                    Case Is = "REDETERMINACIÓN"
                        textoprimercuadro = cuadro_RECONOCIMIENTO_APROPIACION(ORDENDEPAGOS, Doc, impresor.tamaniofuentetablas)
                    Case Is = "VIÁTICOS"
                        textoprimercuadro = cuadro_VIATICOS(ORDENDEPAGOS, Doc, impresor.tamaniofuentetablas)
                    Case Is = "REPOSICIÓN"
                        textoprimercuadro = cuadro_RECONOCIMIENTO(ORDENDEPAGOS, Doc, impresor.tamaniofuentetablas)
                    Case Is = "CONTRATOS"
                        textoprimercuadro = cuadro_RECONOCIMIENTO(ORDENDEPAGOS, Doc, impresor.tamaniofuentetablas)
                    Case Is = "BECAS"
                        textoprimercuadro = cuadro_RECONOCIMIENTO(ORDENDEPAGOS, Doc, impresor.tamaniofuentetablas)
                    Case Is = "PUBLICIDAD"
                        textoprimercuadro = cuadro_RECONOCIMIENTO_APROPIACION(ORDENDEPAGOS, Doc, impresor.tamaniofuentetablas)
                    Case Is = "COMISIÓN BANCARIA"
                        textoprimercuadro = cuadro_RECONOCIMIENTO(ORDENDEPAGOS, Doc, impresor.tamaniofuentetablas)
                    Case Else
                        textoprimercuadro = cuadro_RENDICION(ORDENDEPAGOS, Doc, impresor.tamaniofuentetablas)
                End Select
                'DETERMINAR QUE CAMPOS ESTAN COMPLETADOS
                '************************************************************** REFACTORIZAR*****************************************************************************************
                '************************************************************** REFACTORIZAR*****************************************************************************************
                Select Case ORDENDEPAGOS.Ordenpago_tipo.ToUpper
                    Case Is = "ARANCELAMIENTO"
                        textoprimercuadro = cuadro_RENDICION(ORDENDEPAGOS, Doc, impresor.tamaniofuente)
                    Case Is = "RENDICIÓN"
                        textoprimercuadro = cuadro_RENDICION(ORDENDEPAGOS, Doc, impresor.tamaniofuente)
                    Case Is = "RENDICIÓN FINAL"
                        textoprimercuadro = cuadro_RENDICION(ORDENDEPAGOS, Doc, impresor.tamaniofuente)
                    Case Else
                        If ORDENDEPAGOS.ordenpago_Detalle2.Length > 0 Then
                            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Observaciones:" & ORDENDEPAGOS.ordenpago_Detalle2, PDF_fuente_variable(impresor.tamaniofuente, False))), 0, textoprimercuadro.NumberOfColumns, 1, iTextSharp.text.Element.ALIGN_JUSTIFIED, 0)))
                        End If
                End Select
                With PdfpCell_espaciovacio
                    .FixedHeight = 20.0F
                    .Colspan = textoprimercuadro.NumberOfColumns
                End With
                textoprimercuadro.AddCell(PdfpCell_espaciovacio)
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(textoprimercuadro, 0.5)))
                Dim Totalsumado As Decimal = 0
                'SUMA TOTAL DE PEDIDO DE FONDO Y TEXTO
                For X = 0 To ORDENDEPAGOS.DatosOrdenPago.Rows.Count - 1
                    Totalsumado += CType(ORDENDEPAGOS.DatosOrdenPago.Rows(X).Item(11), Decimal)
                Next
                'Tabla_total.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" La suma de Pesos " & Totalsumado.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")) & ".-" & vbCrLf, PDF_fuente_variable(impresor.tamaniofuente, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_JUSTIFIED)))
                Tabla_total.AddCell(Phrasepdf(" La suma de Pesos " & Totalsumado.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")) & ".-", impresor.tamaniofuente, True, 0, 1, 1, Element.ALIGN_JUSTIFIED, 2, Element.ALIGN_MIDDLE, 200))
                'Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(New iTextSharp.text.Chunk("Son Pesos:  " & Inicio.Num2Text(Math.Truncate(Convert.ToDecimal(Totalsumado))) & " CON " &
                '((Convert.ToDecimal(Totalsumado) - Math.Truncate(Convert.ToDecimal(Totalsumado))) * 100).ToString("00") & "/100.-", PDF_fuente_variable(impresor.tamaniofuente, False)), 0, 11, 1, Element.ALIGN_JUSTIFIED)))
                Tabla_total.AddCell(Phrasepdf("Son Pesos:  " & Inicio.Num2Text(Math.Truncate(Convert.ToDecimal(Totalsumado))) & " CON " &
                    ((Convert.ToDecimal(Totalsumado) - Math.Truncate(Convert.ToDecimal(Totalsumado))) * 100).ToString("00") & "/100.-", impresor.tamaniofuente, False, 0, 11, 1, Element.ALIGN_JUSTIFIED, 2, Element.ALIGN_MIDDLE))
                'Tabla_total.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" QUE SE IMPUTARAN DE LA SIGUIENTE MANERA:", PDF_fuente_variable(impresor.tamaniofuente, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_LEFT)))
                If ORDENDEPAGOS.DatosOrdenPago.Rows.Count > 0 Then
                    Tabla_total.AddCell(Phrasepdf(" QUE SE IMPUTARAN DE LA SIGUIENTE MANERA: CUENTA " & CUENTA_PDF(ORDENDEPAGOS.DatosOrdenPago.Rows(0).Item(2)), impresor.tamaniofuente, True, 0, 1, 1, Element.ALIGN_LEFT, 2, Element.ALIGN_MIDDLE, 0))
                Else
                    Tabla_total.AddCell(Phrasepdf(" QUE SE IMPUTARAN DE LA SIGUIENTE MANERA: CUENTA ARANCELAMIENTO 2-02", impresor.tamaniofuente, True, 0, 1, 1, Element.ALIGN_LEFT, 2, Element.ALIGN_MIDDLE, 0))
                    ORDENDEPAGOS.DatosOrdenPago.Rows.Add({"_", "_", "2-02", "_", "_", "_", "_", "_", "_", "_", "_", 0})
                End If
                'Tabla_total.AddCell(Phrasepdf(, impresor.tamaniofuente, True, 0, 1, 1, Element.ALIGN_LEFT, 2, Element.ALIGN_MIDDLE, 0))
                'TABLA DE PARTIDAS PRESUPUESTARIAS
                'para lograr la adaptación completa debo disminuir el margen necesario
                Dim anchoutil As Single = Anchopagina - Doc.LeftMargin
                tamaniocolumna = New Single(11) {}
                Dim TABLAORDENDEPAGO As iTextSharp.text.pdf.PdfPTable = Nothing
                Select Case ORDENDEPAGOS.Ordenpago_tipo.ToUpper
                    Case Is = "ARANCELAMIENTO"
                        tamaniocolumna(0) = Convert.ToSingle(anchoutil * 0.0681) 'jur.
                        tamaniocolumna(1) = Convert.ToSingle(anchoutil * 0.0681) 'UO
                        tamaniocolumna(2) = Convert.ToSingle(anchoutil * 0.0681) 'CARAC
                        tamaniocolumna(3) = Convert.ToSingle(anchoutil * 0.0681) ' FIN
                        tamaniocolumna(4) = Convert.ToSingle(anchoutil * 0.0681) ' FUN.
                        tamaniocolumna(5) = Convert.ToSingle(anchoutil * 0.0681) 'SECC
                        tamaniocolumna(6) = Convert.ToSingle(anchoutil * 0.0681) 'SECT
                        tamaniocolumna(7) = Convert.ToSingle(anchoutil * 0.0681) ' PDA PCIAL
                        tamaniocolumna(8) = Convert.ToSingle(anchoutil * 0.0681) ' PDA PPAL
                        tamaniocolumna(9) = Convert.ToSingle(anchoutil * 0.0681) 'PDA SUB PAR
                        tamaniocolumna(10) = Convert.ToSingle(anchoutil * 0.0681) 'SCD
                        tamaniocolumna(11) = Convert.ToSingle(anchoutil * 0.25) 'IMPORTE
                        '  TABLAORDENDEPAGO = PDFDatatable_op_arancelamiento(ORDENDEPAGOS, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#ffffff")), impresor.tamaniofuentetablas)
                        TABLAORDENDEPAGO = PDFDatatablepartidapresupuestaria(ORDENDEPAGOS.DatosOrdenPago, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#ffffff")), impresor.tamaniofuentetablas)
                    Case Else
                        tamaniocolumna(0) = Convert.ToSingle(anchoutil * 0.0681) 'jur.
                        tamaniocolumna(1) = Convert.ToSingle(anchoutil * 0.0681) 'UO
                        tamaniocolumna(2) = Convert.ToSingle(anchoutil * 0.0681) 'CARAC
                        tamaniocolumna(3) = Convert.ToSingle(anchoutil * 0.0681) ' FIN
                        tamaniocolumna(4) = Convert.ToSingle(anchoutil * 0.0681) ' FUN.
                        tamaniocolumna(5) = Convert.ToSingle(anchoutil * 0.0681) 'SECC
                        tamaniocolumna(6) = Convert.ToSingle(anchoutil * 0.0681) 'SECT
                        tamaniocolumna(7) = Convert.ToSingle(anchoutil * 0.0681) ' PDA PCIAL
                        tamaniocolumna(8) = Convert.ToSingle(anchoutil * 0.0681) ' PDA PPAL
                        tamaniocolumna(9) = Convert.ToSingle(anchoutil * 0.0681) 'PDA SUB PAR
                        tamaniocolumna(10) = Convert.ToSingle(anchoutil * 0.0681) 'SCD
                        tamaniocolumna(11) = Convert.ToSingle(anchoutil * 0.25) 'IMPORTE
                        TABLAORDENDEPAGO = PDFDatatablepartidapresupuestaria(ORDENDEPAGOS.DatosOrdenPago, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#ffffff")), impresor.tamaniofuentetablas)
                End Select
                If TABLAORDENDEPAGO.Rows.Count > 1 And Not ORDENDEPAGOS.novalido Then
                    With PdfpCell_espaciovacio
                        .FixedHeight = 7.0F
                        .Colspan = TABLAORDENDEPAGO.NumberOfColumns
                    End With
                    TABLAORDENDEPAGO.AddCell(PdfpCell_espaciovacio)
                    TABLAORDENDEPAGO.AddCell(Phrasepdf(" Total: ", impresor.tamaniofuente + 1, True, 0, TABLAORDENDEPAGO.NumberOfColumns - 1, 1, Element.ALIGN_RIGHT, 0))
                    With TABLAORDENDEPAGO.AddCell(Phrasepdf(Totalsumado.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), impresor.tamaniofuente + 1, True, 0, 1, 1, Element.ALIGN_RIGHT, 1))
                        .Border = PdfPCell.TOP_BORDER
                        .BorderWidth = 1
                        .PaddingTop = 0
                    End With
                End If
                'VISTO LA LIQUIDACIÓN, ORDEN DE PAGO
                Doc.Add(Tabla_total)
                '     Doc.Add(PARRAFOPARCIAL)
                Doc.Add(TABLAORDENDEPAGO)
                Dim COLUMNA As New ColumnText(wri.DirectContent)
                'the Phrase
                'the lower left x corner (left)
                'the lower left y corner (bottom)
                'the upper right x corner (right)
                'the upper right y corner (top)
                'line height(leading)
                'alignment.
                'COLUMNA.SetSimpleColumn(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(ORDENDEPAGOS.CLASE_FONDO, PDF_fuente_variable(impresor.tamaniofuente + 6, True))),
                '                        (Doc.LeftMargin) + 50, 750,
                '                       Doc.GetBottom(0) + (TABLAORDENDEPAGO.TotalHeight / 2), (TABLAORDENDEPAGO.TotalWidth / 2) - Doc.RightMargin,
                '                        15, Element.ALIGN_LEFT)
                'COLUMNA.Go()
                tamaniocolumna = New Single(0) {}
                tamaniocolumna(0) = Convert.ToSingle(anchoutil * 1) 'jur.
                'Dim TABLAINICIALES As iTextSharp.text.pdf.PdfPTable = PDFDatatable(New DataTable, tamaniocolumna, 1, Anchopagina - Doc.LeftMargin, False, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#ffffff")), 8)
                Doc.Add(TABLA_INICIALES(anchoutil, ORDENDEPAGOS.ordenpago_USUARIO))
                Dim LISTADETEXTO As New List(Of Chunk)
                PARRAFOCOMPLETO.Clear()
                Select Case ORDENDEPAGOS.Ordenpago_tipo.ToUpper
                    Case Is = "ARANCELAMIENTO"
                        LISTADETEXTO.Add(New Chunk("VISTO: ", PDF_fuente_variable(impresor.tamaniofuente, True)))
                        LISTADETEXTO.Add(New Chunk("La liquidación que antecede, gírese a la Tesorería para su cumplimiento.", PDF_fuente_variable(impresor.tamaniofuente, False)))
                    Case Else
                        LISTADETEXTO.Add(New Chunk("VISTO: ", PDF_fuente_variable(impresor.tamaniofuente, True)))
                        LISTADETEXTO.Add(New Chunk("La liquidación que antecede, téngase por ", PDF_fuente_variable(impresor.tamaniofuente, False)))
                        LISTADETEXTO.Add(New Chunk("ORDEN de  PAGO ", PDF_fuente_variable(impresor.tamaniofuente, True)))
                        LISTADETEXTO.Add(New Chunk("y abónese de conformidad a la misma. Gírese a la Tesorería para su cumplimiento.", PDF_fuente_variable(impresor.tamaniofuente, False)))
                End Select
                For Each ITEM As Chunk In LISTADETEXTO
                    PARRAFOCOMPLETO.Add(ITEM)
                Next
                PARRAFOCOMPLETO.Alignment = Element.ALIGN_JUSTIFIED
                Doc.Add(PARRAFOCOMPLETO)
                'If Not ORDENDEPAGOS.novalido Then
                PARRAFOCOMPLETO.Clear()
                With PARRAFOCOMPLETO
                    .Add(PDFFIRMASv2(Anchopagina - Doc.LeftMargin, impresor.Sello_Contabilidad, impresor.Sello_direccion, 85))
                    '  .Add(PDFFIRMAS(Anchopagina - Doc.LeftMargin, "CONTABILIDAD", "Director",, 85))
                    .Add(PDFFIRMASv2(Anchopagina - Doc.LeftMargin, impresor.Sello_Delegadofiscal, Nothing, 85))
                    '  .Add(PDFFIRMAS(Anchopagina - Doc.LeftMargin, "DELEGADO FISCAL", "",, 85))
                End With
                Doc.Add(PARRAFOCOMPLETO)
                'Else
                Dim COLUMNA2 As New ColumnText(wri.DirectContent)
                'the Phrase
                'the lower left x corner (left)
                'the lower left y corner (bottom)
                'the upper right x corner (right)
                'the upper right y corner (top)
                'line height(leading)
                'alignment.
                Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14.0F, iTextSharp.text.Font.BOLD, BaseColor.GRAY)
                COLUMNA2.SetSimpleColumn(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("SICyF", font12Bold)),
                                        Doc.Left, Doc.Bottom,
                                      Doc.Right, 0,
                                        15, Element.ALIGN_RIGHT)
                COLUMNA2.Go()
                Doc.Close()
            End Using
            Select Case MsgBox("Abrir el archivo generado?", MsgBoxStyle.YesNoCancel, " ")
                Case MsgBoxResult.Yes
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(Controlguardado.FileName) With {
                                                 .UseShellExecute = True
        })
            End Select
            'Catch ex As Exception
            '    MessageBox.Show("NO SE PUDO GENERAR EL ARCHIVO" & vbCrLf & ex.Message)
            'End Try
        End If
    End Sub

    Public Sub PDF_ORDENPAGO_HABERESv2(ByVal ORDENDEPAGOS As Ordendepago)
        '    1.	Tabla total con 2 columnas
        'a.	TABLA Encabezado con 3 columnas (ancho total) (Posadas y fecha,expediente, y nº ordenpago)
        'b.	TABLA Texto:
        'i.	 Se  liquida  para Abonar  por la Tesorería de la Dirección del Servicio Adm. de Salud Pública s/planilla adjunta y  por  el  concepto  que se indica:
        'ii.	@tipo_de_situacion
        'iii.	@que_se_abona y @mes_abonado
        'iv.	 @observaciones
        'c.	Rendiciones a pagar
        'i.	5 columnas lado izquierdo sin encabezado
        '1.	RENDICIONES A PAGAR
        'a.	Inclinado 90º OCUPANDO EL TOTAL DE LA TABLA:
        '2.	GRUPOS
        'a.	Inclinado 90º por el numero total de celdas, ver posibles conflictos
        '3.	Subgrupos
        'a.	Inclinado 90º por el numero total de celdas, ver posibles conflictos
        '4.	Columna Concepto
        'a.	Normal, donde cada ítem de los subgrupos tiene su descripción
        '5.	Columna importe
        'a.	Normal, decimal, formato contable
        'd.	LIQUIDACIÓN A PAGAR 2 COLUMNAS, SIN ENCABEZADO
        'e.	TOTAL A PAGAR 2 COLUMNAS,SIN ENCABEZADO
        'f.	TABLA DE FIRMA JEFE CONTABILIDAD
        'g.	COLUMNA 2 DE LA TABLA (tratar de hacer lo más ancho posible)
        'i.	Tabla de firmas
        '1.	Delegado Fiscal, Director, con bordes
        'ii.	Tabla con 3 columnas
        '1.	Fecha
        '2.	Cheque
        '3.	importe
        'HOJA 2
        '•	2 COLUMNAS
        'o	COLUMNA 1 AFECTACION
        '	TABLA DE PARTIDA PRESUPUESTARIA
        '	Tabla con el total 2 columnas
        'o	COLUMNA 2 DESAFECTACION
        '	TABLA DESAFECTACION
        '•	PREV. DEF. OP. UNO DEBAJO DEL OTRO
        '•	IMPORTE
        'o	FIRMA DEL JEFE DE CONTABILIDAD.
        'DATOS DEL DOCUMENTO
        Dim impresor As New Impresion
        impresor.fecha = ORDENDEPAGOS.ordenpago_fecha
        impresor.cargartodoslossellos()
        'clase
        'itextsharp.pagesize
        'New iTextSharp.text.Font
        'font size
        impresor.marginleft = 10
        impresor.marginright = 10
        impresor.margintop = 10
        impresor.marginbottom = 10
        impresor.tamaniofuentetitulos = 14
        impresor.tamaniofuente = 9
        impresor.tamaniofuentetablas = 9
        Dialogo_impresion.Cargar_impresion(impresor)
        Dim Doc As New Document(impresor.hoja, impresor.marginleft, impresor.marginright, impresor.margintop, impresor.marginbottom)
        ''DATOS DEL DOCUMENTO
        'Dim Doc As New Document(PageSize.LEGAL, 30, 30, 20, 30)
        'Dim FileName As String = FileName
        Dim Anchopagina As Single = Doc.PageSize.Width
        'Directory
        'NOMBRE ARCHIVO
        Dim Directory As String = "C:" & "\" & "Ordenes_de_Pago" & "\" & ORDENDEPAGOS.Ordenpago_Year & "\"
        Dim archivo_nombre As String = " OP - " & ORDENDEPAGOS.ordenpago_numero & "-" & ORDENDEPAGOS.Ordenpago_Year & "_HABERES.pdf"
        archivo_nombre = Guardararchivo(Directory, archivo_nombre)
        If archivo_nombre = "" Then
            Exit Sub
        Else
            Dim FileName As String = archivo_nombre
            Using wri = PdfWriter.GetInstance(Doc, New FileStream(FileName, FileMode.Create))
                'Abrir el documento para el uso
                Doc.Open()
                'Insertar una página en blanco nueva
                Doc.NewPage()
                'ENCABEZADO
                'Crear tabla General para cargar los bordes
                Dim Tabla_total As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(1)
                Tabla_total.TotalWidth = Anchopagina - Doc.LeftMargin
                Tabla_total.LockedWidth = True
                Dim Celdapdf_local As PdfPCell = Nothing
                Dim anchoutil As Single = Anchopagina
                '    1.	Tabla total con 2 columnas
                Dim tamaniocolumna As Single() = New Single(0) {}
                tamaniocolumna(0) = Convert.ToSingle(anchoutil * 1)
                Tabla_total.SetWidths(tamaniocolumna)
                'a.	TABLA Encabezado con 3 columnas (ancho total) (Posadas y fecha,expediente, y nº ordenpago)
                Dim Tabla_Encabezado As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(3)
                tamaniocolumna = New Single(2) {}
                tamaniocolumna(0) = Convert.ToSingle(anchoutil * 0.33)
                tamaniocolumna(1) = Convert.ToSingle(anchoutil * 0.33)
                tamaniocolumna(2) = Convert.ToSingle(anchoutil * 0.34)
                Tabla_Encabezado.SetWidths(tamaniocolumna)
                Dim TEXTO As New Paragraph
                With Tabla_Encabezado.AddCell(New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Posadas " & ORDENDEPAGOS.ordenpago_fecha.ToShortDateString, PDF_fuente_variable(impresor.tamaniofuente, True)))))
                    .VerticalAlignment = (Element.ALIGN_TOP)
                    .HorizontalAlignment = Element.ALIGN_CENTER
                End With
                With Tabla_Encabezado.AddCell(New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Expediente Nº" & vbCrLf & ORDENDEPAGOS.expediente_op.Expediente_N, PDF_fuente_variable(impresor.tamaniofuentetitulos, True)))))
                    .VerticalAlignment = (Element.ALIGN_TOP)
                    .HorizontalAlignment = Element.ALIGN_CENTER
                End With
                With Tabla_Encabezado.AddCell(New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("ORDEN DE PAGO Nº " & vbCrLf & ORDENDEPAGOS.ordenpago_numero & "/" & ORDENDEPAGOS.Ordenpago_Year, PDF_fuente_variable(impresor.tamaniofuentetitulos, True)))))
                    .VerticalAlignment = (Element.ALIGN_TOP)
                    .HorizontalAlignment = Element.ALIGN_CENTER
                End With
                Tabla_Encabezado.WidthPercentage = 100
                'Tabla_Encabezado.LockedWidth = True
                'Tabla_Encabezado.SetWidthPercentage = 100
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(Tabla_Encabezado, 0.5, 2)))
                'b.	TABLA Texto:
                'i.	 Se  liquida  para Abonar  por la Tesorería de la Dirección del Servicio Adm. de Salud Pública s/planilla adjunta y  por  el  concepto  que se indica:
                'ii.	@tipo_de_situacion
                'iii.	@que_se_abona y @mes_abonado
                'iv.	 @observaciones
                Dim Tabla_texto As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(1)
                tamaniocolumna = New Single(0) {}
                tamaniocolumna(0) = Convert.ToSingle(anchoutil * 1)
                Tabla_texto.SetWidths(tamaniocolumna)
                Dim listadodechunks As New List(Of Chunk)
                listadodechunks.Add(New iTextSharp.text.Chunk("Se liquida  para Abonar  por la Tesorería de la Dirección del " & Autorizaciones.Nombrecompletodelservicio & " s/planilla adjunta y  por  el  concepto  que se indica:", PDF_fuente_variable(impresor.tamaniofuente, False)))
                listadodechunks.Add(New iTextSharp.text.Chunk(ORDENDEPAGOS.ordenpago_Detalle, PDF_fuente_variable(11, True)))
                listadodechunks.Add(New iTextSharp.text.Chunk(vbNewLine & ORDENDEPAGOS.ordenpago_Detalle2, PDF_fuente_variable(10, False)))
                Select Case ORDENDEPAGOS.Haberes_recuperovarios > 0
                    Case True
                        listadodechunks.Add(New iTextSharp.text.Chunk(" LA DIFERENCIA " &
                                                                      ORDENDEPAGOS.Haberes_recuperovarios.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")) & " CORRESPONDE A RECUPERO VARIOS ", PDF_fuente_variable(impresor.tamaniofuente, False)))
                    Case False
                End Select
                Tabla_texto.WidthPercentage = 100
                With Tabla_texto.AddCell(New PdfPCell(ParrafoPdF(listadodechunks)))
                    .HorizontalAlignment = Element.ALIGN_JUSTIFIED
                    .SetLeading(impresor.tamaniofuente, 1)
                    .Padding = 1
                End With
                Tabla_total.AddCell(New PdfPCell(Tabla_texto))
                'AGREGAR LA TABLA TOTAL y posteriormente borrarla
                Doc.Add(Tabla_total)
                '1.	Tabla total con 2 columnas
                Tabla_total = New iTextSharp.text.pdf.PdfPTable(2)
                Tabla_total.TotalWidth = Anchopagina - Doc.LeftMargin
                Tabla_total.LockedWidth = True
                tamaniocolumna = New Single(1) {}
                tamaniocolumna(0) = Convert.ToSingle(anchoutil * 0.5)
                tamaniocolumna(1) = Convert.ToSingle(anchoutil * 0.5)
                Tabla_total.SetWidths(tamaniocolumna)
                'c.	Rendiciones a pagar
                'i.	5 columnas lado izquierdo sin encabezado
                Dim Tabla_Sueldoizquierdo As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(5)
                Dim tamaniocolumna_TEMPORAL = New Single(4) {}
                tamaniocolumna_TEMPORAL(0) = Convert.ToSingle(tamaniocolumna(0) * 0.05)
                tamaniocolumna_TEMPORAL(1) = Convert.ToSingle(tamaniocolumna(0) * 0.05)
                tamaniocolumna_TEMPORAL(2) = Convert.ToSingle(tamaniocolumna(0) * 0.05)
                tamaniocolumna_TEMPORAL(3) = Convert.ToSingle(tamaniocolumna(0) * 0.42)
                tamaniocolumna_TEMPORAL(4) = Convert.ToSingle(tamaniocolumna(0) * 0.42)
                '1.	RENDICIONES A PAGAR
                'a.	Inclinado 90º OCUPANDO EL TOTAL DE LA TABLA:
                '2.	GRUPOS
                'a.	Inclinado 90º por el numero total de celdas, ver posibles conflictos
                '3.	Subgrupos
                'a.	Inclinado 90º por el numero total de celdas, ver posibles conflictos
                '4.	Columna Concepto
                'a.	Normal, donde cada ítem de los subgrupos tiene su descripción
                '5.	Columna importe
                'a.	Normal, decimal, formato contable
                Tabla_Sueldoizquierdo.SetWidths(tamaniocolumna_TEMPORAL)
                Celdapdf_local = New iTextSharp.text.pdf.PdfPCell
                TEXTO.Clear()
                TEXTO.Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("CONCEPTO", PDF_fuente_variable(impresor.tamaniofuente, True))))
                TEXTO.Alignment = Element.ALIGN_CENTER
                Celdapdf_local.Colspan = 4
                Celdapdf_local.AddElement(TEXTO)
                Tabla_Sueldoizquierdo.AddCell(Celdapdf_local)
                'Celdapdf_local = New iTextSharp.text.pdf.PdfPCell
                'Celdapdf_local.AddElement(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("IMPORTE", PDF_fuente_variable(10, True))))
                'With Celdapdf_local
                '    '  .SetLeading(10, 1)
                '    .HorizontalAlignment = Element.ALIGN_RIGHT
                '    .Colspan = 1
                'End With
                Celdapdf_local = New PdfPCell
                TEXTO.Clear()
                TEXTO.Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("IMPORTE", PDF_fuente_variable(impresor.tamaniofuente, True))))
                TEXTO.Alignment = Element.ALIGN_CENTER
                Celdapdf_local.Colspan = 1
                Celdapdf_local.AddElement(TEXTO)
                Tabla_Sueldoizquierdo.AddCell(Celdapdf_local)
                'CELDAS DE ITEMS CORRESPONDIENTE AL DETALLE DE HABERES
                Dim TOTALDECELDAS As Integer = ORDENDEPAGOS.HABERES_DETALLE.Rows.Count - 1
                Dim TABLAS As New List(Of DataTable)
                Dim TABLASSUB As New List(Of DataTable)
                Dim LISTADOGRUPOS As New List(Of String)
                Dim LISTADOGRUPOS_CANT As New List(Of Integer)
                Dim LISTADOSUBGRUPOSCONTROL As New List(Of String) 'DEBERIA SER TEMPORAL HASTA ENCONTRAR UNA MEJOR SOLUCIÓN
                Dim LISTADOSUBGRUPOS As New List(Of String)
                Dim LISTADOSUBGRUPOS_CANT As New List(Of Integer)
                Dim VALORDEFILA As Integer = 0
                For X = 0 To ORDENDEPAGOS.HABERES_DETALLE.Rows.Count - 1
                    If Not LISTADOGRUPOS.Contains(ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("GRUPO").ToString, StringComparer.OrdinalIgnoreCase) Then
                        LISTADOGRUPOS.Add(ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("GRUPO").ToString)
                        TABLAS.Add(New DataTable)
                        With TABLAS.Item(TABLAS.Count - 1)
                            .Columns.Add("GRUPO")
                            .Columns.Add("SUBGRUPO")
                            .Columns.Add("DENOMINACION")
                            .Columns.Add("IMPORTE")
                        End With
                        TABLAS.Item(TABLAS.Count - 1).Rows.Add({ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("GRUPO").ToString, ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("SUBGRUPO").ToString, ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("DENOMINACION").ToString, ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("IMPORTE")})
                    Else
                        TABLAS.Item(TABLAS.Count - 1).Rows.Add({ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("GRUPO").ToString, ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("SUBGRUPO").ToString, ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("DENOMINACION").ToString, ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("IMPORTE")})
                        'SOLO PARA CONTROL
                    End If
                    If Not LISTADOSUBGRUPOSCONTROL.Contains(ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("GRUPO").ToString.ToUpper & "-" & ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("SUBGRUPO").ToString.ToUpper, StringComparer.OrdinalIgnoreCase) Then
                        LISTADOSUBGRUPOSCONTROL.Add(ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("GRUPO").ToString.ToUpper & "-" & ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("SUBGRUPO").ToString.ToUpper)
                        LISTADOSUBGRUPOS.Add(ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("SUBGRUPO").ToString)
                        TABLASSUB.Add(New DataTable)
                        With TABLASSUB.Item(TABLASSUB.Count - 1)
                            .Columns.Add("GRUPO")
                            .Columns.Add("SUBGRUPO")
                            .Columns.Add("DENOMINACION")
                            .Columns.Add("IMPORTE")
                        End With
                        TABLASSUB.Item(TABLASSUB.Count - 1).Rows.Add({ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("GRUPO").ToString, ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("SUBGRUPO").ToString, ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("DENOMINACION").ToString, ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("IMPORTE")})
                    Else
                        TABLASSUB.Item(TABLASSUB.Count - 1).Rows.Add({ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("GRUPO").ToString, ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("SUBGRUPO").ToString, ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("DENOMINACION").ToString, ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("IMPORTE")})
                        'SOLO PARA CONTROL
                    End If
                Next
                For Z = 0 To LISTADOGRUPOS.Count - 1
                    LISTADOGRUPOS_CANT.Add(0)
                    For X = 0 To ORDENDEPAGOS.HABERES_DETALLE.Rows.Count - 1
                        If ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("GRUPO").ToString = (LISTADOGRUPOS(Z)) Then
                            LISTADOGRUPOS_CANT(Z) += 1
                        Else
                            'SOLO PARA CONTROL
                        End If
                    Next
                Next
                For Z = 0 To LISTADOSUBGRUPOS.Count - 1
                    LISTADOSUBGRUPOS_CANT.Add(0)
                    For X = 0 To ORDENDEPAGOS.HABERES_DETALLE.Rows.Count - 1
                        If ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("SUBGRUPO").ToString = (LISTADOSUBGRUPOS(Z)) Then
                            LISTADOSUBGRUPOS_CANT(Z) += 1
                        Else
                            'SOLO PARA CONTROL
                        End If
                    Next
                Next
                'INCLINADOS
                With Tabla_Sueldoizquierdo.AddCell(New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("RENDICIONES A PAGAR", PDF_fuente_variable(impresor.tamaniofuentetablas, True)))))
                    .BorderWidth = 0.5
                    .Rotation = 90
                    ' .VerticalAlignment = Element.ALIGN_BASELINE
                    .HorizontalAlignment = Element.ALIGN_CENTER
                    '    .SetLeading(9, 1.2)
                    .Rowspan = TOTALDECELDAS + 1
                    .Colspan = 1
                End With
                For GRUPOS = 0 To LISTADOGRUPOS.Count - 1
                    'AGREGAR GRUPO
                    With Tabla_Sueldoizquierdo.AddCell(New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(LISTADOGRUPOS(GRUPOS), PDF_fuente_variable(impresor.tamaniofuentetablas, True)))))
                        .BorderWidth = 0.5
                        .Rotation = 90
                        '.VerticalAlignment = Element.ALIGN_BASELINE
                        .HorizontalAlignment = Element.ALIGN_CENTER
                        '  .SetLeading(9, 1.2)
                        .Rowspan = TABLAS.Item(GRUPOS).Rows.Count
                        .Colspan = 1
                    End With
                    For I = 0 To TABLASSUB.Count - 1
                        'CARGA DE SUBGRUPOS Y SU ITEM
                        If TABLASSUB.Item(I).Rows(0).Item("GRUPO").ToString.ToUpper = LISTADOGRUPOS(GRUPOS).ToUpper Then
                            'AGREGAR SUBGRUPO
                            With Tabla_Sueldoizquierdo.AddCell(New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(TABLASSUB.Item(I).Rows(0).Item("SUBGRUPO").ToString, PDF_fuente_variable(impresor.tamaniofuentetablas, True)))))
                                .BorderWidth = 0.5
                                .Rotation = 90
                                '.VerticalAlignment = Element.ALIGN_BASELINE
                                .HorizontalAlignment = Element.ALIGN_CENTER
                                '      .SetLeading(9, 1.2)
                                .Rowspan = TABLASSUB.Item(I).Rows.Count
                                .Colspan = 1
                            End With
                            '---------------------------------------DATOS DE CADA UNA DE LAS FILAS-----------------------------------
                            For Z = 0 To TABLASSUB.Item(I).Rows.Count - 1
                                With Tabla_Sueldoizquierdo.AddCell(New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(
                                                                                                           TABLASSUB.Item(I).Rows(Z).Item("DENOMINACION").ToString, PDF_fuente_variable(impresor.tamaniofuentetablas - 1, False)))))
                                    .SetLeading(impresor.tamaniofuentetablas - 1, 1)
                                    .VerticalAlignment = Element.ALIGN_MIDDLE
                                    '.Colspan = 1
                                End With
                                Select Case CType(TABLASSUB.Item(I).Rows(Z).Item("IMPORTE"), Decimal) <> 0
                                    Case True
                                        With Tabla_Sueldoizquierdo.AddCell(New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(
                                                                                  CType(TABLASSUB.Item(I).Rows(Z).Item("IMPORTE"), Decimal).ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")),
                                                                                  PDF_fuente_variable(10, False)))))
                                            .SetLeading(impresor.tamaniofuentetablas - 1, 1)
                                            .HorizontalAlignment = Element.ALIGN_RIGHT
                                        End With
                                    Case False
                                        With Tabla_Sueldoizquierdo.AddCell(New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(
                                                                                                                   "-", PDF_fuente_variable(impresor.tamaniofuentetablas - 1, False)))))
                                            .SetLeading(impresor.tamaniofuentetablas - 1, 1)
                                            .HorizontalAlignment = Element.ALIGN_RIGHT
                                        End With
                                End Select
                            Next
                        End If
                    Next
                Next
                'AGREGAR DATOS
                'tablascomogrupos ver si se puede almacenar en la base de datos, he aqui la parte mas larga debe almacenarse con la clave de la orden de pago
                'COMPLETARRRR
                'e.	TOTAL A PAGAR 2 COLUMNAS,SIN ENCABEZADO
                'f.	TABLA DE FIRMA JEFE CONTABILIDAD
                Tabla_Sueldoizquierdo.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("LIQUIDACIÓN A PAGAR", PDF_fuente_variable(impresor.tamaniofuentetablas + 1, True))), 0.5, 4, 1, 2, 1)))
                Celdapdf_local = New PdfPCell
                TEXTO = New Paragraph
                TEXTO.Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(ORDENDEPAGOS.Haberes_liquidacionapagar.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), PDF_fuente_variable(impresor.tamaniofuentetablas + 1, True))))
                TEXTO.Alignment = Element.ALIGN_RIGHT
                Celdapdf_local.Colspan = 1
                Celdapdf_local.AddElement(TEXTO)
                Tabla_Sueldoizquierdo.AddCell(Celdapdf_local)
                'Tabla_Sueldoizquierdo.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(
                '                                                                                                   ORDENDEPAGOS.ordenpago_montototal.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")),
                '                                                                                                   PDF_fuente_variable(10, True))), 0.5, 1, 1, Element.ALIGN_RIGHT, 1)))
                Tabla_Sueldoizquierdo.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("TOTAL GENERAL", PDF_fuente_variable(impresor.tamaniofuentetablas + 2, True))), 0.5, 4, 1, 0, 1)))
                Celdapdf_local = New PdfPCell
                TEXTO = New Paragraph
                TEXTO.Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk((ORDENDEPAGOS.ordenpago_montototal).ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), PDF_fuente_variable(impresor.tamaniofuentetablas + 2, True))))
                TEXTO.Alignment = Element.ALIGN_RIGHT
                Celdapdf_local.Colspan = 1
                Celdapdf_local.AddElement(TEXTO)
                Tabla_Sueldoizquierdo.AddCell(Celdapdf_local)
                'Tabla_Sueldoizquierdo.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(
                '                                                                                                   ORDENDEPAGOS.ordenpago_montototal.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")),
                '                                                                                                   PDF_fuente_variable(10, True))), 0.5, 1, 1, Element.ALIGN_RIGHT, 1)))
                'f.	TABLA DE FIRMA JEFE CONTABILIDAD
                Celdapdf_local = New PdfPCell(Elementopdf_a_Celda_conborde(Sello_impresion(impresor.Sello_Contabilidad), 0, 5, 1, 1))
                With Celdapdf_local
                    .VerticalAlignment = Element.ALIGN_BOTTOM
                    .Border = 0
                    .PaddingBottom = 4
                    .MinimumHeight = 60
                End With
                Tabla_Sueldoizquierdo.AddCell(Celdapdf_local)
                Tabla_Sueldoizquierdo.WidthPercentage = 98
                With Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(Tabla_Sueldoizquierdo, 0.5, 1)))
                End With
                'd.	LIQUIDACIÓN A PAGAR 10 COLUMNAS, SIN ENCABEZADO
                Dim Tabla_Sueldoderecho As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(10)
                tamaniocolumna = New Single(9) {}
                tamaniocolumna(0) = Convert.ToSingle(anchoutil * 0.1)
                tamaniocolumna(1) = Convert.ToSingle(anchoutil * 0.1)
                tamaniocolumna(2) = Convert.ToSingle(anchoutil * 0.1)
                tamaniocolumna(3) = Convert.ToSingle(anchoutil * 0.1)
                tamaniocolumna(4) = Convert.ToSingle(anchoutil * 0.1)
                tamaniocolumna(5) = Convert.ToSingle(anchoutil * 0.1)
                tamaniocolumna(6) = Convert.ToSingle(anchoutil * 0.1)
                tamaniocolumna(7) = Convert.ToSingle(anchoutil * 0.1)
                tamaniocolumna(8) = Convert.ToSingle(anchoutil * 0.1)
                tamaniocolumna(9) = Convert.ToSingle(anchoutil * 0.1)
                Tabla_Sueldoderecho.SetWidths(tamaniocolumna)
                impresor.Sello_Delegadofiscal.Sellofuentetamanio = impresor.Sello_Delegadofiscal.Sellofuentetamanio - 2
                impresor.Sello_direccion.Sellofuentetamanio = impresor.Sello_direccion.Sellofuentetamanio - 2
                Tabla_Sueldoderecho.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PDFFIRMASv2(anchoutil * 0.5, impresor.Sello_Delegadofiscal, impresor.Sello_direccion), 0.5, 10, 1, 0, 10, 6)))
                impresor.Sello_Delegadofiscal.Sellofuentetamanio = impresor.Sello_Delegadofiscal.Sellofuentetamanio + 2
                impresor.Sello_direccion.Sellofuentetamanio = impresor.Sello_direccion.Sellofuentetamanio + 2
                Celdapdf_local = New iTextSharp.text.pdf.PdfPCell
                With Celdapdf_local
                    .AddElement(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Fecha", PDF_fuente_variable(impresor.tamaniofuentetablas, False))))
                    .HorizontalAlignment = Element.ALIGN_CENTER
                    .VerticalAlignment = (Element.ALIGN_TOP)
                    .BorderWidth = 0.5
                    .Rowspan = 1
                    .Colspan = 2
                    .Padding = 1
                End With
                Tabla_Sueldoderecho.AddCell(Celdapdf_local)
                Celdapdf_local = New iTextSharp.text.pdf.PdfPCell
                With Celdapdf_local
                    .AddElement(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Cheque", PDF_fuente_variable(impresor.tamaniofuentetablas, False))))
                    .HorizontalAlignment = Element.ALIGN_CENTER
                    .VerticalAlignment = (Element.ALIGN_TOP)
                    .BorderWidth = 0.5
                    .Rowspan = 1
                    .Colspan = 3
                    .Padding = 0
                End With
                Tabla_Sueldoderecho.AddCell(Celdapdf_local)
                Celdapdf_local = New iTextSharp.text.pdf.PdfPCell
                With Celdapdf_local
                    .AddElement(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Importe", PDF_fuente_variable(impresor.tamaniofuentetablas, False))))
                    .HorizontalAlignment = Element.ALIGN_CENTER
                    .VerticalAlignment = (Element.ALIGN_TOP)
                    .BorderWidth = 0.5
                    .Rowspan = 1
                    .Colspan = 5
                    .Padding = 0
                End With
                Tabla_Sueldoderecho.AddCell(Celdapdf_local)
                '39 filas
                For x = 0 To 38
                    With Tabla_Sueldoderecho.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(impresor.tamaniofuentetablas, True))), 0.5, 2, 1, 1, 1, 5)))
                        .VerticalAlignment = Element.ALIGN_MIDDLE
                        .HorizontalAlignment = Element.ALIGN_CENTER
                        .SetLeading(impresor.tamaniofuentetablas, 1.2)
                        .Padding = 2.5
                    End With
                    With Tabla_Sueldoderecho.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(impresor.tamaniofuentetablas, True))), 0.5, 3, 1, 1, 1, 5)))
                        .SetLeading(impresor.tamaniofuentetablas, 1.2)
                        .Padding = 2.5
                    End With
                    With Tabla_Sueldoderecho.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(impresor.tamaniofuentetablas, True))), 0.5, 5, 1, 1, 1, 5)))
                        .SetLeading(impresor.tamaniofuentetablas, 1.2)
                        .Padding = 2.5
                    End With
                Next
                '         Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(Tabla_Sueldoizquierdo, 1, 1, 1)))
                Tabla_Sueldoderecho.WidthPercentage = 100
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(Tabla_Sueldoderecho, 0, 1, 1, Element.ALIGN_JUSTIFIED, 0, Element.ALIGN_TOP)))
                'g.	COLUMNA 2 DE LA TABLA (tratar de hacer lo más ancho posible)
                'i.	Tabla de firmas
                '1.	Delegado Fiscal, Director, con bordes
                'ii.	Tabla con 3 columnas
                '1.	Fecha
                '2.	Cheque
                '3.	importe
                Doc.Add(Tabla_total)
                Doc.Add(TABLA_INICIALES(anchoutil, ORDENDEPAGOS.ordenpago_USUARIO))
                Doc.NewPage()
                'TABLA DE PARTIDAS PRESUPUESTARIAS
                'para lograr la adaptación completa debo disminuir el margen necesario
                Tabla_total = New iTextSharp.text.pdf.PdfPTable(14)
                Tabla_total.TotalWidth = Anchopagina - Doc.LeftMargin
                widths = New Single(13) {}
                widths(0) = Convert.ToSingle(Tabla_total.TotalWidth * 0.0375) 'jur.
                widths(1) = Convert.ToSingle(Tabla_total.TotalWidth * 0.0375) 'UO
                widths(2) = Convert.ToSingle(Tabla_total.TotalWidth * 0.07) 'CARAC
                widths(3) = Convert.ToSingle(Tabla_total.TotalWidth * 0.0375) ' FIN
                widths(4) = Convert.ToSingle(Tabla_total.TotalWidth * 0.0425) ' FUN.
                widths(5) = Convert.ToSingle(Tabla_total.TotalWidth * 0.075) 'SECC
                widths(6) = Convert.ToSingle(Tabla_total.TotalWidth * 0.075) 'SECT
                widths(7) = Convert.ToSingle(Tabla_total.TotalWidth * 0.075) ' PDA PCIAL
                widths(8) = Convert.ToSingle(Tabla_total.TotalWidth * 0.075) ' PDA PPAL
                widths(9) = Convert.ToSingle(Tabla_total.TotalWidth * 0.075) 'PDA SUB PAR
                widths(10) = Convert.ToSingle(Tabla_total.TotalWidth * 0.075) 'SCD
                widths(11) = Convert.ToSingle(Tabla_total.TotalWidth * 0.2) 'IMPORTE
                widths(12) = Convert.ToSingle(Tabla_total.TotalWidth * 0.075) 'PREV DEF OP
                widths(13) = Convert.ToSingle(Tabla_total.TotalWidth * 0.2) 'IMPORTE
                Tabla_total.SetWidths(widths)
                Tabla_total.LockedWidth = True
                Dim TABLAORDENDEPAGO As iTextSharp.text.pdf.PdfPTable = PDFDatatable_OP_HABERES(ORDENDEPAGOS.DatosOrdenPago, 5, Anchopagina - Doc.LeftMargin, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#ffffff")), impresor.tamaniofuentetablas)
                '     Doc.Add(PARRAFOPARCIAL)
                'TEXTO.Clear()
                'With TEXTO
                '    .Add(PDFFIRMAS(Anchopagina - Doc.LeftMargin, "", "CONTABILIDAD"))
                'End With
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(TABLAORDENDEPAGO, 0.5, 14, 1)))
                Dim sumatotal As Decimal = 0
                For x = 0 To ORDENDEPAGOS.DatosOrdenPago.Rows.Count - 1
                    sumatotal += ORDENDEPAGOS.DatosOrdenPago.Rows(x).Item("importe")
                Next
                Celdapdf_local = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("TOTAL", PDF_fuente_variable(impresor.tamaniofuentetablas + 1, True)))) With {
            .BorderWidth = 0.5,
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_RIGHT,
            .Padding = 3,
            .Colspan = 11
        }
                Tabla_total.AddCell(Celdapdf_local)
                Tabla_total.AddCell(Phrasepdf(sumatotal.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), impresor.tamaniofuentetablas + 1, True, 0.5, 1, 1, Element.ALIGN_RIGHT, 3))
                Celdapdf_local = New iTextSharp.text.pdf.PdfPCell
                With Celdapdf_local
                    .AddElement(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(impresor.tamaniofuentetablas, True))))
                    .HorizontalAlignment = Element.ALIGN_RIGHT
                    .VerticalAlignment = (Element.ALIGN_TOP)
                    .BorderWidth = 0.5
                    .Rowspan = 1
                    .Colspan = 2
                    .Padding = 0
                End With
                Tabla_total.AddCell(Celdapdf_local)
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(
                                       PDFFIRMASv2(anchoutil, Nothing, impresor.Sello_Contabilidad), 0.5, 14, 1,, 5)))
                'Agrega la leyenda de Expediente autorizante si este existe
                If ORDENDEPAGOS.ClaveExpediente_principal.ToString.Length = 13 Then
                    Tabla_total.AddCell(Phrasepdf("Expte. Autorizante: " & ORDENDEPAGOS.ClaveExpediente_principal.ToString.Substring(4, 4) & "-" &
                                                     Convert.ToInt32(ORDENDEPAGOS.ClaveExpediente_principal.ToString.Substring(8, 5)) & "/" &
                                                    ORDENDEPAGOS.ClaveExpediente_principal.ToString.Substring(0, 4), impresor.tamaniofuente, True, 0, 14, 1, Element.ALIGN_LEFT, 1, Element.ALIGN_MIDDLE))
                Else
                End If
                'PDFFIRMAS(anchoutil, "", "CONTABILIDAD"), 0.5, 14, 1,, 5)))
                'TABLAORDENDEPAGO.AddCell(New PdfPCell((TABLA_INICIALES(anchoutil, ORDENDEPAGOS.ordenpago_USUARIO))))
                Doc.Add(Tabla_total)
                Doc.Add(TABLA_INICIALES(anchoutil, ORDENDEPAGOS.ordenpago_USUARIO))
                Dim COLUMNA2 As New ColumnText(wri.DirectContent)
                'the Phrase
                'the lower left x corner (left)
                'the lower left y corner (bottom)
                'the upper right x corner (right)
                'the upper right y corner (top)
                'line height(leading)
                'alignment.
                Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14.0F, iTextSharp.text.Font.BOLD, BaseColor.GRAY)
                COLUMNA2.SetSimpleColumn(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("SICyF", font12Bold)),
                                        Doc.Left, Doc.Bottom,
                                      Doc.Right, 0,
                                        15, Element.ALIGN_RIGHT)
                COLUMNA2.Go()
                Doc.Close()
            End Using
            Select Case MsgBox("Abrir el archivo generado?", MsgBoxStyle.YesNoCancel, " ")
                Case MsgBoxResult.Yes
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(FileName) With {
                                             .UseShellExecute = True
    })
            End Select
        End If
    End Sub

    Public Sub Generaciondepedidodefondosv2(ByVal PedidoFondo As PedidoFondos)
        Dim Pedidodefondos_datatable As New DataTable
        Dim Numdecuenta_datatable As New DataTable
        Dim Caracterdecuenta1 As New DataTable
        Dim Caracterdecuenta2 As New DataTable
        Dim Cuentadepresupuesto_datatable As New DataTable
        Dim Transferidoportesoreríageneral_datatable As New DataTable
        'DATOS DEL DOCUMENTO
        Dim impresor As New Impresion
        impresor.fecha = PedidoFondo.Fecha_Pedido
        impresor.cargartodoslossellos()
        'clase
        'itextsharp.pagesize
        'New iTextSharp.text.Font
        'font size
        impresor.marginleft = 30
        impresor.marginright = 30
        impresor.margintop = 20
        impresor.marginbottom = 30
        impresor.tamaniofuentetitulos = 14
        impresor.tamaniofuente = 8
        impresor.tamaniofuentetablas = 8
        Dialogo_impresion.Cargar_impresion(impresor)
        Dim Doc As New Document(impresor.hoja, impresor.marginleft, impresor.marginright, impresor.margintop, impresor.marginbottom)
        ''DATOS DEL DOCUMENTO
        Dim Anchopagina As Single = Doc.PageSize.Width
        'declaración de Fuentes a utilizar en el archivo
        'para insertar un espacio entre las celdas
        Dim PdfpCell_espaciovacio As iTextSharp.text.pdf.PdfPCell = New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, impresor.tamaniofuentetitulos + 2, iTextSharp.text.Font.BOLD, BaseColor.BLACK))))
        PdfpCell_espaciovacio.BorderWidth = 0
        PdfpCell_espaciovacio.FixedHeight = 2.0F
        PdfpCell_espaciovacio = New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("", PDF_fuente_variable(impresor.tamaniofuente, True))))
        Dim Controlguardado As New SaveFileDialog
        With Controlguardado
            Select Case System.IO.Directory.Exists("C:" & "\" & "PEDIDOS_DE_FONDO" & "\" & PedidoFondo.YearPedidoFondo & "\")
                Case True
                Case False
                    System.IO.Directory.CreateDirectory("C:" & "\" & "PEDIDOS_DE_FONDO" & "\" & PedidoFondo.YearPedidoFondo & "\")
            End Select
            .Filter = "ARCHIVO PDF|*.pdf"
            .Title = "Guardar en archivo PDF"
            .FileName = PedidoFondo.N_PedidoFondo & "-" & PedidoFondo.YearPedidoFondo & ".pdf"
            .RestoreDirectory = True
            .InitialDirectory = "C:" & "\" & "PEDIDOS_DE_FONDO" & "\" & PedidoFondo.YearPedidoFondo & "\"
        End With
        Controlguardado.Filter = "ARCHIVO PDF|*.pdf"
        Controlguardado.Title = "Guardar en archivo PDF"
        Controlguardado.ShowDialog()
        If Controlguardado.FileName = "" Then
            MsgBox("Para poder proceder a la creación del archivo se requiere un nombre")
            Exit Sub
        Else
            Dim FileName As String = Controlguardado.FileName
            Using wri = PdfWriter.GetInstance(Doc, New FileStream(FileName, FileMode.Create))
                'Abrir el documento para el uso
                Doc.Open()
                'Insertar una página en blanco nueva
                Doc.NewPage()
                'Crear tabla General para cargar los bordes
                Dim Tabla_total As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(1)
                Tabla_total.TotalWidth = Anchopagina - Doc.LeftMargin
                Tabla_total.LockedWidth = True
                Dim tamaniocolumna_total As Single() = New Single(0) {}
                tamaniocolumna_total(0) = Convert.ToSingle(Anchopagina - Doc.LeftMargin * 1)
                Tabla_total.SetWidths(tamaniocolumna_total)
                'Creación de la celda que manejaria cada uno de los cuadros
                Dim PARRAFOCOMPLETO As New iTextSharp.text.Paragraph()
                Dim Phrasetemporal As New iTextSharp.text.Phrase()
                'Crear tabla para manejar los encabezados---------------------------------------------------------------------------------------------
                Dim Encabezadosx As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(2)
                Encabezadosx.TotalWidth = Anchopagina - Doc.LeftMargin
                Encabezadosx.LockedWidth = True
                'Declaración variable de ancho de columnas
                Dim tamaniocolumna As Single() = New Single(1) {}
                tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.2)
                tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.8)
                Encabezadosx.SetWidths(tamaniocolumna)
                'crear imagen con logo a la izquierda
                Dim manejadorimagen As iTextSharp.text.Image = Image.GetInstance(My.Resources.Logo, System.Drawing.Imaging.ImageFormat.Jpeg)
                'asignar la imagen itextsharp a la celda
                Dim PdfPCell As iTextSharp.text.pdf.PdfPCell = New PdfPCell(manejadorimagen, True)
                PdfPCell.Rowspan = 2
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_LEFT
                PdfPCell.FixedHeight = 70.0F
                Encabezadosx.AddCell(PdfPCell)
                'Encabezado del año
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Encabezadodelyear(PedidoFondo.Fecha_Pedido.Year), PDF_fuente_variable(impresor.tamaniofuente, True))))
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.FixedHeight = 25.0F
                Encabezadosx.AddCell(PdfPCell)
                '----------------------NOMBRE DEL SERVICIO ADMINISTRATIVO------------------------------
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Nombrecompletodelservicio.ToUpper, PDF_fuente_variable(impresor.tamaniofuente + 2, True))))
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.FixedHeight = 25.0F
                Encabezadosx.AddCell(PdfPCell)
                '----------------------AGREGA EL ENCABEZADO Completo------------------------------
                ' Frase_total.Clear()
                PARRAFOCOMPLETO.Add(Encabezadosx)
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
                Tabla_total.AddCell(PdfpCell_espaciovacio)
                ' Doc.Add(Encabezadosx)
                '----------------------ORDEN DE ENTREGA DE FONDOS------------------------------
                Dim Ordenentregafondos As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(4)
                Ordenentregafondos.TotalWidth = Anchopagina - Doc.LeftMargin
                Ordenentregafondos.LockedWidth = True
                tamaniocolumna = New Single(3) {}
                tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.3)
                tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.2)
                tamaniocolumna(2) = Convert.ToSingle(Anchopagina * 0.2)
                tamaniocolumna(3) = Convert.ToSingle(Anchopagina * 0.3)
                Ordenentregafondos.SetWidths(tamaniocolumna)
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("ORDEN DE ENTREGA DE FONDOS Nº", PDF_fuente_variable(impresor.tamaniofuente - 2, False))))
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT
                Ordenentregafondos.AddCell(PdfPCell)
                '
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(impresor.tamaniofuente, False))))
                PdfPCell.BorderWidth = 1
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                Ordenentregafondos.AddCell(PdfPCell)
                '
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(impresor.tamaniofuente, False))))
                PdfPCell.BorderWidth = 1
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                Ordenentregafondos.AddCell(PdfPCell)
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("     FECHA:", PDF_fuente_variable(impresor.tamaniofuente, False))))
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_LEFT
                Ordenentregafondos.AddCell(PdfPCell)
                '----------------------AGREGA ORDEN DE ENTREGA------------------------------
                'Frase_total.Clear()
                PARRAFOCOMPLETO.Clear()
                PARRAFOCOMPLETO.Add(Ordenentregafondos)
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0.5)))
                Tabla_total.AddCell(PdfpCell_espaciovacio)
                '----------------------Nº pedido de fondos------------------------------
                Dim Espaciodescripcionpedidofondo As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(3)
                Espaciodescripcionpedidofondo.TotalWidth = Anchopagina - Doc.LeftMargin
                Espaciodescripcionpedidofondo.LockedWidth = True
                tamaniocolumna = New Single(2) {}
                tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.33)
                tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.34)
                tamaniocolumna(2) = Convert.ToSingle(Anchopagina * 0.33)
                Espaciodescripcionpedidofondo.SetWidths(tamaniocolumna)
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("PEDIDO DE FONDOS Nº", PDF_fuente_variable(impresor.tamaniofuente, True))))
                PdfPCell.BorderWidth = 0
                PdfPCell.FixedHeight = 30
                PdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT
                PdfPCell.Rowspan = 1
                Espaciodescripcionpedidofondo.AddCell(PdfPCell)
                '----------------------TABLA CENTRAL DE PEDIDO DE FONDOS CON NRO ----------------------
                Dim Nropedidofondo As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(6)
                'nro de pedido de fondo----------------------
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(PedidoFondo.N_PedidoFondo.ToString, PDF_fuente_variable(impresor.tamaniofuentetitulos, True))))
                PdfPCell.BorderWidth = 0.5
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.Colspan = 3
                PdfPCell.FixedHeight = 25
                Nropedidofondo.AddCell(PdfPCell)
                'año de pedido de fondo----------------------
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(PedidoFondo.Fecha_Pedido.Year, PDF_fuente_variable(impresor.tamaniofuentetitulos, True))))
                PdfPCell.BorderWidth = 0.5
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.Colspan = 3
                PdfPCell.FixedHeight = 25
                Nropedidofondo.AddCell(PdfPCell)
                '----------------------numero del organismo del expediente del pedido de fondo----------------------
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Organismo, PDF_fuente_variable(impresor.tamaniofuente, True))))
                PdfPCell.BorderWidth = 0.5
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.Colspan = 2
                PdfPCell.FixedHeight = 15
                Nropedidofondo.AddCell(PdfPCell)
                'numero del expediente dentro del organismo del pedido de fondos----------------------
                '   PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Expte_numero_numericupdown.Value.ToString, font10Bold)))
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("", PDF_fuente_variable(impresor.tamaniofuente, True))))
                PdfPCell.BorderWidth = 0.5
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.Colspan = 2
                PdfPCell.FixedHeight = 15
                Nropedidofondo.AddCell(PdfPCell)
                'Año del expediente de pedido de fondos.----------------------
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(PedidoFondo.Fecha_Pedido.Year.ToString, PDF_fuente_variable(impresor.tamaniofuente, True))))
                PdfPCell.BorderWidth = 0.5
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.Colspan = 2
                PdfPCell.FixedHeight = 15
                Nropedidofondo.AddCell(PdfPCell)
                tamaniocolumna = New Single(5) {}
                tamaniocolumna(0) = Convert.ToSingle((Anchopagina * 0.33 * 0.33) / 2)
                tamaniocolumna(1) = Convert.ToSingle((Anchopagina * 0.33 * 0.33) / 2)
                tamaniocolumna(2) = Convert.ToSingle((Anchopagina * 0.33 * 0.33) / 2)
                tamaniocolumna(3) = Convert.ToSingle((Anchopagina * 0.33 * 0.33) / 2)
                tamaniocolumna(4) = Convert.ToSingle((Anchopagina * 0.33 * 0.33) / 2)
                tamaniocolumna(5) = Convert.ToSingle((Anchopagina * 0.33 * 0.33) / 2)
                Nropedidofondo.SetWidths(tamaniocolumna)
                '----------------------AGREGA LA TABLA DE DATOS DEL PEDIDO DE FONDOS----------------------
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(Nropedidofondo)
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.Rowspan = 2
                Espaciodescripcionpedidofondo.AddCell(PdfPCell)
                'AGREGA LA FECHA DEL PEDIDO DE FONDOS
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("FECHA:" & Convert.ToDateTime(PedidoFondo.Fecha_Pedido).ToString("dd/MM/yyyy"), PDF_fuente_variable(impresor.tamaniofuente, True))))
                PdfPCell.BorderWidth = 0
                PdfPCell.Rowspan = 2
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE
                Espaciodescripcionpedidofondo.AddCell(PdfPCell)
                'AGREGA LA fRASE EXPEDIENTE Nro
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Expediente Nº", PDF_fuente_variable(impresor.tamaniofuente, True))))
                PdfPCell.BorderWidth = 0
                PdfPCell.FixedHeight = 15
                PdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT
                PdfPCell.Rowspan = 1
                Espaciodescripcionpedidofondo.AddCell(PdfPCell)
                '----------------------AGREGA DATOS FORMALES PEDIDO DE FONDO-----------------------------
                'Frase_total.Clear()
                PARRAFOCOMPLETO.Clear()
                PARRAFOCOMPLETO.Add(Espaciodescripcionpedidofondo)
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0.5)))
                Tabla_total.AddCell(PdfpCell_espaciovacio)
                PARRAFOCOMPLETO.Clear()
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk("Sr.CONTADOR GENERAL DE LA PROVINCIA ", PDF_fuente_variable(impresor.tamaniofuente, True)))
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk("De acuerdo a la ", PDF_fuente_variable(impresor.tamaniofuente, False)))
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk("LEY DE CONTABILIDAD", PDF_fuente_variable(impresor.tamaniofuente, True)))
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk(", solicitamos las siguientes TRANSFERENCIAS de Fondos: ", PDF_fuente_variable(impresor.tamaniofuente, False)))
                'tabla: pedido de fondos con total (5 columnas, con una ultima que tiene un column span de 4 sin borde y el total con borde
                'Evaluar el caso del tipo de pedido de fondo para realizar la confección
                'Select Case Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("parcial").Value = 1
                '    Case True
                'para lograr la adaptación completa debo disminuir el margen necesario
                Dim anchoutil As Single = Anchopagina - Doc.LeftMargin
                tamaniocolumna = New Single(7) {}
                tamaniocolumna(0) = Convert.ToSingle(anchoutil * 0.03) 'Nº
                tamaniocolumna(1) = Convert.ToSingle(anchoutil * 0.05) 'Rubro
                tamaniocolumna(2) = Convert.ToSingle(anchoutil * 0.07) 'Proveedor
                tamaniocolumna(3) = Convert.ToSingle(anchoutil * 0.15) ' EXPEDIENTE
                tamaniocolumna(4) = Convert.ToSingle(anchoutil * 0.1) ' CUIT
                tamaniocolumna(5) = Convert.ToSingle(anchoutil * 0.3) 'Concepto
                tamaniocolumna(6) = Convert.ToSingle(anchoutil * 0.12) 'orden
                tamaniocolumna(7) = Convert.ToSingle(anchoutil * 0.15) 'IMPORTE
                '---------------------------------------------TABLA CON TODOS LOS DATOS-----------------------------------------------------------------------------------------------
                Dim tablapedidodefondos As iTextSharp.text.pdf.PdfPTable
                Select Case PedidoFondo.Datospedidofondos_datatable.Rows.Count
                    Case Is > 12
                        tablapedidodefondos = PDFDatatable(PedidoFondo.Datospedidofondos_datatable, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#c5c7c0")), 6, True)
                    Case Is > 7
                        tablapedidodefondos = PDFDatatable(PedidoFondo.Datospedidofondos_datatable, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#c5c7c0")), 7, True)
                    Case Else
                        tablapedidodefondos = PDFDatatable(PedidoFondo.Datospedidofondos_datatable, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#c5c7c0")), 8, True)
                End Select
                '---------------------------------------------TABLA CON TODOS LOS DATOS-----------------------------------------------------------------------------------------------
                'agrega la celda de Valor total a la tabla
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("TOTAL", PDF_fuente_variable(impresor.tamaniofuente, True))))
                PdfPCell.BorderWidth = 0
                PdfPCell.FixedHeight = 18
                PdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT
                PdfPCell.Colspan = tamaniocolumna.Count - 1
                'agrega la celda total
                tablapedidodefondos.AddCell(PdfPCell)
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(FormatCurrency(PedidoFondo.Monto_pedidofondo, 2,, TriState.True, TriState.True), PDF_fuente_variable(impresor.tamaniofuente, True)))
                PdfPCell.BorderWidth = 0.5
                PdfPCell.FixedHeight = 18
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.Colspan = 1
                'Agrega la celda con el total sumado
                tablapedidodefondos.AddCell(PdfPCell)
                'Agrega tabla de pedido de fondos
                PARRAFOCOMPLETO.Add(tablapedidodefondos)
                'Tabla: Caracter de la cuenta
                'Tabla+--------------------------------------------------------------------------------------------------------------------------------------------
                Dim Deudaconoajuste_fechavencimiento As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(3)
                tamaniocolumna = New Single(2) {}
                tamaniocolumna(0) = Convert.ToSingle((Anchopagina * 0.2))
                tamaniocolumna(1) = Convert.ToSingle((Anchopagina * 0.2))
                tamaniocolumna(2) = Convert.ToSingle((Anchopagina * 0.6))
                Deudaconoajuste_fechavencimiento.SetWidths(tamaniocolumna)
                Deudaconoajuste_fechavencimiento.TotalWidth = Anchopagina - Doc.LeftMargin
                Deudaconoajuste_fechavencimiento.LockedWidth = True
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Fecha de Vencimiento  ", PDF_fuente_variable(impresor.tamaniofuente - 3, False))))
                PdfPCell.BorderWidth = 0
                PdfPCell.FixedHeight = 15
                PdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT
                PdfPCell.Colspan = 1
                'agrega la celda total
                Deudaconoajuste_fechavencimiento.AddCell(PdfPCell)
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("__/__/____", PDF_fuente_variable(impresor.tamaniofuente, True))))
                PdfPCell.BorderWidth = 0.25
                PdfPCell.FixedHeight = 15
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.Colspan = 1
                'agrega la celda total
                Deudaconoajuste_fechavencimiento.AddCell(PdfPCell)
                PDF_fuente_variable(impresor.tamaniofuente, True)
                'Anteriormente Deuda con ajuste, pero debido aque no existen actualmente ajustes por inflación  se Vacia
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(impresor.tamaniofuente - 3, True))))
                PdfPCell.BorderWidth = 0
                PdfPCell.FixedHeight = 15
                PdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT
                PdfPCell.Colspan = 1
                'agrega la celda total
                Deudaconoajuste_fechavencimiento.AddCell(PdfPCell)
                PARRAFOCOMPLETO.Add(Deudaconoajuste_fechavencimiento)
                'PARRAFOCOMPLETO.Add(New iTextSharp.text.Phrase(" " & vbNewLine, font07Normal))
                'Tabla+--------------------------------------------------------CUENTA BANCARIA N°------------------------------------------------------------------------------------
                Dim CuentaBancariatabla_wrap As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(2)
                CuentaBancariatabla_wrap.TotalWidth = Anchopagina - Doc.LeftMargin
                Dim tamaniocolumna_CuentaBancariatabla_wrap As Single() = New Single(1) {}
                tamaniocolumna_CuentaBancariatabla_wrap(0) = Convert.ToSingle((Anchopagina * 0.3))
                tamaniocolumna_CuentaBancariatabla_wrap(1) = Convert.ToSingle((Anchopagina * 0.7))
                CuentaBancariatabla_wrap.SetWidths(tamaniocolumna_CuentaBancariatabla_wrap)
                CuentaBancariatabla_wrap.LockedWidth = True
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("A DEPOSITAR EN LA CUENTA N°", PDF_fuente_variable(impresor.tamaniofuente, True))))
                PdfPCell.BorderWidth = 0
                PdfPCell.FixedHeight = 15
                PdfPCell.Colspan = 1
                'agrega la celda total
                CuentaBancariatabla_wrap.AddCell(PdfPCell)
                Dim CuentaBancariatabla As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(PedidoFondo.Cuenta_PedidoFondo.ToString.Length)
                tamaniocolumna = New Single(PedidoFondo.Cuenta_PedidoFondo.ToString.Length - 1) {}
                For X = 0 To PedidoFondo.Cuenta_PedidoFondo.ToString.Length - 1
                    tamaniocolumna(X) = Convert.ToSingle((Anchopagina * 0.7) / (PedidoFondo.Cuenta_PedidoFondo.Length - 1))
                Next
                CuentaBancariatabla.SetWidths(tamaniocolumna)
                For x = 0 To PedidoFondo.Cuenta_PedidoFondo.ToString.Length - 1
                    'CuentaBancariatabla.AddCell((New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("CUENTA_PEDIDOFONDO").Value.ToString.Chars(x), font12Bold))))
                    CuentaBancariatabla.AddCell(Phrasepdf(PedidoFondo.Cuenta_PedidoFondo.ToString.Chars(x), 10, True, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE))
                Next
                CuentaBancariatabla.SetWidths(tamaniocolumna)
                With CuentaBancariatabla
                    .HorizontalAlignment = 1
                End With
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(CuentaBancariatabla)
                PdfPCell.BorderWidth = 0.5
                PdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT
                CuentaBancariatabla_wrap.AddCell(PdfPCell)
                PARRAFOCOMPLETO.Add(CuentaBancariatabla_wrap)
                'agrega el caracter de la cuenta al parrafo
                'estructura de Caracter
                Caracterdecuenta1.Columns.Add("CARACTER")
                Caracterdecuenta1.Columns.Add("NUMERO")
                Caracterdecuenta1.Columns.Add("CUENTA")
                Caracterdecuenta1.Columns.Add("CUENTA_DETALLE")
                Caracterdecuenta1.Rows.Add()
                Caracterdecuenta1.Rows(0).Item("CARACTER") = "CÁRACTER"
                Caracterdecuenta1.Rows(0).Item("NUMERO") = PedidoFondo.Caracter
                Caracterdecuenta1.Rows(0).Item("CUENTA") = "CUENTA:"
                Caracterdecuenta1.Rows(0).Item("CUENTA_DETALLE") = PedidoFondo.CuentaPedido_Descripcion
                tamaniocolumna = New Single(3) {}
                tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.1)
                tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.05)
                tamaniocolumna(2) = Convert.ToSingle(Anchopagina * 0.1)
                tamaniocolumna(3) = Convert.ToSingle(Anchopagina * 0.75)
                Dim Caracterdecuenta1pdftable As iTextSharp.text.pdf.PdfPTable = PDFDatatable(Caracterdecuenta1, tamaniocolumna, 2, Anchopagina - (Doc.LeftMargin + 4), False, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#c5c7c0")), 9)
                PARRAFOCOMPLETO.Add(Caracterdecuenta1pdftable)
                '                autorizadas Por el servicio administrativo
                ''agregar las tablas DE firmas al parrafo
                With PARRAFOCOMPLETO
                    .Add(PDFFIRMAS(Anchopagina - Doc.LeftMargin, "TESORERO", "DIRECTOR"))
                End With
                'agregar parrafo de datos del pedido de fondo al documento
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0.5, 1, 1, 0, 3)))
                Tabla_total.AddCell(PdfpCell_espaciovacio)
                'Parrafo de Certificación por el Delegado Fiscal
                PARRAFOCOMPLETO.Clear()
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk("CERTIFICO: ", PDF_fuente_variable(impresor.tamaniofuente, True)))
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk("Que la documentación pertinente del Pedido ha sido verificada en forma integral, no mereciendo observaciones que formular", PDF_fuente_variable(impresor.tamaniofuente, True)))
                With PARRAFOCOMPLETO
                    .Add(PDFFIRMAS(Anchopagina - Doc.LeftMargin, "", "DELEGADO FISCAL"))
                End With
                'agregar las tablas DE firmas al parrafo
                'agregar parrafo de Certificación por el Delegado Fiscal
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0.5, 1, 1, 0, 3)))
                Tabla_total.AddCell(PdfpCell_espaciovacio)
                'Parrafo correspondiente a la Tesorería General de la provincia
                PARRAFOCOMPLETO.Clear()
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk("TRANSFIERESE POR LA TESORERIA GENERAL DE LA PROVINCIA ", PDF_fuente_variable(impresor.tamaniofuente, True)))
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk(": a favor del ", PDF_fuente_variable(impresor.tamaniofuente, False)))
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk(Nombrecompletodelservicio.ToUpper, PDF_fuente_variable(impresor.tamaniofuente, True)))
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk(" con cargo de oportuna y documentada rendición de cuentas con ", PDF_fuente_variable(impresor.tamaniofuente, False)))
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk("IMPUTACIÓN ", PDF_fuente_variable(impresor.tamaniofuente, True)))
                'agrega el caracter de la cuenta al parrafo
                'estructura de Caracter
                Caracterdecuenta2.Columns.Add("CARACTER")
                Caracterdecuenta2.Columns.Add("NUMERO")
                Caracterdecuenta2.Columns.Add("CUENTA")
                Caracterdecuenta2.Columns.Add("CUENTA_DETALLE")
                Caracterdecuenta2.Rows.Add()
                Caracterdecuenta2.Rows(0).Item("CARACTER") = "CÁRACTER"
                Caracterdecuenta2.Rows(0).Item("NUMERO") = PedidoFondo.Caracter
                Caracterdecuenta2.Rows(0).Item("CUENTA") = "CUENTA:"
                Select Case PedidoFondo.Caracter
                    Case Is = "0"
                        Caracterdecuenta2.Rows(0).Item(3) = "SIN AFECTACIÓN ESPECIAL"
                    Case Else
                        Caracterdecuenta2.Rows(0).Item("CUENTA_DETALLE") = "CON AFECTACIÓN ESPECIAL -" & vbNewLine & PedidoFondo.CuentaPedido_Descripcion
                End Select
                tamaniocolumna = New Single(3) {}
                tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.1)
                tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.05)
                tamaniocolumna(2) = Convert.ToSingle(Anchopagina * 0.1)
                tamaniocolumna(3) = Convert.ToSingle(Anchopagina * 0.75)
                Dim Caracterdecuenta2pdftable As iTextSharp.text.pdf.PdfPTable = PDFDatatable(Caracterdecuenta2, tamaniocolumna, 2, Anchopagina - (Doc.LeftMargin + 4), False, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#c5c7c0")), 9)
                PARRAFOCOMPLETO.Add(Caracterdecuenta2pdftable)
                ''estructura de cuentadepresupuesto
                'Cuentadepresupuesto_datatable.Columns.Add("CONCEPTO")
                'Cuentadepresupuesto_datatable.Columns.Add("IMPORTES")
                'Cuentadepresupuesto_datatable.Rows.Add()
                'If Year_pedidofondo_numeric.Value.ToString = Clasefondo_textbox.Text Then
                '    Cuentadepresupuesto_datatable.Rows(0).Item("CONCEPTO") = "CUENTA DE PRESUPUESTO EJERCICIO AÑO " & Year_pedidofondo_numeric.Value
                'Else
                '    Cuentadepresupuesto_datatable.Rows(0).Item("CONCEPTO") = "CUENTA DE PRESUPUESTO EJERCICIO AÑO " & Year_pedidofondo_numeric.Value & vbNewLine & "RESIDUOS PASIVOS AÑO " & Clasefondo_textbox.Text
                'End If
                'Cuentadepresupuesto_datatable.Rows(0).Item("IMPORTES") = FormatCurrency(pedidofondo.Monto_pedidofondo, 2,, TriState.True, TriState.True)
                ''/estructura de cuentadepresupuesto
                'tamaniocolumna = New Single(1) {}
                'tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.7)
                'tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.3)
                'Dim Cuentadepresupuesto As iTextSharp.text.pdf.PdfPTable = PDFDatatable(Cuentadepresupuesto_datatable, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, False, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#c5c7c0")), 9)
                Dim parrafotemporal As New iTextSharp.text.Paragraph
                '---------------------------------------------------------------------
                tamaniocolumna = New Single(1) {}
                tamaniocolumna(0) = Convert.ToSingle((Anchopagina - Doc.LeftMargin) * 0.7)
                tamaniocolumna(1) = Convert.ToSingle((Anchopagina - Doc.LeftMargin) * 0.3)
                Dim Cuentadepresupuesto As iTextSharp.text.pdf.PdfPTable = New PdfPTable(tamaniocolumna.Length)
                'fix the absolute width of the table
                Cuentadepresupuesto.TotalWidth = Anchopagina - Doc.LeftMargin
                Cuentadepresupuesto.SetWidths(tamaniocolumna)
                Cuentadepresupuesto.LockedWidth = True
                'relative col widths in proportions
                ' PdfTable.SetWidths(widths)
                Cuentadepresupuesto.HorizontalAlignment = 1 ' 0 --> Left, 1 --> Center, 2 --> Right
                Cuentadepresupuesto.SpacingBefore = 2
                'Declaración de celdas.
                'Agregar los datos del DATATABLE a la tabla ITEXTSHARP_PDF
                PdfPCell = Nothing
                If PedidoFondo.Clase_fondo.ToString.Length = 4 Then
                    If PedidoFondo.YearPedidoFondo = Autorizaciones.Year Then
                        parrafotemporal.Add((New Phrase("CUENTA DE PRESUPUESTO EJERCICIO AÑO " & PedidoFondo.Clase_fondo, PDF_fuente_variable(9, False))))
                    Else
                        'parrafotemporal.Add((New Phrase("CUENTA DE PRESUPUESTO EJERCICIO AÑO " & Year_pedidofondo_numeric.Value, PDF_fuente_variable(9, False))))
                        parrafotemporal.Add((New Phrase(vbNewLine & "RESIDUOS PASIVOS AÑO " & PedidoFondo.Clase_fondo, PDF_fuente_variable(9, True))))
                    End If
                Else
                    parrafotemporal.Add((New Phrase("CUENTA DE PRESUPUESTO EJERCICIO AÑO " & PedidoFondo.Clase_fondo, PDF_fuente_variable(9, False))))
                End If
                parrafotemporal.Add((New Phrase("", PDF_fuente_variable(9, False))))
                parrafotemporal.Alignment = 1
                PdfPCell = ((Elementopdf_a_Celda_conborde(parrafotemporal, 0.5, 1, 1, 1, 3)))
                PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE
                Cuentadepresupuesto.AddCell(PdfPCell)
                parrafotemporal.Clear()
                '
                PdfPCell = Nothing
                parrafotemporal.Add((New Phrase(FormatCurrency(PedidoFondo.Monto_pedidofondo, 2,, TriState.True, TriState.True), PDF_fuente_variable(9, False))))
                parrafotemporal.Add((New Phrase("", PDF_fuente_variable(9, False))))
                parrafotemporal.Alignment = 1
                PdfPCell = ((Elementopdf_a_Celda_conborde(parrafotemporal, 0.5, 1, 1, Element.ALIGN_RIGHT, 3, 5)))
                PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE
                Cuentadepresupuesto.AddCell(PdfPCell)
                '----------------------------------------------------------------------
                parrafotemporal.Clear()
                '
                PdfPCell = Nothing
                'agrega la celda de Valor total a la tabla
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("TOTAL", PDF_fuente_variable(impresor.tamaniofuente, True))))
                PdfPCell.BorderWidth = 0
                PdfPCell.FixedHeight = 18
                PdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT
                PdfPCell.Colspan = 1
                'agrega la celda total
                Cuentadepresupuesto.AddCell(PdfPCell)
                'PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(FormatCurrency(pedidofondo.Monto_pedidofondo, 2,, TriState.True, TriState.True), font10Bold))
                'PdfPCell.BorderWidth = 0.5
                'PdfPCell.FixedHeight = 18
                'PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                'PdfPCell.Colspan = 1
                'Agrega la celda con el total sumado
                'Cuentadepresupuesto.AddCell(PdfPCell)
                Cuentadepresupuesto.AddCell(Phrasepdf(FormatCurrency(PedidoFondo.Monto_pedidofondo, 2,, TriState.True, TriState.True), 10, True, 0.5, 2, 1, Element.ALIGN_CENTER, 4, Element.ALIGN_MIDDLE))
                With PARRAFOCOMPLETO
                    .Add(Cuentadepresupuesto)
                End With
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk("SON PESOS: " & Inicio.Num2Text(Math.Truncate(Convert.ToDecimal(PedidoFondo.Monto_pedidofondo))) & " CON " &
            ((Convert.ToDecimal(PedidoFondo.Monto_pedidofondo) - Math.Truncate(Convert.ToDecimal(PedidoFondo.Monto_pedidofondo))) * 100).ToString("00") & "/100.-", PDF_fuente_variable(impresor.tamaniofuente, True)))
                'Firmas autorizadas Por cONTADURIA
                With PARRAFOCOMPLETO
                    .Add(PDFFIRMAS(Anchopagina - Doc.LeftMargin, "Responsable Transf. Fondos", "CONTADOR GENERAL"))
                End With
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0.5, 1, 1, 0, 2)))
                Tabla_total.AddCell(PdfpCell_espaciovacio)
                PARRAFOCOMPLETO.Clear()
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk("TRANSFERIDO POR LA TESORERÍA GENERAL", PDF_fuente_variable(impresor.tamaniofuente, True)))
                '------------------------------------------------------------------------------------
                'estructura de Tesorería General de la provincia
                PdfPCell = Nothing
                Transferidoportesoreríageneral_datatable.Columns.Add("FECHA")
                Transferidoportesoreríageneral_datatable.Columns.Add("CUENTA Nº")
                Transferidoportesoreríageneral_datatable.Columns.Add("CHEQUE Nº")
                Transferidoportesoreríageneral_datatable.Columns.Add("IMPORTE")
                Dim Transferidoportesoreríageneral As iTextSharp.text.pdf.PdfPTable = New PdfPTable(4)
                Transferidoportesoreríageneral.TotalWidth = Anchopagina - (Doc.LeftMargin + 6)
                Transferidoportesoreríageneral.LockedWidth = True
                tamaniocolumna = New Single(3) {}
                tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.1)
                tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.4)
                tamaniocolumna(2) = Convert.ToSingle(Anchopagina * 0.4)
                tamaniocolumna(3) = Convert.ToSingle(Anchopagina * 0.1)
                Transferidoportesoreríageneral.SetWidths(tamaniocolumna)
                '----------------------------------------------ENCABEZADO DE TABLA DE TRANSFERENCIA TESORERIA GENERAL-----------------
                For X = 0 To Transferidoportesoreríageneral_datatable.Columns.Count - 1
                    'Asignación de valores a cada celda como frases.
                    PdfPCell = New PdfPCell(New Phrase(New Chunk(Transferidoportesoreríageneral_datatable.Columns(X).Caption, PDF_fuente_variable(impresor.tamaniofuente, True))))
                    'Alignment of phrase in the pdfcell
                    PdfPCell.HorizontalAlignment = 1
                    PdfPCell.BackgroundColor = New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#c5c7c0"))
                    'Add pdfcell in pdftable
                    Transferidoportesoreríageneral.AddCell(PdfPCell)
                Next
                Transferidoportesoreríageneral.HeaderRows = 1
                PdfPCell = New PdfPCell(New Phrase(New Chunk(" ", PDF_fuente_variable(impresor.tamaniofuente - 3, False))))
                PdfPCell.FixedHeight = 12
                For x = 0 To 23
                    Transferidoportesoreríageneral.AddCell(PdfPCell)
                Next
                With PARRAFOCOMPLETO
                    .Add(Transferidoportesoreríageneral)
                    .Alignment = Element.ALIGN_CENTER
                End With
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0.5)))
                '/estructura de Tesorería General de la provincia
                'Agregar Tabla al final de la generación del documento
                Doc.Add(Tabla_total)
                Dim textoQR As String = Autorizaciones.Nombrecompletodelservicio.ToUpper & vbNewLine & "Pedido de Fondos Nº" & PedidoFondo.N_PedidoFondo & "/" & PedidoFondo.YearPedidoFondo & vbNewLine & " por:" & PedidoFondo.Monto_pedidofondo
                For x = 0 To PedidoFondo.Datospedidofondos_datatable.Rows.Count - 1
                    textoQR = textoQR & vbNewLine & PedidoFondo.Datospedidofondos_datatable.Rows(x).Item("expediente_N").ToString & " / " &
                        PedidoFondo.Datospedidofondos_datatable.Rows(x).Item("CUIT").ToString & " / " & FormatCurrency(Convert.ToDecimal(PedidoFondo.Datospedidofondos_datatable.Rows(x).Item("Monto").ToString), 2,, TriState.True, TriState.True)
                Next
                ''Agregar imagen QR
                'Dim TablaQR As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(3) With {
                '    .TotalWidth = Convert.ToSingle(Doc.PageSize.Width) - 70,
                '    .SpacingBefore = 15.0F}
                'Dim tamaniocolumnaqr As Single() = New Single(2) {}
                'tamaniocolumnaqr(0) = Convert.ToSingle(Doc.PageSize.Width * 0.4)
                'tamaniocolumnaqr(1) = Convert.ToSingle(Doc.PageSize.Width * 0.4)
                'tamaniocolumnaqr(2) = Convert.ToSingle(Doc.PageSize.Width * 0.2)
                ''Primer celda
                'PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("", titleFont)))
                'PdfPCell.BorderWidth = 0
                'PdfPCell.HorizontalAlignment = iTextSharp.text.pdf.PdfPCell.ALIGN_CENTER
                'PdfPCell.FixedHeight = 70.0F
                'TablaQR.AddCell(PdfPCell)
                ''Segunda Celda centro imagen
                'manejadorimagen = iTextSharp.text.Image.GetInstance(GenerateQR(My.Resources.LOGO_Contaduria.Width, My.Resources.LOGO_Contaduria.Height, textoQR, My.Resources.LOGO_Contaduria), System.Drawing.Imaging.ImageFormat.Png)
                ''asignar la imagen QR a la celda
                'manejadorimagen.ScaleToFit(My.Resources.LOGO_Contaduria.Height * 0.15, My.Resources.LOGO_Contaduria.Height * 0.15)
                'PdfPCell = New PdfPCell(manejadorimagen, True)
                'PdfPCell.BorderWidth = 0
                'PdfPCell.HorizontalAlignment = iTextSharp.text.pdf.PdfPCell.ALIGN_RIGHT
                'PdfPCell.FixedHeight = 70.0F
                'TablaQR.AddCell(PdfPCell)
                ''Tercer Celda
                'PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("", titleFont)))
                'PdfPCell.BorderWidth = 0
                'PdfPCell.HorizontalAlignment = iTextSharp.text.pdf.PdfPCell.ALIGN_CENTER
                'PdfPCell.FixedHeight = 70.0F
                'TablaQR.AddCell(PdfPCell)
                ''---------------------------------AGREGAR CODIGO QR-----------------------------------------
                ''agrega un espacio entre el código QR y la ultima tabla
                '' Doc.Add(PdfpCell_espaciovacio)
                ''agrega la tabla QR
                ''    Doc.Add(TablaQR)
                ''/---------------------------------AGREGAR CODIGO QR-----------------------------------------
                '  Doc.Add(imagenpdf)
                ''//Close our document
                PARRAFOCOMPLETO.Clear()
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk(Inicio.GenerateHash(textoQR), PDF_fuente_variable(impresor.tamaniofuente - 3, False)))
                Doc.Add(PARRAFOCOMPLETO)
                Dim COLUMNA2 As New ColumnText(wri.DirectContent)
                'the Phrase
                'the lower left x corner (left)
                'the lower left y corner (bottom)
                'the upper right x corner (right)
                'the upper right y corner (top)
                'line height(leading)
                'alignment.
                Dim font14Bolds As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14.0F, iTextSharp.text.Font.BOLD, BaseColor.GRAY)
                COLUMNA2.SetSimpleColumn(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("SICyF", font14Bolds)),
                                            Doc.Left, Doc.Bottom,
                                          Doc.Right, 0,
                                            15, Element.ALIGN_RIGHT)
                COLUMNA2.Go()
                Doc.Close()
            End Using
            Select Case MsgBox("Abrir el archivo generado?", MsgBoxStyle.YesNoCancel, " ")
                Case MsgBoxResult.Yes
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(Controlguardado.FileName) With {
                                             .UseShellExecute = True
    })
            End Select
        End If
    End Sub

    'Private Function cuadro_PAGO(ByVal ordenpagos As Ordendepago, ByVal DOC As Document, ByVal TAMANIODEFUENTE As Single) As PdfPTable
    'End Function
    Private Function cuadro_TRANSFERENCIA(ByVal ordenpagos As Ordendepago, ByVal DOC As Document, ByVal TAMANIODEFUENTE As Single) As PdfPTable
        Dim CANTIDADCOLUMNAS As Integer = 3
        Dim textoprimercuadro As iTextSharp.text.pdf.PdfPTable
        Dim NOMBRECOLUMNAS As New List(Of String)
        NOMBRECOLUMNAS.AddRange({"EFECTOR", "TOTAL"})
        ''TEMPORAL BORRAR********************************************************************************************
        'textoprimercuadro = New iTextSharp.text.pdf.PdfPTable(1)
        'textoprimercuadro.TotalWidth = DOC.PageSize.Width - DOC.LeftMargin
        'textoprimercuadro.LockedWidth = True
        'tamaniocolumna = New Single(0) {}
        'tamaniocolumna(0) = Convert.ToSingle(textoprimercuadro.TotalWidth)
        'textoprimercuadro.SetWidths(tamaniocolumna)
        'textoprimercuadro.AddCell(Phrasepdf(ordenpagos.ordenpago_Detalle, TAMANIODEFUENTE + 1, False, 0, textoprimercuadro.NumberOfColumns, 2, Element.ALIGN_JUSTIFIED, 2,, 50,, 1.5))
        If ordenpagos.SINACTAS.Count > 0 Then
            textoprimercuadro = New iTextSharp.text.pdf.PdfPTable(CANTIDADCOLUMNAS)
            textoprimercuadro.TotalWidth = DOC.PageSize.Width - (DOC.LeftMargin + 5)
            textoprimercuadro.LockedWidth = True
            Dim tamaniocolumnasrestantes As Single = 0
            tamaniocolumna = New Single(CANTIDADCOLUMNAS - 1) {}
            For X = 1 To CANTIDADCOLUMNAS - 1
                tamaniocolumna(X) = Convert.ToSingle(textoprimercuadro.TotalWidth * (1 / (CANTIDADCOLUMNAS + 2)))
                tamaniocolumnasrestantes += tamaniocolumna(X)
            Next
            tamaniocolumna(0) = Convert.ToSingle(textoprimercuadro.TotalWidth - tamaniocolumnasrestantes)
            textoprimercuadro.SetWidths(tamaniocolumna)
            textoprimercuadro.AddCell(Phrasepdf(ordenpagos.ordenpago_Detalle, TAMANIODEFUENTE, False, 0, CANTIDADCOLUMNAS, 1, Element.ALIGN_JUSTIFIED, 3,, 50))
            'AGREGA LOS ENCABEZADOS DE COLUMNA
            'For Z = 0 To NOMBRECOLUMNAS.Count - 1
            'textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(
            'NOMBRECOLUMNAS(Z), PDF_fuente_variable(TAMANIODEFUENTE - 1, True))), 0.5, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Municipios", PDF_fuente_variable(TAMANIODEFUENTE - 1, True))), 0.5, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Importe", PDF_fuente_variable(TAMANIODEFUENTE - 1, True))), 0.5, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(TAMANIODEFUENTE - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
            'Next
            Dim SUMATORIA As Decimal = 0
            For ROWSS = 0 To ordenpagos.SINACTAS_DATATABLE.Rows.Count - 1
                For NOMBRE = 0 To NOMBRECOLUMNAS.Count - 1
                    Select Case ordenpagos.SINACTAS_DATATABLE.Rows(ROWSS).Item(NOMBRECOLUMNAS(NOMBRE)).GetType.ToString.ToUpper
                        Case Is = "SYSTEM.STRING"
                            Select Case ordenpagos.SINACTAS_DATATABLE.Columns.Item(NOMBRECOLUMNAS(NOMBRE)).ColumnName.ToUpper
                                Case Is = "PERIODO"
                                    textoprimercuadro.AddCell(Phrasepdf(ordenpagos.SINACTAS_DATATABLE.Rows(ROWSS).Item(NOMBRECOLUMNAS(NOMBRE)), TAMANIODEFUENTE - 2, False, 0.5, 1, 1, Element.ALIGN_CENTER, 0))
                                Case Else
                                    textoprimercuadro.AddCell(Phrasepdf(ordenpagos.SINACTAS_DATATABLE.Rows(ROWSS).Item(NOMBRECOLUMNAS(NOMBRE)), TAMANIODEFUENTE, False, 0.5, 1, 1, Element.ALIGN_CENTER, 0))
                            End Select
                        Case Is = "SYSTEM.DECIMAL"
                            textoprimercuadro.AddCell(Phrasepdf(CType(ordenpagos.SINACTAS_DATATABLE.Rows(ROWSS).Item(NOMBRECOLUMNAS(NOMBRE)), Decimal).ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), TAMANIODEFUENTE, False, 0.5, 1, 1, Element.ALIGN_RIGHT, 2))
                        Case Is = "SYSTEM.INT64"
                            textoprimercuadro.AddCell(Phrasepdf(CType(ordenpagos.SINACTAS_DATATABLE.Rows(ROWSS).Item(NOMBRECOLUMNAS(NOMBRE)), Long).ToString("N0", Globalization.CultureInfo.GetCultureInfo("es-AR")), TAMANIODEFUENTE, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2))
                        Case Else
                            textoprimercuadro.AddCell(Phrasepdf(ordenpagos.SINACTAS_DATATABLE.Rows(ROWSS).Item(NOMBRECOLUMNAS(NOMBRE)), TAMANIODEFUENTE, False, 0.5, 1, 1, Element.ALIGN_CENTER, 0))
                    End Select
                Next
                textoprimercuadro.AddCell(Phrasepdf(" ", TAMANIODEFUENTE + 2, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
                SUMATORIA += ordenpagos.SINACTAS_DATATABLE.Rows(ROWSS).Item("TOTAL")
            Next
            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(
                                                                                                         "TOTAL ", PDF_fuente_variable(TAMANIODEFUENTE + 1, True))), 0.5, NOMBRECOLUMNAS.Count - 1, 1, iTextSharp.text.Element.ALIGN_RIGHT, 0)))
            textoprimercuadro.AddCell(Phrasepdf(CType(SUMATORIA, Decimal).ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), TAMANIODEFUENTE + 1, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2))
        Else
            textoprimercuadro = New iTextSharp.text.pdf.PdfPTable(1)
        End If
        Return textoprimercuadro
    End Function

    Private Function cuadro_RENDICION(ByVal ordenpagos As Ordendepago, ByVal DOC As Document, ByVal TAMANIODEFUENTE As Single) As PdfPTable
        Dim CANTIDADCOLUMNAS As Integer = 2
        Dim textoprimercuadro As iTextSharp.text.pdf.PdfPTable
        Dim NOMBRECOLUMNAS As List(Of String) = ordenpagos.SINACTAS_NOMBRESCOLUMNAS
        'TEMPORAL BORRAR********************************************************************************************
        textoprimercuadro = New iTextSharp.text.pdf.PdfPTable(1)
        textoprimercuadro.TotalWidth = DOC.PageSize.Width - DOC.LeftMargin
        textoprimercuadro.LockedWidth = True
        tamaniocolumna = New Single(0) {}
        tamaniocolumna(0) = Convert.ToSingle(textoprimercuadro.TotalWidth)
        textoprimercuadro.SetWidths(tamaniocolumna)
        textoprimercuadro.AddCell(Phrasepdf(ordenpagos.ordenpago_Detalle, TAMANIODEFUENTE + 1, False, 0, textoprimercuadro.NumberOfColumns, 2, Element.ALIGN_JUSTIFIED, 2,, 50,, 1.5))
        'TEMPORAL BORRAR********************************************************************************************
        If ordenpagos.SINACTAS.Count > 0 Then
            textoprimercuadro = New iTextSharp.text.pdf.PdfPTable(CANTIDADCOLUMNAS)
            textoprimercuadro.TotalWidth = DOC.PageSize.Width - DOC.LeftMargin
            textoprimercuadro.LockedWidth = True
            tamaniocolumna = New Single(CANTIDADCOLUMNAS - 1) {}
            For X = 0 To CANTIDADCOLUMNAS - 1
                tamaniocolumna(X) = Convert.ToSingle(textoprimercuadro.TotalWidth * (1 / CANTIDADCOLUMNAS))
            Next
            textoprimercuadro.SetWidths(tamaniocolumna)
            textoprimercuadro.AddCell(Phrasepdf(ordenpagos.ordenpago_Detalle, TAMANIODEFUENTE, False, 0, CANTIDADCOLUMNAS, 1, Element.ALIGN_JUSTIFIED, 3))
            'AGREGA LOS ENCABEZADOS DE COLUMNA
            If Not ordenpagos.Ordenpago_tipo = "TRANSFERENCIA" Then
                textoprimercuadro.AddCell(Phrasepdf("RECURSOS", TAMANIODEFUENTE, True, 0, 1, 1, Element.ALIGN_RIGHT, 5,,,,, True))
                textoprimercuadro.AddCell(Phrasepdf("GASTOS", TAMANIODEFUENTE, True, 0, 1, 1, Element.ALIGN_LEFT, 5,,,,, True))
                textoprimercuadro.HeaderRows = 1
                For ROWSS = 0 To ordenpagos.SINACTAS_DATATABLE.Rows.Count - 1
                    textoprimercuadro.AddCell(Phrasepdf(CType(ordenpagos.SINACTAS_DATATABLE.Rows(ROWSS).Item("RECURSOS"), Decimal).ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_RIGHT, 5))
                    If Not ordenpagos.SINACTAS_DATATABLE.Rows(ROWSS).Item("GASTOS") = 0 Then
                        textoprimercuadro.AddCell(Phrasepdf(CType(ordenpagos.SINACTAS_DATATABLE.Rows(ROWSS).Item("GASTOS"), Decimal).ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_LEFT, 5))
                    Else
                        textoprimercuadro.AddCell(Phrasepdf("SIN MOVIMIENTOS", TAMANIODEFUENTE, False, 0, 2, 1, Element.ALIGN_LEFT, 5))
                    End If
                Next
                textoprimercuadro.AddCell(Phrasepdf("CORRESPONDE AL MES DE:" & ordenpagos.SINACTAS_DATATABLE.Rows(0).Item("PERIODO"), TAMANIODEFUENTE + 1, True, 0, 4, 1, Element.ALIGN_LEFT, 0))
                Select Case ordenpagos.Ordenpago_tipo
                    Case Is = "ARANCELAMIENTO"
                        '  textoprimercuadro.AddCell(Phrasepdf(ordenpagos.ordenpago_Detalle, TAMANIODEFUENTE, False, 0, CANTIDADCOLUMNAS, 1, Element.ALIGN_JUSTIFIED, 3))
                        textoprimercuadro.AddCell(Phrasepdf(ordenpagos.ordenpago_Detalle2, TAMANIODEFUENTE, True, 0, 4, 1, Element.ALIGN_LEFT, 0))
                    Case Else
                End Select
            End If
        Else
            Select Case ordenpagos.Ordenpago_tipo
                Case Is = "ARANCELAMIENTO"
                    textoprimercuadro.AddCell(Phrasepdf(vbNewLine, TAMANIODEFUENTE, False, 0, CANTIDADCOLUMNAS, 1, Element.ALIGN_JUSTIFIED, 3))
                    textoprimercuadro.AddCell(Phrasepdf(ordenpagos.ordenpago_Detalle2, TAMANIODEFUENTE, True, 0, 4, 1, Element.ALIGN_LEFT, 0))
                Case Else
                    textoprimercuadro = New iTextSharp.text.pdf.PdfPTable(1)
            End Select
        End If
        Return textoprimercuadro
    End Function

    'Private Function cuadro_pagoMultiplesefectores(ByVal ordenpagos As Ordendepago, ByVal DOC As Document, ByVal TAMANIODEFUENTE As Single) As PdfPTable
    '    Dim TIENE_EFECTOR As Boolean = False
    '    Dim TIENE_PERIODO As Boolean = False
    '    Dim TIENE_DETALLE As Boolean = False
    '    Dim TIENE_ANTICIPO As Boolean = False
    '    Dim CANTIDADCOLUMNAS As Integer = ordenpagos.SINACTAS_CANTIDADCOLUMNAS
    '    Dim textoprimercuadro As iTextSharp.text.pdf.PdfPTable
    '    Dim NOMBRECOLUMNAS As List(Of String) = ordenpagos.SINACTAS_NOMBRESCOLUMNAS
    '    Dim SUBTOTAL As Decimal = 0
    '    If ordenpagos.SINACTAS.Count > 0 Then
    '        For Each ACTA In ordenpagos.ACTAS
    '            If ACTA.ACTARECEPCION_ANTICIPO > 0 Then
    '                TIENE_ANTICIPO = True
    '            End If
    '            If ACTA.ACTARECEPCION_DETALLE.Length > 0 Then
    '                TIENE_DETALLE = True
    '            End If
    '            If ACTA.ACTARECEPCION_EFECTOR.Length > 0 Then
    '                TIENE_EFECTOR = True
    '            End If
    '            If ACTA.ACTARECEPCION_PERIODO.Length > 0 Then
    '                TIENE_PERIODO = True
    '            End If
    '            SUBTOTAL += ACTA.ACTARECEPCION_MONTO + ACTA.ACTARECEPCION_MULTA_MONTO
    '        Next
    '        If TIENE_ANTICIPO Then
    '            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("O. PROV.", PDF_fuente_variable(TAMANIODEFUENTE - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
    '            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("ACTA RECEPCION Nº", PDF_fuente_variable(TAMANIODEFUENTE, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
    '            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("ANTICIPO", PDF_fuente_variable(TAMANIODEFUENTE, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
    '            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("IMPORTE", PDF_fuente_variable(TAMANIODEFUENTE, True))), 0, 2, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
    '            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("SALDO A PAGAR", PDF_fuente_variable(TAMANIODEFUENTE, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
    '            For Each ACTAD In ORDENDEPAGOS.ACTAS
    '                textoprimercuadro.AddCell(Phrasepdf(
    '                                                      CType(ACTAD.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(8, 5), Integer) &
    '                                                      "/" &
    '                                                      ACTAD.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(0, 4),
    '                                                      TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_CENTER, 1))
    '                textoprimercuadro.AddCell(Phrasepdf(ACTAD.ACTARECEPCION_NUMERO & "/" & ACTAD.ACTARECEPCION_YEAR, TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
    '                textoprimercuadro.AddCell(Phrasepdf(ACTAD.ACTARECEPCION_ANTICIPO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
    '                textoprimercuadro.AddCell(Phrasepdf(ACTAD.ACTARECEPCION_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), TAMANIODEFUENTE, False, 0, 2, 1, Element.ALIGN_CENTER, 2))
    '                textoprimercuadro.AddCell(Phrasepdf((ACTAD.ACTARECEPCION_MONTO - ACTAD.ACTARECEPCION_ANTICIPO).ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
    '                'Select Case ACTAD.ACTARECEPCION_MULTA_MONTO <> 0
    '                '    Case True
    '                '        textoprimercuadro.AddCell(Phrasepdf(" ", tamaniodefuente, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
    '                '        textoprimercuadro.AddCell(Phrasepdf(ACTAD.ACTARECEPCION_MULTA_RESOLUCION, tamaniodefuente, False, 0, 2, 1, Element.ALIGN_CENTER, 0))
    '                '        textoprimercuadro.AddCell(Phrasepdf(ACTAD.ACTARECEPCION_MULTA_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniodefuente, False, 0, 3, 1, Element.ALIGN_CENTER, 2))
    '                '    Case False
    '                'End Select
    '            Next
    '        Else
    '            If TIENE_DETALLE And TIENE_EFECTOR And TIENE_PERIODO Then
    '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("EFECTOR", PDF_fuente_variable(TAMANIODEFUENTE - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
    '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("PERIODO", PDF_fuente_variable(TAMANIODEFUENTE - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
    '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("O. PROV.", PDF_fuente_variable(TAMANIODEFUENTE - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
    '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("ACTA RECEPCION Nº", PDF_fuente_variable(TAMANIODEFUENTE - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
    '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("DETALLE", PDF_fuente_variable(TAMANIODEFUENTE - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
    '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("IMPORTE", PDF_fuente_variable(TAMANIODEFUENTE - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
    '                For Each ACTAS In ORDENDEPAGOS.ACTAS
    '                    textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_EFECTOR, TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
    '                    textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_PERIODO, TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
    '                    textoprimercuadro.AddCell(Phrasepdf(
    '                                                      CType(ACTAS.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(8, 5), Integer) &
    '                                                      "/" &
    '                                                      ACTAS.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(0, 4),
    '                                                      TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_CENTER, 1))
    '                    textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_NUMERO & "/" & ACTAS.ACTARECEPCION_YEAR, TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
    '                    textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_DETALLE, TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_CENTER, 1))
    '                    textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
    '                    Select Case ACTAS.ACTARECEPCION_MULTA_MONTO <> 0
    '                        Case True
    '                            textoprimercuadro.AddCell(Phrasepdf(" ", TAMANIODEFUENTE, False, 0, 4, 1, Element.ALIGN_CENTER, 0))
    '                            textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MULTA_RESOLUCION, TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
    '                            textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MULTA_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
    '                        Case False
    '                    End Select
    '                Next
    '            ElseIf TIENE_DETALLE And TIENE_EFECTOR Then
    '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("EFECTOR", PDF_fuente_variable(TAMANIODEFUENTE, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
    '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("O. PROV.", PDF_fuente_variable(TAMANIODEFUENTE, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
    '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("ACTA RECEPCION Nº", PDF_fuente_variable(TAMANIODEFUENTE, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
    '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("DETALLE", PDF_fuente_variable(TAMANIODEFUENTE, True))), 0, 2, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
    '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("IMPORTE", PDF_fuente_variable(TAMANIODEFUENTE, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
    '                For Each ACTAS In ORDENDEPAGOS.ACTAS
    '                    textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_EFECTOR, TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
    '                    textoprimercuadro.AddCell(Phrasepdf(
    '                                                      CType(ACTAS.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(8, 5), Integer) &
    '                                                      "/" &
    '                                                      ACTAS.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(0, 4),
    '                                                      TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_CENTER, 1))
    '                    textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_NUMERO & "/" & ACTAS.ACTARECEPCION_YEAR, TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
    '                    textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_DETALLE, TAMANIODEFUENTE, False, 0, 2, 1, Element.ALIGN_CENTER, 1))
    '                    textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
    '                    Select Case ACTAS.ACTARECEPCION_MULTA_MONTO <> 0
    '                        Case True
    '                            textoprimercuadro.AddCell(Phrasepdf(" ", TAMANIODEFUENTE, False, 0, 3, 1, Element.ALIGN_CENTER, 0))
    '                            textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MULTA_RESOLUCION, TAMANIODEFUENTE, False, 0, 2, 1, Element.ALIGN_CENTER, 0))
    '                            textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MULTA_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
    '                        Case False
    '                    End Select
    '                Next
    '            ElseIf TIENE_DETALLE And TIENE_PERIODO Then
    '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("O. PROV.", PDF_fuente_variable(TAMANIODEFUENTE - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
    '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("PERIODO", PDF_fuente_variable(TAMANIODEFUENTE, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
    '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("ACTA RECEPCION Nº", PDF_fuente_variable(TAMANIODEFUENTE, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
    '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("DETALLE", PDF_fuente_variable(TAMANIODEFUENTE, True))), 0, 2, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
    '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("IMPORTE", PDF_fuente_variable(TAMANIODEFUENTE, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
    '                For Each ACTAS In ORDENDEPAGOS.ACTAS
    '                    textoprimercuadro.AddCell(Phrasepdf(
    '                                                          CType(ACTAS.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(8, 5), Integer) &
    '                                                          "/" &
    '                                                          ACTAS.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(0, 4),
    '                                                          TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_CENTER, 1))
    '                    textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_PERIODO, TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
    '                    textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_NUMERO & "/" & ACTAS.ACTARECEPCION_YEAR, TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
    '                    textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_DETALLE, TAMANIODEFUENTE, False, 0, 2, 1, Element.ALIGN_CENTER, 1))
    '                    textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
    '                    Select Case ACTAS.ACTARECEPCION_MULTA_MONTO <> 0
    '                        Case True
    '                            textoprimercuadro.AddCell(Phrasepdf(" ", TAMANIODEFUENTE, False, 0, 2, 1, Element.ALIGN_CENTER, 0))
    '                            textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MULTA_RESOLUCION, TAMANIODEFUENTE, False, 0, 3, 1, Element.ALIGN_CENTER, 0))
    '                            textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MULTA_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
    '                        Case False
    '                    End Select
    '                Next
    '            ElseIf TIENE_DETALLE Then
    '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("O. PROV.", PDF_fuente_variable(TAMANIODEFUENTE - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
    '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("ACTA RECEPCION Nº", PDF_fuente_variable(TAMANIODEFUENTE, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
    '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("DETALLE", PDF_fuente_variable(TAMANIODEFUENTE, True))), 0, 3, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
    '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("IMPORTE", PDF_fuente_variable(TAMANIODEFUENTE, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
    '                For Each ACTAS In ORDENDEPAGOS.ACTAS
    '                    textoprimercuadro.AddCell(Phrasepdf(
    '                                                      CType(ACTAS.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(8, 5), Integer) &
    '                                                      "/" &
    '                                                      ACTAS.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(0, 4),
    '                                                      TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_CENTER, 1))
    '                    textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_NUMERO & "/" & ACTAS.ACTARECEPCION_YEAR, TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
    '                    textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_DETALLE, TAMANIODEFUENTE, False, 0, 3, 1, Element.ALIGN_CENTER, 0))
    '                    textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
    '                    Select Case ACTAS.ACTARECEPCION_MULTA_MONTO <> 0
    '                        Case True
    '                            textoprimercuadro.AddCell(Phrasepdf(" ", TAMANIODEFUENTE, False, 0, 2, 1, Element.ALIGN_CENTER, 0))
    '                            textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MULTA_RESOLUCION, TAMANIODEFUENTE, False, 0, 3, 1, Element.ALIGN_CENTER, 0))
    '                            textoprimercuadro.AddCell(Phrasepdf(ACTAS.ACTARECEPCION_MULTA_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
    '                        Case False
    '                    End Select
    '                Next
    '            Else
    '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("O. PROV.", PDF_fuente_variable(TAMANIODEFUENTE - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
    '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("ACTA RECEPCION Nº", PDF_fuente_variable(TAMANIODEFUENTE, True))), 0, 2, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
    '                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("IMPORTE", PDF_fuente_variable(TAMANIODEFUENTE, True))), 0, 3, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
    '                For Each ACTAD In ORDENDEPAGOS.ACTAS
    '                    textoprimercuadro.AddCell(Phrasepdf(
    '                                                          CType(ACTAD.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(8, 5), Integer) &
    '                                                          "/" &
    '                                                          ACTAD.ACTARECEPCION_CLAVE_ORDENPROVISION.ToString.Substring(0, 4),
    '                                                          TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_CENTER, 1))
    '                    textoprimercuadro.AddCell(Phrasepdf(ACTAD.ACTARECEPCION_NUMERO & "/" & ACTAD.ACTARECEPCION_YEAR, TAMANIODEFUENTE, False, 0, 2, 1, Element.ALIGN_CENTER, 0))
    '                    textoprimercuadro.AddCell(Phrasepdf(ACTAD.ACTARECEPCION_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), TAMANIODEFUENTE, False, 0, 3, 1, Element.ALIGN_CENTER, 2))
    '                    Select Case ACTAD.ACTARECEPCION_MULTA_MONTO <> 0
    '                        Case True
    '                            textoprimercuadro.AddCell(Phrasepdf(" ", TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
    '                            textoprimercuadro.AddCell(Phrasepdf(ACTAD.ACTARECEPCION_MULTA_RESOLUCION, TAMANIODEFUENTE, False, 0, 2, 1, Element.ALIGN_CENTER, 0))
    '                            textoprimercuadro.AddCell(Phrasepdf(ACTAD.ACTARECEPCION_MULTA_MONTO.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), TAMANIODEFUENTE, False, 0, 3, 1, Element.ALIGN_CENTER, 2))
    '                        Case False
    '                    End Select
    '                Next
    '            End If
    '        End If
    '    End If
    '    Return textoprimercuadro
    'End Function
    Private Function cuadro_RECONOCIMIENTO(ByVal ordenpagos As Ordendepago, ByVal DOC As Document, ByVal TAMANIODEFUENTE As Single) As PdfPTable
        Dim CANTIDADCOLUMNAS As Integer = 6
        Dim textoprimercuadro As iTextSharp.text.pdf.PdfPTable
        Dim NOMBRECOLUMNAS As List(Of String) = ordenpagos.SINACTAS_NOMBRESCOLUMNAS
        'TEMPORAL BORRAR********************************************************************************************
        textoprimercuadro = New iTextSharp.text.pdf.PdfPTable(1)
        textoprimercuadro.TotalWidth = DOC.PageSize.Width - DOC.LeftMargin
        textoprimercuadro.LockedWidth = True
        tamaniocolumna = New Single(0) {}
        tamaniocolumna(0) = Convert.ToSingle(textoprimercuadro.TotalWidth)
        textoprimercuadro.SetWidths(tamaniocolumna)
        textoprimercuadro.AddCell(Phrasepdf(ordenpagos.ordenpago_Detalle, TAMANIODEFUENTE + 1, False, 0, textoprimercuadro.NumberOfColumns, 2, Element.ALIGN_JUSTIFIED, 2,, 50,, 1.5))
        If ordenpagos.SINACTAS.Count > 0 Then
            textoprimercuadro = New iTextSharp.text.pdf.PdfPTable(CANTIDADCOLUMNAS)
            textoprimercuadro.TotalWidth = DOC.PageSize.Width - DOC.LeftMargin
            textoprimercuadro.LockedWidth = True
            tamaniocolumna = New Single(CANTIDADCOLUMNAS - 1) {}
            For X = 0 To CANTIDADCOLUMNAS - 1
                tamaniocolumna(X) = Convert.ToSingle(textoprimercuadro.TotalWidth * (1 / CANTIDADCOLUMNAS))
            Next
            textoprimercuadro.SetWidths(tamaniocolumna)
            textoprimercuadro.AddCell(Phrasepdf(ordenpagos.ordenpago_Detalle, TAMANIODEFUENTE, False, 0, CANTIDADCOLUMNAS, 1, Element.ALIGN_JUSTIFIED, 3,, 50))
            'AGREGA LOS ENCABEZADOS DE COLUMNA
            For Z = 0 To NOMBRECOLUMNAS.Count - 1
                'If ordenpagos.SINACTAS_DATATABLE.Columns.Contains(NOMBRECOLUMNAS(Z)) Then
                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(
                                                                                                        NOMBRECOLUMNAS(Z), PDF_fuente_variable(TAMANIODEFUENTE - 1, True))), 0.4, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                'End If
            Next
            For ROWSS = 0 To ordenpagos.SINACTAS_DATATABLE.Rows.Count - 1
                For NOMBRE = 0 To NOMBRECOLUMNAS.Count - 1
                    If ordenpagos.SINACTAS_DATATABLE.Columns.Contains(NOMBRECOLUMNAS(NOMBRE)) Then
                        Select Case ordenpagos.SINACTAS_DATATABLE.Rows(ROWSS).Item(NOMBRECOLUMNAS(NOMBRE)).GetType.ToString.ToUpper
                            Case Is = "SYSTEM.STRING"
                                textoprimercuadro.AddCell(Phrasepdf(ordenpagos.SINACTAS_DATATABLE.Rows(ROWSS).Item(NOMBRECOLUMNAS(NOMBRE)), TAMANIODEFUENTE, False, 0.4, 1, 1, Element.ALIGN_CENTER, 0))
                            Case Is = "SYSTEM.DECIMAL"
                                textoprimercuadro.AddCell(Phrasepdf(CType(ordenpagos.SINACTAS_DATATABLE.Rows(ROWSS).Item(NOMBRECOLUMNAS(NOMBRE)), Decimal).ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), TAMANIODEFUENTE, False, 0.4, 1, 1, Element.ALIGN_CENTER, 2))
                        End Select
                    End If
                Next
            Next
        Else
            textoprimercuadro = New iTextSharp.text.pdf.PdfPTable(1)
        End If
        'TEMPORAL BORRAR********************************************************************************************
        'If ordenpagos.SINACTAS.Count > 0 Then
        '    textoprimercuadro = New iTextSharp.text.pdf.PdfPTable(CANTIDADCOLUMNAS)
        '    textoprimercuadro.TotalWidth = DOC.PageSize.Width - DOC.LeftMargin
        '    textoprimercuadro.LockedWidth = True
        '    tamaniocolumna = New Single(CANTIDADCOLUMNAS - 1) {}
        '    For X = 0 To CANTIDADCOLUMNAS - 1
        '        tamaniocolumna(X) = Convert.ToSingle(textoprimercuadro.TotalWidth * (1 / CANTIDADCOLUMNAS))
        '    Next
        '    textoprimercuadro.SetWidths(tamaniocolumna)
        '    textoprimercuadro.AddCell(Phrasepdf(ordenpagos.ordenpago_Detalle, TAMANIODEFUENTE, False, 0, CANTIDADCOLUMNAS, 1, Element.ALIGN_JUSTIFIED, 3,, 50))
        '    'AGREGA LOS ENCABEZADOS DE COLUMNA
        '    For Z = 0 To NOMBRECOLUMNAS.Count - 1
        '        textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(
        '                                                                                                 NOMBRECOLUMNAS(Z), PDF_fuente_variable(TAMANIODEFUENTE - 1, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
        '    Next
        '    For ROWSS = 0 To ordenpagos.SINACTAS_DATATABLE.Rows.Count - 1
        '        For NOMBRE = 0 To NOMBRECOLUMNAS.Count - 1
        '            Select Case ordenpagos.SINACTAS_DATATABLE.Rows(ROWSS).Item(NOMBRE).GetType.ToString.ToUpper
        '                Case Is = "SYSTEM.STRING"
        '                    textoprimercuadro.AddCell(Phrasepdf(ordenpagos.SINACTAS_DATATABLE.Rows(ROWSS).Item(NOMBRE), TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_CENTER, 0))
        '                Case Is = "SYSTEM.DECIMAL"
        '                    textoprimercuadro.AddCell(Phrasepdf(CType(ordenpagos.SINACTAS_DATATABLE.Rows(ROWSS).Item(NOMBRE), Decimal).ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), TAMANIODEFUENTE, False, 0, 1, 1, Element.ALIGN_CENTER, 2))
        '            End Select
        '        Next
        '    Next
        'Else
        '    textoprimercuadro = New iTextSharp.text.pdf.PdfPTable(1)
        'End If
        Return textoprimercuadro
    End Function

    Private Function cuadro_RECONOCIMIENTO_APROPIACION(ByVal ordenpagos As Ordendepago, ByVal DOC As Document, ByVal TAMANIODEFUENTE As Single) As PdfPTable
        Dim CANTIDADCOLUMNAS As Integer = 5
        Dim textoprimercuadro As iTextSharp.text.pdf.PdfPTable
        Dim NOMBRECOLUMNAS As List(Of String) = ordenpagos.SINACTAS_NOMBRESCOLUMNAS
        Select Case ordenpagos.Ordenpago_tipo
            Case Is = "PUBLICIDAD"
                CANTIDADCOLUMNAS = 4
        End Select
        'TEMPORAL BORRAR********************************************************************************************
        textoprimercuadro = New iTextSharp.text.pdf.PdfPTable(1)
        textoprimercuadro.TotalWidth = DOC.PageSize.Width - DOC.LeftMargin
        textoprimercuadro.LockedWidth = True
        tamaniocolumna = New Single(0) {}
        tamaniocolumna(0) = Convert.ToSingle(textoprimercuadro.TotalWidth)
        textoprimercuadro.SetWidths(tamaniocolumna)
        textoprimercuadro.AddCell(Phrasepdf(ordenpagos.ordenpago_Detalle, TAMANIODEFUENTE + 1, False, 0, textoprimercuadro.NumberOfColumns, 2, Element.ALIGN_JUSTIFIED, 2,, 50,, 1.5))
        'TEMPORAL BORRAR********************************************************************************************
        If ordenpagos.SINACTAS.Count > 0 Then
            textoprimercuadro = New iTextSharp.text.pdf.PdfPTable(CANTIDADCOLUMNAS)
            textoprimercuadro.TotalWidth = DOC.PageSize.Width - DOC.LeftMargin
            textoprimercuadro.LockedWidth = True
            tamaniocolumna = New Single(CANTIDADCOLUMNAS - 1) {}
            For X = 0 To CANTIDADCOLUMNAS - 1
                tamaniocolumna(X) = Convert.ToSingle(textoprimercuadro.TotalWidth * (1 / CANTIDADCOLUMNAS))
            Next
            textoprimercuadro.SetWidths(tamaniocolumna)
            textoprimercuadro.AddCell(Phrasepdf(ordenpagos.ordenpago_Detalle, TAMANIODEFUENTE, False, 0.4, CANTIDADCOLUMNAS, 1, Element.ALIGN_JUSTIFIED, 3,, 50))
            'AGREGA LOS ENCABEZADOS DE COLUMNA
            For Z = 0 To NOMBRECOLUMNAS.Count - 1
                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(
                                                                                                         NOMBRECOLUMNAS(Z), PDF_fuente_variable(TAMANIODEFUENTE - 1, True))), 0.4, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
            Next
            For ROWSS = 0 To ordenpagos.SINACTAS_DATATABLE.Rows.Count - 1
                For NOMBRE = 0 To NOMBRECOLUMNAS.Count - 1
                    Select Case ordenpagos.SINACTAS_DATATABLE.Rows(ROWSS).Item(NOMBRECOLUMNAS(NOMBRE)).GetType.ToString.ToUpper
                        Case Is = "SYSTEM.STRING"
                            textoprimercuadro.AddCell(Phrasepdf(ordenpagos.SINACTAS_DATATABLE.Rows(ROWSS).Item(NOMBRECOLUMNAS(NOMBRE)), TAMANIODEFUENTE, False, 0.4, 1, 1, Element.ALIGN_CENTER, 0))
                        Case Is = "SYSTEM.DECIMAL"
                            textoprimercuadro.AddCell(Phrasepdf(CType(ordenpagos.SINACTAS_DATATABLE.Rows(ROWSS).Item(NOMBRECOLUMNAS(NOMBRE)), Decimal).ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), TAMANIODEFUENTE, False, 0.4, 1, 1, Element.ALIGN_CENTER, 2))
                    End Select
                Next
            Next
        Else
            textoprimercuadro = New iTextSharp.text.pdf.PdfPTable(1)
        End If
        Return textoprimercuadro
    End Function

    Private Function datatabletopdfptable(ByVal tabladatos As DataTable, ByVal DOC As Document, ByVal TAMANIODEFUENTE As Single) As PdfPTable
        Dim tablapdf As PdfPTable = New iTextSharp.text.pdf.PdfPTable(tabladatos.Columns.Count)
        'tamanio de la tabla
        tablapdf.TotalWidth = Math.Truncate(DOC.PageSize.Width) - (DOC.LeftMargin + 5)
        'ancho de cada columna
        Dim widths() = New Single(tabladatos.Columns.Count - 1) {}
        For i = 0 To tabladatos.Columns.Count - 1
            widths(i) = tablapdf.TotalWidth * (1 / tabladatos.Columns.Count)
        Next
        tablapdf.SetWidths(widths)
        tablapdf.LockedWidth = True
        'carga de encabezados
        Dim indice As Integer = 0
        For Each row As DataRow In tabladatos.Rows
            If indice = 0 Then
                For Each col As DataColumn In tabladatos.Columns
                    tablapdf.AddCell(New PdfPCell(
                                 Phrasepdf_a_Celda_conborde(
                                 New iTextSharp.text.Phrase(
                                 New iTextSharp.text.Chunk(
                                 col.ColumnName, PDF_fuente_variable(TAMANIODEFUENTE - 1, True
                                 ))), 0.5, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
                Next
            End If
            indice += 1
            'carga y formato de las celdas
            For Each col As DataColumn In tabladatos.Columns
                Select Case col.DataType.FullName.ToUpper
                    Case Is = "SYSTEM.STRING"
                        tablapdf.AddCell(Phrasepdf(row.Item(col.ColumnName), TAMANIODEFUENTE, False, 0.5, 1, 1, Element.ALIGN_CENTER, 0))
                    Case Is = "SYSTEM.DECIMAL"
                        tablapdf.AddCell(Phrasepdf(CType(row.Item(col.ColumnName), Decimal).ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), TAMANIODEFUENTE, False, 0.5, 1, 1, Element.ALIGN_RIGHT, 2))
                    Case Is = "SYSTEM.INT64"
                        tablapdf.AddCell(Phrasepdf(CType(row.Item(col.ColumnName), Long).ToString("N0", Globalization.CultureInfo.GetCultureInfo("es-AR")), TAMANIODEFUENTE, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2))
                    Case Else
                        tablapdf.AddCell(Phrasepdf(row.Item(col.ColumnName), TAMANIODEFUENTE, False, 0.5, 1, 1, Element.ALIGN_CENTER, 0))
                End Select
            Next
        Next
        Return tablapdf
    End Function

    Private Function cuadro_VIATICOS(ByVal ordenpagos As Ordendepago, ByVal DOC As Document, ByVal TAMANIODEFUENTE As Single) As PdfPTable
        Dim textoprimercuadro As iTextSharp.text.pdf.PdfPTable
        Dim NOMBRECOLUMNAS As List(Of String) = ordenpagos.VIATICOS_NOMBRESCOLUMNAS
        Dim CANTIDADCOLUMNAS As Integer = ordenpagos.VIATICOS_NOMBRESCOLUMNAS.Count
        ''TEMPORAL BORRAR********************************************************************************************
        'textoprimercuadro = New iTextSharp.text.pdf.PdfPTable(1)
        'textoprimercuadro.TotalWidth = DOC.PageSize.Width - DOC.LeftMargin
        'textoprimercuadro.LockedWidth = True
        'tamaniocolumna = New Single(0) {}
        'tamaniocolumna(0) = Convert.ToSingle(textoprimercuadro.TotalWidth)
        'textoprimercuadro.SetWidths(tamaniocolumna)
        'textoprimercuadro.AddCell(Phrasepdf(ordenpagos.ordenpago_Detalle, TAMANIODEFUENTE + 1, False, 0, textoprimercuadro.NumberOfColumns, 2, Element.ALIGN_JUSTIFIED, 2,, 50,, 1.5))
        If ordenpagos.VIATICOS.Count > 0 Then
            textoprimercuadro = New iTextSharp.text.pdf.PdfPTable(CANTIDADCOLUMNAS)
            textoprimercuadro.TotalWidth = DOC.PageSize.Width - (DOC.LeftMargin + 5)
            textoprimercuadro.LockedWidth = True
            Dim tamaniocolumnasrestantes As Single = 0
            tamaniocolumna = New Single(CANTIDADCOLUMNAS - 1) {}
            For X = 1 To CANTIDADCOLUMNAS - 1
                tamaniocolumna(X) = Convert.ToSingle(textoprimercuadro.TotalWidth * (1 / (CANTIDADCOLUMNAS + 2)))
                tamaniocolumnasrestantes += tamaniocolumna(X)
            Next
            tamaniocolumna(0) = Convert.ToSingle(textoprimercuadro.TotalWidth - tamaniocolumnasrestantes)
            textoprimercuadro.SetWidths(tamaniocolumna)
            textoprimercuadro.AddCell(Phrasepdf(ordenpagos.ordenpago_Detalle, TAMANIODEFUENTE, False, 0.4, CANTIDADCOLUMNAS, 1, Element.ALIGN_JUSTIFIED, 3,, 50))
            'AGREGA LOS ENCABEZADOS DE COLUMNA
            For Z = 0 To NOMBRECOLUMNAS.Count - 1
                textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(
                                                                                                         NOMBRECOLUMNAS(Z), PDF_fuente_variable(TAMANIODEFUENTE - 1, True))), 0.5, 1, 1, iTextSharp.text.Element.ALIGN_CENTER, 0)))
            Next
            Dim SUMATORIA As Decimal = 0
            For ROWSS = 0 To ordenpagos.VIATICOS_datatable.Rows.Count - 1
                For NOMBRE = 0 To NOMBRECOLUMNAS.Count - 1
                    Select Case ordenpagos.VIATICOS_datatable.Rows(ROWSS).Item(NOMBRE).GetType.ToString.ToUpper
                        Case Is = "SYSTEM.STRING"
                            Select Case ordenpagos.VIATICOS_datatable.Columns.Item(NOMBRE).ColumnName.ToUpper
                                Case Is = "PERIODO"
                                    textoprimercuadro.AddCell(Phrasepdf(ordenpagos.VIATICOS_datatable.Rows(ROWSS).Item(NOMBRE), TAMANIODEFUENTE - 2, False, 0.5, 1, 1, Element.ALIGN_CENTER, 0))
                                Case Else
                                    textoprimercuadro.AddCell(Phrasepdf(ordenpagos.VIATICOS_datatable.Rows(ROWSS).Item(NOMBRE), TAMANIODEFUENTE, False, 0.5, 1, 1, Element.ALIGN_CENTER, 0))
                            End Select
                        Case Is = "SYSTEM.DECIMAL"
                            textoprimercuadro.AddCell(Phrasepdf(CType(ordenpagos.VIATICOS_datatable.Rows(ROWSS).Item(NOMBRE), Decimal).ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), TAMANIODEFUENTE, False, 0.5, 1, 1, Element.ALIGN_RIGHT, 2))
                        Case Is = "SYSTEM.INT64"
                            textoprimercuadro.AddCell(Phrasepdf(CType(ordenpagos.VIATICOS_datatable.Rows(ROWSS).Item(NOMBRE), Long).ToString("N0", Globalization.CultureInfo.GetCultureInfo("es-AR")), TAMANIODEFUENTE, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2))
                        Case Else
                            textoprimercuadro.AddCell(Phrasepdf(ordenpagos.VIATICOS_datatable.Rows(ROWSS).Item(NOMBRE), TAMANIODEFUENTE, False, 0.5, 1, 1, Element.ALIGN_CENTER, 0))
                    End Select
                Next
                SUMATORIA += ordenpagos.VIATICOS_datatable.Rows(ROWSS).Item("TOTAL")
            Next
            textoprimercuadro.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(
                                                                                                         "TOTAL ", PDF_fuente_variable(TAMANIODEFUENTE + 1, True))), 0.5, NOMBRECOLUMNAS.Count - 1, 1, iTextSharp.text.Element.ALIGN_RIGHT, 0)))
            textoprimercuadro.AddCell(Phrasepdf(CType(SUMATORIA, Decimal).ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), TAMANIODEFUENTE + 1, False, 0.5, 1, 1, Element.ALIGN_CENTER, 2))
        Else
            textoprimercuadro = New iTextSharp.text.pdf.PdfPTable(1)
        End If
        Return textoprimercuadro
    End Function

    Private Function cuadro_REPOSICION(ByVal ordenpagos As Ordendepago, ByVal DOC As Document, ByVal TAMANIODEFUENTE As Single) As PdfPTable
    End Function

    Private Function cuadro_CONTRATOS(ByVal ordenpagos As Ordendepago, ByVal DOC As Document, ByVal TAMANIODEFUENTE As Single) As PdfPTable
    End Function

    Public Function Guardararchivo(ByVal Directory As String, ByVal NOMBREARCHIVO As String, Optional ByVal FILTRO As String = "ARCHIVO PDF|*.pdf", Optional ByVal TITLE As String = "Guardar en archivo PDF") As String
        Dim Controlguardado As New SaveFileDialog
        With Controlguardado
            Select Case System.IO.Directory.Exists(Directory)
                Case True
                Case False
                    System.IO.Directory.CreateDirectory(Directory)
            End Select
            .Filter = "ARCHIVO PDF|*.pdf"
            .Title = "Guardar en archivo PDF"
            .FileName = NOMBREARCHIVO
            .RestoreDirectory = True
            .InitialDirectory = Directory
        End With
        Controlguardado.Filter = FILTRO
        Controlguardado.Title = TITLE
        Controlguardado.ShowDialog()
        If Controlguardado.FileName = "" Then
            MsgBox("Para poder proceder a la creación del archivo se requiere un nombre")
        Else
        End If
        Return Controlguardado.FileName
    End Function

    Public Sub PDF_ORDENPAGO_HABERES(ByVal ORDENDEPAGOS As Ordendepago, ByVal Tamaniohoja As String, Optional ByVal tamaniofuente As Single = 9)
        '    1.	Tabla total con 2 columnas
        'a.	TABLA Encabezado con 3 columnas (ancho total) (Posadas y fecha,expediente, y nº ordenpago)
        'b.	TABLA Texto:
        'i.	 Se  liquida  para Abonar  por la Tesorería de la Dirección del Servicio Adm. de Salud Pública s/planilla adjunta y  por  el  concepto  que se indica:
        'ii.	@tipo_de_situacion
        'iii.	@que_se_abona y @mes_abonado
        'iv.	 @observaciones
        'c.	Rendiciones a pagar
        'i.	5 columnas lado izquierdo sin encabezado
        '1.	RENDICIONES A PAGAR
        'a.	Inclinado 90º OCUPANDO EL TOTAL DE LA TABLA:
        '2.	GRUPOS
        'a.	Inclinado 90º por el numero total de celdas, ver posibles conflictos
        '3.	Subgrupos
        'a.	Inclinado 90º por el numero total de celdas, ver posibles conflictos
        '4.	Columna Concepto
        'a.	Normal, donde cada ítem de los subgrupos tiene su descripción
        '5.	Columna importe
        'a.	Normal, decimal, formato contable
        'd.	LIQUIDACIÓN A PAGAR 2 COLUMNAS, SIN ENCABEZADO
        'e.	TOTAL A PAGAR 2 COLUMNAS,SIN ENCABEZADO
        'f.	TABLA DE FIRMA JEFE CONTABILIDAD
        'g.	COLUMNA 2 DE LA TABLA (tratar de hacer lo más ancho posible)
        'i.	Tabla de firmas
        '1.	Delegado Fiscal, Director, con bordes
        'ii.	Tabla con 3 columnas
        '1.	Fecha
        '2.	Cheque
        '3.	importe
        'HOJA 2
        '•	2 COLUMNAS
        'o	COLUMNA 1 AFECTACION
        '	TABLA DE PARTIDA PRESUPUESTARIA
        '	Tabla con el total 2 columnas
        'o	COLUMNA 2 DESAFECTACION
        '	TABLA DESAFECTACION
        '•	PREV. DEF. OP. UNO DEBAJO DEL OTRO
        '•	IMPORTE
        'o	FIRMA DEL JEFE DE CONTABILIDAD.
        'DATOS DEL DOCUMENTO
        Dim Doc As New Document(PageSize.LEGAL, 30, 30, 20, 30)
        'Dim FileName As String = FileName
        Dim Anchopagina As Single = Doc.PageSize.Width
        'Directory
        'NOMBRE ARCHIVO
        Dim Directory As String = "C:" & "\" & "Ordenes_de_Pago" & "\" & ORDENDEPAGOS.Ordenpago_Year & "\"
        Dim archivo_nombre As String = " OP - " & ORDENDEPAGOS.ordenpago_numero & "-" & ORDENDEPAGOS.Ordenpago_Year & "_HABERES.pdf"
        archivo_nombre = Guardararchivo(Directory, archivo_nombre)
        If archivo_nombre = "" Then
            Exit Sub
        Else
            Dim FileName As String = archivo_nombre
            Using wri = PdfWriter.GetInstance(Doc, New FileStream(FileName, FileMode.Create))
                'Abrir el documento para el uso
                Doc.Open()
                'Insertar una página en blanco nueva
                Doc.NewPage()
                'ENCABEZADO
                'Crear tabla General para cargar los bordes
                Dim Tabla_total As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(1)
                Tabla_total.TotalWidth = Anchopagina - Doc.LeftMargin
                Tabla_total.LockedWidth = True
                Dim Celdapdf_local As PdfPCell = Nothing
                Dim anchoutil As Single = Anchopagina
                '    1.	Tabla total con 2 columnas
                Dim tamaniocolumna As Single() = New Single(0) {}
                tamaniocolumna(0) = Convert.ToSingle(anchoutil * 1)
                Tabla_total.SetWidths(tamaniocolumna)
                'a.	TABLA Encabezado con 3 columnas (ancho total) (Posadas y fecha,expediente, y nº ordenpago)
                Dim Tabla_Encabezado As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(3)
                tamaniocolumna = New Single(2) {}
                tamaniocolumna(0) = Convert.ToSingle(anchoutil * 0.33)
                tamaniocolumna(1) = Convert.ToSingle(anchoutil * 0.33)
                tamaniocolumna(2) = Convert.ToSingle(anchoutil * 0.34)
                Tabla_Encabezado.SetWidths(tamaniocolumna)
                Dim TEXTO As New Paragraph
                With Tabla_Encabezado.AddCell(New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Posadas " & ORDENDEPAGOS.ordenpago_fecha.ToShortDateString, PDF_fuente_variable(tamaniofuente, True)))))
                    .VerticalAlignment = (Element.ALIGN_TOP)
                    .HorizontalAlignment = Element.ALIGN_CENTER
                End With
                With Tabla_Encabezado.AddCell(New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Expediente Nº" & vbCrLf & ORDENDEPAGOS.expediente_op.Expediente_N, PDF_fuente_variable(tamaniofuente + 4, True)))))
                    .VerticalAlignment = (Element.ALIGN_TOP)
                    .HorizontalAlignment = Element.ALIGN_CENTER
                End With
                With Tabla_Encabezado.AddCell(New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("ORDEN DE PAGO Nº " & vbCrLf & ORDENDEPAGOS.ordenpago_numero & "/" & ORDENDEPAGOS.Ordenpago_Year, PDF_fuente_variable(tamaniofuente + 4, True)))))
                    .VerticalAlignment = (Element.ALIGN_TOP)
                    .HorizontalAlignment = Element.ALIGN_CENTER
                End With
                Tabla_Encabezado.WidthPercentage = 100
                'Tabla_Encabezado.LockedWidth = True
                'Tabla_Encabezado.SetWidthPercentage = 100
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(Tabla_Encabezado, 0.5, 2)))
                'b.	TABLA Texto:
                'i.	 Se  liquida  para Abonar  por la Tesorería de la Dirección del Servicio Adm. de Salud Pública s/planilla adjunta y  por  el  concepto  que se indica:
                'ii.	@tipo_de_situacion
                'iii.	@que_se_abona y @mes_abonado
                'iv.	 @observaciones
                Dim Tabla_texto As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(1)
                tamaniocolumna = New Single(0) {}
                tamaniocolumna(0) = Convert.ToSingle(anchoutil * 1)
                Tabla_texto.SetWidths(tamaniocolumna)
                Dim listadodechunks As New List(Of Chunk)
                listadodechunks.Add(New iTextSharp.text.Chunk("Se liquida  para Abonar  por la Tesorería de la Dirección del " & Autorizaciones.Nombrecompletodelservicio & " s/planilla adjunta y  por  el  concepto  que se indica:", PDF_fuente_variable(tamaniofuente, False)))
                listadodechunks.Add(New iTextSharp.text.Chunk(ORDENDEPAGOS.ordenpago_Detalle, PDF_fuente_variable(11, True)))
                listadodechunks.Add(New iTextSharp.text.Chunk(vbNewLine & ORDENDEPAGOS.ordenpago_Detalle2, PDF_fuente_variable(10, False)))
                Select Case ORDENDEPAGOS.Haberes_recuperovarios > 0
                    Case True
                        listadodechunks.Add(New iTextSharp.text.Chunk(" LA DIFERENCIA " &
                                                                      ORDENDEPAGOS.Haberes_recuperovarios.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")) & " CORRESPONDE A RECUPERO VARIOS ", PDF_fuente_variable(tamaniofuente, False)))
                    Case False
                End Select
                Tabla_texto.WidthPercentage = 100
                With Tabla_texto.AddCell(New PdfPCell(ParrafoPdF(listadodechunks)))
                    .HorizontalAlignment = Element.ALIGN_JUSTIFIED
                    .SetLeading(11, 1.2)
                    .Padding = 1.2
                End With
                Tabla_total.AddCell(New PdfPCell(Tabla_texto))
                'AGREGAR LA TABLA TOTAL y posteriormente borrarla
                Doc.Add(Tabla_total)
                '1.	Tabla total con 2 columnas
                Tabla_total = New iTextSharp.text.pdf.PdfPTable(2)
                Tabla_total.TotalWidth = Anchopagina - Doc.LeftMargin
                Tabla_total.LockedWidth = True
                tamaniocolumna = New Single(1) {}
                tamaniocolumna(0) = Convert.ToSingle(anchoutil * 0.5)
                tamaniocolumna(1) = Convert.ToSingle(anchoutil * 0.5)
                Tabla_total.SetWidths(tamaniocolumna)
                'c.	Rendiciones a pagar
                'i.	5 columnas lado izquierdo sin encabezado
                Dim Tabla_Sueldoizquierdo As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(5)
                Dim tamaniocolumna_TEMPORAL = New Single(4) {}
                tamaniocolumna_TEMPORAL(0) = Convert.ToSingle(tamaniocolumna(0) * 0.05)
                tamaniocolumna_TEMPORAL(1) = Convert.ToSingle(tamaniocolumna(0) * 0.05)
                tamaniocolumna_TEMPORAL(2) = Convert.ToSingle(tamaniocolumna(0) * 0.05)
                tamaniocolumna_TEMPORAL(3) = Convert.ToSingle(tamaniocolumna(0) * 0.42)
                tamaniocolumna_TEMPORAL(4) = Convert.ToSingle(tamaniocolumna(0) * 0.42)
                '1.	RENDICIONES A PAGAR
                'a.	Inclinado 90º OCUPANDO EL TOTAL DE LA TABLA:
                '2.	GRUPOS
                'a.	Inclinado 90º por el numero total de celdas, ver posibles conflictos
                '3.	Subgrupos
                'a.	Inclinado 90º por el numero total de celdas, ver posibles conflictos
                '4.	Columna Concepto
                'a.	Normal, donde cada ítem de los subgrupos tiene su descripción
                '5.	Columna importe
                'a.	Normal, decimal, formato contable
                Tabla_Sueldoizquierdo.SetWidths(tamaniocolumna_TEMPORAL)
                Celdapdf_local = New iTextSharp.text.pdf.PdfPCell
                TEXTO.Clear()
                TEXTO.Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("CONCEPTO", PDF_fuente_variable(tamaniofuente, True))))
                TEXTO.Alignment = Element.ALIGN_CENTER
                Celdapdf_local.Colspan = 4
                Celdapdf_local.AddElement(TEXTO)
                Tabla_Sueldoizquierdo.AddCell(Celdapdf_local)
                'Celdapdf_local = New iTextSharp.text.pdf.PdfPCell
                'Celdapdf_local.AddElement(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("IMPORTE", PDF_fuente_variable(10, True))))
                'With Celdapdf_local
                '    '  .SetLeading(10, 1)
                '    .HorizontalAlignment = Element.ALIGN_RIGHT
                '    .Colspan = 1
                'End With
                Celdapdf_local = New PdfPCell
                TEXTO.Clear()
                TEXTO.Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("IMPORTE", PDF_fuente_variable(tamaniofuente, True))))
                TEXTO.Alignment = Element.ALIGN_CENTER
                Celdapdf_local.Colspan = 1
                Celdapdf_local.AddElement(TEXTO)
                Tabla_Sueldoizquierdo.AddCell(Celdapdf_local)
                'CELDAS DE ITEMS CORRESPONDIENTE AL DETALLE DE HABERES
                Dim TOTALDECELDAS As Integer = ORDENDEPAGOS.HABERES_DETALLE.Rows.Count - 1
                Dim TABLAS As New List(Of DataTable)
                Dim TABLASSUB As New List(Of DataTable)
                Dim LISTADOGRUPOS As New List(Of String)
                Dim LISTADOGRUPOS_CANT As New List(Of Integer)
                Dim LISTADOSUBGRUPOSCONTROL As New List(Of String) 'DEBERIA SER TEMPORAL HASTA ENCONTRAR UNA MEJOR SOLUCIÓN
                Dim LISTADOSUBGRUPOS As New List(Of String)
                Dim LISTADOSUBGRUPOS_CANT As New List(Of Integer)
                Dim VALORDEFILA As Integer = 0
                For X = 0 To ORDENDEPAGOS.HABERES_DETALLE.Rows.Count - 1
                    If Not LISTADOGRUPOS.Contains(ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("GRUPO").ToString, StringComparer.OrdinalIgnoreCase) Then
                        LISTADOGRUPOS.Add(ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("GRUPO").ToString)
                        TABLAS.Add(New DataTable)
                        With TABLAS.Item(TABLAS.Count - 1)
                            .Columns.Add("GRUPO")
                            .Columns.Add("SUBGRUPO")
                            .Columns.Add("DENOMINACION")
                            .Columns.Add("IMPORTE")
                        End With
                        TABLAS.Item(TABLAS.Count - 1).Rows.Add({ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("GRUPO").ToString, ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("SUBGRUPO").ToString, ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("DENOMINACION").ToString, ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("IMPORTE")})
                    Else
                        TABLAS.Item(TABLAS.Count - 1).Rows.Add({ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("GRUPO").ToString, ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("SUBGRUPO").ToString, ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("DENOMINACION").ToString, ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("IMPORTE")})
                        'SOLO PARA CONTROL
                    End If
                    If Not LISTADOSUBGRUPOSCONTROL.Contains(ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("GRUPO").ToString.ToUpper & "-" & ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("SUBGRUPO").ToString.ToUpper, StringComparer.OrdinalIgnoreCase) Then
                        LISTADOSUBGRUPOSCONTROL.Add(ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("GRUPO").ToString.ToUpper & "-" & ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("SUBGRUPO").ToString.ToUpper)
                        LISTADOSUBGRUPOS.Add(ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("SUBGRUPO").ToString)
                        TABLASSUB.Add(New DataTable)
                        With TABLASSUB.Item(TABLASSUB.Count - 1)
                            .Columns.Add("GRUPO")
                            .Columns.Add("SUBGRUPO")
                            .Columns.Add("DENOMINACION")
                            .Columns.Add("IMPORTE")
                        End With
                        TABLASSUB.Item(TABLASSUB.Count - 1).Rows.Add({ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("GRUPO").ToString, ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("SUBGRUPO").ToString, ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("DENOMINACION").ToString, ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("IMPORTE")})
                    Else
                        TABLASSUB.Item(TABLASSUB.Count - 1).Rows.Add({ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("GRUPO").ToString, ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("SUBGRUPO").ToString, ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("DENOMINACION").ToString, ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("IMPORTE")})
                        'SOLO PARA CONTROL
                    End If
                Next
                For Z = 0 To LISTADOGRUPOS.Count - 1
                    LISTADOGRUPOS_CANT.Add(0)
                    For X = 0 To ORDENDEPAGOS.HABERES_DETALLE.Rows.Count - 1
                        If ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("GRUPO").ToString = (LISTADOGRUPOS(Z)) Then
                            LISTADOGRUPOS_CANT(Z) += 1
                        Else
                            'SOLO PARA CONTROL
                        End If
                    Next
                Next
                For Z = 0 To LISTADOSUBGRUPOS.Count - 1
                    LISTADOSUBGRUPOS_CANT.Add(0)
                    For X = 0 To ORDENDEPAGOS.HABERES_DETALLE.Rows.Count - 1
                        If ORDENDEPAGOS.HABERES_DETALLE.Rows(X).Item("SUBGRUPO").ToString = (LISTADOSUBGRUPOS(Z)) Then
                            LISTADOSUBGRUPOS_CANT(Z) += 1
                        Else
                            'SOLO PARA CONTROL
                        End If
                    Next
                Next
                'INCLINADOS
                With Tabla_Sueldoizquierdo.AddCell(New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("RENDICIONES A PAGAR", PDF_fuente_variable(tamaniofuente, True)))))
                    .BorderWidth = 0.5
                    .Rotation = 90
                    ' .VerticalAlignment = Element.ALIGN_BASELINE
                    .HorizontalAlignment = Element.ALIGN_CENTER
                    '    .SetLeading(9, 1.2)
                    .Rowspan = TOTALDECELDAS + 1
                    .Colspan = 1
                End With
                For GRUPOS = 0 To LISTADOGRUPOS.Count - 1
                    'AGREGAR GRUPO
                    With Tabla_Sueldoizquierdo.AddCell(New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(LISTADOGRUPOS(GRUPOS), PDF_fuente_variable(tamaniofuente, True)))))
                        .BorderWidth = 0.5
                        .Rotation = 90
                        '.VerticalAlignment = Element.ALIGN_BASELINE
                        .HorizontalAlignment = Element.ALIGN_CENTER
                        '  .SetLeading(9, 1.2)
                        .Rowspan = TABLAS.Item(GRUPOS).Rows.Count
                        .Colspan = 1
                    End With
                    For I = 0 To TABLASSUB.Count - 1
                        'CARGA DE SUBGRUPOS Y SU ITEM
                        If TABLASSUB.Item(I).Rows(0).Item("GRUPO").ToString.ToUpper = LISTADOGRUPOS(GRUPOS).ToUpper Then
                            'AGREGAR SUBGRUPO
                            With Tabla_Sueldoizquierdo.AddCell(New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(TABLASSUB.Item(I).Rows(0).Item("SUBGRUPO").ToString, PDF_fuente_variable(tamaniofuente, True)))))
                                .BorderWidth = 0.5
                                .Rotation = 90
                                '.VerticalAlignment = Element.ALIGN_BASELINE
                                .HorizontalAlignment = Element.ALIGN_CENTER
                                '      .SetLeading(9, 1.2)
                                .Rowspan = TABLASSUB.Item(I).Rows.Count
                                .Colspan = 1
                            End With
                            '---------------------------------------DATOS DE CADA UNA DE LAS FILAS-----------------------------------
                            For Z = 0 To TABLASSUB.Item(I).Rows.Count - 1
                                With Tabla_Sueldoizquierdo.AddCell(New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(
                                                                                                           TABLASSUB.Item(I).Rows(Z).Item("DENOMINACION").ToString, PDF_fuente_variable(tamaniofuente - 1, False)))))
                                    .SetLeading(tamaniofuente - 1, 1)
                                    .VerticalAlignment = Element.ALIGN_MIDDLE
                                    '.Colspan = 1
                                End With
                                Select Case CType(TABLASSUB.Item(I).Rows(Z).Item("IMPORTE"), Decimal) > 0
                                    Case True
                                        With Tabla_Sueldoizquierdo.AddCell(New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(
                                                                                  CType(TABLASSUB.Item(I).Rows(Z).Item("IMPORTE"), Decimal).ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")),
                                                                                  PDF_fuente_variable(10, False)))))
                                            .SetLeading(tamaniofuente - 1, 1)
                                            .HorizontalAlignment = Element.ALIGN_RIGHT
                                        End With
                                    Case False
                                        With Tabla_Sueldoizquierdo.AddCell(New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(
                                                                                                                   "-", PDF_fuente_variable(tamaniofuente - 1, False)))))
                                            .SetLeading(tamaniofuente - 1, 1)
                                            .HorizontalAlignment = Element.ALIGN_RIGHT
                                        End With
                                End Select
                            Next
                        End If
                    Next
                Next
                'AGREGAR DATOS
                'tablascomogrupos ver si se puede almacenar en la base de datos, he aqui la parte mas larga debe almacenarse con la clave de la orden de pago
                'COMPLETARRRR
                'e.	TOTAL A PAGAR 2 COLUMNAS,SIN ENCABEZADO
                'f.	TABLA DE FIRMA JEFE CONTABILIDAD
                Tabla_Sueldoizquierdo.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("LIQUIDACIÓN A PAGAR", PDF_fuente_variable(tamaniofuente, True))), 0.5, 4, 1, 2, 1)))
                Celdapdf_local = New PdfPCell
                TEXTO = New Paragraph
                TEXTO.Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(ORDENDEPAGOS.Haberes_liquidacionapagar.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), PDF_fuente_variable(tamaniofuente, True))))
                TEXTO.Alignment = Element.ALIGN_RIGHT
                Celdapdf_local.Colspan = 1
                Celdapdf_local.AddElement(TEXTO)
                Tabla_Sueldoizquierdo.AddCell(Celdapdf_local)
                'Tabla_Sueldoizquierdo.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(
                '                                                                                                   ORDENDEPAGOS.ordenpago_montototal.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")),
                '                                                                                                   PDF_fuente_variable(10, True))), 0.5, 1, 1, Element.ALIGN_RIGHT, 1)))
                Tabla_Sueldoizquierdo.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("TOTAL GENERAL", PDF_fuente_variable(tamaniofuente, True))), 0.5, 4, 1, 0, 1)))
                Celdapdf_local = New PdfPCell
                TEXTO = New Paragraph
                TEXTO.Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk((ORDENDEPAGOS.ordenpago_montototal - ORDENDEPAGOS.Haberes_recuperovarios).ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), PDF_fuente_variable(tamaniofuente, True))))
                TEXTO.Alignment = Element.ALIGN_RIGHT
                Celdapdf_local.Colspan = 1
                Celdapdf_local.AddElement(TEXTO)
                Tabla_Sueldoizquierdo.AddCell(Celdapdf_local)
                'Tabla_Sueldoizquierdo.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(
                '                                                                                                   ORDENDEPAGOS.ordenpago_montototal.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")),
                '                                                                                                   PDF_fuente_variable(10, True))), 0.5, 1, 1, Element.ALIGN_RIGHT, 1)))
                'f.	TABLA DE FIRMA JEFE CONTABILIDAD
                Celdapdf_local = New PdfPCell(Elementopdf_a_Celda_conborde(Sello("CONTABILIDAD", Date.Now.ToString("yyyy-MM-dd"), tamaniofuente - 2), 0, 5, 1, 1))
                With Celdapdf_local
                    .VerticalAlignment = Element.ALIGN_BOTTOM
                    .Border = 0
                    .PaddingBottom = 4
                    .MinimumHeight = 60
                End With
                Tabla_Sueldoizquierdo.AddCell(Celdapdf_local)
                Tabla_Sueldoizquierdo.WidthPercentage = 98
                With Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(Tabla_Sueldoizquierdo, 0.5, 1)))
                End With
                'd.	LIQUIDACIÓN A PAGAR 10 COLUMNAS, SIN ENCABEZADO
                Dim Tabla_Sueldoderecho As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(10)
                tamaniocolumna = New Single(9) {}
                tamaniocolumna(0) = Convert.ToSingle(anchoutil * 0.1)
                tamaniocolumna(1) = Convert.ToSingle(anchoutil * 0.1)
                tamaniocolumna(2) = Convert.ToSingle(anchoutil * 0.1)
                tamaniocolumna(3) = Convert.ToSingle(anchoutil * 0.1)
                tamaniocolumna(4) = Convert.ToSingle(anchoutil * 0.1)
                tamaniocolumna(5) = Convert.ToSingle(anchoutil * 0.1)
                tamaniocolumna(6) = Convert.ToSingle(anchoutil * 0.1)
                tamaniocolumna(7) = Convert.ToSingle(anchoutil * 0.1)
                tamaniocolumna(8) = Convert.ToSingle(anchoutil * 0.1)
                tamaniocolumna(9) = Convert.ToSingle(anchoutil * 0.1)
                Tabla_Sueldoderecho.SetWidths(tamaniocolumna)
                Tabla_Sueldoderecho.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PDFFIRMAS(anchoutil * 0.5, "DELEGADO FISCAL", "DIRECTOR", tamaniofuente - 2), 0.5, 10, 1, 0, 10, 6)))
                Celdapdf_local = New iTextSharp.text.pdf.PdfPCell
                With Celdapdf_local
                    .AddElement(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Fecha", PDF_fuente_variable(9, False))))
                    .HorizontalAlignment = Element.ALIGN_CENTER
                    .VerticalAlignment = (Element.ALIGN_TOP)
                    .BorderWidth = 0.5
                    .Rowspan = 1
                    .Colspan = 2
                    .Padding = 1
                End With
                Tabla_Sueldoderecho.AddCell(Celdapdf_local)
                Celdapdf_local = New iTextSharp.text.pdf.PdfPCell
                With Celdapdf_local
                    .AddElement(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Cheque", PDF_fuente_variable(9, False))))
                    .HorizontalAlignment = Element.ALIGN_CENTER
                    .VerticalAlignment = (Element.ALIGN_TOP)
                    .BorderWidth = 0.5
                    .Rowspan = 1
                    .Colspan = 3
                    .Padding = 0
                End With
                Tabla_Sueldoderecho.AddCell(Celdapdf_local)
                Celdapdf_local = New iTextSharp.text.pdf.PdfPCell
                With Celdapdf_local
                    .AddElement(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Importe", PDF_fuente_variable(9, False))))
                    .HorizontalAlignment = Element.ALIGN_CENTER
                    .VerticalAlignment = (Element.ALIGN_TOP)
                    .BorderWidth = 0.5
                    .Rowspan = 1
                    .Colspan = 5
                    .Padding = 0
                End With
                Tabla_Sueldoderecho.AddCell(Celdapdf_local)
                '39 filas
                For x = 0 To 38
                    With Tabla_Sueldoderecho.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(tamaniofuente, True))), 0.5, 2, 1, 1, 1, 5)))
                        .VerticalAlignment = Element.ALIGN_MIDDLE
                        .HorizontalAlignment = Element.ALIGN_CENTER
                    End With
                    Tabla_Sueldoderecho.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(tamaniofuente, True))), 0.5, 3, 1, 1, 1, 5)))
                    Tabla_Sueldoderecho.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(tamaniofuente, True))), 0.5, 5, 1, 1, 1, 5)))
                Next
                '         Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(Tabla_Sueldoizquierdo, 1, 1, 1)))
                Tabla_Sueldoderecho.WidthPercentage = 100
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(Tabla_Sueldoderecho, 0, 1, 1, Element.ALIGN_JUSTIFIED, 0, Element.ALIGN_TOP)))
                'g.	COLUMNA 2 DE LA TABLA (tratar de hacer lo más ancho posible)
                'i.	Tabla de firmas
                '1.	Delegado Fiscal, Director, con bordes
                'ii.	Tabla con 3 columnas
                '1.	Fecha
                '2.	Cheque
                '3.	importe
                Doc.Add(Tabla_total)
                Doc.Add(TABLA_INICIALES(anchoutil, ORDENDEPAGOS.ordenpago_USUARIO))
                Doc.NewPage()
                'TABLA DE PARTIDAS PRESUPUESTARIAS
                'para lograr la adaptación completa debo disminuir el margen necesario
                Tabla_total = New iTextSharp.text.pdf.PdfPTable(14)
                Tabla_total.TotalWidth = Anchopagina - Doc.LeftMargin
                widths = New Single(13) {}
                widths(0) = Convert.ToSingle(Tabla_total.TotalWidth * 0.0375) 'jur.
                widths(1) = Convert.ToSingle(Tabla_total.TotalWidth * 0.0375) 'UO
                widths(2) = Convert.ToSingle(Tabla_total.TotalWidth * 0.07) 'CARAC
                widths(3) = Convert.ToSingle(Tabla_total.TotalWidth * 0.0375) ' FIN
                widths(4) = Convert.ToSingle(Tabla_total.TotalWidth * 0.0425) ' FUN.
                widths(5) = Convert.ToSingle(Tabla_total.TotalWidth * 0.075) 'SECC
                widths(6) = Convert.ToSingle(Tabla_total.TotalWidth * 0.075) 'SECT
                widths(7) = Convert.ToSingle(Tabla_total.TotalWidth * 0.075) ' PDA PCIAL
                widths(8) = Convert.ToSingle(Tabla_total.TotalWidth * 0.075) ' PDA PPAL
                widths(9) = Convert.ToSingle(Tabla_total.TotalWidth * 0.075) 'PDA SUB PAR
                widths(10) = Convert.ToSingle(Tabla_total.TotalWidth * 0.075) 'SCD
                widths(11) = Convert.ToSingle(Tabla_total.TotalWidth * 0.2) 'IMPORTE
                widths(12) = Convert.ToSingle(Tabla_total.TotalWidth * 0.075) 'PREV DEF OP
                widths(13) = Convert.ToSingle(Tabla_total.TotalWidth * 0.2) 'IMPORTE
                Tabla_total.SetWidths(widths)
                Tabla_total.LockedWidth = True
                Dim TABLAORDENDEPAGO As iTextSharp.text.pdf.PdfPTable = PDFDatatable_OP_HABERES(ORDENDEPAGOS.DatosOrdenPago, 5, Anchopagina - Doc.LeftMargin, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#ffffff")), tamaniofuente)
                '     Doc.Add(PARRAFOPARCIAL)
                'TEXTO.Clear()
                'With TEXTO
                '    .Add(PDFFIRMAS(Anchopagina - Doc.LeftMargin, "", "CONTABILIDAD"))
                'End With
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(TABLAORDENDEPAGO, 0.5, 14, 1)))
                Dim sumatotal As Decimal = 0
                For x = 0 To ORDENDEPAGOS.DatosOrdenPago.Rows.Count - 1
                    sumatotal += ORDENDEPAGOS.DatosOrdenPago.Rows(x).Item("importe")
                Next
                Celdapdf_local = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("TOTAL", PDF_fuente_variable(tamaniofuente + 1, True)))) With {
            .BorderWidth = 0.5,
            .VerticalAlignment = Element.ALIGN_MIDDLE,
            .HorizontalAlignment = Element.ALIGN_RIGHT,
            .Padding = 3,
            .Colspan = 11
        }
                Tabla_total.AddCell(Celdapdf_local)
                Tabla_total.AddCell(Phrasepdf(sumatotal.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")), tamaniofuente + 1, True, 0.5, 1, 1, Element.ALIGN_RIGHT, 3))
                Celdapdf_local = New iTextSharp.text.pdf.PdfPCell
                With Celdapdf_local
                    .AddElement(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(tamaniofuente, True))))
                    .HorizontalAlignment = Element.ALIGN_RIGHT
                    .VerticalAlignment = (Element.ALIGN_TOP)
                    .BorderWidth = 0.5
                    .Rowspan = 1
                    .Colspan = 2
                    .Padding = 0
                End With
                Tabla_total.AddCell(Celdapdf_local)
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PDFFIRMAS(anchoutil, "", "CONTABILIDAD"), 0.5, 14, 1,, 5)))
                'TABLAORDENDEPAGO.AddCell(New PdfPCell((TABLA_INICIALES(anchoutil, ORDENDEPAGOS.ordenpago_USUARIO))))
                'Agrega la leyenda de Expediente autorizante si este existe
                If ORDENDEPAGOS.ClaveExpediente_principal.ToString.Length = 13 Then
                    Tabla_total.AddCell(Phrasepdf("Expte. Autorizante: " & ORDENDEPAGOS.ClaveExpediente_principal.ToString.Substring(4, 4) & "-" &
                                                     Convert.ToInt32(ORDENDEPAGOS.ClaveExpediente_principal.ToString.Substring(8, 5)) & "/" &
                                                    ORDENDEPAGOS.ClaveExpediente_principal.ToString.Substring(0, 4), tamaniofuente, True, 0, 14, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                Else
                End If
                Doc.Add(Tabla_total)
                Doc.Add(TABLA_INICIALES(anchoutil, ORDENDEPAGOS.ordenpago_USUARIO))
                Dim COLUMNA2 As New ColumnText(wri.DirectContent)
                'the Phrase
                'the lower left x corner (left)
                'the lower left y corner (bottom)
                'the upper right x corner (right)
                'the upper right y corner (top)
                'line height(leading)
                'alignment.
                Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14.0F, iTextSharp.text.Font.BOLD, BaseColor.GRAY)
                COLUMNA2.SetSimpleColumn(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("SICyF", font12Bold)),
                                        Doc.Left, Doc.Bottom,
                                      Doc.Right, 0,
                                        15, Element.ALIGN_RIGHT)
                COLUMNA2.Go()
                Doc.Close()
            End Using
            Select Case MsgBox("Abrir el archivo generado?", MsgBoxStyle.YesNoCancel, " ")
                Case MsgBoxResult.Yes
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(FileName) With {
                                             .UseShellExecute = True
    })
            End Select
        End If
    End Sub

    Public Function Iniciales(ByVal documento As Integer) As String
        Dim iniciales_ As String = ""
        Dim TABLATEMPORAL As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@documento", documento)
        Inicio.SQLPARAMETROS("CONTADURIA_USUARIOS", "SELECT
    CONCAT(NOMBRES,' ',APELLIDOS ) FROM
	USUARIOS WHERE USUARIO=@DOCUMENTO",
                             TABLATEMPORAL, System.Reflection.MethodBase.GetCurrentMethod.Name)
        If TABLATEMPORAL.Rows.Count > 0 Then
            iniciales_ = Inicialesstring(TABLATEMPORAL.Rows(0).Item(0).ToString)
        Else
            iniciales_ = ""
        End If
        Return iniciales_
    End Function

    Public Function Inicialesstring(ByVal texto As String) As String
        Dim Textoaretornar As String = ""
        Dim splitter As String()
        splitter = Split(texto, " ")
        For Each StringS In splitter
            If StringS.Length > 0 Then
                Textoaretornar += StringS.Substring(0, 1)
            End If
        Next
        Return Textoaretornar
    End Function

    Public Function TABLA_INICIALES(ByVal ANCHOUTIL As Single, ByVal DOCUMENTO_USUARIO As Integer) As PdfPTable
        Dim TABLA As PdfPTable = New PdfPTable(1)
        Dim tamaniocolumna As Single() = New Single(0) {}
        tamaniocolumna(0) = Convert.ToSingle(ANCHOUTIL * 1)
        'fix the absolute width of the table
        TABLA.TotalWidth = ANCHOUTIL
        TABLA.SpacingBefore = 2
        TABLA.SpacingAfter = 0
        TABLA.SetWidths(tamaniocolumna)
        TABLA.LockedWidth = True
        'relative col widths in proportions
        'INICIALES
        TABLA.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Iniciales(DOCUMENTO_USUARIO), PDF_fuente_variable(6, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_LEFT, 0)))
        Return TABLA
    End Function

    Public Function CUENTA_PDF(ByVal CARACTER As String) As String
        'Dim TABLA As PdfPTable = New PdfPTable(1)
        Dim tamaniocolumna As Single() = New Single(0) {}
        Dim CANTIDADDESIMILARES As Integer = 0
        'tamaniocolumna(0) = Convert.ToSingle(ANCHOUTIL * 1)
        Dim CUENTABANCARIA As String = ""
        'fix the absolute width of the table
        'TABLA.TotalWidth = ANCHOUTIL
        'TABLA.SpacingBefore = 2
        'TABLA.SpacingAfter = 0
        'TABLA.SetWidths(tamaniocolumna)
        'TABLA.LockedWidth = True
        'relative col widths in proportions
        Dim CUENTASFILTRADO As New DataTable
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@CARACTER", CARACTER)
        CUENTASFILTRADO.Columns.Add(Autocompletetables.Cuentas.Columns(0).ColumnName)
        CUENTASFILTRADO.Columns.Add(Autocompletetables.Cuentas.Columns(1).ColumnName)
        CUENTASFILTRADO.Columns.Add(Autocompletetables.Cuentas.Columns(2).ColumnName)
        For X = 0 To Autocompletetables.Cuentas.Rows.Count - 1
            If Autocompletetables.Cuentas.Rows(X).Item(2) = CARACTER Then
                CUENTASFILTRADO.Rows.Add({Autocompletetables.Cuentas.Rows(X).Item(0), Autocompletetables.Cuentas.Rows(X).Item(1), Autocompletetables.Cuentas.Rows(X).Item(2)})
                CANTIDADDESIMILARES += 1
                CUENTABANCARIA = Autocompletetables.Cuentas.Rows(X).Item(1)
            End If
        Next
        Select Case CANTIDADDESIMILARES
            Case = 1
            Case = 0
                DialogDialogo_Datagridview.Carga_General(Autocompletetables.Cuentas, "Seleccione por Favor la CUENTA BANCARIA", "Seleccionar", "Cancelar", 10)
                If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) And DialogDialogo_Datagridview.Datosdialogo_datagridview.SelectedRows.Count = 1 Then
                    CUENTABANCARIA = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(1).Value
                Else
                End If
            Case Else
                DialogDialogo_Datagridview.Carga_General(CUENTASFILTRADO, "Seleccione por Favor la CUENTA BANCARIA", "Seleccionar", "Cancelar", 10)
                If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) And DialogDialogo_Datagridview.Datosdialogo_datagridview.SelectedRows.Count = 1 Then
                    CUENTABANCARIA = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(1).Value
                Else
                End If
        End Select
        Return CUENTABANCARIA
        'TABLA.AddCell(New PdfPCell(Phrasepdf_a_Celda_conborde(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(CUENTABANCARIA, PDF_fuente_variable(8, True))), 0, 1, 1, iTextSharp.text.Element.ALIGN_LEFT, 0)))
        'Return TABLA
    End Function

    Private Function CeldaPDF(ByVal Texto As String, ByVal tamanio As Single, ByVal Bold As Boolean, ByVal Borde As Boolean, ByVal Columnasdeancho As Integer) As PdfPCell
        Dim Fontusada As iTextSharp.text.Font
        If Bold Then
            Fontusada = New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, tamanio, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Else
            Fontusada = New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, tamanio, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        End If
        Dim CELDA As PdfPCell = New PdfPCell(New Phrase(New Chunk(Texto, Fontusada)))
        CELDA.Colspan = Columnasdeancho
        If Borde Then
            CELDA.BorderColor = BaseColor.BLACK
            CELDA.BorderWidth = 0.5F
            CELDA.Border = Rectangle.BOX
        Else
        End If
        Return CELDA
    End Function

    Private Function TablaPDf(ByVal Reporteaimprimir As DataGridView) As PdfPTable
        Dim Tamanio As Rectangle
        Dim Horizontal As Boolean = False
        'Select Case Tamaniohoja.ToUpper
        '    Case "LEGAL"
        Tamanio = iTextSharp.text.PageSize.LEGAL
        '    Case "A4"
        '        Tamanio = iTextSharp.text.PageSize.A4
        '    Case Else
        '        Tamanio = iTextSharp.text.PageSize.LEGAL
        'End Select
        Dim totalcolumnas As Integer = -1
        For V = 0 To Reporteaimprimir.Columns.Count - 1
            If Not Reporteaimprimir.Columns(V).Visible = False Then
                totalcolumnas = totalcolumnas + 1
            End If
        Next
        Dim Columnasvisibles(totalcolumnas) As Integer
        Dim AnchoColumnas(0) As Single
        Dim control As Integer = 0
        For V = 0 To Reporteaimprimir.Columns.Count - 1
            If Reporteaimprimir.Columns(V).Visible = True Then
                Columnasvisibles(control) = V
                ReDim Preserve AnchoColumnas(control)
                AnchoColumnas(control) = CType(Reporteaimprimir.Columns(V).Width / Reporteaimprimir.Width, Single)
                control = control + 1
            End If
        Next
        Dim PdfTable As PdfPTable = New PdfPTable(Columnasvisibles.Length)
        PdfTable.SpacingBefore = 7.0F
        PdfTable.HorizontalAlignment = 1
        'Selección de orientación de página
        If Horizontal Then
            PdfTable.TotalWidth = Tamanio.Rotate.Width - 40
        Else
            PdfTable.TotalWidth = Tamanio.Width - 40
        End If
        PdfTable.SetWidths(AnchoColumnas)
        'Fuente del encabezado
        Dim Fuente_encabezado As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, Reporteaimprimir.ColumnHeadersDefaultCellStyle.Font.Size, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        'Declaración de celdas.
        Dim PdfPCell As PdfPCell = Nothing
        If Reporteaimprimir.ColumnHeadersVisible Then
            For X = 0 To Columnasvisibles.Length - 1
                'Asignación de valores a cada celda como frases.
                PdfPCell = New PdfPCell(New Phrase(New Chunk(Reporteaimprimir.Columns(Columnasvisibles(X)).HeaderText, Fuente_encabezado)))
                'Alignment of phrase in the pdfcell
                PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                'Add pdfcell in pdftable
                PdfTable.AddCell(PdfPCell)
            Next
            PdfTable.HeaderRows = 1
        Else
            PdfTable.HeaderRows = 0
        End If
        Dim Tmaniofuentecelda As Single = Reporteaimprimir.DefaultCellStyle.Font.Size
        'Agregar los datos del datagridview a la tabla
        For rows As Integer = 0 To Reporteaimprimir.Rows.Count - 1
            For column As Integer = 0 To Columnasvisibles.Length - 1
                If IsNothing(Reporteaimprimir.Rows(rows).Cells.Item(Columnasvisibles(column)).Value) Then
                    PdfTable.AddCell(CeldaPDF("", Tmaniofuentecelda, False, True, 1))
                    'PdfPCell = New PdfPCell(New Phrase("", font07Normal))
                Else
                    Select Case Reporteaimprimir.Rows(rows).Cells.Item(Columnasvisibles(column)).Value.GetType.ToString.ToUpper
                        Case Is = "SYSTEM.DATETIME"
                            PdfTable.AddCell(CeldaPDF(CType(Reporteaimprimir.Rows(rows).Cells.Item(Columnasvisibles(column)).Value, Date).ToShortDateString, Tmaniofuentecelda, False, True, 1))
                            'PdfPCell = New PdfPCell(New Phrase(CType(Reporteaimprimir.Rows(rows).Cells.Item(Columnasvisibles(column)).Value, Date).ToShortDateString, font07Normal))
                        Case Is = "SYSTEM.DECIMAL"
                            PdfTable.AddCell(CeldaPDF(CType(Reporteaimprimir.Rows(rows).Cells.Item(Columnasvisibles(column)).Value, Decimal).ToString("C2"), Tmaniofuentecelda, False, True, 1))
                            'PdfPCell = New PdfPCell(New Phrase(CType(Reporteaimprimir.Rows(rows).Cells.Item(Columnasvisibles(column)).Value, Decimal).ToString("C2"), font07Normal))
                        Case Is = "SYSTEM.DBNULL"
                            PdfTable.AddCell(CeldaPDF("", 7, False, True, 1))
                            ' PdfPCell = New PdfPCell(New Phrase("", font07Normal))
                        Case Else
                            PdfTable.AddCell(CeldaPDF(Reporteaimprimir.Rows(rows).Cells.Item(Columnasvisibles(column)).Value.ToString, Tmaniofuentecelda, False, True, 1))
                            '   PdfPCell = New PdfPCell(New Phrase(Reporteaimprimir.Rows(rows).Cells.Item(Columnasvisibles(column)).Value.ToString, font07Normal))
                    End Select
                    ' PdfPCell = New PdfPCell(New Phrase(Reporteaimprimir.Rows(rows).Cells.Item(column).Value.ToString(), font09Normal))
                End If
            Next
        Next
        Return PdfTable
    End Function

    'Private Function ParrafoPDf()
    'End Function
    'Public Sub PDFDatagridviewvertical(ByRef Reporteaimprimir As DataGridView, ByVal Titulo As String)
    '    If Reporteaimprimir IsNot Nothing Then
    '        Dim totalcolumnas As Integer = -1
    '        For V = 0 To Reporteaimprimir.Columns.Count - 1
    '            If Not Reporteaimprimir.Columns(V).Visible = False Then
    '                totalcolumnas = totalcolumnas + 1
    '            End If
    '        Next
    '        Dim Columnasvisibles(totalcolumnas) As Integer
    '        Dim control As Integer = 0
    '        For V = 0 To Reporteaimprimir.Columns.Count - 1
    '            If Reporteaimprimir.Columns(V).Visible = True Then
    '                Columnasvisibles(control) = V
    '                control = control + 1
    '            End If
    '        Next
    '        ' MessageBox.Show(Columnasvisibles.Length - 1)
    '        Dim Controlguardado As New SaveFileDialog
    '        Controlguardado.Filter = "ARCHIVO PDF|*.pdf"
    '        Controlguardado.Title = "Guardar en archivo PDF"
    '        Controlguardado.ShowDialog()
    '        If Controlguardado.FileName = "" Then
    '            MsgBox("Para poder proceder a la creación del archivo se requiere un nombre")
    '            Exit Sub
    '        Else
    '            Dim font12BoldRed As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.UNDERLINE Or iTextSharp.text.Font.BOLDITALIC, BaseColor.RED)
    '            Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
    '            Dim font10Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
    '            Dim font12Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
    '            Dim font10Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
    '            Dim font09Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 9.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
    '            Dim titleFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
    '            Dim FileName As String = Controlguardado.FileName
    '            Dim paragraph As New Paragraph
    '            Dim anchototal As Integer = 0
    '            Dim doc As New Document(iTextSharp.text.PageSize.LEGAL, 20, 20, 20, 20)
    '            Dim wri As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(FileName, FileMode.Create))
    '            Dim ev As New itsEvents2
    '            wri.PageEvent = ev
    '            If doc.IsOpen Then
    '                doc.Close()
    '            End If
    '            doc.Open()
    '            Dim encabezado As New Paragraph(Autorizaciones.Nombrecompletodelservicio, titleFont)
    '            Dim PdfTable As PdfPTable = New PdfPTable(Columnasvisibles.Length)
    '            PdfTable.TotalWidth = iTextSharp.text.PageSize.LEGAL.Width - 40
    '            'fix the absolute width of the table
    '            PdfTable.LockedWidth = True
    '            'relative col widths in proportions
    '            Dim widths(0 To Columnasvisibles.Length - 1) As Single
    '            For i As Integer = 0 To Columnasvisibles.Length - 1
    '                anchototal = anchototal + Reporteaimprimir.Columns(Columnasvisibles(i)).Width + 2
    '            Next
    '            'For i As Integer = 0 To DTB.Columns.Count - 1
    '            '    widths(i) = CType((DTB.Columns(i) / anchototal), Single)
    '            'Next
    '            ' PdfTable.SetWidths(widths)
    '            PdfTable.HorizontalAlignment = 1 ' 0 --> Left, 1 --> Center, 2 --> Right
    '            PdfTable.SpacingBefore = 12.0F
    '            'Declaración de celdas.
    '            Dim PdfPCell As PdfPCell = Nothing
    '            For X = 0 To Columnasvisibles.Length - 1
    '                'Asignación de valores a cada celda como frases.
    '                PdfPCell = New PdfPCell(New Phrase(New Chunk(Reporteaimprimir.Columns(Columnasvisibles(X)).HeaderText, font10Bold)))
    '                'Alignment of phrase in the pdfcell
    '                PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER
    '                'Add pdfcell in pdftable
    '                PdfTable.AddCell(PdfPCell)
    '            Next
    '            PdfTable.HeaderRows = 1
    '            'Agregar los datos del datagridview a la tabla
    '            For rows As Integer = 0 To Reporteaimprimir.Rows.Count - 1
    '                For column As Integer = 0 To Columnasvisibles.Length - 1
    '                    If IsNothing(Reporteaimprimir.Rows(rows).Cells.Item(Columnasvisibles(column)).Value) Then
    '                        PdfPCell = New PdfPCell(New Phrase("", font09Normal))
    '                    Else
    '                        Select Case Reporteaimprimir.Rows(rows).Cells.Item(Columnasvisibles(column)).Value.GetType.ToString.ToUpper
    '                            Case Is = "SYSTEM.DATETIME"
    '                                PdfPCell = New PdfPCell(New Phrase(CType(Reporteaimprimir.Rows(rows).Cells.Item(Columnasvisibles(column)).Value, Date).ToShortDateString, font09Normal))
    '                            Case Is = "SYSTEM.DECIMAL"
    '                                PdfPCell = New PdfPCell(New Phrase(CType(Reporteaimprimir.Rows(rows).Cells.Item(Columnasvisibles(column)).Value, Decimal).ToString("C2"), font09Normal))
    '                            Case Is = "SYSTEM.DBNULL"
    '                                PdfPCell = New PdfPCell(New Phrase("", font09Normal))
    '                            Case Else
    '                                PdfPCell = New PdfPCell(New Phrase(Reporteaimprimir.Rows(rows).Cells.Item(Columnasvisibles(column)).Value.ToString, font09Normal))
    '                        End Select
    '                        ' PdfPCell = New PdfPCell(New Phrase(Reporteaimprimir.Rows(rows).Cells.Item(column).Value.ToString(), font09Normal))
    '                    End If
    '                    PdfTable.AddCell(PdfPCell)
    '                Next
    '            Next
    '            'Agregar la tabla al documento
    '            doc.Add(PdfTable)
    '            'Verificar intento de agregar firma
    '            doc.Add(New Paragraph(Autorizaciones.Usuario.Rows(0).Item("Apellidos").ToString & "  " & Autorizaciones.Usuario.Rows(0).Item("nombres").ToString, FontFactory.GetFont("ARIAL", 6, iTextSharp.text.Font.BOLD)))
    '            doc.AddCreator(Autorizaciones.Usuario.Rows(0).Item("Apellidos").ToString & "  " & Autorizaciones.Usuario.Rows(0).Item("nombres").ToString)
    '            doc.AddHeader("", Autorizaciones.Nombrecompletodelservicio)
    '            doc.Close()
    '            Select Case MsgBox("Archivo generado Exitosamente" & vbCrLf & "Desea abrir el archivo generado?", MsgBoxStyle.YesNoCancel, " ")
    '                Case MsgBoxResult.Yes
    '                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(Controlguardado.FileName) With {
    '                                                         .UseShellExecute = True})
    '            End Select
    '            'unaTabla.SetWidthPercentage(New Single() {300, 300}, PageSize.A4)
    '            ''Headers
    '            'unaTabla.AddCell(New Paragraph("Columna 1"))
    '            'unaTabla.AddCell(New Paragraph("Columna 2"))
    '            ''�Le damos un poco de formato?
    '            'For Each celda As PdfPCell In unaTabla.Rows(0).GetCells
    '            '    celda.BackgroundColor = BaseColor.LIGHT_GRAY
    '            '    celda.HorizontalAlignment = 1
    '            '    celda.Padding = 3
    '            'Next
    '            'Dim celda1 As PdfPCell = New PdfPCell(New Paragraph("Celda 1", FontFactory.GetFont("Arial", 10)))
    '            'Dim celda2 As PdfPCell = New PdfPCell(New Paragraph("Celda 2", FontFactory.GetFont("Arial", 10)))
    '            'Dim celda3 As PdfPCell = New PdfPCell(New Paragraph("Celda 3", FontFactory.GetFont("Arial", 10)))
    '            'Dim celda4 As PdfPCell = New PdfPCell(New Paragraph("Celda 4", FontFactory.GetFont("Arial", 10)))
    '            'unaTabla.AddCell(celda1)
    '            'unaTabla.AddCell(celda2)
    '            'unaTabla.AddCell(celda3)
    '            'unaTabla.AddCell(celda4)
    '            'doc.Add(unaTabla)
    '        End If
    '    End If
    'End Sub
    Public Sub ExportDataToPDFTable2(ByVal Reporteaimprimir As DataGridView, ByVal Titulo As String)
        Dim columnasaborrararray As Integer = 0
        Dim columnasaborrar_list As New List(Of String)
        Dim DTB = New DataTable, RWS As Integer, CLS As Integer
        For CLS = 0 To Reporteaimprimir.ColumnCount - 1 ' COLUMNS OF DTB
            DTB.Columns.Add(Reporteaimprimir.Columns(CLS).Name.ToString)
            Select Case Reporteaimprimir.Columns(CLS).Visible
                Case True
                Case False
                    columnasaborrar_list.Add(Reporteaimprimir.Columns(CLS).Name.ToString)
            End Select
        Next
        Dim DRW As DataRow
        For RWS = 0 To Reporteaimprimir.Rows.Count - 1 ' FILL DTB WITH DATAGRIDVIEW
            DRW = DTB.NewRow
            For CLS = 0 To Reporteaimprimir.ColumnCount - 1
                Select Case DTB.Columns(CLS).ColumnName.ToString.ToUpper = "COLUMN1"
                    Case True
                        Select Case Reporteaimprimir.Rows(RWS).Cells.Item(CLS).GetType.ToString.ToUpper
                            Case = "SYSTEM.WINDOWS.FORMS.DATAGRIDVIEWBUTTONCELL"
                                DRW(CLS) = ""
                            Case Else
                                MessageBox.Show(Reporteaimprimir.Rows(RWS).Cells.Item(CLS).GetType.ToString)
                        End Select
                    Case False
                        DRW(DTB.Columns(CLS).ColumnName.ToString) = Reporteaimprimir.Rows(RWS).Cells.Item(DTB.Columns(CLS).ColumnName.ToString).Value.ToString
                End Select
                ' Try
                'Select Case DGV.Columns(CLS).Visible
                '    Case True
                '------------------- DRW(DTB.Columns(CLS).ColumnName.ToString) = Reporteaimprimir.Rows(RWS).Cells.Item(DTB.Columns(CLS).ColumnName.ToString).Value
                'DTB.Columns.Add(DGV.Columns(CLS).Name.ToString, DGV.Columns(CLS).ValueType)
                '   Case False
                '  End Select
                '     Catch ex As Exception
                'End Try
            Next
            DTB.Rows.Add(DRW)
        Next
        DTB.AcceptChanges()
        For x As Integer = 0 To columnasaborrar_list.Count - 1
            'For Z = 0 To DTB.Columns.Count - 1
            '    Select Case
            'Next
            DTB.Columns.Remove(columnasaborrar_list(x))
        Next
        Dim DST As New DataSet
        DST.Tables.Add(DTB)
        Dim Controlguardado As New SaveFileDialog
        Controlguardado.Filter = "ARCHIVO PDF|*.pdf"
        Controlguardado.Title = "Guardar en archivo PDF"
        Controlguardado.ShowDialog()
        If Controlguardado.FileName = "" Then
            MsgBox("Para poder proceder a la creación del archivo se requiere un nombre")
            Exit Sub
        Else
            Dim FileName As String = Controlguardado.FileName
            Dim paragraph As New Paragraph
            Dim anchototal As Integer = 0
            Dim doc As New Document(iTextSharp.text.PageSize.LEGAL.Rotate, 20, 20, 20, 20)
            Dim wri As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(FileName, FileMode.Create))
            Dim ev As New itsEvents
            'borrar columnas que no son visibles
            doc.Open()
            wri.PageEvent = ev
            '     ev.OnEndPage(wri, doc)
            Dim font12BoldRed As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.UNDERLINE Or iTextSharp.text.Font.BOLDITALIC, BaseColor.RED)
            Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font10Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font12Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim font10Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim font09Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 9.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim titleFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            'Dim p1 As New Phrase
            'p1 = New Phrase(New Chunk("PDF From Datagridview Data", font12BoldRed))
            'doc.Add(p1)..
            Dim logo As Image = iTextSharp.text.Image.GetInstance(System.Drawing.Image.FromHbitmap(My.Resources.Logo.GetHbitmap()), System.Drawing.Imaging.ImageFormat.Png)
            logo.ScaleAbsoluteWidth(200)
            logo.ScaleAbsoluteHeight(50)
            Dim cellLogo As PdfPCell = New PdfPCell(logo)
            cellLogo.Border = Rectangle.NO_BORDER
            cellLogo.PaddingBottom = 8
            Dim title = New Paragraph(Titulo, titleFont)
            title.Alignment = Element.ALIGN_MIDDLE
            Dim cellTitle As PdfPCell = New PdfPCell(title)
            cellTitle.Border = Rectangle.NO_BORDER
            cellTitle.HorizontalAlignment = 2
            wri.Add(New Paragraph("                       "))
            'Create instance of the pdf table and set the number of column in that table
            Dim PdfTable As New PdfPTable(DTB.Columns.Count)
            PdfTable.TotalWidth = iTextSharp.text.PageSize.LEGAL.Rotate.Width - 40
            'fix the absolute width of the table
            PdfTable.LockedWidth = True
            'relative col widths in proportions
            Dim widths(0 To DTB.Columns.Count - 1) As Single
            For i As Integer = 0 To Reporteaimprimir.Columns.Count - 1
                anchototal = anchototal + Reporteaimprimir.Columns(i).Width + 2
            Next
            'For i As Integer = 0 To DTB.Columns.Count - 1
            '    widths(i) = CType((DTB.Columns(i) / anchototal), Single)
            'Next
            ' PdfTable.SetWidths(widths)
            PdfTable.HorizontalAlignment = 1 ' 0 --> Left, 1 --> Center, 2 --> Right
            PdfTable.SpacingBefore = 32.0F
            'pdfCell Decleration
            Dim PdfPCell As PdfPCell = Nothing
            For X = 0 To DTB.Columns.Count - 1
                'Assigning values to each cell as phrases
                PdfPCell = New PdfPCell(New Phrase(New Chunk(DTB.Columns(X).ColumnName, font10Bold)))
                'Alignment of phrase in the pdfcell
                PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                'Add pdfcell in pdftable
                PdfTable.AddCell(PdfPCell)
            Next
            PdfTable.HeaderRows = 1
            If DTB IsNot Nothing Then
                'Now add the data from datatable to pdf table
                For rows As Integer = 0 To DTB.Rows.Count - 1
                    For column As Integer = 0 To DTB.Columns.Count - 1
                        PdfPCell = New PdfPCell(New Phrase(DTB.Rows(rows).Item(column).ToString(), font10Normal))
                        'If column = 0 Or column = 1 Then
                        PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                        'Else
                        '    PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_RI
                        'End If
                        PdfTable.AddCell(PdfPCell)
                    Next
                Next
                'Adding pdftable to the pdfdocument
                doc.Add(PdfTable)
                doc.Add(New Paragraph(Autorizaciones.Usuario.Rows(0).Item("Apellidos").ToString & "  " & Autorizaciones.Usuario.Rows(0).Item("nombres").ToString, FontFactory.GetFont("ARIAL", 6, iTextSharp.text.Font.BOLD)))
            End If
            Dim COLUMNA2 As New ColumnText(wri.DirectContent)
            'the Phrase
            'the lower left x corner (left)
            'the lower left y corner (bottom)
            'the upper right x corner (right)
            'the upper right y corner (top)
            'line height(leading)
            'alignment.
            Dim font14Bolds As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14.0F, iTextSharp.text.Font.BOLD, BaseColor.GRAY)
            COLUMNA2.SetSimpleColumn(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("SICyF", font14Bolds)),
                                        doc.Left, doc.Bottom,
                                      doc.Right, 0,
                                        15, Element.ALIGN_RIGHT)
            COLUMNA2.Go()
            doc.Close()
            Select Case MsgBox("Archivo generado Exitosamente" & vbCrLf & "Desea abrir el archivo generado?", MsgBoxStyle.YesNoCancel, " ")
                Case MsgBoxResult.Yes
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(Controlguardado.FileName) With {
                                         .UseShellExecute = True
})
            End Select
        End If
    End Sub

    'Sub obsoleta reemplazada por ExportDataToPDFTable2
    Public Sub ExportDataToPDFTable(ByVal Reporteaimprimir As DataGridView, ByVal Titulo As String)
        Dim Controlguardado As New SaveFileDialog
        Controlguardado.Filter = "ARCHIVO PDF|*.pdf"
        Controlguardado.Title = "Guardar en archivo PDF"
        Controlguardado.ShowDialog()
        If Controlguardado.FileName = "" Then
            MsgBox("Para poder proceder a la creación del archivo se requiere un nombre")
            Exit Sub
        Else
            Dim FileName As String = Controlguardado.FileName
            Dim paragraph As New Paragraph
            Dim anchototal As Integer = 0
            Dim doc As New Document(iTextSharp.text.PageSize.LEGAL.Rotate, 20, 20, 20, 20)
            Dim wri As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(FileName, FileMode.Create))
            Dim ev As New itsEvents
            'borrar columnas que no son visibles
            For x = Reporteaimprimir.Columns.Count - 1 To 0
                Select Case Reporteaimprimir.Columns(x).Visible
                    Case True
                    Case False
                        Reporteaimprimir.Columns(x).Dispose()
                End Select
            Next
            doc.Open()
            wri.PageEvent = ev
            '   ev.OnEndPage(wri, doc)
            Dim font12BoldRed As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.UNDERLINE Or iTextSharp.text.Font.BOLDITALIC, BaseColor.RED)
            Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font10Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font12Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim font10Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim titleFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            'Dim p1 As New Phrase
            'p1 = New Phrase(New Chunk("PDF From Datagridview Data", font12BoldRed))
            'doc.Add(p1)..
            Dim logo As Image = iTextSharp.text.Image.GetInstance(System.Drawing.Image.FromHbitmap(My.Resources.Logo.GetHbitmap()), System.Drawing.Imaging.ImageFormat.Png)
            logo.ScaleAbsoluteWidth(200)
            logo.ScaleAbsoluteHeight(50)
            Dim cellLogo As PdfPCell = New PdfPCell(logo)
            cellLogo.Border = Rectangle.NO_BORDER
            cellLogo.PaddingBottom = 8
            Dim title = New Paragraph(Titulo, titleFont)
            title.Alignment = Element.ALIGN_MIDDLE
            Dim cellTitle As PdfPCell = New PdfPCell(title)
            cellTitle.Border = Rectangle.NO_BORDER
            cellTitle.HorizontalAlignment = 2
            wri.Add(New Paragraph("                       "))
            'Create instance of the pdf table and set the number of column in that table
            Dim PdfTable As New PdfPTable(Reporteaimprimir.Columns.Count)
            PdfTable.TotalWidth = iTextSharp.text.PageSize.LEGAL.Rotate.Width - 40
            'fix the absolute width of the table
            PdfTable.LockedWidth = True
            'relative col widths in proportions
            Dim widths(0 To Reporteaimprimir.Columns.Count - 1) As Single
            For i As Integer = 0 To Reporteaimprimir.Columns.Count - 1
                anchototal = anchototal + Reporteaimprimir.Columns(i).Width + 2
            Next
            For i As Integer = 0 To Reporteaimprimir.Columns.Count - 1
                widths(i) = CType((Reporteaimprimir.Columns(i).Width / anchototal), Single)
            Next
            PdfTable.SetWidths(widths)
            PdfTable.HorizontalAlignment = 1 ' 0 --> Left, 1 --> Center, 2 --> Right
            PdfTable.SpacingBefore = 32.0F
            'pdfCell Decleration
            Dim PdfPCell As PdfPCell = Nothing
            For X = 0 To Reporteaimprimir.Columns.Count - 1
                'Assigning values to each cell as phrases
                PdfPCell = New PdfPCell(New Phrase(New Chunk(Reporteaimprimir.Columns(X).HeaderText, font10Bold)))
                'Alignment of phrase in the pdfcell
                PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER
                'Add pdfcell in pdftable
                PdfTable.AddCell(PdfPCell)
            Next
            PdfTable.HeaderRows = 1
            If Reporteaimprimir IsNot Nothing Then
                'Now add the data from datatable to pdf table
                For rows As Integer = 0 To Reporteaimprimir.Rows.Count - 1
                    For column As Integer = 0 To Reporteaimprimir.Columns.Count - 1
                        PdfPCell = New PdfPCell(New Phrase(Reporteaimprimir.Rows(rows).Cells.Item(column).Value.ToString(), font10Normal))
                        'If column = 0 Or column = 1 Then
                        '    PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_LEFT
                        'Else
                        '    PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_RI
                        'End If
                        PdfTable.AddCell(PdfPCell)
                    Next
                Next
                'Adding pdftable to the pdfdocument
                doc.Add(PdfTable)
                doc.Add(New Paragraph(Autorizaciones.Usuario.Rows(0).Item("Apellidos").ToString & "  " & Autorizaciones.Usuario.Rows(0).Item("nombres").ToString, FontFactory.GetFont("ARIAL", 6, iTextSharp.text.Font.BOLD)))
            End If
            Dim COLUMNA2 As New ColumnText(wri.DirectContent)
            'the Phrase
            'the lower left x corner (left)
            'the lower left y corner (bottom)
            'the upper right x corner (right)
            'the upper right y corner (top)
            'line height(leading)
            'alignment.
            Dim font14Bolds As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14.0F, iTextSharp.text.Font.BOLD, BaseColor.GRAY)
            COLUMNA2.SetSimpleColumn(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("SICyF", font14Bolds)),
                                        doc.Left, doc.Bottom,
                                      doc.Right, 0,
                                        15, Element.ALIGN_RIGHT)
            COLUMNA2.Go()
            doc.Close()
            Select Case MsgBox("Archivo generado Exitosamente" & vbCrLf & "Desea abrir el archivo generado?", MsgBoxStyle.YesNoCancel, " ")
                Case MsgBoxResult.Yes
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(Controlguardado.FileName) With {
                                         .UseShellExecute = True
})
            End Select
        End If
    End Sub

    Public Sub Exportaraexceltest(ByVal DGV As DataGridView)
        If DGV.GetType.ToString.ToUpper.Contains("KRYPTON") Then
            'verificar que no sea del tipo krypton
            Exportaraexceltestkrypton(DGV)
            Exit Sub
        End If
        '  Try
        'inicialmente el sistema unicamente borraba las columnas invisibles, cambiamos el foco y ahora solo cargamos las columnas visibles
        Dim Columnasvisibles As Integer = -1
        Dim Columnasinvisibles As Integer = -1
        Dim columnasvisibles_list As New List(Of String)
        Dim columnasinvisibles_list As New List(Of String)
        Dim colores As New List(Of System.Drawing.Color)
        Dim TABLADEDATOS As New DataTable
        TABLADEDATOS = DGV.DataSource.copy
        TABLADEDATOS.PrimaryKey = Nothing
        Dim DTB = New DataTable, RWS As Integer = 0, CLS As Integer
        For CLS = 0 To DGV.ColumnCount - 1 ' COLUMNS OF DTB
            Select Case DGV.Columns(CLS).Visible
                Case True
                    columnasvisibles_list.Add(DGV.Columns(CLS).Name.ToString)
                    DTB.Columns.Add(DGV.Columns(CLS).Name.ToString)
                    Columnasvisibles += 1
                Case False
                    columnasinvisibles_list.Add(DGV.Columns(CLS).Name.ToString)
                    Columnasinvisibles += 1
            End Select
        Next
        For X = 0 To columnasinvisibles_list.Count - 1
            For z = 0 To TABLADEDATOS.Columns.Count - 1
                If TABLADEDATOS.Columns(z).ColumnName = columnasinvisibles_list(X) Then
                    Try
                        TABLADEDATOS.Columns.RemoveAt(z)
                    Catch ex As Exception
                    End Try
                    Exit For
                End If
            Next
        Next
        Dim TIPODEDATOS As Type = Nothing
        For x = 0 To TABLADEDATOS.Rows.Count - 1
            For z = 0 To TABLADEDATOS.Columns.Count - 1
                If IsDBNull(TABLADEDATOS.Rows(x).Item(z)) Then
                    Select Case TABLADEDATOS.Rows(x).Item(z).GetType.FullName.ToUpper
                        Case Is = "SYSTEM.DECIMAL"
                            TABLADEDATOS.Rows(x).Item(z) = 0
                            'DRW(DTB.Columns(x).ColumnName.ToString) = DGV.Rows(RWS).Cells.Item(columnasvisibles_list(x)).Value
                        Case Is = "SYSTEM.DATETIME"
                            TABLADEDATOS.Rows(x).Item(z) = Date.Now
                            'DRW(DTB.Columns(x).ColumnName.ToString) = CDate(DGV.Rows(RWS).Cells.Item(columnasvisibles_list(x)).Value).ToShortDateString
                        Case Is = "SYSTEM.DBNULL"
                            'TABLADEDATOS.Rows(x).Item(z) = 0
                            'DRW(DTB.Columns(x).ColumnName.ToString) = "-"
                        Case Is = "SYSTEM.STRING"
                            TABLADEDATOS.Rows(x).Item(z) = "-"
                        Case Else
                            TABLADEDATOS.Rows(x).Item(z) = "-"
                    End Select
                End If
            Next
        Next
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "ARCHIVO EXCEL xlsx|*.xlsx"
        saveFileDialog1.Title = "Guardar en archivo excel"
        saveFileDialog1.ShowDialog()
        Dim FLE As String = saveFileDialog1.FileName
        Select Case FLE = ""
            Case True
                MessageBox.Show("No se guardará el archivo debido a que: NO SELECCIONÓ RUTA DE DESTINO")
            Case False
                Try
                    Using wb As New XLWorkbook()
                        wb.Worksheets.Add(TABLADEDATOS, "Datosexportados")
                        Dim firstCell = wb.Worksheet(1).FirstCellUsed()
                        Dim lastCell = wb.Worksheet(1).LastCellUsed()
                        Dim range = wb.Worksheet(1).Range(firstCell.Address, lastCell.Address)
                        '
                        wb.Worksheet(1).Table(0).Theme = XLTableTheme.None
                        wb.Worksheet(1).Table(0).AsRange()
                        For i As Integer = 0 To TABLADEDATOS.Rows.Count - 1
                            For x = 0 To TABLADEDATOS.Columns.Count - 1
                                Select Case DGV.Columns(TABLADEDATOS.Columns.Item(x).ColumnName).Visible
                                    Case True
                                        wb.Worksheet(1).Cell(i + 2, x + 1).Style.Fill.BackgroundColor = XLColor.FromArgb(DGV.Rows(i).Cells.Item(TABLADEDATOS.Columns.Item(x).ColumnName).Style.BackColor.ToArgb)
                                        wb.Worksheet(1).Cell(i + 2, x + 1).Style.Font.FontColor = XLColor.FromArgb(DGV.Rows(i).Cells.Item(TABLADEDATOS.Columns.Item(x).ColumnName).Style.ForeColor.ToArgb)
                                        Select Case DGV.Rows(i).Cells.Item(TABLADEDATOS.Columns.Item(x).ColumnName).Value.GetType.FullName.ToUpper
                                            Case Is = "SYSTEM.DECIMAL"
                                                wb.Worksheet(1).Cell(i + 2, x + 1).Style.NumberFormat.Format = "$#,##0.00_);[Red]($#,##0.00)"
                                            Case Is = "SYSTEM.INT64"
                                                wb.Worksheet(1).Cell(i + 2, x + 1).Style.NumberFormat.Format = "#.##0;-#.##0"
                                        End Select
                                        'If DGV.Rows(i).Cells.Item(TABLADEDATOS.Columns.Item(x).ColumnName).Value.GetType.FullName.ToUpper = "SYSTEM.DECIMAL" Then
                                        'End If
                                        wb.Worksheet(1).Cell(i + 2, x + 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                                    Case False
                                End Select
                            Next
                        Next
                        'Adjust widths of Columns.
                        wb.Worksheet(1).Columns().AdjustToContents()
                        'borde ancho al cuadro exportado
                        wb.Worksheet(1).Table(0).Style.Border.OutsideBorder = XLBorderStyleValues.Thick
                        'guardar el archivo
                        wb.SaveAs(FLE)
                        Select Case MsgBox("Archivo generado Exitosamente" & vbCrLf & "Desea abrir el archivo generado?", MsgBoxStyle.YesNoCancel, "ABRIR ARCHIVO? ")
                            Case MsgBoxResult.Yes
                                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(saveFileDialog1.FileName & "") With {
                                         .UseShellExecute = True
                                                                 })
                            Case MsgBoxResult.No
                                MessageBox.Show("Se guardo el archivo en " & FLE)
                        End Select
                    End Using
                Catch ex As Exception
                    MsgBox("Se ha Producido un error " & vbNewLine & ex.Message)
                End Try
        End Select
    End Sub

    Public Sub PasteFromClipboard(ByVal sender As Object, ByVal e As KeyEventArgs)
        Dim dgv = TryCast(sender, Flicker_Datagridview)
        e.Handled = True
        If Not IsNothing(dgv) AndAlso Clipboard.ContainsText Then
            Dim columnasvisibles As New List(Of Integer)
            For x = 0 To dgv.Columns.Count - 1
                If dgv.Columns(x).Visible Then
                    columnasvisibles.Add(x)
                End If
            Next
            If dgv.SelectedCells.Count > 0 Then
                Dim rowSplitter = {ControlChars.NewLine}
                Dim columnSplitter = {ControlChars.Tab}
                Dim topLeftCell = dgv.CurrentCell
                ' CopyPasteFunctions.GetTopLeftSelectedCell(dgv.SelectedCells)
                '
                'dgv.SelectedRows(0).Cells.Item(dgv.SelectedColumns(0).Index)
                If Not IsNothing(topLeftCell) Then
                    Dim clipBoardText = Clipboard.GetText(TextDataFormat.Text)
                    Dim columnIndex = topLeftCell.ColumnIndex
                    Dim rowIndex = topLeftCell.RowIndex
                    Dim columnCount = dgv.Columns.Count
                    Dim rows = clipBoardText.Split(rowSplitter, StringSplitOptions.None)
                    For i = 0 To rows.Length - 1
                        'Split row into cell values
                        Dim values = rows(i).Split(columnSplitter)
                        Dim rowCount = dgv.Rows.Count
                        Dim corrimientoceldas As Integer = 0
                        For j = 0 To values.Length - 1
                            Try
                                If (i <= (rowCount - 1)) AndAlso ((j + 1) <= columnCount) Then
                                    Dim cell = dgv.Rows(rowIndex + i).Cells(columnasvisibles(j))
                                    dgv.CurrentCell = cell
                                    dgv.BeginEdit(False)
                                    dgv.EditingControl.Text = values(j)
                                    If Not sender.FINDFORM.Validate() Then
                                        Exit Sub
                                    Else
                                        dgv.EndEdit()
                                    End If
                                End If
                            Catch ex As Exception
                            End Try
                        Next
                    Next
                End If
            End If
        End If
    End Sub

    Public Sub Exportaraexceltestkrypton(ByRef DGV As ComponentFactory.Krypton.Toolkit.KryptonDataGridView)
        Try
            Dim columnasaborrararray As Integer = 0
            Dim columnasaborrar_list As New List(Of String)
            Dim DTB = New DataTable, RWS As Integer, CLS As Integer
            For CLS = 0 To DGV.ColumnCount - 1 ' COLUMNS OF DTB
                DTB.Columns.Add(DGV.Columns(CLS).Name.ToString)
                Select Case DGV.Columns(CLS).Visible
                    Case True
                    Case False
                        columnasaborrar_list.Add(DGV.Columns(CLS).Name.ToString)
                End Select
            Next
            Dim DRW As DataRow
            For RWS = 0 To DGV.Rows.Count - 1 ' FILL DTB WITH DATAGRIDVIEW
                DRW = DTB.NewRow
                For CLS = 0 To DGV.ColumnCount - 1
                    'Try
                    'Select Case DGV.Columns(CLS).Visible
                    '    Case True
                    Select Case DTB.Columns(CLS).ColumnName.ToString.ToUpper = "COLUMN1"
                        Case True
                            Select Case DGV.Rows(RWS).Cells.Item(CLS).GetType.ToString.ToUpper
                                Case = "SYSTEM.WINDOWS.FORMS.DATAGRIDVIEWBUTTONCELL"
                                    DRW(CLS) = ""
                                Case = "SYSTEM.WINDOWS.FORMS.DATAGRIDVIEWTEXTBOXCELL"
                                    DRW(DTB.Columns(CLS).ColumnName.ToString) = DGV.Rows(RWS).Cells.Item(DTB.Columns(CLS).ColumnName.ToString).Value.ToString
                                Case Else
                                    MessageBox.Show(DGV.Rows(RWS).Cells.Item(CLS).GetType.ToString)
                            End Select
                        Case False
                            ' DRW(DTB.Columns(CLS).ColumnName.ToString) = Convert.ToDecimal(DGV.Rows(RWS).Cells.Item(DTB.Columns(CLS).ColumnName.ToString).Value)
                            DRW(DTB.Columns(CLS).ColumnName.ToString) = DGV.Rows(RWS).Cells.Item(DTB.Columns(CLS).ColumnName.ToString).Value.ToString
                    End Select
                    'DTB.Columns.Add(DGV.Columns(CLS).Name.ToString, DGV.Columns(CLS).ValueType)
                    '   Case False
                    '  End Select
                    'Catch ex As Exception
                    'End Try
                Next
                DTB.Rows.Add(DRW)
            Next
            DTB.AcceptChanges()
            For x As Integer = 0 To columnasaborrar_list.Count - 1
                'For Z = 0 To DTB.Columns.Count - 1
                '    Select Case
                'Next
                DTB.Columns.Remove(columnasaborrar_list(x))
            Next
            Dim DST As New DataSet
            DST.Tables.Add(DTB)
            'Dim FLE As String = My.Computer.FileSystem.SpecialDirectories.Desktop ' PATH AND FILE NAME WHERE THE XML WIL BE CREATED (EXEMPLE: C:\REPS\XML.xml)
            Dim saveFileDialog1 As New SaveFileDialog()
            'saveFileDialog1.Filter = "tabla xml|*.xml"
            'saveFileDialog1.Title = "Guardar en tabla Xml"
            saveFileDialog1.Filter = "ARCHIVO EXCEL xlsx|*.xlsx"
            saveFileDialog1.Title = "Guardar en archivo excel"
            saveFileDialog1.ShowDialog()
            Dim FLE As String = saveFileDialog1.FileName
            '"c:\pruebaborrar.xml" ' PATH AND FILE NAME WHERE THE XML WIL BE CREATED (EXEMPLE: C:\REPS\XML.xml)
            Select Case FLE = ""
                Case True
                    MessageBox.Show("No se guardará el archivo debido a que: NO SELECCIONÓ RUTA DE DESTINO")
                Case False
                    Using wb As New XLWorkbook()
                        wb.Worksheets.Add(DTB, "Datosexportados")
                        wb.SaveAs(FLE)
                        Select Case MsgBox("Archivo generado Exitosamente" & vbCrLf & "Desea abrir el archivo generado?", MsgBoxStyle.YesNoCancel, " ")
                            Case MsgBoxResult.Yes
                                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(saveFileDialog1.FileName & "") With {
                                         .UseShellExecute = True
})
                        End Select
                        MessageBox.Show("Se guardo el archivo en " & FLE)
                    End Using
                    'DTB.WriteXml(FLE)
            End Select
            ' Dim EXL As String = "" ' PATH OF/ EXCEL.EXE IN YOUR MICROSOFT OFFICE
            '   Shell(Chr(34) & EXL & Chr(34) & " " & Chr(34) & FLE & Chr(34), vbNormalFocus) ' OPEN XML WITH EXCEL
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub Exportaraexcel(ByRef DGV As DataGridView)
        Try
            Dim DTB = New DataTable, RWS As Integer, CLS As Integer
            For CLS = 0 To DGV.ColumnCount - 1 ' COLUMNS OF DTB
                Select Case DGV.Columns(CLS).Visible
                    Case True
                        DTB.Columns.Add(DGV.Columns(CLS).Name.ToString)
                    Case False
                End Select
            Next
            Dim DRW As DataRow
            For RWS = 0 To DGV.Rows.Count - 1 ' FILL DTB WITH DATAGRIDVIEW
                DRW = DTB.NewRow
                For CLS = 0 To DGV.ColumnCount - 1
                    Try
                        Select Case DGV.Columns(CLS).Visible
                            Case True
                                DRW(DTB.Columns(CLS).ColumnName.ToString) = DGV.Rows(RWS).Cells.Item(DTB.Columns(CLS).ColumnName.ToString).Value.ToString
                                'DTB.Columns.Add(DGV.Columns(CLS).Name.ToString, DGV.Columns(CLS).ValueType)
                            Case False
                        End Select
                    Catch ex As Exception
                    End Try
                Next
                DTB.Rows.Add(DRW)
            Next
            DTB.AcceptChanges()
            Dim DST As New DataSet
            DST.Tables.Add(DTB)
            'Dim FLE As String = My.Computer.FileSystem.SpecialDirectories.Desktop ' PATH AND FILE NAME WHERE THE XML WIL BE CREATED (EXEMPLE: C:\REPS\XML.xml)
            Dim saveFileDialog1 As New SaveFileDialog()
            'saveFileDialog1.Filter = "tabla xml|*.xml"
            'saveFileDialog1.Title = "Guardar en tabla Xml"
            saveFileDialog1.Filter = "ARCHIVO EXCEL xlsx|*.xlsx"
            saveFileDialog1.Title = "Guardar en archivo excel"
            saveFileDialog1.ShowDialog()
            Dim FLE As String = saveFileDialog1.FileName
            '"c:\pruebaborrar.xml" ' PATH AND FILE NAME WHERE THE XML WIL BE CREATED (EXEMPLE: C:\REPS\XML.xml)
            Select Case FLE = ""
                Case True
                    MessageBox.Show("No se guardará el archivo debido a que: NO SELECCIONÓ RUTA DE DESTINO")
                Case False
                    Using wb As New XLWorkbook()
                        wb.Worksheets.Add(DTB, "Datosexportados")
                        wb.SaveAs(FLE)
                        MessageBox.Show("Se guardo el archivo en " & FLE)
                    End Using
                    'DTB.WriteXml(FLE)
            End Select
            ' Dim EXL As String = "" ' PATH OF/ EXCEL.EXE IN YOUR MICROSOFT OFFICE
            '   Shell(Chr(34) & EXL & Chr(34) & " " & Chr(34) & FLE & Chr(34), vbNormalFocus) ' OPEN XML WITH EXCEL
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub ExportaraexcelWPF(ByVal DGV As System.Windows.Controls.DataGrid)
        Dim columnasaborrar(22) As Integer
        Dim DTB = New DataTable, Rowss As Integer, Columnss As Integer
        Dim DEVOLVER As Boolean = False
        Select Case DGV.SelectionMode
            Case Windows.Controls.DataGridSelectionMode.Single
                DEVOLVER = True
                DGV.SelectionMode = Windows.Controls.DataGridSelectionMode.Extended
                DGV.SelectAllCells()
            Case Windows.Controls.DataGridSelectionMode.Extended
                DGV.SelectAllCells()
        End Select
        '   Try
        For Columnss = 0 To DGV.Columns.Count - 1 ' COLUMNS OF DTB
            DTB.Columns.Add(DGV.Columns(Columnss).Header.ToString)
            'Select Case DGV.Columns(Columnss).Visibility = Windows.Visibility.Visible
            '        Case True
            '    Case False
            '    End Select
        Next
        Dim DRW As DataRow
        For Rowss = 0 To DGV.Items.Count - 1 ' FILL DTB WITH DATAGRIDVIEW
            DRW = Nothing
            DRW = DTB.NewRow
            For Columnss = 0 To DGV.Columns.Count - 1
                Select Case IsDBNull(DGV.Items(Rowss).Item(Columnss))
                    Case True
                        DRW(Columnss) = System.Type.GetType(DGV.Items(Rowss).Item(Columnss).GetType.ToString)
                        DRW(Columnss) = ""
                    Case False
                        DRW(Columnss) = System.Type.GetType(DGV.Items(Rowss).Item(Columnss).GetType.ToString)
                        DRW(Columnss) = DGV.Items(Rowss).Item(Columnss)
                End Select
            Next
            DTB.Rows.Add(DRW)
            ' DTB.Rows.Add(DRW)
        Next
        Dim columnasBorradasContador As Integer = 0
        For Columnss = 0 To DGV.Columns.Count - 1
            Select Case DGV.Columns(Columnss).Visibility = Windows.Visibility.Visible
                Case True
                Case False
                    columnasaborrar(columnasBorradasContador) = Columnss
                    columnasBorradasContador = columnasBorradasContador + 1
            End Select
        Next
        'borra las columnas que no se encuentran visibles en el programa
        Dim x As Integer = columnasBorradasContador - 1 'el total de columnas a borrar y su posición
        While x >= 0
            Select Case columnasaborrar(x) >= 0
                Case True
                    DTB.Columns.Remove(DTB.Columns(columnasaborrar(x)))
                Case False
            End Select
            x = x - 1
        End While
        DTB.AcceptChanges()
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "ARCHIVO EXCEL xlsx|*.xlsx"
        saveFileDialog1.Title = "Guardar en archivo excel"
        saveFileDialog1.ShowDialog()
        Dim FLE As String = saveFileDialog1.FileName
        Select Case FLE = ""
            Case True
                MessageBox.Show("No se guardará el archivo debido a que: NO SELECCIONÓ RUTA DE DESTINO")
            Case False
                Using wb As New XLWorkbook()
                    wb.AddWorksheet("Datos externos")
                    wb.Worksheet("Datos externos").FirstCell.InsertTable(DTB)
                    'wb.Worksheets.Add(DTB, "Datos")
                    wb.SaveAs(saveFileDialog1.FileName)
                    MessageBox.Show("Se guardo el archivo en " & saveFileDialog1.FileName)
                End Using
        End Select
        DTB.Dispose()
        Select Case DEVOLVER
            Case True
                DGV.SelectionMode = Windows.Controls.DataGridSelectionMode.Single
            Case False
        End Select
    End Sub

End Module