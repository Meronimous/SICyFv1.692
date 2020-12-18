<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Tesoreria_Expedientes
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tesoreria_Expedientes))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SplitExpedientes = New System.Windows.Forms.SplitContainer()
        Me.Listado_ = New SICyF.Flicker_Datagridview()
        Me.Busqueda_textbox = New System.Windows.Forms.TextBox()
        Me.Refresh_boton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Datos_expediente_Tabcontrol = New System.Windows.Forms.TabControl()
        Me.Datosgenerales_tabitem = New System.Windows.Forms.TabPage()
        Me.Detalle_listado_expedientes = New ComponentFactory.Krypton.Toolkit.KryptonListBox()
        Me.Pedidofondo_tabitem = New System.Windows.Forms.TabPage()
        Me.Labeltotalpedidofondo = New System.Windows.Forms.Label()
        Me.Datospedidofondo_fecha = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.Datospedidofondo_label = New System.Windows.Forms.Label()
        Me.Datosexpediente_pedidofondolabel = New System.Windows.Forms.Label()
        Me.Datospedidofondo_datagrid = New SICyF.Flicker_Datagridview()
        Me.Expedientesrelacionados_tabitem = New System.Windows.Forms.TabPage()
        Me.Datosexpedientesasociados_datagrid = New SICyF.Flicker_Datagridview()
        Me.TableLayoutPanelbotones = New System.Windows.Forms.TableLayoutPanel()
        Me.Nuevoexpediente_boton = New System.Windows.Forms.Button()
        Me.modificar_boton = New System.Windows.Forms.Button()
        Me.Botoneliminar = New System.Windows.Forms.Button()
        Me.Paneldatosexpedientes = New System.Windows.Forms.Panel()
        Me.BotonCUITS = New System.Windows.Forms.Button()
        Me.Expediente_principal_label = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Ordencargo_seleccionado_label = New System.Windows.Forms.Label()
        Me.Ordenpago_seleccionado_label = New System.Windows.Forms.Label()
        Me.Expediente_seleccionado_label = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Detalleexpediente_textbox = New System.Windows.Forms.TextBox()
        Me.Montodelexpediente_textbox = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.SplitExpedientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitExpedientes.Panel1.SuspendLayout()
        Me.SplitExpedientes.Panel2.SuspendLayout()
        Me.SplitExpedientes.SuspendLayout()
        CType(Me.Listado_, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Datos_expediente_Tabcontrol.SuspendLayout()
        Me.Datosgenerales_tabitem.SuspendLayout()
        Me.Pedidofondo_tabitem.SuspendLayout()
        CType(Me.Datospedidofondo_datagrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Expedientesrelacionados_tabitem.SuspendLayout()
        CType(Me.Datosexpedientesasociados_datagrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanelbotones.SuspendLayout()
        Me.Paneldatosexpedientes.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'SplitExpedientes
        '
        Me.SplitExpedientes.BackColor = System.Drawing.Color.DimGray
        Me.SplitExpedientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitExpedientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitExpedientes.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitExpedientes.Location = New System.Drawing.Point(0, 0)
        Me.SplitExpedientes.Name = "SplitExpedientes"
        '
        'SplitExpedientes.Panel1
        '
        Me.SplitExpedientes.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.SplitExpedientes.Panel1.Controls.Add(Me.Listado_)
        Me.SplitExpedientes.Panel1.Controls.Add(Me.Busqueda_textbox)
        Me.SplitExpedientes.Panel1.Controls.Add(Me.Refresh_boton)
        Me.SplitExpedientes.Panel1.Controls.Add(Me.Label1)
        Me.SplitExpedientes.Panel1MinSize = 374
        '
        'SplitExpedientes.Panel2
        '
        Me.SplitExpedientes.Panel2.BackColor = System.Drawing.Color.White
        Me.SplitExpedientes.Panel2.Controls.Add(Me.Datos_expediente_Tabcontrol)
        Me.SplitExpedientes.Panel2.Controls.Add(Me.TableLayoutPanelbotones)
        Me.SplitExpedientes.Panel2.Controls.Add(Me.Paneldatosexpedientes)
        Me.SplitExpedientes.Size = New System.Drawing.Size(790, 609)
        Me.SplitExpedientes.SplitterDistance = 440
        Me.SplitExpedientes.TabIndex = 0
        '
        'Listado_
        '
        Me.Listado_.AllowUserToAddRows = False
        Me.Listado_.AllowUserToDeleteRows = False
        Me.Listado_.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Listado_.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Listado_.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Listado_.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Listado_.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Listado_.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Listado_.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(134, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(134, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Listado_.DefaultCellStyle = DataGridViewCellStyle3
        Me.Listado_.GridColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Listado_.Location = New System.Drawing.Point(0, 26)
        Me.Listado_.Margin = New System.Windows.Forms.Padding(0)
        Me.Listado_.Name = "Listado_"
        Me.Listado_.ReadOnly = True
        Me.Listado_.RowHeadersVisible = False
        Me.Listado_.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Listado_.Size = New System.Drawing.Size(436, 579)
        Me.Listado_.TabIndex = 3
        '
        'Busqueda_textbox
        '
        Me.Busqueda_textbox.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Busqueda_textbox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Busqueda_textbox.ForeColor = System.Drawing.Color.Black
        Me.Busqueda_textbox.Location = New System.Drawing.Point(78, 3)
        Me.Busqueda_textbox.Name = "Busqueda_textbox"
        Me.Busqueda_textbox.Size = New System.Drawing.Size(189, 23)
        Me.Busqueda_textbox.TabIndex = 19
        Me.Busqueda_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Refresh_boton
        '
        Me.Refresh_boton.BackColor = System.Drawing.Color.Green
        Me.Refresh_boton.BackgroundImage = CType(resources.GetObject("Refresh_boton.BackgroundImage"), System.Drawing.Image)
        Me.Refresh_boton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Refresh_boton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Refresh_boton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Refresh_boton.ForeColor = System.Drawing.Color.Black
        Me.Refresh_boton.Location = New System.Drawing.Point(270, 0)
        Me.Refresh_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Refresh_boton.Name = "Refresh_boton"
        Me.Refresh_boton.Size = New System.Drawing.Size(32, 26)
        Me.Refresh_boton.TabIndex = 23
        Me.Refresh_boton.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Refresh_boton.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.Location = New System.Drawing.Point(3, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 22)
        Me.Label1.TabIndex = 116
        Me.Label1.Text = "Buscar"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Datos_expediente_Tabcontrol
        '
        Me.Datos_expediente_Tabcontrol.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Datos_expediente_Tabcontrol.Controls.Add(Me.Datosgenerales_tabitem)
        Me.Datos_expediente_Tabcontrol.Controls.Add(Me.Pedidofondo_tabitem)
        Me.Datos_expediente_Tabcontrol.Controls.Add(Me.Expedientesrelacionados_tabitem)
        Me.Datos_expediente_Tabcontrol.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Datos_expediente_Tabcontrol.Location = New System.Drawing.Point(3, 283)
        Me.Datos_expediente_Tabcontrol.Margin = New System.Windows.Forms.Padding(0)
        Me.Datos_expediente_Tabcontrol.Name = "Datos_expediente_Tabcontrol"
        Me.Datos_expediente_Tabcontrol.Padding = New System.Drawing.Point(0, 0)
        Me.Datos_expediente_Tabcontrol.SelectedIndex = 0
        Me.Datos_expediente_Tabcontrol.Size = New System.Drawing.Size(333, 324)
        Me.Datos_expediente_Tabcontrol.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight
        Me.Datos_expediente_Tabcontrol.TabIndex = 0
        Me.Datos_expediente_Tabcontrol.Visible = False
        '
        'Datosgenerales_tabitem
        '
        Me.Datosgenerales_tabitem.Controls.Add(Me.Detalle_listado_expedientes)
        Me.Datosgenerales_tabitem.Location = New System.Drawing.Point(4, 22)
        Me.Datosgenerales_tabitem.Name = "Datosgenerales_tabitem"
        Me.Datosgenerales_tabitem.Padding = New System.Windows.Forms.Padding(3)
        Me.Datosgenerales_tabitem.Size = New System.Drawing.Size(325, 298)
        Me.Datosgenerales_tabitem.TabIndex = 0
        Me.Datosgenerales_tabitem.Text = "Datos Generales"
        Me.Datosgenerales_tabitem.UseVisualStyleBackColor = True
        '
        'Detalle_listado_expedientes
        '
        Me.Detalle_listado_expedientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Detalle_listado_expedientes.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridHeaderRowSheet
        Me.Detalle_listado_expedientes.HorizontalScrollbar = True
        Me.Detalle_listado_expedientes.ItemStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.NavigatorMini
        Me.Detalle_listado_expedientes.Location = New System.Drawing.Point(4, 7)
        Me.Detalle_listado_expedientes.Name = "Detalle_listado_expedientes"
        Me.Detalle_listado_expedientes.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue
        Me.Detalle_listado_expedientes.Size = New System.Drawing.Size(315, 285)
        Me.Detalle_listado_expedientes.TabIndex = 0
        '
        'Pedidofondo_tabitem
        '
        Me.Pedidofondo_tabitem.Controls.Add(Me.Labeltotalpedidofondo)
        Me.Pedidofondo_tabitem.Controls.Add(Me.Datospedidofondo_fecha)
        Me.Pedidofondo_tabitem.Controls.Add(Me.Datospedidofondo_label)
        Me.Pedidofondo_tabitem.Controls.Add(Me.Datosexpediente_pedidofondolabel)
        Me.Pedidofondo_tabitem.Controls.Add(Me.Datospedidofondo_datagrid)
        Me.Pedidofondo_tabitem.Location = New System.Drawing.Point(4, 22)
        Me.Pedidofondo_tabitem.Name = "Pedidofondo_tabitem"
        Me.Pedidofondo_tabitem.Padding = New System.Windows.Forms.Padding(3)
        Me.Pedidofondo_tabitem.Size = New System.Drawing.Size(325, 298)
        Me.Pedidofondo_tabitem.TabIndex = 1
        Me.Pedidofondo_tabitem.Text = "Pedidos de Fondos"
        Me.Pedidofondo_tabitem.UseVisualStyleBackColor = True
        '
        'Labeltotalpedidofondo
        '
        Me.Labeltotalpedidofondo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Labeltotalpedidofondo.BackColor = System.Drawing.Color.Transparent
        Me.Labeltotalpedidofondo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labeltotalpedidofondo.Location = New System.Drawing.Point(6, 38)
        Me.Labeltotalpedidofondo.Name = "Labeltotalpedidofondo"
        Me.Labeltotalpedidofondo.Size = New System.Drawing.Size(313, 21)
        Me.Labeltotalpedidofondo.TabIndex = 9
        Me.Labeltotalpedidofondo.Text = "_"
        '
        'Datospedidofondo_fecha
        '
        Me.Datospedidofondo_fecha.Location = New System.Drawing.Point(175, 14)
        Me.Datospedidofondo_fecha.Name = "Datospedidofondo_fecha"
        Me.Datospedidofondo_fecha.Size = New System.Drawing.Size(147, 21)
        Me.Datospedidofondo_fecha.TabIndex = 8
        '
        'Datospedidofondo_label
        '
        Me.Datospedidofondo_label.BackColor = System.Drawing.Color.Transparent
        Me.Datospedidofondo_label.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Datospedidofondo_label.Location = New System.Drawing.Point(6, 22)
        Me.Datospedidofondo_label.Name = "Datospedidofondo_label"
        Me.Datospedidofondo_label.Size = New System.Drawing.Size(69, 13)
        Me.Datospedidofondo_label.TabIndex = 7
        Me.Datospedidofondo_label.Text = "_"
        '
        'Datosexpediente_pedidofondolabel
        '
        Me.Datosexpediente_pedidofondolabel.BackColor = System.Drawing.Color.Transparent
        Me.Datosexpediente_pedidofondolabel.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Datosexpediente_pedidofondolabel.Location = New System.Drawing.Point(6, 3)
        Me.Datosexpediente_pedidofondolabel.Name = "Datosexpediente_pedidofondolabel"
        Me.Datosexpediente_pedidofondolabel.Size = New System.Drawing.Size(69, 13)
        Me.Datosexpediente_pedidofondolabel.TabIndex = 6
        Me.Datosexpediente_pedidofondolabel.Text = "_"
        '
        'Datospedidofondo_datagrid
        '
        Me.Datospedidofondo_datagrid.AllowUserToAddRows = False
        Me.Datospedidofondo_datagrid.AllowUserToDeleteRows = False
        Me.Datospedidofondo_datagrid.AllowUserToOrderColumns = True
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Datospedidofondo_datagrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.Datospedidofondo_datagrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Datospedidofondo_datagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.Datospedidofondo_datagrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Datospedidofondo_datagrid.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datospedidofondo_datagrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.Datospedidofondo_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datospedidofondo_datagrid.DefaultCellStyle = DataGridViewCellStyle6
        Me.Datospedidofondo_datagrid.GridColor = System.Drawing.Color.Black
        Me.Datospedidofondo_datagrid.Location = New System.Drawing.Point(2, 62)
        Me.Datospedidofondo_datagrid.Name = "Datospedidofondo_datagrid"
        Me.Datospedidofondo_datagrid.ReadOnly = True
        Me.Datospedidofondo_datagrid.RowHeadersVisible = False
        Me.Datospedidofondo_datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Datospedidofondo_datagrid.Size = New System.Drawing.Size(317, 197)
        Me.Datospedidofondo_datagrid.TabIndex = 5
        '
        'Expedientesrelacionados_tabitem
        '
        Me.Expedientesrelacionados_tabitem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Expedientesrelacionados_tabitem.Controls.Add(Me.Datosexpedientesasociados_datagrid)
        Me.Expedientesrelacionados_tabitem.Location = New System.Drawing.Point(4, 22)
        Me.Expedientesrelacionados_tabitem.Name = "Expedientesrelacionados_tabitem"
        Me.Expedientesrelacionados_tabitem.Size = New System.Drawing.Size(325, 298)
        Me.Expedientesrelacionados_tabitem.TabIndex = 2
        Me.Expedientesrelacionados_tabitem.Text = "Expedientes Relacionados"
        Me.Expedientesrelacionados_tabitem.UseVisualStyleBackColor = True
        '
        'Datosexpedientesasociados_datagrid
        '
        Me.Datosexpedientesasociados_datagrid.AllowUserToAddRows = False
        Me.Datosexpedientesasociados_datagrid.AllowUserToDeleteRows = False
        Me.Datosexpedientesasociados_datagrid.AllowUserToOrderColumns = True
        DataGridViewCellStyle7.NullValue = Nothing
        Me.Datosexpedientesasociados_datagrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.Datosexpedientesasociados_datagrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Datosexpedientesasociados_datagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.Datosexpedientesasociados_datagrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Datosexpedientesasociados_datagrid.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datosexpedientesasociados_datagrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.Datosexpedientesasociados_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datosexpedientesasociados_datagrid.DefaultCellStyle = DataGridViewCellStyle9
        Me.Datosexpedientesasociados_datagrid.Location = New System.Drawing.Point(3, 3)
        Me.Datosexpedientesasociados_datagrid.MultiSelect = False
        Me.Datosexpedientesasociados_datagrid.Name = "Datosexpedientesasociados_datagrid"
        Me.Datosexpedientesasociados_datagrid.ReadOnly = True
        Me.Datosexpedientesasociados_datagrid.RowHeadersVisible = False
        Me.Datosexpedientesasociados_datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Datosexpedientesasociados_datagrid.Size = New System.Drawing.Size(315, 287)
        Me.Datosexpedientesasociados_datagrid.TabIndex = 4
        '
        'TableLayoutPanelbotones
        '
        Me.TableLayoutPanelbotones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanelbotones.ColumnCount = 3
        Me.TableLayoutPanelbotones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanelbotones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanelbotones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanelbotones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanelbotones.Controls.Add(Me.Nuevoexpediente_boton, 0, 0)
        Me.TableLayoutPanelbotones.Controls.Add(Me.modificar_boton, 1, 0)
        Me.TableLayoutPanelbotones.Controls.Add(Me.Botoneliminar, 2, 0)
        Me.TableLayoutPanelbotones.Location = New System.Drawing.Point(3, 4)
        Me.TableLayoutPanelbotones.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanelbotones.Name = "TableLayoutPanelbotones"
        Me.TableLayoutPanelbotones.RowCount = 1
        Me.TableLayoutPanelbotones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelbotones.Size = New System.Drawing.Size(336, 44)
        Me.TableLayoutPanelbotones.TabIndex = 22
        '
        'Nuevoexpediente_boton
        '
        Me.Nuevoexpediente_boton.BackColor = System.Drawing.Color.LightCyan
        Me.Nuevoexpediente_boton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Nuevoexpediente_boton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Nuevoexpediente_boton.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nuevoexpediente_boton.Image = CType(resources.GetObject("Nuevoexpediente_boton.Image"), System.Drawing.Image)
        Me.Nuevoexpediente_boton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Nuevoexpediente_boton.Location = New System.Drawing.Point(0, 0)
        Me.Nuevoexpediente_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Nuevoexpediente_boton.Name = "Nuevoexpediente_boton"
        Me.Nuevoexpediente_boton.Size = New System.Drawing.Size(112, 44)
        Me.Nuevoexpediente_boton.TabIndex = 14
        Me.Nuevoexpediente_boton.Text = "Nuevo expediente"
        Me.Nuevoexpediente_boton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Nuevoexpediente_boton.UseVisualStyleBackColor = False
        '
        'modificar_boton
        '
        Me.modificar_boton.BackColor = System.Drawing.Color.LightYellow
        Me.modificar_boton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.modificar_boton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.modificar_boton.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.modificar_boton.Image = CType(resources.GetObject("modificar_boton.Image"), System.Drawing.Image)
        Me.modificar_boton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.modificar_boton.Location = New System.Drawing.Point(112, 0)
        Me.modificar_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.modificar_boton.Name = "modificar_boton"
        Me.modificar_boton.Size = New System.Drawing.Size(112, 44)
        Me.modificar_boton.TabIndex = 11
        Me.modificar_boton.Text = "Modificar expediente"
        Me.modificar_boton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.modificar_boton.UseVisualStyleBackColor = False
        '
        'Botoneliminar
        '
        Me.Botoneliminar.BackColor = System.Drawing.Color.MistyRose
        Me.Botoneliminar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Botoneliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Botoneliminar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Botoneliminar.Image = CType(resources.GetObject("Botoneliminar.Image"), System.Drawing.Image)
        Me.Botoneliminar.Location = New System.Drawing.Point(224, 0)
        Me.Botoneliminar.Margin = New System.Windows.Forms.Padding(0)
        Me.Botoneliminar.Name = "Botoneliminar"
        Me.Botoneliminar.Size = New System.Drawing.Size(112, 44)
        Me.Botoneliminar.TabIndex = 13
        Me.Botoneliminar.Text = "BORRAR"
        Me.Botoneliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Botoneliminar.UseVisualStyleBackColor = False
        '
        'Paneldatosexpedientes
        '
        Me.Paneldatosexpedientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Paneldatosexpedientes.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.Paneldatosexpedientes.Controls.Add(Me.BotonCUITS)
        Me.Paneldatosexpedientes.Controls.Add(Me.Expediente_principal_label)
        Me.Paneldatosexpedientes.Controls.Add(Me.Label15)
        Me.Paneldatosexpedientes.Controls.Add(Me.Label14)
        Me.Paneldatosexpedientes.Controls.Add(Me.Ordencargo_seleccionado_label)
        Me.Paneldatosexpedientes.Controls.Add(Me.Ordenpago_seleccionado_label)
        Me.Paneldatosexpedientes.Controls.Add(Me.Expediente_seleccionado_label)
        Me.Paneldatosexpedientes.Controls.Add(Me.Label2)
        Me.Paneldatosexpedientes.Controls.Add(Me.Detalleexpediente_textbox)
        Me.Paneldatosexpedientes.Controls.Add(Me.Montodelexpediente_textbox)
        Me.Paneldatosexpedientes.Controls.Add(Me.Label9)
        Me.Paneldatosexpedientes.Controls.Add(Me.Label3)
        Me.Paneldatosexpedientes.Controls.Add(Me.Label6)
        Me.Paneldatosexpedientes.Location = New System.Drawing.Point(3, 49)
        Me.Paneldatosexpedientes.Name = "Paneldatosexpedientes"
        Me.Paneldatosexpedientes.Size = New System.Drawing.Size(336, 231)
        Me.Paneldatosexpedientes.TabIndex = 20
        Me.Paneldatosexpedientes.Visible = False
        '
        'BotonCUITS
        '
        Me.BotonCUITS.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BotonCUITS.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BotonCUITS.BackgroundImage = Global.SICyF.My.Resources.Resources.add
        Me.BotonCUITS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BotonCUITS.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BotonCUITS.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BotonCUITS.ForeColor = System.Drawing.Color.Black
        Me.BotonCUITS.Location = New System.Drawing.Point(249, 177)
        Me.BotonCUITS.Margin = New System.Windows.Forms.Padding(0)
        Me.BotonCUITS.Name = "BotonCUITS"
        Me.BotonCUITS.Size = New System.Drawing.Size(84, 51)
        Me.BotonCUITS.TabIndex = 22
        Me.BotonCUITS.Text = "Asociar Proveedores"
        Me.BotonCUITS.UseVisualStyleBackColor = False
        '
        'Expediente_principal_label
        '
        Me.Expediente_principal_label.AutoSize = True
        Me.Expediente_principal_label.ForeColor = System.Drawing.Color.Black
        Me.Expediente_principal_label.Location = New System.Drawing.Point(4, 172)
        Me.Expediente_principal_label.Margin = New System.Windows.Forms.Padding(0)
        Me.Expediente_principal_label.Name = "Expediente_principal_label"
        Me.Expediente_principal_label.Size = New System.Drawing.Size(12, 13)
        Me.Expediente_principal_label.TabIndex = 26
        Me.Expediente_principal_label.Text = "_"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(5, 51)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(117, 13)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "Fecha del Expediente"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(5, 208)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(73, 20)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "Monto Exp."
        '
        'Ordencargo_seleccionado_label
        '
        Me.Ordencargo_seleccionado_label.AutoSize = True
        Me.Ordencargo_seleccionado_label.BackColor = System.Drawing.Color.Transparent
        Me.Ordencargo_seleccionado_label.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Ordencargo_seleccionado_label.Location = New System.Drawing.Point(214, 147)
        Me.Ordencargo_seleccionado_label.Name = "Ordencargo_seleccionado_label"
        Me.Ordencargo_seleccionado_label.Size = New System.Drawing.Size(19, 20)
        Me.Ordencargo_seleccionado_label.TabIndex = 20
        Me.Ordencargo_seleccionado_label.Text = "- "
        '
        'Ordenpago_seleccionado_label
        '
        Me.Ordenpago_seleccionado_label.AutoSize = True
        Me.Ordenpago_seleccionado_label.BackColor = System.Drawing.Color.Transparent
        Me.Ordenpago_seleccionado_label.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Ordenpago_seleccionado_label.Location = New System.Drawing.Point(7, 149)
        Me.Ordenpago_seleccionado_label.Name = "Ordenpago_seleccionado_label"
        Me.Ordenpago_seleccionado_label.Size = New System.Drawing.Size(19, 20)
        Me.Ordenpago_seleccionado_label.TabIndex = 19
        Me.Ordenpago_seleccionado_label.Text = "- "
        '
        'Expediente_seleccionado_label
        '
        Me.Expediente_seleccionado_label.AutoSize = True
        Me.Expediente_seleccionado_label.BackColor = System.Drawing.Color.Transparent
        Me.Expediente_seleccionado_label.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Expediente_seleccionado_label.Location = New System.Drawing.Point(75, 19)
        Me.Expediente_seleccionado_label.Name = "Expediente_seleccionado_label"
        Me.Expediente_seleccionado_label.Size = New System.Drawing.Size(0, 32)
        Me.Expediente_seleccionado_label.TabIndex = 5
        Me.Expediente_seleccionado_label.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(140, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Expediente Nº"
        '
        'Detalleexpediente_textbox
        '
        Me.Detalleexpediente_textbox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Detalleexpediente_textbox.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.Detalleexpediente_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Detalleexpediente_textbox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Detalleexpediente_textbox.ForeColor = System.Drawing.Color.Black
        Me.Detalleexpediente_textbox.Location = New System.Drawing.Point(4, 85)
        Me.Detalleexpediente_textbox.Multiline = True
        Me.Detalleexpediente_textbox.Name = "Detalleexpediente_textbox"
        Me.Detalleexpediente_textbox.ReadOnly = True
        Me.Detalleexpediente_textbox.Size = New System.Drawing.Size(329, 49)
        Me.Detalleexpediente_textbox.TabIndex = 18
        Me.Detalleexpediente_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Montodelexpediente_textbox
        '
        Me.Montodelexpediente_textbox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Montodelexpediente_textbox.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.Montodelexpediente_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Montodelexpediente_textbox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Montodelexpediente_textbox.Location = New System.Drawing.Point(81, 204)
        Me.Montodelexpediente_textbox.Multiline = True
        Me.Montodelexpediente_textbox.Name = "Montodelexpediente_textbox"
        Me.Montodelexpediente_textbox.ReadOnly = True
        Me.Montodelexpediente_textbox.Size = New System.Drawing.Size(165, 24)
        Me.Montodelexpediente_textbox.TabIndex = 23
        Me.Montodelexpediente_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(5, 71)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 17)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Descripción"
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(8, 133)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Orden de PAGO N"
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(215, 134)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Orden de CARGO N"
        '
        'Tesoreria_Expedientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(790, 609)
        Me.Controls.Add(Me.SplitExpedientes)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Tesoreria_Expedientes"
        Me.Text = "Tesoreria_Expedientes"
        Me.SplitExpedientes.Panel1.ResumeLayout(False)
        Me.SplitExpedientes.Panel1.PerformLayout()
        Me.SplitExpedientes.Panel2.ResumeLayout(False)
        CType(Me.SplitExpedientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitExpedientes.ResumeLayout(False)
        CType(Me.Listado_, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Datos_expediente_Tabcontrol.ResumeLayout(False)
        Me.Datosgenerales_tabitem.ResumeLayout(False)
        Me.Pedidofondo_tabitem.ResumeLayout(False)
        CType(Me.Datospedidofondo_datagrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Expedientesrelacionados_tabitem.ResumeLayout(False)
        CType(Me.Datosexpedientesasociados_datagrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanelbotones.ResumeLayout(False)
        Me.Paneldatosexpedientes.ResumeLayout(False)
        Me.Paneldatosexpedientes.PerformLayout()
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents SplitExpedientes As SplitContainer
    Friend WithEvents Datos_expediente_Tabcontrol As TabControl
    Friend WithEvents Datosgenerales_tabitem As TabPage
    Friend WithEvents Pedidofondo_tabitem As TabPage
    Friend WithEvents Listado_ As SICyF.Flicker_Datagridview
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Detalleexpediente_textbox As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Paneldatosexpedientes As Panel
    Friend WithEvents Expedientesrelacionados_tabitem As TabPage
    Friend WithEvents Busqueda_textbox As TextBox
    Friend WithEvents BotonCUITS As Button
    Friend WithEvents Datosexpedientesasociados_datagrid As SICyF.Flicker_Datagridview
    Friend WithEvents Datospedidofondo_label As Label
    Friend WithEvents Datosexpediente_pedidofondolabel As Label
    Friend WithEvents Datospedidofondo_fecha As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents Label14 As Label
    Friend WithEvents Montodelexpediente_textbox As TextBox
    Friend WithEvents TableLayoutPanelbotones As TableLayoutPanel
    Friend WithEvents Botoneliminar As Button
    Friend WithEvents modificar_boton As Button
    Friend WithEvents Nuevoexpediente_boton As Button
    Friend WithEvents Refresh_boton As Button
    Friend WithEvents Datospedidofondo_datagrid As SICyF.Flicker_Datagridview
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Detalle_listado_expedientes As ComponentFactory.Krypton.Toolkit.KryptonListBox
    Friend WithEvents Expediente_seleccionado_label As Label
    Friend WithEvents Ordencargo_seleccionado_label As Label
    Friend WithEvents Ordenpago_seleccionado_label As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Expediente_principal_label As Label
    Friend WithEvents Labeltotalpedidofondo As Label
    Friend WithEvents Label1 As Label
End Class
