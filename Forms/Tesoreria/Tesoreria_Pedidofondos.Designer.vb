<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tesoreria_Pedidofondos
    'Inherits ComponentFactory.Krypton.Toolkit.KryptonForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tesoreria_Pedidofondos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Busqueda = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Boton_Modificar = New System.Windows.Forms.Button()
        Me.Boton_borrar = New System.Windows.Forms.Button()
        Me.Boton_Nuevo = New System.Windows.Forms.Button()
        Me.Botonbusquedaexpedientessinasociar = New System.Windows.Forms.Button()
        Me.Asociarexpediente_boton = New System.Windows.Forms.Button()
        Me.BusquedaexpedientesNOasociados_textbox = New System.Windows.Forms.TextBox()
        Me.Labelexpedientessinasociar = New System.Windows.Forms.Label()
        Me.Generarpedidodefondo_boton = New System.Windows.Forms.Button()
        Me.Botonbusquedaexpedientesasociados = New System.Windows.Forms.Button()
        Me.Quitarasociacion_boton = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Busquedaexpedientesasociados_textbox = New System.Windows.Forms.TextBox()
        Me.Label_expedienteasociados = New System.Windows.Forms.Label()
        Me.splitContainerGeneral = New System.Windows.Forms.SplitContainer()
        Me.PanelDatos_pedidofondo = New System.Windows.Forms.Panel()
        Me.Refresh_boton = New System.Windows.Forms.Button()
        Me.Datosspedidofondo_datagridview = New SICyF.Flicker_Datagridview()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panelnuevopedido = New System.Windows.Forms.Panel()
        Me.Pedidohaberes_checkbox = New System.Windows.Forms.CheckBox()
        Me.Pedidoparcialcheckbox = New System.Windows.Forms.CheckBox()
        Me.Organismo_textbox = New System.Windows.Forms.NumericUpDown()
        Me.Year_expediente_textbox = New System.Windows.Forms.NumericUpDown()
        Me.Label_MontoSolicitado = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Organismolabel = New System.Windows.Forms.Label()
        Me.Numero_cuentalabel = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Year_pedidofondo_numeric = New System.Windows.Forms.NumericUpDown()
        Me.Fecha_pedido_textbox = New System.Windows.Forms.DateTimePicker()
        Me.Cuentas_combobox = New System.Windows.Forms.ComboBox()
        Me.Descripcion_textbox = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Expte_numero_numericupdown = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Cuenta_label = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Clasefondo_textbox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.N_pedidofondo_numeric = New System.Windows.Forms.NumericUpDown()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.Expedientesasociados_datagridview = New SICyF.Flicker_Datagridview()
        Me.ElementHost1 = New System.Windows.Forms.Integration.ElementHost()
        Me.Pedidodefondosmontowpf = New SICyF.Control_currency_textboxWPF()
        Me.ExpedientesNOasociados_datagridview = New SICyF.Flicker_Datagridview()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.DirectorySearcher1 = New System.DirectoryServices.DirectorySearcher()
        CType(Me.splitContainerGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitContainerGeneral.Panel1.SuspendLayout()
        Me.splitContainerGeneral.Panel2.SuspendLayout()
        Me.splitContainerGeneral.SuspendLayout()
        Me.PanelDatos_pedidofondo.SuspendLayout()
        CType(Me.Datosspedidofondo_datagridview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panelnuevopedido.SuspendLayout()
        CType(Me.Organismo_textbox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Year_expediente_textbox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Year_pedidofondo_numeric, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Expte_numero_numericupdown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.N_pedidofondo_numeric, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.Expedientesasociados_datagridview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExpedientesNOasociados_datagridview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Busqueda
        '
        Me.Busqueda.BackColor = System.Drawing.Color.White
        Me.Busqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Busqueda.Font = New System.Drawing.Font("Garamond", 10.0!)
        Me.Busqueda.ForeColor = System.Drawing.Color.Black
        Me.Busqueda.Location = New System.Drawing.Point(76, 20)
        Me.Busqueda.Margin = New System.Windows.Forms.Padding(0)
        Me.Busqueda.Name = "Busqueda"
        Me.Busqueda.Size = New System.Drawing.Size(196, 22)
        Me.Busqueda.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(93, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 11)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Pedidos de fondos"
        '
        'Boton_Modificar
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.Boton_Modificar, 2)
        Me.Boton_Modificar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Boton_Modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Boton_Modificar.Font = New System.Drawing.Font("Segoe UI", 8.999999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Boton_Modificar.Image = CType(resources.GetObject("Boton_Modificar.Image"), System.Drawing.Image)
        Me.Boton_Modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Boton_Modificar.Location = New System.Drawing.Point(3, 34)
        Me.Boton_Modificar.Name = "Boton_Modificar"
        Me.Boton_Modificar.Size = New System.Drawing.Size(934, 25)
        Me.Boton_Modificar.TabIndex = 11
        Me.Boton_Modificar.Text = "MODIFICAR Pedido de Fondo Seleccionado"
        Me.Boton_Modificar.UseVisualStyleBackColor = True
        '
        'Boton_borrar
        '
        Me.Boton_borrar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Boton_borrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Boton_borrar.Font = New System.Drawing.Font("Segoe UI", 8.999999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Boton_borrar.Image = CType(resources.GetObject("Boton_borrar.Image"), System.Drawing.Image)
        Me.Boton_borrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Boton_borrar.Location = New System.Drawing.Point(473, 3)
        Me.Boton_borrar.Name = "Boton_borrar"
        Me.Boton_borrar.Size = New System.Drawing.Size(464, 25)
        Me.Boton_borrar.TabIndex = 102
        Me.Boton_borrar.Text = "Borrar Pedido de Fondo seleccionado"
        Me.Boton_borrar.UseVisualStyleBackColor = True
        '
        'Boton_Nuevo
        '
        Me.Boton_Nuevo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Boton_Nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Boton_Nuevo.Font = New System.Drawing.Font("Segoe UI", 8.999999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Boton_Nuevo.Image = CType(resources.GetObject("Boton_Nuevo.Image"), System.Drawing.Image)
        Me.Boton_Nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Boton_Nuevo.Location = New System.Drawing.Point(3, 3)
        Me.Boton_Nuevo.Name = "Boton_Nuevo"
        Me.Boton_Nuevo.Size = New System.Drawing.Size(464, 25)
        Me.Boton_Nuevo.TabIndex = 103
        Me.Boton_Nuevo.Text = " Nuevo Pedido de Fondo"
        Me.Boton_Nuevo.UseVisualStyleBackColor = True
        '
        'Botonbusquedaexpedientessinasociar
        '
        Me.Botonbusquedaexpedientessinasociar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Botonbusquedaexpedientessinasociar.AutoSize = True
        Me.Botonbusquedaexpedientessinasociar.BackgroundImage = CType(resources.GetObject("Botonbusquedaexpedientessinasociar.BackgroundImage"), System.Drawing.Image)
        Me.Botonbusquedaexpedientessinasociar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Botonbusquedaexpedientessinasociar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Botonbusquedaexpedientessinasociar.Location = New System.Drawing.Point(418, 20)
        Me.Botonbusquedaexpedientessinasociar.Name = "Botonbusquedaexpedientessinasociar"
        Me.Botonbusquedaexpedientessinasociar.Size = New System.Drawing.Size(41, 24)
        Me.Botonbusquedaexpedientessinasociar.TabIndex = 106
        Me.Botonbusquedaexpedientessinasociar.UseVisualStyleBackColor = True
        '
        'Asociarexpediente_boton
        '
        Me.Asociarexpediente_boton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Asociarexpediente_boton.BackColor = System.Drawing.Color.AliceBlue
        Me.Asociarexpediente_boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Asociarexpediente_boton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Asociarexpediente_boton.Image = CType(resources.GetObject("Asociarexpediente_boton.Image"), System.Drawing.Image)
        Me.Asociarexpediente_boton.Location = New System.Drawing.Point(2, 49)
        Me.Asociarexpediente_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Asociarexpediente_boton.Name = "Asociarexpediente_boton"
        Me.Asociarexpediente_boton.Size = New System.Drawing.Size(61, 300)
        Me.Asociarexpediente_boton.TabIndex = 103
        Me.Asociarexpediente_boton.Text = "Asociar a " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "pedido" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "de fondo"
        Me.Asociarexpediente_boton.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Asociarexpediente_boton.UseVisualStyleBackColor = False
        '
        'BusquedaexpedientesNOasociados_textbox
        '
        Me.BusquedaexpedientesNOasociados_textbox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BusquedaexpedientesNOasociados_textbox.BackColor = System.Drawing.Color.White
        Me.BusquedaexpedientesNOasociados_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BusquedaexpedientesNOasociados_textbox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BusquedaexpedientesNOasociados_textbox.ForeColor = System.Drawing.Color.Black
        Me.BusquedaexpedientesNOasociados_textbox.Location = New System.Drawing.Point(63, 25)
        Me.BusquedaexpedientesNOasociados_textbox.Margin = New System.Windows.Forms.Padding(0)
        Me.BusquedaexpedientesNOasociados_textbox.Name = "BusquedaexpedientesNOasociados_textbox"
        Me.BusquedaexpedientesNOasociados_textbox.Size = New System.Drawing.Size(352, 22)
        Me.BusquedaexpedientesNOasociados_textbox.TabIndex = 101
        '
        'Labelexpedientessinasociar
        '
        Me.Labelexpedientessinasociar.AutoSize = True
        Me.Labelexpedientessinasociar.BackColor = System.Drawing.Color.Transparent
        Me.Labelexpedientessinasociar.Font = New System.Drawing.Font("Garamond", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labelexpedientessinasociar.ForeColor = System.Drawing.Color.Black
        Me.Labelexpedientessinasociar.Location = New System.Drawing.Point(60, 9)
        Me.Labelexpedientessinasociar.Name = "Labelexpedientessinasociar"
        Me.Labelexpedientessinasociar.Size = New System.Drawing.Size(186, 14)
        Me.Labelexpedientessinasociar.TabIndex = 100
        Me.Labelexpedientessinasociar.Text = "Expedientes sin pedido de fondo"
        Me.Labelexpedientessinasociar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Generarpedidodefondo_boton
        '
        Me.Generarpedidodefondo_boton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Generarpedidodefondo_boton.BackColor = System.Drawing.Color.LightGreen
        Me.Generarpedidodefondo_boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Generarpedidodefondo_boton.Font = New System.Drawing.Font("Segoe UI", 8.999999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Generarpedidodefondo_boton.Image = CType(resources.GetObject("Generarpedidodefondo_boton.Image"), System.Drawing.Image)
        Me.Generarpedidodefondo_boton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Generarpedidodefondo_boton.Location = New System.Drawing.Point(3, 314)
        Me.Generarpedidodefondo_boton.Name = "Generarpedidodefondo_boton"
        Me.Generarpedidodefondo_boton.Size = New System.Drawing.Size(384, 32)
        Me.Generarpedidodefondo_boton.TabIndex = 103
        Me.Generarpedidodefondo_boton.Text = "GENERAR Pedido Fondo"
        Me.Generarpedidodefondo_boton.UseVisualStyleBackColor = False
        '
        'Botonbusquedaexpedientesasociados
        '
        Me.Botonbusquedaexpedientesasociados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Botonbusquedaexpedientesasociados.AutoSize = True
        Me.Botonbusquedaexpedientesasociados.BackgroundImage = CType(resources.GetObject("Botonbusquedaexpedientesasociados.BackgroundImage"), System.Drawing.Image)
        Me.Botonbusquedaexpedientesasociados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Botonbusquedaexpedientesasociados.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Botonbusquedaexpedientesasociados.Location = New System.Drawing.Point(231, 25)
        Me.Botonbusquedaexpedientesasociados.Name = "Botonbusquedaexpedientesasociados"
        Me.Botonbusquedaexpedientesasociados.Size = New System.Drawing.Size(41, 24)
        Me.Botonbusquedaexpedientesasociados.TabIndex = 105
        Me.Botonbusquedaexpedientesasociados.UseVisualStyleBackColor = True
        '
        'Quitarasociacion_boton
        '
        Me.Quitarasociacion_boton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Quitarasociacion_boton.BackColor = System.Drawing.Color.MistyRose
        Me.Quitarasociacion_boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Quitarasociacion_boton.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Quitarasociacion_boton.Image = CType(resources.GetObject("Quitarasociacion_boton.Image"), System.Drawing.Image)
        Me.Quitarasociacion_boton.Location = New System.Drawing.Point(390, 49)
        Me.Quitarasociacion_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Quitarasociacion_boton.Name = "Quitarasociacion_boton"
        Me.Quitarasociacion_boton.Size = New System.Drawing.Size(74, 300)
        Me.Quitarasociacion_boton.TabIndex = 104
        Me.Quitarasociacion_boton.Text = "Quitar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Asociación"
        Me.Quitarasociacion_boton.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Quitarasociacion_boton.UseVisualStyleBackColor = False
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Garamond", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(310, 2)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(132, 14)
        Me.Label17.TabIndex = 100
        Me.Label17.Text = "Expedientes Sumado $"
        '
        'Busquedaexpedientesasociados_textbox
        '
        Me.Busquedaexpedientesasociados_textbox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Busquedaexpedientesasociados_textbox.BackColor = System.Drawing.Color.White
        Me.Busquedaexpedientesasociados_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Busquedaexpedientesasociados_textbox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Busquedaexpedientesasociados_textbox.ForeColor = System.Drawing.Color.Black
        Me.Busquedaexpedientesasociados_textbox.Location = New System.Drawing.Point(8, 25)
        Me.Busquedaexpedientesasociados_textbox.Margin = New System.Windows.Forms.Padding(0)
        Me.Busquedaexpedientesasociados_textbox.Name = "Busquedaexpedientesasociados_textbox"
        Me.Busquedaexpedientesasociados_textbox.Size = New System.Drawing.Size(220, 22)
        Me.Busquedaexpedientesasociados_textbox.TabIndex = 33
        '
        'Label_expedienteasociados
        '
        Me.Label_expedienteasociados.AutoSize = True
        Me.Label_expedienteasociados.BackColor = System.Drawing.Color.Transparent
        Me.Label_expedienteasociados.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_expedienteasociados.ForeColor = System.Drawing.Color.Black
        Me.Label_expedienteasociados.Location = New System.Drawing.Point(7, 5)
        Me.Label_expedienteasociados.Name = "Label_expedienteasociados"
        Me.Label_expedienteasociados.Size = New System.Drawing.Size(196, 20)
        Me.Label_expedienteasociados.TabIndex = 29
        Me.Label_expedienteasociados.Text = "Datos del Pedido de Fondo"
        '
        'splitContainerGeneral
        '
        Me.splitContainerGeneral.BackColor = System.Drawing.Color.DimGray
        Me.splitContainerGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainerGeneral.Location = New System.Drawing.Point(0, 0)
        Me.splitContainerGeneral.Name = "splitContainerGeneral"
        Me.splitContainerGeneral.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitContainerGeneral.Panel1
        '
        Me.splitContainerGeneral.Panel1.AutoScroll = True
        Me.splitContainerGeneral.Panel1.Controls.Add(Me.PanelDatos_pedidofondo)
        '
        'splitContainerGeneral.Panel2
        '
        Me.splitContainerGeneral.Panel2.Controls.Add(Me.SplitContainer3)
        Me.splitContainerGeneral.Size = New System.Drawing.Size(943, 668)
        Me.splitContainerGeneral.SplitterDistance = 312
        Me.splitContainerGeneral.TabIndex = 102
        '
        'PanelDatos_pedidofondo
        '
        Me.PanelDatos_pedidofondo.BackColor = System.Drawing.Color.White
        Me.PanelDatos_pedidofondo.Controls.Add(Me.Refresh_boton)
        Me.PanelDatos_pedidofondo.Controls.Add(Me.Datosspedidofondo_datagridview)
        Me.PanelDatos_pedidofondo.Controls.Add(Me.Busqueda)
        Me.PanelDatos_pedidofondo.Controls.Add(Me.TableLayoutPanel2)
        Me.PanelDatos_pedidofondo.Controls.Add(Me.Label1)
        Me.PanelDatos_pedidofondo.Controls.Add(Me.Panelnuevopedido)
        Me.PanelDatos_pedidofondo.Controls.Add(Me.Label7)
        Me.PanelDatos_pedidofondo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelDatos_pedidofondo.Location = New System.Drawing.Point(0, 0)
        Me.PanelDatos_pedidofondo.Name = "PanelDatos_pedidofondo"
        Me.PanelDatos_pedidofondo.Size = New System.Drawing.Size(943, 312)
        Me.PanelDatos_pedidofondo.TabIndex = 104
        '
        'Refresh_boton
        '
        Me.Refresh_boton.BackColor = System.Drawing.Color.Green
        Me.Refresh_boton.BackgroundImage = CType(resources.GetObject("Refresh_boton.BackgroundImage"), System.Drawing.Image)
        Me.Refresh_boton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Refresh_boton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Refresh_boton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Refresh_boton.ForeColor = System.Drawing.Color.Black
        Me.Refresh_boton.Location = New System.Drawing.Point(278, 16)
        Me.Refresh_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Refresh_boton.Name = "Refresh_boton"
        Me.Refresh_boton.Size = New System.Drawing.Size(32, 26)
        Me.Refresh_boton.TabIndex = 106
        Me.Refresh_boton.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Refresh_boton.UseVisualStyleBackColor = False
        '
        'Datosspedidofondo_datagridview
        '
        Me.Datosspedidofondo_datagridview.AllowUserToAddRows = False
        Me.Datosspedidofondo_datagridview.AllowUserToDeleteRows = False
        Me.Datosspedidofondo_datagridview.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Datosspedidofondo_datagridview.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Datosspedidofondo_datagridview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Datosspedidofondo_datagridview.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Datosspedidofondo_datagridview.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datosspedidofondo_datagridview.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Datosspedidofondo_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datosspedidofondo_datagridview.DefaultCellStyle = DataGridViewCellStyle3
        Me.Datosspedidofondo_datagridview.Location = New System.Drawing.Point(8, 45)
        Me.Datosspedidofondo_datagridview.MultiSelect = False
        Me.Datosspedidofondo_datagridview.Name = "Datosspedidofondo_datagridview"
        Me.Datosspedidofondo_datagridview.ReadOnly = True
        Me.Datosspedidofondo_datagridview.RowHeadersVisible = False
        Me.Datosspedidofondo_datagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Datosspedidofondo_datagridview.Size = New System.Drawing.Size(932, 199)
        Me.Datosspedidofondo_datagridview.TabIndex = 2
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Boton_Nuevo, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Boton_borrar, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Boton_Modificar, 0, 1)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 247)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(940, 62)
        Me.TableLayoutPanel2.TabIndex = 104
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(10, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "Busqueda"
        '
        'Panelnuevopedido
        '
        Me.Panelnuevopedido.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panelnuevopedido.AutoScroll = True
        Me.Panelnuevopedido.Controls.Add(Me.Pedidohaberes_checkbox)
        Me.Panelnuevopedido.Controls.Add(Me.Pedidoparcialcheckbox)
        Me.Panelnuevopedido.Controls.Add(Me.Organismo_textbox)
        Me.Panelnuevopedido.Controls.Add(Me.Year_expediente_textbox)
        Me.Panelnuevopedido.Controls.Add(Me.Label_MontoSolicitado)
        Me.Panelnuevopedido.Controls.Add(Me.Label8)
        Me.Panelnuevopedido.Controls.Add(Me.Organismolabel)
        Me.Panelnuevopedido.Controls.Add(Me.Numero_cuentalabel)
        Me.Panelnuevopedido.Controls.Add(Me.Label3)
        Me.Panelnuevopedido.Controls.Add(Me.Year_pedidofondo_numeric)
        Me.Panelnuevopedido.Controls.Add(Me.Fecha_pedido_textbox)
        Me.Panelnuevopedido.Controls.Add(Me.Cuentas_combobox)
        Me.Panelnuevopedido.Controls.Add(Me.Descripcion_textbox)
        Me.Panelnuevopedido.Controls.Add(Me.Label16)
        Me.Panelnuevopedido.Controls.Add(Me.Expte_numero_numericupdown)
        Me.Panelnuevopedido.Controls.Add(Me.Label2)
        Me.Panelnuevopedido.Controls.Add(Me.Label5)
        Me.Panelnuevopedido.Controls.Add(Me.Label9)
        Me.Panelnuevopedido.Controls.Add(Me.Label13)
        Me.Panelnuevopedido.Controls.Add(Me.Cuenta_label)
        Me.Panelnuevopedido.Controls.Add(Me.Label15)
        Me.Panelnuevopedido.Controls.Add(Me.Clasefondo_textbox)
        Me.Panelnuevopedido.Controls.Add(Me.Label6)
        Me.Panelnuevopedido.Controls.Add(Me.N_pedidofondo_numeric)
        Me.Panelnuevopedido.Controls.Add(Me.Label14)
        Me.Panelnuevopedido.Location = New System.Drawing.Point(1168, 3)
        Me.Panelnuevopedido.Name = "Panelnuevopedido"
        Me.Panelnuevopedido.Size = New System.Drawing.Size(275, 290)
        Me.Panelnuevopedido.TabIndex = 30
        Me.Panelnuevopedido.Visible = False
        '
        'Pedidohaberes_checkbox
        '
        Me.Pedidohaberes_checkbox.AutoSize = True
        Me.Pedidohaberes_checkbox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pedidohaberes_checkbox.Location = New System.Drawing.Point(109, 292)
        Me.Pedidohaberes_checkbox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Pedidohaberes_checkbox.Name = "Pedidohaberes_checkbox"
        Me.Pedidohaberes_checkbox.Size = New System.Drawing.Size(69, 19)
        Me.Pedidohaberes_checkbox.TabIndex = 142
        Me.Pedidohaberes_checkbox.Text = "Haberes"
        Me.Pedidohaberes_checkbox.UseVisualStyleBackColor = True
        '
        'Pedidoparcialcheckbox
        '
        Me.Pedidoparcialcheckbox.AutoSize = True
        Me.Pedidoparcialcheckbox.Location = New System.Drawing.Point(111, 267)
        Me.Pedidoparcialcheckbox.Name = "Pedidoparcialcheckbox"
        Me.Pedidoparcialcheckbox.Size = New System.Drawing.Size(151, 17)
        Me.Pedidoparcialcheckbox.TabIndex = 9
        Me.Pedidoparcialcheckbox.Text = "Pedido de Fondo Parcial"
        Me.Pedidoparcialcheckbox.UseVisualStyleBackColor = True
        '
        'Organismo_textbox
        '
        Me.Organismo_textbox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Organismo_textbox.Location = New System.Drawing.Point(127, 163)
        Me.Organismo_textbox.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.Organismo_textbox.Name = "Organismo_textbox"
        Me.Organismo_textbox.ReadOnly = True
        Me.Organismo_textbox.Size = New System.Drawing.Size(86, 23)
        Me.Organismo_textbox.TabIndex = 4
        Me.Organismo_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Year_expediente_textbox
        '
        Me.Year_expediente_textbox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Year_expediente_textbox.Location = New System.Drawing.Point(344, 162)
        Me.Year_expediente_textbox.Maximum = New Decimal(New Integer() {2200, 0, 0, 0})
        Me.Year_expediente_textbox.Minimum = New Decimal(New Integer() {2016, 0, 0, 0})
        Me.Year_expediente_textbox.Name = "Year_expediente_textbox"
        Me.Year_expediente_textbox.Size = New System.Drawing.Size(86, 23)
        Me.Year_expediente_textbox.TabIndex = 6
        Me.Year_expediente_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Year_expediente_textbox.Value = New Decimal(New Integer() {2016, 0, 0, 0})
        '
        'Label_MontoSolicitado
        '
        Me.Label_MontoSolicitado.AutoSize = True
        Me.Label_MontoSolicitado.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Label_MontoSolicitado.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_MontoSolicitado.ForeColor = System.Drawing.Color.White
        Me.Label_MontoSolicitado.Location = New System.Drawing.Point(19, 4)
        Me.Label_MontoSolicitado.Name = "Label_MontoSolicitado"
        Me.Label_MontoSolicitado.Size = New System.Drawing.Size(244, 17)
        Me.Label_MontoSolicitado.TabIndex = 17
        Me.Label_MontoSolicitado.Text = "Monto Solicitado según expedientes $"
        Me.Label_MontoSolicitado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(380, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Año"
        '
        'Organismolabel
        '
        Me.Organismolabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Organismolabel.AutoSize = True
        Me.Organismolabel.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Organismolabel.ForeColor = System.Drawing.Color.Black
        Me.Organismolabel.Location = New System.Drawing.Point(19, 184)
        Me.Organismolabel.Name = "Organismolabel"
        Me.Organismolabel.Size = New System.Drawing.Size(29, 13)
        Me.Organismolabel.TabIndex = 23
        Me.Organismolabel.Text = "Org."
        Me.Organismolabel.Visible = False
        '
        'Numero_cuentalabel
        '
        Me.Numero_cuentalabel.AutoSize = True
        Me.Numero_cuentalabel.Font = New System.Drawing.Font("Garamond", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Numero_cuentalabel.Location = New System.Drawing.Point(19, 138)
        Me.Numero_cuentalabel.Name = "Numero_cuentalabel"
        Me.Numero_cuentalabel.Size = New System.Drawing.Size(16, 13)
        Me.Numero_cuentalabel.TabIndex = 28
        Me.Numero_cuentalabel.Text = "N"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(19, 215)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Descripción"
        '
        'Year_pedidofondo_numeric
        '
        Me.Year_pedidofondo_numeric.Enabled = False
        Me.Year_pedidofondo_numeric.Font = New System.Drawing.Font("Garamond", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Year_pedidofondo_numeric.Location = New System.Drawing.Point(325, 46)
        Me.Year_pedidofondo_numeric.Maximum = New Decimal(New Integer() {2200, 0, 0, 0})
        Me.Year_pedidofondo_numeric.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.Year_pedidofondo_numeric.Name = "Year_pedidofondo_numeric"
        Me.Year_pedidofondo_numeric.Size = New System.Drawing.Size(148, 31)
        Me.Year_pedidofondo_numeric.TabIndex = 1
        Me.Year_pedidofondo_numeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Year_pedidofondo_numeric.Value = New Decimal(New Integer() {2018, 0, 0, 0})
        '
        'Fecha_pedido_textbox
        '
        Me.Fecha_pedido_textbox.CalendarFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fecha_pedido_textbox.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Fecha_pedido_textbox.Location = New System.Drawing.Point(182, 83)
        Me.Fecha_pedido_textbox.Name = "Fecha_pedido_textbox"
        Me.Fecha_pedido_textbox.Size = New System.Drawing.Size(291, 25)
        Me.Fecha_pedido_textbox.TabIndex = 2
        '
        'Cuentas_combobox
        '
        Me.Cuentas_combobox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cuentas_combobox.FormattingEnabled = True
        Me.Cuentas_combobox.Location = New System.Drawing.Point(116, 112)
        Me.Cuentas_combobox.Margin = New System.Windows.Forms.Padding(0)
        Me.Cuentas_combobox.Name = "Cuentas_combobox"
        Me.Cuentas_combobox.Size = New System.Drawing.Size(357, 25)
        Me.Cuentas_combobox.TabIndex = 3
        '
        'Descripcion_textbox
        '
        Me.Descripcion_textbox.BackColor = System.Drawing.Color.White
        Me.Descripcion_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Descripcion_textbox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Descripcion_textbox.ForeColor = System.Drawing.Color.Black
        Me.Descripcion_textbox.Location = New System.Drawing.Point(116, 203)
        Me.Descripcion_textbox.Margin = New System.Windows.Forms.Padding(0)
        Me.Descripcion_textbox.Multiline = True
        Me.Descripcion_textbox.Name = "Descripcion_textbox"
        Me.Descripcion_textbox.Size = New System.Drawing.Size(361, 37)
        Me.Descripcion_textbox.TabIndex = 7
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(19, 112)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(81, 26)
        Me.Label16.TabIndex = 17
        Me.Label16.Text = "Cuenta a la " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "que pertenece"
        '
        'Expte_numero_numericupdown
        '
        Me.Expte_numero_numericupdown.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Expte_numero_numericupdown.Location = New System.Drawing.Point(216, 162)
        Me.Expte_numero_numericupdown.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.Expte_numero_numericupdown.Name = "Expte_numero_numericupdown"
        Me.Expte_numero_numericupdown.Size = New System.Drawing.Size(122, 23)
        Me.Expte_numero_numericupdown.TabIndex = 5
        Me.Expte_numero_numericupdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(218, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Número"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(19, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Fecha de solicitud"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(8, 158)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(105, 26)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Expediente Pedido" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "de Fondos"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(370, 146)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(29, 13)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "Año"
        '
        'Cuenta_label
        '
        Me.Cuenta_label.AutoSize = True
        Me.Cuenta_label.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cuenta_label.ForeColor = System.Drawing.Color.Black
        Me.Cuenta_label.Location = New System.Drawing.Point(19, 55)
        Me.Cuenta_label.Name = "Cuenta_label"
        Me.Cuenta_label.Size = New System.Drawing.Size(112, 13)
        Me.Cuenta_label.TabIndex = 1
        Me.Cuenta_label.Text = "Pedido de fondos N"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(137, 149)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 13)
        Me.Label15.TabIndex = 22
        Me.Label15.Text = "Organismo"
        '
        'Clasefondo_textbox
        '
        Me.Clasefondo_textbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Clasefondo_textbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.Clasefondo_textbox.BackColor = System.Drawing.Color.White
        Me.Clasefondo_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Clasefondo_textbox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Clasefondo_textbox.ForeColor = System.Drawing.Color.Black
        Me.Clasefondo_textbox.Location = New System.Drawing.Point(116, 243)
        Me.Clasefondo_textbox.Margin = New System.Windows.Forms.Padding(0)
        Me.Clasefondo_textbox.Name = "Clasefondo_textbox"
        Me.Clasefondo_textbox.Size = New System.Drawing.Size(361, 23)
        Me.Clasefondo_textbox.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(18, 247)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Clase de Fondo"
        '
        'N_pedidofondo_numeric
        '
        Me.N_pedidofondo_numeric.Font = New System.Drawing.Font("Garamond", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.N_pedidofondo_numeric.Location = New System.Drawing.Point(182, 46)
        Me.N_pedidofondo_numeric.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.N_pedidofondo_numeric.Name = "N_pedidofondo_numeric"
        Me.N_pedidofondo_numeric.Size = New System.Drawing.Size(140, 31)
        Me.N_pedidofondo_numeric.TabIndex = 0
        Me.N_pedidofondo_numeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(244, 146)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(50, 13)
        Me.Label14.TabIndex = 20
        Me.Label14.Text = "Número"
        '
        'SplitContainer3
        '
        Me.SplitContainer3.BackColor = System.Drawing.Color.DimGray
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.AutoScroll = True
        Me.SplitContainer3.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainer3.Panel1.Controls.Add(Me.Generarpedidodefondo_boton)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Expedientesasociados_datagridview)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Botonbusquedaexpedientesasociados)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label_expedienteasociados)
        Me.SplitContainer3.Panel1.Controls.Add(Me.ElementHost1)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Busquedaexpedientesasociados_textbox)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Quitarasociacion_boton)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label17)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.BackColor = System.Drawing.Color.White
        Me.SplitContainer3.Panel2.Controls.Add(Me.Botonbusquedaexpedientessinasociar)
        Me.SplitContainer3.Panel2.Controls.Add(Me.ExpedientesNOasociados_datagridview)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Asociarexpediente_boton)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Labelexpedientessinasociar)
        Me.SplitContainer3.Panel2.Controls.Add(Me.BusquedaexpedientesNOasociados_textbox)
        Me.SplitContainer3.Size = New System.Drawing.Size(943, 352)
        Me.SplitContainer3.SplitterDistance = 469
        Me.SplitContainer3.TabIndex = 104
        Me.SplitContainer3.Visible = False
        '
        'Expedientesasociados_datagridview
        '
        Me.Expedientesasociados_datagridview.AllowUserToAddRows = False
        Me.Expedientesasociados_datagridview.AllowUserToDeleteRows = False
        Me.Expedientesasociados_datagridview.AllowUserToOrderColumns = True
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Expedientesasociados_datagridview.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.Expedientesasociados_datagridview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Expedientesasociados_datagridview.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Expedientesasociados_datagridview.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Expedientesasociados_datagridview.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.Expedientesasociados_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Expedientesasociados_datagridview.DefaultCellStyle = DataGridViewCellStyle6
        Me.Expedientesasociados_datagridview.Location = New System.Drawing.Point(0, 49)
        Me.Expedientesasociados_datagridview.Name = "Expedientesasociados_datagridview"
        Me.Expedientesasociados_datagridview.RowHeadersVisible = False
        Me.Expedientesasociados_datagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Expedientesasociados_datagridview.Size = New System.Drawing.Size(387, 259)
        Me.Expedientesasociados_datagridview.TabIndex = 99
        Me.Expedientesasociados_datagridview.VirtualMode = True
        '
        'ElementHost1
        '
        Me.ElementHost1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ElementHost1.Enabled = False
        Me.ElementHost1.Location = New System.Drawing.Point(278, 20)
        Me.ElementHost1.Name = "ElementHost1"
        Me.ElementHost1.Size = New System.Drawing.Size(185, 29)
        Me.ElementHost1.TabIndex = 30
        Me.ElementHost1.Text = "ElementHost1"
        Me.ElementHost1.Child = Me.Pedidodefondosmontowpf
        '
        'ExpedientesNOasociados_datagridview
        '
        Me.ExpedientesNOasociados_datagridview.AllowUserToAddRows = False
        Me.ExpedientesNOasociados_datagridview.AllowUserToDeleteRows = False
        Me.ExpedientesNOasociados_datagridview.AllowUserToOrderColumns = True
        DataGridViewCellStyle7.NullValue = Nothing
        Me.ExpedientesNOasociados_datagridview.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.ExpedientesNOasociados_datagridview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExpedientesNOasociados_datagridview.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.ExpedientesNOasociados_datagridview.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ExpedientesNOasociados_datagridview.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.ExpedientesNOasociados_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ExpedientesNOasociados_datagridview.DefaultCellStyle = DataGridViewCellStyle9
        Me.ExpedientesNOasociados_datagridview.Location = New System.Drawing.Point(66, 51)
        Me.ExpedientesNOasociados_datagridview.Name = "ExpedientesNOasociados_datagridview"
        Me.ExpedientesNOasociados_datagridview.ReadOnly = True
        Me.ExpedientesNOasociados_datagridview.RowHeadersVisible = False
        Me.ExpedientesNOasociados_datagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ExpedientesNOasociados_datagridview.Size = New System.Drawing.Size(393, 295)
        Me.ExpedientesNOasociados_datagridview.TabIndex = 102
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(0, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 668)
        Me.Splitter1.TabIndex = 103
        Me.Splitter1.TabStop = False
        '
        'DirectorySearcher1
        '
        Me.DirectorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01")
        '
        'Tesoreria_Pedidofondos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(943, 668)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.splitContainerGeneral)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Tesoreria_Pedidofondos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Pedidofondos"
        Me.splitContainerGeneral.Panel1.ResumeLayout(False)
        Me.splitContainerGeneral.Panel2.ResumeLayout(False)
        CType(Me.splitContainerGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitContainerGeneral.ResumeLayout(False)
        Me.PanelDatos_pedidofondo.ResumeLayout(False)
        Me.PanelDatos_pedidofondo.PerformLayout()
        CType(Me.Datosspedidofondo_datagridview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panelnuevopedido.ResumeLayout(False)
        Me.Panelnuevopedido.PerformLayout()
        CType(Me.Organismo_textbox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Year_expediente_textbox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Year_pedidofondo_numeric, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Expte_numero_numericupdown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.N_pedidofondo_numeric, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.Panel2.PerformLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.Expedientesasociados_datagridview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExpedientesNOasociados_datagridview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents Label7 As Label
    Friend WithEvents Busqueda As TextBox
    Friend WithEvents Boton_borrar As Button
    Friend WithEvents Label_expedienteasociados As Label
    Friend WithEvents BusquedaexpedientesNOasociados_textbox As TextBox
    Friend WithEvents Labelexpedientessinasociar As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Asociarexpediente_boton As Button
    Friend WithEvents Quitarasociacion_boton As Button
    Friend WithEvents Generarpedidodefondo_boton As Button
    Friend WithEvents Botonbusquedaexpedientessinasociar As Button
    Friend WithEvents Botonbusquedaexpedientesasociados As Button
    Friend WithEvents ElementHost1 As Integration.ElementHost
    Friend Pedidodefondosmontowpf As Control_currency_textboxWPF
    Friend WithEvents Busquedaexpedientesasociados_textbox As TextBox
    Friend WithEvents Boton_Nuevo As Button
    Friend WithEvents Boton_Modificar As Button
    Friend WithEvents splitContainerGeneral As SplitContainer
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents Label1 As Label
    Friend WithEvents PanelDatos_pedidofondo As Panel
    Friend WithEvents Panelnuevopedido As Panel
    Friend WithEvents Pedidoparcialcheckbox As CheckBox
    Friend WithEvents Organismo_textbox As NumericUpDown
    Friend WithEvents Year_expediente_textbox As NumericUpDown
    Friend WithEvents Label_MontoSolicitado As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Organismolabel As Label
    Friend WithEvents Numero_cuentalabel As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Year_pedidofondo_numeric As NumericUpDown
    Friend WithEvents Fecha_pedido_textbox As DateTimePicker
    Friend WithEvents Cuentas_combobox As ComboBox
    Friend WithEvents Descripcion_textbox As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Expte_numero_numericupdown As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Cuenta_label As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Clasefondo_textbox As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents N_pedidofondo_numeric As NumericUpDown
    Friend WithEvents Label14 As Label
    Friend WithEvents Pedidohaberes_checkbox As CheckBox
    Friend WithEvents ExpedientesNOasociados_datagridview As Flicker_Datagridview
    Friend WithEvents Datosspedidofondo_datagridview As Flicker_Datagridview
    Friend WithEvents Expedientesasociados_datagridview As Flicker_Datagridview
    Friend WithEvents DirectorySearcher1 As DirectoryServices.DirectorySearcher
    Friend WithEvents Refresh_boton As Button
End Class
