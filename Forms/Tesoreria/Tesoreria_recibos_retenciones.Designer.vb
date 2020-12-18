<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tesoreria_recibos_retenciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tesoreria_recibos_retenciones))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Proveedores_datagrid = New System.Windows.Forms.DataGridView()
        Me.Busqueda = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Cuentas_combobox = New System.Windows.Forms.ComboBox()
        Me.Busqueda_textbox = New System.Windows.Forms.TextBox()
        Me.Certificadoboton = New System.Windows.Forms.Button()
        Me.Expedientes_seleccionado = New System.Windows.Forms.DataGridView()
        Me.TOTALES_SELECCIONADO = New System.Windows.Forms.DataGridView()
        Me.N_Recibo_numeric2 = New System.Windows.Forms.NumericUpDown()
        Me.LABEL22 = New System.Windows.Forms.Label()
        Me.EXPEDIENTES_DATAGRIDVIEW = New SICyF.Flicker_Datagridview()
        Me.Recibo_boton = New System.Windows.Forms.Button()
        Me.Fecha_Recibo = New System.Windows.Forms.DateTimePicker()
        Me.N_Recibo_numeric = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Descripcion_textbox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.RetencionesTab = New SICyF.FlickerTabcontrol()
        Me.cargarecibos_tab = New System.Windows.Forms.TabPage()
        Me.Lista_recibos = New System.Windows.Forms.TabPage()
        Me.busquedarecibos = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Datos_recibos_datagridview = New SICyF.Flicker_Datagridview()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Listado_recibos_datagridview = New SICyF.Flicker_Datagridview()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Flicker_Split_panel1 = New SICyF.Flicker_Split_panel()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.Proveedores_datagrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Expedientes_seleccionado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TOTALES_SELECCIONADO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.N_Recibo_numeric2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EXPEDIENTES_DATAGRIDVIEW, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.N_Recibo_numeric, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RetencionesTab.SuspendLayout()
        Me.cargarecibos_tab.SuspendLayout()
        Me.Lista_recibos.SuspendLayout()
        CType(Me.Datos_recibos_datagridview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Listado_recibos_datagridview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Flicker_Split_panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Flicker_Split_panel1.Panel1.SuspendLayout()
        Me.Flicker_Split_panel1.Panel2.SuspendLayout()
        Me.Flicker_Split_panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Proveedores_datagrid
        '
        Me.Proveedores_datagrid.AllowUserToAddRows = False
        Me.Proveedores_datagrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Proveedores_datagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Proveedores_datagrid.BackgroundColor = System.Drawing.Color.White
        Me.Proveedores_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Proveedores_datagrid.GridColor = System.Drawing.Color.Black
        Me.Proveedores_datagrid.Location = New System.Drawing.Point(3, 28)
        Me.Proveedores_datagrid.MultiSelect = False
        Me.Proveedores_datagrid.Name = "Proveedores_datagrid"
        Me.Proveedores_datagrid.ReadOnly = True
        Me.Proveedores_datagrid.RowHeadersVisible = False
        Me.Proveedores_datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Proveedores_datagrid.Size = New System.Drawing.Size(257, 619)
        Me.Proveedores_datagrid.TabIndex = 106
        '
        'Busqueda
        '
        Me.Busqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Busqueda.BackColor = System.Drawing.Color.White
        Me.Busqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Busqueda.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Busqueda.ForeColor = System.Drawing.Color.Black
        Me.Busqueda.Location = New System.Drawing.Point(35, 3)
        Me.Busqueda.Margin = New System.Windows.Forms.Padding(0)
        Me.Busqueda.Name = "Busqueda"
        Me.Busqueda.Size = New System.Drawing.Size(225, 23)
        Me.Busqueda.TabIndex = 107
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.Cuentas_combobox)
        Me.GroupBox1.Controls.Add(Me.Busqueda_textbox)
        Me.GroupBox1.Controls.Add(Me.Certificadoboton)
        Me.GroupBox1.Controls.Add(Me.Expedientes_seleccionado)
        Me.GroupBox1.Controls.Add(Me.TOTALES_SELECCIONADO)
        Me.GroupBox1.Controls.Add(Me.N_Recibo_numeric2)
        Me.GroupBox1.Controls.Add(Me.LABEL22)
        Me.GroupBox1.Controls.Add(Me.EXPEDIENTES_DATAGRIDVIEW)
        Me.GroupBox1.Controls.Add(Me.Recibo_boton)
        Me.GroupBox1.Controls.Add(Me.Fecha_Recibo)
        Me.GroupBox1.Controls.Add(Me.N_Recibo_numeric)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Descripcion_textbox)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.ForeColor = System.Drawing.Color.LightCyan
        Me.GroupBox1.Location = New System.Drawing.Point(-4, 3)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(892, 618)
        Me.GroupBox1.TabIndex = 137
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Comprobante Recibo"
        '
        'Cuentas_combobox
        '
        Me.Cuentas_combobox.BackColor = System.Drawing.Color.PeachPuff
        Me.Cuentas_combobox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cuentas_combobox.FormattingEnabled = True
        Me.Cuentas_combobox.Location = New System.Drawing.Point(399, 8)
        Me.Cuentas_combobox.Margin = New System.Windows.Forms.Padding(0)
        Me.Cuentas_combobox.Name = "Cuentas_combobox"
        Me.Cuentas_combobox.Size = New System.Drawing.Size(399, 29)
        Me.Cuentas_combobox.TabIndex = 4
        '
        'Busqueda_textbox
        '
        Me.Busqueda_textbox.BackColor = System.Drawing.Color.White
        Me.Busqueda_textbox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Busqueda_textbox.ForeColor = System.Drawing.Color.Black
        Me.Busqueda_textbox.Location = New System.Drawing.Point(77, 13)
        Me.Busqueda_textbox.Name = "Busqueda_textbox"
        Me.Busqueda_textbox.Size = New System.Drawing.Size(185, 23)
        Me.Busqueda_textbox.TabIndex = 148
        Me.Busqueda_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Certificadoboton
        '
        Me.Certificadoboton.AllowDrop = True
        Me.Certificadoboton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Certificadoboton.AutoSize = True
        Me.Certificadoboton.BackColor = System.Drawing.Color.LightBlue
        Me.Certificadoboton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Certificadoboton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Certificadoboton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Certificadoboton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Certificadoboton.Image = CType(resources.GetObject("Certificadoboton.Image"), System.Drawing.Image)
        Me.Certificadoboton.Location = New System.Drawing.Point(524, 404)
        Me.Certificadoboton.Name = "Certificadoboton"
        Me.Certificadoboton.Size = New System.Drawing.Size(300, 43)
        Me.Certificadoboton.TabIndex = 147
        Me.Certificadoboton.Text = "Informe sobre Expedientes Seleccionados"
        Me.Certificadoboton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Certificadoboton.UseVisualStyleBackColor = False
        '
        'Expedientes_seleccionado
        '
        Me.Expedientes_seleccionado.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue
        Me.Expedientes_seleccionado.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Expedientes_seleccionado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Expedientes_seleccionado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Expedientes_seleccionado.BackgroundColor = System.Drawing.Color.White
        Me.Expedientes_seleccionado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(134, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Expedientes_seleccionado.DefaultCellStyle = DataGridViewCellStyle2
        Me.Expedientes_seleccionado.GridColor = System.Drawing.Color.Black
        Me.Expedientes_seleccionado.Location = New System.Drawing.Point(272, 470)
        Me.Expedientes_seleccionado.Name = "Expedientes_seleccionado"
        Me.Expedientes_seleccionado.ReadOnly = True
        Me.Expedientes_seleccionado.RowHeadersVisible = False
        Me.Expedientes_seleccionado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Expedientes_seleccionado.Size = New System.Drawing.Size(250, 148)
        Me.Expedientes_seleccionado.TabIndex = 146
        '
        'TOTALES_SELECCIONADO
        '
        Me.TOTALES_SELECCIONADO.AllowUserToAddRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Blue
        Me.TOTALES_SELECCIONADO.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.TOTALES_SELECCIONADO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TOTALES_SELECCIONADO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TOTALES_SELECCIONADO.BackgroundColor = System.Drawing.Color.White
        Me.TOTALES_SELECCIONADO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(134, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TOTALES_SELECCIONADO.DefaultCellStyle = DataGridViewCellStyle4
        Me.TOTALES_SELECCIONADO.GridColor = System.Drawing.Color.Black
        Me.TOTALES_SELECCIONADO.Location = New System.Drawing.Point(6, 470)
        Me.TOTALES_SELECCIONADO.Name = "TOTALES_SELECCIONADO"
        Me.TOTALES_SELECCIONADO.ReadOnly = True
        Me.TOTALES_SELECCIONADO.RowHeadersVisible = False
        Me.TOTALES_SELECCIONADO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TOTALES_SELECCIONADO.Size = New System.Drawing.Size(260, 148)
        Me.TOTALES_SELECCIONADO.TabIndex = 142
        '
        'N_Recibo_numeric2
        '
        Me.N_Recibo_numeric2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.N_Recibo_numeric2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.N_Recibo_numeric2.ForeColor = System.Drawing.Color.Black
        Me.N_Recibo_numeric2.Location = New System.Drawing.Point(127, 408)
        Me.N_Recibo_numeric2.Margin = New System.Windows.Forms.Padding(0)
        Me.N_Recibo_numeric2.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.N_Recibo_numeric2.Name = "N_Recibo_numeric2"
        Me.N_Recibo_numeric2.Size = New System.Drawing.Size(124, 29)
        Me.N_Recibo_numeric2.TabIndex = 1
        Me.N_Recibo_numeric2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LABEL22
        '
        Me.LABEL22.AutoSize = True
        Me.LABEL22.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LABEL22.ForeColor = System.Drawing.Color.White
        Me.LABEL22.Location = New System.Drawing.Point(6, 16)
        Me.LABEL22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LABEL22.Name = "LABEL22"
        Me.LABEL22.Size = New System.Drawing.Size(64, 20)
        Me.LABEL22.TabIndex = 139
        Me.LABEL22.Text = "BUSCAR"
        '
        'EXPEDIENTES_DATAGRIDVIEW
        '
        Me.EXPEDIENTES_DATAGRIDVIEW.AllowUserToAddRows = False
        Me.EXPEDIENTES_DATAGRIDVIEW.AllowUserToOrderColumns = True
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EXPEDIENTES_DATAGRIDVIEW.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.EXPEDIENTES_DATAGRIDVIEW.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EXPEDIENTES_DATAGRIDVIEW.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.EXPEDIENTES_DATAGRIDVIEW.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.EXPEDIENTES_DATAGRIDVIEW.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EXPEDIENTES_DATAGRIDVIEW.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.EXPEDIENTES_DATAGRIDVIEW.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(134, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.EXPEDIENTES_DATAGRIDVIEW.DefaultCellStyle = DataGridViewCellStyle7
        Me.EXPEDIENTES_DATAGRIDVIEW.GridColor = System.Drawing.Color.Black
        Me.EXPEDIENTES_DATAGRIDVIEW.Location = New System.Drawing.Point(0, 39)
        Me.EXPEDIENTES_DATAGRIDVIEW.Name = "EXPEDIENTES_DATAGRIDVIEW"
        Me.EXPEDIENTES_DATAGRIDVIEW.ReadOnly = True
        Me.EXPEDIENTES_DATAGRIDVIEW.RowHeadersVisible = False
        Me.EXPEDIENTES_DATAGRIDVIEW.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.EXPEDIENTES_DATAGRIDVIEW.Size = New System.Drawing.Size(886, 365)
        Me.EXPEDIENTES_DATAGRIDVIEW.TabIndex = 5
        '
        'Recibo_boton
        '
        Me.Recibo_boton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Recibo_boton.AutoSize = True
        Me.Recibo_boton.BackColor = System.Drawing.Color.LightBlue
        Me.Recibo_boton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Recibo_boton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Recibo_boton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Recibo_boton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Recibo_boton.Image = CType(resources.GetObject("Recibo_boton.Image"), System.Drawing.Image)
        Me.Recibo_boton.Location = New System.Drawing.Point(524, 558)
        Me.Recibo_boton.Name = "Recibo_boton"
        Me.Recibo_boton.Size = New System.Drawing.Size(300, 54)
        Me.Recibo_boton.TabIndex = 4
        Me.Recibo_boton.Text = "Guardar Recibo"
        Me.Recibo_boton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Recibo_boton.UseVisualStyleBackColor = False
        '
        'Fecha_Recibo
        '
        Me.Fecha_Recibo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Fecha_Recibo.CalendarFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fecha_Recibo.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Fecha_Recibo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Fecha_Recibo.Location = New System.Drawing.Point(364, 409)
        Me.Fecha_Recibo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Fecha_Recibo.Name = "Fecha_Recibo"
        Me.Fecha_Recibo.Size = New System.Drawing.Size(111, 27)
        Me.Fecha_Recibo.TabIndex = 2
        '
        'N_Recibo_numeric
        '
        Me.N_Recibo_numeric.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.N_Recibo_numeric.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.N_Recibo_numeric.ForeColor = System.Drawing.Color.Black
        Me.N_Recibo_numeric.Location = New System.Drawing.Point(34, 407)
        Me.N_Recibo_numeric.Margin = New System.Windows.Forms.Padding(0)
        Me.N_Recibo_numeric.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.N_Recibo_numeric.Name = "N_Recibo_numeric"
        Me.N_Recibo_numeric.Size = New System.Drawing.Size(70, 29)
        Me.N_Recibo_numeric.TabIndex = 0
        Me.N_Recibo_numeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(4, 411)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 20)
        Me.Label2.TabIndex = 120
        Me.Label2.Text = "Nº"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Descripcion_textbox
        '
        Me.Descripcion_textbox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Descripcion_textbox.BackColor = System.Drawing.Color.White
        Me.Descripcion_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Descripcion_textbox.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Descripcion_textbox.ForeColor = System.Drawing.Color.Black
        Me.Descripcion_textbox.Location = New System.Drawing.Point(95, 442)
        Me.Descripcion_textbox.Margin = New System.Windows.Forms.Padding(0)
        Me.Descripcion_textbox.Multiline = True
        Me.Descripcion_textbox.Name = "Descripcion_textbox"
        Me.Descripcion_textbox.Size = New System.Drawing.Size(426, 25)
        Me.Descripcion_textbox.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(293, 414)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 21)
        Me.Label5.TabIndex = 135
        Me.Label5.Text = "FECHA "
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(7, 444)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 20)
        Me.Label3.TabIndex = 111
        Me.Label3.Text = "Descripción"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(108, 411)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 20)
        Me.Label1.TabIndex = 141
        Me.Label1.Text = "-"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(268, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 21)
        Me.Label6.TabIndex = 145
        Me.Label6.Text = "Cuenta Bancaria"
        '
        'RetencionesTab
        '
        Me.RetencionesTab.Controls.Add(Me.cargarecibos_tab)
        Me.RetencionesTab.Controls.Add(Me.Lista_recibos)
        Me.RetencionesTab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RetencionesTab.Location = New System.Drawing.Point(0, 0)
        Me.RetencionesTab.Margin = New System.Windows.Forms.Padding(0)
        Me.RetencionesTab.Name = "RetencionesTab"
        Me.RetencionesTab.SelectedIndex = 0
        Me.RetencionesTab.Size = New System.Drawing.Size(901, 653)
        Me.RetencionesTab.TabIndex = 138
        '
        'cargarecibos_tab
        '
        Me.cargarecibos_tab.Controls.Add(Me.GroupBox1)
        Me.cargarecibos_tab.Location = New System.Drawing.Point(4, 22)
        Me.cargarecibos_tab.Name = "cargarecibos_tab"
        Me.cargarecibos_tab.Padding = New System.Windows.Forms.Padding(3)
        Me.cargarecibos_tab.Size = New System.Drawing.Size(893, 627)
        Me.cargarecibos_tab.TabIndex = 0
        Me.cargarecibos_tab.Text = "Carga de recibos"
        Me.cargarecibos_tab.UseVisualStyleBackColor = True
        '
        'Lista_recibos
        '
        Me.Lista_recibos.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.Lista_recibos.Controls.Add(Me.busquedarecibos)
        Me.Lista_recibos.Controls.Add(Me.Label8)
        Me.Lista_recibos.Controls.Add(Me.Datos_recibos_datagridview)
        Me.Lista_recibos.Controls.Add(Me.Label7)
        Me.Lista_recibos.Controls.Add(Me.Listado_recibos_datagridview)
        Me.Lista_recibos.Controls.Add(Me.Label4)
        Me.Lista_recibos.Location = New System.Drawing.Point(4, 22)
        Me.Lista_recibos.Name = "Lista_recibos"
        Me.Lista_recibos.Padding = New System.Windows.Forms.Padding(3)
        Me.Lista_recibos.Size = New System.Drawing.Size(819, 559)
        Me.Lista_recibos.TabIndex = 1
        Me.Lista_recibos.Text = "Lista de recibos"
        '
        'busquedarecibos
        '
        Me.busquedarecibos.BackColor = System.Drawing.Color.White
        Me.busquedarecibos.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.busquedarecibos.ForeColor = System.Drawing.Color.Black
        Me.busquedarecibos.Location = New System.Drawing.Point(272, 6)
        Me.busquedarecibos.Name = "busquedarecibos"
        Me.busquedarecibos.Size = New System.Drawing.Size(185, 23)
        Me.busquedarecibos.TabIndex = 150
        Me.busquedarecibos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(201, 9)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 20)
        Me.Label8.TabIndex = 149
        Me.Label8.Text = "BUSCAR"
        '
        'Datos_recibos_datagridview
        '
        Me.Datos_recibos_datagridview.AllowUserToAddRows = False
        Me.Datos_recibos_datagridview.AllowUserToDeleteRows = False
        Me.Datos_recibos_datagridview.AllowUserToOrderColumns = True
        DataGridViewCellStyle8.NullValue = Nothing
        Me.Datos_recibos_datagridview.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        Me.Datos_recibos_datagridview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Datos_recibos_datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Datos_recibos_datagridview.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Datos_recibos_datagridview.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_recibos_datagridview.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.Datos_recibos_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_recibos_datagridview.DefaultCellStyle = DataGridViewCellStyle10
        Me.Datos_recibos_datagridview.Location = New System.Drawing.Point(6, 251)
        Me.Datos_recibos_datagridview.Name = "Datos_recibos_datagridview"
        Me.Datos_recibos_datagridview.ReadOnly = True
        Me.Datos_recibos_datagridview.RowHeadersVisible = False
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_recibos_datagridview.RowsDefaultCellStyle = DataGridViewCellStyle11
        Me.Datos_recibos_datagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Datos_recibos_datagridview.Size = New System.Drawing.Size(806, 300)
        Me.Datos_recibos_datagridview.TabIndex = 140
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(3, 228)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(318, 20)
        Me.Label7.TabIndex = 142
        Me.Label7.Text = "EXPEDIENTES QUE CONFORMAN EL RECIBO"
        '
        'Listado_recibos_datagridview
        '
        Me.Listado_recibos_datagridview.AllowUserToAddRows = False
        Me.Listado_recibos_datagridview.AllowUserToDeleteRows = False
        Me.Listado_recibos_datagridview.AllowUserToOrderColumns = True
        DataGridViewCellStyle12.NullValue = Nothing
        Me.Listado_recibos_datagridview.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle12
        Me.Listado_recibos_datagridview.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Listado_recibos_datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.Listado_recibos_datagridview.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Listado_recibos_datagridview.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Listado_recibos_datagridview.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.Listado_recibos_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Listado_recibos_datagridview.DefaultCellStyle = DataGridViewCellStyle14
        Me.Listado_recibos_datagridview.Location = New System.Drawing.Point(6, 35)
        Me.Listado_recibos_datagridview.Name = "Listado_recibos_datagridview"
        Me.Listado_recibos_datagridview.ReadOnly = True
        Me.Listado_recibos_datagridview.RowHeadersVisible = False
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Listado_recibos_datagridview.RowsDefaultCellStyle = DataGridViewCellStyle15
        Me.Listado_recibos_datagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Listado_recibos_datagridview.Size = New System.Drawing.Size(806, 190)
        Me.Listado_recibos_datagridview.TabIndex = 138
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(3, 4)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 20)
        Me.Label4.TabIndex = 141
        Me.Label4.Text = "RECIBOS"
        '
        'Flicker_Split_panel1
        '
        Me.Flicker_Split_panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.Flicker_Split_panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flicker_Split_panel1.Location = New System.Drawing.Point(0, 0)
        Me.Flicker_Split_panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Flicker_Split_panel1.Name = "Flicker_Split_panel1"
        '
        'Flicker_Split_panel1.Panel1
        '
        Me.Flicker_Split_panel1.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.Flicker_Split_panel1.Panel1.Controls.Add(Me.Busqueda)
        Me.Flicker_Split_panel1.Panel1.Controls.Add(Me.Label9)
        Me.Flicker_Split_panel1.Panel1.Controls.Add(Me.Proveedores_datagrid)
        '
        'Flicker_Split_panel1.Panel2
        '
        Me.Flicker_Split_panel1.Panel2.BackColor = System.Drawing.Color.White
        Me.Flicker_Split_panel1.Panel2.Controls.Add(Me.RetencionesTab)
        Me.Flicker_Split_panel1.Size = New System.Drawing.Size(1168, 653)
        Me.Flicker_Split_panel1.SplitterDistance = 263
        Me.Flicker_Split_panel1.TabIndex = 139
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Image = CType(resources.GetObject("Label9.Image"), System.Drawing.Image)
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label9.Location = New System.Drawing.Point(3, 3)
        Me.Label9.Margin = New System.Windows.Forms.Padding(0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 22)
        Me.Label9.TabIndex = 117
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Tesoreria_recibos_retenciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(1168, 653)
        Me.Controls.Add(Me.Flicker_Split_panel1)
        Me.DoubleBuffered = True
        Me.Name = "Tesoreria_recibos_retenciones"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Tesoreria_recibos_retenciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Proveedores_datagrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Expedientes_seleccionado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TOTALES_SELECCIONADO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.N_Recibo_numeric2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EXPEDIENTES_DATAGRIDVIEW, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.N_Recibo_numeric, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RetencionesTab.ResumeLayout(False)
        Me.cargarecibos_tab.ResumeLayout(False)
        Me.Lista_recibos.ResumeLayout(False)
        Me.Lista_recibos.PerformLayout()
        CType(Me.Datos_recibos_datagridview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Listado_recibos_datagridview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Flicker_Split_panel1.Panel1.ResumeLayout(False)
        Me.Flicker_Split_panel1.Panel1.PerformLayout()
        Me.Flicker_Split_panel1.Panel2.ResumeLayout(False)
        CType(Me.Flicker_Split_panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Flicker_Split_panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents Proveedores_datagrid As DataGridView
    Friend WithEvents Busqueda As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Fecha_Recibo As DateTimePicker
    Friend WithEvents N_Recibo_numeric As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents Descripcion_textbox As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Recibo_boton As Button
    Friend WithEvents LABEL22 As Label
    Friend WithEvents EXPEDIENTES_DATAGRIDVIEW As SICyF.Flicker_Datagridview
    Friend WithEvents N_Recibo_numeric2 As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents TOTALES_SELECCIONADO As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents Cuentas_combobox As ComboBox
    Friend WithEvents Expedientes_seleccionado As DataGridView
    Friend WithEvents Certificadoboton As Button
    Friend WithEvents Busqueda_textbox As TextBox
    Friend WithEvents RetencionesTab As FlickerTabcontrol
    Friend WithEvents cargarecibos_tab As TabPage
    Friend WithEvents Lista_recibos As TabPage
    Friend WithEvents Datos_recibos_datagridview As Flicker_Datagridview
    Friend WithEvents Listado_recibos_datagridview As Flicker_Datagridview
    Friend WithEvents Label7 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents busquedarecibos As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Flicker_Split_panel1 As Flicker_Split_panel
    Friend WithEvents Label9 As Label
End Class
