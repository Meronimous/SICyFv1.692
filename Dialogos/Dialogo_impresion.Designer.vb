<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialogo_impresion
    Inherits System.Windows.Forms.Form
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dialogo_impresion))
        Me.Visor_PDF = New PdfiumViewer.PdfViewer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Cantidaddecimales_numeric = New SICyF.Flicker_Numericcontrol_Numero()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SizeTablas = New SICyF.Flicker_Numericcontrol_Numero()
        Me.SizeTexto = New SICyF.Flicker_Numericcontrol_Numero()
        Me.Sizetitulo = New SICyF.Flicker_Numericcontrol_Numero()
        Me.Refresh_boton = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Boton_SelloDelegadofiscal = New System.Windows.Forms.Button()
        Me.LabelDelegadofiscal = New System.Windows.Forms.Label()
        Me.Boton_SelloSuministros = New System.Windows.Forms.Button()
        Me.LabelSuministros = New System.Windows.Forms.Label()
        Me.Boton_SelloContabilidad = New System.Windows.Forms.Button()
        Me.LabelContabilidad = New System.Windows.Forms.Label()
        Me.Boton_SelloTesoreria = New System.Windows.Forms.Button()
        Me.LabelTesoreria = New System.Windows.Forms.Label()
        Me.Boton_SelloDireccion = New System.Windows.Forms.Button()
        Me.LabelDireccion = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tamaniohoja_boton = New System.Windows.Forms.Button()
        Me.margen_abajo = New SICyF.Flicker_Numericcontrol_Numero()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.margen_derecho = New SICyF.Flicker_Numericcontrol_Numero()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.margen_arriba = New SICyF.Flicker_Numericcontrol_Numero()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.margen_izquierdo = New SICyF.Flicker_Numericcontrol_Numero()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.IMPRIMIR_BOTON = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout
        CType(Me.Cantidaddecimales_numeric,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.SizeTablas,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.SizeTexto,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Sizetitulo,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupBox4.SuspendLayout
        Me.GroupBox2.SuspendLayout
        CType(Me.margen_abajo,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.margen_derecho,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.margen_arriba,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.margen_izquierdo,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'Visor_PDF
        '
        Me.Visor_PDF.BackColor = System.Drawing.Color.White
        Me.Visor_PDF.Location = New System.Drawing.Point(617, 12)
        Me.Visor_PDF.Name = "Visor_PDF"
        Me.Visor_PDF.Size = New System.Drawing.Size(53, 750)
        Me.Visor_PDF.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(11, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Tamaño Fuente Titulo"
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(11, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Tamaño Fuente Texto"
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(11, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Fuente de Tablas"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.Cantidaddecimales_numeric)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.SizeTablas)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.SizeTexto)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Sizetitulo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Orange
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox1.Size = New System.Drawing.Size(261, 271)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = false
        Me.GroupBox1.Text = "Tamaño de Fuentes"
        '
        'Cantidaddecimales_numeric
        '
        Me.Cantidaddecimales_numeric.Location = New System.Drawing.Point(15, 207)
        Me.Cantidaddecimales_numeric.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Cantidaddecimales_numeric.Name = "Cantidaddecimales_numeric"
        Me.Cantidaddecimales_numeric.Size = New System.Drawing.Size(95, 25)
        Me.Cantidaddecimales_numeric.Suffix = Nothing
        Me.Cantidaddecimales_numeric.TabIndex = 8
        Me.Cantidaddecimales_numeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Cantidaddecimales_numeric.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label8
        '
        Me.Label8.AutoSize = true
        Me.Label8.BackColor = System.Drawing.Color.Black
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label8.ForeColor = System.Drawing.Color.Aqua
        Me.Label8.Location = New System.Drawing.Point(12, 191)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(116, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Cantidad de Decimales"
        '
        'SizeTablas
        '
        Me.SizeTablas.Location = New System.Drawing.Point(14, 144)
        Me.SizeTablas.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.SizeTablas.Name = "SizeTablas"
        Me.SizeTablas.Size = New System.Drawing.Size(95, 25)
        Me.SizeTablas.Suffix = Nothing
        Me.SizeTablas.TabIndex = 6
        Me.SizeTablas.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'SizeTexto
        '
        Me.SizeTexto.Location = New System.Drawing.Point(14, 91)
        Me.SizeTexto.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.SizeTexto.Name = "SizeTexto"
        Me.SizeTexto.Size = New System.Drawing.Size(95, 25)
        Me.SizeTexto.Suffix = Nothing
        Me.SizeTexto.TabIndex = 4
        Me.SizeTexto.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Sizetitulo
        '
        Me.Sizetitulo.Location = New System.Drawing.Point(17, 37)
        Me.Sizetitulo.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Sizetitulo.Name = "Sizetitulo"
        Me.Sizetitulo.Size = New System.Drawing.Size(95, 25)
        Me.Sizetitulo.Suffix = Nothing
        Me.Sizetitulo.TabIndex = 2
        Me.Sizetitulo.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Refresh_boton
        '
        Me.Refresh_boton.BackColor = System.Drawing.Color.Green
        Me.Refresh_boton.BackgroundImage = CType(resources.GetObject("Refresh_boton.BackgroundImage"),System.Drawing.Image)
        Me.Refresh_boton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Refresh_boton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Refresh_boton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Refresh_boton.ForeColor = System.Drawing.Color.Black
        Me.Refresh_boton.Location = New System.Drawing.Point(394, 736)
        Me.Refresh_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Refresh_boton.Name = "Refresh_boton"
        Me.Refresh_boton.Size = New System.Drawing.Size(32, 26)
        Me.Refresh_boton.TabIndex = 24
        Me.Refresh_boton.Text = ""&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)
        Me.Refresh_boton.UseVisualStyleBackColor = false
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.White
        Me.GroupBox4.Controls.Add(Me.Boton_SelloDelegadofiscal)
        Me.GroupBox4.Controls.Add(Me.LabelDelegadofiscal)
        Me.GroupBox4.Controls.Add(Me.Boton_SelloSuministros)
        Me.GroupBox4.Controls.Add(Me.LabelSuministros)
        Me.GroupBox4.Controls.Add(Me.Boton_SelloContabilidad)
        Me.GroupBox4.Controls.Add(Me.LabelContabilidad)
        Me.GroupBox4.Controls.Add(Me.Boton_SelloTesoreria)
        Me.GroupBox4.Controls.Add(Me.LabelTesoreria)
        Me.GroupBox4.Controls.Add(Me.Boton_SelloDireccion)
        Me.GroupBox4.Controls.Add(Me.LabelDireccion)
        Me.GroupBox4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.DarkRed
        Me.GroupBox4.Location = New System.Drawing.Point(13, 286)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox4.Size = New System.Drawing.Size(509, 219)
        Me.GroupBox4.TabIndex = 15
        Me.GroupBox4.TabStop = false
        Me.GroupBox4.Text = "Sellos"
        '
        'Boton_SelloDelegadofiscal
        '
        Me.Boton_SelloDelegadofiscal.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Boton_SelloDelegadofiscal.ForeColor = System.Drawing.Color.White
        Me.Boton_SelloDelegadofiscal.Location = New System.Drawing.Point(14, 173)
        Me.Boton_SelloDelegadofiscal.Name = "Boton_SelloDelegadofiscal"
        Me.Boton_SelloDelegadofiscal.Size = New System.Drawing.Size(186, 32)
        Me.Boton_SelloDelegadofiscal.TabIndex = 32
        Me.Boton_SelloDelegadofiscal.Text = "Delegado Fiscal"
        Me.Boton_SelloDelegadofiscal.UseVisualStyleBackColor = false
        '
        'LabelDelegadofiscal
        '
        Me.LabelDelegadofiscal.AutoSize = true
        Me.LabelDelegadofiscal.Location = New System.Drawing.Point(206, 181)
        Me.LabelDelegadofiscal.Name = "LabelDelegadofiscal"
        Me.LabelDelegadofiscal.Size = New System.Drawing.Size(13, 17)
        Me.LabelDelegadofiscal.TabIndex = 31
        Me.LabelDelegadofiscal.Text = "-"
        '
        'Boton_SelloSuministros
        '
        Me.Boton_SelloSuministros.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Boton_SelloSuministros.ForeColor = System.Drawing.Color.White
        Me.Boton_SelloSuministros.Location = New System.Drawing.Point(14, 135)
        Me.Boton_SelloSuministros.Name = "Boton_SelloSuministros"
        Me.Boton_SelloSuministros.Size = New System.Drawing.Size(186, 32)
        Me.Boton_SelloSuministros.TabIndex = 30
        Me.Boton_SelloSuministros.Text = "Suministros"
        Me.Boton_SelloSuministros.UseVisualStyleBackColor = false
        '
        'LabelSuministros
        '
        Me.LabelSuministros.AutoSize = true
        Me.LabelSuministros.Location = New System.Drawing.Point(206, 143)
        Me.LabelSuministros.Name = "LabelSuministros"
        Me.LabelSuministros.Size = New System.Drawing.Size(13, 17)
        Me.LabelSuministros.TabIndex = 29
        Me.LabelSuministros.Text = "-"
        '
        'Boton_SelloContabilidad
        '
        Me.Boton_SelloContabilidad.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Boton_SelloContabilidad.ForeColor = System.Drawing.Color.White
        Me.Boton_SelloContabilidad.Location = New System.Drawing.Point(14, 97)
        Me.Boton_SelloContabilidad.Name = "Boton_SelloContabilidad"
        Me.Boton_SelloContabilidad.Size = New System.Drawing.Size(186, 32)
        Me.Boton_SelloContabilidad.TabIndex = 28
        Me.Boton_SelloContabilidad.Text = "Contabilidad"
        Me.Boton_SelloContabilidad.UseVisualStyleBackColor = false
        '
        'LabelContabilidad
        '
        Me.LabelContabilidad.AutoSize = true
        Me.LabelContabilidad.Location = New System.Drawing.Point(206, 105)
        Me.LabelContabilidad.Name = "LabelContabilidad"
        Me.LabelContabilidad.Size = New System.Drawing.Size(13, 17)
        Me.LabelContabilidad.TabIndex = 27
        Me.LabelContabilidad.Text = "-"
        '
        'Boton_SelloTesoreria
        '
        Me.Boton_SelloTesoreria.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Boton_SelloTesoreria.ForeColor = System.Drawing.Color.White
        Me.Boton_SelloTesoreria.Location = New System.Drawing.Point(14, 59)
        Me.Boton_SelloTesoreria.Name = "Boton_SelloTesoreria"
        Me.Boton_SelloTesoreria.Size = New System.Drawing.Size(186, 32)
        Me.Boton_SelloTesoreria.TabIndex = 26
        Me.Boton_SelloTesoreria.Text = "Tesorería"
        Me.Boton_SelloTesoreria.UseVisualStyleBackColor = false
        '
        'LabelTesoreria
        '
        Me.LabelTesoreria.AutoSize = true
        Me.LabelTesoreria.Location = New System.Drawing.Point(206, 67)
        Me.LabelTesoreria.Name = "LabelTesoreria"
        Me.LabelTesoreria.Size = New System.Drawing.Size(13, 17)
        Me.LabelTesoreria.TabIndex = 25
        Me.LabelTesoreria.Text = "-"
        '
        'Boton_SelloDireccion
        '
        Me.Boton_SelloDireccion.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Boton_SelloDireccion.ForeColor = System.Drawing.Color.White
        Me.Boton_SelloDireccion.Location = New System.Drawing.Point(14, 21)
        Me.Boton_SelloDireccion.Name = "Boton_SelloDireccion"
        Me.Boton_SelloDireccion.Size = New System.Drawing.Size(186, 32)
        Me.Boton_SelloDireccion.TabIndex = 24
        Me.Boton_SelloDireccion.Text = "Dirección"
        Me.Boton_SelloDireccion.UseVisualStyleBackColor = false
        '
        'LabelDireccion
        '
        Me.LabelDireccion.AutoSize = true
        Me.LabelDireccion.Location = New System.Drawing.Point(206, 29)
        Me.LabelDireccion.Name = "LabelDireccion"
        Me.LabelDireccion.Size = New System.Drawing.Size(13, 17)
        Me.LabelDireccion.TabIndex = 23
        Me.LabelDireccion.Text = "-"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.tamaniohoja_boton)
        Me.GroupBox2.Controls.Add(Me.margen_abajo)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.margen_derecho)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.margen_arriba)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.margen_izquierdo)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Orange
        Me.GroupBox2.Location = New System.Drawing.Point(279, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox2.Size = New System.Drawing.Size(243, 271)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = false
        Me.GroupBox2.Text = "Margenes"
        '
        'tamaniohoja_boton
        '
        Me.tamaniohoja_boton.BackColor = System.Drawing.Color.White
        Me.tamaniohoja_boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.tamaniohoja_boton.ForeColor = System.Drawing.Color.Black
        Me.tamaniohoja_boton.Image = CType(resources.GetObject("tamaniohoja_boton.Image"),System.Drawing.Image)
        Me.tamaniohoja_boton.Location = New System.Drawing.Point(73, 89)
        Me.tamaniohoja_boton.Name = "tamaniohoja_boton"
        Me.tamaniohoja_boton.Size = New System.Drawing.Size(88, 99)
        Me.tamaniohoja_boton.TabIndex = 9
        Me.tamaniohoja_boton.Text = "Hoja"
        Me.tamaniohoja_boton.UseVisualStyleBackColor = false
        '
        'margen_abajo
        '
        Me.margen_abajo.Location = New System.Drawing.Point(93, 207)
        Me.margen_abajo.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.margen_abajo.Name = "margen_abajo"
        Me.margen_abajo.Size = New System.Drawing.Size(44, 25)
        Me.margen_abajo.Suffix = Nothing
        Me.margen_abajo.TabIndex = 8
        Me.margen_abajo.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = true
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(90, 191)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Abajo"
        '
        'margen_derecho
        '
        Me.margen_derecho.Location = New System.Drawing.Point(167, 128)
        Me.margen_derecho.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.margen_derecho.Name = "margen_derecho"
        Me.margen_derecho.Size = New System.Drawing.Size(44, 25)
        Me.margen_derecho.Suffix = Nothing
        Me.margen_derecho.TabIndex = 6
        Me.margen_derecho.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(163, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Derecho"
        '
        'margen_arriba
        '
        Me.margen_arriba.Location = New System.Drawing.Point(93, 58)
        Me.margen_arriba.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.margen_arriba.Name = "margen_arriba"
        Me.margen_arriba.Size = New System.Drawing.Size(44, 25)
        Me.margen_arriba.Suffix = Nothing
        Me.margen_arriba.TabIndex = 4
        Me.margen_arriba.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = true
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(90, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Arriba"
        '
        'margen_izquierdo
        '
        Me.margen_izquierdo.Location = New System.Drawing.Point(21, 128)
        Me.margen_izquierdo.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.margen_izquierdo.Name = "margen_izquierdo"
        Me.margen_izquierdo.Size = New System.Drawing.Size(44, 25)
        Me.margen_izquierdo.Suffix = Nothing
        Me.margen_izquierdo.TabIndex = 2
        Me.margen_izquierdo.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = true
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(18, 114)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Izquierdo"
        '
        'IMPRIMIR_BOTON
        '
        Me.IMPRIMIR_BOTON.BackColor = System.Drawing.Color.Snow
        Me.IMPRIMIR_BOTON.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.IMPRIMIR_BOTON.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.IMPRIMIR_BOTON.Image = CType(resources.GetObject("IMPRIMIR_BOTON.Image"),System.Drawing.Image)
        Me.IMPRIMIR_BOTON.Location = New System.Drawing.Point(13, 505)
        Me.IMPRIMIR_BOTON.Margin = New System.Windows.Forms.Padding(0)
        Me.IMPRIMIR_BOTON.Name = "IMPRIMIR_BOTON"
        Me.IMPRIMIR_BOTON.Size = New System.Drawing.Size(509, 44)
        Me.IMPRIMIR_BOTON.TabIndex = 25
        Me.IMPRIMIR_BOTON.Text = "IMPRIMIR"
        Me.IMPRIMIR_BOTON.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IMPRIMIR_BOTON.UseVisualStyleBackColor = false
        '
        'Dialogo_impresion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 560)
        Me.Controls.Add(Me.IMPRIMIR_BOTON)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Refresh_boton)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Visor_PDF)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Name = "Dialogo_impresion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Dialogo_impresion"
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        CType(Me.Cantidaddecimales_numeric,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.SizeTablas,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.SizeTexto,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Sizetitulo,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupBox4.ResumeLayout(false)
        Me.GroupBox4.PerformLayout
        Me.GroupBox2.ResumeLayout(false)
        Me.GroupBox2.PerformLayout
        CType(Me.margen_abajo,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.margen_derecho,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.margen_arriba,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.margen_izquierdo,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
End Sub
    Friend WithEvents Visor_PDF As PdfiumViewer.PdfViewer
    Friend WithEvents Label1 As Label
    Friend WithEvents Sizetitulo As Flicker_Numericcontrol_Numero
    Friend WithEvents SizeTexto As Flicker_Numericcontrol_Numero
    Friend WithEvents Label2 As Label
    Friend WithEvents SizeTablas As Flicker_Numericcontrol_Numero
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Refresh_boton As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Boton_SelloDelegadofiscal As Button
    Friend WithEvents LabelDelegadofiscal As Label
    Friend WithEvents Boton_SelloSuministros As Button
    Friend WithEvents LabelSuministros As Label
    Friend WithEvents Boton_SelloContabilidad As Button
    Friend WithEvents LabelContabilidad As Label
    Friend WithEvents Boton_SelloTesoreria As Button
    Friend WithEvents LabelTesoreria As Label
    Friend WithEvents Boton_SelloDireccion As Button
    Friend WithEvents LabelDireccion As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents margen_derecho As Flicker_Numericcontrol_Numero
    Friend WithEvents Label4 As Label
    Friend WithEvents margen_arriba As Flicker_Numericcontrol_Numero
    Friend WithEvents Label5 As Label
    Friend WithEvents margen_izquierdo As Flicker_Numericcontrol_Numero
    Friend WithEvents Label6 As Label
    Friend WithEvents tamaniohoja_boton As Button
    Friend WithEvents margen_abajo As Flicker_Numericcontrol_Numero
    Friend WithEvents Label7 As Label
    Friend WithEvents IMPRIMIR_BOTON As Button
    Friend WithEvents Cantidaddecimales_numeric As Flicker_Numericcontrol_Numero
    Friend WithEvents Label8 As Label
End Class
