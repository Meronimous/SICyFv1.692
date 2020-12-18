<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Control_Movimiento_MFyV
    Inherits System.Windows.Forms.UserControl
    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Control_Movimiento_MFyV))
        Me.TableLayout_movimientos = New SICyF.Flicker_Tablelayout(Me.components)
        Me.Panel_datosmovimiento = New SICyF.PANEL_sinFlicker()
        Me.Panel_Formulario = New SICyF.PANEL_sinFlicker()
        Me.Tipodemovimiento_label = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Detalle_textbox = New System.Windows.Forms.TextBox()
        Me.Monto_factura_textbox = New SICyF.Flicker_Numericcontrol_Dinero()
        Me.Label_montonombre = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New SICyF.Flicker_Tablelayout(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Cuitdelbeneficiario_textbox = New System.Windows.Forms.MaskedTextBox()
        Me.Beneficiario_label = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Movimientofecha_calendar = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Nrotransferencia_textbox = New SICyF.Flicker_Numericcontrol_Numero()
        Me.Ordendeentregayear_integerupdown = New SICyF.Flicker_Numericcontrol_Numero()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Orden_label = New System.Windows.Forms.Label()
        Me.Ordendeentrega_integerupdown = New SICyF.Flicker_Numericcontrol_Numero()
        Me.Panel_botones = New SICyF.PANEL_sinFlicker()
        Me.TableLayout_MFyV = New SICyF.Flicker_Tablelayout(Me.components)
        Me.LabelClasefondo = New System.Windows.Forms.Label()
        Me.Label_Codorden = New System.Windows.Forms.Label()
        Me.Label_Codimp = New System.Windows.Forms.Label()
        Me.TableLayout_botones = New SICyF.Flicker_Tablelayout(Me.components)
        Me.TableLayoutPanel5 = New SICyF.Flicker_Tablelayout(Me.components)
        Me.Codigoimputacion9 = New System.Windows.Forms.Button()
        Me.Codigoimputacion4 = New System.Windows.Forms.Button()
        Me.Codigoimputacion3 = New System.Windows.Forms.Button()
        Me.Codigoimputacion2 = New System.Windows.Forms.Button()
        Me.Codigoimputacion1 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel4 = New SICyF.Flicker_Tablelayout(Me.components)
        Me.Clasefondo9 = New System.Windows.Forms.Button()
        Me.Clasefondo2 = New System.Windows.Forms.Button()
        Me.Clasefondo1 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel3 = New SICyF.Flicker_Tablelayout(Me.components)
        Me.COD__ORDEN9 = New System.Windows.Forms.Button()
        Me.COD__ORDEN5 = New System.Windows.Forms.Button()
        Me.COD__ORDEN4 = New System.Windows.Forms.Button()
        Me.COD__ORDEN3 = New System.Windows.Forms.Button()
        Me.COD__ORDEN2 = New System.Windows.Forms.Button()
        Me.COD__ORDEN1 = New System.Windows.Forms.Button()
        Me.Tipo_movimiento_boton = New System.Windows.Forms.Button()
        Me.Cargartotalfactura = New System.Windows.Forms.Button()
        Me.Botonaceptar_button = New System.Windows.Forms.Button()
        Me.Modificar_boton = New System.Windows.Forms.Button()
        Me.Borrar_boton = New System.Windows.Forms.Button()
        Me.Cuit_boton = New System.Windows.Forms.Button()
        Me.Constancia_Boton = New System.Windows.Forms.Button()
        Me.Candado_fechaboton = New System.Windows.Forms.Button()
        Me.TableLayout_movimientos.SuspendLayout()
        Me.Panel_datosmovimiento.SuspendLayout()
        Me.Panel_Formulario.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Monto_factura_textbox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Nrotransferencia_textbox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ordendeentregayear_integerupdown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ordendeentrega_integerupdown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_botones.SuspendLayout()
        Me.TableLayout_MFyV.SuspendLayout()
        Me.TableLayout_botones.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayout_movimientos
        '
        Me.TableLayout_movimientos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayout_movimientos.ColumnCount = 2
        Me.TableLayout_movimientos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280.0!))
        Me.TableLayout_movimientos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayout_movimientos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayout_movimientos.Controls.Add(Me.Panel_datosmovimiento, 1, 0)
        Me.TableLayout_movimientos.Controls.Add(Me.Panel_botones, 0, 0)
        Me.TableLayout_movimientos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayout_movimientos.Location = New System.Drawing.Point(0, 0)
        Me.TableLayout_movimientos.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayout_movimientos.Name = "TableLayout_movimientos"
        Me.TableLayout_movimientos.RowCount = 1
        Me.TableLayout_movimientos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayout_movimientos.Size = New System.Drawing.Size(645, 410)
        Me.TableLayout_movimientos.TabIndex = 1
        '
        'Panel_datosmovimiento
        '
        Me.Panel_datosmovimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_datosmovimiento.Controls.Add(Me.Panel_Formulario)
        Me.Panel_datosmovimiento.Location = New System.Drawing.Point(280, 0)
        Me.Panel_datosmovimiento.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel_datosmovimiento.Name = "Panel_datosmovimiento"
        Me.Panel_datosmovimiento.Size = New System.Drawing.Size(365, 407)
        Me.Panel_datosmovimiento.TabIndex = 2
        '
        'Panel_Formulario
        '
        Me.Panel_Formulario.BackColor = System.Drawing.Color.SkyBlue
        Me.Panel_Formulario.Controls.Add(Me.Tipodemovimiento_label)
        Me.Panel_Formulario.Controls.Add(Me.Tipo_movimiento_boton)
        Me.Panel_Formulario.Controls.Add(Me.GroupBox3)
        Me.Panel_Formulario.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel_Formulario.Controls.Add(Me.GroupBox2)
        Me.Panel_Formulario.Controls.Add(Me.GroupBox1)
        Me.Panel_Formulario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_Formulario.Location = New System.Drawing.Point(0, 0)
        Me.Panel_Formulario.Name = "Panel_Formulario"
        Me.Panel_Formulario.Size = New System.Drawing.Size(363, 405)
        Me.Panel_Formulario.TabIndex = 134
        '
        'Tipodemovimiento_label
        '
        Me.Tipodemovimiento_label.BackColor = System.Drawing.Color.SkyBlue
        Me.Tipodemovimiento_label.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tipodemovimiento_label.ForeColor = System.Drawing.Color.Black
        Me.Tipodemovimiento_label.Location = New System.Drawing.Point(149, 260)
        Me.Tipodemovimiento_label.Margin = New System.Windows.Forms.Padding(0)
        Me.Tipodemovimiento_label.Name = "Tipodemovimiento_label"
        Me.Tipodemovimiento_label.Size = New System.Drawing.Size(226, 18)
        Me.Tipodemovimiento_label.TabIndex = 118
        Me.Tipodemovimiento_label.Text = "Normal"
        Me.Tipodemovimiento_label.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.SkyBlue
        Me.GroupBox3.Controls.Add(Me.Detalle_textbox)
        Me.GroupBox3.Controls.Add(Me.Cargartotalfactura)
        Me.GroupBox3.Controls.Add(Me.Monto_factura_textbox)
        Me.GroupBox3.Controls.Add(Me.Label_montonombre)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(5, 161)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox3.Size = New System.Drawing.Size(370, 100)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Descripción"
        '
        'Detalle_textbox
        '
        Me.Detalle_textbox.BackColor = System.Drawing.Color.White
        Me.Detalle_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Detalle_textbox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Detalle_textbox.ForeColor = System.Drawing.Color.Black
        Me.Detalle_textbox.Location = New System.Drawing.Point(24, 18)
        Me.Detalle_textbox.Margin = New System.Windows.Forms.Padding(0)
        Me.Detalle_textbox.Multiline = True
        Me.Detalle_textbox.Name = "Detalle_textbox"
        Me.Detalle_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Detalle_textbox.Size = New System.Drawing.Size(331, 49)
        Me.Detalle_textbox.TabIndex = 6
        '
        'Monto_factura_textbox
        '
        Me.Monto_factura_textbox.BackColor = System.Drawing.Color.White
        Me.Monto_factura_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Monto_factura_textbox.DecimalPlaces = 2
        Me.Monto_factura_textbox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Monto_factura_textbox.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.Monto_factura_textbox.Location = New System.Drawing.Point(137, 70)
        Me.Monto_factura_textbox.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 131072})
        Me.Monto_factura_textbox.Minimum = New Decimal(New Integer() {1316134911, 2328, 0, -2147352576})
        Me.Monto_factura_textbox.Name = "Monto_factura_textbox"
        Me.Monto_factura_textbox.Size = New System.Drawing.Size(181, 25)
        Me.Monto_factura_textbox.Suffix = Nothing
        Me.Monto_factura_textbox.TabIndex = 7
        Me.Monto_factura_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Monto_factura_textbox.ThousandsSeparator = True
        '
        'Label_montonombre
        '
        Me.Label_montonombre.AutoSize = True
        Me.Label_montonombre.BackColor = System.Drawing.Color.Transparent
        Me.Label_montonombre.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_montonombre.ForeColor = System.Drawing.Color.Black
        Me.Label_montonombre.Location = New System.Drawing.Point(12, 70)
        Me.Label_montonombre.Margin = New System.Windows.Forms.Padding(0)
        Me.Label_montonombre.Name = "Label_montonombre"
        Me.Label_montonombre.Size = New System.Drawing.Size(127, 15)
        Me.Label_montonombre.TabIndex = 125
        Me.Label_montonombre.Text = "Monto de la Factura $"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.Controls.Add(Me.Botonaceptar_button, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Modificar_boton, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Borrar_boton, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 365)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(363, 40)
        Me.TableLayoutPanel2.TabIndex = 56
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.SkyBlue
        Me.GroupBox2.Controls.Add(Me.Cuitdelbeneficiario_textbox)
        Me.GroupBox2.Controls.Add(Me.Beneficiario_label)
        Me.GroupBox2.Controls.Add(Me.Cuit_boton)
        Me.GroupBox2.Controls.Add(Me.Constancia_Boton)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 67)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox2.Size = New System.Drawing.Size(370, 95)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "CUIT"
        '
        'Cuitdelbeneficiario_textbox
        '
        Me.Cuitdelbeneficiario_textbox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cuitdelbeneficiario_textbox.Location = New System.Drawing.Point(24, 15)
        Me.Cuitdelbeneficiario_textbox.Mask = "00-00000000-0"
        Me.Cuitdelbeneficiario_textbox.Name = "Cuitdelbeneficiario_textbox"
        Me.Cuitdelbeneficiario_textbox.Size = New System.Drawing.Size(159, 29)
        Me.Cuitdelbeneficiario_textbox.TabIndex = 4
        Me.Cuitdelbeneficiario_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Beneficiario_label
        '
        Me.Beneficiario_label.BackColor = System.Drawing.Color.SkyBlue
        Me.Beneficiario_label.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Beneficiario_label.ForeColor = System.Drawing.Color.Indigo
        Me.Beneficiario_label.Location = New System.Drawing.Point(4, 44)
        Me.Beneficiario_label.Margin = New System.Windows.Forms.Padding(0)
        Me.Beneficiario_label.Name = "Beneficiario_label"
        Me.Beneficiario_label.Size = New System.Drawing.Size(351, 19)
        Me.Beneficiario_label.TabIndex = 117
        Me.Beneficiario_label.Text = "-"
        Me.Beneficiario_label.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.SkyBlue
        Me.GroupBox1.Controls.Add(Me.Movimientofecha_calendar)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Nrotransferencia_textbox)
        Me.GroupBox1.Controls.Add(Me.Candado_fechaboton)
        Me.GroupBox1.Controls.Add(Me.Ordendeentregayear_integerupdown)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Orden_label)
        Me.GroupBox1.Controls.Add(Me.Ordendeentrega_integerupdown)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(5, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox1.Size = New System.Drawing.Size(370, 67)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Transferencia"
        '
        'Movimientofecha_calendar
        '
        Me.Movimientofecha_calendar.CalendarFont = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Movimientofecha_calendar.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Movimientofecha_calendar.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Movimientofecha_calendar.Location = New System.Drawing.Point(207, 12)
        Me.Movimientofecha_calendar.Name = "Movimientofecha_calendar"
        Me.Movimientofecha_calendar.Size = New System.Drawing.Size(113, 25)
        Me.Movimientofecha_calendar.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(162, 17)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 15)
        Me.Label6.TabIndex = 117
        Me.Label6.Text = "Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(0, 11)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 15)
        Me.Label2.TabIndex = 116
        Me.Label2.Text = "Nº"
        '
        'Nrotransferencia_textbox
        '
        Me.Nrotransferencia_textbox.BackColor = System.Drawing.Color.White
        Me.Nrotransferencia_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Nrotransferencia_textbox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Nrotransferencia_textbox.ForeColor = System.Drawing.Color.Black
        Me.Nrotransferencia_textbox.Location = New System.Drawing.Point(21, 14)
        Me.Nrotransferencia_textbox.Margin = New System.Windows.Forms.Padding(0)
        Me.Nrotransferencia_textbox.Maximum = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.Nrotransferencia_textbox.Name = "Nrotransferencia_textbox"
        Me.Nrotransferencia_textbox.Size = New System.Drawing.Size(141, 25)
        Me.Nrotransferencia_textbox.Suffix = Nothing
        Me.Nrotransferencia_textbox.TabIndex = 0
        Me.Nrotransferencia_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Ordendeentregayear_integerupdown
        '
        Me.Ordendeentregayear_integerupdown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Ordendeentregayear_integerupdown.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Ordendeentregayear_integerupdown.Location = New System.Drawing.Point(295, 39)
        Me.Ordendeentregayear_integerupdown.Maximum = New Decimal(New Integer() {2200, 0, 0, 0})
        Me.Ordendeentregayear_integerupdown.Name = "Ordendeentregayear_integerupdown"
        Me.Ordendeentregayear_integerupdown.Size = New System.Drawing.Size(60, 23)
        Me.Ordendeentregayear_integerupdown.Suffix = Nothing
        Me.Ordendeentregayear_integerupdown.TabIndex = 3
        Me.Ordendeentregayear_integerupdown.ThousandsSeparator = True
        Me.Ordendeentregayear_integerupdown.Value = New Decimal(New Integer() {2000, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(282, 43)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 15)
        Me.Label3.TabIndex = 116
        Me.Label3.Text = "/"
        '
        'Orden_label
        '
        Me.Orden_label.BackColor = System.Drawing.Color.SkyBlue
        Me.Orden_label.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Orden_label.ForeColor = System.Drawing.Color.Black
        Me.Orden_label.Location = New System.Drawing.Point(27, 41)
        Me.Orden_label.Margin = New System.Windows.Forms.Padding(0)
        Me.Orden_label.Name = "Orden_label"
        Me.Orden_label.Size = New System.Drawing.Size(169, 23)
        Me.Orden_label.TabIndex = 115
        Me.Orden_label.Text = "Orden "
        Me.Orden_label.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Ordendeentrega_integerupdown
        '
        Me.Ordendeentrega_integerupdown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Ordendeentrega_integerupdown.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Ordendeentrega_integerupdown.Location = New System.Drawing.Point(207, 38)
        Me.Ordendeentrega_integerupdown.Margin = New System.Windows.Forms.Padding(0)
        Me.Ordendeentrega_integerupdown.Maximum = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.Ordendeentrega_integerupdown.Name = "Ordendeentrega_integerupdown"
        Me.Ordendeentrega_integerupdown.Size = New System.Drawing.Size(75, 23)
        Me.Ordendeentrega_integerupdown.Suffix = Nothing
        Me.Ordendeentrega_integerupdown.TabIndex = 2
        Me.Ordendeentrega_integerupdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Ordendeentrega_integerupdown.ThousandsSeparator = True
        '
        'Panel_botones
        '
        Me.Panel_botones.Controls.Add(Me.TableLayout_MFyV)
        Me.Panel_botones.Controls.Add(Me.TableLayout_botones)
        Me.Panel_botones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_botones.Location = New System.Drawing.Point(3, 3)
        Me.Panel_botones.Name = "Panel_botones"
        Me.Panel_botones.Size = New System.Drawing.Size(274, 404)
        Me.Panel_botones.TabIndex = 1
        '
        'TableLayout_MFyV
        '
        Me.TableLayout_MFyV.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayout_MFyV.ColumnCount = 3
        Me.TableLayout_MFyV.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayout_MFyV.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayout_MFyV.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayout_MFyV.Controls.Add(Me.LabelClasefondo, 1, 0)
        Me.TableLayout_MFyV.Controls.Add(Me.Label_Codorden, 0, 0)
        Me.TableLayout_MFyV.Controls.Add(Me.Label_Codimp, 2, 0)
        Me.TableLayout_MFyV.Location = New System.Drawing.Point(0, 378)
        Me.TableLayout_MFyV.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayout_MFyV.Name = "TableLayout_MFyV"
        Me.TableLayout_MFyV.RowCount = 1
        Me.TableLayout_MFyV.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayout_MFyV.Size = New System.Drawing.Size(274, 26)
        Me.TableLayout_MFyV.TabIndex = 115
        '
        'LabelClasefondo
        '
        Me.LabelClasefondo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelClasefondo.AutoSize = True
        Me.LabelClasefondo.BackColor = System.Drawing.Color.Transparent
        Me.LabelClasefondo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelClasefondo.ForeColor = System.Drawing.Color.Black
        Me.LabelClasefondo.Location = New System.Drawing.Point(91, 0)
        Me.LabelClasefondo.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelClasefondo.Name = "LabelClasefondo"
        Me.LabelClasefondo.Size = New System.Drawing.Size(91, 26)
        Me.LabelClasefondo.TabIndex = 120
        Me.LabelClasefondo.Text = "-"
        Me.LabelClasefondo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Codorden
        '
        Me.Label_Codorden.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_Codorden.AutoSize = True
        Me.Label_Codorden.BackColor = System.Drawing.Color.Transparent
        Me.Label_Codorden.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Codorden.ForeColor = System.Drawing.Color.Black
        Me.Label_Codorden.Location = New System.Drawing.Point(0, 0)
        Me.Label_Codorden.Margin = New System.Windows.Forms.Padding(0)
        Me.Label_Codorden.Name = "Label_Codorden"
        Me.Label_Codorden.Size = New System.Drawing.Size(91, 26)
        Me.Label_Codorden.TabIndex = 119
        Me.Label_Codorden.Text = "-"
        Me.Label_Codorden.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Codimp
        '
        Me.Label_Codimp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_Codimp.AutoSize = True
        Me.Label_Codimp.BackColor = System.Drawing.Color.Transparent
        Me.Label_Codimp.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Codimp.ForeColor = System.Drawing.Color.Black
        Me.Label_Codimp.Location = New System.Drawing.Point(182, 0)
        Me.Label_Codimp.Margin = New System.Windows.Forms.Padding(0)
        Me.Label_Codimp.Name = "Label_Codimp"
        Me.Label_Codimp.Size = New System.Drawing.Size(92, 26)
        Me.Label_Codimp.TabIndex = 118
        Me.Label_Codimp.Text = "-"
        Me.Label_Codimp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayout_botones
        '
        Me.TableLayout_botones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayout_botones.BackColor = System.Drawing.Color.LightCyan
        Me.TableLayout_botones.ColumnCount = 3
        Me.TableLayout_botones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayout_botones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayout_botones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.0!))
        Me.TableLayout_botones.Controls.Add(Me.TableLayoutPanel5, 2, 0)
        Me.TableLayout_botones.Controls.Add(Me.TableLayoutPanel4, 1, 0)
        Me.TableLayout_botones.Controls.Add(Me.TableLayoutPanel3, 0, 0)
        Me.TableLayout_botones.Location = New System.Drawing.Point(3, 3)
        Me.TableLayout_botones.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayout_botones.Name = "TableLayout_botones"
        Me.TableLayout_botones.RowCount = 1
        Me.TableLayout_botones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayout_botones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 299.0!))
        Me.TableLayout_botones.Size = New System.Drawing.Size(271, 304)
        Me.TableLayout_botones.TabIndex = 0
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.Codigoimputacion9, 0, 4)
        Me.TableLayoutPanel5.Controls.Add(Me.Codigoimputacion4, 0, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.Codigoimputacion3, 0, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.Codigoimputacion2, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.Codigoimputacion1, 0, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(178, 0)
        Me.TableLayoutPanel5.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 5
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(93, 304)
        Me.TableLayoutPanel5.TabIndex = 2
        '
        'Codigoimputacion9
        '
        Me.Codigoimputacion9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Codigoimputacion9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Codigoimputacion9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Codigoimputacion9.Location = New System.Drawing.Point(0, 240)
        Me.Codigoimputacion9.Margin = New System.Windows.Forms.Padding(0)
        Me.Codigoimputacion9.Name = "Codigoimputacion9"
        Me.Codigoimputacion9.Size = New System.Drawing.Size(93, 64)
        Me.Codigoimputacion9.TabIndex = 5
        Me.Codigoimputacion9.Text = "9-Ingreso por Recaudación Propia"
        Me.Codigoimputacion9.UseVisualStyleBackColor = True
        '
        'Codigoimputacion4
        '
        Me.Codigoimputacion4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Codigoimputacion4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Codigoimputacion4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Codigoimputacion4.Location = New System.Drawing.Point(0, 180)
        Me.Codigoimputacion4.Margin = New System.Windows.Forms.Padding(0)
        Me.Codigoimputacion4.Name = "Codigoimputacion4"
        Me.Codigoimputacion4.Size = New System.Drawing.Size(93, 60)
        Me.Codigoimputacion4.TabIndex = 4
        Me.Codigoimputacion4.Text = "4-Reintegro"
        Me.Codigoimputacion4.UseVisualStyleBackColor = True
        '
        'Codigoimputacion3
        '
        Me.Codigoimputacion3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Codigoimputacion3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Codigoimputacion3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Codigoimputacion3.Location = New System.Drawing.Point(0, 120)
        Me.Codigoimputacion3.Margin = New System.Windows.Forms.Padding(0)
        Me.Codigoimputacion3.Name = "Codigoimputacion3"
        Me.Codigoimputacion3.Size = New System.Drawing.Size(93, 60)
        Me.Codigoimputacion3.TabIndex = 3
        Me.Codigoimputacion3.Text = "3-Ingresos"
        Me.Codigoimputacion3.UseVisualStyleBackColor = True
        '
        'Codigoimputacion2
        '
        Me.Codigoimputacion2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Codigoimputacion2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Codigoimputacion2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Codigoimputacion2.Location = New System.Drawing.Point(0, 60)
        Me.Codigoimputacion2.Margin = New System.Windows.Forms.Padding(0)
        Me.Codigoimputacion2.Name = "Codigoimputacion2"
        Me.Codigoimputacion2.Size = New System.Drawing.Size(93, 60)
        Me.Codigoimputacion2.TabIndex = 2
        Me.Codigoimputacion2.Text = "2-Rendición"
        Me.Codigoimputacion2.UseVisualStyleBackColor = True
        '
        'Codigoimputacion1
        '
        Me.Codigoimputacion1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Codigoimputacion1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Codigoimputacion1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Codigoimputacion1.Location = New System.Drawing.Point(0, 0)
        Me.Codigoimputacion1.Margin = New System.Windows.Forms.Padding(0)
        Me.Codigoimputacion1.Name = "Codigoimputacion1"
        Me.Codigoimputacion1.Size = New System.Drawing.Size(93, 60)
        Me.Codigoimputacion1.TabIndex = 1
        Me.Codigoimputacion1.Text = "1-Salida de Fondos"
        Me.Codigoimputacion1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Clasefondo9, 0, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.Clasefondo2, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Clasefondo1, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(89, 0)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 3
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(89, 304)
        Me.TableLayoutPanel4.TabIndex = 1
        '
        'Clasefondo9
        '
        Me.Clasefondo9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Clasefondo9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Clasefondo9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Clasefondo9.Location = New System.Drawing.Point(0, 202)
        Me.Clasefondo9.Margin = New System.Windows.Forms.Padding(0)
        Me.Clasefondo9.Name = "Clasefondo9"
        Me.Clasefondo9.Size = New System.Drawing.Size(89, 102)
        Me.Clasefondo9.TabIndex = 3
        Me.Clasefondo9.Text = "9-Residuos Pasivos"
        Me.Clasefondo9.UseVisualStyleBackColor = True
        '
        'Clasefondo2
        '
        Me.Clasefondo2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Clasefondo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Clasefondo2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Clasefondo2.Location = New System.Drawing.Point(0, 101)
        Me.Clasefondo2.Margin = New System.Windows.Forms.Padding(0)
        Me.Clasefondo2.Name = "Clasefondo2"
        Me.Clasefondo2.Size = New System.Drawing.Size(89, 101)
        Me.Clasefondo2.TabIndex = 2
        Me.Clasefondo2.Text = "2-Fondos Especiales"
        Me.Clasefondo2.UseVisualStyleBackColor = True
        '
        'Clasefondo1
        '
        Me.Clasefondo1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Clasefondo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Clasefondo1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Clasefondo1.Location = New System.Drawing.Point(0, 0)
        Me.Clasefondo1.Margin = New System.Windows.Forms.Padding(0)
        Me.Clasefondo1.Name = "Clasefondo1"
        Me.Clasefondo1.Size = New System.Drawing.Size(89, 101)
        Me.Clasefondo1.TabIndex = 1
        Me.Clasefondo1.Text = "1-Fondos Permanentes"
        Me.Clasefondo1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.COD__ORDEN9, 0, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.COD__ORDEN5, 0, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.COD__ORDEN4, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.COD__ORDEN3, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.COD__ORDEN2, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.COD__ORDEN1, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 6
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(89, 304)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'COD__ORDEN9
        '
        Me.COD__ORDEN9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.COD__ORDEN9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.COD__ORDEN9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.COD__ORDEN9.Location = New System.Drawing.Point(0, 250)
        Me.COD__ORDEN9.Margin = New System.Windows.Forms.Padding(0)
        Me.COD__ORDEN9.Name = "COD__ORDEN9"
        Me.COD__ORDEN9.Size = New System.Drawing.Size(89, 54)
        Me.COD__ORDEN9.TabIndex = 5
        Me.COD__ORDEN9.Text = "9-Doc y/o Nº Planilla Rec. Ingresos"
        Me.COD__ORDEN9.UseVisualStyleBackColor = True
        '
        'COD__ORDEN5
        '
        Me.COD__ORDEN5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.COD__ORDEN5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.COD__ORDEN5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.COD__ORDEN5.Location = New System.Drawing.Point(0, 200)
        Me.COD__ORDEN5.Margin = New System.Windows.Forms.Padding(0)
        Me.COD__ORDEN5.Name = "COD__ORDEN5"
        Me.COD__ORDEN5.Size = New System.Drawing.Size(89, 50)
        Me.COD__ORDEN5.TabIndex = 4
        Me.COD__ORDEN5.Text = "5-Descuento o Crédito Bancario"
        Me.COD__ORDEN5.UseVisualStyleBackColor = True
        '
        'COD__ORDEN4
        '
        Me.COD__ORDEN4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.COD__ORDEN4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.COD__ORDEN4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.COD__ORDEN4.Location = New System.Drawing.Point(0, 150)
        Me.COD__ORDEN4.Margin = New System.Windows.Forms.Padding(0)
        Me.COD__ORDEN4.Name = "COD__ORDEN4"
        Me.COD__ORDEN4.Size = New System.Drawing.Size(89, 50)
        Me.COD__ORDEN4.TabIndex = 3
        Me.COD__ORDEN4.Text = "4-Transferencia"
        Me.COD__ORDEN4.UseVisualStyleBackColor = True
        '
        'COD__ORDEN3
        '
        Me.COD__ORDEN3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.COD__ORDEN3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.COD__ORDEN3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.COD__ORDEN3.Location = New System.Drawing.Point(0, 100)
        Me.COD__ORDEN3.Margin = New System.Windows.Forms.Padding(0)
        Me.COD__ORDEN3.Name = "COD__ORDEN3"
        Me.COD__ORDEN3.Size = New System.Drawing.Size(89, 50)
        Me.COD__ORDEN3.TabIndex = 2
        Me.COD__ORDEN3.Text = "3-Compra directa /" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Contado"
        Me.COD__ORDEN3.UseVisualStyleBackColor = True
        '
        'COD__ORDEN2
        '
        Me.COD__ORDEN2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.COD__ORDEN2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.COD__ORDEN2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.COD__ORDEN2.Location = New System.Drawing.Point(0, 50)
        Me.COD__ORDEN2.Margin = New System.Windows.Forms.Padding(0)
        Me.COD__ORDEN2.Name = "COD__ORDEN2"
        Me.COD__ORDEN2.Size = New System.Drawing.Size(89, 50)
        Me.COD__ORDEN2.TabIndex = 1
        Me.COD__ORDEN2.Text = "2-Orden de Cargo"
        Me.COD__ORDEN2.UseVisualStyleBackColor = True
        '
        'COD__ORDEN1
        '
        Me.COD__ORDEN1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.COD__ORDEN1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.COD__ORDEN1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.COD__ORDEN1.Location = New System.Drawing.Point(0, 0)
        Me.COD__ORDEN1.Margin = New System.Windows.Forms.Padding(0)
        Me.COD__ORDEN1.Name = "COD__ORDEN1"
        Me.COD__ORDEN1.Size = New System.Drawing.Size(89, 50)
        Me.COD__ORDEN1.TabIndex = 0
        Me.COD__ORDEN1.Text = "1-Orden de pago"
        Me.COD__ORDEN1.UseVisualStyleBackColor = True
        '
        'Tipo_movimiento_boton
        '
        Me.Tipo_movimiento_boton.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Tipo_movimiento_boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Tipo_movimiento_boton.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Tipo_movimiento_boton.ForeColor = System.Drawing.Color.White
        Me.Tipo_movimiento_boton.Image = CType(resources.GetObject("Tipo_movimiento_boton.Image"), System.Drawing.Image)
        Me.Tipo_movimiento_boton.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Tipo_movimiento_boton.Location = New System.Drawing.Point(-1, 259)
        Me.Tipo_movimiento_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Tipo_movimiento_boton.Name = "Tipo_movimiento_boton"
        Me.Tipo_movimiento_boton.Size = New System.Drawing.Size(145, 23)
        Me.Tipo_movimiento_boton.TabIndex = 57
        Me.Tipo_movimiento_boton.Text = "Tipo de Movimiento"
        Me.Tipo_movimiento_boton.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Tipo_movimiento_boton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.Tipo_movimiento_boton.UseVisualStyleBackColor = False
        '
        'Cargartotalfactura
        '
        Me.Cargartotalfactura.BackColor = System.Drawing.Color.Transparent
        Me.Cargartotalfactura.BackgroundImage = CType(resources.GetObject("Cargartotalfactura.BackgroundImage"), System.Drawing.Image)
        Me.Cargartotalfactura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Cargartotalfactura.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cargartotalfactura.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cargartotalfactura.ForeColor = System.Drawing.Color.Black
        Me.Cargartotalfactura.Location = New System.Drawing.Point(326, 70)
        Me.Cargartotalfactura.Margin = New System.Windows.Forms.Padding(0)
        Me.Cargartotalfactura.Name = "Cargartotalfactura"
        Me.Cargartotalfactura.Size = New System.Drawing.Size(29, 26)
        Me.Cargartotalfactura.TabIndex = 137
        Me.Cargartotalfactura.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Cargartotalfactura.UseVisualStyleBackColor = False
        '
        'Botonaceptar_button
        '
        Me.Botonaceptar_button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Botonaceptar_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Botonaceptar_button.Font = New System.Drawing.Font("Raleway Light", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Botonaceptar_button.Image = CType(resources.GetObject("Botonaceptar_button.Image"), System.Drawing.Image)
        Me.Botonaceptar_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Botonaceptar_button.Location = New System.Drawing.Point(0, 0)
        Me.Botonaceptar_button.Margin = New System.Windows.Forms.Padding(0)
        Me.Botonaceptar_button.Name = "Botonaceptar_button"
        Me.Botonaceptar_button.Size = New System.Drawing.Size(121, 40)
        Me.Botonaceptar_button.TabIndex = 10
        Me.Botonaceptar_button.Text = "Nuevo"
        Me.Botonaceptar_button.UseVisualStyleBackColor = True
        '
        'Modificar_boton
        '
        Me.Modificar_boton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Modificar_boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Modificar_boton.Font = New System.Drawing.Font("Raleway Light", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Modificar_boton.Image = CType(resources.GetObject("Modificar_boton.Image"), System.Drawing.Image)
        Me.Modificar_boton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Modificar_boton.Location = New System.Drawing.Point(121, 0)
        Me.Modificar_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Modificar_boton.Name = "Modificar_boton"
        Me.Modificar_boton.Size = New System.Drawing.Size(121, 40)
        Me.Modificar_boton.TabIndex = 11
        Me.Modificar_boton.Text = "Modificar seleccionado"
        Me.Modificar_boton.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.Modificar_boton.UseVisualStyleBackColor = True
        '
        'Borrar_boton
        '
        Me.Borrar_boton.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Borrar_boton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Borrar_boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Borrar_boton.Font = New System.Drawing.Font("Raleway Light", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Borrar_boton.Image = CType(resources.GetObject("Borrar_boton.Image"), System.Drawing.Image)
        Me.Borrar_boton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Borrar_boton.Location = New System.Drawing.Point(242, 0)
        Me.Borrar_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Borrar_boton.Name = "Borrar_boton"
        Me.Borrar_boton.Size = New System.Drawing.Size(121, 40)
        Me.Borrar_boton.TabIndex = 12
        Me.Borrar_boton.Text = "Borrar"
        Me.Borrar_boton.UseVisualStyleBackColor = False
        '
        'Cuit_boton
        '
        Me.Cuit_boton.BackColor = System.Drawing.Color.White
        Me.Cuit_boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cuit_boton.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cuit_boton.ForeColor = System.Drawing.Color.ForestGreen
        Me.Cuit_boton.Image = CType(resources.GetObject("Cuit_boton.Image"), System.Drawing.Image)
        Me.Cuit_boton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cuit_boton.Location = New System.Drawing.Point(207, 15)
        Me.Cuit_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Cuit_boton.Name = "Cuit_boton"
        Me.Cuit_boton.Size = New System.Drawing.Size(151, 29)
        Me.Cuit_boton.TabIndex = 5
        Me.Cuit_boton.Text = "Buscar CUIT"
        Me.Cuit_boton.UseVisualStyleBackColor = False
        '
        'Constancia_Boton
        '
        Me.Constancia_Boton.BackColor = System.Drawing.Color.White
        Me.Constancia_Boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Constancia_Boton.Font = New System.Drawing.Font("Segoe UI", 7.0!)
        Me.Constancia_Boton.Image = CType(resources.GetObject("Constancia_Boton.Image"), System.Drawing.Image)
        Me.Constancia_Boton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Constancia_Boton.Location = New System.Drawing.Point(21, 63)
        Me.Constancia_Boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Constancia_Boton.Name = "Constancia_Boton"
        Me.Constancia_Boton.Size = New System.Drawing.Size(331, 29)
        Me.Constancia_Boton.TabIndex = 118
        Me.Constancia_Boton.Text = "Ver Constancia de inscripción"
        Me.Constancia_Boton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Constancia_Boton.UseVisualStyleBackColor = False
        '
        'Candado_fechaboton
        '
        Me.Candado_fechaboton.BackColor = System.Drawing.Color.Transparent
        Me.Candado_fechaboton.BackgroundImage = Global.SICyF.My.Resources.Resources.lock_closed
        Me.Candado_fechaboton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Candado_fechaboton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Candado_fechaboton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Candado_fechaboton.ForeColor = System.Drawing.Color.Black
        Me.Candado_fechaboton.Location = New System.Drawing.Point(326, 7)
        Me.Candado_fechaboton.Margin = New System.Windows.Forms.Padding(0)
        Me.Candado_fechaboton.Name = "Candado_fechaboton"
        Me.Candado_fechaboton.Size = New System.Drawing.Size(29, 26)
        Me.Candado_fechaboton.TabIndex = 118
        Me.Candado_fechaboton.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Candado_fechaboton.UseVisualStyleBackColor = False
        Me.Candado_fechaboton.Visible = False
        '
        'Control_Movimiento_MFyV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayout_movimientos)
        Me.Name = "Control_Movimiento_MFyV"
        Me.Size = New System.Drawing.Size(645, 410)
        Me.TableLayout_movimientos.ResumeLayout(False)
        Me.Panel_datosmovimiento.ResumeLayout(False)
        Me.Panel_Formulario.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.Monto_factura_textbox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Nrotransferencia_textbox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ordendeentregayear_integerupdown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ordendeentrega_integerupdown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_botones.ResumeLayout(False)
        Me.TableLayout_MFyV.ResumeLayout(False)
        Me.TableLayout_MFyV.PerformLayout()
        Me.TableLayout_botones.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents TableLayout_movimientos As Flicker_Tablelayout
    Friend WithEvents Panel_datosmovimiento As PANEL_sinFlicker
    Friend WithEvents Panel_Formulario As PANEL_sinFlicker
    Friend WithEvents Tipodemovimiento_label As Label
    Friend WithEvents Tipo_movimiento_boton As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Detalle_textbox As TextBox
    Friend WithEvents Cargartotalfactura As Button
    Friend WithEvents Monto_factura_textbox As Flicker_Numericcontrol_Dinero
    Friend WithEvents Label_montonombre As Label
    Friend WithEvents TableLayoutPanel2 As Flicker_Tablelayout
    Friend WithEvents Botonaceptar_button As Button
    Friend WithEvents Modificar_boton As Button
    Friend WithEvents Borrar_boton As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Cuitdelbeneficiario_textbox As MaskedTextBox
    Friend WithEvents Beneficiario_label As Label
    Friend WithEvents Cuit_boton As Button
    Friend WithEvents Constancia_Boton As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Movimientofecha_calendar As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Nrotransferencia_textbox As Flicker_Numericcontrol_Numero
    Friend WithEvents Candado_fechaboton As Button
    Friend WithEvents Ordendeentregayear_integerupdown As Flicker_Numericcontrol_Numero
    Friend WithEvents Label3 As Label
    Friend WithEvents Orden_label As Label
    Friend WithEvents Ordendeentrega_integerupdown As Flicker_Numericcontrol_Numero
    Friend WithEvents Panel_botones As PANEL_sinFlicker
    Friend WithEvents TableLayout_MFyV As Flicker_Tablelayout
    Friend WithEvents LabelClasefondo As Label
    Friend WithEvents Label_Codorden As Label
    Friend WithEvents Label_Codimp As Label
    Friend WithEvents TableLayout_botones As Flicker_Tablelayout
    Friend WithEvents TableLayoutPanel5 As Flicker_Tablelayout
    Friend WithEvents Codigoimputacion9 As Button
    Friend WithEvents Codigoimputacion4 As Button
    Friend WithEvents Codigoimputacion3 As Button
    Friend WithEvents Codigoimputacion2 As Button
    Friend WithEvents Codigoimputacion1 As Button
    Friend WithEvents TableLayoutPanel4 As Flicker_Tablelayout
    Friend WithEvents Clasefondo9 As Button
    Friend WithEvents Clasefondo2 As Button
    Friend WithEvents Clasefondo1 As Button
    Friend WithEvents TableLayoutPanel3 As Flicker_Tablelayout
    Friend WithEvents COD__ORDEN9 As Button
    Friend WithEvents COD__ORDEN5 As Button
    Friend WithEvents COD__ORDEN4 As Button
    Friend WithEvents COD__ORDEN3 As Button
    Friend WithEvents COD__ORDEN2 As Button
    Friend WithEvents COD__ORDEN1 As Button
End Class
