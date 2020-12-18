<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Direccion_reportes
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Direccion_reportes))
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Kripton_containergeneral = New SICyF.Flicker_Split_panel()
        Me.Generar_reporte = New System.Windows.Forms.Button()
        Me.Label_Tiporeporte = New System.Windows.Forms.Label()
        Me.Seleccionarcuenta_boton = New System.Windows.Forms.Button()
        Me.Desde_monthcalendarA = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Hasta_monthcalendarA = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Splitcontainer_Datos = New SICyF.Flicker_Split_panel()
        Me.Flicker_Datagridview1 = New SICyF.Flicker_Datagridview()
        Me.Refresh_boton = New System.Windows.Forms.Button()
        Me.Descripcion_General_label = New System.Windows.Forms.Label()
        Me.Buscador_general = New System.Windows.Forms.TextBox()
        Me.Datagrid_General = New SICyF.Flicker_Datagridview()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Imagen_General = New System.Windows.Forms.PictureBox()
        Me.Ver_todos_movimientos_checkbox = New System.Windows.Forms.CheckBox()
        Me.Datagrid_totales = New SICyF.Flicker_Datagridview()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Descripcion_Detallado_label = New System.Windows.Forms.Label()
        Me.Buscador_detallado = New System.Windows.Forms.TextBox()
        Me.Datagrid_Detalles = New SICyF.Flicker_Datagridview()
        Me.Ver_MFyV_CheckBox = New System.Windows.Forms.CheckBox()
        CType(Me.Kripton_containergeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Kripton_containergeneral.Panel1.SuspendLayout()
        Me.Kripton_containergeneral.Panel2.SuspendLayout()
        Me.Kripton_containergeneral.SuspendLayout()
        CType(Me.Splitcontainer_Datos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Splitcontainer_Datos.Panel1.SuspendLayout()
        Me.Splitcontainer_Datos.Panel2.SuspendLayout()
        Me.Splitcontainer_Datos.SuspendLayout()
        CType(Me.Flicker_Datagridview1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Datagrid_General, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Imagen_General, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Datagrid_totales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Datagrid_Detalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Kripton_containergeneral
        '
        Me.Kripton_containergeneral.BackColor = System.Drawing.Color.DarkGray
        Me.Kripton_containergeneral.Cursor = System.Windows.Forms.Cursors.Default
        Me.Kripton_containergeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Kripton_containergeneral.Location = New System.Drawing.Point(0, 0)
        Me.Kripton_containergeneral.Name = "Kripton_containergeneral"
        Me.Kripton_containergeneral.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'Kripton_containergeneral.Panel1
        '
        Me.Kripton_containergeneral.Panel1.BackColor = System.Drawing.Color.White
        Me.Kripton_containergeneral.Panel1.Controls.Add(Me.Generar_reporte)
        Me.Kripton_containergeneral.Panel1.Controls.Add(Me.Label_Tiporeporte)
        Me.Kripton_containergeneral.Panel1.Controls.Add(Me.Seleccionarcuenta_boton)
        Me.Kripton_containergeneral.Panel1.Controls.Add(Me.Desde_monthcalendarA)
        Me.Kripton_containergeneral.Panel1.Controls.Add(Me.Label2)
        Me.Kripton_containergeneral.Panel1.Controls.Add(Me.Hasta_monthcalendarA)
        Me.Kripton_containergeneral.Panel1.Controls.Add(Me.Label5)
        '
        'Kripton_containergeneral.Panel2
        '
        Me.Kripton_containergeneral.Panel2.Controls.Add(Me.Splitcontainer_Datos)
        Me.Kripton_containergeneral.Size = New System.Drawing.Size(1002, 512)
        Me.Kripton_containergeneral.SplitterDistance = 55
        Me.Kripton_containergeneral.TabIndex = 1
        '
        'Generar_reporte
        '
        Me.Generar_reporte.BackColor = System.Drawing.Color.SteelBlue
        Me.Generar_reporte.Font = New System.Drawing.Font("Raleway Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Generar_reporte.ForeColor = System.Drawing.Color.White
        Me.Generar_reporte.Location = New System.Drawing.Point(472, 26)
        Me.Generar_reporte.Name = "Generar_reporte"
        Me.Generar_reporte.Size = New System.Drawing.Size(321, 27)
        Me.Generar_reporte.TabIndex = 139
        Me.Generar_reporte.Text = "Ver Reporte"
        Me.Generar_reporte.UseVisualStyleBackColor = False
        '
        'Label_Tiporeporte
        '
        Me.Label_Tiporeporte.BackColor = System.Drawing.Color.Transparent
        Me.Label_Tiporeporte.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Tiporeporte.Location = New System.Drawing.Point(3, 3)
        Me.Label_Tiporeporte.Name = "Label_Tiporeporte"
        Me.Label_Tiporeporte.Size = New System.Drawing.Size(460, 23)
        Me.Label_Tiporeporte.TabIndex = 138
        Me.Label_Tiporeporte.Text = "-"
        Me.Label_Tiporeporte.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Seleccionarcuenta_boton
        '
        Me.Seleccionarcuenta_boton.BackColor = System.Drawing.Color.SkyBlue
        Me.Seleccionarcuenta_boton.Font = New System.Drawing.Font("Raleway Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Seleccionarcuenta_boton.Location = New System.Drawing.Point(3, 32)
        Me.Seleccionarcuenta_boton.Name = "Seleccionarcuenta_boton"
        Me.Seleccionarcuenta_boton.Size = New System.Drawing.Size(460, 20)
        Me.Seleccionarcuenta_boton.TabIndex = 137
        Me.Seleccionarcuenta_boton.Text = "Seleccionar TIPO REPORTE"
        Me.Seleccionarcuenta_boton.UseVisualStyleBackColor = False
        '
        'Desde_monthcalendarA
        '
        Me.Desde_monthcalendarA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Desde_monthcalendarA.Location = New System.Drawing.Point(529, 3)
        Me.Desde_monthcalendarA.Name = "Desde_monthcalendarA"
        Me.Desde_monthcalendarA.Size = New System.Drawing.Size(98, 20)
        Me.Desde_monthcalendarA.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(469, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 16)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Desde"
        '
        'Hasta_monthcalendarA
        '
        Me.Hasta_monthcalendarA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Hasta_monthcalendarA.Location = New System.Drawing.Point(688, 3)
        Me.Hasta_monthcalendarA.Name = "Hasta_monthcalendarA"
        Me.Hasta_monthcalendarA.Size = New System.Drawing.Size(105, 20)
        Me.Hasta_monthcalendarA.TabIndex = 24
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(633, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 16)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Hasta"
        '
        'Splitcontainer_Datos
        '
        Me.Splitcontainer_Datos.BackColor = System.Drawing.Color.Gray
        Me.Splitcontainer_Datos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Splitcontainer_Datos.Location = New System.Drawing.Point(0, 0)
        Me.Splitcontainer_Datos.Name = "Splitcontainer_Datos"
        '
        'Splitcontainer_Datos.Panel1
        '
        Me.Splitcontainer_Datos.Panel1.BackColor = System.Drawing.Color.White
        Me.Splitcontainer_Datos.Panel1.Controls.Add(Me.Flicker_Datagridview1)
        Me.Splitcontainer_Datos.Panel1.Controls.Add(Me.Refresh_boton)
        Me.Splitcontainer_Datos.Panel1.Controls.Add(Me.Descripcion_General_label)
        Me.Splitcontainer_Datos.Panel1.Controls.Add(Me.Buscador_general)
        Me.Splitcontainer_Datos.Panel1.Controls.Add(Me.Datagrid_General)
        Me.Splitcontainer_Datos.Panel1.Controls.Add(Me.Label3)
        Me.Splitcontainer_Datos.Panel1.Controls.Add(Me.Imagen_General)
        '
        'Splitcontainer_Datos.Panel2
        '
        Me.Splitcontainer_Datos.Panel2.BackColor = System.Drawing.Color.White
        Me.Splitcontainer_Datos.Panel2.Controls.Add(Me.Ver_MFyV_CheckBox)
        Me.Splitcontainer_Datos.Panel2.Controls.Add(Me.Ver_todos_movimientos_checkbox)
        Me.Splitcontainer_Datos.Panel2.Controls.Add(Me.Datagrid_totales)
        Me.Splitcontainer_Datos.Panel2.Controls.Add(Me.Label1)
        Me.Splitcontainer_Datos.Panel2.Controls.Add(Me.Descripcion_Detallado_label)
        Me.Splitcontainer_Datos.Panel2.Controls.Add(Me.Buscador_detallado)
        Me.Splitcontainer_Datos.Panel2.Controls.Add(Me.Datagrid_Detalles)
        Me.Splitcontainer_Datos.Size = New System.Drawing.Size(1002, 453)
        Me.Splitcontainer_Datos.SplitterDistance = 417
        Me.Splitcontainer_Datos.TabIndex = 1
        '
        'Flicker_Datagridview1
        '
        Me.Flicker_Datagridview1.AllowUserToAddRows = False
        Me.Flicker_Datagridview1.AllowUserToDeleteRows = False
        Me.Flicker_Datagridview1.AllowUserToOrderColumns = True
        Me.Flicker_Datagridview1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Flicker_Datagridview1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Flicker_Datagridview1.BackgroundColor = System.Drawing.Color.White
        Me.Flicker_Datagridview1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Flicker_Datagridview1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.Flicker_Datagridview1.ColumnHeadersHeight = 40
        Me.Flicker_Datagridview1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Flicker_Datagridview1.DefaultCellStyle = DataGridViewCellStyle10
        Me.Flicker_Datagridview1.Location = New System.Drawing.Point(3, 382)
        Me.Flicker_Datagridview1.Name = "Flicker_Datagridview1"
        Me.Flicker_Datagridview1.ReadOnly = True
        Me.Flicker_Datagridview1.RowHeadersVisible = False
        Me.Flicker_Datagridview1.RowHeadersWidth = 22
        Me.Flicker_Datagridview1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Flicker_Datagridview1.Size = New System.Drawing.Size(411, 68)
        Me.Flicker_Datagridview1.TabIndex = 128
        '
        'Refresh_boton
        '
        Me.Refresh_boton.BackColor = System.Drawing.Color.Green
        Me.Refresh_boton.BackgroundImage = CType(resources.GetObject("Refresh_boton.BackgroundImage"), System.Drawing.Image)
        Me.Refresh_boton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Refresh_boton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Refresh_boton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Refresh_boton.ForeColor = System.Drawing.Color.Black
        Me.Refresh_boton.Location = New System.Drawing.Point(113, 13)
        Me.Refresh_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Refresh_boton.Name = "Refresh_boton"
        Me.Refresh_boton.Size = New System.Drawing.Size(32, 26)
        Me.Refresh_boton.TabIndex = 125
        Me.Refresh_boton.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Refresh_boton.UseVisualStyleBackColor = False
        '
        'Descripcion_General_label
        '
        Me.Descripcion_General_label.AutoSize = True
        Me.Descripcion_General_label.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Descripcion_General_label.Location = New System.Drawing.Point(84, 17)
        Me.Descripcion_General_label.Name = "Descripcion_General_label"
        Me.Descripcion_General_label.Size = New System.Drawing.Size(14, 17)
        Me.Descripcion_General_label.TabIndex = 124
        Me.Descripcion_General_label.Text = "-"
        '
        'Buscador_general
        '
        Me.Buscador_general.Location = New System.Drawing.Point(222, 18)
        Me.Buscador_general.Name = "Buscador_general"
        Me.Buscador_general.Size = New System.Drawing.Size(164, 20)
        Me.Buscador_general.TabIndex = 114
        '
        'Datagrid_General
        '
        Me.Datagrid_General.AllowUserToAddRows = False
        Me.Datagrid_General.AllowUserToDeleteRows = False
        Me.Datagrid_General.AllowUserToOrderColumns = True
        Me.Datagrid_General.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Datagrid_General.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Datagrid_General.BackgroundColor = System.Drawing.Color.White
        Me.Datagrid_General.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datagrid_General.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.Datagrid_General.ColumnHeadersHeight = 40
        Me.Datagrid_General.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datagrid_General.DefaultCellStyle = DataGridViewCellStyle12
        Me.Datagrid_General.Location = New System.Drawing.Point(3, 40)
        Me.Datagrid_General.Name = "Datagrid_General"
        Me.Datagrid_General.ReadOnly = True
        Me.Datagrid_General.RowHeadersVisible = False
        Me.Datagrid_General.RowHeadersWidth = 22
        Me.Datagrid_General.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Datagrid_General.Size = New System.Drawing.Size(411, 336)
        Me.Datagrid_General.TabIndex = 122
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 7.25!)
        Me.Label3.Location = New System.Drawing.Point(182, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 12)
        Me.Label3.TabIndex = 115
        Me.Label3.Text = "Buscar"
        '
        'Imagen_General
        '
        Me.Imagen_General.BackColor = System.Drawing.Color.Transparent
        Me.Imagen_General.Location = New System.Drawing.Point(9, 9)
        Me.Imagen_General.Name = "Imagen_General"
        Me.Imagen_General.Size = New System.Drawing.Size(69, 31)
        Me.Imagen_General.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Imagen_General.TabIndex = 116
        Me.Imagen_General.TabStop = False
        '
        'Ver_todos_movimientos_checkbox
        '
        Me.Ver_todos_movimientos_checkbox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Ver_todos_movimientos_checkbox.AutoSize = True
        Me.Ver_todos_movimientos_checkbox.CheckAlign = System.Drawing.ContentAlignment.TopRight
        Me.Ver_todos_movimientos_checkbox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ver_todos_movimientos_checkbox.Location = New System.Drawing.Point(10, 382)
        Me.Ver_todos_movimientos_checkbox.Name = "Ver_todos_movimientos_checkbox"
        Me.Ver_todos_movimientos_checkbox.Size = New System.Drawing.Size(169, 19)
        Me.Ver_todos_movimientos_checkbox.TabIndex = 127
        Me.Ver_todos_movimientos_checkbox.Text = "Ver todos los movimientos"
        Me.Ver_todos_movimientos_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Ver_todos_movimientos_checkbox.UseVisualStyleBackColor = True
        '
        'Datagrid_totales
        '
        Me.Datagrid_totales.AllowUserToAddRows = False
        Me.Datagrid_totales.AllowUserToDeleteRows = False
        Me.Datagrid_totales.AllowUserToOrderColumns = True
        Me.Datagrid_totales.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Datagrid_totales.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Datagrid_totales.BackgroundColor = System.Drawing.Color.White
        Me.Datagrid_totales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datagrid_totales.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.Datagrid_totales.ColumnHeadersHeight = 40
        Me.Datagrid_totales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datagrid_totales.DefaultCellStyle = DataGridViewCellStyle14
        Me.Datagrid_totales.Location = New System.Drawing.Point(313, 343)
        Me.Datagrid_totales.Name = "Datagrid_totales"
        Me.Datagrid_totales.ReadOnly = True
        Me.Datagrid_totales.RowHeadersVisible = False
        Me.Datagrid_totales.RowHeadersWidth = 22
        Me.Datagrid_totales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Datagrid_totales.Size = New System.Drawing.Size(265, 107)
        Me.Datagrid_totales.TabIndex = 126
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 7.25!)
        Me.Label1.Location = New System.Drawing.Point(8, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 12)
        Me.Label1.TabIndex = 125
        Me.Label1.Text = "Buscar"
        '
        'Descripcion_Detallado_label
        '
        Me.Descripcion_Detallado_label.AutoSize = True
        Me.Descripcion_Detallado_label.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Descripcion_Detallado_label.Location = New System.Drawing.Point(484, 16)
        Me.Descripcion_Detallado_label.Name = "Descripcion_Detallado_label"
        Me.Descripcion_Detallado_label.Size = New System.Drawing.Size(14, 17)
        Me.Descripcion_Detallado_label.TabIndex = 124
        Me.Descripcion_Detallado_label.Text = "-"
        '
        'Buscador_detallado
        '
        Me.Buscador_detallado.Location = New System.Drawing.Point(48, 5)
        Me.Buscador_detallado.Name = "Buscador_detallado"
        Me.Buscador_detallado.Size = New System.Drawing.Size(151, 20)
        Me.Buscador_detallado.TabIndex = 116
        '
        'Datagrid_Detalles
        '
        Me.Datagrid_Detalles.AllowUserToAddRows = False
        Me.Datagrid_Detalles.AllowUserToDeleteRows = False
        Me.Datagrid_Detalles.AllowUserToOrderColumns = True
        Me.Datagrid_Detalles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Datagrid_Detalles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Datagrid_Detalles.BackgroundColor = System.Drawing.Color.White
        Me.Datagrid_Detalles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datagrid_Detalles.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.Datagrid_Detalles.ColumnHeadersHeight = 40
        Me.Datagrid_Detalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datagrid_Detalles.DefaultCellStyle = DataGridViewCellStyle16
        Me.Datagrid_Detalles.Location = New System.Drawing.Point(0, 36)
        Me.Datagrid_Detalles.Margin = New System.Windows.Forms.Padding(0)
        Me.Datagrid_Detalles.Name = "Datagrid_Detalles"
        Me.Datagrid_Detalles.ReadOnly = True
        Me.Datagrid_Detalles.RowHeadersVisible = False
        Me.Datagrid_Detalles.RowHeadersWidth = 22
        Me.Datagrid_Detalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Datagrid_Detalles.Size = New System.Drawing.Size(578, 304)
        Me.Datagrid_Detalles.TabIndex = 121
        '
        'Ver_MFyV_CheckBox
        '
        Me.Ver_MFyV_CheckBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Ver_MFyV_CheckBox.AutoSize = True
        Me.Ver_MFyV_CheckBox.CheckAlign = System.Drawing.ContentAlignment.TopRight
        Me.Ver_MFyV_CheckBox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ver_MFyV_CheckBox.Location = New System.Drawing.Point(10, 407)
        Me.Ver_MFyV_CheckBox.Name = "Ver_MFyV_CheckBox"
        Me.Ver_MFyV_CheckBox.Size = New System.Drawing.Size(80, 19)
        Me.Ver_MFyV_CheckBox.TabIndex = 128
        Me.Ver_MFyV_CheckBox.Text = "Ver  MFyV"
        Me.Ver_MFyV_CheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Ver_MFyV_CheckBox.UseVisualStyleBackColor = True
        '
        'Direccion_reportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1002, 512)
        Me.Controls.Add(Me.Kripton_containergeneral)
        Me.Name = "Direccion_reportes"
        Me.Text = "Direccion_reportes"
        Me.Kripton_containergeneral.Panel1.ResumeLayout(False)
        Me.Kripton_containergeneral.Panel1.PerformLayout()
        Me.Kripton_containergeneral.Panel2.ResumeLayout(False)
        CType(Me.Kripton_containergeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Kripton_containergeneral.ResumeLayout(False)
        Me.Splitcontainer_Datos.Panel1.ResumeLayout(False)
        Me.Splitcontainer_Datos.Panel1.PerformLayout()
        Me.Splitcontainer_Datos.Panel2.ResumeLayout(False)
        Me.Splitcontainer_Datos.Panel2.PerformLayout()
        CType(Me.Splitcontainer_Datos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Splitcontainer_Datos.ResumeLayout(False)
        CType(Me.Flicker_Datagridview1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Datagrid_General, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Imagen_General, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Datagrid_totales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Datagrid_Detalles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents Kripton_containergeneral As Flicker_Split_panel
    Friend WithEvents Label_Tiporeporte As Label
    Friend WithEvents Seleccionarcuenta_boton As Button
    Friend WithEvents Desde_monthcalendarA As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Hasta_monthcalendarA As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Splitcontainer_Datos As Flicker_Split_panel
    Friend WithEvents Descripcion_General_label As Label
    Friend WithEvents Buscador_general As TextBox
    Friend WithEvents Datagrid_General As Flicker_Datagridview
    Friend WithEvents Label3 As Label
    Friend WithEvents Imagen_General As PictureBox
    Friend WithEvents Datagrid_Detalles As Flicker_Datagridview
    Friend WithEvents Buscador_detallado As TextBox
    Friend WithEvents Descripcion_Detallado_label As Label
    Friend WithEvents Refresh_boton As Button
    Friend WithEvents Generar_reporte As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Datagrid_totales As Flicker_Datagridview
    Friend WithEvents Flicker_Datagridview1 As Flicker_Datagridview
    Friend WithEvents Ver_todos_movimientos_checkbox As CheckBox
    Friend WithEvents Ver_MFyV_CheckBox As CheckBox
End Class
