Imports System.IO

Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class PedidoFondos
    Private N_PedidoFondo_ As String
    Public Property N_PedidoFondo() As Integer
        Get
            Return N_PedidoFondo_
        End Get
        Set(ByVal value As Integer)
            N_PedidoFondo_ = value
        End Set
    End Property
    ' Public N_pedidofondo As Integer
    Private _YearPedidoFondo As Integer
    '  Private YearPedidoFondo As Integer
    Public Property YearPedidoFondo() As Integer
        Get
            Return _YearPedidoFondo
        End Get
        Set(ByVal value As Integer)
            _YearPedidoFondo = value
        End Set
    End Property
    'Private YearPedidoFondo_ As Integer
    'Public Property YearPedidoFondo() As Integer
    '    Get
    '        Return YearPedidoFondo
    '    End Get
    '    Set(ByVal value As Integer)
    '        YearPedidoFondo_ = value
    '    End Set
    'End Property
    'Public Year_pedidofondo As Integer
    'Public Clave_pedidofondo As String
    Private Clave_PedidoFondo_ As String
    Public Property Clave_pedidofondo() As String
        Get
            Return Clave_PedidoFondo_
        End Get
        Set(ByVal value As String)
            Clave_PedidoFondo_ = value
        End Set
    End Property
    'Public Fecha_pedido As Date
    Private Fecha_Pedido_ As Date
    Public Property Fecha_Pedido() As Date
        Get
            Return Fecha_Pedido_
        End Get
        Set(ByVal value As Date)
            Fecha_Pedido_ = value
        End Set
    End Property
    'Public Cuenta_pedidofondo As String
    Private Cuenta_PedidoFondo_ As String
    Public Property Cuenta_PedidoFondo() As String
        Get
            Return Cuenta_PedidoFondo_
        End Get
        Set(ByVal value As String)
            Cuenta_PedidoFondo_ = value
        End Set
    End Property
    'Public CuentaPedidofondo_descripcion As String
    Private CuentaPedidoFondo_Descripcion_ As String
    Public Property CuentaPedido_Descripcion() As String
        Get
            Return CuentaPedidoFondo_Descripcion_
        End Get
        Set(ByVal value As String)
            CuentaPedidoFondo_Descripcion_ = value
        End Set
    End Property
    Public Caracter As String
    Public Expediente_N As String
    Public ExpteOrganismo As Integer
    Public ExpteNumero As Integer
    Public ExpteYear As Integer
    Public N_Ordenpago As Integer
    Public Year_Ordenpago As Integer
    Public Descripcion As String
    Public Monto_pedidofondo As Decimal
    Public Clase_fondo As Integer
    Public Parcial As Boolean
    Public Haberes As Boolean
    Public Datospedidofondos_datatable As New DataTable
    Public Datospartidas_datatable As New DataTable

    Public Sub New(ByRef Clavepedido As String, ByRef Expte_completo As String)
        If Not IsNothing(Clavepedido) Then
            Clave_pedidofondo = Clavepedido
            Expediente_N = Expte_completo
            If Not (Clave_pedidofondo = "0") Then
                Desglose_clave()
                Desglose_expediente()
            Else
                buscarmaximo_pedidofondo(Date.Now.Year)
            End If
        End If
    End Sub

    Public Function Existe_pedidofondo(ByVal numpedido As Integer, ByVal yearpedido As Integer) As Boolean
        Dim clave_pedido As Long = CType((yearpedido & Autorizaciones.Organismo.ToString.Substring(0, 4) & Format(Convert.ToInt32(numpedido.ToString), "00000")), Long)
        Dim temporal As New DataTable
        COMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", clave_pedido)
        Inicio.SQLPARAMETROS(Organismotabla,
                             "Select clave_pedidofondo from pedido_fondos where Clave_pedidofondo=@Clave_pedidofondo",
                             temporal, Reflection.MethodBase.GetCurrentMethod.Name)
        Select Case temporal.Rows.Count > 0
            Case True
                Return False
            Case Else
                Return True
        End Select
    End Function

    Private Sub Desglose_clave()
        If Clave_pedidofondo.Length > 7 Then
            meExpteOrganismo = CType(Clave_pedidofondo.Substring(4, 4), Integer)
            Me.N_PedidoFondo = CType(Clave_pedidofondo.Substring(8, 5), Integer)
            Me._YearPedidoFondo = CType(Clave_pedidofondo.Substring(0, 4), Integer)
            Me.Expediente_N = ExpteOrganismo & "-" & ExpteNumero & "/" & ExpteYear
        Else
            Me.ExpteOrganismo = 0
            Me.Expediente_N = 0
            Me._YearPedidoFondo = Date.Now.Year
            Me.Expediente_N = ""
        End If
    End Sub

    Public Sub CargarDatos(ByVal ClavepedidoFondos As String)
        Dim PedidoFondosData As New DataTable
        COMMANDSQL.Parameters.AddWithValue("@clave_pedidofondo", ClavepedidoFondos)
        Inicio.SQLPARAMETROS(Organismotabla, "SELECT * from pedido_fondos where clave_pedidofondo=@clave_pedidofondo", PedidoFondosData, Reflection.MethodBase.GetCurrentMethod.Name)
        If PedidoFondosData.Rows.Count > 0 Then
            Me.YearPedidoFondo = PedidoFondosData.Rows(0).Item("Clave_pedidofondo").ToString.Substring(0, 4)
            Me.Fecha_Pedido = PedidoFondosData.Rows(0).Item("Fecha_pedido")
            Me.Cuenta_PedidoFondo = PedidoFondosData.Rows(0).Item("Cuenta_pedidofondo")
            'divide el texto en 3 partes
            Dim ExpedienteDividido As String() = DIVISORUNIVERSAL(PedidoFondosData.Rows(0).Item("Expediente_N"))
            Me.ExpteOrganismo = CType(ExpedienteDividido(0), Integer)
            Me.ExpteNumero = CType(ExpedienteDividido(1), Integer)
            Me.ExpteYear = CType(ExpedienteDividido(2), Integer)
            Me.Parcial = PedidoFondosData.Rows(0).Item("Parcial")
            Me.Descripcion = PedidoFondosData.Rows(0).Item("Descripcion")
            Me.Fecha_Pedido_ = PedidoFondosData.Rows(0).Item("Fecha_pedido")
            Me.Haberes = PedidoFondosData.Rows(0).Item("Haberes")
        End If
    End Sub

    Private Sub buscarmaximo_pedidofondo(ByVal Year As Integer)
        Dim temporal As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Year_pedidofondo", Year)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla,
                             "Select max(N_pedidofondo) from pedido_fondos where Year_pedidofondo=@Year_pedidofondo and not N_pedidofondo between 1000 and 1999 ",
                             temporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Select Case IsDBNull(temporal.Rows(0).Item(0))
            Case True
                N_PedidoFondo = 1
            Case False
                N_PedidoFondo = Convert.ToInt16(temporal.Rows(0).Item(0)) + 1
                If N_PedidoFondo >= 1000 And N_PedidoFondo <= 1999 Then
                    N_PedidoFondo += 1000
                End If
                temporal.Dispose()
        End Select
    End Sub

    Private Sub Desglose_expediente()
        If Expediente_N.Length > 7 Then
            Dim Expedientecompleto_pedidofondo() As String
            Expedientecompleto_pedidofondo = Divisordetresvariables(Expediente_N)
            If Not IsNothing(Expedientecompleto_pedidofondo) Then
                If Expedientecompleto_pedidofondo.Count = 3 Then
                    ExpteOrganismo = CType(Expedientecompleto_pedidofondo(0).ToString, Integer)
                    ExpteNumero = CType(Expedientecompleto_pedidofondo(1).ToString, Integer)
                    ExpteYear = CType(Expedientecompleto_pedidofondo(2).ToString, Integer)
                Else
                    ExpteOrganismo = CType(Autorizaciones.Organismo.ToString.Substring(0, 4), Integer)
                    ExpteNumero = 0
                    ExpteYear = Date.Now.Year
                End If
            Else
                ExpteOrganismo = CType(Autorizaciones.Organismo.ToString.Substring(0, 4), Integer)
                ExpteNumero = 0
                ExpteYear = Date.Now.Year
            End If
        Else
            ExpteOrganismo = CType(Autorizaciones.Organismo.ToString.Substring(0, 4), Integer)
            ExpteNumero = 0
            ExpteYear = Date.Now.Year
        End If
    End Sub

    Private Sub Generaciondepedidodefondos3(ByVal pedido_fondo As PedidoFondos)
        Dim Pedidodefondos_datatable As New DataTable
        Dim Numdecuenta_datatable As New DataTable
        Dim Caracterdecuenta1 As New DataTable
        Dim Caracterdecuenta2 As New DataTable
        Dim Cuentadepresupuesto_datatable As New DataTable
        Dim Transferidoportesoreríageneral_datatable As New DataTable
        'declaración de Fuentes a utilizar en el archivo
        Dim titleFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 18.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font12BoldSUAVE As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD Or iTextSharp.text.Font.BOLDITALIC, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#c5c7c0")))
        Dim font12Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font10Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font10Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font07Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font07bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim Doc As New Document(PageSize.LEGAL, 80, 40, 20, 20)
        'Dim FileName As String = FileName
        Dim Anchopagina As Single = Doc.PageSize.Width
        Dim Controlguardado As New SaveFileDialog
        With Controlguardado
            Select Case System.IO.Directory.Exists("C:" & "\" & "PEDIDOS_DE_FONDO" & "\" & pedido_fondo.YearPedidoFondo & "\")
                Case True
                Case False
                    System.IO.Directory.CreateDirectory("C:" & "\" & "PEDIDOS_DE_FONDO" & "\" & pedido_fondo.YearPedidoFondo & "\")
            End Select
            .Filter = "ARCHIVO PDF|*.pdf"
            .Title = "Guardar en archivo PDF"
            .FileName = pedido_fondo.N_PedidoFondo & "-" & pedido_fondo.YearPedidoFondo & ".pdf"
            .RestoreDirectory = True
            .InitialDirectory = "C:" & "\" & "PEDIDOS_DE_FONDO" & "\" & pedido_fondo.YearPedidoFondo & "\"
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
                'para insertar un espacio entre las celdas
                Dim PdfpCell_espaciovacio As iTextSharp.text.pdf.PdfPCell = New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("", font10Normal)))
                PdfpCell_espaciovacio.BorderWidth = 0
                PdfpCell_espaciovacio.FixedHeight = 2.0F
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
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Encabezadodelyear(pedido_fondo._YearPedidoFondo), font10Normal)))
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.FixedHeight = 25.0F
                Encabezadosx.AddCell(PdfPCell)
                '----------------------NOMBRE DEL SERVICIO ADMINISTRATIVO------------------------------
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Nombrecompletodelservicio.ToUpper, PDF_fuente_variable(12, True))))
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
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("ORDEN DE ENTREGA DE FONDOS Nº", font07Normal)))
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT
                Ordenentregafondos.AddCell(PdfPCell)
                '
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", font10Normal)))
                PdfPCell.BorderWidth = 1
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                Ordenentregafondos.AddCell(PdfPCell)
                '
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", font10Normal)))
                PdfPCell.BorderWidth = 1
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                Ordenentregafondos.AddCell(PdfPCell)
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("     FECHA:", font10Normal)))
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
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("PEDIDO DE FONDOS Nº", font10Bold)))
                PdfPCell.BorderWidth = 0
                PdfPCell.FixedHeight = 30
                PdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT
                PdfPCell.Rowspan = 1
                Espaciodescripcionpedidofondo.AddCell(PdfPCell)
                '----------------------TABLA CENTRAL DE PEDIDO DE FONDOS CON NRO ----------------------
                Dim Nropedidofondo As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(6)
                'nro de pedido de fondo----------------------
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(pedido_fondo.N_PedidoFondo.ToString, titleFont)))
                PdfPCell.BorderWidth = 0.5
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.Colspan = 3
                PdfPCell.FixedHeight = 25
                Nropedidofondo.AddCell(PdfPCell)
                'año de pedido de fondo----------------------
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(pedido_fondo._YearPedidoFondo, titleFont)))
                PdfPCell.BorderWidth = 0.5
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.Colspan = 3
                PdfPCell.FixedHeight = 25
                Nropedidofondo.AddCell(PdfPCell)
                '----------------------numero del organismo del expediente del pedido de fondo----------------------
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Organismo, font10Bold)))
                PdfPCell.BorderWidth = 0.5
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.Colspan = 2
                PdfPCell.FixedHeight = 15
                Nropedidofondo.AddCell(PdfPCell)
                'numero del expediente dentro del organismo del pedido de fondos----------------------
                '   PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Expte_numero_numericupdown.Value.ToString, font10Bold)))
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("", font10Bold)))
                PdfPCell.BorderWidth = 0.5
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.Colspan = 2
                PdfPCell.FixedHeight = 15
                Nropedidofondo.AddCell(PdfPCell)
                'Año del expediente de pedido de fondos.----------------------
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(pedido_fondo._YearPedidoFondo.ToString, font10Bold)))
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
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("FECHA:" & Convert.ToDateTime(pedido_fondo.Fecha_Pedido).ToString("dd/MM/yyyy"), font10Bold)))
                PdfPCell.BorderWidth = 0
                PdfPCell.Rowspan = 2
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE
                Espaciodescripcionpedidofondo.AddCell(PdfPCell)
                'AGREGA LA fRASE EXPEDIENTE Nro
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Expediente Nº", font10Bold)))
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
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk("Sr.CONTADOR GENERAL DE LA PROVINCIA ", font10Bold))
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk("De acuerdo a la ", font10Normal))
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk("LEY DE CONTABILIDAD", font10Bold))
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk(", solicitamos las siguientes TRANSFERENCIAS de Fondos: ", font10Normal))
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
                tamaniocolumna(3) = Convert.ToSingle(anchoutil * 0.1) ' EXPEDIENTE
                tamaniocolumna(4) = Convert.ToSingle(anchoutil * 0.1) ' CUIT
                tamaniocolumna(5) = Convert.ToSingle(anchoutil * 0.35) 'Concepto
                tamaniocolumna(6) = Convert.ToSingle(anchoutil * 0.12) 'orden
                tamaniocolumna(7) = Convert.ToSingle(anchoutil * 0.15) 'IMPORTE
                '    Case False
                '        tamaniocolumna = New Single(4) {}
                '        tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.05) 'Nº
                '        tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.1) 'Rubro
                '        tamaniocolumna(2) = Convert.ToSingle(Anchopagina * 0.1) 'Proveedor
                '        tamaniocolumna(3) = Convert.ToSingle(Anchopagina * 0.65) ' Concepto
                '        tamaniocolumna(4) = Convert.ToSingle(Anchopagina * 0.1) ' Importe
                'End Select
                '---------------------------------------------TABLA CON TODOS LOS DATOS-----------------------------------------------------------------------------------------------
                Dim tablapedidodefondos As iTextSharp.text.pdf.PdfPTable = PDFDatatable(Datospedidofondos_datatable, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#c5c7c0")), 8, True)
                '---------------------------------------------TABLA CON TODOS LOS DATOS-----------------------------------------------------------------------------------------------
                'agrega la celda de Valor total a la tabla
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("TOTAL", font10Bold)))
                PdfPCell.BorderWidth = 0
                PdfPCell.FixedHeight = 18
                PdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT
                PdfPCell.Colspan = tamaniocolumna.Count - 1
                'agrega la celda total
                tablapedidodefondos.AddCell(PdfPCell)
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(pedido_fondo.Monto_pedidofondo.ToString("C"), font10Bold))
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
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Fecha de Vencimiento  ", font07Normal)))
                PdfPCell.BorderWidth = 0
                PdfPCell.FixedHeight = 15
                PdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT
                PdfPCell.Colspan = 1
                'agrega la celda total
                Deudaconoajuste_fechavencimiento.AddCell(PdfPCell)
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("__/__/____", font10Bold)))
                PdfPCell.BorderWidth = 0.25
                PdfPCell.FixedHeight = 15
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.Colspan = 1
                'agrega la celda total
                Deudaconoajuste_fechavencimiento.AddCell(PdfPCell)
                'Anteriormente Deuda con ajuste, pero debido aque no existen actualmente ajustes por inflación  se Vacia
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", font07Normal)))
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
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("A DEPOSITAR EN LA CUENTA N°", font07Normal)))
                PdfPCell.BorderWidth = 0
                PdfPCell.FixedHeight = 15
                PdfPCell.Colspan = 1
                'agrega la celda total
                CuentaBancariatabla_wrap.AddCell(PdfPCell)
                Dim CuentaBancariatabla As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(pedido_fondo.Cuenta_PedidoFondo.ToString.Length)
                tamaniocolumna = New Single(pedido_fondo.Cuenta_PedidoFondo.ToString.Length - 1) {}
                For X = 0 To pedido_fondo.Cuenta_PedidoFondo.ToString.Length - 1
                    tamaniocolumna(X) = Convert.ToSingle((Anchopagina * 0.7) / pedido_fondo.Cuenta_PedidoFondo.ToString.Length - 1)
                Next
                CuentaBancariatabla.SetWidths(tamaniocolumna)
                For x = 0 To pedido_fondo.Cuenta_PedidoFondo.ToString.Length - 1
                    CuentaBancariatabla.AddCell((New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(pedido_fondo.Cuenta_PedidoFondo.ToString.Chars(x), font12Bold))))
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
                Caracterdecuenta1.Rows(0).Item("NUMERO") = pedido_fondo.Caracter.ToString
                Caracterdecuenta1.Rows(0).Item("CUENTA") = "CUENTA:"
                Caracterdecuenta1.Rows(0).Item("CUENTA_DETALLE") = pedido_fondo.CuentaPedidoFondo_Descripcion_.ToString
                tamaniocolumna = New Single(3) {}
                tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.1)
                tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.05)
                tamaniocolumna(2) = Convert.ToSingle(Anchopagina * 0.1)
                tamaniocolumna(3) = Convert.ToSingle(Anchopagina * 0.75)
                Dim Caracterdecuenta1pdftable As iTextSharp.text.pdf.PdfPTable = PDFDatatable(Caracterdecuenta1, tamaniocolumna, 2, Anchopagina - (Doc.LeftMargin + 4), False, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#c5c7c0")), 9)
                PARRAFOCOMPLETO.Add(Caracterdecuenta1pdftable)
                'Firmas autorizadas Por el servicio administrativo
                ''agregar las tablas DE firmas al parrafo
                With PARRAFOCOMPLETO
                    .Add(PDFFIRMAS(Anchopagina - Doc.LeftMargin, "TESORERO", "DIRECTOR"))
                End With
                'agregar parrafo de datos del pedido de fondo al documento
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0.5)))
                Tabla_total.AddCell(PdfpCell_espaciovacio)
                'Parrafo de Certificación por el Delegado Fiscal
                PARRAFOCOMPLETO.Clear()
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk("CERTIFICO: ", font10Bold))
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk("Que la documentación pertinente del Pedido ha sido verificada en forma integral, no mereciendo observaciones que formular", font10Normal))
                With PARRAFOCOMPLETO
                    .Add(PDFFIRMAS(Anchopagina - Doc.LeftMargin, "", "DELEGADO FISCAL"))
                End With
                'agregar las tablas DE firmas al parrafo
                'agregar parrafo de Certificación por el Delegado Fiscal
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0.5)))
                Tabla_total.AddCell(PdfpCell_espaciovacio)
                'Parrafo correspondiente a la Tesorería General de la provincia
                PARRAFOCOMPLETO.Clear()
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk("TRANSFIERESE POR LA TESORERIA GENERAL DE LA PROVINCIA ", font10Bold))
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk(": a favor del ", font10Normal))
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk(Nombrecompletodelservicio.ToUpper, font10Bold))
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk(" con cargo de oportuna y documentada rendición de cuentas con ", font10Normal))
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk("IMPUTACIÓN ", font10Bold))
                'agrega el caracter de la cuenta al parrafo
                'estructura de Caracter
                Caracterdecuenta2.Columns.Add("CARACTER")
                Caracterdecuenta2.Columns.Add("NUMERO")
                Caracterdecuenta2.Columns.Add("CUENTA")
                Caracterdecuenta2.Columns.Add("CUENTA_DETALLE")
                Caracterdecuenta2.Rows.Add()
                Caracterdecuenta2.Rows(0).Item("CARACTER") = "CÁRACTER"
                Caracterdecuenta2.Rows(0).Item("NUMERO") = pedido_fondo.Caracter.ToString
                Caracterdecuenta2.Rows(0).Item("CUENTA") = "CUENTA:"
                Select Case pedido_fondo.Caracter.ToString
                    Case Is = "0"
                        Caracterdecuenta2.Rows(0).Item(3) = "SIN AFECTACIÓN ESPECIAL"
                    Case Else
                        Caracterdecuenta2.Rows(0).Item("CUENTA_DETALLE") = "CON AFECTACIÓN ESPECIAL -" & vbNewLine & pedido_fondo.CuentaPedidoFondo_Descripcion_
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
                'If   pedido_fondo.Yearpedidofondo.ToString = pedido_fondo.AnioEjecucion Then
                '    Cuentadepresupuesto_datatable.Rows(0).Item("CONCEPTO") = "CUENTA DE PRESUPUESTO EJERCICIO AÑO " &   pedido_fondo.Yearpedidofondo
                'Else
                '    Cuentadepresupuesto_datatable.Rows(0).Item("CONCEPTO") = "CUENTA DE PRESUPUESTO EJERCICIO AÑO " &   pedido_fondo.Yearpedidofondo & vbNewLine & "RESIDUOS PASIVOS AÑO " & pedido_fondo.AnioEjecucion
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
                If pedido_fondo.Clase_fondo.ToString.Length = 4 Then
                    If pedido_fondo._YearPedidoFondo.ToString = pedido_fondo.Clase_fondo Then
                        parrafotemporal.Add((New Phrase("CUENTA DE PRESUPUESTO EJERCICIO AÑO " & pedido_fondo._YearPedidoFondo, PDF_fuente_variable(9, False))))
                    Else
                        'parrafotemporal.Add((New Phrase("CUENTA DE PRESUPUESTO EJERCICIO AÑO " &   pedido_fondo.Yearpedidofondo, PDF_fuente_variable(9, False))))
                        parrafotemporal.Add((New Phrase(vbNewLine & "RESIDUOS PASIVOS AÑO " & pedido_fondo.Clase_fondo, PDF_fuente_variable(9, True))))
                    End If
                Else
                    parrafotemporal.Add((New Phrase("CUENTA DE PRESUPUESTO EJERCICIO AÑO " & pedido_fondo._YearPedidoFondo, PDF_fuente_variable(9, False))))
                End If
                parrafotemporal.Add((New Phrase("", PDF_fuente_variable(9, False))))
                parrafotemporal.Alignment = 1
                PdfPCell = ((Elementopdf_a_Celda_conborde(parrafotemporal, 0.5)))
                PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE
                Cuentadepresupuesto.AddCell(PdfPCell)
                parrafotemporal.Clear()
                '
                PdfPCell = Nothing
                parrafotemporal.Add((New Phrase(pedido_fondo.Monto_pedidofondo.ToString("C"), PDF_fuente_variable(9, False))))
                parrafotemporal.Add((New Phrase("", PDF_fuente_variable(9, False))))
                parrafotemporal.Alignment = 1
                PdfPCell = ((Elementopdf_a_Celda_conborde(parrafotemporal, 0.5)))
                PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE
                Cuentadepresupuesto.AddCell(PdfPCell)
                '----------------------------------------------------------------------
                parrafotemporal.Clear()
                '
                PdfPCell = Nothing
                'agrega la celda de Valor total a la tabla
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("TOTAL", font10Bold)))
                PdfPCell.BorderWidth = 0
                PdfPCell.FixedHeight = 18
                PdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT
                PdfPCell.Colspan = 1
                'agrega la celda total
                Cuentadepresupuesto.AddCell(PdfPCell)
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(pedido_fondo.Monto_pedidofondo.ToString("C"), font10Bold))
                PdfPCell.BorderWidth = 0.5
                PdfPCell.FixedHeight = 18
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.Colspan = 1
                'Agrega la celda con el total sumado
                Cuentadepresupuesto.AddCell(PdfPCell)
                With PARRAFOCOMPLETO
                    .Add(Cuentadepresupuesto)
                End With
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk("SON PESOS: " & Inicio.Num2Text(Math.Truncate(pedido_fondo.Monto_pedidofondo) & " CON " &
                                                                                              (pedido_fondo.Monto_pedidofondo) - Math.Truncate(pedido_fondo.Monto_pedidofondo) * 100).ToString("00") & "/100.-", font10Bold))
                'Firmas autorizadas Por cONTADURIA
                With PARRAFOCOMPLETO
                    .Add(PDFFIRMAS(Anchopagina - Doc.LeftMargin, "Responsable Transf. Fondos", "CONTADOR GENERAL"))
                End With
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0.5)))
                Tabla_total.AddCell(PdfpCell_espaciovacio)
                PARRAFOCOMPLETO.Clear()
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk("TRANSFERIDO POR LA TESORERÍA GENERAL", font10Bold))
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
                    PdfPCell = New PdfPCell(New Phrase(New Chunk(Transferidoportesoreríageneral_datatable.Columns(X).Caption, font10Bold)))
                    'Alignment of phrase in the pdfcell
                    PdfPCell.HorizontalAlignment = 1
                    PdfPCell.BackgroundColor = New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#c5c7c0"))
                    'Add pdfcell in pdftable
                    Transferidoportesoreríageneral.AddCell(PdfPCell)
                Next
                Transferidoportesoreríageneral.HeaderRows = 1
                PdfPCell = New PdfPCell(New Phrase(New Chunk(" ", font07Normal)))
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
                Dim textoQR As String = Autorizaciones.Nombrecompletodelservicio.ToUpper & vbNewLine & "Pedido de Fondos Nº" & pedido_fondo.N_PedidoFondo & "/" & pedido_fondo.YearPedidoFondo & vbNewLine & " por:" & pedido_fondo.Monto_pedidofondo.ToString("C")
                'For x = 0 To Expedientesasociados_datagridview.Rows.Count - 1
                '    textoQR = textoQR & vbNewLine & Expedientesasociados_datagridview.Rows(x).Cells.Item("expediente_N").Value.ToString & " / " &
                '        Expedientesasociados_datagridview.Rows(x).Cells.Item("CUIT").Value.ToString & " / " & FormatCurrency(Convert.ToDecimal(Expedientesasociados_datagridview.Rows(x).Cells.Item("Monto2").Value.ToString), 2,, TriState.True, TriState.True)
                'Next
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
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk(Inicio.GenerateHash(textoQR), font07Normal))
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

    Public Sub Nuevo_pedido_dialogo()
        Dim pedfondo As New PedidoFondos("0", "0")
        pedfondo._YearPedidoFondo = Date.Now.Year
        'asigna el mayor número de pedido de fondo que no se encuentre entre el 1000 y el 1999, estos números son asignados por contabilidad
        buscarmaximo_pedidofondo(pedfondo._YearPedidoFondo)
        pedfondo.Fecha_Pedido = Date.Now
        pedfondo.Cuenta_PedidoFondo = 0
        pedfondo.ExpteOrganismo = Organismo.ToString.Substring(0, 4)
        pedfondo.ExpteNumero = 0
        pedfondo.ExpteYear = Date.Now.Year
        pedfondo.Descripcion = ""
        pedfondo.Clase_fondo = Date.Now.Year
        pedfondo.Parcial = False
        pedfondo.Haberes = False
        Dialogo_nuevopedidofondo.General_cargapedidofondo(pedfondo, Inicio, True)
    End Sub

    Public Sub CargarDatosPartidas_datatable()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", Clave_pedidofondo)
        Dim consultasql As String
        If Me.Haberes Then
            consultasql = "
Select *  FROM
(Select CUIT,Monto,Clave_expediente,Clave_pedidofondo from Cuit_Movimiento Where Clave_pedidofondo=@Clave_pedidofondo group by clave_expediente ) A
LEFT JOIN
(Select CONCAT(Substring(clave_expediente From 5 for 4),'-',cast(Substring(clave_expediente From 9 for 5)AS UNSIGNED),'/',Substring(clave_expediente From 1 for 4)) as Expediente_N,
Fecha,Detalle,Ordenpago,ORDENCARGO,Clave_expediente from expediente) C ON
A.clave_expediente=C.Clave_expediente
LEFT JOIN
(Select Proveedor,CUIT,NUMERO,NOMBREFANTASIA from proveedores) B ON
A.CUIT=B.CUIT
LEFT JOIN
(Select * from contabilidad_partidaexpediente where clave_ordenpago in (select clave_ordenpago from contabilidad_ordenpago where estado='ACTIVO')) partida ON
A.clave_expediente=partida.Clave_expediente
LEFT JOIN
(Select CLAVE_ORDENPAGO, CONCAT (GRUPO,' ',SUBGRUPO,' ', DENOMINACION) AS 'DETALLEHABERES',MONTO AS MONTOHABERES from contabilidad_ordenpago_haberesdetalle where clave_ordenpago in (select clave_ordenpago from contabilidad_ordenpago where estado='ACTIVO')
AND MONTO<>0
UNION
Select CLAVE_ORDENPAGO, 'LIQUIDACIÓN A PAGAR' AS 'DETALLEHABERES',Haberes_liquidacionapagar AS MONTOHABERES from contabilidad_ordenpago where clave_ordenpago in (select clave_ordenpago from contabilidad_ordenpago_haberesdetalle where estado='ACTIVO' group by clave_ordenpago having sum(monto)>0)
AND MONTO<>0
) partidaHABERES ON
PARTIDA.Clave_Ordenpago=partidaHABERES.Clave_Ordenpago
LEFT JOIN
(SELECT CUIT,MONTO,Clave_expediente,rubro FROM cuit_expediente )D
on CONCAT(A.CUIT,A.Clave_expediente)= CONCAT(D.CUIT,D.Clave_expediente)
LEFT JOIN
(SELECT CUIT,SUM(MONTO) AS MONTO,Clave_expediente FROM cuit_movimiento GROUP BY CLAVE_EXPEDIENTE,CUIT)E
on CONCAT(A.CUIT,A.Clave_expediente)= CONCAT(E.CUIT,E.Clave_expediente)
order by a.clave_expediente desc,detalle asc,fecha desc
"
            '            consultasql = "
            '   Select *  FROM
            '(Select CUIT,Monto,Clave_expediente,Clave_pedidofondo from Cuit_Movimiento Where Clave_pedidofondo=@Clave_pedidofondo ) A
            'LEFT JOIN
            '(Select CONCAT(Substring(clave_expediente From 5 for 4),'-',cast(Substring(clave_expediente From 9 for 5)AS UNSIGNED),'/',Substring(clave_expediente From 1 for 4)) as Expediente_N,
            'Fecha,Detalle,Ordenpago,ORDENCARGO,Clave_expediente from expediente) C ON
            'A.clave_expediente=C.Clave_expediente
            'LEFT JOIN
            '(Select Proveedor,CUIT,NUMERO,NOMBREFANTASIA from proveedores) B ON
            'A.CUIT=B.CUIT
            'LEFT JOIN
            '(Select * from contabilidad_partidaexpediente where clave_ordenpago in (select clave_ordenpago from contabilidad_ordenpago where estado='ACTIVO')) partida ON
            'A.clave_expediente=partida.Clave_expediente
            'LEFT JOIN
            '(SELECT CUIT,MONTO,Clave_expediente,rubro FROM cuit_expediente )D
            'on CONCAT(A.CUIT,A.Clave_expediente)= CONCAT(D.CUIT,D.Clave_expediente)
            'LEFT JOIN
            '(SELECT CUIT,SUM(MONTO) AS MONTO,Clave_expediente FROM cuit_movimiento GROUP BY CLAVE_EXPEDIENTE,CUIT)E
            'on CONCAT(A.CUIT,A.Clave_expediente)= CONCAT(E.CUIT,E.Clave_expediente)
            'order by a.clave_expediente desc,detalle asc,fecha desc
            '"
        Else
            consultasql = "
   Select
DETALLE_PEDIDOFONDO.CUIT,
IMPORTE_ACTARECEPCION,
CASE WHEN CANTIDAD=1 THEN partida.importe ELSE (IMPORTE_ACTARECEPCION-(ABS(MULTA_MONTO))) END AS 'IMPORTE',
MONTOEXPEDIENTE.monto,
Clave_pedidofondo,
Expediente_N,
Fecha,
Detalle,
Ordenpago,
ORDENCARGO,
Proveedor,
NUMERO,
NOMBREFANTASIA,
PARTIDA.Clave_ordenPago,
JUR,
UO,
CARAC,
FI,
FUN,
SECC,
SECT,
PDAPCIAL,
PDASUBPAR,
PDAPPAL,
SCD
FROM
	 #RENGLONES DE LA ORDEN DE PAGO
(Select CUIT,Monto,Clave_expediente,Clave_pedidofondo from Cuit_Movimiento Where Clave_pedidofondo=@Clave_pedidofondo ) DETALLE_PEDIDOFONDO
LEFT JOIN
#DATOS BÁSICOS DEL EXPEDIENTE
(Select
CONCAT(Substring(clave_expediente From 5 for 4),'-',cast(Substring(clave_expediente From 9 for 5)AS UNSIGNED),'/',Substring(clave_expediente From 1 for 4)) as Expediente_N,
Fecha,Detalle,Ordenpago,ORDENCARGO,Clave_expediente from expediente)DATOSEXPEDIENTE ON
DETALLE_PEDIDOFONDO.clave_expediente=DATOSEXPEDIENTE.Clave_expediente
#DATOS DE LOS PROVEEDORES
LEFT JOIN
(Select Proveedor,CUIT,NUMERO,NOMBREFANTASIA from proveedores) Datosproveedor ON
DETALLE_PEDIDOFONDO.CUIT=Datosproveedor.CUIT
LEFT JOIN
#DATOS DE LA PARTIDA PRESUPUESTARIA
(Select Clave_expediente,
Clave_ordenPago,
JUR,
UO,
CARAC,
FI,
FUN,
SECC,
SECT,
PDAPCIAL,
PDASUBPAR,
PDAPPAL,
SCD,SUM(IMPORTE) as importe
from contabilidad_partidaexpediente where clave_ordenpago in (select clave_ordenpago from contabilidad_ordenpago where estado='ACTIVO')
group by concat(pdapcial,pdappal),clave_expediente
) partida ON
DETALLE_PEDIDOFONDO.clave_expediente=partida.Clave_expediente
LEFT JOIN
#CUITS DENTRO DEL EXPEDIENTE
(SELECT CUIT,MONTO,Clave_expediente,rubro FROM cuit_expediente )CUITSEXPEDIENTE
on CONCAT(DETALLE_PEDIDOFONDO.CUIT,DETALLE_PEDIDOFONDO.Clave_expediente)= CONCAT(CUITSEXPEDIENTE.CUIT,CUITSEXPEDIENTE.Clave_expediente)
LEFT JOIN
#MONTO DE CADA EXPEDIENTE00
(SELECT CUIT,SUM(MONTO) AS MONTO,Clave_expediente FROM cuit_movimiento GROUP BY CLAVE_EXPEDIENTE,CUIT)MONTOEXPEDIENTE
on CONCAT(DETALLE_PEDIDOFONDO.CUIT,DETALLE_PEDIDOFONDO.Clave_expediente)= CONCAT(MONTOEXPEDIENTE.CUIT,MONTOEXPEDIENTE.Clave_expediente)
LEFT JOIN
#ACTAS DE RECEPCION
(SELECT CUIT,sum(TOTAL) AS IMPORTE_ACTARECEPCION,SUM(MULTA_MONTO) AS MULTA_MONTO,clave_ordenpago,CLAVE_EXPEDIENTE FROM contabilidad_actasrecepcion GROUP BY CLAVE_EXPEDIENTE,clave_ordenpago,CUIT)ACTARECEPCION
on CONCAT(Datosproveedor.CUIT,PARTIDA.CLAVE_ORDENPAGO)= CONCAT(ACTARECEPCION.CUIT,ACTARECEPCION.clave_ordenpago)
LEFT JOIN
#CONTAR PROVEEDORES DENTRO DE LAS ORDENES DE PAGO MEDIANTE SUS ACTAS DE RECEPCION
(SELECT COUNT(CUIT) AS CANTIDAD,Clave_Ordenpago AS 'CLAVE_ORDENPAGOAGRUP' FROM contabilidad_actasrecepcion GROUP BY CLAVE_EXPEDIENTE,clave_ordenpago)CANTIDADPROVEEDORES
on PARTIDA.CLAVE_ORDENPAGO= CLAVE_ORDENPAGOAGRUP
order by DETALLE_PEDIDOFONDO.clave_expediente desc,detalle asc,fecha desc
"
        End If
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, Me.Datospartidas_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
    End Sub

End Class

'/////////////////////////////////////////////////////////*************************************************************************************************************************