<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Suministros_expedientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Suministros_expedientes))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitExpedientes = New System.Windows.Forms.SplitContainer()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Datos_datagrid = New SICyF.Flicker_Datagridview()
        Me.Busqueda_textbox = New System.Windows.Forms.TextBox()
        Me.Refresh_boton = New System.Windows.Forms.Button()
        Me.TableLayoutPanelbotones = New System.Windows.Forms.TableLayoutPanel()
        Me.Nuevoexpediente_boton = New System.Windows.Forms.Button()
        Me.modificar_boton = New System.Windows.Forms.Button()
        Me.Botoneliminar = New System.Windows.Forms.Button()
        Me.Paneldatosexpedientes = New System.Windows.Forms.Panel()
        Me.TableLayoutOP = New System.Windows.Forms.TableLayoutPanel()
        Me.IMPRIMIR_BOTON = New System.Windows.Forms.Button()
        Me.Borrar_ordenprovision_boton = New System.Windows.Forms.Button()
        Me.Nueva_ordenprovision_boton = New System.Windows.Forms.Button()
        Me.Modificar_ordenprovision_boton = New System.Windows.Forms.Button()
        Me.Busqueda_OP = New System.Windows.Forms.TextBox()
        Me.Refresh_op = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Datos_ordenprovision = New SICyF.Flicker_Datagridview()
        Me.BotonCUITS = New System.Windows.Forms.Button()
        Me.Expediente_principal_label = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Expediente_seleccionado_label = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Detalleexpediente_textbox = New System.Windows.Forms.TextBox()
        Me.Montodelexpediente_textbox = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.SplitExpedientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitExpedientes.Panel1.SuspendLayout()
        Me.SplitExpedientes.Panel2.SuspendLayout()
        Me.SplitExpedientes.SuspendLayout()
        CType(Me.Datos_datagrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanelbotones.SuspendLayout()
        Me.Paneldatosexpedientes.SuspendLayout()
        Me.TableLayoutOP.SuspendLayout()
        CType(Me.Datos_ordenprovision, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitExpedientes.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitExpedientes.Panel1.Controls.Add(Me.Label3)
        Me.SplitExpedientes.Panel1.Controls.Add(Me.Datos_datagrid)
        Me.SplitExpedientes.Panel1.Controls.Add(Me.Busqueda_textbox)
        Me.SplitExpedientes.Panel1.Controls.Add(Me.Refresh_boton)
        Me.SplitExpedientes.Panel1MinSize = 374
        '
        'SplitExpedientes.Panel2
        '
        Me.SplitExpedientes.Panel2.BackColor = System.Drawing.Color.White
        Me.SplitExpedientes.Panel2.Controls.Add(Me.TableLayoutPanelbotones)
        Me.SplitExpedientes.Panel2.Controls.Add(Me.Paneldatosexpedientes)
        Me.SplitExpedientes.Size = New System.Drawing.Size(981, 423)
        Me.SplitExpedientes.SplitterDistance = 439
        Me.SplitExpedientes.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Image = CType(resources.GetObject("Label3.Image"), System.Drawing.Image)
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 22)
        Me.Label3.TabIndex = 116
        Me.Label3.Text = "Buscar"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.Datos_datagrid.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_datagrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Datos_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_datagrid.DefaultCellStyle = DataGridViewCellStyle3
        Me.Datos_datagrid.Location = New System.Drawing.Point(3, 28)
        Me.Datos_datagrid.Name = "Datos_datagrid"
        Me.Datos_datagrid.ReadOnly = True
        Me.Datos_datagrid.RowHeadersVisible = False
        Me.Datos_datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Datos_datagrid.Size = New System.Drawing.Size(429, 388)
        Me.Datos_datagrid.TabIndex = 3
        '
        'Busqueda_textbox
        '
        Me.Busqueda_textbox.BackColor = System.Drawing.Color.White
        Me.Busqueda_textbox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Busqueda_textbox.ForeColor = System.Drawing.Color.Black
        Me.Busqueda_textbox.Location = New System.Drawing.Point(78, 2)
        Me.Busqueda_textbox.Name = "Busqueda_textbox"
        Me.Busqueda_textbox.Size = New System.Drawing.Size(185, 23)
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
        Me.Refresh_boton.Location = New System.Drawing.Point(266, -1)
        Me.Refresh_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Refresh_boton.Name = "Refresh_boton"
        Me.Refresh_boton.Size = New System.Drawing.Size(32, 26)
        Me.Refresh_boton.TabIndex = 23
        Me.Refresh_boton.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Refresh_boton.UseVisualStyleBackColor = False
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
        Me.TableLayoutPanelbotones.Size = New System.Drawing.Size(534, 44)
        Me.TableLayoutPanelbotones.TabIndex = 22
        '
        'Nuevoexpediente_boton
        '
        Me.Nuevoexpediente_boton.BackColor = System.Drawing.Color.LightGreen
        Me.Nuevoexpediente_boton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Nuevoexpediente_boton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Nuevoexpediente_boton.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nuevoexpediente_boton.Image = CType(resources.GetObject("Nuevoexpediente_boton.Image"), System.Drawing.Image)
        Me.Nuevoexpediente_boton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Nuevoexpediente_boton.Location = New System.Drawing.Point(0, 0)
        Me.Nuevoexpediente_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Nuevoexpediente_boton.Name = "Nuevoexpediente_boton"
        Me.Nuevoexpediente_boton.Size = New System.Drawing.Size(178, 44)
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
        Me.modificar_boton.Location = New System.Drawing.Point(178, 0)
        Me.modificar_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.modificar_boton.Name = "modificar_boton"
        Me.modificar_boton.Size = New System.Drawing.Size(178, 44)
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
        Me.Botoneliminar.Location = New System.Drawing.Point(356, 0)
        Me.Botoneliminar.Margin = New System.Windows.Forms.Padding(0)
        Me.Botoneliminar.Name = "Botoneliminar"
        Me.Botoneliminar.Size = New System.Drawing.Size(178, 44)
        Me.Botoneliminar.TabIndex = 13
        Me.Botoneliminar.Text = "BORRAR"
        Me.Botoneliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Botoneliminar.UseVisualStyleBackColor = False
        '
        'Paneldatosexpedientes
        '
        Me.Paneldatosexpedientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Paneldatosexpedientes.BackColor = System.Drawing.Color.Bisque
        Me.Paneldatosexpedientes.Controls.Add(Me.TableLayoutOP)
        Me.Paneldatosexpedientes.Controls.Add(Me.Busqueda_OP)
        Me.Paneldatosexpedientes.Controls.Add(Me.Refresh_op)
        Me.Paneldatosexpedientes.Controls.Add(Me.Label1)
        Me.Paneldatosexpedientes.Controls.Add(Me.Datos_ordenprovision)
        Me.Paneldatosexpedientes.Controls.Add(Me.BotonCUITS)
        Me.Paneldatosexpedientes.Controls.Add(Me.Expediente_principal_label)
        Me.Paneldatosexpedientes.Controls.Add(Me.Label15)
        Me.Paneldatosexpedientes.Controls.Add(Me.Label14)
        Me.Paneldatosexpedientes.Controls.Add(Me.Expediente_seleccionado_label)
        Me.Paneldatosexpedientes.Controls.Add(Me.Label2)
        Me.Paneldatosexpedientes.Controls.Add(Me.Detalleexpediente_textbox)
        Me.Paneldatosexpedientes.Controls.Add(Me.Montodelexpediente_textbox)
        Me.Paneldatosexpedientes.Controls.Add(Me.Label9)
        Me.Paneldatosexpedientes.Location = New System.Drawing.Point(3, 49)
        Me.Paneldatosexpedientes.Name = "Paneldatosexpedientes"
        Me.Paneldatosexpedientes.Size = New System.Drawing.Size(534, 367)
        Me.Paneldatosexpedientes.TabIndex = 20
        Me.Paneldatosexpedientes.Visible = False
        '
        'TableLayoutOP
        '
        Me.TableLayoutOP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutOP.ColumnCount = 4
        Me.TableLayoutOP.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutOP.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutOP.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutOP.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutOP.Controls.Add(Me.IMPRIMIR_BOTON, 2, 0)
        Me.TableLayoutOP.Controls.Add(Me.Borrar_ordenprovision_boton, 3, 0)
        Me.TableLayoutOP.Controls.Add(Me.Nueva_ordenprovision_boton, 0, 0)
        Me.TableLayoutOP.Controls.Add(Me.Modificar_ordenprovision_boton, 1, 0)
        Me.TableLayoutOP.Location = New System.Drawing.Point(4, 323)
        Me.TableLayoutOP.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutOP.Name = "TableLayoutOP"
        Me.TableLayoutOP.RowCount = 1
        Me.TableLayoutOP.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutOP.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.TableLayoutOP.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.TableLayoutOP.Size = New System.Drawing.Size(534, 44)
        Me.TableLayoutOP.TabIndex = 33
        '
        'IMPRIMIR_BOTON
        '
        Me.IMPRIMIR_BOTON.BackColor = System.Drawing.Color.Snow
        Me.IMPRIMIR_BOTON.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IMPRIMIR_BOTON.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.IMPRIMIR_BOTON.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IMPRIMIR_BOTON.Image = CType(resources.GetObject("IMPRIMIR_BOTON.Image"), System.Drawing.Image)
        Me.IMPRIMIR_BOTON.Location = New System.Drawing.Point(266, 0)
        Me.IMPRIMIR_BOTON.Margin = New System.Windows.Forms.Padding(0)
        Me.IMPRIMIR_BOTON.Name = "IMPRIMIR_BOTON"
        Me.IMPRIMIR_BOTON.Size = New System.Drawing.Size(133, 44)
        Me.IMPRIMIR_BOTON.TabIndex = 16
        Me.IMPRIMIR_BOTON.Text = "IMPRIMIR"
        Me.IMPRIMIR_BOTON.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IMPRIMIR_BOTON.UseVisualStyleBackColor = False
        '
        'Borrar_ordenprovision_boton
        '
        Me.Borrar_ordenprovision_boton.BackColor = System.Drawing.Color.LightCoral
        Me.Borrar_ordenprovision_boton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Borrar_ordenprovision_boton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Borrar_ordenprovision_boton.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Borrar_ordenprovision_boton.Image = CType(resources.GetObject("Borrar_ordenprovision_boton.Image"), System.Drawing.Image)
        Me.Borrar_ordenprovision_boton.Location = New System.Drawing.Point(399, 0)
        Me.Borrar_ordenprovision_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Borrar_ordenprovision_boton.Name = "Borrar_ordenprovision_boton"
        Me.Borrar_ordenprovision_boton.Size = New System.Drawing.Size(135, 44)
        Me.Borrar_ordenprovision_boton.TabIndex = 15
        Me.Borrar_ordenprovision_boton.Text = "BORRAR O. Prov."
        Me.Borrar_ordenprovision_boton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Borrar_ordenprovision_boton.UseVisualStyleBackColor = False
        '
        'Nueva_ordenprovision_boton
        '
        Me.Nueva_ordenprovision_boton.BackColor = System.Drawing.Color.LimeGreen
        Me.Nueva_ordenprovision_boton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Nueva_ordenprovision_boton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Nueva_ordenprovision_boton.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nueva_ordenprovision_boton.Image = CType(resources.GetObject("Nueva_ordenprovision_boton.Image"), System.Drawing.Image)
        Me.Nueva_ordenprovision_boton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Nueva_ordenprovision_boton.Location = New System.Drawing.Point(0, 0)
        Me.Nueva_ordenprovision_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Nueva_ordenprovision_boton.Name = "Nueva_ordenprovision_boton"
        Me.Nueva_ordenprovision_boton.Size = New System.Drawing.Size(133, 44)
        Me.Nueva_ordenprovision_boton.TabIndex = 14
        Me.Nueva_ordenprovision_boton.Text = "Nueva Orden Provisión"
        Me.Nueva_ordenprovision_boton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Nueva_ordenprovision_boton.UseVisualStyleBackColor = False
        '
        'Modificar_ordenprovision_boton
        '
        Me.Modificar_ordenprovision_boton.BackColor = System.Drawing.Color.Gold
        Me.Modificar_ordenprovision_boton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Modificar_ordenprovision_boton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Modificar_ordenprovision_boton.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Modificar_ordenprovision_boton.Image = CType(resources.GetObject("Modificar_ordenprovision_boton.Image"), System.Drawing.Image)
        Me.Modificar_ordenprovision_boton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Modificar_ordenprovision_boton.Location = New System.Drawing.Point(133, 0)
        Me.Modificar_ordenprovision_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Modificar_ordenprovision_boton.Name = "Modificar_ordenprovision_boton"
        Me.Modificar_ordenprovision_boton.Size = New System.Drawing.Size(133, 44)
        Me.Modificar_ordenprovision_boton.TabIndex = 11
        Me.Modificar_ordenprovision_boton.Text = "Modificar Orden Provisión"
        Me.Modificar_ordenprovision_boton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Modificar_ordenprovision_boton.UseVisualStyleBackColor = False
        '
        'Busqueda_OP
        '
        Me.Busqueda_OP.BackColor = System.Drawing.Color.White
        Me.Busqueda_OP.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Busqueda_OP.ForeColor = System.Drawing.Color.Black
        Me.Busqueda_OP.Location = New System.Drawing.Point(9, 149)
        Me.Busqueda_OP.Name = "Busqueda_OP"
        Me.Busqueda_OP.Size = New System.Drawing.Size(263, 23)
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
        Me.Refresh_op.Location = New System.Drawing.Point(275, 146)
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
        Me.Label1.Location = New System.Drawing.Point(133, 133)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Ordenes de provisión"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Datos_ordenprovision
        '
        Me.Datos_ordenprovision.AllowUserToAddRows = False
        Me.Datos_ordenprovision.AllowUserToOrderColumns = True
        Me.Datos_ordenprovision.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Datos_ordenprovision.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Datos_ordenprovision.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Datos_ordenprovision.BackgroundColor = System.Drawing.Color.White
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
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_ordenprovision.DefaultCellStyle = DataGridViewCellStyle5
        Me.Datos_ordenprovision.Location = New System.Drawing.Point(3, 178)
        Me.Datos_ordenprovision.Name = "Datos_ordenprovision"
        Me.Datos_ordenprovision.RowHeadersVisible = False
        Me.Datos_ordenprovision.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Datos_ordenprovision.Size = New System.Drawing.Size(528, 142)
        Me.Datos_ordenprovision.TabIndex = 28
        '
        'BotonCUITS
        '
        Me.BotonCUITS.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BotonCUITS.BackColor = System.Drawing.Color.DarkOrange
        Me.BotonCUITS.BackgroundImage = Global.SICyF.My.Resources.Resources.add
        Me.BotonCUITS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BotonCUITS.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BotonCUITS.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BotonCUITS.ForeColor = System.Drawing.Color.Black
        Me.BotonCUITS.Location = New System.Drawing.Point(447, 112)
        Me.BotonCUITS.Margin = New System.Windows.Forms.Padding(0)
        Me.BotonCUITS.Name = "BotonCUITS"
        Me.BotonCUITS.Size = New System.Drawing.Size(84, 63)
        Me.BotonCUITS.TabIndex = 22
        Me.BotonCUITS.Text = "Asociar Proveedores"
        Me.BotonCUITS.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BotonCUITS.UseVisualStyleBackColor = False
        '
        'Expediente_principal_label
        '
        Me.Expediente_principal_label.AutoSize = True
        Me.Expediente_principal_label.ForeColor = System.Drawing.Color.Black
        Me.Expediente_principal_label.Location = New System.Drawing.Point(4, 79)
        Me.Expediente_principal_label.Margin = New System.Windows.Forms.Padding(0)
        Me.Expediente_principal_label.Name = "Expediente_principal_label"
        Me.Expediente_principal_label.Size = New System.Drawing.Size(13, 13)
        Me.Expediente_principal_label.TabIndex = 26
        Me.Expediente_principal_label.Text = "_"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(5, 26)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(117, 13)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "Fecha del Expediente"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(1, 110)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(73, 20)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "Monto Exp."
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
        Me.Detalleexpediente_textbox.BackColor = System.Drawing.Color.Bisque
        Me.Detalleexpediente_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Detalleexpediente_textbox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Detalleexpediente_textbox.ForeColor = System.Drawing.Color.Black
        Me.Detalleexpediente_textbox.Location = New System.Drawing.Point(4, 60)
        Me.Detalleexpediente_textbox.Multiline = True
        Me.Detalleexpediente_textbox.Name = "Detalleexpediente_textbox"
        Me.Detalleexpediente_textbox.ReadOnly = True
        Me.Detalleexpediente_textbox.Size = New System.Drawing.Size(533, 49)
        Me.Detalleexpediente_textbox.TabIndex = 18
        Me.Detalleexpediente_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Montodelexpediente_textbox
        '
        Me.Montodelexpediente_textbox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Montodelexpediente_textbox.BackColor = System.Drawing.Color.Bisque
        Me.Montodelexpediente_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Montodelexpediente_textbox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Montodelexpediente_textbox.Location = New System.Drawing.Point(77, 93)
        Me.Montodelexpediente_textbox.Multiline = True
        Me.Montodelexpediente_textbox.Name = "Montodelexpediente_textbox"
        Me.Montodelexpediente_textbox.ReadOnly = True
        Me.Montodelexpediente_textbox.Size = New System.Drawing.Size(369, 37)
        Me.Montodelexpediente_textbox.TabIndex = 23
        Me.Montodelexpediente_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(5, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 17)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Descripción"
        '
        'Suministros_expedientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(981, 423)
        Me.Controls.Add(Me.SplitExpedientes)
        Me.Name = "Suministros_expedientes"
        Me.Text = "Suministros_expedientes"
        Me.SplitExpedientes.Panel1.ResumeLayout(False)
        Me.SplitExpedientes.Panel1.PerformLayout()
        Me.SplitExpedientes.Panel2.ResumeLayout(False)
        CType(Me.SplitExpedientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitExpedientes.ResumeLayout(False)
        CType(Me.Datos_datagrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanelbotones.ResumeLayout(False)
        Me.Paneldatosexpedientes.ResumeLayout(False)
        Me.Paneldatosexpedientes.PerformLayout()
        Me.TableLayoutOP.ResumeLayout(False)
        CType(Me.Datos_ordenprovision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents SplitExpedientes As SplitContainer
    Friend WithEvents Datos_datagrid As Flicker_Datagridview
    Friend WithEvents Busqueda_textbox As TextBox
    Friend WithEvents Refresh_boton As Button
    Friend WithEvents TableLayoutPanelbotones As TableLayoutPanel
    Friend WithEvents Nuevoexpediente_boton As Button
    Friend WithEvents modificar_boton As Button
    Friend WithEvents Botoneliminar As Button
    Friend WithEvents Paneldatosexpedientes As Panel
    Friend WithEvents BotonCUITS As Button
    Friend WithEvents Expediente_principal_label As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Expediente_seleccionado_label As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Detalleexpediente_textbox As TextBox
    Friend WithEvents Montodelexpediente_textbox As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Datos_ordenprovision As Flicker_Datagridview
    Friend WithEvents Busqueda_OP As TextBox
    Friend WithEvents Refresh_op As Button
    Friend WithEvents TableLayoutOP As TableLayoutPanel
    Friend WithEvents Nueva_ordenprovision_boton As Button
    Friend WithEvents Modificar_ordenprovision_boton As Button
    Friend WithEvents IMPRIMIR_BOTON As Button
    Friend WithEvents Borrar_ordenprovision_boton As Button
    Friend WithEvents Label3 As Label
End Class
