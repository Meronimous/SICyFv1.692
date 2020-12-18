<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Contabilidad_DialogoContratos
    Inherits System.Windows.Forms.Form
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_DialogoOrdenPago))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FullScreen_boton = New System.Windows.Forms.Button()
        Me.Cerrar_boton = New System.Windows.Forms.Button()
        Me.Label_ordenpagoasociada = New System.Windows.Forms.Label()
        Me.ordenpago_detalles = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label_montonombre = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Boton_SUGERENCIA = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.OPNumero_numericupdown = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.OPyear_numericupdown = New System.Windows.Forms.NumericUpDown()
        Me.Fechaconfeccion_datetimepicker = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Year_numericupdown = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Numeroexpediente_numericupdown = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Organismo_numericupdown = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Flicker_Tablelayout1 = New SICyF.Flicker_Tablelayout(Me.components)
        Me.Guardar_boton = New System.Windows.Forms.Button()
        Me.Guardar_eimprimir_boton = New System.Windows.Forms.Button()
        Me.Flicker_Tablelayout2 = New SICyF.Flicker_Tablelayout(Me.components)
        Me.PaneL_sinFlicker3 = New SICyF.PANEL_sinFlicker()
        Me.CLASEOP = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.PaneL_sinFlicker1 = New SICyF.PANEL_sinFlicker()
        Me.Datos_Ordenesprovision = New SICyF.Flicker_Datagridview()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PaneL_sinFlicker2 = New SICyF.PANEL_sinFlicker()
        Me.PARTIDAS_TOTALNUMERICAUPDOWN = New SICyF.Flicker_Numericcontrol_Dinero()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Datos_Partidas = New SICyF.Flicker_Datagridview()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Montototal = New SICyF.Flicker_Numericcontrol_Dinero()
        Me.ESTADOOP = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.OPNumero_numericupdown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OPyear_numericupdown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.Year_numericupdown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Numeroexpediente_numericupdown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Organismo_numericupdown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Flicker_Tablelayout1.SuspendLayout()
        Me.Flicker_Tablelayout2.SuspendLayout()
        Me.PaneL_sinFlicker3.SuspendLayout()
        Me.PaneL_sinFlicker1.SuspendLayout()
        CType(Me.Datos_Ordenesprovision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PaneL_sinFlicker2.SuspendLayout()
        CType(Me.PARTIDAS_TOTALNUMERICAUPDOWN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Datos_Partidas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Montototal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.Panel1.Controls.Add(Me.FullScreen_boton)
        Me.Panel1.Controls.Add(Me.Cerrar_boton)
        Me.Panel1.Controls.Add(Me.Label_ordenpagoasociada)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1111, 42)
        Me.Panel1.TabIndex = 108
        '
        'FullScreen_boton
        '
        Me.FullScreen_boton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FullScreen_boton.BackColor = System.Drawing.Color.Transparent
        Me.FullScreen_boton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.FullScreen_boton.FlatAppearance.BorderSize = 0
        Me.FullScreen_boton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.FullScreen_boton.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.FullScreen_boton.Image = CType(resources.GetObject("FullScreen_boton.Image"), System.Drawing.Image)
        Me.FullScreen_boton.Location = New System.Drawing.Point(1003, 1)
        Me.FullScreen_boton.Name = "FullScreen_boton"
        Me.FullScreen_boton.Size = New System.Drawing.Size(60, 41)
        Me.FullScreen_boton.TabIndex = 32
        Me.FullScreen_boton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.FullScreen_boton.UseVisualStyleBackColor = False
        '
        'Cerrar_boton
        '
        Me.Cerrar_boton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cerrar_boton.AutoSize = True
        Me.Cerrar_boton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Cerrar_boton.FlatAppearance.BorderSize = 0
        Me.Cerrar_boton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cerrar_boton.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Cerrar_boton.Image = CType(resources.GetObject("Cerrar_boton.Image"), System.Drawing.Image)
        Me.Cerrar_boton.Location = New System.Drawing.Point(1069, 0)
        Me.Cerrar_boton.Name = "Cerrar_boton"
        Me.Cerrar_boton.Size = New System.Drawing.Size(42, 42)
        Me.Cerrar_boton.TabIndex = 31
        Me.Cerrar_boton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cerrar_boton.UseVisualStyleBackColor = True
        '
        'Label_ordenpagoasociada
        '
        Me.Label_ordenpagoasociada.AutoSize = True
        Me.Label_ordenpagoasociada.Font = New System.Drawing.Font("Raleway Black", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ordenpagoasociada.ForeColor = System.Drawing.Color.White
        Me.Label_ordenpagoasociada.Location = New System.Drawing.Point(171, 2)
        Me.Label_ordenpagoasociada.Name = "Label_ordenpagoasociada"
        Me.Label_ordenpagoasociada.Size = New System.Drawing.Size(165, 30)
        Me.Label_ordenpagoasociada.TabIndex = 29
        Me.Label_ordenpagoasociada.Text = "Orden de Pago"
        '
        'ordenpago_detalles
        '
        Me.ordenpago_detalles.BackColor = System.Drawing.Color.White
        Me.ordenpago_detalles.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ordenpago_detalles.ForeColor = System.Drawing.Color.Black
        Me.ordenpago_detalles.Location = New System.Drawing.Point(93, 55)
        Me.ordenpago_detalles.Multiline = True
        Me.ordenpago_detalles.Name = "ordenpago_detalles"
        Me.ordenpago_detalles.Size = New System.Drawing.Size(705, 52)
        Me.ordenpago_detalles.TabIndex = 3
        Me.ordenpago_detalles.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(7, 61)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 17)
        Me.Label9.TabIndex = 130
        Me.Label9.Text = "Descripción"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label_montonombre
        '
        Me.Label_montonombre.AutoSize = True
        Me.Label_montonombre.BackColor = System.Drawing.Color.Transparent
        Me.Label_montonombre.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_montonombre.ForeColor = System.Drawing.Color.Black
        Me.Label_montonombre.Location = New System.Drawing.Point(801, 64)
        Me.Label_montonombre.Margin = New System.Windows.Forms.Padding(0)
        Me.Label_montonombre.Name = "Label_montonombre"
        Me.Label_montonombre.Size = New System.Drawing.Size(118, 15)
        Me.Label_montonombre.TabIndex = 139
        Me.Label_montonombre.Text = "Importe Acumulado"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.BackColor = System.Drawing.Color.MediumAquamarine
        Me.GroupBox3.Controls.Add(Me.Boton_SUGERENCIA)
        Me.GroupBox3.Controls.Add(Me.ordenpago_detalles)
        Me.GroupBox3.Controls.Add(Me.Flicker_Tablelayout2)
        Me.GroupBox3.Controls.Add(Me.Montototal)
        Me.GroupBox3.Controls.Add(Me.Label_montonombre)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.OPNumero_numericupdown)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.OPyear_numericupdown)
        Me.GroupBox3.Controls.Add(Me.Fechaconfeccion_datetimepicker)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Panel2)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox3.Location = New System.Drawing.Point(0, 45)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1111, 427)
        Me.GroupBox3.TabIndex = 715
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "DATOS DE ORDEN DE PAGO"
        '
        'Boton_SUGERENCIA
        '
        Me.Boton_SUGERENCIA.BackColor = System.Drawing.Color.White
        Me.Boton_SUGERENCIA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Boton_SUGERENCIA.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Boton_SUGERENCIA.ForeColor = System.Drawing.Color.ForestGreen
        Me.Boton_SUGERENCIA.Image = CType(resources.GetObject("Boton_SUGERENCIA.Image"), System.Drawing.Image)
        Me.Boton_SUGERENCIA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Boton_SUGERENCIA.Location = New System.Drawing.Point(4, 78)
        Me.Boton_SUGERENCIA.Margin = New System.Windows.Forms.Padding(0)
        Me.Boton_SUGERENCIA.Name = "Boton_SUGERENCIA"
        Me.Boton_SUGERENCIA.Size = New System.Drawing.Size(85, 29)
        Me.Boton_SUGERENCIA.TabIndex = 727
        Me.Boton_SUGERENCIA.Text = "SUGERENCIA"
        Me.Boton_SUGERENCIA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Boton_SUGERENCIA.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(50, 13)
        Me.Label11.TabIndex = 715
        Me.Label11.Text = "Número"
        '
        'OPNumero_numericupdown
        '
        Me.OPNumero_numericupdown.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OPNumero_numericupdown.Location = New System.Drawing.Point(62, 18)
        Me.OPNumero_numericupdown.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.OPNumero_numericupdown.Name = "OPNumero_numericupdown"
        Me.OPNumero_numericupdown.Size = New System.Drawing.Size(97, 33)
        Me.OPNumero_numericupdown.TabIndex = 0
        Me.OPNumero_numericupdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(162, 19)
        Me.Label12.Margin = New System.Windows.Forms.Padding(0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 13)
        Me.Label12.TabIndex = 716
        Me.Label12.Text = "Año"
        '
        'OPyear_numericupdown
        '
        Me.OPyear_numericupdown.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OPyear_numericupdown.Location = New System.Drawing.Point(194, 18)
        Me.OPyear_numericupdown.Maximum = New Decimal(New Integer() {2100, 0, 0, 0})
        Me.OPyear_numericupdown.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.OPyear_numericupdown.Name = "OPyear_numericupdown"
        Me.OPyear_numericupdown.Size = New System.Drawing.Size(84, 33)
        Me.OPyear_numericupdown.TabIndex = 1
        Me.OPyear_numericupdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OPyear_numericupdown.Value = New Decimal(New Integer() {2000, 0, 0, 0})
        '
        'Fechaconfeccion_datetimepicker
        '
        Me.Fechaconfeccion_datetimepicker.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Fechaconfeccion_datetimepicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Fechaconfeccion_datetimepicker.Location = New System.Drawing.Point(303, 22)
        Me.Fechaconfeccion_datetimepicker.Name = "Fechaconfeccion_datetimepicker"
        Me.Fechaconfeccion_datetimepicker.Size = New System.Drawing.Size(115, 27)
        Me.Fechaconfeccion_datetimepicker.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(284, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(134, 13)
        Me.Label6.TabIndex = 712
        Me.Label6.Text = "Fecha de Orden de Pago"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Year_numericupdown)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Numeroexpediente_numericupdown)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Organismo_numericupdown)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Location = New System.Drawing.Point(518, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(445, 49)
        Me.Panel2.TabIndex = 726
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(3, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(150, 13)
        Me.Label10.TabIndex = 726
        Me.Label10.Text = "EXPEDIENTE AUTORIZANTE"
        '
        'Year_numericupdown
        '
        Me.Year_numericupdown.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Year_numericupdown.Location = New System.Drawing.Point(353, 13)
        Me.Year_numericupdown.Maximum = New Decimal(New Integer() {2100, 0, 0, 0})
        Me.Year_numericupdown.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.Year_numericupdown.Name = "Year_numericupdown"
        Me.Year_numericupdown.Size = New System.Drawing.Size(84, 27)
        Me.Year_numericupdown.TabIndex = 722
        Me.Year_numericupdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Year_numericupdown.Value = New Decimal(New Integer() {2000, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(162, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 723
        Me.Label5.Text = "Organismo"
        '
        'Numeroexpediente_numericupdown
        '
        Me.Numeroexpediente_numericupdown.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Numeroexpediente_numericupdown.Location = New System.Drawing.Point(252, 13)
        Me.Numeroexpediente_numericupdown.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.Numeroexpediente_numericupdown.Name = "Numeroexpediente_numericupdown"
        Me.Numeroexpediente_numericupdown.Size = New System.Drawing.Size(97, 27)
        Me.Numeroexpediente_numericupdown.TabIndex = 721
        Me.Numeroexpediente_numericupdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(355, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 725
        Me.Label8.Text = "Año"
        '
        'Organismo_numericupdown
        '
        Me.Organismo_numericupdown.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Organismo_numericupdown.Location = New System.Drawing.Point(156, 13)
        Me.Organismo_numericupdown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.Organismo_numericupdown.Name = "Organismo_numericupdown"
        Me.Organismo_numericupdown.Size = New System.Drawing.Size(93, 27)
        Me.Organismo_numericupdown.TabIndex = 720
        Me.Organismo_numericupdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(255, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 13)
        Me.Label7.TabIndex = 724
        Me.Label7.Text = "Número"
        '
        'Flicker_Tablelayout1
        '
        Me.Flicker_Tablelayout1.ColumnCount = 2
        Me.Flicker_Tablelayout1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Flicker_Tablelayout1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Flicker_Tablelayout1.Controls.Add(Me.Guardar_boton, 0, 0)
        Me.Flicker_Tablelayout1.Controls.Add(Me.Guardar_eimprimir_boton, 1, 0)
        Me.Flicker_Tablelayout1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flicker_Tablelayout1.Location = New System.Drawing.Point(0, 478)
        Me.Flicker_Tablelayout1.Name = "Flicker_Tablelayout1"
        Me.Flicker_Tablelayout1.RowCount = 1
        Me.Flicker_Tablelayout1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Flicker_Tablelayout1.Size = New System.Drawing.Size(1111, 39)
        Me.Flicker_Tablelayout1.TabIndex = 717
        '
        'Guardar_boton
        '
        Me.Guardar_boton.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.Guardar_boton.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guardar_boton.ForeColor = System.Drawing.Color.White
        Me.Guardar_boton.Location = New System.Drawing.Point(1, 1)
        Me.Guardar_boton.Margin = New System.Windows.Forms.Padding(1)
        Me.Guardar_boton.Name = "Guardar_boton"
        Me.Guardar_boton.Size = New System.Drawing.Size(553, 36)
        Me.Guardar_boton.TabIndex = 716
        Me.Guardar_boton.Text = "Guardar"
        Me.Guardar_boton.UseVisualStyleBackColor = False
        '
        'Guardar_eimprimir_boton
        '
        Me.Guardar_eimprimir_boton.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.Guardar_eimprimir_boton.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guardar_eimprimir_boton.ForeColor = System.Drawing.Color.Black
        Me.Guardar_eimprimir_boton.Location = New System.Drawing.Point(556, 1)
        Me.Guardar_eimprimir_boton.Margin = New System.Windows.Forms.Padding(1)
        Me.Guardar_eimprimir_boton.Name = "Guardar_eimprimir_boton"
        Me.Guardar_eimprimir_boton.Size = New System.Drawing.Size(552, 36)
        Me.Guardar_eimprimir_boton.TabIndex = 18
        Me.Guardar_eimprimir_boton.Text = "Guardar y Generar Archivo"
        Me.Guardar_eimprimir_boton.UseVisualStyleBackColor = False
        '
        'Flicker_Tablelayout2
        '
        Me.Flicker_Tablelayout2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Flicker_Tablelayout2.ColumnCount = 1
        Me.Flicker_Tablelayout2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Flicker_Tablelayout2.Controls.Add(Me.PaneL_sinFlicker3, 0, 2)
        Me.Flicker_Tablelayout2.Controls.Add(Me.PaneL_sinFlicker1, 0, 0)
        Me.Flicker_Tablelayout2.Controls.Add(Me.PaneL_sinFlicker2, 0, 1)
        Me.Flicker_Tablelayout2.Location = New System.Drawing.Point(4, 113)
        Me.Flicker_Tablelayout2.Name = "Flicker_Tablelayout2"
        Me.Flicker_Tablelayout2.RowCount = 3
        Me.Flicker_Tablelayout2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.Flicker_Tablelayout2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.Flicker_Tablelayout2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.Flicker_Tablelayout2.Size = New System.Drawing.Size(1107, 308)
        Me.Flicker_Tablelayout2.TabIndex = 719
        '
        'PaneL_sinFlicker3
        '
        Me.PaneL_sinFlicker3.Controls.Add(Me.ESTADOOP)
        Me.PaneL_sinFlicker3.Controls.Add(Me.CLASEOP)
        Me.PaneL_sinFlicker3.Controls.Add(Me.Label14)
        Me.PaneL_sinFlicker3.Controls.Add(Me.Label13)
        Me.PaneL_sinFlicker3.Controls.Add(Me.Label4)
        Me.PaneL_sinFlicker3.Controls.Add(Me.TextBox1)
        Me.PaneL_sinFlicker3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PaneL_sinFlicker3.Location = New System.Drawing.Point(3, 249)
        Me.PaneL_sinFlicker3.Name = "PaneL_sinFlicker3"
        Me.PaneL_sinFlicker3.Size = New System.Drawing.Size(1101, 56)
        Me.PaneL_sinFlicker3.TabIndex = 2
        '
        'CLASEOP
        '
        Me.CLASEOP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CLASEOP.BackColor = System.Drawing.Color.White
        Me.CLASEOP.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CLASEOP.ForeColor = System.Drawing.Color.Black
        Me.CLASEOP.Location = New System.Drawing.Point(767, 30)
        Me.CLASEOP.Name = "CLASEOP"
        Me.CLASEOP.Size = New System.Drawing.Size(331, 22)
        Me.CLASEOP.TabIndex = 134
        Me.CLASEOP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(664, 37)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(97, 17)
        Me.Label14.TabIndex = 133
        Me.Label14.Text = "CLASE FONDO"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(664, 5)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(208, 17)
        Me.Label13.TabIndex = 132
        Me.Label13.Text = "ESTADO DE LA ORDEN DE PAGO"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(5, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 17)
        Me.Label4.TabIndex = 131
        Me.Label4.Text = "Observaciones"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Black
        Me.TextBox1.Location = New System.Drawing.Point(109, 2)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(555, 52)
        Me.TextBox1.TabIndex = 4
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PaneL_sinFlicker1
        '
        Me.PaneL_sinFlicker1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PaneL_sinFlicker1.Controls.Add(Me.Datos_Ordenesprovision)
        Me.PaneL_sinFlicker1.Controls.Add(Me.Label2)
        Me.PaneL_sinFlicker1.Location = New System.Drawing.Point(0, 0)
        Me.PaneL_sinFlicker1.Margin = New System.Windows.Forms.Padding(0)
        Me.PaneL_sinFlicker1.Name = "PaneL_sinFlicker1"
        Me.PaneL_sinFlicker1.Size = New System.Drawing.Size(1107, 123)
        Me.PaneL_sinFlicker1.TabIndex = 0
        '
        'Datos_Ordenesprovision
        '
        Me.Datos_Ordenesprovision.AllowUserToAddRows = False
        Me.Datos_Ordenesprovision.AllowUserToOrderColumns = True
        Me.Datos_Ordenesprovision.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Datos_Ordenesprovision.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Datos_Ordenesprovision.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Datos_Ordenesprovision.BackgroundColor = System.Drawing.Color.White
        Me.Datos_Ordenesprovision.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Datos_Ordenesprovision.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_Ordenesprovision.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.Datos_Ordenesprovision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_Ordenesprovision.DefaultCellStyle = DataGridViewCellStyle6
        Me.Datos_Ordenesprovision.Location = New System.Drawing.Point(3, 13)
        Me.Datos_Ordenesprovision.Margin = New System.Windows.Forms.Padding(0)
        Me.Datos_Ordenesprovision.Name = "Datos_Ordenesprovision"
        Me.Datos_Ordenesprovision.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Datos_Ordenesprovision.Size = New System.Drawing.Size(1100, 109)
        Me.Datos_Ordenesprovision.TabIndex = 721
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(247, 13)
        Me.Label2.TabIndex = 721
        Me.Label2.Text = "ORDENES DE PROVISIÓN EN ESTE EXPEDIENTE"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PaneL_sinFlicker2
        '
        Me.PaneL_sinFlicker2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PaneL_sinFlicker2.Controls.Add(Me.PARTIDAS_TOTALNUMERICAUPDOWN)
        Me.PaneL_sinFlicker2.Controls.Add(Me.Label1)
        Me.PaneL_sinFlicker2.Controls.Add(Me.Datos_Partidas)
        Me.PaneL_sinFlicker2.Controls.Add(Me.Label3)
        Me.PaneL_sinFlicker2.Location = New System.Drawing.Point(3, 126)
        Me.PaneL_sinFlicker2.Name = "PaneL_sinFlicker2"
        Me.PaneL_sinFlicker2.Size = New System.Drawing.Size(1101, 117)
        Me.PaneL_sinFlicker2.TabIndex = 1
        '
        'PARTIDAS_TOTALNUMERICAUPDOWN
        '
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.BackColor = System.Drawing.Color.White
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.DecimalPlaces = 2
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.Location = New System.Drawing.Point(929, 21)
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 131072})
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.Minimum = New Decimal(New Integer() {1316134911, 2328, 0, -2147352576})
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.Name = "PARTIDAS_TOTALNUMERICAUPDOWN"
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.ReadOnly = True
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.Size = New System.Drawing.Size(159, 25)
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.Suffix = Nothing
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.TabIndex = 720
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.ThousandsSeparator = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(926, 3)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 15)
        Me.Label1.TabIndex = 721
        Me.Label1.Text = "Importe Acumulado Partidas"
        '
        'Datos_Partidas
        '
        Me.Datos_Partidas.AllowUserToAddRows = False
        Me.Datos_Partidas.AllowUserToOrderColumns = True
        Me.Datos_Partidas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Datos_Partidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Datos_Partidas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Datos_Partidas.BackgroundColor = System.Drawing.Color.White
        Me.Datos_Partidas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Datos_Partidas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_Partidas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.Datos_Partidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_Partidas.DefaultCellStyle = DataGridViewCellStyle8
        Me.Datos_Partidas.Location = New System.Drawing.Point(3, 16)
        Me.Datos_Partidas.Name = "Datos_Partidas"
        Me.Datos_Partidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Datos_Partidas.Size = New System.Drawing.Size(922, 98)
        Me.Datos_Partidas.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 0)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(134, 13)
        Me.Label3.TabIndex = 719
        Me.Label3.Text = "Partidas Presupuestarias"
        '
        'Montototal
        '
        Me.Montototal.BackColor = System.Drawing.Color.White
        Me.Montototal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Montototal.DecimalPlaces = 2
        Me.Montototal.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Montototal.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.Montototal.Location = New System.Drawing.Point(804, 82)
        Me.Montototal.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 131072})
        Me.Montototal.Minimum = New Decimal(New Integer() {1316134911, 2328, 0, -2147352576})
        Me.Montototal.Name = "Montototal"
        Me.Montototal.ReadOnly = True
        Me.Montototal.Size = New System.Drawing.Size(159, 25)
        Me.Montototal.Suffix = Nothing
        Me.Montototal.TabIndex = 8
        Me.Montototal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Montototal.ThousandsSeparator = True
        '
        'ESTADOOP
        '
        Me.ESTADOOP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ESTADOOP.BackColor = System.Drawing.Color.White
        Me.ESTADOOP.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ESTADOOP.ForeColor = System.Drawing.Color.Black
        Me.ESTADOOP.Location = New System.Drawing.Point(869, 2)
        Me.ESTADOOP.Name = "ESTADOOP"
        Me.ESTADOOP.Size = New System.Drawing.Size(229, 22)
        Me.ESTADOOP.TabIndex = 135
        Me.ESTADOOP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Contabilidad_DialogoOrdenPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.MediumAquamarine
        Me.ClientSize = New System.Drawing.Size(1111, 517)
        Me.Controls.Add(Me.Flicker_Tablelayout1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Contabilidad_DialogoOrdenPago"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Suministros_ordenpago"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.OPNumero_numericupdown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OPyear_numericupdown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.Year_numericupdown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Numeroexpediente_numericupdown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Organismo_numericupdown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Flicker_Tablelayout1.ResumeLayout(False)
        Me.Flicker_Tablelayout2.ResumeLayout(False)
        Me.PaneL_sinFlicker3.ResumeLayout(False)
        Me.PaneL_sinFlicker3.PerformLayout()
        Me.PaneL_sinFlicker1.ResumeLayout(False)
        Me.PaneL_sinFlicker1.PerformLayout()
        CType(Me.Datos_Ordenesprovision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PaneL_sinFlicker2.ResumeLayout(False)
        Me.PaneL_sinFlicker2.PerformLayout()
        CType(Me.PARTIDAS_TOTALNUMERICAUPDOWN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Datos_Partidas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Montototal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Cerrar_boton As Button
    Friend WithEvents Label_ordenpagoasociada As Label
    Friend WithEvents ordenpago_detalles As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label_montonombre As Label
    Friend WithEvents Montototal As Flicker_Numericcontrol_Dinero
    Friend WithEvents Guardar_eimprimir_boton As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Datos_Partidas As Flicker_Datagridview
    Friend WithEvents Fechaconfeccion_datetimepicker As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents OPNumero_numericupdown As NumericUpDown
    Friend WithEvents Label12 As Label
    Friend WithEvents OPyear_numericupdown As NumericUpDown
    Friend WithEvents Guardar_boton As Button
    Friend WithEvents Flicker_Tablelayout1 As Flicker_Tablelayout
    Friend WithEvents Flicker_Tablelayout2 As Flicker_Tablelayout
    Friend WithEvents Label2 As Label
    Friend WithEvents PaneL_sinFlicker1 As PANEL_sinFlicker
    Friend WithEvents Datos_Ordenesprovision As Flicker_Datagridview
    Friend WithEvents Label3 As Label
    Friend WithEvents PARTIDAS_TOTALNUMERICAUPDOWN As Flicker_Numericcontrol_Dinero
    Friend WithEvents Label1 As Label
    Friend WithEvents FullScreen_boton As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents Year_numericupdown As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents Numeroexpediente_numericupdown As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents Organismo_numericupdown As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents Boton_SUGERENCIA As Button
    Friend WithEvents PaneL_sinFlicker3 As PANEL_sinFlicker
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents PaneL_sinFlicker2 As PANEL_sinFlicker
    Friend WithEvents CLASEOP As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents ESTADOOP As TextBox
End Class
