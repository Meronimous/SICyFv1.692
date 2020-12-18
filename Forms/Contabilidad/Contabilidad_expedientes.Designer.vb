<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Contabilidad_expedientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_expedientes))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitExpedientes = New System.Windows.Forms.SplitContainer()
        Me.Datos_datagrid = New SICyF.Flicker_Datagridview()
        Me.Busqueda_textbox = New System.Windows.Forms.TextBox()
        Me.Refresh_boton = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TableLayoutPanelbotones = New System.Windows.Forms.TableLayoutPanel()
        Me.Nuevoexpediente_boton = New System.Windows.Forms.Button()
        Me.modificar_boton = New System.Windows.Forms.Button()
        Me.Botoneliminar = New System.Windows.Forms.Button()
        Me.Paneldatosexpedientes = New System.Windows.Forms.Panel()
        Me.ActasyordenesTablelayout = New SICyF.Flicker_Tablelayout(Me.components)
        Me.PaneL_sinFlicker3 = New SICyF.PANEL_sinFlicker()
        Me.Selecciondetallestab = New SICyF.FlickerTabcontrol()
        Me.Ordenesprovision = New System.Windows.Forms.TabPage()
        Me.Datos_ordenprovision = New SICyF.Flicker_Datagridview()
        Me.Expedienteshijos = New System.Windows.Forms.TabPage()
        Me.PaneL_sinFlicker2 = New SICyF.PANEL_sinFlicker()
        Me.TableLayoutOP = New System.Windows.Forms.TableLayoutPanel()
        Me.IMPRIMIR_BOTON = New System.Windows.Forms.Button()
        Me.Nueva_ordenpago_boton = New System.Windows.Forms.Button()
        Me.Modificar_ordenpago_boton = New System.Windows.Forms.Button()
        Me.Borrar_ordenpago_boton = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Datos_ordenpago = New SICyF.Flicker_Datagridview()
        Me.Busqueda_OP = New System.Windows.Forms.TextBox()
        Me.Refresh_op = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BotonCUITS = New System.Windows.Forms.Button()
        Me.Expediente_seleccionado_label = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Montodelexpediente_textbox = New System.Windows.Forms.TextBox()
        CType(Me.SplitExpedientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitExpedientes.Panel1.SuspendLayout()
        Me.SplitExpedientes.Panel2.SuspendLayout()
        Me.SplitExpedientes.SuspendLayout()
        CType(Me.Datos_datagrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanelbotones.SuspendLayout()
        Me.Paneldatosexpedientes.SuspendLayout()
        Me.ActasyordenesTablelayout.SuspendLayout()
        Me.PaneL_sinFlicker3.SuspendLayout()
        Me.Selecciondetallestab.SuspendLayout()
        Me.Ordenesprovision.SuspendLayout()
        CType(Me.Datos_ordenprovision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PaneL_sinFlicker2.SuspendLayout()
        Me.TableLayoutOP.SuspendLayout()
        CType(Me.Datos_ordenpago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.SplitExpedientes.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(121, Byte), Integer), CType(CType(111, Byte), Integer))
        Me.SplitExpedientes.Panel1.Controls.Add(Me.Datos_datagrid)
        Me.SplitExpedientes.Panel1.Controls.Add(Me.Busqueda_textbox)
        Me.SplitExpedientes.Panel1.Controls.Add(Me.Refresh_boton)
        Me.SplitExpedientes.Panel1.Controls.Add(Me.Label10)
        Me.SplitExpedientes.Panel1MinSize = 374
        '
        'SplitExpedientes.Panel2
        '
        Me.SplitExpedientes.Panel2.BackColor = System.Drawing.Color.White
        Me.SplitExpedientes.Panel2.Controls.Add(Me.TableLayoutPanelbotones)
        Me.SplitExpedientes.Panel2.Controls.Add(Me.Paneldatosexpedientes)
        Me.SplitExpedientes.Size = New System.Drawing.Size(981, 573)
        Me.SplitExpedientes.SplitterDistance = 454
        Me.SplitExpedientes.TabIndex = 1
        '
        'Datos_datagrid
        '
        Me.Datos_datagrid.AllowUserToAddRows = False
        Me.Datos_datagrid.AllowUserToDeleteRows = False
        Me.Datos_datagrid.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Datos_datagrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Datos_datagrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Datos_datagrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Datos_datagrid.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_datagrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(198, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_datagrid.DefaultCellStyle = DataGridViewCellStyle3
        Me.Datos_datagrid.Location = New System.Drawing.Point(3, 49)
        Me.Datos_datagrid.MultiSelect = False
        Me.Datos_datagrid.Name = "Datos_datagrid"
        Me.Datos_datagrid.ReadOnly = True
        Me.Datos_datagrid.RowHeadersVisible = False
        Me.Datos_datagrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Datos_datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Datos_datagrid.Size = New System.Drawing.Size(444, 517)
        Me.Datos_datagrid.TabIndex = 3
        Me.Datos_datagrid.VirtualMode = True
        '
        'Busqueda_textbox
        '
        Me.Busqueda_textbox.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.Busqueda_textbox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Busqueda_textbox.ForeColor = System.Drawing.Color.Black
        Me.Busqueda_textbox.Location = New System.Drawing.Point(10, 20)
        Me.Busqueda_textbox.Name = "Busqueda_textbox"
        Me.Busqueda_textbox.Size = New System.Drawing.Size(263, 23)
        Me.Busqueda_textbox.TabIndex = 19
        Me.Busqueda_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Refresh_boton
        '
        Me.Refresh_boton.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Refresh_boton.BackgroundImage = CType(resources.GetObject("Refresh_boton.BackgroundImage"), System.Drawing.Image)
        Me.Refresh_boton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Refresh_boton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Refresh_boton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Refresh_boton.ForeColor = System.Drawing.Color.Black
        Me.Refresh_boton.Location = New System.Drawing.Point(276, 17)
        Me.Refresh_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Refresh_boton.Name = "Refresh_boton"
        Me.Refresh_boton.Size = New System.Drawing.Size(32, 26)
        Me.Refresh_boton.TabIndex = 23
        Me.Refresh_boton.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Refresh_boton.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(37, 4)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(148, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Ingrese aquí su BUSQUEDA"
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
        Me.TableLayoutPanelbotones.Size = New System.Drawing.Size(519, 44)
        Me.TableLayoutPanelbotones.TabIndex = 22
        '
        'Nuevoexpediente_boton
        '
        Me.Nuevoexpediente_boton.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Nuevoexpediente_boton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Nuevoexpediente_boton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Nuevoexpediente_boton.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nuevoexpediente_boton.Image = CType(resources.GetObject("Nuevoexpediente_boton.Image"), System.Drawing.Image)
        Me.Nuevoexpediente_boton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Nuevoexpediente_boton.Location = New System.Drawing.Point(0, 0)
        Me.Nuevoexpediente_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Nuevoexpediente_boton.Name = "Nuevoexpediente_boton"
        Me.Nuevoexpediente_boton.Size = New System.Drawing.Size(173, 44)
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
        Me.modificar_boton.Location = New System.Drawing.Point(173, 0)
        Me.modificar_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.modificar_boton.Name = "modificar_boton"
        Me.modificar_boton.Size = New System.Drawing.Size(173, 44)
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
        Me.Botoneliminar.Location = New System.Drawing.Point(346, 0)
        Me.Botoneliminar.Margin = New System.Windows.Forms.Padding(0)
        Me.Botoneliminar.Name = "Botoneliminar"
        Me.Botoneliminar.Size = New System.Drawing.Size(173, 44)
        Me.Botoneliminar.TabIndex = 13
        Me.Botoneliminar.Text = "Borrar Expediente"
        Me.Botoneliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Botoneliminar.UseVisualStyleBackColor = False
        '
        'Paneldatosexpedientes
        '
        Me.Paneldatosexpedientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Paneldatosexpedientes.BackColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Paneldatosexpedientes.Controls.Add(Me.ActasyordenesTablelayout)
        Me.Paneldatosexpedientes.Controls.Add(Me.Busqueda_OP)
        Me.Paneldatosexpedientes.Controls.Add(Me.Refresh_op)
        Me.Paneldatosexpedientes.Controls.Add(Me.Label1)
        Me.Paneldatosexpedientes.Controls.Add(Me.BotonCUITS)
        Me.Paneldatosexpedientes.Controls.Add(Me.Expediente_seleccionado_label)
        Me.Paneldatosexpedientes.Controls.Add(Me.Label2)
        Me.Paneldatosexpedientes.Controls.Add(Me.Montodelexpediente_textbox)
        Me.Paneldatosexpedientes.Location = New System.Drawing.Point(3, 49)
        Me.Paneldatosexpedientes.Name = "Paneldatosexpedientes"
        Me.Paneldatosexpedientes.Size = New System.Drawing.Size(519, 517)
        Me.Paneldatosexpedientes.TabIndex = 20
        Me.Paneldatosexpedientes.Visible = False
        '
        'ActasyordenesTablelayout
        '
        Me.ActasyordenesTablelayout.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ActasyordenesTablelayout.ColumnCount = 1
        Me.ActasyordenesTablelayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ActasyordenesTablelayout.Controls.Add(Me.PaneL_sinFlicker3, 0, 1)
        Me.ActasyordenesTablelayout.Controls.Add(Me.PaneL_sinFlicker2, 0, 0)
        Me.ActasyordenesTablelayout.Location = New System.Drawing.Point(3, 31)
        Me.ActasyordenesTablelayout.Name = "ActasyordenesTablelayout"
        Me.ActasyordenesTablelayout.RowCount = 2
        Me.ActasyordenesTablelayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ActasyordenesTablelayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ActasyordenesTablelayout.Size = New System.Drawing.Size(510, 483)
        Me.ActasyordenesTablelayout.TabIndex = 34
        '
        'PaneL_sinFlicker3
        '
        Me.PaneL_sinFlicker3.Controls.Add(Me.Selecciondetallestab)
        Me.PaneL_sinFlicker3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PaneL_sinFlicker3.Location = New System.Drawing.Point(0, 241)
        Me.PaneL_sinFlicker3.Margin = New System.Windows.Forms.Padding(0)
        Me.PaneL_sinFlicker3.Name = "PaneL_sinFlicker3"
        Me.PaneL_sinFlicker3.Size = New System.Drawing.Size(510, 242)
        Me.PaneL_sinFlicker3.TabIndex = 39
        '
        'Selecciondetallestab
        '
        Me.Selecciondetallestab.Controls.Add(Me.Ordenesprovision)
        Me.Selecciondetallestab.Controls.Add(Me.Expedienteshijos)
        Me.Selecciondetallestab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Selecciondetallestab.Location = New System.Drawing.Point(0, 0)
        Me.Selecciondetallestab.Name = "Selecciondetallestab"
        Me.Selecciondetallestab.SelectedIndex = 0
        Me.Selecciondetallestab.Size = New System.Drawing.Size(510, 242)
        Me.Selecciondetallestab.TabIndex = 24
        '
        'Ordenesprovision
        '
        Me.Ordenesprovision.Controls.Add(Me.Datos_ordenprovision)
        Me.Ordenesprovision.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ordenesprovision.Location = New System.Drawing.Point(4, 22)
        Me.Ordenesprovision.Name = "Ordenesprovision"
        Me.Ordenesprovision.Padding = New System.Windows.Forms.Padding(3)
        Me.Ordenesprovision.Size = New System.Drawing.Size(502, 216)
        Me.Ordenesprovision.TabIndex = 0
        Me.Ordenesprovision.Text = "Ordenes de provisión"
        Me.Ordenesprovision.UseVisualStyleBackColor = True
        '
        'Datos_ordenprovision
        '
        Me.Datos_ordenprovision.AllowUserToAddRows = False
        Me.Datos_ordenprovision.AllowUserToOrderColumns = True
        Me.Datos_ordenprovision.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader
        Me.Datos_ordenprovision.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Datos_ordenprovision.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_ordenprovision.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Datos_ordenprovision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(198, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_ordenprovision.DefaultCellStyle = DataGridViewCellStyle5
        Me.Datos_ordenprovision.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Datos_ordenprovision.Location = New System.Drawing.Point(3, 3)
        Me.Datos_ordenprovision.Name = "Datos_ordenprovision"
        Me.Datos_ordenprovision.RowHeadersVisible = False
        Me.Datos_ordenprovision.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Datos_ordenprovision.Size = New System.Drawing.Size(496, 210)
        Me.Datos_ordenprovision.TabIndex = 28
        '
        'Expedienteshijos
        '
        Me.Expedienteshijos.Location = New System.Drawing.Point(4, 22)
        Me.Expedienteshijos.Name = "Expedienteshijos"
        Me.Expedienteshijos.Padding = New System.Windows.Forms.Padding(3)
        Me.Expedienteshijos.Size = New System.Drawing.Size(502, 216)
        Me.Expedienteshijos.TabIndex = 1
        Me.Expedienteshijos.Text = "Expedientes Hijos"
        Me.Expedienteshijos.UseVisualStyleBackColor = True
        '
        'PaneL_sinFlicker2
        '
        Me.PaneL_sinFlicker2.Controls.Add(Me.TableLayoutOP)
        Me.PaneL_sinFlicker2.Controls.Add(Me.Label5)
        Me.PaneL_sinFlicker2.Controls.Add(Me.Datos_ordenpago)
        Me.PaneL_sinFlicker2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PaneL_sinFlicker2.Location = New System.Drawing.Point(0, 0)
        Me.PaneL_sinFlicker2.Margin = New System.Windows.Forms.Padding(0)
        Me.PaneL_sinFlicker2.Name = "PaneL_sinFlicker2"
        Me.PaneL_sinFlicker2.Size = New System.Drawing.Size(510, 241)
        Me.PaneL_sinFlicker2.TabIndex = 36
        '
        'TableLayoutOP
        '
        Me.TableLayoutOP.ColumnCount = 4
        Me.TableLayoutOP.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutOP.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutOP.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutOP.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutOP.Controls.Add(Me.IMPRIMIR_BOTON, 2, 0)
        Me.TableLayoutOP.Controls.Add(Me.Nueva_ordenpago_boton, 0, 0)
        Me.TableLayoutOP.Controls.Add(Me.Modificar_ordenpago_boton, 1, 0)
        Me.TableLayoutOP.Controls.Add(Me.Borrar_ordenpago_boton, 3, 0)
        Me.TableLayoutOP.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutOP.Location = New System.Drawing.Point(0, 197)
        Me.TableLayoutOP.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutOP.Name = "TableLayoutOP"
        Me.TableLayoutOP.RowCount = 1
        Me.TableLayoutOP.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutOP.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.TableLayoutOP.Size = New System.Drawing.Size(510, 44)
        Me.TableLayoutOP.TabIndex = 37
        '
        'IMPRIMIR_BOTON
        '
        Me.IMPRIMIR_BOTON.BackColor = System.Drawing.Color.Snow
        Me.IMPRIMIR_BOTON.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IMPRIMIR_BOTON.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.IMPRIMIR_BOTON.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IMPRIMIR_BOTON.Image = CType(resources.GetObject("IMPRIMIR_BOTON.Image"), System.Drawing.Image)
        Me.IMPRIMIR_BOTON.Location = New System.Drawing.Point(254, 0)
        Me.IMPRIMIR_BOTON.Margin = New System.Windows.Forms.Padding(0)
        Me.IMPRIMIR_BOTON.Name = "IMPRIMIR_BOTON"
        Me.IMPRIMIR_BOTON.Size = New System.Drawing.Size(127, 44)
        Me.IMPRIMIR_BOTON.TabIndex = 17
        Me.IMPRIMIR_BOTON.Text = "IMPRIMIR"
        Me.IMPRIMIR_BOTON.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IMPRIMIR_BOTON.UseVisualStyleBackColor = False
        '
        'Nueva_ordenpago_boton
        '
        Me.Nueva_ordenpago_boton.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Nueva_ordenpago_boton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Nueva_ordenpago_boton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Nueva_ordenpago_boton.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nueva_ordenpago_boton.Image = CType(resources.GetObject("Nueva_ordenpago_boton.Image"), System.Drawing.Image)
        Me.Nueva_ordenpago_boton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Nueva_ordenpago_boton.Location = New System.Drawing.Point(0, 0)
        Me.Nueva_ordenpago_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Nueva_ordenpago_boton.Name = "Nueva_ordenpago_boton"
        Me.Nueva_ordenpago_boton.Size = New System.Drawing.Size(127, 44)
        Me.Nueva_ordenpago_boton.TabIndex = 14
        Me.Nueva_ordenpago_boton.Text = "Nueva Orden de Pago"
        Me.Nueva_ordenpago_boton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Nueva_ordenpago_boton.UseVisualStyleBackColor = False
        '
        'Modificar_ordenpago_boton
        '
        Me.Modificar_ordenpago_boton.BackColor = System.Drawing.Color.Gold
        Me.Modificar_ordenpago_boton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Modificar_ordenpago_boton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Modificar_ordenpago_boton.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Modificar_ordenpago_boton.Image = CType(resources.GetObject("Modificar_ordenpago_boton.Image"), System.Drawing.Image)
        Me.Modificar_ordenpago_boton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Modificar_ordenpago_boton.Location = New System.Drawing.Point(127, 0)
        Me.Modificar_ordenpago_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Modificar_ordenpago_boton.Name = "Modificar_ordenpago_boton"
        Me.Modificar_ordenpago_boton.Size = New System.Drawing.Size(127, 44)
        Me.Modificar_ordenpago_boton.TabIndex = 11
        Me.Modificar_ordenpago_boton.Text = "Modificar Orden de Pago"
        Me.Modificar_ordenpago_boton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Modificar_ordenpago_boton.UseVisualStyleBackColor = False
        '
        'Borrar_ordenpago_boton
        '
        Me.Borrar_ordenpago_boton.BackColor = System.Drawing.Color.LightCoral
        Me.Borrar_ordenpago_boton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Borrar_ordenpago_boton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Borrar_ordenpago_boton.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Borrar_ordenpago_boton.Image = CType(resources.GetObject("Borrar_ordenpago_boton.Image"), System.Drawing.Image)
        Me.Borrar_ordenpago_boton.Location = New System.Drawing.Point(381, 0)
        Me.Borrar_ordenpago_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Borrar_ordenpago_boton.Name = "Borrar_ordenpago_boton"
        Me.Borrar_ordenpago_boton.Size = New System.Drawing.Size(129, 44)
        Me.Borrar_ordenpago_boton.TabIndex = 13
        Me.Borrar_ordenpago_boton.Text = "BORRAR Orden Pago"
        Me.Borrar_ordenpago_boton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Borrar_ordenpago_boton.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(159, 1)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(184, 25)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "ORDENES DE PAGO"
        '
        'Datos_ordenpago
        '
        Me.Datos_ordenpago.AllowUserToAddRows = False
        Me.Datos_ordenpago.AllowUserToDeleteRows = False
        Me.Datos_ordenpago.AllowUserToOrderColumns = True
        Me.Datos_ordenpago.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Datos_ordenpago.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.Datos_ordenpago.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Datos_ordenpago.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_ordenpago.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Datos_ordenpago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(198, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_ordenpago.DefaultCellStyle = DataGridViewCellStyle7
        Me.Datos_ordenpago.Location = New System.Drawing.Point(4, 29)
        Me.Datos_ordenpago.Name = "Datos_ordenpago"
        Me.Datos_ordenpago.ReadOnly = True
        Me.Datos_ordenpago.RowHeadersVisible = False
        Me.Datos_ordenpago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Datos_ordenpago.Size = New System.Drawing.Size(502, 165)
        Me.Datos_ordenpago.TabIndex = 28
        '
        'Busqueda_OP
        '
        Me.Busqueda_OP.BackColor = System.Drawing.Color.White
        Me.Busqueda_OP.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Busqueda_OP.ForeColor = System.Drawing.Color.Black
        Me.Busqueda_OP.Location = New System.Drawing.Point(102, 2)
        Me.Busqueda_OP.Name = "Busqueda_OP"
        Me.Busqueda_OP.Size = New System.Drawing.Size(217, 23)
        Me.Busqueda_OP.TabIndex = 31
        Me.Busqueda_OP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Refresh_op
        '
        Me.Refresh_op.BackColor = System.Drawing.Color.Green
        Me.Refresh_op.BackgroundImage = CType(resources.GetObject("Refresh_op.BackgroundImage"), System.Drawing.Image)
        Me.Refresh_op.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Refresh_op.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Refresh_op.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Refresh_op.ForeColor = System.Drawing.Color.Black
        Me.Refresh_op.Location = New System.Drawing.Point(322, 2)
        Me.Refresh_op.Margin = New System.Windows.Forms.Padding(0)
        Me.Refresh_op.Name = "Refresh_op"
        Me.Refresh_op.Size = New System.Drawing.Size(32, 26)
        Me.Refresh_op.TabIndex = 32
        Me.Refresh_op.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Refresh_op.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(158, 208)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Ordenes de pago"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'BotonCUITS
        '
        Me.BotonCUITS.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BotonCUITS.BackColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.BotonCUITS.BackgroundImage = Global.SICyF.My.Resources.Resources.add
        Me.BotonCUITS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BotonCUITS.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BotonCUITS.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BotonCUITS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.BotonCUITS.Location = New System.Drawing.Point(406, 0)
        Me.BotonCUITS.Margin = New System.Windows.Forms.Padding(0)
        Me.BotonCUITS.Name = "BotonCUITS"
        Me.BotonCUITS.Size = New System.Drawing.Size(110, 28)
        Me.BotonCUITS.TabIndex = 22
        Me.BotonCUITS.Text = "Asociar Proveedores"
        Me.BotonCUITS.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BotonCUITS.UseVisualStyleBackColor = False
        '
        'Expediente_seleccionado_label
        '
        Me.Expediente_seleccionado_label.AutoSize = True
        Me.Expediente_seleccionado_label.BackColor = System.Drawing.Color.Transparent
        Me.Expediente_seleccionado_label.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Expediente_seleccionado_label.Location = New System.Drawing.Point(75, -6)
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
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(14, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Expediente Nº"
        '
        'Montodelexpediente_textbox
        '
        Me.Montodelexpediente_textbox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Montodelexpediente_textbox.BackColor = System.Drawing.Color.MediumAquamarine
        Me.Montodelexpediente_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Montodelexpediente_textbox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Montodelexpediente_textbox.Location = New System.Drawing.Point(77, 93)
        Me.Montodelexpediente_textbox.Multiline = True
        Me.Montodelexpediente_textbox.Name = "Montodelexpediente_textbox"
        Me.Montodelexpediente_textbox.ReadOnly = True
        Me.Montodelexpediente_textbox.Size = New System.Drawing.Size(354, 37)
        Me.Montodelexpediente_textbox.TabIndex = 23
        Me.Montodelexpediente_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Contabilidad_expedientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(981, 573)
        Me.Controls.Add(Me.SplitExpedientes)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Name = "Contabilidad_expedientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Expedientes Contabilidad"
        Me.SplitExpedientes.Panel1.ResumeLayout(False)
        Me.SplitExpedientes.Panel1.PerformLayout()
        Me.SplitExpedientes.Panel2.ResumeLayout(False)
        CType(Me.SplitExpedientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitExpedientes.ResumeLayout(False)
        CType(Me.Datos_datagrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanelbotones.ResumeLayout(False)
        Me.Paneldatosexpedientes.ResumeLayout(False)
        Me.Paneldatosexpedientes.PerformLayout()
        Me.ActasyordenesTablelayout.ResumeLayout(False)
        Me.PaneL_sinFlicker3.ResumeLayout(False)
        Me.Selecciondetallestab.ResumeLayout(False)
        Me.Ordenesprovision.ResumeLayout(False)
        CType(Me.Datos_ordenprovision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PaneL_sinFlicker2.ResumeLayout(False)
        Me.PaneL_sinFlicker2.PerformLayout()
        Me.TableLayoutOP.ResumeLayout(False)
        CType(Me.Datos_ordenpago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents SplitExpedientes As SplitContainer
    Friend WithEvents Datos_datagrid As Flicker_Datagridview
    Friend WithEvents Busqueda_textbox As TextBox
    Friend WithEvents Refresh_boton As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents TableLayoutPanelbotones As TableLayoutPanel
    Friend WithEvents Nuevoexpediente_boton As Button
    Friend WithEvents modificar_boton As Button
    Friend WithEvents Botoneliminar As Button
    Friend WithEvents Paneldatosexpedientes As Panel
    Friend WithEvents BotonCUITS As Button
    Friend WithEvents Expediente_seleccionado_label As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Montodelexpediente_textbox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Busqueda_OP As TextBox
    Friend WithEvents Refresh_op As Button
    Friend WithEvents ActasyordenesTablelayout As Flicker_Tablelayout
    Friend WithEvents PaneL_sinFlicker2 As PANEL_sinFlicker
    Friend WithEvents PaneL_sinFlicker3 As PANEL_sinFlicker
    Friend WithEvents Datos_ordenprovision As Flicker_Datagridview
    Friend WithEvents TableLayoutOP As TableLayoutPanel
    Friend WithEvents Nueva_ordenpago_boton As Button
    Friend WithEvents Modificar_ordenpago_boton As Button
    Friend WithEvents Borrar_ordenpago_boton As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Datos_ordenpago As Flicker_Datagridview
    Friend WithEvents IMPRIMIR_BOTON As Button
    Friend WithEvents Selecciondetallestab As FlickerTabcontrol
    Friend WithEvents Ordenesprovision As TabPage
    Friend WithEvents Expedienteshijos As TabPage
End Class
