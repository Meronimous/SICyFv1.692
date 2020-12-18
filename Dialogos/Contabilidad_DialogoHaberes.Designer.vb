<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_DialogoHaberes
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_DialogoHaberes))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Year_numericupdown = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Numeroexpediente_numericupdown = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Organismo_numericupdown = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Recupero_varios_numericupdown = New SICyF.Flicker_Numericcontrol_Dinero()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LIQUIDACIONAPAGAR_NUMERICUPDOWN = New SICyF.Flicker_Numericcontrol_Dinero()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ordenpago_detalles2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ordenpago_detalles = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.OPNumero_numericupdown = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.OPyear_numericupdown = New System.Windows.Forms.NumericUpDown()
        Me.Fechaconfeccion_datetimepicker = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PARTIDAS_TOTALNUMERICAUPDOWN = New SICyF.Flicker_Numericcontrol_Dinero()
        Me.Label_montonombre = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Montototal = New SICyF.Flicker_Numericcontrol_Dinero()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Datos_DetalleHaberes = New SICyF.Flicker_Datagridview()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Sugerencia_partidas = New System.Windows.Forms.Button()
        Me.Datos_Partidas = New SICyF.Flicker_Datagridview()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FullScreen_boton = New System.Windows.Forms.Button()
        Me.Cerrar_boton = New System.Windows.Forms.Button()
        Me.Label_ordenpagoasociada = New System.Windows.Forms.Label()
        Me.Flicker_Tablelayout1 = New SICyF.Flicker_Tablelayout(Me.components)
        Me.Guardar_boton = New System.Windows.Forms.Button()
        Me.Guardar_eimprimir_boton = New System.Windows.Forms.Button()
        Me.GroupBox3.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.Year_numericupdown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Numeroexpediente_numericupdown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Organismo_numericupdown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Recupero_varios_numericupdown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LIQUIDACIONAPAGAR_NUMERICUPDOWN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OPNumero_numericupdown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OPyear_numericupdown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PARTIDAS_TOTALNUMERICAUPDOWN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Montototal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Datos_DetalleHaberes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Datos_Partidas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Flicker_Tablelayout1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.GroupBox3.Controls.Add(Me.Panel3)
        Me.GroupBox3.Controls.Add(Me.Recupero_varios_numericupdown)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.LIQUIDACIONAPAGAR_NUMERICUPDOWN)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.ordenpago_detalles2)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.ordenpago_detalles)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.OPNumero_numericupdown)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.OPyear_numericupdown)
        Me.GroupBox3.Controls.Add(Me.Fechaconfeccion_datetimepicker)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Panel2)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox3.Location = New System.Drawing.Point(2, 37)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox3.Size = New System.Drawing.Size(503, 360)
        Me.GroupBox3.TabIndex = 716
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "DATOS DE ORDEN DE PAGO"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.Year_numericupdown)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Numeroexpediente_numericupdown)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Organismo_numericupdown)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Location = New System.Drawing.Point(62, 57)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(408, 44)
        Me.Panel3.TabIndex = 727
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(3, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(118, 13)
        Me.Label10.TabIndex = 726
        Me.Label10.Text = "EXPTE AUTORIZANTE"
        '
        'Year_numericupdown
        '
        Me.Year_numericupdown.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Year_numericupdown.Location = New System.Drawing.Point(324, 10)
        Me.Year_numericupdown.Maximum = New Decimal(New Integer() {2100, 0, 0, 0})
        Me.Year_numericupdown.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.Year_numericupdown.Name = "Year_numericupdown"
        Me.Year_numericupdown.Size = New System.Drawing.Size(84, 27)
        Me.Year_numericupdown.TabIndex = 722
        Me.Year_numericupdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Year_numericupdown.Value = New Decimal(New Integer() {2000, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(133, -1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 723
        Me.Label7.Text = "Organismo"
        '
        'Numeroexpediente_numericupdown
        '
        Me.Numeroexpediente_numericupdown.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Numeroexpediente_numericupdown.Location = New System.Drawing.Point(223, 11)
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
        Me.Label8.Location = New System.Drawing.Point(326, -1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 725
        Me.Label8.Text = "Año"
        '
        'Organismo_numericupdown
        '
        Me.Organismo_numericupdown.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Organismo_numericupdown.Location = New System.Drawing.Point(127, 12)
        Me.Organismo_numericupdown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.Organismo_numericupdown.Name = "Organismo_numericupdown"
        Me.Organismo_numericupdown.Size = New System.Drawing.Size(93, 27)
        Me.Organismo_numericupdown.TabIndex = 720
        Me.Organismo_numericupdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(226, -1)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 13)
        Me.Label13.TabIndex = 724
        Me.Label13.Text = "Número"
        '
        'Recupero_varios_numericupdown
        '
        Me.Recupero_varios_numericupdown.BackColor = System.Drawing.Color.White
        Me.Recupero_varios_numericupdown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Recupero_varios_numericupdown.DecimalPlaces = 2
        Me.Recupero_varios_numericupdown.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Recupero_varios_numericupdown.ForeColor = System.Drawing.Color.Brown
        Me.Recupero_varios_numericupdown.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.Recupero_varios_numericupdown.Location = New System.Drawing.Point(280, 278)
        Me.Recupero_varios_numericupdown.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 131072})
        Me.Recupero_varios_numericupdown.Name = "Recupero_varios_numericupdown"
        Me.Recupero_varios_numericupdown.Size = New System.Drawing.Size(207, 25)
        Me.Recupero_varios_numericupdown.Suffix = Nothing
        Me.Recupero_varios_numericupdown.TabIndex = 721
        Me.Recupero_varios_numericupdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Recupero_varios_numericupdown.ThousandsSeparator = True
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(319, 259)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(175, 20)
        Me.Label4.TabIndex = 722
        Me.Label4.Text = "RECUPERO VARIOS"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LIQUIDACIONAPAGAR_NUMERICUPDOWN
        '
        Me.LIQUIDACIONAPAGAR_NUMERICUPDOWN.BackColor = System.Drawing.Color.White
        Me.LIQUIDACIONAPAGAR_NUMERICUPDOWN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LIQUIDACIONAPAGAR_NUMERICUPDOWN.DecimalPlaces = 2
        Me.LIQUIDACIONAPAGAR_NUMERICUPDOWN.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LIQUIDACIONAPAGAR_NUMERICUPDOWN.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.LIQUIDACIONAPAGAR_NUMERICUPDOWN.Location = New System.Drawing.Point(13, 278)
        Me.LIQUIDACIONAPAGAR_NUMERICUPDOWN.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 131072})
        Me.LIQUIDACIONAPAGAR_NUMERICUPDOWN.Minimum = New Decimal(New Integer() {1316134911, 2328, 0, -2147352576})
        Me.LIQUIDACIONAPAGAR_NUMERICUPDOWN.Name = "LIQUIDACIONAPAGAR_NUMERICUPDOWN"
        Me.LIQUIDACIONAPAGAR_NUMERICUPDOWN.Size = New System.Drawing.Size(207, 25)
        Me.LIQUIDACIONAPAGAR_NUMERICUPDOWN.Suffix = Nothing
        Me.LIQUIDACIONAPAGAR_NUMERICUPDOWN.TabIndex = 719
        Me.LIQUIDACIONAPAGAR_NUMERICUPDOWN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.LIQUIDACIONAPAGAR_NUMERICUPDOWN.ThousandsSeparator = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(31, 259)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(170, 16)
        Me.Label3.TabIndex = 720
        Me.Label3.Text = "LIQUIDACIÓN A PAGAR"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ordenpago_detalles2
        '
        Me.ordenpago_detalles2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ordenpago_detalles2.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.ordenpago_detalles2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ordenpago_detalles2.ForeColor = System.Drawing.Color.Black
        Me.ordenpago_detalles2.Location = New System.Drawing.Point(10, 222)
        Me.ordenpago_detalles2.Multiline = True
        Me.ordenpago_detalles2.Name = "ordenpago_detalles2"
        Me.ordenpago_detalles2.Size = New System.Drawing.Size(481, 34)
        Me.ordenpago_detalles2.TabIndex = 717
        Me.ordenpago_detalles2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(6, 202)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 17)
        Me.Label2.TabIndex = 718
        Me.Label2.Text = "Observaciones"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ordenpago_detalles
        '
        Me.ordenpago_detalles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ordenpago_detalles.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.ordenpago_detalles.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ordenpago_detalles.ForeColor = System.Drawing.Color.Black
        Me.ordenpago_detalles.Location = New System.Drawing.Point(3, 133)
        Me.ordenpago_detalles.Multiline = True
        Me.ordenpago_detalles.Name = "ordenpago_detalles"
        Me.ordenpago_detalles.Size = New System.Drawing.Size(491, 66)
        Me.ordenpago_detalles.TabIndex = 3
        Me.ordenpago_detalles.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(10, 29)
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
        Me.Label12.Location = New System.Drawing.Point(162, 29)
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
        Me.Fechaconfeccion_datetimepicker.Location = New System.Drawing.Point(372, 19)
        Me.Fechaconfeccion_datetimepicker.Name = "Fechaconfeccion_datetimepicker"
        Me.Fechaconfeccion_datetimepicker.Size = New System.Drawing.Size(115, 27)
        Me.Fechaconfeccion_datetimepicker.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(284, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 26)
        Me.Label6.TabIndex = 712
        Me.Label6.Text = "Fecha de " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Orden de Pago"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(6, 113)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 17)
        Me.Label9.TabIndex = 130
        Me.Label9.Text = "Descripción"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Wheat
        Me.Panel2.Controls.Add(Me.PARTIDAS_TOTALNUMERICAUPDOWN)
        Me.Panel2.Controls.Add(Me.Label_montonombre)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Montototal)
        Me.Panel2.Location = New System.Drawing.Point(9, 309)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(485, 48)
        Me.Panel2.TabIndex = 725
        '
        'PARTIDAS_TOTALNUMERICAUPDOWN
        '
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.BackColor = System.Drawing.Color.White
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.DecimalPlaces = 2
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.Enabled = False
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.InterceptArrowKeys = False
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.Location = New System.Drawing.Point(263, 19)
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 131072})
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.Minimum = New Decimal(New Integer() {1316134911, 2328, 0, -2147352576})
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.Name = "PARTIDAS_TOTALNUMERICAUPDOWN"
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.ReadOnly = True
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.Size = New System.Drawing.Size(215, 25)
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.Suffix = Nothing
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.TabIndex = 723
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.ThousandsSeparator = True
        '
        'Label_montonombre
        '
        Me.Label_montonombre.AutoSize = True
        Me.Label_montonombre.BackColor = System.Drawing.Color.Transparent
        Me.Label_montonombre.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_montonombre.ForeColor = System.Drawing.Color.Black
        Me.Label_montonombre.Location = New System.Drawing.Point(22, 1)
        Me.Label_montonombre.Margin = New System.Windows.Forms.Padding(0)
        Me.Label_montonombre.Name = "Label_montonombre"
        Me.Label_montonombre.Size = New System.Drawing.Size(169, 15)
        Me.Label_montonombre.TabIndex = 139
        Me.Label_montonombre.Text = "Acumulado Items Liquidación"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(269, 1)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(170, 15)
        Me.Label1.TabIndex = 724
        Me.Label1.Text = "Acumulado P. Presupuestarias"
        '
        'Montototal
        '
        Me.Montototal.BackColor = System.Drawing.Color.White
        Me.Montototal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Montototal.DecimalPlaces = 2
        Me.Montototal.Enabled = False
        Me.Montototal.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Montototal.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.Montototal.InterceptArrowKeys = False
        Me.Montototal.Location = New System.Drawing.Point(4, 19)
        Me.Montototal.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 131072})
        Me.Montototal.Minimum = New Decimal(New Integer() {1316134911, 2328, 0, -2147352576})
        Me.Montototal.Name = "Montototal"
        Me.Montototal.ReadOnly = True
        Me.Montototal.Size = New System.Drawing.Size(207, 25)
        Me.Montototal.Suffix = Nothing
        Me.Montototal.TabIndex = 8
        Me.Montototal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Montototal.ThousandsSeparator = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.Datos_DetalleHaberes)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.Location = New System.Drawing.Point(505, 37)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox1.Size = New System.Drawing.Size(515, 360)
        Me.GroupBox1.TabIndex = 717
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DATOS DE ORDEN DE PAGO"
        '
        'Datos_DetalleHaberes
        '
        Me.Datos_DetalleHaberes.AllowUserToAddRows = False
        Me.Datos_DetalleHaberes.AllowUserToOrderColumns = True
        Me.Datos_DetalleHaberes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Datos_DetalleHaberes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Datos_DetalleHaberes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Datos_DetalleHaberes.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_DetalleHaberes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Datos_DetalleHaberes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(198, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_DetalleHaberes.DefaultCellStyle = DataGridViewCellStyle2
        Me.Datos_DetalleHaberes.Location = New System.Drawing.Point(0, 18)
        Me.Datos_DetalleHaberes.Name = "Datos_DetalleHaberes"
        Me.Datos_DetalleHaberes.ReadOnly = True
        Me.Datos_DetalleHaberes.RowHeadersVisible = False
        Me.Datos_DetalleHaberes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Datos_DetalleHaberes.Size = New System.Drawing.Size(512, 342)
        Me.Datos_DetalleHaberes.TabIndex = 140
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.Sugerencia_partidas)
        Me.GroupBox2.Controls.Add(Me.Datos_Partidas)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.Location = New System.Drawing.Point(2, 397)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox2.Size = New System.Drawing.Size(1018, 143)
        Me.GroupBox2.TabIndex = 718
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "PARTIDAS PRESUPUESTARIAS"
        '
        'Sugerencia_partidas
        '
        Me.Sugerencia_partidas.BackColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Sugerencia_partidas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Sugerencia_partidas.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sugerencia_partidas.ForeColor = System.Drawing.Color.Ivory
        Me.Sugerencia_partidas.Image = CType(resources.GetObject("Sugerencia_partidas.Image"), System.Drawing.Image)
        Me.Sugerencia_partidas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Sugerencia_partidas.Location = New System.Drawing.Point(3, 16)
        Me.Sugerencia_partidas.Margin = New System.Windows.Forms.Padding(0)
        Me.Sugerencia_partidas.Name = "Sugerencia_partidas"
        Me.Sugerencia_partidas.Size = New System.Drawing.Size(80, 124)
        Me.Sugerencia_partidas.TabIndex = 729
        Me.Sugerencia_partidas.Text = "Sugerencias Partidas"
        Me.Sugerencia_partidas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Sugerencia_partidas.UseVisualStyleBackColor = False
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
        Me.Datos_Partidas.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.Datos_Partidas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Datos_Partidas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_Partidas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Datos_Partidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(198, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_Partidas.DefaultCellStyle = DataGridViewCellStyle4
        Me.Datos_Partidas.Location = New System.Drawing.Point(82, 19)
        Me.Datos_Partidas.Name = "Datos_Partidas"
        Me.Datos_Partidas.ReadOnly = True
        Me.Datos_Partidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Datos_Partidas.Size = New System.Drawing.Size(933, 121)
        Me.Datos_Partidas.TabIndex = 722
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Panel1.Controls.Add(Me.FullScreen_boton)
        Me.Panel1.Controls.Add(Me.Cerrar_boton)
        Me.Panel1.Controls.Add(Me.Label_ordenpagoasociada)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1022, 37)
        Me.Panel1.TabIndex = 719
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
        Me.FullScreen_boton.Location = New System.Drawing.Point(922, 0)
        Me.FullScreen_boton.Name = "FullScreen_boton"
        Me.FullScreen_boton.Size = New System.Drawing.Size(52, 37)
        Me.FullScreen_boton.TabIndex = 33
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
        Me.Cerrar_boton.Location = New System.Drawing.Point(980, 0)
        Me.Cerrar_boton.Name = "Cerrar_boton"
        Me.Cerrar_boton.Size = New System.Drawing.Size(42, 37)
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
        'Flicker_Tablelayout1
        '
        Me.Flicker_Tablelayout1.ColumnCount = 2
        Me.Flicker_Tablelayout1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Flicker_Tablelayout1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Flicker_Tablelayout1.Controls.Add(Me.Guardar_boton, 0, 0)
        Me.Flicker_Tablelayout1.Controls.Add(Me.Guardar_eimprimir_boton, 1, 0)
        Me.Flicker_Tablelayout1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flicker_Tablelayout1.Location = New System.Drawing.Point(0, 543)
        Me.Flicker_Tablelayout1.Name = "Flicker_Tablelayout1"
        Me.Flicker_Tablelayout1.RowCount = 1
        Me.Flicker_Tablelayout1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Flicker_Tablelayout1.Size = New System.Drawing.Size(1022, 39)
        Me.Flicker_Tablelayout1.TabIndex = 720
        '
        'Guardar_boton
        '
        Me.Guardar_boton.BackColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Guardar_boton.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guardar_boton.ForeColor = System.Drawing.Color.White
        Me.Guardar_boton.Location = New System.Drawing.Point(1, 1)
        Me.Guardar_boton.Margin = New System.Windows.Forms.Padding(1)
        Me.Guardar_boton.Name = "Guardar_boton"
        Me.Guardar_boton.Size = New System.Drawing.Size(509, 36)
        Me.Guardar_boton.TabIndex = 716
        Me.Guardar_boton.Text = "Guardar"
        Me.Guardar_boton.UseVisualStyleBackColor = False
        '
        'Guardar_eimprimir_boton
        '
        Me.Guardar_eimprimir_boton.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Guardar_eimprimir_boton.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guardar_eimprimir_boton.ForeColor = System.Drawing.Color.Black
        Me.Guardar_eimprimir_boton.Location = New System.Drawing.Point(512, 1)
        Me.Guardar_eimprimir_boton.Margin = New System.Windows.Forms.Padding(1)
        Me.Guardar_eimprimir_boton.Name = "Guardar_eimprimir_boton"
        Me.Guardar_eimprimir_boton.Size = New System.Drawing.Size(509, 36)
        Me.Guardar_eimprimir_boton.TabIndex = 18
        Me.Guardar_eimprimir_boton.Text = "Guardar y Generar Archivo"
        Me.Guardar_eimprimir_boton.UseVisualStyleBackColor = False
        '
        'Contabilidad_DialogoHaberes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1022, 582)
        Me.ControlBox = False
        Me.Controls.Add(Me.Flicker_Tablelayout1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Contabilidad_DialogoHaberes"
        Me.Text = "Contabilidad_DialogoHaberes"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.Year_numericupdown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Numeroexpediente_numericupdown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Organismo_numericupdown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Recupero_varios_numericupdown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LIQUIDACIONAPAGAR_NUMERICUPDOWN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OPNumero_numericupdown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OPyear_numericupdown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PARTIDAS_TOTALNUMERICAUPDOWN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Montototal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.Datos_DetalleHaberes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.Datos_Partidas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Flicker_Tablelayout1.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents ordenpago_detalles As TextBox
    Friend WithEvents Montototal As Flicker_Numericcontrol_Dinero
    Friend WithEvents Label_montonombre As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents OPNumero_numericupdown As NumericUpDown
    Friend WithEvents Label12 As Label
    Friend WithEvents OPyear_numericupdown As NumericUpDown
    Friend WithEvents Fechaconfeccion_datetimepicker As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents PARTIDAS_TOTALNUMERICAUPDOWN As Flicker_Numericcontrol_Dinero
    Friend WithEvents Label1 As Label
    Friend WithEvents Datos_Partidas As Flicker_Datagridview
    Friend WithEvents ordenpago_detalles2 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Datos_DetalleHaberes As Flicker_Datagridview
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Cerrar_boton As Button
    Friend WithEvents Label_ordenpagoasociada As Label
    Friend WithEvents FullScreen_boton As Button
    Friend WithEvents Flicker_Tablelayout1 As Flicker_Tablelayout
    Friend WithEvents Guardar_boton As Button
    Friend WithEvents Guardar_eimprimir_boton As Button
    Friend WithEvents LIQUIDACIONAPAGAR_NUMERICUPDOWN As Flicker_Numericcontrol_Dinero
    Friend WithEvents Label3 As Label
    Friend WithEvents Recupero_varios_numericupdown As Flicker_Numericcontrol_Dinero
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Sugerencia_partidas As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents Year_numericupdown As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents Numeroexpediente_numericupdown As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents Organismo_numericupdown As NumericUpDown
    Friend WithEvents Label13 As Label
End Class
