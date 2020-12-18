<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Contabilidad_DialogoOrdenPago
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FullScreen_boton = New System.Windows.Forms.Button()
        Me.Cerrar_boton = New System.Windows.Forms.Button()
        Me.Label_ordenpagoasociada = New System.Windows.Forms.Label()
        Me.ordenpago_detalles = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label_montonombre = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.PaneL_sinFlicker3 = New SICyF.PANEL_sinFlicker()
        Me.ESTADOOP = New System.Windows.Forms.TextBox()
        Me.CLASEOP = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ordenpago_detalles2 = New System.Windows.Forms.TextBox()
        Me.Flicker_Split_panel1 = New SICyF.Flicker_Split_panel()
        Me.PaneL_sinFlicker1 = New SICyF.PANEL_sinFlicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Datos_Ordenesprovision = New SICyF.Flicker_Datagridview()
        Me.Montototal = New SICyF.Flicker_Numericcontrol_Dinero()
        Me.PaneL_sinFlicker2 = New SICyF.PANEL_sinFlicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Sugerencia_partidas = New System.Windows.Forms.Button()
        Me.PARTIDAS_TOTALNUMERICAUPDOWN = New SICyF.Flicker_Numericcontrol_Dinero()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Datos_Partidas = New SICyF.Flicker_Datagridview()
        Me.NOVALIDO_CHECKBOX = New System.Windows.Forms.CheckBox()
        Me.LABELTIPODEORODEN = New System.Windows.Forms.Label()
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
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.PaneL_sinFlicker3.SuspendLayout()
        CType(Me.Flicker_Split_panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Flicker_Split_panel1.Panel1.SuspendLayout()
        Me.Flicker_Split_panel1.Panel2.SuspendLayout()
        Me.Flicker_Split_panel1.SuspendLayout()
        Me.PaneL_sinFlicker1.SuspendLayout()
        CType(Me.Datos_Ordenesprovision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Montototal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PaneL_sinFlicker2.SuspendLayout()
        CType(Me.PARTIDAS_TOTALNUMERICAUPDOWN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Datos_Partidas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OPNumero_numericupdown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OPyear_numericupdown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.Year_numericupdown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Numeroexpediente_numericupdown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Organismo_numericupdown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Flicker_Tablelayout1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(1287, 42)
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
        Me.FullScreen_boton.Location = New System.Drawing.Point(1179, 1)
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
        Me.Cerrar_boton.Location = New System.Drawing.Point(1245, 0)
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
        Me.Label_ordenpagoasociada.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.Label_ordenpagoasociada.Location = New System.Drawing.Point(282, 2)
        Me.Label_ordenpagoasociada.Name = "Label_ordenpagoasociada"
        Me.Label_ordenpagoasociada.Size = New System.Drawing.Size(165, 30)
        Me.Label_ordenpagoasociada.TabIndex = 29
        Me.Label_ordenpagoasociada.Text = "Orden de Pago"
        '
        'ordenpago_detalles
        '
        Me.ordenpago_detalles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ordenpago_detalles.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.ordenpago_detalles.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ordenpago_detalles.ForeColor = System.Drawing.Color.Black
        Me.ordenpago_detalles.Location = New System.Drawing.Point(90, 58)
        Me.ordenpago_detalles.Multiline = True
        Me.ordenpago_detalles.Name = "ordenpago_detalles"
        Me.ordenpago_detalles.Size = New System.Drawing.Size(1197, 46)
        Me.ordenpago_detalles.TabIndex = 3
        Me.ordenpago_detalles.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(4, 58)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 17)
        Me.Label9.TabIndex = 130
        Me.Label9.Text = "Descripción"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label_montonombre
        '
        Me.Label_montonombre.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_montonombre.AutoSize = True
        Me.Label_montonombre.BackColor = System.Drawing.Color.Transparent
        Me.Label_montonombre.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_montonombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Label_montonombre.Location = New System.Drawing.Point(359, 370)
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
        Me.GroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.GroupBox3.Controls.Add(Me.PaneL_sinFlicker3)
        Me.GroupBox3.Controls.Add(Me.Flicker_Split_panel1)
        Me.GroupBox3.Controls.Add(Me.NOVALIDO_CHECKBOX)
        Me.GroupBox3.Controls.Add(Me.LABELTIPODEORODEN)
        Me.GroupBox3.Controls.Add(Me.Boton_SUGERENCIA)
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
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(0, 42)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox3.Size = New System.Drawing.Size(1287, 559)
        Me.GroupBox3.TabIndex = 715
        Me.GroupBox3.TabStop = False
        '
        'PaneL_sinFlicker3
        '
        Me.PaneL_sinFlicker3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PaneL_sinFlicker3.BackColor = System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.PaneL_sinFlicker3.Controls.Add(Me.ESTADOOP)
        Me.PaneL_sinFlicker3.Controls.Add(Me.CLASEOP)
        Me.PaneL_sinFlicker3.Controls.Add(Me.Label14)
        Me.PaneL_sinFlicker3.Controls.Add(Me.Label13)
        Me.PaneL_sinFlicker3.Controls.Add(Me.Label4)
        Me.PaneL_sinFlicker3.Controls.Add(Me.ordenpago_detalles2)
        Me.PaneL_sinFlicker3.Location = New System.Drawing.Point(-2, 501)
        Me.PaneL_sinFlicker3.Margin = New System.Windows.Forms.Padding(0)
        Me.PaneL_sinFlicker3.Name = "PaneL_sinFlicker3"
        Me.PaneL_sinFlicker3.Size = New System.Drawing.Size(1292, 58)
        Me.PaneL_sinFlicker3.TabIndex = 2
        '
        'ESTADOOP
        '
        Me.ESTADOOP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ESTADOOP.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.ESTADOOP.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ESTADOOP.ForeColor = System.Drawing.Color.Black
        Me.ESTADOOP.Location = New System.Drawing.Point(971, 3)
        Me.ESTADOOP.Name = "ESTADOOP"
        Me.ESTADOOP.Size = New System.Drawing.Size(318, 22)
        Me.ESTADOOP.TabIndex = 135
        Me.ESTADOOP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CLASEOP
        '
        Me.CLASEOP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CLASEOP.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.CLASEOP.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CLASEOP.ForeColor = System.Drawing.Color.Black
        Me.CLASEOP.Location = New System.Drawing.Point(971, 30)
        Me.CLASEOP.Name = "CLASEOP"
        Me.CLASEOP.Size = New System.Drawing.Size(318, 22)
        Me.CLASEOP.TabIndex = 134
        Me.CLASEOP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(868, 30)
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
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(757, 3)
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
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(5, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 17)
        Me.Label4.TabIndex = 131
        Me.Label4.Text = "Observaciones"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ordenpago_detalles2
        '
        Me.ordenpago_detalles2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ordenpago_detalles2.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.ordenpago_detalles2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ordenpago_detalles2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.ordenpago_detalles2.Location = New System.Drawing.Point(109, 2)
        Me.ordenpago_detalles2.Multiline = True
        Me.ordenpago_detalles2.Name = "ordenpago_detalles2"
        Me.ordenpago_detalles2.Size = New System.Drawing.Size(642, 53)
        Me.ordenpago_detalles2.TabIndex = 4
        Me.ordenpago_detalles2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Flicker_Split_panel1
        '
        Me.Flicker_Split_panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Flicker_Split_panel1.BackColor = System.Drawing.Color.DarkGreen
        Me.Flicker_Split_panel1.Location = New System.Drawing.Point(-2, 107)
        Me.Flicker_Split_panel1.Name = "Flicker_Split_panel1"
        '
        'Flicker_Split_panel1.Panel1
        '
        Me.Flicker_Split_panel1.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Flicker_Split_panel1.Panel1.Controls.Add(Me.PaneL_sinFlicker1)
        '
        'Flicker_Split_panel1.Panel2
        '
        Me.Flicker_Split_panel1.Panel2.BackColor = System.Drawing.Color.White
        Me.Flicker_Split_panel1.Panel2.Controls.Add(Me.PaneL_sinFlicker2)
        Me.Flicker_Split_panel1.Size = New System.Drawing.Size(1292, 394)
        Me.Flicker_Split_panel1.SplitterDistance = 647
        Me.Flicker_Split_panel1.TabIndex = 730
        '
        'PaneL_sinFlicker1
        '
        Me.PaneL_sinFlicker1.BackColor = System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.PaneL_sinFlicker1.Controls.Add(Me.Label15)
        Me.PaneL_sinFlicker1.Controls.Add(Me.Datos_Ordenesprovision)
        Me.PaneL_sinFlicker1.Controls.Add(Me.Montototal)
        Me.PaneL_sinFlicker1.Controls.Add(Me.Label_montonombre)
        Me.PaneL_sinFlicker1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PaneL_sinFlicker1.Location = New System.Drawing.Point(0, 0)
        Me.PaneL_sinFlicker1.Margin = New System.Windows.Forms.Padding(0)
        Me.PaneL_sinFlicker1.Name = "PaneL_sinFlicker1"
        Me.PaneL_sinFlicker1.Size = New System.Drawing.Size(647, 394)
        Me.PaneL_sinFlicker1.TabIndex = 0
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(5, 5)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(108, 17)
        Me.Label15.TabIndex = 722
        Me.Label15.Text = "DATOS BÁSICOS"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Datos_Ordenesprovision
        '
        Me.Datos_Ordenesprovision.AllowUserToAddRows = False
        Me.Datos_Ordenesprovision.AllowUserToOrderColumns = True
        Me.Datos_Ordenesprovision.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Datos_Ordenesprovision.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.Datos_Ordenesprovision.BackgroundColor = System.Drawing.Color.White
        Me.Datos_Ordenesprovision.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Datos_Ordenesprovision.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_Ordenesprovision.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Datos_Ordenesprovision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(198, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_Ordenesprovision.DefaultCellStyle = DataGridViewCellStyle2
        Me.Datos_Ordenesprovision.Location = New System.Drawing.Point(-1, 32)
        Me.Datos_Ordenesprovision.Margin = New System.Windows.Forms.Padding(0)
        Me.Datos_Ordenesprovision.Name = "Datos_Ordenesprovision"
        Me.Datos_Ordenesprovision.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Datos_Ordenesprovision.Size = New System.Drawing.Size(645, 331)
        Me.Datos_Ordenesprovision.TabIndex = 721
        '
        'Montototal
        '
        Me.Montototal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Montototal.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.Montototal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Montototal.DecimalPlaces = 2
        Me.Montototal.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Montototal.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.Montototal.Location = New System.Drawing.Point(480, 366)
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
        'PaneL_sinFlicker2
        '
        Me.PaneL_sinFlicker2.BackColor = System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.PaneL_sinFlicker2.Controls.Add(Me.Label16)
        Me.PaneL_sinFlicker2.Controls.Add(Me.Sugerencia_partidas)
        Me.PaneL_sinFlicker2.Controls.Add(Me.PARTIDAS_TOTALNUMERICAUPDOWN)
        Me.PaneL_sinFlicker2.Controls.Add(Me.Label1)
        Me.PaneL_sinFlicker2.Controls.Add(Me.Datos_Partidas)
        Me.PaneL_sinFlicker2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PaneL_sinFlicker2.Location = New System.Drawing.Point(0, 0)
        Me.PaneL_sinFlicker2.Name = "PaneL_sinFlicker2"
        Me.PaneL_sinFlicker2.Size = New System.Drawing.Size(641, 394)
        Me.PaneL_sinFlicker2.TabIndex = 1
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(3, 5)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(188, 17)
        Me.Label16.TabIndex = 730
        Me.Label16.Text = "PARTIDAS PRESUPUESTARIAS"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Sugerencia_partidas
        '
        Me.Sugerencia_partidas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Sugerencia_partidas.BackColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Sugerencia_partidas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Sugerencia_partidas.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sugerencia_partidas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.Sugerencia_partidas.Image = CType(resources.GetObject("Sugerencia_partidas.Image"), System.Drawing.Image)
        Me.Sugerencia_partidas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Sugerencia_partidas.Location = New System.Drawing.Point(479, 0)
        Me.Sugerencia_partidas.Margin = New System.Windows.Forms.Padding(0)
        Me.Sugerencia_partidas.Name = "Sugerencia_partidas"
        Me.Sugerencia_partidas.Size = New System.Drawing.Size(154, 29)
        Me.Sugerencia_partidas.TabIndex = 729
        Me.Sugerencia_partidas.Text = "Sugerencias Partidas"
        Me.Sugerencia_partidas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Sugerencia_partidas.UseVisualStyleBackColor = False
        '
        'PARTIDAS_TOTALNUMERICAUPDOWN
        '
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.DecimalPlaces = 2
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.PARTIDAS_TOTALNUMERICAUPDOWN.Location = New System.Drawing.Point(473, 366)
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
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(305, 370)
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
        Me.Datos_Partidas.Location = New System.Drawing.Point(3, 32)
        Me.Datos_Partidas.Name = "Datos_Partidas"
        Me.Datos_Partidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Datos_Partidas.Size = New System.Drawing.Size(630, 335)
        Me.Datos_Partidas.TabIndex = 17
        '
        'NOVALIDO_CHECKBOX
        '
        Me.NOVALIDO_CHECKBOX.AutoSize = True
        Me.NOVALIDO_CHECKBOX.BackColor = System.Drawing.Color.Transparent
        Me.NOVALIDO_CHECKBOX.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.NOVALIDO_CHECKBOX.Location = New System.Drawing.Point(364, 33)
        Me.NOVALIDO_CHECKBOX.Name = "NOVALIDO_CHECKBOX"
        Me.NOVALIDO_CHECKBOX.Size = New System.Drawing.Size(226, 19)
        Me.NOVALIDO_CHECKBOX.TabIndex = 729
        Me.NOVALIDO_CHECKBOX.Text = "NO VALIDO COMO ORDEN DE PAGO"
        Me.NOVALIDO_CHECKBOX.UseVisualStyleBackColor = False
        '
        'LABELTIPODEORODEN
        '
        Me.LABELTIPODEORODEN.BackColor = System.Drawing.Color.Transparent
        Me.LABELTIPODEORODEN.Font = New System.Drawing.Font("Raleway Black", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LABELTIPODEORODEN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.LABELTIPODEORODEN.Location = New System.Drawing.Point(324, 9)
        Me.LABELTIPODEORODEN.Name = "LABELTIPODEORODEN"
        Me.LABELTIPODEORODEN.Size = New System.Drawing.Size(333, 46)
        Me.LABELTIPODEORODEN.TabIndex = 728
        Me.LABELTIPODEORODEN.Text = "RENDICIÓN PARCIAL"
        Me.LABELTIPODEORODEN.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Boton_SUGERENCIA
        '
        Me.Boton_SUGERENCIA.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
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
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(34, 11)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(50, 13)
        Me.Label11.TabIndex = 715
        Me.Label11.Text = "Número"
        '
        'OPNumero_numericupdown
        '
        Me.OPNumero_numericupdown.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.OPNumero_numericupdown.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OPNumero_numericupdown.Location = New System.Drawing.Point(10, 24)
        Me.OPNumero_numericupdown.Margin = New System.Windows.Forms.Padding(0)
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
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(141, 12)
        Me.Label12.Margin = New System.Windows.Forms.Padding(0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 13)
        Me.Label12.TabIndex = 716
        Me.Label12.Text = "Año"
        '
        'OPyear_numericupdown
        '
        Me.OPyear_numericupdown.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.OPyear_numericupdown.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OPyear_numericupdown.Location = New System.Drawing.Point(110, 24)
        Me.OPyear_numericupdown.Margin = New System.Windows.Forms.Padding(0)
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
        Me.Fechaconfeccion_datetimepicker.CalendarMonthBackground = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.Fechaconfeccion_datetimepicker.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Fechaconfeccion_datetimepicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Fechaconfeccion_datetimepicker.Location = New System.Drawing.Point(200, 29)
        Me.Fechaconfeccion_datetimepicker.Margin = New System.Windows.Forms.Padding(0)
        Me.Fechaconfeccion_datetimepicker.Name = "Fechaconfeccion_datetimepicker"
        Me.Fechaconfeccion_datetimepicker.Size = New System.Drawing.Size(115, 27)
        Me.Fechaconfeccion_datetimepicker.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(194, 11)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(134, 13)
        Me.Label6.TabIndex = 712
        Me.Label6.Text = "Fecha de Orden de Pago"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Year_numericupdown)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Numeroexpediente_numericupdown)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Organismo_numericupdown)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Location = New System.Drawing.Point(845, 6)
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
        Me.Flicker_Tablelayout1.Location = New System.Drawing.Point(0, 601)
        Me.Flicker_Tablelayout1.Name = "Flicker_Tablelayout1"
        Me.Flicker_Tablelayout1.RowCount = 1
        Me.Flicker_Tablelayout1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Flicker_Tablelayout1.Size = New System.Drawing.Size(1287, 39)
        Me.Flicker_Tablelayout1.TabIndex = 717
        '
        'Guardar_boton
        '
        Me.Guardar_boton.BackColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Guardar_boton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Guardar_boton.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guardar_boton.ForeColor = System.Drawing.Color.White
        Me.Guardar_boton.Location = New System.Drawing.Point(1, 1)
        Me.Guardar_boton.Margin = New System.Windows.Forms.Padding(1)
        Me.Guardar_boton.Name = "Guardar_boton"
        Me.Guardar_boton.Size = New System.Drawing.Size(641, 37)
        Me.Guardar_boton.TabIndex = 716
        Me.Guardar_boton.Text = "Guardar"
        Me.Guardar_boton.UseVisualStyleBackColor = False
        '
        'Guardar_eimprimir_boton
        '
        Me.Guardar_eimprimir_boton.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Guardar_eimprimir_boton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Guardar_eimprimir_boton.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guardar_eimprimir_boton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Guardar_eimprimir_boton.Location = New System.Drawing.Point(644, 1)
        Me.Guardar_eimprimir_boton.Margin = New System.Windows.Forms.Padding(1)
        Me.Guardar_eimprimir_boton.Name = "Guardar_eimprimir_boton"
        Me.Guardar_eimprimir_boton.Size = New System.Drawing.Size(642, 37)
        Me.Guardar_eimprimir_boton.TabIndex = 18
        Me.Guardar_eimprimir_boton.Text = "Guardar y Generar Archivo"
        Me.Guardar_eimprimir_boton.UseVisualStyleBackColor = False
        '
        'Contabilidad_DialogoOrdenPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1287, 640)
        Me.ControlBox = False
        Me.Controls.Add(Me.Flicker_Tablelayout1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Panel1)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Name = "Contabilidad_DialogoOrdenPago"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.PaneL_sinFlicker3.ResumeLayout(False)
        Me.PaneL_sinFlicker3.PerformLayout()
        Me.Flicker_Split_panel1.Panel1.ResumeLayout(False)
        Me.Flicker_Split_panel1.Panel2.ResumeLayout(False)
        CType(Me.Flicker_Split_panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Flicker_Split_panel1.ResumeLayout(False)
        Me.PaneL_sinFlicker1.ResumeLayout(False)
        Me.PaneL_sinFlicker1.PerformLayout()
        CType(Me.Datos_Ordenesprovision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Montototal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PaneL_sinFlicker2.ResumeLayout(False)
        Me.PaneL_sinFlicker2.PerformLayout()
        CType(Me.PARTIDAS_TOTALNUMERICAUPDOWN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Datos_Partidas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OPNumero_numericupdown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OPyear_numericupdown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.Year_numericupdown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Numeroexpediente_numericupdown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Organismo_numericupdown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Flicker_Tablelayout1.ResumeLayout(False)
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
    Friend WithEvents PaneL_sinFlicker1 As PANEL_sinFlicker
    Friend WithEvents Datos_Ordenesprovision As Flicker_Datagridview
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
    Friend WithEvents PaneL_sinFlicker2 As PANEL_sinFlicker
    Friend WithEvents LABELTIPODEORODEN As Label
    Friend WithEvents NOVALIDO_CHECKBOX As CheckBox
    Friend WithEvents Sugerencia_partidas As Button
    Friend WithEvents PaneL_sinFlicker3 As PANEL_sinFlicker
    Friend WithEvents ESTADOOP As TextBox
    Friend WithEvents CLASEOP As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ordenpago_detalles2 As TextBox
    Friend WithEvents Flicker_Split_panel1 As Flicker_Split_panel
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
End Class
