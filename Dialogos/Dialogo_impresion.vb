Imports PdfiumViewer

Public Class Dialogo_impresion
    Dim impresor_actual As Impresion

    Private Sub Dialogo_impresion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Public Sub Cargar_impresion(ByRef impresor As Impresion)
        impresor_actual = impresor
        Sizetitulo.Value = impresor_actual.tamaniofuentetitulos
        SizeTablas.Value = impresor_actual.tamaniofuentetablas
        SizeTexto.Value = impresor_actual.tamaniofuente
        Cantidaddecimales_numeric.Value = impresor_actual.decimales
        'dirección
        'impresor_actual.Sello_direccion
        LabelDireccion.Text = impresor_actual.Sello_direccion.Nombre_sello
        'tesoreria
        'impresor_actual.Sello_Tesoreria
        LabelTesoreria.Text = impresor_actual.Sello_Tesoreria.Nombre_sello
        'contabilidad
        'impresor_actual.Sello_Contabilidad
        LabelContabilidad.Text = impresor_actual.Sello_Contabilidad.Nombre_sello
        'suministros
        'impresor_actual.Sello_Suministros
        LabelSuministros.Text = impresor_actual.Sello_Suministros.Nombre_sello
        'delegado fiscal
        'impresor_actual.Sello_Delegadofiscal
        LabelDelegadofiscal.Text = impresor_actual.Sello_Delegadofiscal.Nombre_sello
        margen_arriba.Value = impresor_actual.margintop
        margen_abajo.Value = impresor_actual.marginbottom
        margen_izquierdo.Value = impresor_actual.marginleft
        margen_derecho.Value = impresor_actual.marginright
        If (impresor_actual.hoja.Width + impresor_actual.hoja.Height) = (iTextSharp.text.PageSize.LEGAL.Width + iTextSharp.text.PageSize.LEGAL.Height) Then
            tamaniohoja_boton.Text = "LEGAL"
        Else
            tamaniohoja_boton.Text = "A4"
        End If
        Me.ShowDialog()
    End Sub

    Private Sub Refresh_boton_Click(sender As Object, e As EventArgs) Handles Refresh_boton.Click
        Using dialog As New OpenFileDialog()
            dialog.Filter = "PDF files |*.PDF"
            dialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            dialog.Title = "Seleccione el archivo a visualizar"
            If dialog.ShowDialog() = DialogResult.OK Then
                'Dim doc As PdfiumViewer.IPdfDocument
                'doc.
                Dim doc As PdfDocument
                doc = PdfiumViewer.PdfDocument.Load(dialog.FileName)
                Visor_PDF.Document = doc
                Visor_PDF.Refresh()
                'Using document = PdfiumViewer.PdfDocument.Load("input.pdf")
                '    Dim image = document.Render(1, 300, 300, True)
                '    image.Save("output.png", ImageFormat.Png)
                'End Using
            End If
        End Using
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
    End Sub

    Private Sub guardarimpresor_actual()
        impresor_actual.tamaniofuentetitulos = Sizetitulo.Value
        impresor_actual.tamaniofuentetablas = SizeTablas.Value
        impresor_actual.tamaniofuente = SizeTexto.Value
        ''dirección
        ''impresor_actual.Sello_direccion
        'LabelDireccion.Text = impresor_actual.Sello_direccion.Nombre_sello
        ''tesoreria
        ''impresor_actual.Sello_Tesoreria
        'LabelTesoreria.Text = impresor_actual.Sello_Tesoreria.Nombre_sello
        ''contabilidad
        ''impresor_actual.Sello_Contabilidad
        'LabelContabilidad.Text = impresor_actual.Sello_Contabilidad.Nombre_sello
        ''suministros
        ''impresor_actual.Sello_Suministros
        'LabelSuministros.Text = impresor_actual.Sello_Suministros.Nombre_sello
        ''delegado fiscal
        ''impresor_actual.Sello_Delegadofiscal
        'LabelDelegadofiscal.Text = impresor_actual.Sello_Delegadofiscal.Nombre_sello
        impresor_actual.margintop = margen_arriba.Value
        impresor_actual.marginbottom = margen_abajo.Value
        impresor_actual.marginleft = margen_izquierdo.Value
        impresor_actual.marginright = margen_derecho.Value
        impresor_actual.decimales = Cantidaddecimales_numeric.Value
        If tamaniohoja_boton.Text = "LEGAL" Then
            impresor_actual.hoja = iTextSharp.text.PageSize.LEGAL
        Else
            impresor_actual.hoja = iTextSharp.text.PageSize.A4
        End If
        'if (impresor_actual.hoja.Width +impresor_actual.hoja.height) = (iTextSharp.text.PageSize.LEGAL.Width +iTextSharp.text.PageSize.LEGAL.Height) Then
        '    tamaniohoja_boton .Text="LEGAL"
        'Else
        '    tamaniohoja_boton .Text="A4"
        'End If
    End Sub

    Private Sub tamaniohoja_boton_Click(sender As Object, e As EventArgs) Handles tamaniohoja_boton.Click
        tamaniohoja()
    End Sub

    Private Sub tamaniohoja()
        If tamaniohoja_boton.Text = "LEGAL" Then
            tamaniohoja_boton.Text = "A4"
        Else
            tamaniohoja_boton.Text = "LEGAL"
        End If
    End Sub

    Private Sub selloseleccion(ByVal sello As Sello)
        Dim Sello_datatable As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@departamento", sello.SelloDepartamento)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@fecha", sello.FechaSello)
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
        DialogDialogo_Datagridview.Carga_General(Sello_datatable, "Seleccione la persona que ocupa el cargo de:" & sello.Cargo, "Seleccionar persona", "Cancelar")
        If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) And DialogDialogo_Datagridview.Datosdialogo_datagridview.SelectedRows.Count = 1 Then
            sello.Nombre_sello = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item("Nombre_sello").Value.ToString
            sello.Cargo = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item("cargo").Value.ToString
        Else
        End If
        'PARRAFOCOMPLETO.Add(New Phrase(New iTextSharp.text.Chunk(Chr(160) & Chr(160) & Chr(160) & Chr(160) & Chr(160) & Chr(160) &
        '                                                         DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item("Nombre_sello").Value.ToString &
        '                                                         Chr(160) & Chr(160) & Chr(160) & Chr(160) & Chr(160) & Chr(160) &
        '                                                         vbNewLine, PDF_fuente_variable(fuente_tamanio, True, True))))
    End Sub

    Private Sub Boton_SelloDireccion_Click(sender As Object, e As EventArgs) Handles Boton_SelloDireccion.Click
        selloseleccion(impresor_actual.Sello_direccion)
        LabelDireccion.Text = impresor_actual.Sello_direccion.Nombre_sello
    End Sub

    Private Sub Boton_SelloTesoreria_Click(sender As Object, e As EventArgs) Handles Boton_SelloTesoreria.Click
        selloseleccion(impresor_actual.Sello_Tesoreria)
        LabelTesoreria.Text = impresor_actual.Sello_Tesoreria.Nombre_sello
    End Sub

    Private Sub Boton_SelloContabilidad_Click(sender As Object, e As EventArgs) Handles Boton_SelloContabilidad.Click
        selloseleccion(impresor_actual.Sello_Contabilidad)
        LabelContabilidad.Text = impresor_actual.Sello_Contabilidad.Nombre_sello
    End Sub

    Private Sub Boton_SelloSuministros_Click(sender As Object, e As EventArgs) Handles Boton_SelloSuministros.Click
        selloseleccion(impresor_actual.Sello_Suministros)
        LabelSuministros.Text = impresor_actual.Sello_Suministros.Nombre_sello
    End Sub

    Private Sub Boton_SelloDelegadofiscal_Click(sender As Object, e As EventArgs) Handles Boton_SelloDelegadofiscal.Click
        selloseleccion(impresor_actual.Sello_Delegadofiscal)
        LabelDelegadofiscal.Text = impresor_actual.Sello_Delegadofiscal.Nombre_sello
    End Sub

    Private Sub IMPRIMIR_BOTON_Click(sender As Object, e As EventArgs) Handles IMPRIMIR_BOTON.Click
        guardarimpresor_actual()
        Me.Close()
    End Sub

End Class