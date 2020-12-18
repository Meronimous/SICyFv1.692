Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class ExtensionPdf_Sicyf
End Class



Public Class AFIP_lote
    Public formulario As Integer 'nro de formulario
    Public version As Integer '0100
    Public cod_trazabilidad As String 'texto libre para seguimiento
    Public cuit_agente As Long 'Cuit de Agente de retención
    Public impuesto As Integer '353 retenciones contribuciones de la seguridad social
    Public regimen As Integer '755 Retención General de Contribuciones
    Public Cuit_retenido As Long 'Cuit del Proveedor
    Public fecha_retencion As Date
    Public tipo_comprobante As Integer '1 factura /2 Recibo /3 nota de crédito / 5 otro
    Public fecha_comprobante As Date
    Public nro_comprobante As String
    Public importe_comprobante As Decimal
    Public importe_retencion As Decimal
    Public certificado_original_nro As Integer
    Public certificado_original_fecha As Date
    Public certificado_original_importe As Decimal
    Public otros_datos As String

    Public Sub New()
        clear()
    End Sub

    'Public Sub borrarcarga()
    '    Datatable_totxt(borrar)
    'End Sub
    Public Sub Carga_intermedia(ByVal desde As Date, ByVal hasta As Date, ByVal cuenta As String)
        Datatable_totxt(Archivoafip(desde, hasta, cuenta), desde, hasta, cuenta)
    End Sub

    Public Sub clear()
        formulario = 0  'nro de formulario
        version = 0 '0100
        cod_trazabilidad = ""  'texto libre para seguimiento
        cuit_agente = 0 'Cuit de Agente de retención
        impuesto = 0 '353 retenciones contribuciones de la seguridad social
        regimen = 0 '755 Retención General de Contribuciones
        Cuit_retenido = 0 'Cuit del Proveedor
        fecha_retencion = Date.Now
        tipo_comprobante = 0 '1 factura /2 Recibo /3 nota de crédito / 5 otro
        fecha_comprobante = Date.Now
        nro_comprobante = 0
        importe_comprobante = 0
        importe_retencion = 0
        certificado_original_nro = 0
        certificado_original_fecha = Date.Now
        certificado_original_importe = 0
        otros_datos = ""
    End Sub

    Public Function afip_Txtlote(ByVal fila As AFIP_lote) As String
        Dim string_total As String = ""
        fila.formulario = 2004
        fila.version = 100
        fila.impuesto = 353
        string_total += fila.formulario.ToString("0000")
        string_total += fila.version.ToString("0000")
        string_total += fila.cod_trazabilidad.ToString.PadLeft(10, " ")
        string_total += fila.cuit_agente.ToString
        string_total += fila.impuesto.ToString("000")
        string_total += fila.regimen.ToString("000")
        string_total += fila.Cuit_retenido.ToString
        string_total += fila.fecha_retencion.ToString("dd/MM/yyyy")
        string_total += fila.tipo_comprobante.ToString("00")
        string_total += fila.fecha_comprobante.ToString("dd/MM/yyyy")
        string_total += fila.nro_comprobante.ToString.PadLeft(14, "0")
        string_total += fila.importe_comprobante.ToString("G").PadLeft(14, "0")
        string_total += fila.importe_retencion.ToString("G").PadLeft(14, "0")
        If certificado_original_nro = 0 Then
        Else
            string_total += fila.certificado_original_nro.ToString.PadLeft(16, "0")
            string_total += fila.certificado_original_fecha.ToString("dd/MM/yyyy")
            string_total += fila.certificado_original_importe.ToString("G").PadLeft(14, "0")
            string_total += fila.otros_datos.ToString.PadLeft(30, " ")
        End If
        Return string_total
    End Function

    Public Sub Datatable_totxt(ByVal tabla As DataTable, ByVal desde As Date, ByVal hasta As Date, ByVal cuenta As String)
        Dim fila As New AFIP_lote
        Dim file As System.IO.StreamWriter
        Dim Controlguardado As New SaveFileDialog
        With Controlguardado
            Select Case System.IO.Directory.Exists("C:" & "\" & "AFIP" & "\" & Date.Now.Year & "\" & cuenta & "\")
                Case True
                Case False
                    System.IO.Directory.CreateDirectory("C:" & "\" & "AFIP" & "\" & Date.Now.Year & "\" & cuenta & "\")
            End Select
            .Filter = "ARCHIVO txt|*.txt"
            .Title = "Guardar en archivo TXT"
            .FileName = Date.Now.ToString("yyyy-MM-dd") & ".txt"
            .RestoreDirectory = True
            .InitialDirectory = "C:" & "\" & "AFIP" & "\" & Date.Now.Year & "\" & cuenta & "\"
        End With
        Controlguardado.Filter = "ARCHIVO TXT|*.txt"
        Controlguardado.Title = "Guardar en archivo TXT"
        Controlguardado.ShowDialog()
        If Controlguardado.FileName = "" Then
            MsgBox("Para poder proceder a la creación del archivo se requiere un nombre")
            Exit Sub
        Else
            Dim FileName As String = Controlguardado.FileName
            file = My.Computer.FileSystem.OpenTextFileWriter(FileName, True)
            'Abrir el documento para el uso
            For x = 0 To tabla.Rows.Count - 1
                fila.formulario = tabla.Rows(x).Item("FORMULARIO")
                fila.version = tabla.Rows(x).Item("VERSION")
                fila.cod_trazabilidad = ""
                fila.cuit_agente = tabla.Rows(x).Item("CUIT_AGENTE").ToString.Replace("-", "")
                fila.impuesto = tabla.Rows(x).Item("IMPUESTO")
                fila.regimen = tabla.Rows(x).Item("REGIMEN")
                fila.Cuit_retenido = tabla.Rows(x).Item("CUIT_RETENIDO").ToString.Replace("-", "")
                fila.fecha_retencion = tabla.Rows(x).Item("FECHA_RETENCION")
                fila.tipo_comprobante = tabla.Rows(x).Item("TIPO_COMPROBANTE")
                fila.fecha_comprobante = tabla.Rows(x).Item("FECHA_COMPROBANTE")
                fila.nro_comprobante = tabla.Rows(x).Item("NRO_COMPROBANTE")
                fila.importe_comprobante = tabla.Rows(x).Item("IMPORTE_COMPROBANTE")
                fila.importe_retencion = tabla.Rows(x).Item("IMPORTE_RETENCION")
                'fila.certificado_original_nro = 0
                'fila.certificado_original_fecha = 0
                'fila.certificado_original_importe = ""
                'fila.otros_datos = ""
                'fila.certificado_original_nro = tabla.Rows(x).Item("CERTIFICADO_ORIGINAL_NRO")
                'fila.certificado_original_fecha = tabla.Rows(x).Item("CERTIFICADO_ORIGINAL_FECHARETEN")
                'fila.certificado_original_importe = tabla.Rows(x).Item("CERTIFICADO_ORIGINAL_IMPORTE")
                'fila.otros_datos = tabla.Rows(x).Item("OTROS_DATOS")
                file.WriteLine(afip_Txtlote(fila))
            Next
            file.Close()
        End If
    End Sub

    Private Function borrar() As DataTable
        Dim temporal As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", "300109417767043")
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@MD5_Banco", "")
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@desde", "'2019-08-14'")
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@hasta", "2019-10-18")
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "
SELECT Expediente_N,Detalle,Monto,Fechadelmovimiento as 'Fecha',CUIT,Nrotransferencia,`MFyV`,Clave_expediente_detalle,`Pedido de Fondo`,A.MD5_relacionado,
CASE WHEN ISNULL(Libro_Asociado) THEN 0 ELSE Libro_Asociado END AS 'Libro_Asociado',
CASE WHEN ISNULL(IMPORTE) THEN 0 ELSE IMPORTE END AS 'IMPORTE',
(CASE WHEN LIBRO_ASOCIADO-ABS(IMPORTE)=0 THEN 'OK' ELSE
    CASE WHEN ISNULL(LIBRO_ASOCIADO-ABS(IMPORTE))
        THEN 'SIN ASOCIAR' ELSE FORMAT(LIBRO_ASOCIADO-ABS(IMPORTE),2,'es_AR') END
END) as 'Diferencia'
FROM
        (Select Expediente_N,Detalle,Monto,Fechadelmovimiento,CUIT,Nrotransferencia,Clave_expediente_detalle,concat(Cod_orden,CFdo,CodInp) as 'MFyV',MD5_relacionado
                                    from Expediente_detalle  WHERE  ((FEchadelmovimiento BETWEEN @desde AND @hasta) OR (FEchadelmovimiento=@desde) OR (FEchadelmovimiento=@hasta))   AND NOT (CODINP='2')
)A  LEFT JOIN
(SELECT CONCAT (CONVERT((SUBSTRING(clave_pedidofondo FROM 9 FOR CHAR_LENGTH(clave_pedidofondo) - 4)),UNSIGNED),'/',SUBSTRING(clave_pedidofondo FROM 1 FOR CHAR_LENGTH(clave_pedidofondo) - 9) )AS 'Pedido de Fondo' ,
Clave_expediente FROM expediente)B ON B.Clave_expediente=SUBSTRING( A.Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4)
Left Join
(SELECT SUM(MONTO) AS 'Libro_Asociado',MD5_relacionado FROM expediente_detalle where NOT ISNULL(MD5_relacionado) group by MD5_relacionado)D
On A.MD5_relacionado=D.MD5_relacionado
Left Join
(SELECT SUM(IMPORTE) AS 'Importe',MD5HASH FROM reportebanco GROUP BY MD5HASH)E
On A.MD5_relacionado=E.MD5HASH
                                    order by Fechadelmovimiento desc,Nrotransferencia asc ",
                                 temporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Return temporal
    End Function

    Private Function Archivoafip(ByVal desde As Date, ByVal hasta As Date, ByVal cuenta As String) As DataTable
        Dim temporal As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", cuenta)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@CUIT_AGENTE", Autorizaciones.CUIT_servicioadministrativo)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@desde", desde)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@hasta", hasta)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "SElect '2004' as 'FORMULARIO',
'0100' AS 'VERSION',
@CUIT_AGENTE AS 'CUIT_AGENTE',
'353' AS IMPUESTO,
REGIMEN,
CUIT_RETENIDO,
FECHA_RETENCION,
TIPO_COMPROBANTE,
FECHA_COMPROBANTE,
NRO_COMPROBANTE,
IMPORTE_COMPROBANTE,
IMPORTE_RETENCION,
'' AS 'CERTIFICADO_ORIGINAL_NRO',
'' AS 'CERTIFICADO_ORIGINAL_FECHARETEN',
'' AS 'CERTIFICADO_ORIGINAL_IMPORTE',
'' AS 'OTROS_DATOS'
FROM
(SELECT COD_REGIMEN AS 'REGIMEN', CUIT AS 'CUIT_RETENIDO',FECHA_RETENCION,'2' AS 'TIPO_COMPROBANTE',
Monto_retenido AS 'IMPORTE_RETENCION',NRO_RECIBO FROM RETENCIONES)A
inner JOIN
(SELECT NRO_RECIBO as 'NRO_COMPROBANTE',Fecha_recibo as 'FECHA_COMPROBANTE',SUM(TOTAL + total_ganancias + total_iva + total_dgr + total_otros + total_suss) AS 'IMPORTE_COMPROBANTE',
CUIT,YEAR_RECIBO FROM tesoreria_recibos where Fecha_recibo between @desde and @hasta)B
ON CONCAT(A.NRO_RECIBO,CUIT,YEAR(FECHA_COMPROBANTE))=CONCAT(B.NRO_COMPROBANTE,CUIT,YEAR_RECIBO)
",
                                 temporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Return temporal
    End Function

End Class

'/////////////////////////////////////////////////////////*************************************************************************************************************************
Public Class TesoreriaGral
    Public idpedidofondo As Integer
    Public pedidofondo As Integer
    Public idorigen As Integer
    Public ordenentrega As Char
    Public fechaing As Date
    Public fechaven As Date
    Public fechault As Date
    Public desdeuda As String
    Public observa As String
    Public cuenta As String
    Public Importe_solicitado As Decimal
    Public expediente As Char
    Public ejercicio As Integer
    Public idimputac1 As Integer
    Public idimputac2 As Integer
    Public idimputac3 As Integer
    Public idimputac4 As Integer
    Public detalle As String
    Public contpedifondo As String
    Public contano As String

    Public Sub New()
    End Sub

    Public Sub Clear()
        idpedidofondo = 0
        pedidofondo = 0
        idorigen = 0
        ordenentrega = ""
        fechaing = Date.Now
        fechaven = Date.Now
        fechault = Date.Now
        desdeuda = ""
        observa = ""
        cuenta = ""
        Importe_solicitado = 0
        expediente = ""
        ejercicio = 0
        idimputac1 = 0
        idimputac2 = 0
        idimputac3 = 0
        idimputac4 = 0
        detalle = ""
        contpedifondo = ""
        contano = ""
    End Sub

    '    Public Sub Cargatesoreriagral(ByVal pedido As PedidoFondos)
    '        Dim maximo As Long = 0
    '        idpedidofondo = 0
    '        pedidofondo = pedido.N_pedidofondo
    '        idorigen = ctype(Autorizaciones.Organismo.tostring.substring(0,4),integer)
    '        ordenentrega = "0"
    '        fechaing = New Date(2000, 1, 1)
    '        fechaven = New Date(2000, 1, 1)
    '        fechault = Date.Now.Date
    '        desdeuda = ""
    '        observa = ""
    '        cuenta = pedido.Cuenta_pedidofondo
    '        Importe_solicitado = 0
    '        expediente = pedido.Expediente_N
    '        ejercicio = pedido.Clase_fondo
    '        idimputac1 = 0
    '        idimputac2 = 0
    '        idimputac3 = 0
    '        idimputac4 = 0
    '        detalle = pedido
    '        contpedifondo = ""
    '        contano = ""
    '        Dim temporalus As New DataTable
    '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@idpedidofondo", Me.idpedidofondo)
    '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@pedidofondo", Me.pedidofondo)
    '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@idorigen", Me.idorigen)
    '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@ordenentrega", Me.ordenentrega)
    '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@fechaing", Me.fechaing)
    '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@fechaven", Me.fechaven)
    '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@fechault", Me.fechault)
    '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@desdeuda", Me.desdeuda)
    '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@observa", Me.observa)
    '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@cuenta", Me.cuenta)
    '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Importe_solicitado", Me.Importe_solicitado)
    '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@expediente", Me.expediente)
    '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@ejercicio", Me.ejercicio)
    '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@idimputac1", Me.idimputac1)
    '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@idimputac2", Me.idimputac2)
    '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@idimputac3", Me.idimputac3)
    '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@idimputac4", Me.idimputac4)
    '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@detalle", Me.detalle)
    '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@contpedifondo", Me.contpedifondo)
    '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@contano", Me.contano)
    '        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO
    '(idpedidofondo,pedidofondo,idorigen,ordenentrega,fechaing,observa,cuenta,Importe_solicitado,expediente,ejercicio,idimputac1,idimputac2,idimputac3,idimputac4,detalle,contpedifondo,contano)
    'values (@idpedidofondo,@pedidofondo,@idorigen,@ordenentrega,@fechaing,@observa,@cuenta,@Importe_solicitado,@expediente,@ejercicio,@idimputac1,@idimputac2,@idimputac3,@idimputac4,@detalle,@contpedifondo,@contano)
    'ON DUPLICATE KEY UPDATE (ordenentrega=@ordenentrega,fechaing=@fechaing,observa=@observa,cuenta=@cuenta,Importe_solicitado=@Importe_solicitado,expediente=@expediente,ejercicio=@ejercicio,idimputac1=@idimputac1,idimputac2=@idimputac2,idimputac3=@idimputac3,idimputac4=@idimputac4,detalle=@detalle,contpedifondo=@contpedifondo,contano=@contano)"
    '        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
    '    End Sub
End Class

'clases creadas para el manejo del encabezado y pie de página dentro de los archivos PDF itsevents y itsevents2
Public Class itsEvents
    Inherits PdfPageEventHelper

    Public Overrides Sub OnEndPage(ByVal writer As iTextSharp.text.pdf.PdfWriter, ByVal document As iTextSharp.text.Document)
        Dim bf As BaseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED)
        Dim ch As New iTextSharp.text.Chunk(" SICyF " & Autorizaciones.Nombrecompletodelservicio & " " & writer.PageNumber)
        document.Add(ch)
    End Sub

End Class

Public Class itsEvents2
    Inherits PdfPageEventHelper
    Private cb As PdfContentByte
    Private headerTemplate, footerTemplate As PdfTemplate
    Private bf As BaseFont = Nothing
    Private PrintTime As DateTime = DateTime.Now
    Private _header As String

    Public Overrides Sub OnStartPage(ByVal writer As iTextSharp.text.pdf.PdfWriter, ByVal docume As iTextSharp.text.Document)
        'Dim imagen As iTextSharp.text.Image 'declaración de imagen
        'Dim textdwn As Font = FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD)
        'Dim Tcabecera As New PdfPTable(2) 'tabla  para cabecera
        'Dim Ttitulo As New PdfPTable(1) 'tabla para el titulo y datos generales
        'Dim salto As Font = FontFactory.GetFont(FontFactory.HELVETICA, 6)
        'Dim saltoF As Font = FontFactory.GetFont(FontFactory.HELVETICA, 6, Font.BOLD)
        'Dim fchica As Font = FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.BOLD)
        'Dim Ftitulo As Font = FontFactory.GetFont(FontFactory.HELVETICA, 14, Font.BOLD)
        ''Crear tabla para manejar los encabezados---------------------------------------------------------------------------------------------
        'Dim Encabezadosx As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(2)
        ''Encabezadosx.TotalWidth = Anchopagina - Doc.LeftMargin
        'Encabezadosx.LockedWidth = True
        ''Declaración variable de ancho de columnas
        'Dim tamaniocolumna As Single() = New Single(1) {}
        'tamaniocolumna(0) = Convert.ToSingle(docume.PageSize.Width * 0.2)
        'tamaniocolumna(1) = Convert.ToSingle(docume.PageSize.Width * 0.8)
        'Encabezadosx.SetWidths(tamaniocolumna)
        ''para insertar un espacio entre las celdas
        'Dim PdfpCell_espaciovacio As iTextSharp.text.pdf.PdfPCell = New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("", PDF_fuente_variable(10, False))))
        'PdfpCell_espaciovacio.BorderWidth = 0
        'PdfpCell_espaciovacio.FixedHeight = 2.0F
        'Dim PdfpCell_espaciovacioborde As iTextSharp.text.pdf.PdfPCell = New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("", PDF_fuente_variable(10, False))))
        'PdfpCell_espaciovacioborde.BorderWidth = 0.5
        'PdfpCell_espaciovacioborde.FixedHeight = 2.0F
        ''crear imagen con logo a la izquierda
        'Dim manejadorimagen As iTextSharp.text.Image = Image.GetInstance(My.Resources.Logo, System.Drawing.Imaging.ImageFormat.Jpeg)
        ''asignar la imagen itextsharp a la celda
        'Dim PdfPCell As iTextSharp.text.pdf.PdfPCell = New PdfPCell(manejadorimagen, True)
        'PdfPCell.Rowspan = 2
        'PdfPCell.BorderWidth = 0
        'PdfPCell.HorizontalAlignment = Element.ALIGN_LEFT
        'PdfPCell.FixedHeight = 70.0F
        'Encabezadosx.AddCell(PdfPCell)
        ''Encabezado del año
        '' PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Encabezadodelyear(OrdenProvision.fecharealizada_ordenprovision.Year), font10Normal)))
        'PdfPCell.BorderWidth = 0
        'PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
        'PdfPCell.FixedHeight = 25.0F
        'Encabezadosx.AddCell(PdfPCell)
        ''----------------------NOMBRE DEL SERVICIO ADMINISTRATIVO------------------------------
        'PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Nombrecompletodelservicio.ToUpper, PDF_fuente_variable(12, True))))
        'PdfPCell.BorderWidth = 0
        'PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
        'PdfPCell.FixedHeight = 25.0F
        'Encabezadosx.AddCell(PdfPCell)
        ''docume.Add(Encabezadosx)
        'docume.Add(Ttitulo)
        Dim imagen As iTextSharp.text.Image 'declaración de imagen
        Dim textdwn As Font = FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD)
        Dim Tcabecera As New PdfPTable(2) 'tabla  para cabecera
        Dim Ttitulo As New PdfPTable(1) 'tabla para el titulo y datos generales
        Dim salto As Font = FontFactory.GetFont(FontFactory.HELVETICA, 6)
        Dim saltoF As Font = FontFactory.GetFont(FontFactory.HELVETICA, 6, Font.BOLD)
        Dim fchica As Font = FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.BOLD)
        Dim Ftitulo As Font = FontFactory.GetFont(FontFactory.HELVETICA, 14, Font.BOLD)
        'Agregar escabezado, el que queramos
        imagen = iTextSharp.text.Image.GetInstance(System.Drawing.Image.FromHbitmap(My.Resources.Logo.GetHbitmap()), System.Drawing.Imaging.ImageFormat.Png) 'nombre y ruta de la imagen a insertar
        imagen.ScalePercent(30) 'escala al tamaño de la imagen
        imagen.Alignment = iTextSharp.text.Image.ALIGN_LEFT
        'PARTE SUPERIOR DEL DOCUMENTO (MEMBRETADO, FECHA Y DATOS GENERALES)
        Tcabecera.WidthPercentage = 100
        Dim anchoTcabecera() As Single = {20, 80}
        Tcabecera.SetWidths(anchoTcabecera)
        Dim margen As New PdfPCell(New Phrase("-1", salto))
        margen.Colspan = 9
        margen.BorderWidth = 1
        ' Tcabecera.AddCell(margen)
        Dim img As New PdfPCell(imagen)
        img.HorizontalAlignment = Element.ALIGN_LEFT
        img.BorderWidth = 0
        Tcabecera.AddCell(img)
        Dim Titulocontaduria As New PdfPCell(New Phrase("Contaduría General Provincia de Misiones" & vbCrLf & Autorizaciones.Nombrecompletodelservicio))
        Titulocontaduria.Colspan = 1
        Titulocontaduria.BorderWidth = 0
        Titulocontaduria.HorizontalAlignment = Element.ALIGN_RIGHT
        Tcabecera.AddCell(Titulocontaduria)
        'Dim espacio As New PdfPCell(New Phrase("x"))
        'espacio.Colspan = 0
        'espacio.BorderWidth = 0
        'Tcabecera.AddCell(espacio)
        '  Tcabecera.AddCell(espacio)
        Ttitulo.WidthPercentage = 100
        Dim anchoTtitulo() As Single = {100}
        Ttitulo.SetWidths(anchoTtitulo)
        'Dim saltoTitulo As New PdfPCell(New Phrase("1", salto))
        'saltoTitulo.Colspan = 1
        'saltoTitulo.BorderWidth = 0
        'Ttitulo.AddCell(saltoTitulo)
        '  Ttitulo.AddCell(espacio)
        ' Ttitulo.AddCell(espacio)
        '   Ttitulo.AddCell(espacio)
        'Dim Memb As New PdfPCell(New Phrase("2", fchica))
        'Memb.Colspan = 2
        'Memb.BorderWidth = 1
        'Memb.HorizontalAlignment = Element.ALIGN_CENTER
        'Ttitulo.AddCell(Memb)
        'Ttitulo.AddCell(espacio)
        'Ttitulo.AddCell(espacio)
        'Dim Titulo As New PdfPCell(New Phrase("3", Ftitulo))
        'Titulo.Colspan = 4
        'Titulo.BorderWidth = 1
        'Titulo.HorizontalAlignment = Element.ALIGN_RIGHT
        'Ttitulo.AddCell(Titulo)
        'Ttitulo.AddCell(espacio)
        'Dim saltoL As New PdfPCell(New Phrase("3 ", salto))
        'saltoL.Colspan = 6
        'saltoL.BorderWidth = 1
        'Ttitulo.AddCell(saltoL)
        'Ttitulo.AddCell(espacio)
        'Dim Dependencia As New PdfPCell(New Phrase("4", textdwn))
        'Dependencia.Colspan = 1
        'Dependencia.HorizontalAlignment = 1
        'Dependencia.BorderWidth = 1
        'Ttitulo.AddCell(Dependencia)
        'Dim DependenciaV As New PdfPCell(New Phrase("5", textdwn))
        'DependenciaV.Colspan = 9
        'DependenciaV.HorizontalAlignment = 1
        'DependenciaV.BorderWidth = 1
        'Ttitulo.AddCell(DependenciaV)
        ' Ttitulo.AddCell(espacio)
        ' Ttitulo.AddCell(espacio)
        ' Ttitulo.AddCell(espacio)
        ' Dim espacioF As New PdfPCell(New Phrase("6", salto))
        '  espacioF.Colspan = 1
        '  espacioF.BorderWidth = 1
        '  Ttitulo.AddCell(espacioF)
        '  Ttitulo.AddCell(espacioF)
        '   Ttitulo.AddCell(espacioF)
        '   Ttitulo.AddCell(espacioF)
        'Dim Tfecha As New PdfPTable(3) 'tabla  para la fecha
        'Dim Dia As New PdfPCell(New Phrase("DÍA", saltoF))
        'Dia.Colspan = 1
        'Dia.HorizontalAlignment = Element.ALIGN_CENTER
        'Dia.BorderWidth = 1
        'Dia.BackgroundColor = BaseColor.WHITE
        'Tfecha.AddCell(Dia)
        'Dim Mes As New PdfPCell(New Phrase("MES", saltoF))
        'Mes.Colspan = 1
        'Mes.HorizontalAlignment = Element.ALIGN_CENTER
        'Mes.BorderWidth = 1
        'Mes.BackgroundColor = BaseColor.WHITE
        'Tfecha.AddCell(Mes)
        'Dim year As New PdfPCell(New Phrase("AÑO", saltoF))
        'year.Colspan = 1
        'year.HorizontalAlignment = Element.ALIGN_CENTER
        'year.BorderWidth = 1
        'year.BackgroundColor = BaseColor.WHITE
        'Tfecha.AddCell(year)
        'Dim casteo As New PdfPCell((Tfecha))
        'casteo.Colspan = 1
        'casteo.BorderWidth = 0
        '   Ttitulo.AddCell(casteo)
        ' Ttitulo.AddCell(espacioF)
        'Ttitulo.AddCell(espacio)
        'Dim AreaAdmin As New PdfPCell(New Phrase("ÁREA ADMINISTRATIVA: ", textdwn))
        'AreaAdmin.Colspan = 1
        'AreaAdmin.HorizontalAlignment = 1
        'AreaAdmin.BorderWidth = 0
        'Ttitulo.AddCell(AreaAdmin)
        'Dim AreaAdminv As New PdfPCell(New Phrase(" DIVISION DE SISTEMAS", textdwn))
        'AreaAdminv.Colspan = 1
        'AreaAdminv.HorizontalAlignment = 1
        'AreaAdminv.BorderWidth = 1
        'Ttitulo.AddCell(AreaAdminv)
        'Ttitulo.AddCell(espacio)
        'Dim TfechaV As New PdfPTable(3) 'tabla  para la fecha
        'Dim DiaV As New PdfPCell(New Phrase(Date.Now.Day, textdwn))
        'DiaV.Colspan = 1
        'DiaV.HorizontalAlignment = Element.ALIGN_CENTER
        'DiaV.BorderWidth = 1
        'DiaV.BackgroundColor = BaseColor.WHITE
        'TfechaV.AddCell(DiaV)
        'Dim MesV As New PdfPCell(New Phrase(Date.Now.Month, textdwn))
        'MesV.Colspan = 1
        'MesV.HorizontalAlignment = Element.ALIGN_CENTER
        'MesV.BorderWidth = 1
        'MesV.BackgroundColor = BaseColor.WHITE
        'TfechaV.AddCell(MesV)
        'Dim yearV As New PdfPCell(New Phrase(Date.Now.Year, textdwn))
        'yearV.Colspan = 1
        'yearV.HorizontalAlignment = Element.ALIGN_CENTER
        'yearV.BorderWidth = 1
        'yearV.BackgroundColor = BaseColor.WHITE
        'TfechaV.AddCell(yearV)
        'Dim casteoV As New PdfPCell((TfechaV))
        'casteo.Colspan = 1
        'casteo.BorderWidth = 0
        'Ttitulo.AddCell(casteoV)
        '  Ttitulo.AddCell(espacio)
        '  Ttitulo.AddCell(saltoL)
        '  docume.Add(img)
        docume.Add(Tcabecera)
        docume.Add(Ttitulo)
    End Sub

End Class

Public Class itsEventsX
    Inherits PdfPageEventHelper
    Private cb As PdfContentByte
    Private headerTemplate, footerTemplate As PdfTemplate
    Private bf As BaseFont = Nothing
    Private PrintTime As DateTime = DateTime.Now
    Private _header As String
    Public textoencabezado As String
    Public Cuenta() As Cuenta_Bancaria
    Public Tipo_reporte As String

    Public Overrides Sub OnStartPage(ByVal writer As iTextSharp.text.pdf.PdfWriter, ByVal docume As iTextSharp.text.Document)
        Dim imagen As iTextSharp.text.Image 'declaración de imagen
        Dim textdwn As Font = FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD)
        Dim Tcabecera As New PdfPTable(3) 'tabla  para cabecera
        Dim Ttitulo As New PdfPTable(1) 'tabla para el titulo y datos generales
        Dim salto As Font = FontFactory.GetFont(FontFactory.HELVETICA, 6)
        Dim saltoF As Font = FontFactory.GetFont(FontFactory.HELVETICA, 6, Font.BOLD)
        Dim fchica As Font = FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.BOLD)
        Dim Ftitulo As Font = FontFactory.GetFont(FontFactory.HELVETICA, 14, Font.BOLD)
        'Agregar escabezado, el que queramos
        imagen = iTextSharp.text.Image.GetInstance(System.Drawing.Image.FromHbitmap(My.Resources.Logo.GetHbitmap()), System.Drawing.Imaging.ImageFormat.Png) 'nombre y ruta de la imagen a insertar
        imagen.ScalePercent(30) 'escala al tamaño de la imagen
        imagen.Alignment = iTextSharp.text.Image.ALIGN_LEFT
        'PARTE SUPERIOR DEL DOCUMENTO (MEMBRETADO, FECHA Y DATOS GENERALES)
        Tcabecera.WidthPercentage = 100
        Dim anchoTcabecera() As Single = {20, 30, 50}
        Tcabecera.SetWidths(anchoTcabecera)
        Dim margen As New PdfPCell(New Phrase("-1", salto))
        margen.Colspan = 9
        margen.BorderWidth = 1
        ' Tcabecera.AddCell(margen)
        'Datos Izquierda
        Dim img As New PdfPCell(imagen)
        img.HorizontalAlignment = Element.ALIGN_LEFT
        img.BorderWidth = 0
        Tcabecera.AddCell(img)
        Dim textocuentas As String = "Cuenta:"
        If Not Cuenta(0).nombrecuenta = "-1" Then
            For i = 0 To Cuenta.Count - 1
                textocuentas += Cuenta(i).nombrecuenta & " " & Cuenta(i).CuentaN & " (" & Autorizaciones.Year & ")" & vbCrLf
            Next
        Else
            textocuentas = "Varias"
        End If
        'Datos Mitad
        Dim Cuentabancaria As New PdfPCell(New Phrase(textocuentas))
        Cuentabancaria.Colspan = 1
        Cuentabancaria.BorderWidth = 0
        Cuentabancaria.HorizontalAlignment = Element.ALIGN_CENTER
        Tcabecera.AddCell(Cuentabancaria)
        'Datos Derecha
        Dim Titulocontaduria As PdfPCell
        If Not Cuenta(0).nombrecuenta = "-1" Then
            Titulocontaduria = New PdfPCell(New Phrase("Contaduría General Provincia de Misiones" & vbCrLf & Autorizaciones.Nombrecompletodelservicio & vbCrLf & textoencabezado))
        Else
            Titulocontaduria = New PdfPCell(New Phrase("Contaduría General Provincia de Misiones" & vbCrLf & Autorizaciones.Nombrecompletodelservicio))
        End If
        Titulocontaduria.Colspan = 1
        Titulocontaduria.BorderWidth = 0
        Titulocontaduria.HorizontalAlignment = Element.ALIGN_RIGHT
        Tcabecera.AddCell(Titulocontaduria)
        'Dim espacio As New PdfPCell(New Phrase("x"))
        'espacio.Colspan = 0
        'espacio.BorderWidth = 0
        'Tcabecera.AddCell(espacio)
        '  Tcabecera.AddCell(espacio)
        Ttitulo.WidthPercentage = 100
        Dim anchoTtitulo() As Single = {100}
        Ttitulo.SetWidths(anchoTtitulo)
        'Dim saltoTitulo As New PdfPCell(New Phrase("1", salto))
        'saltoTitulo.Colspan = 1
        'saltoTitulo.BorderWidth = 0
        'Ttitulo.AddCell(saltoTitulo)
        '  Ttitulo.AddCell(espacio)
        ' Ttitulo.AddCell(espacio)
        '   Ttitulo.AddCell(espacio)
        'Dim Memb As New PdfPCell(New Phrase("2", fchica))
        'Memb.Colspan = 2
        'Memb.BorderWidth = 1
        'Memb.HorizontalAlignment = Element.ALIGN_CENTER
        'Ttitulo.AddCell(Memb)
        'Ttitulo.AddCell(espacio)
        'Ttitulo.AddCell(espacio)
        'Dim Titulo As New PdfPCell(New Phrase("3", Ftitulo))
        'Titulo.Colspan = 4
        'Titulo.BorderWidth = 1
        'Titulo.HorizontalAlignment = Element.ALIGN_RIGHT
        'Ttitulo.AddCell(Titulo)
        'Ttitulo.AddCell(espacio)
        'Dim saltoL As New PdfPCell(New Phrase("3 ", salto))
        'saltoL.Colspan = 6
        'saltoL.BorderWidth = 1
        'Ttitulo.AddCell(saltoL)
        'Ttitulo.AddCell(espacio)
        'Dim Dependencia As New PdfPCell(New Phrase("4", textdwn))
        'Dependencia.Colspan = 1
        'Dependencia.HorizontalAlignment = 1
        'Dependencia.BorderWidth = 1
        'Ttitulo.AddCell(Dependencia)
        'Dim DependenciaV As New PdfPCell(New Phrase("5", textdwn))
        'DependenciaV.Colspan = 9
        'DependenciaV.HorizontalAlignment = 1
        'DependenciaV.BorderWidth = 1
        'Ttitulo.AddCell(DependenciaV)
        ' Ttitulo.AddCell(espacio)
        ' Ttitulo.AddCell(espacio)
        ' Ttitulo.AddCell(espacio)
        ' Dim espacioF As New PdfPCell(New Phrase("6", salto))
        '  espacioF.Colspan = 1
        '  espacioF.BorderWidth = 1
        '  Ttitulo.AddCell(espacioF)
        '  Ttitulo.AddCell(espacioF)
        '   Ttitulo.AddCell(espacioF)
        '   Ttitulo.AddCell(espacioF)
        'Dim Tfecha As New PdfPTable(3) 'tabla  para la fecha
        'Dim Dia As New PdfPCell(New Phrase("DÍA", saltoF))
        'Dia.Colspan = 1
        'Dia.HorizontalAlignment = Element.ALIGN_CENTER
        'Dia.BorderWidth = 1
        'Dia.BackgroundColor = BaseColor.WHITE
        'Tfecha.AddCell(Dia)
        'Dim Mes As New PdfPCell(New Phrase("MES", saltoF))
        'Mes.Colspan = 1
        'Mes.HorizontalAlignment = Element.ALIGN_CENTER
        'Mes.BorderWidth = 1
        'Mes.BackgroundColor = BaseColor.WHITE
        'Tfecha.AddCell(Mes)
        'Dim year As New PdfPCell(New Phrase("AÑO", saltoF))
        'year.Colspan = 1
        'year.HorizontalAlignment = Element.ALIGN_CENTER
        'year.BorderWidth = 1
        'year.BackgroundColor = BaseColor.WHITE
        'Tfecha.AddCell(year)
        'Dim casteo As New PdfPCell((Tfecha))
        'casteo.Colspan = 1
        'casteo.BorderWidth = 0
        '   Ttitulo.AddCell(casteo)
        ' Ttitulo.AddCell(espacioF)
        'Ttitulo.AddCell(espacio)
        'Dim AreaAdmin As New PdfPCell(New Phrase("ÁREA ADMINISTRATIVA: ", textdwn))
        'AreaAdmin.Colspan = 1
        'AreaAdmin.HorizontalAlignment = 1
        'AreaAdmin.BorderWidth = 0
        'Ttitulo.AddCell(AreaAdmin)
        'Dim AreaAdminv As New PdfPCell(New Phrase(" DIVISION DE SISTEMAS", textdwn))
        'AreaAdminv.Colspan = 1
        'AreaAdminv.HorizontalAlignment = 1
        'AreaAdminv.BorderWidth = 1
        'Ttitulo.AddCell(AreaAdminv)
        'Ttitulo.AddCell(espacio)
        'Dim TfechaV As New PdfPTable(3) 'tabla  para la fecha
        'Dim DiaV As New PdfPCell(New Phrase(Date.Now.Day, textdwn))
        'DiaV.Colspan = 1
        'DiaV.HorizontalAlignment = Element.ALIGN_CENTER
        'DiaV.BorderWidth = 1
        'DiaV.BackgroundColor = BaseColor.WHITE
        'TfechaV.AddCell(DiaV)
        'Dim MesV As New PdfPCell(New Phrase(Date.Now.Month, textdwn))
        'MesV.Colspan = 1
        'MesV.HorizontalAlignment = Element.ALIGN_CENTER
        'MesV.BorderWidth = 1
        'MesV.BackgroundColor = BaseColor.WHITE
        'TfechaV.AddCell(MesV)
        'Dim yearV As New PdfPCell(New Phrase(Date.Now.Year, textdwn))
        'yearV.Colspan = 1
        'yearV.HorizontalAlignment = Element.ALIGN_CENTER
        'yearV.BorderWidth = 1
        'yearV.BackgroundColor = BaseColor.WHITE
        'TfechaV.AddCell(yearV)
        'Dim casteoV As New PdfPCell((TfechaV))
        'casteo.Colspan = 1
        'casteo.BorderWidth = 0
        'Ttitulo.AddCell(casteoV)
        '  Ttitulo.AddCell(espacio)
        '  Ttitulo.AddCell(saltoL)
        '  docume.Add(img)
        docume.Add(Tcabecera)
        docume.Add(Ttitulo)
    End Sub

    'Public Overrides Sub OnEndPage(ByVal writer As iTextSharp.text.pdf.PdfWriter, ByVal document As iTextSharp.text.Document)
    '    ' Dim footerImage As iTextSharp.text.Image = New Quote().GetFooter()
    '    Dim page As Rectangle = document.PageSize()
    '    Dim foot As PdfPTable = New PdfPTable(1)
    '    foot.DefaultCell.BorderWidth = 0
    '    '    foot.DefaultCell.BorderColorBottom = New Color(255, 255, 255)
    '    '  foot.AddCell(footerImage)
    '    foot.TotalWidth = page.Width - document.LeftMargin - document.RightMargin
    '    foot.WriteSelectedRows(0, -1, document.LeftMargin, foot.TotalHeight - 7, writer.DirectContent)
    'End Sub
    'Public Overrides Sub OnEndPage(ByVal writer As iTextSharp.text.pdf.PdfWriter, ByVal docume As iTextSharp.text.Document)
    '    MyBase.OnEndPage(writer, Document)
    '    Dim baseFontNormal As iTextSharp.text.Font = New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12.0F, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)
    '    Dim baseFontBig As iTextSharp.text.Font = New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12.0F, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)
    '    Dim p1Header As Phrase = New Phrase("Sample Header Here", baseFontNormal)
    '    Dim pdfTab As PdfPTable = New PdfPTable(3)
    '    Dim pdfCell1 As PdfPCell = New PdfPCell()
    '    Dim pdfCell2 As PdfPCell = New PdfPCell(p1Header)
    '    Dim pdfCell3 As PdfPCell = New PdfPCell()
    '    Dim text As String = "Page " & writer.PageNumber & " of "
    '    If True Then
    '        cb.BeginText()
    '        cb.SetFontAndSize(bf, 12)
    '        cb.SetTextMatrix(Document.PageSize.GetRight(200), Document.PageSize.GetTop(45))
    '        cb.ShowText(text)
    '        cb.EndText()
    '        Dim len As Single = bf.GetWidthPoint(text, 12)
    '        cb.AddTemplate(headerTemplate, Document.PageSize.GetRight(200) + len, Document.PageSize.GetTop(45))
    '    End If
    '    If True Then
    '        cb.BeginText()
    '        cb.SetFontAndSize(bf, 12)
    '        cb.SetTextMatrix(Document.PageSize.GetRight(180), Document.PageSize.GetBottom(30))
    '        cb.ShowText(text)
    '        cb.EndText()
    '        Dim len As Single = bf.GetWidthPoint(text, 12)
    '        cb.AddTemplate(footerTemplate, Document.PageSize.GetRight(180) + len, Document.PageSize.GetBottom(30))
    '    End If
    '    Dim pdfCell4 As PdfPCell = New PdfPCell(New Phrase("Sub Header Description", baseFontNormal))
    '    Dim pdfCell5 As PdfPCell = New PdfPCell(New Phrase("Date:" & PrintTime.ToShortDateString(), baseFontBig))
    '    Dim pdfCell6 As PdfPCell = New PdfPCell()
    '    Dim pdfCell7 As PdfPCell = New PdfPCell(New Phrase("TIME:" & String.Format("{0:t}", DateTime.Now), baseFontBig))
    '    pdfCell1.HorizontalAlignment = Element.ALIGN_CENTER
    '    pdfCell2.HorizontalAlignment = Element.ALIGN_CENTER
    '    pdfCell3.HorizontalAlignment = Element.ALIGN_CENTER
    '    pdfCell4.HorizontalAlignment = Element.ALIGN_CENTER
    '    pdfCell5.HorizontalAlignment = Element.ALIGN_CENTER
    '    pdfCell6.HorizontalAlignment = Element.ALIGN_CENTER
    '    pdfCell7.HorizontalAlignment = Element.ALIGN_CENTER
    '    pdfCell2.VerticalAlignment = Element.ALIGN_BOTTOM
    '    pdfCell3.VerticalAlignment = Element.ALIGN_MIDDLE
    '    pdfCell4.VerticalAlignment = Element.ALIGN_TOP
    '    pdfCell5.VerticalAlignment = Element.ALIGN_MIDDLE
    '    pdfCell6.VerticalAlignment = Element.ALIGN_MIDDLE
    '    pdfCell7.VerticalAlignment = Element.ALIGN_MIDDLE
    '    pdfCell4.Colspan = 3
    '    pdfCell1.Border = 0
    '    pdfCell2.Border = 0
    '    pdfCell3.Border = 0
    '    pdfCell4.Border = 0
    '    pdfCell5.Border = 0
    '    pdfCell6.Border = 0
    '    pdfCell7.Border = 0
    '    pdfTab.AddCell(pdfCell1)
    '    pdfTab.AddCell(pdfCell2)
    '    pdfTab.AddCell(pdfCell3)
    '    pdfTab.AddCell(pdfCell4)
    '    pdfTab.AddCell(pdfCell5)
    '    pdfTab.AddCell(pdfCell6)
    '    pdfTab.AddCell(pdfCell7)
    '    pdfTab.TotalWidth = Document.PageSize.Width - 80.0F
    '    pdfTab.WidthPercentage = 70
    '    pdfTab.WriteSelectedRows(0, -1, 40, Document.PageSize.Height - 30, writer.DirectContent)
    '    cb.MoveTo(40, Document.PageSize.Height - 100)
    '    cb.LineTo(Document.PageSize.Width - 40, Document.PageSize.Height - 100)
    '    cb.Stroke()
    '    cb.MoveTo(40, Document.PageSize.GetBottom(50))
    '    cb.LineTo(Document.PageSize.Width - 40, Document.PageSize.GetBottom(50))
    '    cb.Stroke()
    'End Sub
End Class

''' <summary>
''' encabezado custom, se alimenta de la pdftable (tablaencabezado)
''' </summary>
Public Class itsEventscustom
    Inherits PdfPageEventHelper
    Public tablaencabezado As PdfPTable
    Private headerTemplate, footerTemplate As PdfTemplate

    Public Overrides Sub OnStartPage(ByVal writer As iTextSharp.text.pdf.PdfWriter, ByVal docume As iTextSharp.text.Document)
        'MyBase.OnStartPage(writer, docume)
        'docume.Add(tablaencabezado)
    End Sub

    Public Overrides Sub OnEndPage(ByVal writer As PdfWriter, ByVal document As Document)
        ' Dim page As Rectangle = document.PageSize
        Dim head As PdfPTable = tablaencabezado
        head.TotalWidth = document.PageSize.Width - (document.LeftMargin + document.RightMargin)
        head.LockedWidth = True
        head.WriteSelectedRows(0, -1, document.Left, document.PageSize.Height - 10, writer.DirectContent)
    End Sub

    'Public Overrides Sub OnEndPage(ByVal writer As iTextSharp.text.pdf.PdfWriter, ByVal document As iTextSharp.text.Document)
    '    ' Dim footerImage As iTextSharp.text.Image = New Quote().GetFooter()
    '    Dim page As Rectangle = document.PageSize()
    '    Dim foot As PdfPTable = New PdfPTable(1)
    '    foot.DefaultCell.BorderWidth = 0
    '    '    foot.DefaultCell.BorderColorBottom = New Color(255, 255, 255)
    '    '  foot.AddCell(footerImage)
    '    foot.TotalWidth = page.Width - document.LeftMargin - document.RightMargin
    '    foot.WriteSelectedRows(0, -1, document.LeftMargin, foot.TotalHeight - 7, writer.DirectContent)
    'End Sub
    'Public Overrides Sub OnEndPage(ByVal writer As iTextSharp.text.pdf.PdfWriter, ByVal docume As iTextSharp.text.Document)
    '    MyBase.OnEndPage(writer, Document)
    '    Dim baseFontNormal As iTextSharp.text.Font = New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12.0F, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)
    '    Dim baseFontBig As iTextSharp.text.Font = New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12.0F, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)
    '    Dim p1Header As Phrase = New Phrase("Sample Header Here", baseFontNormal)
    '    Dim pdfTab As PdfPTable = New PdfPTable(3)
    '    Dim pdfCell1 As PdfPCell = New PdfPCell()
    '    Dim pdfCell2 As PdfPCell = New PdfPCell(p1Header)
    '    Dim pdfCell3 As PdfPCell = New PdfPCell()
    '    Dim text As String = "Page " & writer.PageNumber & " of "
    '    If True Then
    '        cb.BeginText()
    '        cb.SetFontAndSize(bf, 12)
    '        cb.SetTextMatrix(Document.PageSize.GetRight(200), Document.PageSize.GetTop(45))
    '        cb.ShowText(text)
    '        cb.EndText()
    '        Dim len As Single = bf.GetWidthPoint(text, 12)
    '        cb.AddTemplate(headerTemplate, Document.PageSize.GetRight(200) + len, Document.PageSize.GetTop(45))
    '    End If
    '    If True Then
    '        cb.BeginText()
    '        cb.SetFontAndSize(bf, 12)
    '        cb.SetTextMatrix(Document.PageSize.GetRight(180), Document.PageSize.GetBottom(30))
    '        cb.ShowText(text)
    '        cb.EndText()
    '        Dim len As Single = bf.GetWidthPoint(text, 12)
    '        cb.AddTemplate(footerTemplate, Document.PageSize.GetRight(180) + len, Document.PageSize.GetBottom(30))
    '    End If
    '    Dim pdfCell4 As PdfPCell = New PdfPCell(New Phrase("Sub Header Description", baseFontNormal))
    '    Dim pdfCell5 As PdfPCell = New PdfPCell(New Phrase("Date:" & PrintTime.ToShortDateString(), baseFontBig))
    '    Dim pdfCell6 As PdfPCell = New PdfPCell()
    '    Dim pdfCell7 As PdfPCell = New PdfPCell(New Phrase("TIME:" & String.Format("{0:t}", DateTime.Now), baseFontBig))
    '    pdfCell1.HorizontalAlignment = Element.ALIGN_CENTER
    '    pdfCell2.HorizontalAlignment = Element.ALIGN_CENTER
    '    pdfCell3.HorizontalAlignment = Element.ALIGN_CENTER
    '    pdfCell4.HorizontalAlignment = Element.ALIGN_CENTER
    '    pdfCell5.HorizontalAlignment = Element.ALIGN_CENTER
    '    pdfCell6.HorizontalAlignment = Element.ALIGN_CENTER
    '    pdfCell7.HorizontalAlignment = Element.ALIGN_CENTER
    '    pdfCell2.VerticalAlignment = Element.ALIGN_BOTTOM
    '    pdfCell3.VerticalAlignment = Element.ALIGN_MIDDLE
    '    pdfCell4.VerticalAlignment = Element.ALIGN_TOP
    '    pdfCell5.VerticalAlignment = Element.ALIGN_MIDDLE
    '    pdfCell6.VerticalAlignment = Element.ALIGN_MIDDLE
    '    pdfCell7.VerticalAlignment = Element.ALIGN_MIDDLE
    '    pdfCell4.Colspan = 3
    '    pdfCell1.Border = 0
    '    pdfCell2.Border = 0
    '    pdfCell3.Border = 0
    '    pdfCell4.Border = 0
    '    pdfCell5.Border = 0
    '    pdfCell6.Border = 0
    '    pdfCell7.Border = 0
    '    pdfTab.AddCell(pdfCell1)
    '    pdfTab.AddCell(pdfCell2)
    '    pdfTab.AddCell(pdfCell3)
    '    pdfTab.AddCell(pdfCell4)
    '    pdfTab.AddCell(pdfCell5)
    '    pdfTab.AddCell(pdfCell6)
    '    pdfTab.AddCell(pdfCell7)
    '    pdfTab.TotalWidth = Document.PageSize.Width - 80.0F
    '    pdfTab.WidthPercentage = 70
    '    pdfTab.WriteSelectedRows(0, -1, 40, Document.PageSize.Height - 30, writer.DirectContent)
    '    cb.MoveTo(40, Document.PageSize.Height - 100)
    '    cb.LineTo(Document.PageSize.Width - 40, Document.PageSize.Height - 100)
    '    cb.Stroke()
    '    cb.MoveTo(40, Document.PageSize.GetBottom(50))
    '    cb.LineTo(Document.PageSize.Width - 40, Document.PageSize.GetBottom(50))
    '    cb.Stroke()
    'End Sub
End Class

Public Class itsEventsNOVALIDOCOMOORDENPAGO
    Inherits PdfPageEventHelper
    Public tablaencabezado As PdfPTable
    Public NOVALIDO As Boolean = False
    Private headerTemplate, footerTemplate As PdfTemplate

    Public Overrides Sub OnStartPage(ByVal writer As iTextSharp.text.pdf.PdfWriter, ByVal docume As iTextSharp.text.Document)
        'MyBase.OnStartPage(writer, docume)
        'docume.Add(tablaencabezado)
    End Sub

    Public Overrides Sub OnEndPage(ByVal writer As PdfWriter, ByVal document As Document)
        ' Dim page As Rectangle = document.PageSize
        Dim head As PdfPTable = tablaencabezado
        Dim Datosbasicosordenpago As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(1)
        Datosbasicosordenpago.TotalWidth = document.PageSize.Width
        ' Datosbasicosordenpago.TotalHeight = document.PageSize.Height
        Datosbasicosordenpago.LockedWidth = True
        Datosbasicosordenpago.PaddingTop = 5
        tamaniocolumna = New Single(0) {}
        tamaniocolumna(0) = Convert.ToSingle(document.PageSize.Width * 1)
        Datosbasicosordenpago.SetWidths(tamaniocolumna)
        Dim CELL As PdfPCell = PhrasepdfSKEW(" NO VALIDO COMO ORDEN DE PAGO ", 33, True, 0.5, 2, 1, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE, 45)
        Datosbasicosordenpago.AddCell(CELL)
        If NOVALIDO = True Then
            'head.TotalWidth = document.PageSize.Width - (document.LeftMargin + document.RightMargin)
            'head.LockedWidth = True
            Datosbasicosordenpago.WriteSelectedRows(0, -1, document.Left, document.PageSize.Height - 10, writer.DirectContent)
        End If
    End Sub

    'Public Overrides Sub OnEndPage(ByVal writer As iTextSharp.text.pdf.PdfWriter, ByVal document As iTextSharp.text.Document)
    '    ' Dim footerImage As iTextSharp.text.Image = New Quote().GetFooter()
    '    Dim page As Rectangle = document.PageSize()
    '    Dim foot As PdfPTable = New PdfPTable(1)
    '    foot.DefaultCell.BorderWidth = 0
    '    '    foot.DefaultCell.BorderColorBottom = New Color(255, 255, 255)
    '    '  foot.AddCell(footerImage)
    '    foot.TotalWidth = page.Width - document.LeftMargin - document.RightMargin
    '    foot.WriteSelectedRows(0, -1, document.LeftMargin, foot.TotalHeight - 7, writer.DirectContent)
    'End Sub
    'Public Overrides Sub OnEndPage(ByVal writer As iTextSharp.text.pdf.PdfWriter, ByVal docume As iTextSharp.text.Document)
    '    MyBase.OnEndPage(writer, Document)
    '    Dim baseFontNormal As iTextSharp.text.Font = New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12.0F, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)
    '    Dim baseFontBig As iTextSharp.text.Font = New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12.0F, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)
    '    Dim p1Header As Phrase = New Phrase("Sample Header Here", baseFontNormal)
    '    Dim pdfTab As PdfPTable = New PdfPTable(3)
    '    Dim pdfCell1 As PdfPCell = New PdfPCell()
    '    Dim pdfCell2 As PdfPCell = New PdfPCell(p1Header)
    '    Dim pdfCell3 As PdfPCell = New PdfPCell()
    '    Dim text As String = "Page " & writer.PageNumber & " of "
    '    If True Then
    '        cb.BeginText()
    '        cb.SetFontAndSize(bf, 12)
    '        cb.SetTextMatrix(Document.PageSize.GetRight(200), Document.PageSize.GetTop(45))
    '        cb.ShowText(text)
    '        cb.EndText()
    '        Dim len As Single = bf.GetWidthPoint(text, 12)
    '        cb.AddTemplate(headerTemplate, Document.PageSize.GetRight(200) + len, Document.PageSize.GetTop(45))
    '    End If
    '    If True Then
    '        cb.BeginText()
    '        cb.SetFontAndSize(bf, 12)
    '        cb.SetTextMatrix(Document.PageSize.GetRight(180), Document.PageSize.GetBottom(30))
    '        cb.ShowText(text)
    '        cb.EndText()
    '        Dim len As Single = bf.GetWidthPoint(text, 12)
    '        cb.AddTemplate(footerTemplate, Document.PageSize.GetRight(180) + len, Document.PageSize.GetBottom(30))
    '    End If
    '    Dim pdfCell4 As PdfPCell = New PdfPCell(New Phrase("Sub Header Description", baseFontNormal))
    '    Dim pdfCell5 As PdfPCell = New PdfPCell(New Phrase("Date:" & PrintTime.ToShortDateString(), baseFontBig))
    '    Dim pdfCell6 As PdfPCell = New PdfPCell()
    '    Dim pdfCell7 As PdfPCell = New PdfPCell(New Phrase("TIME:" & String.Format("{0:t}", DateTime.Now), baseFontBig))
    '    pdfCell1.HorizontalAlignment = Element.ALIGN_CENTER
    '    pdfCell2.HorizontalAlignment = Element.ALIGN_CENTER
    '    pdfCell3.HorizontalAlignment = Element.ALIGN_CENTER
    '    pdfCell4.HorizontalAlignment = Element.ALIGN_CENTER
    '    pdfCell5.HorizontalAlignment = Element.ALIGN_CENTER
    '    pdfCell6.HorizontalAlignment = Element.ALIGN_CENTER
    '    pdfCell7.HorizontalAlignment = Element.ALIGN_CENTER
    '    pdfCell2.VerticalAlignment = Element.ALIGN_BOTTOM
    '    pdfCell3.VerticalAlignment = Element.ALIGN_MIDDLE
    '    pdfCell4.VerticalAlignment = Element.ALIGN_TOP
    '    pdfCell5.VerticalAlignment = Element.ALIGN_MIDDLE
    '    pdfCell6.VerticalAlignment = Element.ALIGN_MIDDLE
    '    pdfCell7.VerticalAlignment = Element.ALIGN_MIDDLE
    '    pdfCell4.Colspan = 3
    '    pdfCell1.Border = 0
    '    pdfCell2.Border = 0
    '    pdfCell3.Border = 0
    '    pdfCell4.Border = 0
    '    pdfCell5.Border = 0
    '    pdfCell6.Border = 0
    '    pdfCell7.Border = 0
    '    pdfTab.AddCell(pdfCell1)
    '    pdfTab.AddCell(pdfCell2)
    '    pdfTab.AddCell(pdfCell3)
    '    pdfTab.AddCell(pdfCell4)
    '    pdfTab.AddCell(pdfCell5)
    '    pdfTab.AddCell(pdfCell6)
    '    pdfTab.AddCell(pdfCell7)
    '    pdfTab.TotalWidth = Document.PageSize.Width - 80.0F
    '    pdfTab.WidthPercentage = 70
    '    pdfTab.WriteSelectedRows(0, -1, 40, Document.PageSize.Height - 30, writer.DirectContent)
    '    cb.MoveTo(40, Document.PageSize.Height - 100)
    '    cb.LineTo(Document.PageSize.Width - 40, Document.PageSize.Height - 100)
    '    cb.Stroke()
    '    cb.MoveTo(40, Document.PageSize.GetBottom(50))
    '    cb.LineTo(Document.PageSize.Width - 40, Document.PageSize.GetBottom(50))
    '    cb.Stroke()
    'End Sub
End Class

'Clase para poder manejar el hash de encriptacion debido a la dificultad de calculo del crc/hash en diferentes sistemas de 32bits y 64bits
'/**
'* La Class AES_basededatos Gestiona la encriptación dentro del programa y provee obfuscación a las interacciones inseguras.
'*
'* @author (Roberto H. Romero)
'* @version (2018-02-19)
'*/