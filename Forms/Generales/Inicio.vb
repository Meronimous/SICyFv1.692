Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions

Imports ClosedXML.Excel

Imports DocumentFormat.OpenXml.Packaging

Imports iTextSharp.text
Imports iTextSharp.text.pdf

'Imports DocumentFormat.OpenXml.Spreadsheet
'/**
'* La Class Inicio contiene la mayor parte de los métodos y funciones que se utilizan recursivamente en el programa
'*
'* @author (Roberto H. Romero)
'* @version (2018-01-05)
'*/
Public Class Inicio
    Dim datagridseleccionado As Object
    Dim Conexion As New Windows.Threading.DispatcherTimer()
    'Dim timerx1 As System.Threading.Timer
    'Dim timerx2 As System.Threading.Timer
    Dim errorenserver1 As Boolean = False
    Dim errorenserver2 As Boolean = False
    Dim SQLTEXT As String = ""
    Dim Tiempodetecleo As New Windows.Threading.DispatcherTimer()
    Dim activartimer As Boolean = False
    'Private Sub Tiempogeneraldetecleo(ByVal Busquedatext As TextBox, ByVal Busqueda_Datagridview As DataGridView, ByVal Message_espera As String)
    '    '  DispatcherTimer setup
    '    activartimer = True
    '    RemoveHandler Tiempodetecleogeneral.Tick, AddressOf Tiempogeneraldetecleo_Tick
    '    AddHandler Tiempodetecleogeneral.Tick, AddressOf Tiempogeneraldetecleo_Tick
    '    Tiempodetecleo.Interval = TimeSpan.FromMilliseconds(300)
    '    ' = New TimeSpan(0, 0, 1)
    '    Tiempodetecleo.Start()
    'End Sub
    'Private Sub Conexion_Tick(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim th1 As New Threading.Thread(New Threading.ThreadStart(Sub() Conexion_verificartoolstrip()))
    '    th1.Start()
    'End Sub
    '----------------------[[[[Parametros para evitar el flickering, en teoría con colocarlo acá ya es suficiente.
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 33554432
            Return cp
        End Get
    End Property

    Private Sub PreVentFlicker()
        With Me
            .SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            .SetStyle(ControlStyles.UserPaint, True)
            .SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            .UpdateStyles()
        End With
    End Sub

    '-----------------------]]]]Parametros para evitar el flickering, en teoría con colocarlo acá ya es suficiente.
    '   <STAThread()>
    Private Sub Inicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Debido a un problema con la implementación de los controles WPF se obliga al momento de abrir la aplicación a realizar un ajuste del tamaño de la ventana, maximizarla y minimizarla. :  la explicación completa aquí
        'http://errummwelluhh.blogspot.com/2015/08/display-problems-when-hosting-wpf.html
        If WindowState = FormWindowState.Maximized Then
            WindowState = FormWindowState.Normal
            WindowState = FormWindowState.Maximized
        Else
            Width += 1
            Width -= 1
        End If
        Me.KeyPreview = True
        Menusautorizados()
    End Sub

    '****************************************************************************************************************
    Public Sub Menusautorizados()
        For Z = 0 To RibbonMenu.Tabs.Count - 1
            RibbonMenu.Tabs(Z).Visible = False
            For x = 0 To RibbonMenu.Tabs(Z).Panels.Count - 1
                RibbonMenu.Tabs(Z).Panels(x).Visible = False
                For C = 0 To RibbonMenu.Tabs(Z).Panels(x).Items.Count - 1
                    RibbonMenu.Tabs(Z).Panels(x).Items(C).Visible = False
                Next
            Next
        Next
        'Dim S As String = ""
        For N As Integer = 0 To Autorizaciones.Menuautorizado.Rows.Count - 1
            For Z = 0 To RibbonMenu.Tabs.Count - 1
                'Recorrido por Tabs
                Select Case RibbonMenu.Tabs(Z).Name.ToString.ToUpper = Autorizaciones.Menuautorizado.Rows(N).Item(0).ToString.ToUpper
                    Case True
                        RibbonMenu.Tabs(Z).Visible = True
                        Exit For
                    Case False
                        'Recorrido por Panels
                        For x = 0 To RibbonMenu.Tabs(Z).Panels.Count - 1
                            Select Case RibbonMenu.Tabs(Z).Panels(x).Name.ToString.ToUpper = Autorizaciones.Menuautorizado.Rows(N).Item(0).ToString.ToUpper
                                Case True
                                    RibbonMenu.Tabs(Z).Panels(x).Visible = True
                                    Exit For
                                Case False
                                    'Recorrido por items
                                    For C = 0 To RibbonMenu.Tabs(Z).Panels(x).Items.Count - 1
                                        Select Case RibbonMenu.Tabs(Z).Panels(x).Items(C).Name.ToString.ToUpper = Autorizaciones.Menuautorizado.Rows(N).Item(0).ToString.ToUpper
                                            Case True
                                                RibbonMenu.Tabs(Z).Panels(x).Items(C).Visible = True
                                            Case False
                                        End Select
                                    Next
                            End Select
                        Next
                End Select
            Next
        Next
        For x = 0 To RibbonMenu.Tabs.Count - 1
            Select Case RibbonMenu.Tabs(x).Visible
                Case True
                    RibbonMenu.ActiveTab = (RibbonMenu.Tabs(x))
                    x = RibbonMenu.Tabs.Count
                Case False
            End Select
        Next
    End Sub

    Public Function Num2Text(ByVal value As Int64, Optional Ultimo As Boolean = False) As String
        If Not IsNothing(value) Then
            Select Case value
                Case 0 : Num2Text = "CERO"
                Case 1 : If Ultimo Then Num2Text = "UN" Else Num2Text = "UNO"
                Case 2 : Num2Text = "DOS"
                Case 3 : Num2Text = "TRES"
                Case 4 : Num2Text = "CUATRO"
                Case 5 : Num2Text = "CINCO"
                Case 6 : Num2Text = "SEIS"
                Case 7 : Num2Text = "SIETE"
                Case 8 : Num2Text = "OCHO"
                Case 9 : Num2Text = "NUEVE"
                Case 10 : Num2Text = "DIEZ"
                Case 11 : Num2Text = "ONCE"
                Case 12 : Num2Text = "DOCE"
                Case 13 : Num2Text = "TRECE"
                Case 14 : Num2Text = "CATORCE"
                Case 15 : Num2Text = "QUINCE"
                Case Is < 20 : Num2Text = "DIECI" & Num2Text(value - 10)
                Case 20 : Num2Text = "VEINTE"
                Case Is < 30 : Num2Text = "VEINTI" & Num2Text(value - 20, True)
                Case 30 : Num2Text = "TREINTA"
                Case 40 : Num2Text = "CUARENTA"
                Case 50 : Num2Text = "CINCUENTA"
                Case 60 : Num2Text = "SESENTA"
                Case 70 : Num2Text = "SETENTA"
                Case 80 : Num2Text = "OCHENTA"
                Case 90 : Num2Text = "NOVENTA"
                Case Is < 100 : Num2Text = Num2Text(Int(value \ 10) * 10) & " Y " & Num2Text(value Mod 10, True)
                Case 100 : Num2Text = "CIEN"
                Case Is < 200 : Num2Text = "CIENTO " & Num2Text(value - 100)
                Case 200, 300, 400, 600, 800 : Num2Text = Num2Text(Int(value \ 100)) & "CIENTOS"
                Case 500 : Num2Text = "QUINIENTOS"
                Case 700 : Num2Text = "SETECIENTOS"
                Case 900 : Num2Text = "NOVECIENTOS"
                Case Is < 1000 : Num2Text = Num2Text(Int(value \ 100) * 100) & " " & Num2Text(value Mod 100)
                Case 1000 : Num2Text = "MIL"
                Case Is < 2000 : Num2Text = "MIL " & Num2Text(value Mod 1000)
                Case Is < 1000000 : Num2Text = Num2Text(Int(value \ 1000)) & " MIL"
                    If value Mod 1000 Then Num2Text = Num2Text & " " & Num2Text(value Mod 1000)
                Case 1000000 : Num2Text = "UN MILLON"
                Case Is < 2000000 : Num2Text = "UN MILLON " & Num2Text(value Mod 1000000)
                Case Is < 1000000000000.0# : Num2Text = Num2Text(Int(value / 1000000)) & " MILLONES "
                    If (value - Int(value / 1000000) * 1000000) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000) * 1000000)
                Case 1000000000000.0# : Num2Text = "UN BILLON"
                Case Is < 2000000000000.0# : Num2Text = "UN BILLON " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
                Case Else : Num2Text = Num2Text(Int(value / 1000000000000.0#)) & " BILLONES"
                    If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            End Select
        End If
    End Function

    Public Function Cdecimal(ByRef numero As Object) As Decimal
        Select Case IsDBNull(numero)
            Case True
                Return 0
            Case False
                Return CType(numero, Decimal)
        End Select
    End Function

    '0-Comienzo----------------------------Subs y funciones generales de interfaz---------------------------------------
    '01----------------------Ventanas----------------------------------------------------------------------------
    ''' <summary>
    ''' Carga de los datos correspondientes a los usuarios
    ''' </summary>
    ''' <param name="usuario"> Normalmente es un DNI</param>
    ''' <param name="pwd"> </param>
    Public Sub autorizaciones_control(ByVal usuario As Double, ByVal pwd As String)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@usuario", usuario)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@pwd", ENCRIPTACION.Encriptar(pwd))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@nombrecompleto", Autorizaciones.Nombrecompletodelservicio)
        SQLPARAMETROS(Autorizaciones.userdatabase, "SELECT * FROM
(SELECT Apellidos,Nombres,usuario,Direccion,Departamento,Oficina,Funcion,Rol,nivel,UsuarioSafi,PwdSafi FROM usuarios WHERE usuario=@usuario and pwd=@pwd)A
LEFT JOIN
(SELECT N_DIRECCION,NOMBRE_DIRECCION,NOMBRE_DATABASE,CUIT,DOMICILIO,`SELLO ABREVIADO` FROM DIRECCION where NOMBRE_DIRECCION=@nombrecompleto)B
ON A.Direccion=B.N_DIRECCION", Autorizaciones.Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Recargar_autorizaciones(usuario)
    End Sub

    Public Sub Recargar_autorizaciones(ByVal usuario As Double)
        Select Case Autorizaciones.Usuario.Rows.Count > 0
            Case True
                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@usuario", usuario)
                If Autorizaciones.Usuario.Rows(0).Item("nivel").ToString = "0" Then
                    SQLPARAMETROS(Autorizaciones.userdatabase, "SELECT * FROM (SELECT Nombre_elemento as 'Menu' FROM Elemento_menu)A", Autorizaciones.Menuautorizado, System.Reflection.MethodBase.GetCurrentMethod.Name)
                Else
                    SQLPARAMETROS(Autorizaciones.userdatabase, "SELECT Menu FROM autorizaciones_menu WHERE usuario=@usuario", Autorizaciones.Menuautorizado, System.Reflection.MethodBase.GetCurrentMethod.Name)
                End If
                Autorizaciones.Nombrecompletodelservicio = Autorizaciones.Usuario.Rows(0).Item("Nombre_Direccion").ToString
            Case False
        End Select
    End Sub

    Public Sub VENTANACARGANDO(ByVal Objetocarga As Object, ByVal VENTANAPARENT As Form, ByVal Message As String)
        Objetocarga.ENABLED = False
        Dim panels As New Panel
        With panels
            .Height = 300
            .Width = 500
            .BackColor = System.Drawing.Color.FromArgb(40, System.Drawing.Color.White)
            .Location = New System.Drawing.Point(Convert.ToInt16(Objetocarga.size.width / 2), Convert.ToInt16(Objetocarga.size.height / 2))
            Dim picturebox01 As New PictureBox
            .Controls.Add(picturebox01)
            With picturebox01
                .Image = My.Resources.TRABAJANDO
                .Height = 168
                .Width = 375
                .SizeMode = PictureBoxSizeMode.Zoom
                .Location = New Point(63, 66)
            End With
            Dim labelpanel As New Label With {.Text = Message}
            .Controls.Add(labelpanel)
            With labelpanel
                .AutoSize = True
                .BackColor = System.Drawing.Color.FromArgb(120, 33, 156, 202)
                .Location = New Point(picturebox01.Location.X + picturebox01.Width + 3, picturebox01.Location.Y + 28)
                .BringToFront()
            End With
        End With
        VENTANAPARENT.Controls.Add(panels)
        panels.BringToFront()
        panels.Refresh()
        panels.Name = "Panelcarga-" & Objetocarga.name
    End Sub

    Public Sub VENTANAFINALIZAR(ByVal Objetocarga As Form, ByVal ventanaparent As Form)
        For Z = 0 To ventanaparent.Controls.Count - 1
            Select Case ventanaparent.Controls(Z).Name = "Panelcarga-" & Objetocarga.Name
                Case True
                    ventanaparent.Controls(Z).Dispose()
                    Z = ventanaparent.Controls.Count
                Case False
            End Select
        Next
        Objetocarga.Enabled = True
    End Sub

    Public Sub MENULLAMADO(ByRef WINDOWS As Form)
        If Debugging.Ventanadentro Then
            WINDOWS.MdiParent = Me
        Else
            WINDOWS.MdiParent = Nothing
        End If
        Dim tamanio As New Rectangle(Me.Size.Width, Me.Size.Height - (RibbonMenu.Height))
        Dim localizacion As New Point(0, (RibbonMenu.Height))
        OBJETOCARGANDO(WINDOWS, Me, "Cargando..." & vbCrLf & WINDOWS.Text, tamanio, localizacion)
        WINDOWS.WindowState = FormWindowState.Maximized
        WINDOWS.Show()
        OBJETOFINALIZAR(WINDOWS, Me)
    End Sub

    '01-FIN---------------------Ventanas----------------------------------------------------------------------------
    '01-Comienzo------------------------Objetos----------------------------------------------------------------------------
    Public Sub OBJETOCARGANDO(ByVal Objetocarga As Control,
                              ByVal ventana As Form,
                              ByVal Message As String, Optional anchoyalto As Rectangle = Nothing, Optional ubicacion As Point = Nothing)
        'Objetocarga.ENABLED = False
        Dim panels As New Panel
        With panels
            If IsNothing(anchoyalto) Then
                .Height = Objetocarga.Height
                .Width = Objetocarga.Width
            Else
                .Height = anchoyalto.Height
                .Width = anchoyalto.Width
            End If
            .BackColor = System.Drawing.Color.FromArgb(33, 28, 162, 220)
            '.Location = pnt
            If IsNothing(ubicacion) Then
                .Location = New Point(Objetocarga.Location.X + (Objetocarga.Size.Width / 2) - (panels.Width / 2), Objetocarga.Location.Y + (Objetocarga.Size.Height / 2) - (panels.Height / 2))
            Else
                .Location = ubicacion
            End If
            Dim picturebox01 As New PictureBox
            .Controls.Add(picturebox01)
            With picturebox01
                .Image = My.Resources.TRABAJANDO
                ' .Image = My.Resources.preloading
                .Height = 168
                .Width = 375
                .SizeMode = PictureBoxSizeMode.Zoom
                If IsNothing(ubicacion) Then
                    .Location = New Point((Objetocarga.Size.Width / 2) - (picturebox01.Width / 2), (Objetocarga.Size.Height / 2) - (picturebox01.Height / 2))
                Else
                    .Location = New Point((Objetocarga.Size.Width / 2), (Objetocarga.Size.Height / 2))
                End If
            End With
            Dim labelpanel As New Label With {.Text = Message}
            .Controls.Add(labelpanel)
            With labelpanel
                .AutoSize = True
                .BackColor = Color.Transparent
                If IsNothing(ubicacion) Then
                    .Location = New Point(picturebox01.Location.X + (picturebox01.Width / 2) + 4, (Objetocarga.Size.Height / 2) - (picturebox01.Height / 2) + 28)
                Else
                    .Location = New Point(picturebox01.Location.X + (picturebox01.Width / 2) + 4, (Objetocarga.Size.Height / 2) + (picturebox01.Height / 2) + 28)
                End If
                .BringToFront()
            End With
        End With
        Try
            ventana.Controls.Add(panels)
        Catch ex As Exception
        End Try
        panels.BringToFront()
        panels.Refresh()
        panels.Name = "Panelcarga-" & Objetocarga.Name
    End Sub

    Public Delegate Sub OBJETOCARGANDO2delegate()

    Public Sub OBJETOFINALIZAR(ByVal Objetocarga As Object, ByVal ventana As Form)
        For Z = 0 To ventana.Controls.Count - 1
            Select Case ventana.Controls(Z).Name.ToString = "Panelcarga-" & Objetocarga.name.ToString
                Case True
                    ventana.Controls(Z).Dispose()
                    Z = ventana.Controls.Count
                Case False
            End Select
        Next
        Objetocarga.ENABLED = True
    End Sub

    Public Sub Cargadetextboxautcompleteonload(ByRef Controlautocomplete As Object, ByVal Datatablesource As DataTable)
        '  Dim tablatemporal As New DataTable
        '  SQLPARAMETROS(database, Consultasql, tablatemporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Dim r As DataRow
        ' TextBox1.AutoCompleteCustomSource.Clear()
        ' select case Controlautocomplete
        '   Controlautocomplete.AutoCompleteCustomSource.Clear()
        'for each datarow in the rows of the datatable
        ' For Each r In Datatablesource.Rows
        'adding the specific row of the table in the AutoCompleteCustomSource of the textbox
        ' TextBox1.AutoCompleteCustomSource.Add(r.Item("detalle").ToString)
        ' Controlautocomplete.AutoCompleteCustomSource.Add(r.Item(0).ToString)
        ' Next
        'tablatemporal.Dispose()
    End Sub

    Public Sub Cargadetextboxautcompleteonload2(ByRef Controlautocomplete As TextBox, ByVal consultasql As String, ByVal columna As String)
        Dim tablatemporal As New DataTable
        SQLPARAMETROS(DATABASE, consultasql, tablatemporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Dim r As DataRow
        '  Controlautocomplete.AutoCompleteCustomSource.Clear()
        Controlautocomplete.AutoCompleteCustomSource.Clear()
        ' For Each datarow In the rows Of the datatable
        For Each r In tablatemporal.Rows
            '            adding the specific row of the table in the AutoCompleteCustomSource of the textbox
            Controlautocomplete.AutoCompleteCustomSource.Add(r.Item(columna).ToString)
            Controlautocomplete.AutoCompleteCustomSource.Add(r.Item(0).ToString)
        Next
        tablatemporal.Dispose()
    End Sub

    Public Sub CARGACOMBOBOX(ByRef LISTADO As ComboBox, ByVal TABLA As DataTable, ByVal VALUEMEMBER As String, ByVal DISPLAYMEMBER As String)
        Dim bindera As New BindingSource
        bindera.DataSource = TABLA
        If Not IsNothing(bindera) Then
            LISTADO.DataSource = bindera
            LISTADO.ValueMember = VALUEMEMBER
            LISTADO.DisplayMember = DISPLAYMEMBER
        End If
    End Sub

    Private Sub Cargacomboboxthread(ByRef completo As Object)
    End Sub

    Public Sub CARGACOMBOBOXWPF(ByRef LISTADO As System.Windows.Controls.ComboBox, ByVal TABLA As DataTable, ByVal VALUEMEMBER As String, ByVal DISPLAYMEMBER As String)
        Dim bindera As New BindingSource
        bindera.DataSource = TABLA.DefaultView
        LISTADO.DataContext = bindera
        LISTADO.SelectedValuePath = VALUEMEMBER
        LISTADO.DisplayMemberPath = DISPLAYMEMBER
    End Sub

    Public Sub CARGACOMBOBOXCONCONSULTA(ByRef LISTADO As ComboBox, ByVal ConsultaSql As String, ByVal VALUEMEMBER As String, ByVal DISPLAYMEMBER As String)
        Dim tabla As New DataTable
        Dim bindera As New BindingSource
        bindera.DataSource = tabla
        LISTADO.DataSource = bindera
        LISTADO.ValueMember = VALUEMEMBER
        LISTADO.DisplayMember = DISPLAYMEMBER
    End Sub

    'SUBS PARA RENDERIZAR RICHTEXTBOX
    ''' Convert the unit used by the .NET framework (1/100 inch)
    ''' and the unit used by Win32 API calls (twips 1/1440 inch)
    Private Const anInch As Double = 14.4
    Private Const WM_USER As Integer = &H400
    Private Const EM_FORMATRANGE As Integer = WM_USER + 57
    <StructLayout(LayoutKind.Sequential)>
    Private Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure
    <StructLayout(LayoutKind.Sequential)>
    Private Structure CHARRANGE
        Public cpMin As Integer
        ' primer caracter de un rango (0 for start of doc)
        Public cpMax As Integer
        ' ultimo caracter de un rango (-1 for end of doc)
    End Structure
    <StructLayout(LayoutKind.Sequential)>
    Private Structure FORMATRANGE
        Public hdc As IntPtr
        ' Actual DC to draw on
        Public hdcTarget As IntPtr
        ' Target DC for determining text formatting
        Public rc As RECT
        ' Region of the DC to draw to (in twips)
        Public rcPage As RECT
        ' Region of the whole DC (page size) (in twips)
        Public chrg As CHARRANGE
        ' Range of text to draw (see earlier declaration)
    End Structure

    Public Sub GENERARPDF(ByVal Panels As Panel, ByVal FileName As String, ByVal Directory As String)
        Dim rect As System.Drawing.Rectangle = Panels.ClientRectangle
        Dim bmp As New Bitmap(rect.Width, rect.Height)
        Panels.DrawToBitmap(bmp, rect)
        bmp.SetResolution(388.0F, 388.0F)
        Dim Message As New SaveFileDialog
        With Message
            .FileName = FileName & ".pdf"
            .RestoreDirectory = True
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        End With
        'Message.ShowDialog()
        If Message.ShowDialog() = DialogResult.OK Then
            ' myStream = Message.OpenFile()
        End If
        Dim imagenpdf As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(bmp, System.Drawing.Imaging.ImageFormat.Bmp)
        imagenpdf.SetAbsolutePosition(0, 0)
        imagenpdf.ScaleToFit(PageSize.LEGAL)
        ''//Create our file with an exclusive writer lock
        Using FS As New FileStream(Message.FileName, FileMode.Create, FileAccess.Write, FileShare.None)
            ''//Create our PDF document
            Using Doc As New Document(PageSize.LEGAL)
                ''//Bind our PDF object to the physical file using a PdfWriter
                Using Writer = PdfWriter.GetInstance(Doc, FS)
                    ''//Open our document for writing
                    Doc.Open()
                    ''//Insert a blank page
                    Doc.NewPage()
                    ''//Add an image to a document. This does not scale the image or anything so if your image is large it might go off the canvas
                    Doc.Add(imagenpdf)
                    ''//Close our document
                    Doc.Close()
                End Using
            End Using
        End Using
        Select Case MsgBox("Abrir el archivo generado?", MsgBoxStyle.YesNoCancel, " ")
            Case MsgBoxResult.Yes
                System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(Message.FileName) With {
                                         .UseShellExecute = True
})
        End Select
    End Sub

    Public Sub GenerarPdfMultiple(ByVal Panels() As Bitmap, ByVal FileName As String, ByVal Directory As String, ByVal PanelsAmount As Integer)
        'Dim rect As System.Drawing.Rectangle = Panels(0).ClientRectangle
        ' Dim imagenpdf2 As iTextSharp.text.Image
        Dim contador As Integer = 0
        'For Each panele As Panel In Panels
        '    'bmp(contador) = New Bitmap(rect.Width, rect.Height)
        '    contador = contador + 1
        'Next
        Dim Message As New SaveFileDialog
        With Message
            .FileName = FileName & ".pdf"
            .RestoreDirectory = True
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        End With
        'Message.ShowDialog()
        ''//The main folder that we are working in
        ' Dim WorkingFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        'Dim WorkingFolder As String = "C:"
        ''//The file that we are creating
        'Select Case System.IO.Directory.Exists(WorkingFolder & "\" & Date.Now.Day & "-" & Date.Now.Month & "-" & Date.Now.Year & "\" & Directory)
        '    Case True
        '    Case False
        '        System.IO.Directory.CreateDirectory(WorkingFolder & "\" & Date.Now.Day & "-" & Date.Now.Month & "-" & Date.Now.Year & "\" & Directory)
        'End Select
        '  Dim WorkingFile = Path.Combine(WorkingFolder, "\" & Date.Now.Day & "-" & Date.Now.Month & "-" & Date.Now.Year & "\" & Directory & "\" & FileName & ".pdf")
        If Message.ShowDialog() = DialogResult.OK Then
            ' myStream = Message.OpenFile()
        End If
        Dim imagenpdf As iTextSharp.text.Image = Nothing
        contador = 0
        ''//Create our file with an exclusive writer lock
        Using FS As New FileStream(Message.FileName, FileMode.Create, FileAccess.Write, FileShare.None)
            ''//Create our PDF document
            Using Doc As New Document(PageSize.LEGAL)
                ''//Bind our PDF object to the physical file using a PdfWriter
                Using Writer = PdfWriter.GetInstance(Doc, FS)
                    ''//Open our document for writing
                    Doc.Open()
                    ''//Insert a blank page
                    For X = 0 To PanelsAmount - 1
                        ' Dim bmp As New Bitmap(rect.Width, rect.Height)
                        Try
                            '   Panels(X).DrawToBitmap(bmp, rect)
                            '   bmp.SetResolution(388.0F, 388.0F)
                            'Select Case IsNothing(Panels(X))
                            '    Case True
                            '    Case False
                            'End Select
                            imagenpdf = iTextSharp.text.Image.GetInstance(Panels(X), System.Drawing.Imaging.ImageFormat.Bmp)
                        Catch ex As Exception
                        End Try
                        'bmp.Dispose()
                        imagenpdf.SetAbsolutePosition(0, 0)
                        imagenpdf.ScaleToFit(PageSize.LEGAL)
                        Doc.NewPage()
                        ''//Add an image to a document. This does not scale the image or anything so if your image is large it might go off the canvas
                        Doc.Add(imagenpdf)
                        contador += +1
                    Next
                    ''//Close our document
                    Doc.Close()
                End Using
            End Using
        End Using
    End Sub

    Public Sub GenerarPdfHorizontal(ByVal Panels As Panel, ByVal FileName As String, ByVal Directory As String)
        Dim rect As System.Drawing.Rectangle = Panels.ClientRectangle
        Dim bmp As New Bitmap(rect.Width, rect.Height)
        Panels.DrawToBitmap(bmp, rect)
        '   e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
        '   e.Graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.None
        '   e.Graphics.DrawImage(bmp, 5, 5)
        ''//The main folder that we are working in
        ' Dim WorkingFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Dim WorkingFolder As String = "C:"
        ''//The file that we are creating
        Select Case System.IO.Directory.Exists(WorkingFolder & "\" & Date.Now.Day & "-" & Date.Now.Month & "-" & Date.Now.Year & "\" & Directory)
            Case True
            Case False
                System.IO.Directory.CreateDirectory(WorkingFolder & "\" & Date.Now.Day & "-" & Date.Now.Month & "-" & Date.Now.Year & "\" & Directory)
        End Select
        Dim WorkingFile = Path.Combine(WorkingFolder, "\" & Date.Now.Day & "-" & Date.Now.Month & "-" & Date.Now.Year & "\" & Directory & "\" & FileName & ".pdf")
        Dim imagenpdf As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(bmp, System.Drawing.Imaging.ImageFormat.Bmp)
        imagenpdf.SetAbsolutePosition(0, 0)
        imagenpdf.ScaleToFit(PageSize.LEGAL.Height, PageSize.LEGAL.Width)
        Dim Message As New SaveFileDialog
        With Message
            .FileName = FileName & ".pdf"
            .RestoreDirectory = True
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        End With
        If Message.ShowDialog() = DialogResult.OK Then
            ' myStream = Message.OpenFile()
        End If
        ''//Create our file with an exclusive writer lock
        Using FS As New FileStream(Message.FileName, FileMode.Create, FileAccess.Write, FileShare.None)
            ''//Create our PDF document
            Using Doc As New Document(PageSize.LEGAL.Rotate)
                ''//Bind our PDF object to the physical file using a PdfWriter
                Using Writer = PdfWriter.GetInstance(Doc, FS)
                    ''//Open our document for writing
                    Doc.Open()
                    ''//Insert a blank page
                    Doc.NewPage()
                    ''//Add an image to a document. This does not scale the image or anything so if your image is large it might go off the canvas
                    Doc.Add(imagenpdf)
                    ''//Close our document
                    Doc.Close()
                End Using
            End Using
        End Using
    End Sub

    Public Function localizaciondecontrol(ByVal objetoanterior As Object, ByVal objetoactual As Object) As Point
        'Dim Xlocalizacion As Integer = 0
        'Dim Ylocalizacion As Integer = 0
        Xlocalizacion = objetoactual.location.x
        Ylocalizacion = objetoanterior.location.y + objetoanterior.height + 1
        Return New Point(Xlocalizacion, Ylocalizacion)
    End Function

    Public Function Tamaniodatagridview(ByVal tabladatagridview As DataGridView) As Size
        Dim tamanioheight As Integer = 2
        tabladatagridview.SendToBack()
        Select Case tabladatagridview.Rows.Count - 1
            Case = 0
                tamanioheight = tamanioheight + tabladatagridview.Rows(0).Height + 1
            Case Else
                For x = 0 To tabladatagridview.Rows.Count - 1
                    tamanioheight += tabladatagridview.Rows(x).Height
                Next
        End Select
        Select Case tabladatagridview.ColumnHeadersVisible
            Case True
                tamanioheight = tamanioheight + tabladatagridview.ColumnHeadersHeight + 2
            Case False
        End Select
        Return New Size(Tamaniodatagridview.Width, tamanioheight)
    End Function

    Public Function Tamaniopanel(ByVal Panelacambiartamanio As Panel) As Size
        Dim Tamanioheight As Integer = 1
        Dim mensageaborrar As String = Panelacambiartamanio.Name
        Dim Tamaniowidth As Integer = Panelacambiartamanio.Width
        For x = 0 To Panelacambiartamanio.Controls.Count - 1
            mensageaborrar = mensageaborrar & vbCrLf & Panelacambiartamanio.Controls(x).Name & "-" & Panelacambiartamanio.Controls(x).Height
            Tamanioheight = Tamanioheight + Panelacambiartamanio.Controls(x).Size.Height
            'Select Case x = 0
            '    Case True
            '        Tamanioheight = Panelacambiartamanio.Controls(0).Location.Y + Panelacambiartamanio.Controls(0).Size.Height
            '    Case False
            '        Tamanioheight = Tamanioheight + Panelacambiartamanio.Controls(x).Size.Height
            'End Select
        Next
        Tamanioheight = Tamanioheight + 2
        '  MessageBox.Show(mensageaborrar & vbCrLf & Tamanioheight)
        Return New Size(Tamaniowidth, Tamanioheight)
    End Function

    '01-FIN---------------------Objetos----------------------------------------------------------------------------
    '0-FIN------------------------------Subs y funciones generales de interfaz---------------------------------------
    '****************************************************************************************************************
    '****************************************************************************************************************
    '0-Comienzo-----------------------------Subs y funciones generales de conexion---------------------------------------
    Public Delegate Sub Conexion_verificartoolstripdelegate()

    Public Async Sub Conexion_verificartoolstrip()
        If InvokeRequired Then
            Invoke(New Conexion_verificartoolstripdelegate(AddressOf Conexion_verificartoolstrip))
        Else
            Serveractivotoolstrip.Text = SERVIDORMYSQL.ServerActivo
            Dim connx As MySql.Data.MySqlClient.MySqlConnection = New MySql.Data.MySqlClient.MySqlConnection()
            Try
                connx.ConnectionString = "Server=" & SERVIDORMYSQL.SERVER1 &
                              ";Port=" & SERVIDORMYSQL.PORT &
                              ";Database=" & SERVIDORMYSQL.DATABASE.ToLower &
                              ";Uid=" & SERVIDORMYSQL.USUARIO1 &
                              ";Pwd=" & SERVIDORMYSQL.PWD1 & ";AllowPublicKeyRetrieval=true;"
                Await connx.OpenAsync
                SERVIDORMYSQL.ServerActivo = SERVIDORMYSQL.SERVER1
                SERVIDORMYSQL.USUARIOactivo = SERVIDORMYSQL.USUARIO1
                SERVIDORMYSQL.PWDactivo = SERVIDORMYSQL.PWD1
                Servidor1toolstrip_label.Image = SICyF.My.Resources.checkmark
                Servidor1toolstrip_label.BackColor = System.Drawing.Color.LightGreen
            Catch ex As MySql.Data.MySqlClient.MySqlException
                errorenserver1 = True
                Servidor1toolstrip_label.BackColor = System.Drawing.Color.White
                Servidor1toolstrip_label.Image = SICyF.My.Resources.close
                Servidor1toolstrip_label.ToolTipText = ex.Message
            End Try
            Try
                connx.Close()
            Catch ex As MySql.Data.MySqlClient.MySqlException
            End Try
        End If
    End Sub

    'Public Delegate Sub Conexion_verificartoolstripdelegate2()
    'Public Async Sub Conexion_verificartoolstrip2()
    '    If InvokeRequired Then
    '        Invoke(New Conexion_verificartoolstripdelegate2(AddressOf Conexion_verificartoolstrip2))
    '    Else
    '        Dim connx As MySql.Data.MySqlClient.MySqlConnection = New MySql.Data.MySqlClient.MySqlConnection()
    '        Servidor2toolstrip_label.BackColor = system.drawing.Color.White
    '        Try
    '            connx.ConnectionString = "Server=" & SERVIDORMYSQL.SERVER2 &
    '                          ";Port=" & SERVIDORMYSQL.PORT &
    '                          ";Database=" & SERVIDORMYSQL.DATABASE.ToLower &
    '                          ";Uid=" & SERVIDORMYSQL.USUARIO2 &
    '                          ";Pwd=" & SERVIDORMYSQL.PWD2 & ";SslMode=none;"
    '            Await connx.OpenAsync
    '            Servidor2toolstrip_label.Image = SICyF.My.Resources.checkmark
    '            Select Case errorenserver1
    '                Case True
    '                    SERVIDORMYSQL.ServerActivo = SERVER2
    '                    SERVIDORMYSQL.USUARIOactivo = USUARIO2
    '                    SERVIDORMYSQL.PWDactivo = SERVIDORMYSQL.PWD2
    '                    Servidor2toolstrip_label.BackColor = system.drawing.Color.LightGreen
    '                Case False
    '            End Select
    '        Catch ex As MySql.Data.MySqlClient.MySqlException
    '            errorenserver2 = True
    '            Servidor2toolstrip_label.Image = SICyF.My.Resources.close
    '            Servidor2toolstrip_label.ToolTipText = ex.Message
    '        End Try
    '        Try
    '            Await connx.CloseAsync
    '        Catch ex As MySql.Data.MySqlClient.MySqlException
    '        End Try
    '    End If
    'End Sub
    Public Async Function Conexion_verificar(ByVal control1 As Object, ByVal control2 As Object) As Task
        Dim errorenserver1 As Boolean = False
        Dim errorenserver2 As Boolean = False
        control1.backcolor = System.Drawing.Color.FromArgb(255, 204, 198, 157)
        control2.backcolor = System.Drawing.Color.FromArgb(255, 204, 198, 157)
        control1.TEXT = "Esperando Servidor 1..."
        control2.TEXT = "Esperando Servidor 2..."
        'conexión Servidor 1  Datos básicos
        Dim conn As MySql.Data.MySqlClient.MySqlConnection = New MySql.Data.MySqlClient.MySqlConnection() With {
            .ConnectionString = "Server=" & SERVIDORMYSQL.SERVER1 &
                          ";Port=" & SERVIDORMYSQL.PORT &
                          ";Database=" & SERVIDORMYSQL.DATABASE.ToLower &
                          ";Uid=" & SERVIDORMYSQL.USUARIO1 &
                          ";Pwd=" & SERVIDORMYSQL.PWD1 & ";AllowPublicKeyRetrieval=true"}
        'conexión Servidor 2  Datos básicos
        Dim conn2 As MySql.Data.MySqlClient.MySqlConnection = New MySql.Data.MySqlClient.MySqlConnection() With {
            .ConnectionString = "Server=" & SERVIDORMYSQL.SERVER2 &
                          ";Port=" & SERVIDORMYSQL.PORT &
                          ";Database=" & SERVIDORMYSQL.DATABASE.ToLower &
                          ";Uid=" & SERVIDORMYSQL.USUARIO2 &
                          ";Pwd=" & SERVIDORMYSQL.PWD2 & ";AllowPublicKeyRetrieval=true"}
        Try
            conn.Ping()
            Await conn.OpenAsync()
            control1.backcolor = System.Drawing.Color.FromArgb(172, 200, 29)
            control1.text = "Online"
        Catch ex As MySql.Data.MySqlClient.MySqlException
            errorenserver1 = True
            control1.backcolor = System.Drawing.Color.FromArgb(187, 114, 103)
            control1.text = Errormysql(ex.Number)
            MessageBox.Show(ex.Message)
        End Try
        ' Si el servidor 1 se encuentra en la Ip o Nombre seleccionado, continua evaluando si el servidor Mysql se encuentra encendido.
        If Not errorenserver1 Then
            Try
                Await conn.CloseAsync()
            Catch ex2 As MySql.Data.MySqlClient.MySqlException
                errorenserver1 = True
                control1.backcolor = System.Drawing.Color.FromArgb(187, 114, 103)
                control1.text = Errormysql(ex2.Number)
            End Try
        End If
        Try
            conn2.Ping()
            Await conn2.OpenAsync
            control2.backcolor = System.Drawing.Color.FromArgb(172, 200, 29)
            control2.text = "Online"
        Catch ex As MySql.Data.MySqlClient.MySqlException
            errorenserver2 = True
            control2.backcolor = System.Drawing.Color.FromArgb(187, 114, 103)
            control2.text = Errormysql(ex.Number)
            control2.text = Errormysql(ex.Number)
        End Try
        ' Si el servidor 2 se encuentra en la Ip o Nombre seleccionado, continua evaluando si el servidor Mysql se encuentra encendido.
        If Not errorenserver2 Then
            Try
                Await conn2.CloseAsync()
            Catch ex As MySql.Data.MySqlClient.MySqlException
                errorenserver2 = True
                control2.backcolor = System.Drawing.Color.FromArgb(187, 114, 103)
                control2.text = Errormysql(ex.Number)
            End Try
        End If
        Select Case errorenserver1
            Case True
                If Not errorenserver2 Then
                    SERVIDORMYSQL.ServerActivo = SERVER2
                    SERVIDORMYSQL.USUARIOactivo = USUARIO2
                    SERVIDORMYSQL.PWDactivo = SERVIDORMYSQL.PWD2
                Else
                End If
            Case False
        End Select
    End Function

    ''' <summary>
    ''' Cambia el color del fondo al control cuyo nombre es invocado al color determinado por la palabra online
    ''' </summary>
    ''' <param name="NOMBRE"> Nombre del control a ser modificado</param>
    Private Sub CAMBIODECOLOR(ByVal NOMBRE As String)
        If Me.Controls.Count > 0 Then
            If Me.Controls(NOMBRE).Text.ToUpper = "ONLINE" Then
                Me.Controls(NOMBRE).BackColor = System.Drawing.Color.FromArgb(172, 200, 29)
            Else
                Me.Controls(NOMBRE).BackColor = System.Drawing.Color.FromArgb(187, 114, 103)
            End If
        End If
    End Sub

    Public Sub Conexionmysql(ByVal INSERTCOMMANDSQLORCOMMANDSQL As String)
        Dim conn As MySql.Data.MySqlClient.MySqlConnection = New MySql.Data.MySqlClient.MySqlConnection()
        Dim data As New MySql.Data.MySqlClient.MySqlDataAdapter
        conn.ConnectionString = "Server=" & SERVIDORMYSQL.ServerActivo &
                          ";Port=" & SERVIDORMYSQL.PORT &
                          ";old guids=true " &
                          ";Database=" & SERVIDORMYSQL.DATABASE.ToLower &
                          ";Uid=" & SERVIDORMYSQL.USUARIOactivo &
                          ";Pwd=" & SERVIDORMYSQL.PWDactivo & ";AllowPublicKeyRetrieval=true;"
        Select Case INSERTCOMMANDSQLORCOMMANDSQL
            Case "COMMANDSQL"
                SERVIDORMYSQL.COMMANDSQL.Connection = conn
            Case Else
                SERVIDORMYSQL.INSERTCOMMANDSQL.Connection = conn
        End Select
    End Sub

    Public Sub Ventanaescalar(ByRef ventana As Form)
        Dim DesignScreenWidth As Integer = 1920
        Dim DesignScreenHeight As Integer = 1080
        Dim CurrentScreenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim CurrentScreenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim RatioX As Double = CurrentScreenWidth / DesignScreenWidth
        Dim RatioY As Double = CurrentScreenHeight / DesignScreenHeight
        Dim I As Integer = 0
        For Each iControl In ventana.Controls
            With iControl
                If (.GetType.GetProperty("Width").CanRead) Then .Width = CInt(.Width * RatioX)
                If (.GetType.GetProperty("Height").CanRead) Then .Height = CInt(.Height * RatioY)
                If (.GetType.GetProperty("Top").CanRead) Then .Top = CInt(.Top * RatioX)
                If (.GetType.GetProperty("Left").CanRead) Then .Left = CInt(.Left * RatioY)
            End With
            For Each iControl2 In ventana.Controls(I).Controls
                With iControl2
                    If (.GetType.GetProperty("Width").CanRead) Then .Width = CInt(.Width * RatioX)
                    If (.GetType.GetProperty("Height").CanRead) Then .Height = CInt(.Height * RatioY)
                    If (.GetType.GetProperty("Top").CanRead) Then .Top = CInt(.Top * RatioX)
                    If (.GetType.GetProperty("Left").CanRead) Then .Left = CInt(.Left * RatioY)
                End With
            Next
            I = I + 1
        Next
    End Sub

    Public Sub Fondosplittercolor(ByVal split As SplitContainer)
        split.BackColor = System.Drawing.Color.Gray
        split.Panel1.BackColor = System.Drawing.Color.White
        split.Panel2.BackColor = System.Drawing.Color.White
    End Sub

    Public Sub COLUMNASDEUNATABLAACOMBOBOX(ByRef LISTADO As ComboBox, ByVal Nombredelatabla As String)
        Dim Tabla As New DataTable
        LISTADO.DataSource = Nothing
        'LISTADO.Items.Clear()
        Dim bindera As New BindingSource
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@tabla", Nombredelatabla)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@table_schema", Autorizaciones.Organismotabla)
        SQLPARAMETROS(Autorizaciones.Organismotabla, "Select column_name  as 'Columnas' FROM information_schema.columns WHERE  table_name = @tabla  AND table_schema = @table_schema", Tabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        bindera.DataSource = Tabla
        LISTADO.DataSource = bindera
        LISTADO.ValueMember = "Columnas"
        LISTADO.DisplayMember = "Columnas"
    End Sub

    Public Sub SQLPARAMETROS(ByVal database As String, ByVal CONSULTASQL As String, ByRef DATADIREsource As DataTable, ByVal PROCESO As String)
        'Creacion de un dataset temporario para lograr manejar el error de enforce constraints
        SERVIDORMYSQL.COMMANDSQL.CommandType = CommandType.Text
        Dim reloj As New Stopwatch
        reloj.Start()
        Dim DV As New DataView
        DATADIREsource = New DataTable
        Dim DATADIRE As New DataTable
        DV = New DataView(DATADIREsource)
        DATADIRE = DV.ToTable
        DATADIRE = DATADIREsource
        Dim datasettemporario As New DataSet
        datasettemporario.Tables.Add(DATADIRE)
        datasettemporario.EnforceConstraints = False
        '------------
        DATADIREsource = DATADIRE
        Dim ERRORPARAMETROS As String = ""
        Dim ERRORPARAMETROSdeclarados As String = ""
        'DATADIRE.Dispose()
        ' DATADIRE = Nothing
        ' DATADIREsource.Clear()
        'database.ToLower()
        SERVIDORMYSQL.DATABASE = database
        Me.Conexionmysql("COMMANDSQL")
        Dim datafiller As MySql.Data.MySqlClient.MySqlDataReader
        Try
            SERVIDORMYSQL.COMMANDSQL.Connection.Open()
        Catch ex As Exception
            Select Case My.Computer.Name.ToUpper
                Case Is = "MERONETBOOK"
                    MessageBox.Show(ex.Message)
                Case Is = "MEROSUPERPC"
                    MessageBox.Show(ex.Message)
            End Select
            Conexion_verificar(Servidor1toolstrip_label, Servidor2toolstrip_label)
            ToolStripgeneral.Text = ""
        End Try
        '    If SERVIDORMYSQL.COMMANDSQL.Connection.State = ConnectionState.Open Then
        Try
            SERVIDORMYSQL.COMMANDSQL.CommandType = CommandType.Text
            SERVIDORMYSQL.COMMANDSQL.CommandText = CONSULTASQL
            '2019-02-19 comando utilizado para activar el registro de los comandos sql en tiempo de ejecución, debería estar comentado y ser utilizado unicamente para debugging
            If Estadodedepuracion Then
                Debugging.VerificadorMysql(PROCESO)
            End If
            datafiller = CType(SERVIDORMYSQL.COMMANDSQL.ExecuteReader, MySql.Data.MySqlClient.MySqlDataReader)
            ' DATADIRE.Load(datafiller)
            DATADIREsource.Load(datafiller)
            '
        Catch ex As Exception
            Select Case My.Computer.Name.ToUpper
                Case Is = "MERONETBOOK"
                    Select Case MsgBox(ex.Message & vbCrLf & "¿Error desea ver la ejecución del comando SQL?", MsgBoxStyle.YesNoCancel, "")
                        Case MsgBoxResult.Yes
                            '2019-02-19 comando utilizado para activar el registro de los comandos sql en tiempo de ejecución, debería estar comentado y ser utilizado unicamente para debugging
                            Debugging.VerificadorMysql(database & "-" & PROCESO)
                            ToolStripDebug.Visible = True
                    End Select
                Case Is = "MEROSUPERPC"
                    Select Case MsgBox(ex.Message & vbCrLf & "¿Error desea ver la ejecución del comando SQL?", MsgBoxStyle.YesNoCancel, "")
                        Case MsgBoxResult.Yes
                            '2019-02-19 comando utilizado para activar el registro de los comandos sql en tiempo de ejecución, debería estar comentado y ser utilizado unicamente para debugging
                            Debugging.VerificadorMysql(database & "-" & PROCESO)
                            ToolStripDebug.Visible = True
                    End Select
                Case Else
                    MessageBox.Show(ex.Message)
            End Select
        Finally
            SERVIDORMYSQL.COMMANDSQL.Parameters.Clear()
            SERVIDORMYSQL.COMMANDSQL.Connection.Close()
        End Try
        reloj.Stop()
        '    Threading.Thread.Sleep(300)
        Select Case My.Computer.Name.ToUpper
            Case Is = "MERONETBOOK"
                ToolStripDebug.Visible = True
                ToolStripDebug.Text = $"{PROCESO}-{reloj.ElapsedMilliseconds}ms-"
            Case Is = "MEROSUPERPC"
        End Select
        GC.Collect(4)
    End Sub

    Public Sub SQLPARAMETROS_STOREDPROCEDURE(ByVal database As String, ByVal CONSULTASQL As String, ByRef DATADIREsource As DataTable, ByVal PROCESO As String)
        'Creacion de un dataset temporario para lograr manejar el error de enforce constraints
        Dim DV As New DataView
        DATADIREsource = New DataTable
        Dim ERRORPARAMETROS As String = ""
        Dim ERRORPARAMETROSdeclarados As String = ""
        SERVIDORMYSQL.DATABASE = database
        Me.Conexionmysql("COMMANDSQL")
        Dim reloj As New Stopwatch
        reloj.Start()
        Try
            SERVIDORMYSQL.COMMANDSQL.Connection.Open()
        Catch ex As Exception
            Select Case My.Computer.Name.ToUpper
                Case Is = "MERONETBOOK"
                    MessageBox.Show(ex.Message)
                Case Is = "MEROSUPERPC"
                    MessageBox.Show(ex.Message)
            End Select
            Conexion_verificar(Servidor1toolstrip_label, Servidor2toolstrip_label)
            ToolStripgeneral.Text = ""
        End Try
        '    If SERVIDORMYSQL.COMMANDSQL.Connection.State = ConnectionState.Open Then
        Try
            SERVIDORMYSQL.COMMANDSQL.CommandText = CONSULTASQL
            SERVIDORMYSQL.COMMANDSQL.CommandType = CommandType.StoredProcedure
            Dim datafiller As New MySql.Data.MySqlClient.MySqlDataAdapter(SERVIDORMYSQL.COMMANDSQL)
            '2019-02-19 comando utilizado para activar el registro de los comandos sql en tiempo de ejecución, debería estar comentado y ser utilizado unicamente para debugging
            If Estadodedepuracion Then
                Debugging.VerificadorMysql(PROCESO)
            End If
            Dim DATASETS As New DataSet()
            datafiller.Fill(DATADIREsource)
            'DATADIREsource = DATASETS.Tables(0)
            '' DATADIRE.Load(datafiller)
            'DATADIREsource.Load(CType(DATASETS, DataTable))
            '
        Catch ex As Exception
            Select Case My.Computer.Name.ToUpper
                Case Is = "MERONETBOOK"
                    Select Case MsgBox(ex.Message & vbCrLf & "¿Error desea ver la ejecución del comando SQL?", MsgBoxStyle.YesNoCancel, "")
                        Case MsgBoxResult.Yes
                            '2019-02-19 comando utilizado para activar el registro de los comandos sql en tiempo de ejecución, debería estar comentado y ser utilizado unicamente para debugging
                            Debugging.VerificadorMysql(database & "-" & PROCESO)
                            ToolStripDebug.Visible = True
                    End Select
                Case Is = "MEROSUPERPC"
                    Select Case MsgBox(ex.Message & vbCrLf & "¿Error desea ver la ejecución del comando SQL?", MsgBoxStyle.YesNoCancel, "")
                        Case MsgBoxResult.Yes
                            '2019-02-19 comando utilizado para activar el registro de los comandos sql en tiempo de ejecución, debería estar comentado y ser utilizado unicamente para debugging
                            Debugging.VerificadorMysql(database & "-" & PROCESO)
                            ToolStripDebug.Visible = True
                    End Select
                Case Else
                    MessageBox.Show(ex.Message)
            End Select
        Finally
            SERVIDORMYSQL.COMMANDSQL.Parameters.Clear()
            SERVIDORMYSQL.COMMANDSQL.Connection.Close()
        End Try
        '    Threading.Thread.Sleep(300)
        reloj.Stop()
        '    Threading.Thread.Sleep(300)
        Select Case My.Computer.Name.ToUpper
            Case Is = "MERONETBOOK"
                ToolStripDebug.Visible = True
                ToolStripDebug.Text = $"{PROCESO}-{reloj.ElapsedMilliseconds}ms-"
            Case Is = "MEROSUPERPC"
        End Select
        GC.Collect(4)
        '  Else
        '  Conexion_verificar(Servidor1toolstrip_label, Servidor2toolstrip_label)
        '  End If
    End Sub

    Public Sub SQLPARAMETROS_MULTIPLE(ByVal database As String, ByVal CONSULTASQL As String, ByRef DATADIREsource As DataTable, ByVal MantenerConexionabierta As Boolean, ByVal PROCESO As String)
        'parametros de conexión para mantener abierta la conexión una vez finalizada la consulta, dando paso a una nueva.
        'Creacion de un dataset temporario para lograr manejar el error de enforce constraints
        Dim DV As New DataView
        Dim DATADIRE As New DataTable
        DV = New DataView(DATADIREsource)
        DATADIRE = DV.ToTable
        DATADIRE = DATADIREsource
        'Dim datasettemporario As New DataSet
        'datasettemporario.Tables.Add(DATADIRE)
        'datasettemporario.EnforceConstraints = False
        '------------
        DATADIREsource = DATADIRE
        Dim ERRORPARAMETROS As String = ""
        Dim ERRORPARAMETROSdeclarados As String = ""
        DATADIRE.Dispose()
        DATADIRE = Nothing
        DATADIREsource.Clear()
        'database.ToLower()
        SERVIDORMYSQL.DATABASE = database
        Me.Conexionmysql("COMMANDSQL")
        Dim datafiller As MySql.Data.MySqlClient.MySqlDataReader
        Try
            If SERVIDORMYSQL.COMMANDSQL.Connection.State = ConnectionState.Closed Then
                SERVIDORMYSQL.COMMANDSQL.Connection.Open()
            End If
        Catch ex As Exception
            Select Case My.Computer.Name.ToUpper
                Case Is = "MERONETBOOK"
                    MessageBox.Show(ex.Message)
                Case Is = "MEROSUPERPC"
                    MessageBox.Show(ex.Message)
            End Select
            Conexion_verificar(Servidor1toolstrip_label, Servidor2toolstrip_label)
            ToolStripgeneral.Text = ""
        End Try
        '    If SERVIDORMYSQL.COMMANDSQL.Connection.State = ConnectionState.Open Then
        Try
            SERVIDORMYSQL.COMMANDSQL.CommandText = CONSULTASQL
            '2019-02-19 comando utilizado para activar el registro de los comandos sql en tiempo de ejecución, debería estar comentado y ser utilizado unicamente para debugging
            If Estadodedepuracion Then
                Debugging.VerificadorMysql(PROCESO)
            End If
            datafiller = CType(SERVIDORMYSQL.COMMANDSQL.ExecuteReader, MySql.Data.MySqlClient.MySqlDataReader)
            ' DATADIRE.Load(datafiller)
            DATADIREsource.Load(datafiller)
            '
        Catch ex As Exception
            Select Case My.Computer.Name.ToUpper
                Case Is = "MERONETBOOK"
                    Select Case MsgBox(ex.Message & vbCrLf & "¿Error desea ver la ejecución del comando SQL?", MsgBoxStyle.YesNoCancel, "")
                        Case MsgBoxResult.Yes
                            '2019-02-19 comando utilizado para activar el registro de los comandos sql en tiempo de ejecución, debería estar comentado y ser utilizado unicamente para debugging
                            Debugging.VerificadorMysql(database & "-" & PROCESO)
                            ToolStripDebug.Visible = True
                    End Select
                Case Is = "MEROSUPERPC"
                    Select Case MsgBox(ex.Message & vbCrLf & "¿Error desea ver la ejecución del comando SQL?", MsgBoxStyle.YesNoCancel, "")
                        Case MsgBoxResult.Yes
                            '2019-02-19 comando utilizado para activar el registro de los comandos sql en tiempo de ejecución, debería estar comentado y ser utilizado unicamente para debugging
                            Debugging.VerificadorMysql(database & "-" & PROCESO)
                            ToolStripDebug.Visible = True
                    End Select
                Case Else
                    MessageBox.Show(ex.Message)
            End Select
        End Try
        '    Threading.Thread.Sleep(300)
        SERVIDORMYSQL.COMMANDSQL.Parameters.Clear()
        Select Case MantenerConexionabierta
            Case True
                 '  SERVIDORMYSQL.COMMANDSQL.Connection.Close()
            Case False
                SERVIDORMYSQL.COMMANDSQL.Connection.Close()
        End Select
        GC.Collect(4)
        '  Else
        '  Conexion_verificar(Servidor1toolstrip_label, Servidor2toolstrip_label)
        '  End If
    End Sub

    Public Sub INSERTSQLPARAMETROS(ByVal database As String, ByVal PROCESO As String, Optional ByVal CommandSQL As MySql.Data.MySqlClient.MySqlCommand = Nothing)
        If IsNothing(CommandSQL) Then
            CommandSQL = SERVIDORMYSQL.INSERTCOMMANDSQL
        End If
        CommandSQL.CommandType = CommandType.Text
        Try
            Dim Errorparametros As String = CommandSQL.CommandText
            Dim Errorparametrosdeclarados As String = ""
            Dim Filasafectadas As Integer = 0
            If CommandSQL.Parameters.Contains("@usuario") Then
                'CommandSQL.Parameters.AddWithValue("@Usuario" & CInt(Math.Ceiling(Rnd() * 1500)) + 1, Autorizaciones.Usuario.Rows(0).Item("usuario"))
            Else
                CommandSQL.Parameters.AddWithValue("@Usuario", Autorizaciones.Usuario.Rows(0).Item("usuario"))
            End If
            database.ToLower()
            SERVIDORMYSQL.DATABASE = database
            Me.Conexionmysql("INSERTCOMMANDSQL")
            Try
                CommandSQL.Connection.Open()
            Catch ex As Exception
                Conexion_verificar(Servidor1toolstrip_label, Servidor2toolstrip_label)
                ToolStripgeneral.Text = ""
            End Try
            '2019-02-19 comando utilizado para activar el registro de los comandos sql en tiempo de ejecución, debería estar comentado y ser utilizado unicamente para debugging
            If Estadodedepuracion Then
                Debugging.VerificadorMysql(PROCESO)
            End If
            Filasafectadas = CommandSQL.ExecuteNonQuery
            Resultadotoolstrip_label.Text = "Filas afectadas=" & Filasafectadas
            Resultadotoolstrip_label.BackColor = System.Drawing.Color.LightGreen
        Catch ex As Exception
            Select Case My.Computer.Name.ToUpper
                Case Is = "MERONETBOOK"
                    If Not IsNothing(ex.InnerException) Then
                        Select Case MsgBox(ex.Message & vbCrLf & ex.InnerException.Message & "¿Error desea ver la ejecución del comando SQL?", MsgBoxStyle.YesNoCancel, "")
                            Case MsgBoxResult.Yes
                                '2019-02-19 comando utilizado para activar el registro de los comandos sql en tiempo de ejecución, debería estar comentado y ser utilizado unicamente para debugging
                                Debugging.VerificadorMysql(PROCESO)
                        End Select
                    Else
                        Debugging.VerificadorMysql(PROCESO)
                    End If
                Case Is = "MEROSUPERPC"
                    Select Case MsgBox(ex.Message & vbCrLf & "¿Error desea ver la ejecución del comando SQL?", MsgBoxStyle.YesNoCancel, "")
                        Case MsgBoxResult.Yes
                            '2019-02-19 comando utilizado para activar el registro de los comandos sql en tiempo de ejecución, debería estar comentado y ser utilizado unicamente para debugging
                            Debugging.VerificadorMysql(PROCESO)
                    End Select
                Case Else
                    MessageBox.Show(ex.Message)
            End Select
            CommandSQL.Parameters.Clear()
            CommandSQL.Connection.Close()
            CommandSQL.CommandText = ""
        End Try
        Try
            CommandSQL.Parameters.Clear()
            CommandSQL.Connection.Close()
            CommandSQL.CommandText = ""
        Catch ex As Exception
            'Me.ERRORES(3, "HAY UN PROBLEMA ACCEDIENDO A LA BASE DE DATOS  " & ex.Message & vbCrLf & CommandSQL.CommandText.ToString & vbCrLf & vbCrLf & Errorparametros & vbCrLf & vbCrLf & PROCESO, "", "Error de Sistema, por favor lea la información ")
        End Try
    End Sub

    Public Async Sub INSERTSQLPARAMETROSasync(ByVal database As String, ByVal PROCESO As String, Optional ByVal CommandSQL As MySql.Data.MySqlClient.MySqlCommand = Nothing)
        If IsNothing(CommandSQL) Then
            CommandSQL = SERVIDORMYSQL.INSERTCOMMANDSQL
        End If
        CommandSQL.CommandType = CommandType.Text
        Try
            Dim Errorparametros As String = CommandSQL.CommandText
            Dim Errorparametrosdeclarados As String = ""
            Dim Filasafectadas As Integer = 0
            If CommandSQL.Parameters.Contains("@usuario") Then
                'CommandSQL.Parameters.AddWithValue("@Usuario" & CInt(Math.Ceiling(Rnd() * 1500)) + 1, Autorizaciones.Usuario.Rows(0).Item("usuario"))
            Else
                CommandSQL.Parameters.AddWithValue("@Usuario", Autorizaciones.Usuario.Rows(0).Item("usuario"))
            End If
            database.ToLower()
            SERVIDORMYSQL.DATABASE = database
            Me.Conexionmysql("INSERTCOMMANDSQL")
            Try
                Await CommandSQL.Connection.OpenAsync()
            Catch ex As Exception
                Conexion_verificar(Servidor1toolstrip_label, Servidor2toolstrip_label)
                ToolStripgeneral.Text = ""
            End Try
            '2019-02-19 comando utilizado para activar el registro de los comandos sql en tiempo de ejecución, debería estar comentado y ser utilizado unicamente para debugging
            If Estadodedepuracion Then
                Debugging.VerificadorMysql(PROCESO)
            End If
            Filasafectadas = Await CommandSQL.ExecuteNonQueryAsync
            Resultadotoolstrip_label.Text = "Filas afectadas=" & Filasafectadas
            Resultadotoolstrip_label.BackColor = System.Drawing.Color.LightGreen
        Catch ex As Exception
            Select Case My.Computer.Name.ToUpper
                Case Is = "MERONETBOOK"
                    Select Case MsgBox(ex.Message & vbCrLf & "¿Error desea ver la ejecución del comando SQL?", MsgBoxStyle.YesNoCancel, "")
                        Case MsgBoxResult.Yes
                            '2019-02-19 comando utilizado para activar el registro de los comandos sql en tiempo de ejecución, debería estar comentado y ser utilizado unicamente para debugging
                            Debugging.VerificadorMysql(PROCESO)
                    End Select
                Case Is = "MEROSUPERPC"
                    Select Case MsgBox(ex.Message & vbCrLf & "¿Error desea ver la ejecución del comando SQL?", MsgBoxStyle.YesNoCancel, "")
                        Case MsgBoxResult.Yes
                            '2019-02-19 comando utilizado para activar el registro de los comandos sql en tiempo de ejecución, debería estar comentado y ser utilizado unicamente para debugging
                            Debugging.VerificadorMysql(PROCESO)
                    End Select
                Case Else
                    MessageBox.Show(ex.Message)
            End Select
            CommandSQL.Parameters.Clear()
            CommandSQL.Connection.Close()
            CommandSQL.CommandText = ""
        End Try
        Try
            CommandSQL.Parameters.Clear()
            CommandSQL.Connection.Close()
            CommandSQL.CommandText = ""
        Catch ex As Exception
            'Me.ERRORES(3, "HAY UN PROBLEMA ACCEDIENDO A LA BASE DE DATOS  " & ex.Message & vbCrLf & COMMANDSQL.CommandText.ToString & vbCrLf & vbCrLf & Errorparametros & vbCrLf & vbCrLf & PROCESO, "", "Error de Sistema, por favor lea la información ")
        End Try
    End Sub

    Public Sub INSERTSQLPROCEDIMIENTO(ByVal database As String, ByVal PROCESO As String)
        Try
            Dim Errorparametros As String = SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText
            Dim Errorparametrosdeclarados As String = ""
            Dim Filasafectadas As Integer = 0
            'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Usuario", Autorizaciones.Usuario.Rows(0).Item("usuario"))
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Usuario", Autorizaciones.Usuario.Rows(0).Item("usuario"))
            database.ToLower()
            SERVIDORMYSQL.DATABASE = database
            Me.Conexionmysql("INSERTCOMMANDSQL")
            Try
                SERVIDORMYSQL.INSERTCOMMANDSQL.Connection.Open()
            Catch ex As Exception
                Conexion_verificar(Servidor1toolstrip_label, Servidor2toolstrip_label)
                ToolStripgeneral.Text = ""
            End Try
            '2019-02-19 comando utilizado para activar el registro de los comandos sql en tiempo de ejecución, debería estar comentado y ser utilizado unicamente para debugging
            If Estadodedepuracion Then
                Debugging.VerificadorMysql(PROCESO)
            End If
            SERVIDORMYSQL.INSERTCOMMANDSQL.CommandType = CommandType.StoredProcedure
            Filasafectadas = SERVIDORMYSQL.INSERTCOMMANDSQL.ExecuteNonQuery
            Resultadotoolstrip_label.Text = "Filas afectadas=" & Filasafectadas
            Resultadotoolstrip_label.BackColor = System.Drawing.Color.LightGreen
        Catch ex As Exception
            Select Case My.Computer.Name.ToUpper
                Case Is = "MERONETBOOK"
                    Select Case MsgBox(ex.Message & vbCrLf & "¿Error desea ver la ejecución del comando SQL?", MsgBoxStyle.YesNoCancel, "")
                        Case MsgBoxResult.Yes
                            '2019-02-19 comando utilizado para activar el registro de los comandos sql en tiempo de ejecución, debería estar comentado y ser utilizado unicamente para debugging
                            Debugging.VerificadorMysql(PROCESO)
                    End Select
                Case Is = "MEROSUPERPC"
                    Select Case MsgBox(ex.Message & vbCrLf & "¿Error desea ver la ejecución del comando SQL?", MsgBoxStyle.YesNoCancel, "")
                        Case MsgBoxResult.Yes
                            '2019-02-19 comando utilizado para activar el registro de los comandos sql en tiempo de ejecución, debería estar comentado y ser utilizado unicamente para debugging
                            Debugging.VerificadorMysql(PROCESO)
                    End Select
                Case Else
                    MessageBox.Show(ex.Message)
            End Select
            SERVIDORMYSQL.INSERTCOMMANDSQL.CommandType = CommandType.Text
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Clear()
            SERVIDORMYSQL.INSERTCOMMANDSQL.Connection.Close()
            SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = ""
        End Try
        Try
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Clear()
            SERVIDORMYSQL.INSERTCOMMANDSQL.Connection.Close()
            SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = ""
        Catch ex As Exception
            'Me.ERRORES(3, "HAY UN PROBLEMA ACCEDIENDO A LA BASE DE DATOS  " & ex.Message & vbCrLf & SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText.ToString & vbCrLf & vbCrLf & Errorparametros & vbCrLf & vbCrLf & PROCESO, "", "Error de Sistema, por favor lea la información ")
        End Try
    End Sub

    Public Sub INSERTSQLPARAMETROSTesoreria(ByVal database As String, ByVal PROCESO As String)
        Try
            Dim Errorparametros As String = TESO_SERVIDORMYSQL.INSERTCOMMANDSQLx.CommandText
            Dim Errorparametrosdeclarados As String = ""
            Dim Filasafectadas As Integer = 0
            TESO_SERVIDORMYSQL.INSERTCOMMANDSQLx.Parameters.AddWithValue("@Usuario", Autorizaciones.Usuario.Rows(0).Item("usuario"))
            database.ToLower()
            TESO_SERVIDORMYSQL.DATABASEx = database
            Dim conn As MySql.Data.MySqlClient.MySqlConnection = New MySql.Data.MySqlClient.MySqlConnection()
            Dim data As New MySql.Data.MySqlClient.MySqlDataAdapter
            conn.ConnectionString = "Server=" & TESO_SERVIDORMYSQL.ServerActivox &
                          ";Port=" & TESO_SERVIDORMYSQL.PORTx &
                          ";old guids=true " &
                          ";Database=" & TESO_SERVIDORMYSQL.DATABASEx.ToLower &
                          ";Uid=" & TESO_SERVIDORMYSQL.USUARIOactivox &
                          ";Pwd=" & TESO_SERVIDORMYSQL.PWDactivox & ";AllowPublicKeyRetrieval=true;"
            TESO_SERVIDORMYSQL.INSERTCOMMANDSQLx.Connection = conn
            Try
                TESO_SERVIDORMYSQL.INSERTCOMMANDSQLx.Connection.Open()
            Catch ex As Exception
                Conexion_verificar(Servidor1toolstrip_label, Servidor2toolstrip_label)
                ToolStripgeneral.Text = ""
            End Try
            '2019-02-19 comando utilizado para activar el registro de los comandos sql en tiempo de ejecución, debería estar comentado y ser utilizado unicamente para debugging
            If Estadodedepuracion Then
                Debugging.VerificadorMysql(PROCESO)
            End If
            Filasafectadas = TESO_SERVIDORMYSQL.INSERTCOMMANDSQLx.ExecuteNonQuery
            Resultadotoolstrip_label.Text = "Filas afectadas=" & Filasafectadas
            Resultadotoolstrip_label.BackColor = System.Drawing.Color.LightGreen
        Catch ex As Exception
            Select Case My.Computer.Name.ToUpper
                Case Is = "MERONETBOOK"
                    Select Case MsgBox(ex.Message & vbCrLf & "¿Error desea ver la ejecución del comando SQL?", MsgBoxStyle.YesNoCancel, "")
                        Case MsgBoxResult.Yes
                            '2019-02-19 comando utilizado para activar el registro de los comandos sql en tiempo de ejecución, debería estar comentado y ser utilizado unicamente para debugging
                            Debugging.VerificadorMysql(PROCESO)
                    End Select
                Case Is = "MEROSUPERPC"
                    Select Case MsgBox(ex.Message & vbCrLf & "¿Error desea ver la ejecución del comando SQL?", MsgBoxStyle.YesNoCancel, "")
                        Case MsgBoxResult.Yes
                            '2019-02-19 comando utilizado para activar el registro de los comandos sql en tiempo de ejecución, debería estar comentado y ser utilizado unicamente para debugging
                            Debugging.VerificadorMysql(PROCESO)
                    End Select
                Case Else
                    MessageBox.Show(ex.Message)
            End Select
            TESO_SERVIDORMYSQL.INSERTCOMMANDSQLx.Parameters.Clear()
            TESO_SERVIDORMYSQL.INSERTCOMMANDSQLx.Connection.Close()
            TESO_SERVIDORMYSQL.INSERTCOMMANDSQLx.CommandText = ""
        End Try
        Try
            TESO_SERVIDORMYSQL.INSERTCOMMANDSQLx.Parameters.Clear()
            TESO_SERVIDORMYSQL.INSERTCOMMANDSQLx.Connection.Close()
            TESO_SERVIDORMYSQL.INSERTCOMMANDSQLx.CommandText = ""
        Catch ex As Exception
            'Me.ERRORES(3, "HAY UN PROBLEMA ACCEDIENDO A LA BASE DE DATOS  " & ex.Message & vbCrLf & SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText.ToString & vbCrLf & vbCrLf & Errorparametros & vbCrLf & vbCrLf & PROCESO, "", "Error de Sistema, por favor lea la información ")
        End Try
    End Sub

    Public Sub SQLPARAMETROSgrafico(ByVal database As String, ByVal CONSULTASQL As String, ByVal Grafico As System.Windows.Forms.DataVisualization.Charting.Chart, ByVal tipodegrafico As DataVisualization.Charting.SeriesChartType, ByVal Titulodelgrafico As String, ByVal Ejex As String, ByVal EjeY As String, ByVal PROCESO As String)
        If Not IsNothing(database) Then
            Grafico.Series.Clear() 'borra las series
            Grafico.ChartAreas.Clear()        'Borra el area para permitir la ampliación o reducción de la escala.
            Grafico.ChartAreas.Add("nuevo") 'agrega nueva area de dibujo
            Grafico.Series.Add(Titulodelgrafico).ChartType = tipodegrafico
            Grafico.Series(Titulodelgrafico).Palette = DataVisualization.Charting.ChartColorPalette.BrightPastel
            Grafico.Series(0).LabelFormat = "C2"
            Grafico.Series(0).IsValueShownAsLabel = True
            Grafico.ChartAreas(0).Area3DStyle.Enable3D = True
            Dim ERRORPARAMETROS As String = ""
            Dim ERRORPARAMETROSdeclarados As String = ""
            SERVIDORMYSQL.DATABASE = database.ToString.ToLower
            Me.Conexionmysql("COMMANDSQL")
            Dim datafiller As MySql.Data.MySqlClient.MySqlDataReader
            Try
                ' MessageBox.Show(SERVIDORMYSQL.COMMANDSQL.Connection.ConnectionString)
                SERVIDORMYSQL.COMMANDSQL.Connection.Open()
                Try
                    Select Case My.Computer.Name.ToUpper
                        Case Is = "MERONETBOOK"
                            'For Each Parametro As M
                            For z = 0 To SERVIDORMYSQL.COMMANDSQL.Parameters.Count - 1
                                ERRORPARAMETROS = ERRORPARAMETROS & vbCrLf & SERVIDORMYSQL.COMMANDSQL.Parameters(z).ParameterName.ToString & " =" & SERVIDORMYSQL.COMMANDSQL.Parameters(z).Value.ToString
                            Next
                            'MessageBox.Show("HAY UN PROBLEMA ACCEDIENDO A LA BASE DE DATOS  " & ex.Message & vbCrLf & SERVIDORMYSQL.COMMANDSQL.CommandText.ToString & vbCrLf & vbCrLf & ERRORPARAMETROS & vbCrLf & vbCrLf & PROCESO)
                            'ME.ERRORES("HAY UN PROBLEMA ACCEDIENDO A LA BASE DE DATOS  " & ex.Message & vbCrLf & SERVIDORMYSQL.COMMANDSQL.CommandText.ToString & vbCrLf & vbCrLf & ERRORPARAMETROS & vbCrLf & vbCrLf & PROCESO)
                            '    ERRORES(3, "HAY UN PROBLEMA ACCEDIENDO A LA BASE DE DATOS  " & ex.Message & vbCrLf & vbCrLf & vbCrLf & ERRORPARAMETROS & vbCrLf & vbCrLf & PROCESO, "", "Error de Sistema, por favor lea la información ")
                        Case Else
                            'ME.ERRORES("SE HA PRODUCIDO UN ERROR EN " & PROCESO)
                            '      ERRORES(1, "SE HA PRODUCIDO UN ERROR EN " & PROCESO, "", "Error de Sistema, por favor lea la información ")
                    End Select
                    SERVIDORMYSQL.COMMANDSQL.CommandText = CONSULTASQL
                    datafiller = SERVIDORMYSQL.COMMANDSQL.ExecuteReader
                    While datafiller.Read
                        Grafico.Series(Titulodelgrafico).Points.AddXY(datafiller.GetString(Ejex), datafiller.GetDecimal(EjeY))
                    End While
                    '   My.Computer.Clipboard.SetText(CONSULTASQL)
                    '  MessageBox.Show(CONSULTASQL)
                    'La datatable debe ser removida del dataset para que en caso de una nueva consulta poder utilizar la misma.
                Catch ex As Exception
                    Select Case My.Computer.Name.ToUpper
                        Case Is = "MERONETBOOK"
                            'For Each Parametro As M
                            For z = 0 To SERVIDORMYSQL.COMMANDSQL.Parameters.Count - 1
                                ERRORPARAMETROS = ERRORPARAMETROS & vbCrLf & SERVIDORMYSQL.COMMANDSQL.Parameters(z).ParameterName.ToString & " =" & SERVIDORMYSQL.COMMANDSQL.Parameters(z).Value.ToString
                            Next
                            MessageBox.Show("HAY UN PROBLEMA ACCEDIENDO A LA BASE DE DATOS  " & ex.Message & vbCrLf & SERVIDORMYSQL.COMMANDSQL.CommandText.ToString & vbCrLf & vbCrLf & ERRORPARAMETROS & vbCrLf & vbCrLf & PROCESO)
                            'ME.ERRORES("HAY UN PROBLEMA ACCEDIENDO A LA BASE DE DATOS  " & ex.Message & vbCrLf & SERVIDORMYSQL.COMMANDSQL.CommandText.ToString & vbCrLf & vbCrLf & ERRORPARAMETROS & vbCrLf & vbCrLf & PROCESO)
                            '    ERRORES(3, "HAY UN PROBLEMA ACCEDIENDO A LA BASE DE DATOS  " & ex.Message & vbCrLf & vbCrLf & vbCrLf & ERRORPARAMETROS & vbCrLf & vbCrLf & PROCESO, "", "Error de Sistema, por favor lea la información ")
                        Case Else
                            'ME.ERRORES("SE HA PRODUCIDO UN ERROR EN " & PROCESO)
                            '      ERRORES(1, "SE HA PRODUCIDO UN ERROR EN " & PROCESO, "", "Error de Sistema, por favor lea la información ")
                    End Select
                End Try
                SERVIDORMYSQL.COMMANDSQL.Parameters.Clear()
                SERVIDORMYSQL.COMMANDSQL.Connection.Close()
            Catch ex As Exception
                Select Case My.Computer.Name.ToString.ToUpper
                    Case Is = "MERONETBOOK"
                        ERRORPARAMETROSdeclarados = " SET "
                        ' Me.ERRORES(3, "HAY UN PROBLEMA AL INTENTAR CONECTAR A LA BASE DE DATOS  " & ex.Message & vbCrLf & SERVIDORMYSQL.COMMANDSQL.CommandText.ToString & vbCrLf & vbCrLf & ERRORPARAMETROS & vbCrLf & vbCrLf & PROCESO, vbCrLf & " ERROR EN " & vbCrLf & Reflection.MethodBase.GetCurrentMethod().Name, "Error de conexión al Sistema, por favor lea la información ")
                    Case Else
                        For z = 0 To SERVIDORMYSQL.COMMANDSQL.Parameters.Count - 1
                            ERRORPARAMETROSdeclarados = ERRORPARAMETROSdeclarados & vbCrLf & SERVIDORMYSQL.COMMANDSQL.Parameters(z).ParameterName.ToString & " =" & SERVIDORMYSQL.COMMANDSQL.Parameters(z).Value.ToString
                        Next
                        '   Me.ERRORES(3, "HAY UN PROBLEMA AL INTENTAR CONECTAR A LA BASE DE DATOS  " & ex.Message & vbCrLf & SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText.ToString & vbCrLf & vbCrLf & ERRORPARAMETROS, vbCrLf & PROCESO, "Error de Sistema, por favor lea la información ")
                End Select
            End Try
        End If
    End Sub

    Public Function InsertSQLFunction(ByVal database As String, ByVal PROCESO As String, Optional ByVal CommandSQL As MySql.Data.MySqlClient.MySqlCommand = Nothing) As Integer
        If IsNothing(CommandSQL) Then
            CommandSQL = SERVIDORMYSQL.INSERTCOMMANDSQL
        End If
        CommandSQL.CommandType = CommandType.Text
        Dim Errorparametros As String = CommandSQL.CommandText
        Dim Errorparametrosdeclarados As String = ""
        Dim Filasafectadas As Integer = 0
        database.ToLower()
        SERVIDORMYSQL.DATABASE = database
        Me.Conexionmysql("INSERTCOMMANDSQL")
        Try
            If Estadodedepuracion Then
                Debugging.VerificadorMysql(PROCESO)
            End If
            CommandSQL.Connection.Open()
            Filasafectadas = CommandSQL.ExecuteNonQuery()
            Resultadotoolstrip_label.Text = "Filas afectadas=" & Filasafectadas
            Resultadotoolstrip_label.BackColor = System.Drawing.Color.LightGreen
            CommandSQL.Parameters.Clear()
            CommandSQL.Connection.Close()
            CommandSQL.CommandText = ""
            Return Filasafectadas
        Catch ex As Exception
            Select Case My.Computer.Name.ToString.ToUpper
                Case Is = "MERONETBOOK"
                    Errorparametrosdeclarados = Errorparametrosdeclarados & ";"
                    Resultadotoolstrip_label.Text = "error al ejecutar " & ex.Message
                    Resultadotoolstrip_label.BackColor = System.Drawing.Color.LightCoral
                Case Is = "MEROSUPERPC"
                    Errorparametrosdeclarados = Errorparametrosdeclarados & ";"
                    Resultadotoolstrip_label.Text = "error al ejecutar " & ex.Message
                    Resultadotoolstrip_label.BackColor = System.Drawing.Color.LightCoral
                Case Else
                    Resultadotoolstrip_label.Text = "Error verificar " & ex.Message
                    Resultadotoolstrip_label.BackColor = System.Drawing.Color.LightCoral
            End Select
            CommandSQL.Parameters.Clear()
            Try
                CommandSQL.Connection.Close()
                CommandSQL.CommandText = ""
            Catch ex2 As Exception
            End Try
        End Try
        Return Filasafectadas
    End Function

    Public Sub DELETESQLPARAMETROS(ByVal database As String, ByVal PROCESO As String, ByVal UNDO As String)
        Dim Comandoaguardar As String = SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText
        Dim Errorparametrosdeclarados As String = ""
        database.ToLower()
        SERVIDORMYSQL.DATABASE = database
        Me.Conexionmysql("INSERTCOMMANDSQL")
        Try
            For x = 0 To SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Count - 1
                Errorparametrosdeclarados = " SET "
                Errorparametrosdeclarados = Errorparametrosdeclarados & vbCrLf & SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters(x).ParameterName.ToString & " =" & SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters(x).Value.ToString
                If x = 0 Then
                    Errorparametrosdeclarados = Errorparametrosdeclarados & "  " & SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters(x).ParameterName.ToString & " ='" & SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters(x).Value.ToString & "'"
                Else
                    Errorparametrosdeclarados = Errorparametrosdeclarados & ",  " & SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters(x).ParameterName.ToString & " ='" & SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters(x).Value.ToString & "'"
                End If
            Next
            SERVIDORMYSQL.INSERTCOMMANDSQL.Connection.Open()
            SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = UNDO
            SERVIDORMYSQL.INSERTCOMMANDSQL.ExecuteNonQuery()
            SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = Comandoaguardar
            SERVIDORMYSQL.INSERTCOMMANDSQL.ExecuteNonQuery()
        Catch ex As Exception
            Try
                SERVIDORMYSQL.INSERTCOMMANDSQL.Connection.Open()
                SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = UNDO
                SERVIDORMYSQL.INSERTCOMMANDSQL.ExecuteNonQuery()
                SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = Comandoaguardar
                SERVIDORMYSQL.INSERTCOMMANDSQL.ExecuteNonQuery()
            Catch ex2 As Exception
                MessageBox.Show(ex2.Message)
            End Try
            Select Case My.Computer.Name.ToString.ToUpper
                Case Is = "MERONETBOOK"
                    Errorparametrosdeclarados = Errorparametrosdeclarados & ";"
                Case Is = "MEROSUPERPC"
                    Errorparametrosdeclarados = Errorparametrosdeclarados & ";"
                Case Else
            End Select
        End Try
        Try
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Clear()
            SERVIDORMYSQL.INSERTCOMMANDSQL.Connection.Close()
            SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = ""
        Catch ex As Exception
            ' Me.ERRORES(3, "HAY UN PROBLEMA ACCEDIENDO A LA BASE DE DATOS  " & ex.Message & vbCrLf & SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText.ToString & vbCrLf & vbCrLf & Errorparametros & vbCrLf & vbCrLf & PROCESO, "", "Error de Sistema, por favor lea la información ")
        End Try
    End Sub

    'Public Shared Async Function Sqlconexionasync(conexion As System.Windows.Shapes.Ellipse, ByVal Server As String, ByVal Port As Integer, ByVal Usuario As String, ByVal Databasemysql As String, ByVal Pwd As String) As Task(Of System.Windows.Shapes.Ellipse)
    '    Dim conn As MySql.Data.MySqlClient.MySqlConnection = New MySql.Data.MySqlClient.MySqlConnection()
    '    conn.ConnectionString = "Server=" & Server &
    '                      ";Port=" & Port &
    '                      ";Database=" & Databasemysql &
    '                      ";Uid=" & Usuario &
    '                      ";Pwd=" & Pwd & ";SslMode=none"
    '    'SERVIDORSQLSERVER.DATABASESQL = DATABASE
    '    Try
    '        Await conn.OpenAsync
    '        conexion.Fill = New System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Green)
    '    Catch ex As Exception
    '        conexion.Fill = New System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red)
    '        conexion.ToolTip = ex.Message
    '        ' MessageBox.Show(ex.Message & vbCrLf & SERVIDORSQLSERVER.SERVER)
    '    End Try
    '    Try
    '        conn.Close()
    '    Catch ex As Exception
    '    End Try
    '    Return conexion
    'End Function
    '0-FIN------------------------------Subs y funciones generales de conexion---------------------------------------
    '****************************************************************************************************************
    '****************************************************************************************************************
    '0-Comienzo------------------------------Subs y funciones generales de conversion---------------------------------------
    Public Sub RenderToBitmap(textBox As RichTextBox, bitmap As Bitmap)
        ' determinar el area completa a renderizar a bitmap
        Dim rect As RECT = Nothing
        Dim g As Graphics = Nothing
        Dim hdc As IntPtr = g.GetHdc()
        Dim fmtRange As FORMATRANGE
        rect.Left = 0
        rect.Top = 0
        bitmap.SetResolution(144.0F, 144.0F)
        rect.Right = CInt(bitmap.Width * anInch)
        rect.Bottom = CInt(bitmap.Height * anInch)
        g = Graphics.FromImage(bitmap)
        Try
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        Catch ex As Exception
        End Try
        Try
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        Catch ex As Exception
        End Try
        fmtRange.chrg.cpMin = textBox.GetCharIndexFromPosition(New Point(0, 0))
        fmtRange.chrg.cpMax = textBox.GetCharIndexFromPosition(New Point(bitmap.Width, bitmap.Height))
        fmtRange.hdc = hdc
        ' Use the same DC for measuring and rendering
        fmtRange.hdcTarget = hdc
        fmtRange.rc = rect
        fmtRange.rcPage = rect
        Dim lparam As IntPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(fmtRange))
        Marshal.StructureToPtr(fmtRange, lparam, False)
        'Renderizar el control al Bitmap
        SendMessage(textBox.Handle, EM_FORMATRANGE, New IntPtr(1), lparam)
        ' Limpieza posterior
        Marshal.FreeCoTaskMem(lparam)
        g.ReleaseHdc(hdc)
    End Sub

    <DllImport("USER32.dll")>
    Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer, wp As IntPtr, lp As IntPtr) As IntPtr
    End Function

    'public sub MOUSE DERECHO, sujeto a mejoras
    Public Sub MOUSEDERECHO(ByRef CONTROL As System.Object, ByRef MOUSE As System.Windows.Forms.MouseEventArgs, ByRef datagridgestor As Object)
        datagridseleccionado = Nothing
        If MOUSE.Button <> Windows.Forms.MouseButtons.Right Then Return
        datagridseleccionado = datagridgestor
        Dim tagss As New List(Of Object)
        Dim cms = New ContextMenuStrip
        'tagss.Add(cms.Items.Add("Copiar"))
        'tagss.Item(tagss.Count - 1).tag = 0
        Dim item1 = cms.Items.Add("Copiar")
        item1.Tag = 0
        ' AddHandler item2.Click, AddressOf MENUCONTEXTUAL
        AddHandler item1.Click, AddressOf MENUCONTEXTUAL
        Dim item2 = cms.Items.Add("Exportar toda la tablar a Excel")
        item2.Tag = 1
        AddHandler item2.Click, AddressOf MENUCONTEXTUAL
        Dim item3 = cms.Items.Add("Guardar Tabla Reporte PDF (hoja horizontal)")
        item3.Tag = 2
        AddHandler item3.Click, AddressOf MENUCONTEXTUAL
        Dim item4 = cms.Items.Add("Guardar Tabla Reporte PDF (hoja vertical)")
        item4.Tag = 3
        AddHandler item4.Click, AddressOf MENUCONTEXTUAL
        If CType(datagridseleccionado, DataGridView).Columns.Contains("clave_expediente_detalle") Then
            Dim item5 = cms.Items.Add("Ver Movimientos del Expediente")
            item5.Tag = 4
            AddHandler item5.Click, AddressOf MENUCONTEXTUAL
        End If
        'Dim item3 = cms.Items.Add("VERIFICAR ADICIONALES")
        'item3.Tag = 2
        'AddHandler item3.Click, AddressOf MENUCONTEXTUAL
        'If (My.Computer.Name.ToUpper = "MERONETBOOK") Or (My.Computer.Name.ToUpper = "MEROSUPERPC") Then
        '    Dim item10 = cms.Items.Add("PDF EXPERIMENTAL")
        '    item10.Tag = 10
        '    AddHandler item10.Click, AddressOf MENUCONTEXTUAL
        'End If
        '-- etc
        '..
        cms.Show(CONTROL, MOUSE.Location)
    End Sub

    Public Sub MENUCONTEXTUAL(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)
        Select Case selection
            Case Is = 0
                Clipboard.SetDataObject(datagridseleccionado.GetClipboardContent())
                Dim objData As DataObject = datagridseleccionado.GetClipboardContent
                If objData IsNot Nothing Then
                    Clipboard.SetDataObject(objData)
                End If
            Case Is = 1
                Exportaraexceltest(datagridseleccionado)
                'Select Case datagridseleccionado.GetType.ToString.ToUpper
                '    Case Is = "SYSTEM.WINDOWS.FORMS.DATAGRIDVIEW"
                '        Exportaraexceltest(datagridseleccionado)
                '    Case Is = "SICYF.FLICKER_DATAGRIDVIEW"
                '        Exportaraexceltest(datagridseleccionado)
                '    Case Is = "COMPONENTFACTORY.KRYPTON.TOOLKIT.KRYPTONDATAGRIDVIEW"
                '        Exportaraexceltestkrypton(datagridseleccionado)
                '    Case Else
                '        MessageBox.Show(datagridseleccionado.GetType.ToString)
                'End Select
                'MessageBox.Show(datagridseleccionado.GetType.ToString)
                'Select Case
                '    Case Is = "Datagridview"
                '        Exportaraexceltest(datagridseleccionado)
                'End Select
            Case Is = 2
                'Reportesgenerales.ExportDataToPDFTable2(datagridseleccionado, "Reporte Rapido")
                'Reportesgenerales.PDFDatagridview(CType(datagridseleccionado, DataGridView), "Reporte Rapido")
                PDFDatagridview(CType(datagridseleccionado, DataGridView), "Reporte Rapido", True, "LEGAL")
                'PDFDatagridview()
            Case Is = 3
                'Reportesgenerales.PDFDatagridviewvertical(CType(datagridseleccionado, DataGridView), "Reporte Rapido")
                PDFDatagridview(CType(datagridseleccionado, DataGridView), "Reporte Rapido", False, "LEGAL")
            Case Is = 4
                'Reportesgenerales.PDFDatagridviewvertical(CType(datagridseleccionado, DataGridView), "Reporte Rapido")
                Dialogo_datos.mostrardatatable(Movimiento.Tablatotalesporclave_expedientedetalle(CType(datagridseleccionado, DataGridView).SelectedRows(0).Cells.Item("clave_expediente_detalle").Value))
            Case Is = 10
                'EXPERIMENTAL DEBE SER CORREGIDO
                'PDFPEDIDODEFONDO(CType(datagridseleccionado, DataGridView), "Reporte Rapido", False, "LEGAL")
        End Select
        '-- etc
    End Sub

    '/public sub MOUSE DERECHO
    Public Function GenerateHash(ByVal SourceText As String) As String
        'Create an encoding object to ensure the encoding standard for the source text
        Dim Ue As New UnicodeEncoding()
        'Retrieve a byte array based on the source text
        Dim ByteSourceText() As Byte = Ue.GetBytes(SourceText)
        'Instantiate an MD5 Provider object
        Dim Md5 As New MD5CryptoServiceProvider()
        'Compute the hash value from the source
        Dim ByteHash() As Byte = Md5.ComputeHash(ByteSourceText)
        'And convert it to String format for return
        Return Convert.ToBase64String(ByteHash)
    End Function

    '01++++++++++++++++++++++++++++++++++++++++++++experimental+++++++++++++++++++++++++++++++++++++++++++++
    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Public Function Numerodecuentanormalizar(ByVal stringanormalizar As String) As String
        Dim Numerodecuenta As String = ""
        For x = 0 To stringanormalizar.Length - 1
            If x = 0 Then
                Numerodecuenta = stringanormalizar.Chars(x).ToString
            ElseIf (x = 1 Or x = 4 Or x = 14) Then
                Numerodecuenta = Numerodecuenta & "-" & stringanormalizar.Chars(x).ToString
            Else
                Numerodecuenta = Numerodecuenta & stringanormalizar.Chars(x).ToString
            End If
        Next
        Return Numerodecuenta
    End Function

    Public Sub Abrirarchivoexcel(ByRef excel_datagridview As DataGridView, ByRef primerafila As Integer, ByRef primeracolumna As Integer)
        Using dialog As New OpenFileDialog()
            dialog.Filter = "Excel files |*.xlsx"
            dialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            dialog.Title = "Seleccione el archivo de movimientos de banco, recuerde que tiene que ser una versión posterior a MS Excel 2003"
            If dialog.ShowDialog() = DialogResult.OK Then
                'Create a new DataTable.
                Dim dt As New DataTable()
                Dim splitnumerodecuenta As String()
                Dim Numerodecuenta As String = ""
                Using workBook As New XLWorkbook((dialog.FileName))
                    'Read the first Sheet from Excel file.
                    Dim workSheet As IXLWorksheet = workBook.Worksheet(1)
                    'Loop through the Worksheet rows.
                    Dim firstRow As Boolean = True
                    splitnumerodecuenta = Split(workSheet.Rows(primerafila - 1).Cells(0).Value.ToString, "Número de cuenta ")
                    Numerodecuenta = Numerodecuentanormalizar(splitnumerodecuenta(1))
                    For x = primerafila To workSheet.LastRowUsed.RowNumber
                        If x = primerafila Then
                            For z = primeracolumna - 1 To workSheet.LastColumnUsed().ColumnNumber - 1
                                dt.Columns.Add(workSheet.Rows(x).Cells(z).Value.ToString)
                            Next
                            'agrego el indice md5
                            dt.Columns.Add("INDICEMD5")
                        Else
                            'Add rows to DataTable.
                            dt.Rows.Add()
                            Dim i As Integer = 0
                            For z = workSheet.FirstColumnUsed.ColumnNumber - 1 To workSheet.LastColumnUsed().ColumnNumber - 1
                                dt.Rows(dt.Rows.Count - 1).Item(i) = workSheet.Rows(x).Cells(z).Value
                                i = i + 1
                            Next
                            'FECHA, NOMBRE, TRANSFERENCIA Y VALOR
                            For N = 0 To 4
                                dt.Rows(dt.Rows.Count - 1).Item(i) = dt.Rows(dt.Rows.Count - 1).Item(i).ToString & dt.Rows(dt.Rows.Count - 1).Item(N).ToString
                            Next
                            Select Case dt.Rows(dt.Rows.Count - 1).Item(i).ToString.Length > 0
                                Case True
                                    dt.Rows(dt.Rows.Count - 1).Item(i) = GenerateHash(dt.Rows(dt.Rows.Count - 1).Item(i).ToString)
                                Case False
                                    dt.Rows(dt.Rows.Count - 1).Item(i) = ""
                            End Select
                        End If
                    Next
                End Using
                Insertarareportebanco(dt, Numerodecuenta)
                MessageBox.Show(dt.Rows.Count - 1)
                dt.Dispose()
            End If
        End Using
    End Sub

    Public Sub Abrirarchivoexcel2(ByRef excel_datagridview As DataGridView, ByVal primerafila As Integer, ByVal primeracolumna As Integer, ByVal numerodecuenta As String)
        Using dialog As New OpenFileDialog()
            dialog.Filter = "Excel files |*.xlsx"
            dialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            dialog.Title = "Seleccione el archivo de movimientos de banco, recuerde que tiene que ser una versión posterior a MS Excel 2003"
            If dialog.ShowDialog() = DialogResult.OK Then
                'Create a new DataTable.
                Dim dt As New DataTable()
                Using workBook As New XLWorkbook((dialog.FileName))
                    'Read the first Sheet from Excel file.
                    Dim workSheet As IXLWorksheet = workBook.Worksheet(1)
                    'Loop through the Worksheet rows.
                    Dim firstRow As Boolean = True
                    For x = primerafila To workSheet.LastRowUsed.RowNumber
                        If x = primerafila Then
                            For z = primeracolumna - 1 To workSheet.LastColumnUsed().ColumnNumber - 1
                                'agrego a los datos del banco
                                dt.Columns.Add(workSheet.Rows(x).Cells(z).Value.ToString)
                            Next
                            'agrego el indice md5
                            dt.Columns.Add("INDICEMD5")
                        Else
                            'Add rows to DataTable.
                            dt.Rows.Add()
                            Dim i As Integer = 0
                            For z = workSheet.FirstColumnUsed.ColumnNumber - 1 To workSheet.LastColumnUsed().ColumnNumber - 1
                                dt.Rows(dt.Rows.Count - 1).Item(i) = workSheet.Rows(x).Cells(z).Value
                                i = i + 1
                            Next
                            'Fecha	Referencia	Codigo Causal	Concepto	Debito	Credito	Saldo
                            For N = 0 To 6
                                'Debe realizarse la consulta de si el campo esta en formato fecha, debido a que el formato de datetime de algunas máquinas contienen un formato de 12 horas,
                                'debido a esto dependiendo de la máquina que realiza la carga el hash md5no coincide , se opta entonces por un formato corto(shortdate)
                                If IsDate(dt.Rows(dt.Rows.Count - 1).Item(N)) Then
                                    dt.Rows(dt.Rows.Count - 1).Item(i) = dt.Rows(dt.Rows.Count - 1).Item(i) & CType(dt.Rows(dt.Rows.Count - 1).Item(N), Date).ToString("dd/MM/yyyy")
                                Else
                                    dt.Rows(dt.Rows.Count - 1).Item(i) = dt.Rows(dt.Rows.Count - 1).Item(i) & dt.Rows(dt.Rows.Count - 1).Item(N)
                                End If
                            Next
                            Select Case dt.Rows(dt.Rows.Count - 1).Item(i).ToString.Length > 0
                                Case True
                                    ''Debido a inconsistencias en la carga del excel en distintas máquinas que ocasionan una duplicación de los movimientos bancarios por no coincidir la cadena de generación de la formula
                                    ''MD5, procedo a realizar lo siguiente:
                                    'Pase a Mayusculas de todas las letras en la cadena a ser convertido.
                                    dt.Rows(dt.Rows.Count - 1).Item(i) = dt.Rows(dt.Rows.Count - 1).Item(i).ToString.ToUpper
                                Case False
                                    dt.Rows(dt.Rows.Count - 1).Item(i) = ""
                            End Select
                        End If
                    Next
                End Using
                Select Case MsgBox("Desea ver los valores a ser importados?", MsgBoxStyle.YesNo, "Seleccione por favor")
                    Case MsgBoxResult.Yes
                        Mostrar_datatable("Datos de banco", dt, "abrirarchivoexcel2")
                    Case MsgBoxResult.No
                End Select
                Insertarareportebanco(dt, numerodecuenta)
                '            excel_datagridview.DataSource = dt
                MessageBox.Show("Actualizados " & dt.Rows.Count & " registros")
                dt.Dispose()
            End If
        End Using
    End Sub

    Public Function AbrirarchivoexcelMFyV(ByVal primerafila As Integer, ByVal primeracolumna As Integer, ByVal numerodecuenta As String) As DataTable
        Using dialog As New OpenFileDialog()
            dialog.Filter = "Excel files |*.xlsx"
            dialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            dialog.Title = "Seleccione el archivo de movimientos de banco, recuerde que tiene que ser una versión posterior a MS Excel 2003"
            Dim partedeclave() As String
            Dim Hashed As String = ""
            If dialog.ShowDialog() = DialogResult.OK Then
                'Create a new DataTable.
                Dim dt As New DataTable()
                ' Dim splitnumerodecuenta As String()
                '    Dim Numerodecuenta As String = ""
                Using workBook As New XLWorkbook((dialog.FileName))
                    'Read the first Sheet from Excel file.
                    Dim workSheet As IXLWorksheet = workBook.Worksheet(1)
                    'Loop through the Worksheet rows.
                    Dim firstRow As Boolean = True
                    dt.Columns.Add("FECHA", GetType(Date)) 'FECHA,1
                    dt.Columns.Add("CodInp", GetType(Integer)) 'CODIGOIMPUTACION,2
                    dt.Columns.Add("Cod_orden", GetType(Integer)) 'CODIGOORDEN,3
                    dt.Columns.Add("Nrotransferencia") 'NUMEROCOMPROBANTE,4
                    dt.Columns.Add("Detalle", GetType(String)) 'EXTRACTO,5
                    dt.Columns.Add("CFdo", GetType(Integer)) 'CLASEFONDO,6
                    dt.Columns.Add("PedidoFondo_N", GetType(Integer)) 'PEDIDOFONDO,7
                    dt.Columns.Add("Expediente_N") 'EXPEDIENTE,8
                    dt.Columns.Add("Expediente_year") 'EXPEDIENTE,8 substring
                    dt.Columns.Add("clave_expediente") 'EXPEDIENTE,8 , transformar
                    dt.Columns.Add("Ingresos", GetType(Decimal)) 'INGRESOS=J/11
                    dt.Columns.Add("Egresos", GetType(Decimal)) 'EGRESOS=K/12
                    dt.Columns.Add("Cuenta_N")
                    dt.Columns.Add("INDICEMD5")
                    For x = primerafila To workSheet.LastRowUsed.RowNumber
                        Dim i As Integer = 0
                        'CONFIGURAR EL TIPO DE DATO
                        'EN CASO DE QUE ESTE VACIO
                        If Not workSheet.Rows(x).Cells(0).Value.ToString = "" Then
                            'Add rows to DataTable.
                            dt.Rows.Add()
                            'CARGA DE DATOS DE MFyV
                            For z = workSheet.FirstColumnUsed.ColumnNumber - 1 To workSheet.LastColumnUsed().ColumnNumber - 1
                                If (z = 0) Or (z = 1) Or (z = 2) Or (z = 3) Or (z = 4) Or (z = 5) Or (z = 6) Or (z = 7) Or (z = 10) Or (z = 11) Then
                                    If z = 7 Then
                                        dt.Rows(dt.Rows.Count - 1).Item(i) = workSheet.Rows(x).Cells(z).Value.ToString.Substring(0, workSheet.Rows(x).Cells(z).Value.ToString.Length - 2)
                                        dt.Rows(dt.Rows.Count - 1).Item(i + 1) = "20" & workSheet.Rows(x).Cells(z).Value.ToString.Substring(workSheet.Rows(x).Cells(z).Value.ToString.Length - 2, 2)
                                        partedeclave = Divisordedosvariablesexpte(workSheet.Rows(x).Cells(z).Value.ToString.Substring(0, workSheet.Rows(x).Cells(z).Value.ToString.Length - 2))
                                        dt.Rows(dt.Rows.Count - 1).Item(i + 2) = Regex.Replace("20" & workSheet.Rows(x).Cells(z).Value.ToString.Substring(workSheet.Rows(x).Cells(z).Value.ToString.Length - 2, 2) &
                                        partedeclave(0) & Format(Convert.ToInt32(partedeclave(1)), "00000").ToString, "[^0-9]", "")
                                        i += +2
                                    Else
                                        dt.Rows(dt.Rows.Count - 1).Item(i) = workSheet.Rows(x).Cells(z).Value
                                    End If
                                    i += +1
                                End If
                            Next
                            ' i += -1
                            'FECHA, NOMBRE, TRANSFERENCIA Y VALOR
                            'For N = 0 To workSheet.LastColumnUsed().ColumnNumber - 1
                            For N = 0 To dt.Columns.Count - 1
                                'Debe realizarse la consulta de si el campo esta en formato fecha, debido a que el formato de datetime de algunas máquinas contienen un formato de 12 horas,
                                'debido a esto dependiendo de la máquina que realiza la carga el hash md5no coincide , se opta entonces por un formato corto(shortdate)
                                If IsDate(dt.Rows(dt.Rows.Count - 1).Item(N)) Then
                                    dt.Rows(dt.Rows.Count - 1).Item(i) = dt.Rows(dt.Rows.Count - 1).Item(i) & CType(dt.Rows(dt.Rows.Count - 1).Item(N), Date).ToShortDateString
                                    '   MessageBox.Show(CType(dt.Rows(dt.Rows.Count - 1).Item(N), Date).ToShortDateString)
                                Else
                                    dt.Rows(dt.Rows.Count - 1).Item(i) = dt.Rows(dt.Rows.Count - 1).Item(i) & dt.Rows(dt.Rows.Count - 1).Item(N)
                                End If
                                Hashed += dt.Rows(dt.Rows.Count - 1).Item(N).ToString
                            Next
                            Select Case dt.Rows(dt.Rows.Count - 1).Item(i).ToString.Length > 0
                                Case True
                                    ''Debido a inconsistencias en la carga del excel en distintas máquinas que ocasionan una duplicación de los movimientos bancarios por no coincidir la cadena de generación de la formula
                                    ''MD5, procedo a realizar lo siguiente:
                                    'dt.Rows(dt.Rows.Count - 1).Item(i) = (dt.Rows(dt.Rows.Count - 1).Item(i).ToString)
                                    ''Extracción de los signos de puntuación, que debido a la configuración regional de cada máquina puede ser interpretado como separador de miles o decimal'
                                    'dt.Rows(dt.Rows.Count - 1).Item(i) = dt.Rows(dt.Rows.Count - 1).Item(i).ToString.Replace(",", "")
                                    'dt.Rows(dt.Rows.Count - 1).Item(i) = dt.Rows(dt.Rows.Count - 1).Item(i).ToString.Replace(".", "")
                                    dt.Rows(dt.Rows.Count - 1).Item(dt.Columns.Count - 2) = numerodecuenta
                                    dt.Rows(dt.Rows.Count - 1).Item(dt.Columns.Count - 1) = GenerateHash(Hashed)
                                'Pase a Mayusculas de todas las letras en la cadena a ser convertido.
                                'Utilización del motor de base de datos para el cálculo de la función md5 en la inserción SQL
                            '    dt.Rows(dt.Rows.Count - 1).Item(i) = GenerateHash(dt.Rows(dt.Rows.Count - 1).Item(i).ToString)
                                Case False
                                    dt.Rows(dt.Rows.Count - 1).Item(i) = ""
                            End Select
                        End If
                        Hashed = ""
                    Next
                End Using
                CargarenMFyV(dt, numerodecuenta)
                Return dt
                'Insertarareportebanco(dt, numerodecuenta)
                ''            excel_datagridview.DataSource = dt
                MessageBox.Show(dt.Rows.Count - 1)
                '    dt.Dispose()
            End If
        End Using
    End Function

    Private Function GetValue(doc As SpreadsheetDocument, cell As DocumentFormat.OpenXml.Spreadsheet.Cell) As Object
        If Not IsNothing(cell.CellValue) Then
            Dim value As String = cell.CellValue.InnerText
            Dim valuedec As Decimal = 0
            If cell.DataType IsNot Nothing AndAlso cell.DataType.Value = DocumentFormat.OpenXml.Spreadsheet.CellValues.SharedString Then
                Return doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements(Int32.Parse(value)).InnerText
            Else
                'MessageBox.Show(cell.StyleIndex)
                valuedec = cell.CellValue.InnerText
            End If
            Return value
        Else
            Return ""
        End If
        'Double.Parse(cell.CellValue.Text, Globalization.CultureInfo.InvariantCulture).ToString()
    End Function

    Private Function GetValuedecimal(doc As SpreadsheetDocument, cell As DocumentFormat.OpenXml.Spreadsheet.Cell) As Object
        If Not IsNothing(cell.CellValue) Then
            Dim value As String = cell.CellValue.InnerText
            Dim valuedec As Decimal = 0
            'If cell.InnerText.Contains("7746109") Then
            '    MessageBox.Show(cell.StyleIndex)
            'End If
            If cell.StyleIndex = "4" Or
                cell.StyleIndex = "6" Or
                cell.StyleIndex = "7" Or
                cell.StyleIndex = "9" Or
                cell.StyleIndex = "11" Or
                  cell.StyleIndex = "12" Or
                 cell.StyleIndex = "14" Or
                cell.StyleIndex = "15" Or
                    cell.StyleIndex = "16" Or
                   cell.StyleIndex = "17" Or
                cell.StyleIndex = "19" Then
                If (cell.CellValue.InnerText.Length - (cell.CellValue.InnerText.ToString.IndexOf(".") + 1)) > 1 And cell.CellValue.InnerText.ToString.IndexOf(".") <= 9 And Not (cell.CellValue.InnerText.ToString.IndexOf(".") = -1) Then
                    'If cell.CellValue.InnerText.ToString = "3261339262.4299998" Then
                    '    MessageBox.Show(cell.StyleIndex)1
                    'End If
                    valuedec = CType(cell.CellValue.InnerText.ToString.Substring(0, cell.CellValue.InnerText.ToString.IndexOf(".")), Integer)
                    Select Case (cell.CellValue.InnerText.Length - (cell.CellValue.InnerText.ToString.IndexOf(".") + 1))
                        Case = 2
                            valuedec += CType(cell.CellValue.InnerText.ToString.Substring(cell.CellValue.InnerText.ToString.IndexOf(".") + 1, 2), Integer) / 100
                        Case < 2
                            valuedec += CType(cell.CellValue.InnerText.ToString.Substring(cell.CellValue.InnerText.ToString.IndexOf(".") + 1, 1) & "0", Integer) / 100
                        Case Else
                            valuedec += ((CType(cell.CellValue.InnerText.ToString.Substring(cell.CellValue.InnerText.ToString.IndexOf(".") + 1, 2), Integer)) / 100)
                            If cell.CellValue.InnerText.ToString.Substring(cell.CellValue.InnerText.Length - (cell.CellValue.InnerText.ToString.IndexOf(".") + 1), 1) = "9" Then
                                valuedec += 0.01
                            Else
                            End If
                    End Select
                Else
                    Return CType(cell.CellValue.InnerText.Replace(".", ","), Decimal)
                End If
                Return valuedec
            End If
            If cell.DataType IsNot Nothing AndAlso cell.DataType.Value = DocumentFormat.OpenXml.Spreadsheet.CellValues.SharedString Then
                Return doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements(Int32.Parse(value)).InnerText
                ' Return doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(Integer.Parse(value)).InnerText
            Else
                ' MessageBox.Show(cell.StyleIndex)
                valuedec = cell.CellValue.InnerText
            End If
            Return value
        Else
            Return ""
        End If
        'Double.Parse(cell.CellValue.Text, Globalization.CultureInfo.InvariantCulture).ToString()
    End Function

    Public Function AbrirarchivoexcelMFyV_SAFI() As DataTable
        Dim primerafila As Integer = 1
        Dim Primeracolumna As Integer = 0
        Dim Numerodecuenta As String = "fallido"
        Using dialog As New OpenFileDialog()
            dialog.Filter = "Excel files |*.xlsx"
            dialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            dialog.Title = "Seleccione el archivo de movimientos de banco, recuerde que tiene que ser una versión posterior a MS Excel 2003"
            Dim partedeclave() As String
            Dim Hashed As String = ""
            If dialog.ShowDialog() = DialogResult.OK Then
                'Create a new DataTable.
                Dim dtexcel As New DataTable()
                ' Dim splitnumerodecuenta As String()
                '    Dim Numerodecuenta As String = ""
                Dim i As Integer = 0
                'Create a new DataTable.
                Dim dt As New DataTable()
                'Open the Excel file in Read Mode using OpenXml.
                Using doc As SpreadsheetDocument = SpreadsheetDocument.Open((dialog.FileName), False)
                    'Read the first Sheet from Excel file.
                    Dim sheet As DocumentFormat.OpenXml.Spreadsheet.Sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild(Of DocumentFormat.OpenXml.Spreadsheet.Sheet)()
                    'Get the Worksheet instance.
                    Dim worksheet As DocumentFormat.OpenXml.Spreadsheet.Worksheet = TryCast(doc.WorkbookPart.GetPartById(sheet.Id.Value), WorksheetPart).Worksheet
                    'Fetch all the rows present in the Worksheet.
                    Dim rows As IEnumerable(Of DocumentFormat.OpenXml.Spreadsheet.Row) = worksheet.GetFirstChild(Of DocumentFormat.OpenXml.Spreadsheet.SheetData)().Descendants(Of DocumentFormat.OpenXml.Spreadsheet.Row)()
                    Dim valoraevaluar As String = ""
                    Dim valordecimal As Decimal = Nothing
                    'Loop through the Worksheet rows.
                    For Each row As DocumentFormat.OpenXml.Spreadsheet.Row In rows
                        'Use the first row to add columns to DataTable.
                        If row.RowIndex.Value = 1 Then
                            For Each cell As DocumentFormat.OpenXml.Spreadsheet.Cell In row.Descendants(Of DocumentFormat.OpenXml.Spreadsheet.Cell)()
                                dtexcel.Columns.Add(GetValue(doc, cell))
                                'If dtexcel.Columns.Count = 11 Or dtexcel.Columns.Count = 12 Then
                                '    dtexcel.Columns.Add(dtexcel.Columns.Count, TypeOf (System.Decimal))
                                'Else
                                '    dtexcel.Columns.Add(GetValue(doc, cell))
                                'End If
                            Next
                        Else
                            'Add rows to DataTable.
                            dtexcel.Rows.Add()
                            Dim p As Integer = 0
                            For Each cell As DocumentFormat.OpenXml.Spreadsheet.Cell In row.Descendants(Of DocumentFormat.OpenXml.Spreadsheet.Cell)()
                                'If Not IsNothing(cell.CellValue) Then
                                '    If cell.CellValue.InnerText.Contains("1116000") Then
                                '        MessageBox.Show("este")
                                '    End If
                                'End If
                                If p = 11 Or p = 12 Then
                                    dtexcel.Rows(dtexcel.Rows.Count - 1)(p) = GetValuedecimal(doc, cell)
                                Else
                                    dtexcel.Rows(dtexcel.Rows.Count - 1)(p) = GetValue(doc, cell)
                                End If
                                'If dtexcel.Columns.Count = 11 Or dtexcel.Columns.Count = 12 Then
                                '    dtexcel.Rows(dtexcel.Rows.Count - 1)(p) = GetValue(doc, cell)
                                'Else
                                '    dtexcel.Rows(dtexcel.Rows.Count - 1)(p) = GetValue(doc, cell)
                                'End If
                                'If Not valoraevaluar = "" Then
                                '    If IsNumeric(valoraevaluar) Then
                                '        If Decimal.TryParse(valoraevaluar, valordecimal) Then
                                '            dtexcel.Rows(dtexcel.Rows.Count - 1)(p) = valordecimal
                                '        Else
                                '            dtexcel.Rows(dtexcel.Rows.Count - 1)(p) = valoraevaluar
                                '        End If
                                '    Else
                                '        dtexcel.Rows(dtexcel.Rows.Count - 1)(p) = valoraevaluar
                                '    End If
                                'Else
                                '    dtexcel.Rows(dtexcel.Rows.Count - 1)(p) = valoraevaluar
                                'End If
                                p += 1
                            Next
                        End If
                    Next
                End Using
                'Using workBook As New DocumentFormat.OpenXml.Spreadsheet.Workbook((dialog.FileName), XLEventTracking.Disabled)
                '    'Read the first Sheet from Excel file.
                '    Dim workSheet As IXLWorksheet = workBook.Worksheet(1)
                '    'Loop through the Worksheet rows.
                '    Dim firstRow As Boolean = True
                '    For Each row As IXLRow In workSheet.Rows()
                '        'Use the first row to add columns to DataTable.
                '        If firstRow Then
                '            For Each cell As IXLCell In row.Cells()
                '                dtexcel.Columns.Add(cell.Value.ToString())
                '            Next
                '            firstRow = False
                '        Else
                '            'Add rows to DataTable.
                '            dtexcel.Rows.Add()
                '            i = 0
                '            For Each cell As IXLCell In row.Cells()
                '                dtexcel.Rows(dtexcel.Rows.Count - 1)(i) = cell.Value.ToString()
                '                i += 1
                '            Next
                '        End If
                '    Next
                '    Dim workcell As IXLCell = Nothing
                dt.Columns.Add("FECHA", GetType(Date)) 'FECHA,0
                dt.Columns.Add("CodInp", GetType(Integer)) 'CODIGOIMPUTACION,1
                dt.Columns.Add("Cod_orden", GetType(Integer)) 'CODIGOORDEN,2
                dt.Columns.Add("Nrotransferencia") 'NUMEROCOMPROBANTE,3
                dt.Columns.Add("Detalle", GetType(String)) 'EXTRACTO,4
                dt.Columns.Add("CFdo", GetType(Integer)) 'CLASEFONDO,5
                dt.Columns.Add("PedidoFondo_N", GetType(Integer)) 'PEDIDOFONDO,6
                dt.Columns.Add("Expediente_N") 'EXPEDIENTE,7
                dt.Columns.Add("Expediente_year") 'EXPEDIENTE,8 substring,8
                dt.Columns.Add("clave_expediente") 'EXPEDIENTE,8 , transformar,9
                dt.Columns.Add("Ingresos", GetType(Decimal)) 'INGRESOS=J/10
                dt.Columns.Add("Egresos", GetType(Decimal)) 'EGRESOS=K/11
                dt.Columns.Add("Cuenta_N") 'Cuenta_N=K/12
                dt.Columns.Add("INDICEMD5") 'INDICEMD5=K/13
                i = 0
                For x = 0 To dtexcel.Rows.Count - 2
                    'Add rows to DataTable.
                    '1   N° Asiento
                    '2   Fecha del Comprobante
                    '3
                    '4   Código de Orden
                    '5   Clase de Fondo
                    '6   Código de Imputación
                    '7   Pedido de Fondo
                    '8   N° Comprobante
                    '9   Expediente
                    '10  Descripción
                    '11  Ingresos
                    '12  Egresos
                    If IsNumeric(dtexcel.Rows(x).Item(4)) Then
                        If dtexcel.Rows(x).Item(4) > 0 Then
                            dt.Rows.Add()
                            For z = 0 To dtexcel.Columns.Count - 1
                                Select Case z
                                    Case Is = 0
                                    Case Is = 1
                                        dt.Rows(i).Item(13) = dtexcel.Rows(x).Item(z)
                                    Case Is = 2
                                        dt.Rows(i).Item(0) = dtexcel.Rows(x).Item(z)
                                    Case Is = 3
                                    Case Is = 4
                                        dt.Rows(i).Item(2) = dtexcel.Rows(x).Item(z)
                                    Case Is = 5
                                        dt.Rows(i).Item(5) = dtexcel.Rows(x).Item(z)
                                    Case Is = 6
                                        dt.Rows(i).Item(1) = dtexcel.Rows(x).Item(z)
                                    Case Is = 7
                                        dt.Rows(i).Item(6) = dtexcel.Rows(x).Item(z)
                                    Case Is = 8
                                        dt.Rows(i).Item(3) = dtexcel.Rows(x).Item(z)
                                    Case Is = 9
                                        '7'8'9
                                        Dim VARIABLE As String() = Divisordetresvariables(dtexcel.Rows(x).Item(z)) 'Expediente
                                        dt.Rows(i).Item(7) = VARIABLE(0) & "-" & VARIABLE(1)
                                        dt.Rows(i).Item(8) = VARIABLE(2)
                                        dt.Rows(i).Item(9) = VARIABLE(2) & VARIABLE(0) & Format(Convert.ToInt32(VARIABLE(1)), "00000")
                                    Case Is = 10
                                        dt.Rows(i).Item(4) = dtexcel.Rows(x).Item(z)
                                    Case Is = 11
                                        dt.Rows(i).Item(10) = dtexcel.Rows(x).Item(z)
                                        'Math.Round(CType(dtexcel.Rows(x).Item(z).ToString.Replace(",", "."), Decimal), 2)
                                    Case Is = 12
                                        dt.Rows(i).Item(11) = dtexcel.Rows(x).Item(z)
                                        'Math.Round(CType(dtexcel.Rows(x).Item(z).ToString.Replace(",", "."), Decimal), 2)
                                End Select
                                dt.Rows(i).Item(12) = Numerodecuenta
                            Next
                            'RENDICIONES solo valido
                            'For z = 0 To dtexcel.Columns.Count - 1
                            '    Select Case z
                            '        Case Is = 0
                            '        Case Is = 1
                            '            dt.Rows(i).Item(13) = dtexcel.Rows(x).Item(z)
                            '        Case Is = 2
                            '            dt.Rows(i).Item(0) = dtexcel.Rows(x).Item(z)
                            '        Case Is = 3
                            '        Case Is = 4
                            '            dt.Rows(i).Item(2) = dtexcel.Rows(x).Item(z)
                            '        Case Is = 5
                            '            dt.Rows(i).Item(5) = dtexcel.Rows(x).Item(z)
                            '        Case Is = 6
                            '            dt.Rows(i).Item(1) = dtexcel.Rows(x).Item(z)
                            '        Case Is = 7
                            '            dt.Rows(i).Item(6) = dtexcel.Rows(x).Item(z)
                            '        Case Is = 8
                            '            dt.Rows(i).Item(4) = dtexcel.Rows(x).Item(z)
                            '        Case Is = 9
                            '            '7'8'9
                            '            Dim VARIABLE As String() = Divisordetresvariables(dtexcel.Rows(x).Item(z)) 'Expediente
                            '            dt.Rows(i).Item(7) = VARIABLE(0)
                            '            dt.Rows(i).Item(8) = VARIABLE(1)
                            '            dt.Rows(i).Item(9) = VARIABLE(2)
                            '        Case Is = 10
                            '            If dtexcel.Rows(x).Item(z) > 0 Then
                            '                dt.Rows(i).Item(10) = CType(dtexcel.Rows(x).Item(z), Decimal)
                            '            Else
                            '                dt.Rows(i).Item(11) = CType(dtexcel.Rows(x).Item(z), Decimal)
                            '            End If
                            '    End Select
                            '    dt.Rows(i).Item(12) = Numerodecuenta
                            'Next
                            i += 1
                        Else
                        End If
                    Else
                        If dtexcel.Rows(x).Item(1).ToString.Contains("Cuenta Bancaria N°") Then
                            If Not dtexcel.Rows(x).Item(1).ToString.Substring(19, 10) = "9999999999" Then
                                Numerodecuenta = "30010" & dtexcel.Rows(x).Item(1).ToString.Substring(19, 10)
                            Else
                                Numerodecuenta = "99999" & dtexcel.Rows(x).Item(1).ToString.Substring(19, 10)
                            End If
                        End If
                    End If
                Next
                CargarenMFyV_SAFI(dt, Numerodecuenta)
                Return dt
                'Insertarareportebanco(dt, numerodecuenta)
                ''            excel_datagridview.DataSource = dt
                MessageBox.Show(dt.Rows.Count - 1)
                '    dt.Dispose()
            End If
        End Using
    End Function

    'Public Sub Abrirarchivocsv(ByRef excel_datagridview As DataGridView, ByVal primerafila As Integer, ByVal primeracolumna As Integer, ByVal numerodecuenta As String, ByVal delimitador As String, ByVal calificadortexto As String)
    '    Dim dialog As New OpenFileDialog()
    '    dialog.Filter = "CSV FILES |*.CSV"
    '    dialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
    '    dialog.Title = "Seleccione el archivo de movimientos de banco csv"
    '    If dialog.ShowDialog() = DialogResult.OK Then
    '        'Create a new DataTable.
    '        Dim dt As New DataTable()
    '        Dim parser As New GenericParsing.GenericParserAdapter
    '        'Using parser As New GenericParsing.GenericParserAdapter((dialog.FileName))
    '        '    parser.ColumnDelimiter = CType(",", Char)
    '        '    ' parser.TextQualifier = CType(Chr(34) & Chr(34), Char)
    '        '    parser.FirstRowHasHeader = True
    '        '    ' parser.TextFieldType = GenericParsing.FieldType.Delimited
    '        '    dt = parser.GetDataTable
    '        'End Using
    '        'Using csv = New CachedCsvReader(New StreamReader(dialog.FileName), True)
    '        '    excel_datagridview.DataSource = csv
    '        'End Using
    '        parser.SetDataSource(dialog.FileName)
    '        parser.ColumnDelimiter = ","
    '        parser.FirstRowHasHeader = True
    '        parser.SkipStartingDataRows = 0
    '        parser.MaxBufferSize = 4096
    '        parser.MaxRows = 119500
    '        parser.TextQualifier = """" & """"
    '        excel_datagridview.DataSource = parser.GetDataTable
    '        MessageBox.Show("Datos importados")
    '        'Dim splitnumerodecuenta As String()
    '        ''    Dim Numerodecuenta As String = ""
    '        'Using workBook As New XLWorkbook((dialog.FileName))
    '        '    'Read the first Sheet from Excel file.
    '        '    Dim workSheet As IXLWorksheet = workBook.Worksheet(1)
    '        '    'Loop through the Worksheet rows.
    '        '    Dim firstRow As Boolean = True
    '        '    '  splitnumerodecuenta = numerodecuenta
    '        '    'Split(workSheet.Rows(primerafila - 1).Cells(0).Value.ToString, "Número de cuenta ")
    '        '    '    Numerodecuenta = "3-001-0941679090-7"
    '        '    'Numerodecuentanormalizar(splitnumerodecuenta(1))
    '        '    For x = primerafila To workSheeRowUsed.RowNumber
    '        '        If x = primerafila Then
    '        '            For z = primeracolumna - 1 To workSheet.LastColumnUsed().ColumnNumber - 1
    '        '                dt.Columns.Add(workSheet.Rows(x).Cells(z).Value.ToString)
    '        '            Next
    '        '            'agrego el indice md5
    '        '            dt.Columns.Add("INDICEMD5")
    '        '        Else
    '        '            'Add rows to DataTable.
    '        '            dt.Rows.Add()
    '        '            Dim i As Integer = 0
    '        '            For z = workSheet.FirstColumnUsed.ColumnNumber - 1 To workSheet.LastColumnUsed().ColumnNumber - 1
    '        '                dt.Rows(dt.Rows.Count - 1).Item(i) = workSheet.Rows(x).Cells(z).Value
    '        '                i = i + 1
    '        '            Next
    '        '            'FECHA, NOMBRE, TRANSFERENCIA Y VALOR
    '        '            For N = 0 To 4
    '        '                dt.Rows(dt.Rows.Count - 1).Item(i) = dt.Rows(dt.Rows.Count - 1).Item(i).ToString & dt.Rows(dt.Rows.Count - 1).Item(N).ToString
    '        '            Next
    '        '            Select Case dt.Rows(dt.Rows.Count - 1).Item(i).ToString.Length > 0
    '        '                Case True
    '        '                    dt.Rows(dt.Rows.Count - 1).Item(i) = GenerateHash(dt.Rows(dt.Rows.Count - 1).Item(i).ToString)
    '        '                Case False
    '        '                    dt.Rows(dt.Rows.Count - 1).Item(i) = ""
    '        '            End Select
    '        '        End If
    '        '    Next
    '        'End Using
    '        'Insertarareportebanco(dt, numerodecuenta)
    '        ''            excel_datagridview.DataSource = dt
    '        'MessageBox.Show(dt.Rows.Count - 1)
    '        'dt.Dispose()
    '    End If
    'End Sub
    Public Sub Insertarareportebanco(ByVal tabladedatos As DataTable, ByVal Numerodecuenta As String)
        'Fecha, Nro.Transacción, Descripción, Importe, Saldo, MD5HASH
        Dim RELOJ As New Stopwatch
        RELOJ.Start()
        Dim S As Decimal
        Dim CATEGORIAS As String = ""
        For x As Integer = 0 To tabladedatos.Rows.Count - 1
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Cuenta", Numerodecuenta)
            'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(DateTime.Parse(tabladedatos.Rows(x).Item(0)).ToString("YYYY-MM-dd")))
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(tabladedatos.Rows(x).Item(0)))
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Nro_Transaccion", tabladedatos.Rows(x).Item(1))
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Descripcion", tabladedatos.Rows(x).Item(3))
            CATEGORIAS = CATEGORIA(tabladedatos.Rows(x).Item(3)).ToString
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CATEGORIA", CATEGORIAS)
            Select Case Not (tabladedatos.Rows(x).Item(4).ToString = "")
                Case True
                    S = Convert.ToDecimal(tabladedatos.Rows(x).Item(4), System.Globalization.CultureInfo.InvariantCulture) * -1
                Case False
                    S = Convert.ToDecimal(tabladedatos.Rows(x).Item(5), System.Globalization.CultureInfo.InvariantCulture)
            End Select
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Importe", S)
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Saldo", Convert.ToDecimal(tabladedatos.Rows(x).Item(6), System.Globalization.CultureInfo.InvariantCulture))
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@MD5HASH", GenerateHash(tabladedatos.Rows(x).Item(7).ToString))
            SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "
INSERT INTO reportebanco (`Cuenta`,`Fecha`, `Nro_Transaccion`, `Descripcion`, `Importe`, `Saldo`, `MD5HASH`,CATEGORIA,Usuario) VALUES
            (@Cuenta,@Fecha, @Nro_Transaccion, @Descripcion, @Importe, @Saldo, @MD5HASH,@CATEGORIA,@Usuario) On DUPLICATE KEY UPDATE
`Cuenta`=@Cuenta,
`Fecha`=@Fecha,
`Nro_Transaccion`=@Nro_Transaccion,
`Descripcion`=@Descripcion,
`Importe`=@Importe,
`Saldo`=@Saldo,
`MD5HASH`=@MD5HASH,
cATEGORIA=@CATEGORIA,Usuario=@Usuario"
            INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Next
        RELOJ.Stop()
        MessageBox.Show($"PROCESADOS {tabladedatos.Rows.Count} REGISTROS EN {RELOJ.ElapsedMilliseconds } Milisegundos")
    End Sub

    Private Function CATEGORIA(ByVal DETALLE As String) As String
        Dim RETORNO As String = ""
        Dim DETALLADO As New List(Of String)
        Dim CATEGORIAS As String
        ''CHEQUE
        'DETALLADO.AddRange({"CHEQUE", "CHEQ.", "TRANSFERIDO"})
        'CATEGORIAS = "CHEQUE"
        ''If DETALLADO.Contains(DETALLE.ToUpper) Then
        ''    RETORNO = CATEGORIAS
        ''End If
        'For x = 0 To DETALLADO.Count - 1
        '    If DETALLE.ToUpper.Contains(DETALLADO.Item(x).ToUpper) Then
        '        RETORNO = CATEGORIAS
        '        Exit For
        '    End If
        'Next
        ''If DETALLE.ToUpper.Contains("CHEQUE") Or DETALLE.ToUpper.Contains("CHEQ.DETALLE.") Or DETALLE.ToUpper.Contains("TRANSFERIDO") Then
        ''    RETORNO = CATEGORIAS
        ''End If
        'DETALLADO.Clear()
        'CHEQUE COMUN O TRANSFERENCIA
        DETALLADO.AddRange({"CHEQUE", "CHEQ.", "TRANSFERIDO", "DIST TIT"})
        CATEGORIAS = "CHEQUE"
        If RETORNOCATEGORIA(DETALLADO, DETALLE) Then
            RETORNO = CATEGORIAS
        End If
        DETALLADO.Clear()
        'CHEQUE RECHAZADO
        DETALLADO.AddRange({"RECH.CHEQUE", "RECHAZADO", "FALLA TECNICA", "SIN FONDO"})
        CATEGORIAS = "CHEQUE RECHAZADO"
        If RETORNOCATEGORIA(DETALLADO, DETALLE) Then
            RETORNO = CATEGORIAS
        End If
        DETALLADO.Clear()
        'CHEQUE PROPIO
        DETALLADO.AddRange({"CHEQUE PROPIO"})
        CATEGORIAS = "CHEQUE PROPIO"
        If RETORNOCATEGORIA(DETALLADO, DETALLE) Then
            RETORNO = CATEGORIAS
        End If
        DETALLADO.Clear()
        'CHEQUE INTERBANCO
        DETALLADO.AddRange({"TRANSFER.INTERSUC."})
        CATEGORIAS = "CHEQUE INTERBANCO"
        If RETORNOCATEGORIA(DETALLADO, DETALLE) Then
            RETORNO = CATEGORIAS
        End If
        DETALLADO.Clear()
        'DEPOSITO TESORERIA GENERAL
        DETALLADO.AddRange({"TESORERIA GENERAL", "30672394011"})
        CATEGORIAS = "DEPOSITO TESORERIA GRAL."
        If RETORNOCATEGORIA(DETALLADO, DETALLE) Then
            RETORNO = CATEGORIAS
        End If
        DETALLADO.Clear()
        'DEPOSITO TESORERIA GENERAL HABERES
        DETALLADO.AddRange({"REMUNERACIONES"})
        CATEGORIAS = "HABERES"
        If RETORNOCATEGORIA(DETALLADO, DETALLE) Then
            RETORNO = CATEGORIAS
        End If
        DETALLADO.Clear()
        'COMISION BANCARIA
        DETALLADO.AddRange({"COMISION ", "DE CHEQUERA"})
        CATEGORIAS = "COMISION BANCARIA"
        If RETORNOCATEGORIA(DETALLADO, DETALLE) Then
            RETORNO = CATEGORIAS
        End If
        DETALLADO.Clear()
        'MEP
        DETALLADO.AddRange({"DEBITO TRANSFERENCIAS MEP ", "MEP"})
        CATEGORIAS = "MEP"
        If RETORNOCATEGORIA(DETALLADO, DETALLE) Then
            RETORNO = CATEGORIAS
        End If
        DETALLADO.Clear()
        'DEBITO FISCAL IVA BASICO
        DETALLADO.AddRange({"DEBITO FISCAL IVA BASICO"})
        CATEGORIAS = "DEBITO FISCAL IVA BASICO"
        If RETORNOCATEGORIA(DETALLADO, DETALLE) Then
            RETORNO = CATEGORIAS
        End If
        DETALLADO.Clear()
        'JUDICIALES
        DETALLADO.AddRange({"JUDICIALES"})
        CATEGORIAS = "JUDICIALES"
        If RETORNOCATEGORIA(DETALLADO, DETALLE) Then
            RETORNO = CATEGORIAS
        End If
        DETALLADO.Clear()
        ''CHEQUE PROPIO
        'DETALLADO.AddRange({"CHEQUE PROPIO"})
        'CATEGORIAS = "CHEQUE PROPIO"
        'For x = 0 To DETALLADO.Count - 1
        '    If DETALLE.ToUpper.Contains(DETALLADO.Item(x).ToUpper) Then
        '        RETORNO = CATEGORIAS
        '        Exit For
        '    End If
        'Next
        'DETALLADO.Clear()
        ''CHEQUE INTERBANCO
        'DETALLADO.AddRange({"TRANSFER.INTERSUC."})
        'CATEGORIAS = "CHEQUE INTERBANCO"
        'For x = 0 To DETALLADO.Count - 1
        '    If DETALLE.ToUpper.Contains(DETALLADO.Item(x).ToUpper) Then
        '        RETORNO = CATEGORIAS
        '        Exit For
        '    End If
        'Next
        'DETALLADO.Clear()
        ''DEPOSITO TESORERIA GENERAL
        'DETALLADO.AddRange({"TESORERIA GENERAL", "30672394011"})
        'CATEGORIAS = "DEPOSITO TESORERIA GRAL."
        'For x = 0 To DETALLADO.Count - 1
        '    If DETALLE.ToUpper.Contains(DETALLADO.Item(x).ToUpper) Then
        '        RETORNO = CATEGORIAS
        '        Exit For
        '    End If
        'Next
        'DETALLADO.Clear()
        ''DEPOSITO TESORERIA GENERAL
        'DETALLADO.AddRange({"REMUNERACIONES"})
        'CATEGORIAS = "HABERES"
        'For x = 0 To DETALLADO.Count - 1
        '    If DETALLE.ToUpper.Contains(DETALLADO.Item(x).ToUpper) Then
        '        RETORNO = CATEGORIAS
        '        Exit For
        '    End If
        'Next
        'DETALLADO.Clear()
        'DETALLADO.AddRange({"COMISION ", "DE CHEQUERA"})
        'CATEGORIAS = "COMISION BANCARIA"
        'For x = 0 To DETALLADO.Count - 1
        '    If DETALLE.ToUpper.Contains(DETALLADO.Item(x).ToUpper) Then
        '        RETORNO = CATEGORIAS
        '        Exit For
        '    End If
        'Next
        'DETALLADO.Clear()
        Return RETORNO
    End Function

    Private Function RETORNOCATEGORIA(ByVal DETALLADO As List(Of String), ByVal DETALLE As String) As Boolean
        Dim RETORNAR As Boolean
        For x = 0 To DETALLADO.Count - 1
            If DETALLE.ToUpper.Contains(DETALLADO.Item(x).ToUpper) Then
                Return True
                Exit For
            End If
        Next
    End Function

    Private Async Sub InsertarMFyV(ByVal tabladedatos As DataTable, ByVal Numerodecuenta As String)
        'Fecha, Nro.Transacción, Descripción, Importe, Saldo, MD5HASH
        Dim TabladeMFyV As New List(Of MFyV_movimientos)
        Dim detalle_MFyv As New MFyV_movimientos
        For x As Integer = 0 To tabladedatos.Rows.Count - 1
            detalle_MFyv.Cuenta = Numerodecuenta
            detalle_MFyv.FECHA = tabladedatos.Rows(x).Item("Fecha")
            detalle_MFyv.CODIGO_IMPUTAC = tabladedatos.Rows(x).Item("CODIGO_IMPUTAC")
            detalle_MFyv.CODIGO_ORDEN = tabladedatos.Rows(x).Item("CODIGO_ORDEN")
            detalle_MFyv.NUMERO_COMPROBANTE = tabladedatos.Rows(x).Item("NUMERO_COMPROBANTE")
            detalle_MFyv.EXTRACTO = tabladedatos.Rows(x).Item("EXTRACTO")
            detalle_MFyv.CLASE_FONDO = tabladedatos.Rows(x).Item("CLASE_FONDO")
            detalle_MFyv.PEDIDO_DE_FONDO = tabladedatos.Rows(x).Item("PEDIDO_DE_FONDO")
            detalle_MFyv.EXPEDIENTE = tabladedatos.Rows(x).Item("EXPEDIENTE")
            detalle_MFyv.INGRESOS = tabladedatos.Rows(x).Item("INGRESOS")
            detalle_MFyv.EGRESOS = tabladedatos.Rows(x).Item("EGRESOS")
            TabladeMFyV.Add(detalle_MFyv)
        Next
        Dim S As Decimal
        For x As Integer = 0 To tabladedatos.Rows.Count - 1
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Cuenta", Numerodecuenta)
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(tabladedatos.Rows(x).Item(0)))
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Nro_Transaccion", tabladedatos.Rows(x).Item(1))
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Descripcion", tabladedatos.Rows(x).Item(3))
            Select Case Not (tabladedatos.Rows(x).Item(4) = "")
                Case True
                    S = Convert.ToDecimal(tabladedatos.Rows(x).Item(4), System.Globalization.CultureInfo.InvariantCulture) * -1
                Case False
                    S = Convert.ToDecimal(tabladedatos.Rows(x).Item(5), System.Globalization.CultureInfo.InvariantCulture)
            End Select
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Importe", S)
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Saldo", Convert.ToDecimal(tabladedatos.Rows(x).Item(6), System.Globalization.CultureInfo.InvariantCulture))
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@MD5HASH", GenerateHash(tabladedatos.Rows(x).Item(7).ToString))
            SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "
INSERT INTO MFyV (`Cuenta`,`Fecha`, `Nro_Transaccion`, `Descripcion`, `Importe`, `Saldo`, `MD5HASH`,Usuario) VALUES
            (@Cuenta,@Fecha, @Nro_Transaccion, @Descripcion, @Importe, @Saldo, @MD5HASH,@Usuario) On DUPLICATE KEY UPDATE
`Cuenta`=@Cuenta,
`Fecha`=@Fecha,
`Nro_Transaccion`=@Nro_Transaccion,
`Descripcion`=@Descripcion,
`Importe`=@Importe,
`Saldo`=@Saldo,
`MD5HASH`=@MD5HASH,
Usuario=@Usuario
"
            INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Next
    End Sub

    'Public Shared Function ImportExcel(filepath As String) As DataTable
    '    ' string sqlquery= "Select * From [SheetName$] Where YourCondition";
    '    Dim dt As New DataTable
    '    Try
    '        Dim ds As New DataSet()
    '        'Error generado al no tener registrado el OLEDB provider
    '        Dim constring As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & filepath & ";Extended Properties=""Excel 12.0;HDR=YES;"""
    '        Dim con As New OleDbConnection(constring & "")
    '        con.Open()
    '        Dim myTableName = con.GetSchema("Tables").Rows(0)("TABLE_NAME")
    '        Dim sqlquery As String = String.Format("Select * FROM [{0}]", myTableName) ' "Select * From " & myTableName
    '        Dim da As New OleDbDataAdapter(sqlquery, con)
    '        da.Fill(ds)
    '        dt = ds.Tables(0)
    '        Return dt
    '    Catch ex As Exception
    '        MsgBox(Err.Description, MsgBoxStyle.Critical)
    '        Return dt
    '    End Try
    'End Function
    Public Function extraersimbolo(ByVal stringaevaluar As String, ByVal simbolo As Char) As String
        Dim Reconstruccion As String = ""
        If stringaevaluar.Contains(simbolo) Then
            For x = 0 To stringaevaluar.Length - 1
                If Not (stringaevaluar.Chars(x).ToString = simbolo) Then
                    Reconstruccion = Reconstruccion & stringaevaluar.Chars(x)
                End If
            Next
        Else
            Reconstruccion = stringaevaluar
        End If
        stringaevaluar = Reconstruccion
        Reconstruccion = ""
        Return stringaevaluar
    End Function

    Public Function Numerosatextopesosconcorreccion(ByVal Stringinicial As String) As String
        Return Num2Text(Math.Truncate(Convert.ToDecimal(Stringinicial))) & " Pesos con " &
            ((Convert.ToDecimal(Stringinicial) - Math.Truncate(Convert.ToDecimal(Stringinicial))) * 100).ToString("00") & " Centavos.-"
    End Function

    '01 fin +++++++++++++++++++++++++++++++++++++++++experimental+++++++++++++++++++++++++++++++++++++++++++++
    Public Sub Purificaciondedatos(ByRef textboxaevaluar As TextBox)
        'MessageBox.Show(stringaevaluar)
        Dim Reconstruccion As String = ""
        Dim Almacenado As String = textboxaevaluar.Text
        Almacenado = extraersimbolo(Almacenado, ",")
        Almacenado = extraersimbolo(Almacenado, ".")
        Almacenado = extraersimbolo(Almacenado, "+")
        Almacenado = extraersimbolo(Almacenado, "*")
        Almacenado = extraersimbolo(Almacenado, "_")
        Almacenado = extraersimbolo(Almacenado, "=")
        Almacenado = extraersimbolo(Almacenado, ")")
        Almacenado = extraersimbolo(Almacenado, "(")
        'If Almacenado.Contains(" ") Then
        '    For x = 0 To Almacenado.Length - 1
        '        If Not (Almacenado.Chars(x).ToString = " ") Then
        '            Reconstruccion = Reconstruccion & Almacenado.Chars(x)
        '        End If
        '    Next
        'Else
        '    Reconstruccion = Almacenado
        'End If
        'Almacenado = Reconstruccion
        'Reconstruccion = ""
        'If Almacenado.Contains(",") Then
        '    For x = 0 To Almacenado.Length - 1
        '        If Not (Almacenado.Chars(x).ToString = ",") Then
        '            Reconstruccion = Reconstruccion & Almacenado.Chars(x)
        '        End If
        '    Next
        'Else
        '    Reconstruccion = Almacenado
        'End If
        'Almacenado = Reconstruccion
        'Reconstruccion = ""
        'If Almacenado.Contains(".") Then
        '    For x = 0 To Almacenado.Length - 1
        '        If Not (Almacenado.Chars(x).ToString = ".") Then
        '            Reconstruccion = Reconstruccion & Almacenado.Chars(x)
        '        End If
        '    Next
        'Else
        '    Reconstruccion = Almacenado
        'End If
        'Almacenado = Reconstruccion
        'Reconstruccion = ""
        'If Almacenado.Contains("/") Then
        '    For x = 0 To Almacenado.Length - 1
        '        If Not (Almacenado.Chars(x).ToString = "/") Then
        '            Reconstruccion = Reconstruccion & Almacenado.Chars(x)
        '        End If
        '    Next
        'Else
        '    Reconstruccion = Almacenado
        'End If
        'Almacenado = Reconstruccion
        'Reconstruccion = ""
        'If Almacenado.Contains("*") Then
        '    For x = 0 To Almacenado.Length - 1
        '        If Not (Almacenado.Chars(x).ToString = "*") Then
        '            Reconstruccion = Reconstruccion & Almacenado.Chars(x)
        '        End If
        '    Next
        'Else
        '    Reconstruccion = Almacenado
        'End If
        'Almacenado = Reconstruccion
        textboxaevaluar.Text = Almacenado
    End Sub

    Public Function Evaluardocumento(ByVal evaluado As TextBox) As Boolean
        Select Case IsNumeric(evaluado.Text)
            Case True
                Select Case evaluado.Text.Length > 5
                    Case True
                        Return True
                    Case False
                        Return False
                End Select
            Case False
                Select Case evaluado.Text.Length > 7
                    Case True
                        Return True
                    Case False
                        Return False
                End Select
        End Select
    End Function

    Public Sub Verificar(ByRef Objeto As Object, ByVal Verificar As String, ByVal tipodeverificacion As String)
        Select Case Verificar.Length > 0
            Case True
                Select Case tipodeverificacion.ToUpper
                    Case "NUMERICO"
                        Select Case IsNumeric(Verificar)
                            Case True
                                Select Case Convert.ToDecimal(Verificar) > 0
                                    Case True
                                        Colorearobjetos(Objeto, "CORRECTO")
                                    Case False
                                        Colorearobjetos(Objeto, "BORRAR")
                                        TOOLTIPS(Objeto, "El número debe ser mayor a 0 (cero)")
                                End Select
                            Case False
                                Colorearobjetos(Objeto, "BORRAR")
                                TOOLTIPS(Objeto, "Debe ingresar un número")
                        End Select
                    Case "CUIT"
                        Select Case Verificar.Length = 13
                            Case True
                                Colorearobjetos(Objeto, "CORRECTO")
                            Case False
                                Colorearobjetos(Objeto, "BORRAR")
                                TOOLTIPS(Objeto, "El número de CUIT debe tener 13 letras incluidos los guiones")
                        End Select
                    Case "CUENTABANCARIA"
                        Select Case Verificar.Length < 19
                            Case True
                                Colorearobjetos(Objeto, "CORRECTO")
                            Case False
                                Colorearobjetos(Objeto, "BORRAR")
                                TOOLTIPS(Objeto, "Verifique por favor el número de Cuenta")
                        End Select
                    Case "TEXTO"
                        Select Case Verificar.Length > 0
                            Case True
                                Select Case Not IsNumeric(Verificar)
                                    Case True
                                        Colorearobjetos(Objeto, "AGREGAR")
                                    Case False
                                        Colorearobjetos(Objeto, "BORRAR")
                                        TOOLTIPS(Objeto, "debe ingresar un texto")
                                End Select
                            Case False
                                Colorearobjetos(Objeto, "BORRAR")
                                TOOLTIPS(Objeto, "debe ingresar un texto")
                        End Select
                    Case "YEAR"
                        Select Case Verificar.Length = 4
                            Case True
                                Select Case IsNumeric(Verificar)
                                    Case True
                                        Select Case Verificar > 2000
                                            Case True
                                                Colorearobjetos(Objeto, "CORRECTO")
                                            Case False
                                                Colorearobjetos(Objeto, "BORRAR")
                                                TOOLTIPS(Objeto, "El año debe ser superior al 2000")
                                        End Select
                                    Case False
                                        Colorearobjetos(Objeto, "BORRAR")
                                        TOOLTIPS(Objeto, "Verifique de solo ingresar números")
                                End Select
                            Case False
                                Colorearobjetos(Objeto, "BORRAR")
                                TOOLTIPS(Objeto, "Ingrese el año en formato 20XX")
                        End Select
                    Case "FECHA"
                        Select Case Verificar.Length = 10
                            Case True
                                Select Case IsDate(Verificar)
                                    Case True
                                        Select Case Convert.ToDateTime(Verificar).Year > 1999
                                            Case True
                                                Colorearobjetos(Objeto, "CORRECTO")
                                            Case False
                                                Colorearobjetos(Objeto, "BORRAR")
                                                TOOLTIPS(Objeto, "El año debe ser superior al 2000")
                                        End Select
                                    Case False
                                        Colorearobjetos(Objeto, "BORRAR")
                                        TOOLTIPS(Objeto, "Debe ingresar la fecha en formato dd/mm/aaaa por ejemplo " & Date.Now.ToShortDateString)
                                End Select
                            Case False
                                Colorearobjetos(Objeto, "BORRAR")
                                TOOLTIPS(Objeto, "Debe ingresar la fecha en formato dd/mm/aaaa por ejemplo " & Date.Now.ToShortDateString)
                        End Select
                    Case "ORGANISMO"
                        Select Case Verificar.Length = 4
                            Case True
                                Select Case IsNumeric(Verificar)
                                    Case True
                                        Colorearobjetos(Objeto, "CORRECTO")
                                    Case False
                                        Colorearobjetos(Objeto, "BORRAR")
                                        TOOLTIPS(Objeto, "Debe ingresar el número del Organismo, el cual contiene 4 números")
                                End Select
                                TOOLTIPS(Objeto, "Debe ingresar el número del Organismo, el cual contiene 4 números")
                        End Select
                    Case Else
                        Colorearobjetos(Objeto, "BORRAR")
                        Objeto.text = Objeto.text & " Verificar control utilizado "
                End Select
            Case False
                Select Case Verificar = "TEXTO"
                    Case True
                        Colorearobjetos(Objeto, "BORRAR")
                        Objeto.text = Objeto.text & " Verificar control utilizado "
                    Case False
                        Colorearobjetos(Objeto, "VACIO")
                End Select
        End Select
    End Sub

    Public Function Verificacionexistenciaexpediente(ByVal claveunica As String) As String
        Dim borrar As New DataTable
        Dim consultasql As String = ""
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Claveunica", claveunica)
        consultasql = "Select * from expediente where Clave_expediente=@claveunica"
        SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, borrar, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Select Case borrar.Rows.Count
            Case > 0
                Return " ¿Realmente desea MODIFICAR este expediente EXISTENTE?" & vbCrLf & "Expte:" & borrar.Rows(0).Item("Expediente_N").ToString & vbCrLf & "Detalle:" & borrar.Rows(0).Item("Detalle").ToString & vbCrLf & "Por $" & borrar.Rows(0).Item("Monto").ToString
            Case Else
                Return "¿Confirma que desea AGREGAR este Expediente?"
        End Select
    End Function

    Public Sub SIGUIENTECONTROL(ByRef WINDOWS As Form, ByRef CONTROL As System.Object, ByRef E As System.Windows.Forms.KeyEventArgs)
        Select Case E.KeyValue = Keys.Enter
            Case True
                E.SuppressKeyPress = True
                WINDOWS.SelectNextControl(CONTROL, True, True, True, True)
            Case False
        End Select
    End Sub

    Public Sub ControlnumeroWPF(ByRef CONTROL As Object, ByRef E As Windows.Input.KeyEventArgs)
        Select Case E.Key
            Case Windows.Input.Key.Enter
                E.Handled = True
                SendKeys.Send("{TAB}")
            Case Windows.Input.Key.Back
                E.Handled = True
                If CONTROL.Number <= 9 Then
                    CONTROL.Number = 0
                Else
                    Dim PREVIO As Decimal = CONTROL.Number
                    CONTROL.Number = CType(PREVIO.ToString.Substring(0, PREVIO.ToString.Length - 1), Decimal)
                End If
        End Select
    End Sub

    Public Sub SIGUIENTECONTROLWPF(ByRef CONTROL As System.Object, ByRef E As Windows.Input.KeyEventArgs)
        Select Case E.Key = Windows.Input.Key.Enter
            Case True
                E.Handled = True
                SendKeys.Send("{TAB}")
            Case False
        End Select
    End Sub

    Public Sub TOOLTIPS(ByVal sender As Object, ByVal textotool As String)
        Try
            Select Case sender.GetType
                Case Is = GetType(Button)
                    Me.MessageTooltip.Show(textotool, sender)
                Case Is = GetType(ToolStrip)
                    Me.MessageTooltip.Show(textotool, sender)
                Case Is = GetType(TextBox)
                    ' Me.MessageTooltip.Show(textotool, sender)
                    ' Me.MessageTooltip.SetToolTip(sender, sender.tooltiptext)
                Case Else
                    Me.MessageTooltip.SetToolTip(sender, sender.tooltiptext)
            End Select
        Catch ex As Exception
            'ERRORES(1, ex.Message & vbCrLf & "  " & sender.GetType.ToString, Reflection.MethodBase.GetCurrentMethod.Name, sender.GetType.ToString)
        End Try
    End Sub

    Public Sub controldeguiones(ByRef WINDOWS As Form, ByRef CONTROL As System.Object, ByRef E As System.Windows.Forms.KeyEventArgs)
        Select Case E.KeyValue
            Case = Keys.Divide
                E.SuppressKeyPress = True
                WINDOWS.SelectNextControl(CONTROL, True, True, True, True)
            Case = Keys.OemMinus
                E.SuppressKeyPress = True
                WINDOWS.SelectNextControl(CONTROL, True, True, True, True)
            Case = Keys.Subtract
                E.SuppressKeyPress = True
                WINDOWS.SelectNextControl(CONTROL, True, True, True, True)
        End Select
    End Sub

    Public Sub COLOREARFUNCIONES(ByRef TEXTOAEVALUAR As String, ByRef FILAAEVALUAR As DataGridViewRow)
        Dim color1 As New Color
        Dim color2 As New Color
        Dim color3 As New Color
        Dim color4 As New Color
        Dim color5 As New Color
        ''terra1
        'color1 = system.drawing.Color.FromArgb(255, 238, 217, 189)
        'color1 = system.drawing.Color.FromArgb(255, 231, 184, 125)
        'color1 = system.drawing.Color.FromArgb(255, 167, 94, 91)
        'color1 = system.drawing.Color.FromArgb(255, 167, 210, 196)
        'color1 = system.drawing.Color.FromArgb(255, 63, 112, 131)
        'terra2
        'color1 = system.drawing.Color.FromArgb(255, 212, 126, 79)
        'color2 = system.drawing.Color.FromArgb(255, 236, 157, 104)
        'color3 = system.drawing.Color.FromArgb(255, 238, 189, 129)
        'color4 = system.drawing.Color.FromArgb(255, 238, 183, 100)
        'color5 = system.drawing.Color.FromArgb(255, 227, 148, 67)
        ''terra3
        'color1 = system.drawing.Color.FromArgb(255, 109, 50, 50)
        'color2 = system.drawing.Color.FromArgb(255, 143, 128, 64)
        'color3 = system.drawing.Color.FromArgb(255, 201, 191, 38)
        'color4 = system.drawing.Color.FromArgb(255, 198, 110, 31)
        'color5 = system.drawing.Color.FromArgb(255, 203, 142, 14)
        '#AD4B00
        '#AD6200
        '#AD7700
        '#AD8B00
        '#AD9C00
        '#ACAD00
        '#D38300
        '#D3B200
        '#B0D300
        '#1AD300
        '#00D35B
        '#00D3CE
        'terra4
        color1 = ColorTranslator.FromHtml("#D38300")
        color2 = ColorTranslator.FromHtml("#D3B200")
        color3 = ColorTranslator.FromHtml("#B0D300")
        color4 = ColorTranslator.FromHtml("#1AD300")
        color5 = ColorTranslator.FromHtml("#00D35B")
        Select Case True
            Case TEXTOAEVALUAR.Contains("DIRECTOR")
                FILAAEVALUAR.DefaultCellStyle.BackColor = color1
            Case TEXTOAEVALUAR.Contains("TESOR")
                FILAAEVALUAR.DefaultCellStyle.BackColor = color2
            Case TEXTOAEVALUAR.Contains("JEFE")
                FILAAEVALUAR.DefaultCellStyle.BackColor = color3
            Case TEXTOAEVALUAR = ("DELEGADO FISCAL")
                FILAAEVALUAR.DefaultCellStyle.BackColor = color4
            Case TEXTOAEVALUAR = ("DELEGADO FISCAL AUDITOR")
                FILAAEVALUAR.DefaultCellStyle.BackColor = color5
            Case TEXTOAEVALUAR.Contains("SIN FUNCION")
                FILAAEVALUAR.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255)
            Case Else
                FILAAEVALUAR.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255)
        End Select
        Select Case FILAAEVALUAR.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255)
            Case True
                FILAAEVALUAR.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0)
            Case False
                'METODO 1 DE CONTRASTING COLOR
                FILAAEVALUAR.DefaultCellStyle.ForeColor = GetContrastColor(FILAAEVALUAR.DefaultCellStyle.BackColor)
                'METODO 2 DE CONTRASTING COLOR
                'FILAAEVALUAR.DefaultCellStyle.ForeColor = CalcContrastColor(FILAAEVALUAR.DefaultCellStyle.BackColor)
        End Select
    End Sub

    'Public Sub Coloreartipodeobjeto(ByVal Ventana As Form, ByVal Valores As Integer, ByVal Tipodeobjeto As Type)
    '    Dim color1 As New Color
    '    Dim color2 As New Color
    '    Dim color3 As New Color
    '    Dim color4 As New Color
    '    Dim color5 As New Color
    '    ''terra1
    '    'color1 = system.drawing.Color.FromArgb(255, 238, 217, 189)
    '    'color1 = system.drawing.Color.FromArgb(255, 231, 184, 125)
    '    'color1 = system.drawing.Color.FromArgb(255, 167, 94, 91)
    '    'color1 = system.drawing.Color.FromArgb(255, 167, 210, 196)
    '    'color1 = system.drawing.Color.FromArgb(255, 63, 112, 131)
    '    'terra2
    '    'color1 = system.drawing.Color.FromArgb(255, 212, 126, 79)
    '    'color2 = system.drawing.Color.FromArgb(255, 236, 157, 104)
    '    'color3 = system.drawing.Color.FromArgb(255, 238, 189, 129)
    '    'color4 = system.drawing.Color.FromArgb(255, 238, 183, 100)
    '    'color5 = system.drawing.Color.FromArgb(255, 227, 148, 67)
    '    ''terra3
    '    'color1 = system.drawing.Color.FromArgb(255, 109, 50, 50)
    '    'color2 = system.drawing.Color.FromArgb(255, 143, 128, 64)
    '    'color3 = system.drawing.Color.FromArgb(255, 201, 191, 38)
    '    'color4 = system.drawing.Color.FromArgb(255, 198, 110, 31)
    '    'color5 = system.drawing.Color.FromArgb(255, 203, 142, 14)
    '    '#AD4B00
    '    '#AD6200
    '    '#AD7700
    '    '#AD8B00
    '    '#AD9C00
    '    '#ACAD00
    '    '#D38300
    '    '#D3B200
    '    '#B0D300
    '    '#1AD300
    '    '#00D35B
    '    '#00D3CE
    '    'terra4
    '    color1 = ColorTranslator.FromHtml("#D38300")
    '    color2 = ColorTranslator.FromHtml("#D3B200")
    '    color3 = ColorTranslator.FromHtml("#B0D300")
    '    color4 = ColorTranslator.FromHtml("#1AD300")
    '    color5 = ColorTranslator.FromHtml("#00D35B")
    '    Select Case True
    '        Case TEXTOAEVALUAR.Contains("DIRECTOR")
    '            FILAAEVALUAR.DefaultCellStyle.BackColor = color1
    '        Case TEXTOAEVALUAR.Contains("TESOR")
    '            FILAAEVALUAR.DefaultCellStyle.BackColor = color2
    '        Case TEXTOAEVALUAR.Contains("JEFE")
    '            FILAAEVALUAR.DefaultCellStyle.BackColor = color3
    '        Case TEXTOAEVALUAR = ("DELEGADO FISCAL")
    '            FILAAEVALUAR.DefaultCellStyle.BackColor = color4
    '        Case TEXTOAEVALUAR = ("DELEGADO FISCAL AUDITOR")
    '            FILAAEVALUAR.DefaultCellStyle.BackColor = color5
    '        Case TEXTOAEVALUAR.Contains("SIN FUNCION")
    '            FILAAEVALUAR.DefaultCellStyle.BackColor = system.drawing.Color.FromArgb(255, 255, 255, 255)
    '        Case Else
    '            FILAAEVALUAR.DefaultCellStyle.BackColor = system.drawing.Color.FromArgb(255, 255, 255, 255)
    '    End Select
    '    Select Case FILAAEVALUAR.DefaultCellStyle.BackColor = system.drawing.Color.FromArgb(255, 255, 255, 255)
    '        Case True
    '            FILAAEVALUAR.DefaultCellStyle.ForeColor = system.drawing.Color.FromArgb(255, 0, 0, 0)
    '        Case False
    '            'METODO 1 DE CONTRASTING COLOR
    '            FILAAEVALUAR.DefaultCellStyle.ForeColor = GetContrastColor(FILAAEVALUAR.DefaultCellStyle.BackColor)
    '            'METODO 2 DE CONTRASTING COLOR
    '            'FILAAEVALUAR.DefaultCellStyle.ForeColor = CalcContrastColor(FILAAEVALUAR.DefaultCellStyle.BackColor)
    '    End Select
    'End Sub
    Public Shared Sub Colorearobjetos(ByRef Objeto As Object, ByVal Textodescriptivo As String)
        Select Case Textodescriptivo.ToUpper
            Case = "AGREGAR"
                Objeto.BackColor = System.Drawing.Color.FromArgb(255, 105, 178, 122)
                Objeto.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0)
            Case = "MODIFICAR"
                Objeto.BackColor = System.Drawing.Color.FromArgb(255, 205, 255, 214)
                Objeto.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0)
            Case = "BORRAR"
                Objeto.BackColor = System.Drawing.Color.FromArgb(255, 255, 176, 184)
                Objeto.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0)
            Case = "CONSULTAR"
                Objeto.BackColor = System.Drawing.Color.FromArgb(255, 195, 204, 120)
                Objeto.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0)
            Case = "VISTA PREVIA"
                Objeto.BackColor = System.Drawing.Color.FromArgb(255, 175, 215, 255)
                Objeto.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0)
            Case = "IMPRIMIR"
                Objeto.BackColor = System.Drawing.Color.FromArgb(255, 255, 174, 168)
                Objeto.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0)
            Case = "VACIO"
                Objeto.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255)
                Objeto.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0)
            Case = "CORRECTO"
                Objeto.BackColor = System.Drawing.Color.FromArgb(255, 229, 245, 232)
                Objeto.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0)
            Case = ""
        End Select
    End Sub

    Public Shared Sub Colorearobjetoskrypton(ByRef Objeto As ComponentFactory.Krypton.Toolkit.KryptonTextBox, ByVal Textodescriptivo As String)
        Select Case Textodescriptivo.ToUpper
            Case = "AGREGAR"
                Objeto.BackColor = System.Drawing.Color.FromArgb(255, 105, 178, 122)
                Objeto.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0)
            Case = "MODIFICAR"
                Objeto.BackColor = System.Drawing.Color.FromArgb(255, 205, 255, 214)
                Objeto.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0)
            Case = "BORRAR"
                Objeto.BackColor = System.Drawing.Color.FromArgb(255, 255, 176, 184)
                Objeto.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0)
            Case = "CONSULTAR"
                Objeto.BackColor = System.Drawing.Color.FromArgb(255, 195, 204, 120)
                Objeto.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0)
            Case = "VISTA PREVIA"
                Objeto.BackColor = System.Drawing.Color.FromArgb(255, 175, 215, 255)
                Objeto.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0)
            Case = "IMPRIMIR"
                Objeto.BackColor = System.Drawing.Color.FromArgb(255, 255, 174, 168)
                Objeto.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0)
            Case = ""
        End Select
    End Sub

    Public Function GetContrastColor(ByVal clr As Color) As Color
        Const TOLERANCE As Integer = &H80
        Dim crBg As Integer = ColorTranslator.ToWin32(clr)
        If Math.Abs(((crBg) And &HFF) - &H80) <= TOLERANCE AndAlso Math.Abs(((crBg >> 8) And &HFF) - &H80) <= TOLERANCE AndAlso Math.Abs(((crBg >> 16) And &HFF) - &H80) <= TOLERANCE Then
            Return ColorTranslator.FromWin32((&H7F7F7F + crBg) And &HFFFFFF)
            ' Return system.drawing.Color.FromArgb(255, 0, 0, 0)
        Else
            Return ColorTranslator.FromWin32(crBg Xor &HFFFFFF)
        End If
    End Function

    Private Function CalcContrastColor(ByVal clr As Color) As Color
        Const TOLERANCE As Integer = &H40
        Dim crBg As Integer = ColorTranslator.ToWin32(clr)
        If ((Math.Abs(((crBg And 255) _
                        - 128)) <= TOLERANCE) AndAlso ((Math.Abs((((crBg + 8) And 255) - 128)) <= TOLERANCE) AndAlso (Math.Abs((((crBg + 16) And 255) - 128)) <= TOLERANCE))) Then
            Return ColorTranslator.FromWin32((8355711 + crBg) And 16777215)
        Else
            Return ColorTranslator.FromWin32(crBg Xor 16777215)
        End If
        'The operator should be an XOR ^ instead of an OR, but not available in CodeDOM
    End Function

    Public Sub Expedientesdividir(ByVal Stringoriginal As String, ByRef stringorganismo As String, ByRef stringnumero As String, ByRef stringyear As String)
        Dim separador As String()
        Strings.stringorganismo = ""
        Strings.stringnumero = ""
        stringyear = ""
        Select Case Stringoriginal.Length > 8
            Case True
                separador = Split(Stringoriginal, "-")
                Strings.stringorganismo = separador(0)
                separador = Split(separador(1), "/")
                Strings.stringnumero = separador(0)
                Strings.stringyear = separador(1)
            Case False
        End Select
    End Sub

    Public Sub divisoruniversal(ByVal Stringoriginal As String, ByRef stringinicial As String, ByRef stringyear As String)
        Dim separador As String()
        stringinicial = ""
        stringyear = ""
        Select Case Stringoriginal.Length > 3
            Case True
                If Stringoriginal.Contains("/") Then
                    If Not Stringoriginal.StartsWith("/") Then
                        separador = Split(Stringoriginal, "/")
                        stringinicial = separador(0)
                        If separador.Count = 2 Then
                            Try
                                Select Case separador(1).Length = 4
                                    Case True
                                        stringyear = separador(1)
                                    Case False
                                        stringyear = "20" & separador(1)
                                End Select
                            Catch ex As Exception
                                stringinicial = Stringoriginal
                            End Try
                        Else
                            stringinicial = Stringoriginal
                        End If
                    Else
                        stringinicial = "0"
                        stringyear = Date.Now.Year
                    End If
                Else
                    stringinicial = "0"
                    stringyear = Date.Now.Year
                End If
            Case False
                stringinicial = Stringoriginal
                stringyear = ""
        End Select
    End Sub

    Public Sub Divisordecodigo(ByVal Stringoriginal As String, ByRef Stringorganismo As String, ByRef Stringexptenum As String, ByRef Stringyear As String)
        If Stringoriginal.Length = 13 Then
            Stringorganismo = Stringoriginal.Substring(4, 4)
            Stringexptenum = Stringoriginal.Substring(9, 4)
            Stringyear = Stringoriginal.Substring(0, 4)
        Else
            MessageBox.Show("El código de expediente seleccionado contiene un error " & vbCrLf & Stringoriginal)
        End If
    End Sub

    Public Function Verificacionasociacionpedidofondo(ByVal claveunica As String) As String
        Dim borrar As New DataTable
        Dim consultasql As String = ""
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Claveunica", claveunica)
        consultasql = "Select * from expediente where Clave_expediente=@claveunica and not isnull(Clave_pedidofondo)"
        SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, borrar, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Select Case borrar.Rows.Count
            Case > 0
                Return " El Expte:" & borrar.Rows(0).Item("Expediente_N").ToString & vbCrLf & "Desc.:" & borrar.Rows(0).Item("Detalle").ToString & vbCrLf & "NO PUEDE SER BORRADO" & vbCrLf & "por estar asociado al pedido de fondos N" &
                    Verificadorcodigopedidodefondo(borrar.Rows(0).Item("clave_pedidofondo").ToString)
            Case Else
                Return ""
        End Select
    End Function

    Public Function Verificadorcodigopedidodefondo(ByVal clavepedidofondo As String) As String
        If clavepedidofondo.ToString.Length > 10 Then
            'stringorganismo = clavepedidofondo.ToString.Substring(4, 4)
            'Stringexptenum = clavepedidofondo.ToString.Substring(9, 4)
            'stringyear = clavepedidofondo.ToString.Substring(0, 4)
            Return clavepedidofondo.ToString.Substring(9, 4) & "/" & clavepedidofondo.ToString.Substring(0, 4)
        Else
            ' MessageBox.Show("El código seleccionado contiene un error " & vbCrLf & clavepedidofondo)
            Return ""
        End If
    End Function

    Public Function Unificadordecodigo(ByVal Stringoriginal As String, ByVal Tipo As String) As String
        If Stringoriginal.Length = 13 Then
            Select Case Tipo.ToUpper
                Case "PEDIDOFONDO"
                    Return CType(Stringoriginal.Substring(9, 4), Integer) & "/" & Stringoriginal.Substring(0, 4)
                Case "EXPEDIENTE"
                    Return CType(Stringoriginal.Substring(4, 4), Integer) & "-" & CType(Stringoriginal.Substring(9, 4), Integer) & "/" & Stringoriginal.Substring(0, 4)
            End Select
        Else
        End If
    End Function

    '0-FIN------------------------------Subs y funciones generales de conversion---------------------------------------
    '****************************************************************************************************************
    '0-Comienzo-----------------------------Subs y funciones privadas de la ventana---------------------------------------
    '0-FIN------------------------------Subs y funciones privadas de la ventana---------------------------------------
    Private Sub Inicio_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        SQLPARAMETROS_MULTIPLE(Autorizaciones.Organismotabla, "select Proveedor,CUIT from proveedores group by proveedor order by proveedor asc ", Autocompletetables.Proveedores, True, System.Reflection.MethodBase.GetCurrentMethod.Name)
        '  recargardatosprincipales()
        'códigos sistema de fondos y valores
        SQLPARAMETROS_MULTIPLE(Autorizaciones.Organismotabla, "select Codigo,Descripcion from SistemaFondosyvaloresCodif where tipo='Cod.Orden' order by codigo asc", Autocompletetables.SFyV_Codorden, True, System.Reflection.MethodBase.GetCurrentMethod.Name)
        SQLPARAMETROS_MULTIPLE(Autorizaciones.Organismotabla, "select Codigo,Descripcion from SistemaFondosyvaloresCodif where tipo='Clasefondo' order by codigo asc", Autocompletetables.SFyV_CodClasefondo, True, System.Reflection.MethodBase.GetCurrentMethod.Name)
        SQLPARAMETROS_MULTIPLE(Autorizaciones.Organismotabla, "select Codigo,Descripcion from SistemaFondosyvaloresCodif where tipo='Codigoimputacion' order by codigo asc", Autocompletetables.SFyV_Codimputacion, True, System.Reflection.MethodBase.GetCurrentMethod.Name)
        'PLAN DE CUENTAS DEL TESORO
        SQLPARAMETROS_MULTIPLE("contaduria_usuarios", "Select CONCAT(COD_GRAL,'-', COD_DETALLADO) as 'COD', DESCRIPCION, CAT_GENERAL, CAT_DETALLE from plan_cuentas_tesoro order by COD_GRAL, COD_DETALLADO ", Autocompletetables.Plan_Cuenta_Tesoro, True, System.Reflection.MethodBase.GetCurrentMethod.Name)
        'CLASE DE FONDOS
        SQLPARAMETROS_MULTIPLE(Autorizaciones.Organismotabla, "select clase_fondo from pedido_fondos group by clase_fondo", Autocompletetables.Clasefondo, True, System.Reflection.MethodBase.GetCurrentMethod.Name)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@tabla", "reportebanco")
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@table_schema", Autorizaciones.Organismotabla)
        SQLPARAMETROS_MULTIPLE(Autorizaciones.Organismotabla, "Select column_name  as 'Columnas' FROM information_schema.columns WHERE  table_name = @tabla  AND table_schema = @table_schema", Autocompletetables.Tabla_detallada, False, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Dim callback As New System.Threading.TimerCallback(AddressOf Conexion_verificartoolstrip)
        ' timerx1 = New System.Threading.Timer(callback, vbNull, 1300, Timeout.Infinite)
        '    Dim callback2 As New System.Threading.TimerCallback(AddressOf Conexion_verificartoolstrip2)
        '  timerx2 = New System.Threading.Timer(callback2, vbNull, 1400, Timeout.Infinite)
        Presentacion.MdiParent = Me
        Presentacion.Show()
        If Informatica_Servicioadministrativo.Visible Then
            Informatica_Servicioadministrativo.Visible = False
        End If
        'CAMBIODECOLOR(Servidor1toolstrip_label.Name)
        'CAMBIODECOLOR(Servidor2toolstrip_label.Name)
    End Sub

    Public Sub Recargardatosprincipales()
        SQLPARAMETROS(Autorizaciones.Organismotabla, "select clase_fondo from pedido_fondos group by clase_fondo", Autocompletetables.Clasefondo, System.Reflection.MethodBase.GetCurrentMethod.Name)
        SQLPARAMETROS(Autorizaciones.Organismotabla, "select Cuenta,Descripcion,caracter From Cuenta_Bancaria  order by cuenta asc ", Autocompletetables.Cuentas, System.Reflection.MethodBase.GetCurrentMethod.Name)
    End Sub

    'Botones de llamados a menu
    Private Sub Menu_botonexpedientescontabilidad_Click(sender As Object, e As EventArgs)
        MENULLAMADO(Contabilidad_expedientes)
    End Sub

    Private Sub Movimientos_Menuboton_Click(sender As Object, e As EventArgs)
        MENULLAMADO(Tesoreria_Movimientos)
    End Sub

    Private Sub DatosdelUsuario_Click(sender As Object, e As EventArgs)
        MENULLAMADO(Datospersonales)
    End Sub

    Private Sub Menu_botonexpedientesMEyS_Click(sender As Object, e As EventArgs)
        MENULLAMADO(MesadeEntradas_expedientes)
    End Sub

    Private Sub Cerrarsesion_boton_Click(sender As Object, e As EventArgs)
        INGRESO.Show()
    End Sub

    Private Sub Liquidacion_Menuboton_Click(sender As Object, e As EventArgs)
        MENULLAMADO(Retenciones)
    End Sub

    Private Sub Tamaniomenu_Click(sender As Object, e As EventArgs)
        'Select Case RibbonMenu.Size.Height
        '    Case > 53
        '        RibbonMenu.Size = New Size(RibbonMenu.Width, 53)
        '        Tamaniomenu.Text = "Maximizar"
        '    Case Else
        '        RibbonMenu.Size = New Size(RibbonMenu.Width, 120)
        '        Tamaniomenu.Text = "Minimizar"
        'End Select
    End Sub

    Private Sub Tesoreriamenu_Expedientes_Click(sender As Object, e As EventArgs) Handles Tesoreriamenu_Expedientes.Click
        Select Case Autorizaciones.Usuario.Rows(0).Item("nivel")
            Case Is > 59
                Tesoreria_Expedientes.MESADEENTRADAS()
            Case Else
                MENULLAMADO(Tesoreria_Expedientes)
        End Select
    End Sub

    Private Sub Tesoreriamenu_PedidodeFondos_Click(sender As Object, e As EventArgs) Handles Tesoreriamenu_PedidodeFondos.Click
        MENULLAMADO(Tesoreria_Pedidofondos)
    End Sub

    Private Sub Tesoreriamenu_Liquidaciones_Click(sender As Object, e As EventArgs) Handles Tesoreriamenu_Liquidaciones.Click
    End Sub

    Private Sub Tesoreriamenu_Movimientos_Click(sender As Object, e As EventArgs) Handles Tesoreriamenu_Movimientos.Click
        MENULLAMADO(Tesoreria_Movimientos)
    End Sub

    Private Sub Tesoreriamenu_CargaCheques_Click(sender As Object, e As EventArgs)
        '  MENULLAMADO(Cheques)
    End Sub

    Private Sub Tesoreriamenu_ParteDiario_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Tesoreriamenu_CuentaBancaria_Click(sender As Object, e As EventArgs) Handles Tesoreriamenu_CuentaBancaria.Click
        MENULLAMADO(Cuentabancaria)
    End Sub

    Private Sub Tesoreriamenu_Rendiciones_Click(sender As Object, e As EventArgs)
        MENULLAMADO(Tesoreria_Rendiciones)
    End Sub

    Private Sub Usuariomenu_Usuario_Click(sender As Object, e As EventArgs) Handles Usuariomenu_Usuario.Click
        MENULLAMADO(Datospersonales)
    End Sub

    Public Sub INICIO_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyValue
            'Case = Keys.F5
            '    If Control.ModifierKeys = (Keys.Control) Then
            '        'recargar las autorizaciones
            '        MsgBox("Se van a consultar nuevamente las autorizaciones otorgadas")
            '        recargar_autorizaciones()
            '        Menusautorizados()
            '    End If
            'Case = Keys.F7
            '    '    Select Case NIVELDESEGURIDAD.NIVELDESEGURIDADINTERNO = 0
            '    '        Case True
            '    '            Dim rect As System.Drawing.Rectangle = Me.ClientRectangle
            '    '            Dim bmp As New Bitmap(Me.Width, Me.Height)
            '    '            Dim g As Graphics = Graphics.FromImage(bmp)
            '    '            g.CopyFromScreen(Me.Location, New Point(0, 0), Me.Size)
            '    '            'por un problema de error generico de gdi+ se coloca un segundo bitmap que luego es descartado
            '    '            bmp.Save("c:\MANUAL\" & My.Application.Info.Title & "\" & Ultimaventanallamada & "-" & Date.Now.Second & ".JPG", ImageFormat.Jpeg)
            '    '            'bmp.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Dropbox\mero\MANUAL\" & My.Application.Info.Title & "\IMAGENES\" & Ultimaventanallamada & ".JPG")
            '    '            'bmp.Dispose()
            '    '        Case Else
                '    End Select
            Case = Keys.F8
                Me.WindowState = FormWindowState.Normal
                Me.Size = New Size(1366, 1024)
                'Case = Keys.F12
                '    My.Computer.Clipboard.SetText(SQLTEXT)
            Case Else
        End Select
    End Sub

    Private Sub Contabilidadmenu_Expedientes_Click(sender As Object, e As EventArgs) Handles Contabilidadmenu_Expedientes.Click
        MENULLAMADO(Contabilidad_expedientes)
    End Sub

    Private Sub Mesaentradasmenu_Expedientes_Click(sender As Object, e As EventArgs) Handles Mesaentradasmenu_Expedientes.Click
        'Tesoreria_Expedientes.MESADEENTRADAS()
        MENULLAMADO(Tesoreria_retencionesV2)
        'MENULLAMADO(Suministros_expedientes)
    End Sub

    Private Sub EstadoServidores_Menu_Click(sender As Object, e As EventArgs) Handles EstadoServidores_Menu.Click
        MENULLAMADO(Informatica_Servidor)
    End Sub

    Private Sub Contabilidadmenu_Ordenpago_Click(sender As Object, e As EventArgs) Handles Contabilidadmenu_Ordenpago.Click
        MENULLAMADO(Contabilidad_listadoordenespago)
        '   Dim orden As New Ordendepago
        '     orden.cargadatossss()
    End Sub

    Private Sub Tesoreriamenu_Ajustes_Click(sender As Object, e As EventArgs)
        MENULLAMADO(Tesoreria_AjustesMFyV)
    End Sub

    Private Sub StatusStrip1_MouseUp(sender As Object, e As MouseEventArgs) Handles StatusSiciyf.MouseUp
        Mousederecho_admin(Me, e)
    End Sub

    Private Sub Mousederecho_admin(ByRef CONTROL As System.Object, ByRef MOUSE As System.Windows.Forms.MouseEventArgs)
        If MOUSE.Button <> Windows.Forms.MouseButtons.Right Then Return
        Dim cms = New ContextMenuStrip
        Select Case Autorizaciones.Usuario.Rows(0).Item("nivel").ToString
            Case Is = "0"
                Select Case Debugging.Estadodedepuracion
                    Case True
                        Dim item1 = cms.Items.Add("Volver al Modo Normal")
                        item1.Tag = 0
                        ' AddHandler item2.Click, AddressOf MENUCONTEXTUAL
                        AddHandler item1.Click, AddressOf MenuContextualadmin
                    Case False
                        Dim item1 = cms.Items.Add("Mostrar modo Debugging")
                        item1.Tag = 0
                        ' AddHandler item2.Click, AddressOf MENUCONTEXTUAL
                        AddHandler item1.Click, AddressOf MenuContextualadmin
                End Select
                Dim item2 = cms.Items.Add("Cambiar de Ejercicio Financiero")
                item2.Tag = 1
                AddHandler item2.Click, AddressOf MenuContextualadmin
                Dim item3 = cms.Items.Add("Nuevo Usuario")
                item3.Tag = 2
                AddHandler item3.Click, AddressOf MenuContextualadmin
                Dim item4 = cms.Items.Add("Cambio de Base de datos")
                item4.Tag = 3
                AddHandler item4.Click, AddressOf MenuContextualadmin
                Dim item5 = cms.Items.Add("Cambio Modo de ventana")
                item5.Tag = 4
                AddHandler item5.Click, AddressOf MenuContextualadmin
                'Dim item3 = cms.Items.Add("VERIFICAR ADICIONALES")
                'item3.Tag = 2
                'AddHandler item3.Click, AddressOf MENUCONTEXTUAL
                '-- etc
                '..
            Case Is = "99"
            Case Else
        End Select
        Dim item990 = cms.Items.Add("Cambio de Usuario")
        item990.Tag = 990
        AddHandler item990.Click, AddressOf MenuContextualadmin
        Dim item991 = cms.Items.Add("Recargar autorizaciones")
        item991.Tag = 991
        AddHandler item991.Click, AddressOf MenuContextualadmin
        cms.Show(New Point(MOUSE.Location.X, MOUSE.Location.Y + Me.Height))
    End Sub

    Private Sub MenuContextualadmin(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)
        Select Case selection
            Case Is = 0
                Debugging.Estadodedepuracion = Not (Debugging.Estadodedepuracion)
            Case Is = 1
                Informatica_Servicioadministrativo.Cargadeopciones_ServAdm("BASE DE DATOS")
            Case Is = 2
                Usuarios_nuevousuario.ShowDialog()
            Case Is = 3
                Informatica_Servicioadministrativo.Cargadeopciones_ServAdm("CONEXION")
            Case Is = 4
                Debugging.Ventanadentro = Not Debugging.Ventanadentro
            Case Is = 990
                'recargar las autorizaciones
                MsgBox("Cambio de usuario")
                INGRESO.Show()
            Case Is = 991
                'recargar las autorizaciones
                MsgBox("Se van a consultar nuevamente las autorizaciones otorgadas")
                Recargar_autorizaciones(Autorizaciones.Usuario.Rows(0).Item("usuario"))
                Menusautorizados()
        End Select
        '-- etc
    End Sub

    Private Sub ToolStripSplitButton1_ButtonClick(sender As Object, e As EventArgs) Handles ToolStripSplitButton1.ButtonClick
        ''InstallUpdateSyncWithInfo()
        'Dim PROVEEDORBASICO As New Proveedor
        'Dim regg As regproveedores() = Respuestaproveedores.devolverregistroproveedor("")
        'DialogDialogo_Datagridview.Carga_General(regg.ToDataTable, "", "ok", "Cancelar")
        'If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) And DialogDialogo_Datagridview.Datosdialogo_datagridview.SelectedRows.Count = 1 Then
        '    For Each ITEM As regproveedores In regg
        '        PROVEEDORBASICO.updateproveedorregistro(ITEM)
        '    Next
        '    'sender.Rows(sender.CurrentCell.RowIndex).Cells.Item(sender.CurrentCell.ColumnIndex).Value = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value
        'Else
        'End If
    End Sub

    Private Sub Tamaniomenu_CanvasChanged(sender As Object, e As EventArgs)
    End Sub

    'Private Sub RibbonMenu_Enter(sender As Object, e As EventArgs) Handles RibbonMenu.Enter
    '    RibbonMenu.Height = 99
    'End Sub
    Private Sub RibbonMenu_MouseHover(sender As Object, e As EventArgs) Handles RibbonMenu.MouseHover, RibbonMenu.MouseEnter
        Timer1.Stop()
        RibbonMenu.Height = 108
        Timer_menu.Stop()
        'Me.ActiveMdiChild.ResumeLayout()
    End Sub

    Private Sub RibbonMenu_MouseLeave(sender As Object, e As EventArgs) Handles RibbonMenu.MouseLeave
        'activar timer
        'Dim timerdescanso As New Timer
        'With timerdescanso
        '    .Interval = 30
        '    .Enabled = True
        '    .Start()
        '    Application.DoEvents()
        'End With
        'For i As Integer = 0 To 45 * 1
        '    System.Threading.Thread.Sleep(10)
        '    Application.DoEvents()
        'Next
        'If Me.ActiveControl.Name = CType(sender, Control).Name Then
        'Else
        Dim cerrar As Boolean = True
        If Tesoreriamenu_Reportes2.Selected Then
            cerrar = False
            Timer1.Stop()
        End If
        If Tesoreriamenu_Liquidaciones.Selected Then
            cerrar = False
            Timer1.Stop()
        End If
        If Tesoreriamenu_Conciliación.Selected Then
            cerrar = False
            Timer1.Stop()
        End If
        If Tesoreriamenu_CuentaBancaria.Selected Then
            cerrar = False
            Timer1.Stop()
        End If
        If cerrar Then
            'While RibbonMenu.Height > 27
            '    RibbonMenu.Height += -1
            '    Threading.Thread.Sleep(100)
            'End While
            Timer_menu.Enabled = True
            Timer_menu.Start()
            'RibbonMenu.Height = 27
        End If
        ' End If
        'timerdescanso.Dispose()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        RibbonMenu.Height = 27
        Timer1.Stop()
        'If RibbonMenu.Height >= 27 Then
        '    RibbonMenu.Height += -5
        'Else
        '    Timer1.Stop()
        '    'Me.ActiveMdiChild.ResumeLayout()
        'End If
    End Sub

    Private Sub Timer_menu_Tick(sender As Object, e As EventArgs) Handles Timer_menu.Tick
        Timer1.Enabled = True
        Timer1.Start()
        Timer_menu.Stop()
    End Sub

    Private Sub Tabs_MouseEnter(sender As RibbonTab, e As MouseEventArgs) Handles Tesoreriamenu.MouseEnter, Contabilidadmenu.MouseEnter, Mesaentradasmenu.MouseEnter, Usuariomenu.MouseEnter, Informaticamenu.MouseEnter, SuministrosMenu.MouseEnter
        RibbonMenu.ActiveTab = sender
    End Sub

    Private Sub Conciliacion_reporte_Click(sender As Object, e As EventArgs) Handles Conciliacion_reporte.Click
        Dim REPORTAR As New Tesoreria_Reportes
        With REPORTAR
            .MdiParent = Me
        End With
        REPORTAR.CARGAGENERAL("CONCILIACIÓN")
    End Sub

    Private Sub ReportesDiarios_reporte_Click(sender As Object, e As EventArgs) Handles ReportesDiarios_reporte.Click
        Dim REPORTAR As New Tesoreria_Reportes
        With REPORTAR
            .MdiParent = Me
        End With
        REPORTAR.CARGAGENERAL("REPORTES DIARIOS")
    End Sub

    Private Sub Otros_reportes_Click(sender As Object, e As EventArgs) Handles Otros_reportes.Click
        Dim REPORTAR As New Tesoreria_Reportes
        With REPORTAR
            .MdiParent = Me
        End With
        REPORTAR.CARGAGENERAL("OTROS REPORTES")
    End Sub

    Private Sub Tesoreriamenu_Reportes2_DropDownShowing(sender As Object, e As EventArgs) Handles Tesoreriamenu_Reportes2.DropDownShowing
        CERRARMENU = False
    End Sub

    Private Sub Tesoreriamenu_Reportes2_DropDownItemClicked(sender As Object, e As RibbonItemEventArgs) Handles Tesoreriamenu_Reportes2.DropDownItemClicked
        CERRARMENU = True
    End Sub

    Private Sub Recibos_retenciones_Click(sender As Object, e As EventArgs) Handles Recibos_retenciones.Click
        MENULLAMADO(Tesoreria_recibos_retenciones)
    End Sub

    Private Sub Retencionescheque_Click(sender As Object, e As EventArgs) Handles Retencionescheque.Click
        MENULLAMADO(Retenciones)
    End Sub

    Private Sub Tesoreriamenu_Ajustes_DoubleClick(sender As Object, e As EventArgs)
    End Sub

    Private Sub Conciliacion1_Click(sender As Object, e As EventArgs) Handles Conciliacion1.Click
        MENULLAMADO(Conciliacion_Bancaria)
    End Sub

    Private Sub Conciliacion2_Click(sender As Object, e As EventArgs) Handles Conciliacion2.Click
        MENULLAMADO(Tesoreria_Conciliacion2)
    End Sub

    Private Sub ConciliacionMFyV_Click(sender As Object, e As EventArgs) Handles ConciliacionMFyV.Click
        MENULLAMADO(Tesoreria_AjustesMFyV)
    End Sub

    Private Sub CuentaBancaria_menu_Click(sender As Object, e As EventArgs) Handles CuentaBancaria_menu.Click
        MENULLAMADO(Cuentabancaria)
    End Sub

    Private Sub Tesoreria_Cheques_menu_Click(sender As Object, e As EventArgs) Handles Tesoreria_Cheques_menu.Click
        MENULLAMADO(Tesoreria_cheques_listado)
    End Sub

    Private Sub Direccion_menu_boton_Click(sender As Object, e As EventArgs) Handles Direccion_menu_boton.Click
        MENULLAMADO(Direccion_reportes)
    End Sub

    Private Sub Suministros_Expedientes_button_Click(sender As Object, e As EventArgs) Handles Suministros_Expedientes_button.Click
        MENULLAMADO(Suministros_expedientes)
    End Sub

    Private Sub Label_desarrollo_Click(sender As Object, e As EventArgs) Handles Label_EJERCICIOFINANCIERO.Click
        ' Dim infoss As New Informatica_Servicioadministrativo
        Informatica_Servicioadministrativo.Cargadeopciones_ServAdm("BASE DE DATOS")
    End Sub

    Private Sub Suministros_Ordenprovision_button_Click(sender As Object, e As EventArgs) Handles Suministros_Ordenprovision_button.Click
        MENULLAMADO(Suministros_listadoordenesprovision)
    End Sub

    Private Sub Contabilidadmenu_Ordencargo_Click(sender As Object, e As EventArgs)
        MENULLAMADO(Contabilidad_DialogoHaberes)
    End Sub

    Private Sub RibbonButton8_Click(sender As Object, e As EventArgs) Handles RibbonButton8.Click
        MENULLAMADO(Tesoreria_retencionesV2)
    End Sub

    '-fin Botones de llamados a menu
End Class