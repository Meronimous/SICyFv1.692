<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tesoreria_retencionesV2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tesoreria_retencionesV2))
        Me.Encabezado_groupbox = New System.Windows.Forms.GroupBox()
        Me.Cuentas_combobox = New System.Windows.Forms.ComboBox()
        Me.BotonAgregarMov = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.PaneL_aniocalendario = New SICyF.PANEL_sinFlicker()
        Me.label445 = New System.Windows.Forms.Label()
        Me.Facturadoanio_label = New System.Windows.Forms.Label()
        Me.PaneL_12meses = New SICyF.PANEL_sinFlicker()
        Me.label444 = New System.Windows.Forms.Label()
        Me.Facturado12meses_label = New System.Windows.Forms.Label()
        Me.Panelmes = New SICyF.PANEL_sinFlicker()
        Me.Facturadomes_label = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.PaneL_sinFlicker1 = New SICyF.PANEL_sinFlicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Nro_Transferencia_numericupdown = New SICyF.Flicker_Numericcontrol_Dinero()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.IVA_PORCENTAJE_LABEL = New System.Windows.Forms.Label()
        Me.Fecha_factura = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.IVA_boton = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Beneficiario_label = New System.Windows.Forms.Label()
        Me.Responsabletipo_boton = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Cuitdelbeneficiario_textbox = New System.Windows.Forms.MaskedTextBox()
        Me.Cuit_boton = New System.Windows.Forms.Button()
        Me.Constancia_Boton = New System.Windows.Forms.Button()
        Me.PanelSplitGeneal = New SICyF.Flicker_Split_panel()
        Me.Encabezado_groupbox.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.PaneL_aniocalendario.SuspendLayout()
        Me.PaneL_12meses.SuspendLayout()
        Me.Panelmes.SuspendLayout()
        Me.PaneL_sinFlicker1.SuspendLayout()
        CType(Me.Nro_Transferencia_numericupdown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelSplitGeneal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelSplitGeneal.Panel1.SuspendLayout()
        Me.PanelSplitGeneal.SuspendLayout()
        Me.SuspendLayout()
        '
        'Encabezado_groupbox
        '
        Me.Encabezado_groupbox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Encabezado_groupbox.BackColor = System.Drawing.Color.SteelBlue
        Me.Encabezado_groupbox.Controls.Add(Me.Cuentas_combobox)
        Me.Encabezado_groupbox.Controls.Add(Me.BotonAgregarMov)
        Me.Encabezado_groupbox.Controls.Add(Me.TableLayoutPanel2)
        Me.Encabezado_groupbox.Controls.Add(Me.Label16)
        Me.Encabezado_groupbox.Controls.Add(Me.Label29)
        Me.Encabezado_groupbox.Controls.Add(Me.Nro_Transferencia_numericupdown)
        Me.Encabezado_groupbox.Controls.Add(Me.Button1)
        Me.Encabezado_groupbox.Controls.Add(Me.Label1)
        Me.Encabezado_groupbox.Controls.Add(Me.IVA_PORCENTAJE_LABEL)
        Me.Encabezado_groupbox.Controls.Add(Me.Fecha_factura)
        Me.Encabezado_groupbox.Controls.Add(Me.Label18)
        Me.Encabezado_groupbox.Controls.Add(Me.Label8)
        Me.Encabezado_groupbox.Controls.Add(Me.IVA_boton)
        Me.Encabezado_groupbox.Controls.Add(Me.Label3)
        Me.Encabezado_groupbox.Controls.Add(Me.Beneficiario_label)
        Me.Encabezado_groupbox.Controls.Add(Me.Responsabletipo_boton)
        Me.Encabezado_groupbox.Controls.Add(Me.Label7)
        Me.Encabezado_groupbox.Controls.Add(Me.Cuitdelbeneficiario_textbox)
        Me.Encabezado_groupbox.Controls.Add(Me.Cuit_boton)
        Me.Encabezado_groupbox.Controls.Add(Me.Constancia_Boton)
        Me.Encabezado_groupbox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Encabezado_groupbox.Location = New System.Drawing.Point(2, 0)
        Me.Encabezado_groupbox.Margin = New System.Windows.Forms.Padding(0)
        Me.Encabezado_groupbox.Name = "Encabezado_groupbox"
        Me.Encabezado_groupbox.Padding = New System.Windows.Forms.Padding(0)
        Me.Encabezado_groupbox.Size = New System.Drawing.Size(982, 225)
        Me.Encabezado_groupbox.TabIndex = 125
        Me.Encabezado_groupbox.TabStop = False
        Me.Encabezado_groupbox.Text = "CUIT"
        '
        'Cuentas_combobox
        '
        Me.Cuentas_combobox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cuentas_combobox.FormattingEnabled = True
        Me.Cuentas_combobox.Location = New System.Drawing.Point(136, 141)
        Me.Cuentas_combobox.Margin = New System.Windows.Forms.Padding(0)
        Me.Cuentas_combobox.Name = "Cuentas_combobox"
        Me.Cuentas_combobox.Size = New System.Drawing.Size(442, 23)
        Me.Cuentas_combobox.TabIndex = 144
        '
        'BotonAgregarMov
        '
        Me.BotonAgregarMov.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BotonAgregarMov.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BotonAgregarMov.BackgroundImage = Global.SICyF.My.Resources.Resources.add
        Me.BotonAgregarMov.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BotonAgregarMov.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BotonAgregarMov.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BotonAgregarMov.ForeColor = System.Drawing.Color.Black
        Me.BotonAgregarMov.Location = New System.Drawing.Point(860, 179)
        Me.BotonAgregarMov.Margin = New System.Windows.Forms.Padding(0)
        Me.BotonAgregarMov.Name = "BotonAgregarMov"
        Me.BotonAgregarMov.Size = New System.Drawing.Size(122, 43)
        Me.BotonAgregarMov.TabIndex = 4
        Me.BotonAgregarMov.Text = "AGREGAR Movimiento"
        Me.BotonAgregarMov.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BotonAgregarMov.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.RoyalBlue
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.PaneL_aniocalendario, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.PaneL_12meses, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panelmes, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.PaneL_sinFlicker1, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 75)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(982, 55)
        Me.TableLayoutPanel2.TabIndex = 131
        '
        'PaneL_aniocalendario
        '
        Me.PaneL_aniocalendario.BackColor = System.Drawing.Color.SeaGreen
        Me.PaneL_aniocalendario.Controls.Add(Me.label445)
        Me.PaneL_aniocalendario.Controls.Add(Me.Facturadoanio_label)
        Me.PaneL_aniocalendario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PaneL_aniocalendario.Location = New System.Drawing.Point(648, 22)
        Me.PaneL_aniocalendario.Margin = New System.Windows.Forms.Padding(0)
        Me.PaneL_aniocalendario.Name = "PaneL_aniocalendario"
        Me.PaneL_aniocalendario.Size = New System.Drawing.Size(334, 33)
        Me.PaneL_aniocalendario.TabIndex = 2
        '
        'label445
        '
        Me.label445.AutoSize = True
        Me.label445.BackColor = System.Drawing.Color.Transparent
        Me.label445.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label445.ForeColor = System.Drawing.Color.White
        Me.label445.Location = New System.Drawing.Point(3, 7)
        Me.label445.Name = "label445"
        Me.label445.Size = New System.Drawing.Size(29, 15)
        Me.label445.TabIndex = 127
        Me.label445.Text = "Año"
        '
        'Facturadoanio_label
        '
        Me.Facturadoanio_label.AutoSize = True
        Me.Facturadoanio_label.BackColor = System.Drawing.Color.Transparent
        Me.Facturadoanio_label.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Facturadoanio_label.ForeColor = System.Drawing.Color.White
        Me.Facturadoanio_label.Location = New System.Drawing.Point(38, 6)
        Me.Facturadoanio_label.Name = "Facturadoanio_label"
        Me.Facturadoanio_label.Size = New System.Drawing.Size(15, 17)
        Me.Facturadoanio_label.TabIndex = 126
        Me.Facturadoanio_label.Text = "$"
        '
        'PaneL_12meses
        '
        Me.PaneL_12meses.BackColor = System.Drawing.Color.SeaGreen
        Me.PaneL_12meses.Controls.Add(Me.label444)
        Me.PaneL_12meses.Controls.Add(Me.Facturado12meses_label)
        Me.PaneL_12meses.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PaneL_12meses.Location = New System.Drawing.Point(324, 22)
        Me.PaneL_12meses.Margin = New System.Windows.Forms.Padding(0)
        Me.PaneL_12meses.Name = "PaneL_12meses"
        Me.PaneL_12meses.Size = New System.Drawing.Size(324, 33)
        Me.PaneL_12meses.TabIndex = 1
        '
        'label444
        '
        Me.label444.AutoSize = True
        Me.label444.BackColor = System.Drawing.Color.Transparent
        Me.label444.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.label444.ForeColor = System.Drawing.Color.White
        Me.label444.Location = New System.Drawing.Point(3, 9)
        Me.label444.Name = "label444"
        Me.label444.Size = New System.Drawing.Size(74, 13)
        Me.label444.TabIndex = 127
        Me.label444.Text = "ult. 12 meses"
        '
        'Facturado12meses_label
        '
        Me.Facturado12meses_label.AutoSize = True
        Me.Facturado12meses_label.BackColor = System.Drawing.Color.Transparent
        Me.Facturado12meses_label.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Facturado12meses_label.ForeColor = System.Drawing.Color.White
        Me.Facturado12meses_label.Location = New System.Drawing.Point(83, 7)
        Me.Facturado12meses_label.Name = "Facturado12meses_label"
        Me.Facturado12meses_label.Size = New System.Drawing.Size(15, 17)
        Me.Facturado12meses_label.TabIndex = 126
        Me.Facturado12meses_label.Text = "$"
        '
        'Panelmes
        '
        Me.Panelmes.BackColor = System.Drawing.Color.SeaGreen
        Me.Panelmes.Controls.Add(Me.Facturadomes_label)
        Me.Panelmes.Controls.Add(Me.Label21)
        Me.Panelmes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panelmes.Location = New System.Drawing.Point(0, 22)
        Me.Panelmes.Margin = New System.Windows.Forms.Padding(0)
        Me.Panelmes.Name = "Panelmes"
        Me.Panelmes.Size = New System.Drawing.Size(324, 33)
        Me.Panelmes.TabIndex = 0
        '
        'Facturadomes_label
        '
        Me.Facturadomes_label.AutoSize = True
        Me.Facturadomes_label.BackColor = System.Drawing.Color.Transparent
        Me.Facturadomes_label.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Facturadomes_label.ForeColor = System.Drawing.Color.White
        Me.Facturadomes_label.Location = New System.Drawing.Point(44, 6)
        Me.Facturadomes_label.Name = "Facturadomes_label"
        Me.Facturadomes_label.Size = New System.Drawing.Size(15, 17)
        Me.Facturadomes_label.TabIndex = 126
        Me.Facturadomes_label.Text = "$"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(5, 7)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(33, 15)
        Me.Label21.TabIndex = 125
        Me.Label21.Text = " Mes"
        '
        'PaneL_sinFlicker1
        '
        Me.PaneL_sinFlicker1.BackColor = System.Drawing.Color.SeaGreen
        Me.TableLayoutPanel2.SetColumnSpan(Me.PaneL_sinFlicker1, 3)
        Me.PaneL_sinFlicker1.Controls.Add(Me.Label2)
        Me.PaneL_sinFlicker1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PaneL_sinFlicker1.Location = New System.Drawing.Point(0, 0)
        Me.PaneL_sinFlicker1.Margin = New System.Windows.Forms.Padding(0)
        Me.PaneL_sinFlicker1.Name = "PaneL_sinFlicker1"
        Me.PaneL_sinFlicker1.Size = New System.Drawing.Size(982, 22)
        Me.PaneL_sinFlicker1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(457, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 15)
        Me.Label2.TabIndex = 126
        Me.Label2.Text = "Pagos acumulados"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(8, 144)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(117, 15)
        Me.Label16.TabIndex = 145
        Me.Label16.Text = "Cuenta Seleccionada"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.Location = New System.Drawing.Point(8, 172)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(93, 30)
        Me.Label29.TabIndex = 143
        Me.Label29.Text = "Nro de Cheque " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Transferencia"
        '
        'Nro_Transferencia_numericupdown
        '
        Me.Nro_Transferencia_numericupdown.BackColor = System.Drawing.Color.DodgerBlue
        Me.Nro_Transferencia_numericupdown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Nro_Transferencia_numericupdown.CausesValidation = False
        Me.Nro_Transferencia_numericupdown.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nro_Transferencia_numericupdown.ForeColor = System.Drawing.Color.White
        Me.Nro_Transferencia_numericupdown.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.Nro_Transferencia_numericupdown.Location = New System.Drawing.Point(111, 170)
        Me.Nro_Transferencia_numericupdown.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 131072})
        Me.Nro_Transferencia_numericupdown.Minimum = New Decimal(New Integer() {1316134911, 2328, 0, -2147352576})
        Me.Nro_Transferencia_numericupdown.Name = "Nro_Transferencia_numericupdown"
        Me.Nro_Transferencia_numericupdown.Size = New System.Drawing.Size(293, 31)
        Me.Nro_Transferencia_numericupdown.Suffix = Nothing
        Me.Nro_Transferencia_numericupdown.TabIndex = 142
        Me.Nro_Transferencia_numericupdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Nro_Transferencia_numericupdown.ThousandsSeparator = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Button1.Location = New System.Drawing.Point(512, 42)
        Me.Button1.Margin = New System.Windows.Forms.Padding(0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(63, 28)
        Me.Button1.TabIndex = 138
        Me.Button1.Text = "80%"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(423, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 15)
        Me.Label1.TabIndex = 139
        Me.Label1.Text = "Retención IVA"
        '
        'IVA_PORCENTAJE_LABEL
        '
        Me.IVA_PORCENTAJE_LABEL.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IVA_PORCENTAJE_LABEL.ForeColor = System.Drawing.Color.White
        Me.IVA_PORCENTAJE_LABEL.Location = New System.Drawing.Point(596, 141)
        Me.IVA_PORCENTAJE_LABEL.Name = "IVA_PORCENTAJE_LABEL"
        Me.IVA_PORCENTAJE_LABEL.Size = New System.Drawing.Size(383, 38)
        Me.IVA_PORCENTAJE_LABEL.TabIndex = 137
        Me.IVA_PORCENTAJE_LABEL.Text = "RespuestaAfip"
        '
        'Fecha_factura
        '
        Me.Fecha_factura.CalendarFont = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Fecha_factura.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fecha_factura.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Fecha_factura.Location = New System.Drawing.Point(465, 170)
        Me.Fecha_factura.Name = "Fecha_factura"
        Me.Fecha_factura.Size = New System.Drawing.Size(113, 29)
        Me.Fecha_factura.TabIndex = 1
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(404, 179)
        Me.Label18.Margin = New System.Windows.Forms.Padding(0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(39, 15)
        Me.Label18.TabIndex = 133
        Me.Label18.Text = "Fecha"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(394, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 21)
        Me.Label8.TabIndex = 129
        Me.Label8.Text = "%"
        '
        'IVA_boton
        '
        Me.IVA_boton.BackColor = System.Drawing.Color.LightSteelBlue
        Me.IVA_boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IVA_boton.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IVA_boton.ForeColor = System.Drawing.Color.White
        Me.IVA_boton.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.IVA_boton.Location = New System.Drawing.Point(316, 42)
        Me.IVA_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.IVA_boton.Name = "IVA_boton"
        Me.IVA_boton.Size = New System.Drawing.Size(75, 30)
        Me.IVA_boton.TabIndex = 3
        Me.IVA_boton.Text = "0"
        Me.IVA_boton.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.IVA_boton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.IVA_boton.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(248, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 30)
        Me.Label3.TabIndex = 128
        Me.Label3.Text = "ALÍCUOTA" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  IVA"
        '
        'Beneficiario_label
        '
        Me.Beneficiario_label.BackColor = System.Drawing.Color.SteelBlue
        Me.Beneficiario_label.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Beneficiario_label.ForeColor = System.Drawing.Color.White
        Me.Beneficiario_label.Location = New System.Drawing.Point(325, 15)
        Me.Beneficiario_label.Margin = New System.Windows.Forms.Padding(0)
        Me.Beneficiario_label.Name = "Beneficiario_label"
        Me.Beneficiario_label.Size = New System.Drawing.Size(493, 19)
        Me.Beneficiario_label.TabIndex = 117
        Me.Beneficiario_label.Text = "-"
        Me.Beneficiario_label.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Responsabletipo_boton
        '
        Me.Responsabletipo_boton.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Responsabletipo_boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Responsabletipo_boton.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Responsabletipo_boton.ForeColor = System.Drawing.Color.White
        Me.Responsabletipo_boton.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Responsabletipo_boton.Location = New System.Drawing.Point(94, 46)
        Me.Responsabletipo_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Responsabletipo_boton.Name = "Responsabletipo_boton"
        Me.Responsabletipo_boton.Size = New System.Drawing.Size(151, 28)
        Me.Responsabletipo_boton.TabIndex = 2
        Me.Responsabletipo_boton.Text = "NO INSCRIPTO"
        Me.Responsabletipo_boton.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Responsabletipo_boton.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(3, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 15)
        Me.Label7.TabIndex = 125
        Me.Label7.Text = "RESPONSABLE"
        '
        'Cuitdelbeneficiario_textbox
        '
        Me.Cuitdelbeneficiario_textbox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cuitdelbeneficiario_textbox.Location = New System.Drawing.Point(3, 14)
        Me.Cuitdelbeneficiario_textbox.Mask = "00-00000000-0"
        Me.Cuitdelbeneficiario_textbox.Name = "Cuitdelbeneficiario_textbox"
        Me.Cuitdelbeneficiario_textbox.Size = New System.Drawing.Size(159, 29)
        Me.Cuitdelbeneficiario_textbox.TabIndex = 0
        Me.Cuitdelbeneficiario_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Cuit_boton
        '
        Me.Cuit_boton.BackColor = System.Drawing.Color.White
        Me.Cuit_boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cuit_boton.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cuit_boton.ForeColor = System.Drawing.Color.ForestGreen
        Me.Cuit_boton.Image = CType(resources.GetObject("Cuit_boton.Image"), System.Drawing.Image)
        Me.Cuit_boton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cuit_boton.Location = New System.Drawing.Point(165, 14)
        Me.Cuit_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Cuit_boton.Name = "Cuit_boton"
        Me.Cuit_boton.Size = New System.Drawing.Size(151, 29)
        Me.Cuit_boton.TabIndex = 7
        Me.Cuit_boton.Text = "Buscar CUIT"
        Me.Cuit_boton.UseVisualStyleBackColor = False
        '
        'Constancia_Boton
        '
        Me.Constancia_Boton.BackColor = System.Drawing.Color.White
        Me.Constancia_Boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Constancia_Boton.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Constancia_Boton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Constancia_Boton.Location = New System.Drawing.Point(589, 36)
        Me.Constancia_Boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Constancia_Boton.Name = "Constancia_Boton"
        Me.Constancia_Boton.Size = New System.Drawing.Size(167, 36)
        Me.Constancia_Boton.TabIndex = 118
        Me.Constancia_Boton.Text = "Ver Constancia de inscripción"
        Me.Constancia_Boton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Constancia_Boton.UseVisualStyleBackColor = False
        '
        'PanelSplitGeneal
        '
        Me.PanelSplitGeneal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelSplitGeneal.BackColor = System.Drawing.Color.LightBlue
        Me.PanelSplitGeneal.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.PanelSplitGeneal.IsSplitterFixed = True
        Me.PanelSplitGeneal.Location = New System.Drawing.Point(0, 0)
        Me.PanelSplitGeneal.Name = "PanelSplitGeneal"
        Me.PanelSplitGeneal.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'PanelSplitGeneal.Panel1
        '
        Me.PanelSplitGeneal.Panel1.BackColor = System.Drawing.Color.White
        Me.PanelSplitGeneal.Panel1.Controls.Add(Me.Encabezado_groupbox)
        '
        'PanelSplitGeneal.Panel2
        '
        Me.PanelSplitGeneal.Panel2.BackColor = System.Drawing.Color.White
        Me.PanelSplitGeneal.Size = New System.Drawing.Size(984, 568)
        Me.PanelSplitGeneal.SplitterDistance = 227
        Me.PanelSplitGeneal.TabIndex = 126
        '
        'Tesoreria_retencionesV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(984, 568)
        Me.Controls.Add(Me.PanelSplitGeneal)
        Me.DoubleBuffered = True
        Me.Name = "Tesoreria_retencionesV2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Carga multiple"
        Me.Encabezado_groupbox.ResumeLayout(False)
        Me.Encabezado_groupbox.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.PaneL_aniocalendario.ResumeLayout(False)
        Me.PaneL_aniocalendario.PerformLayout()
        Me.PaneL_12meses.ResumeLayout(False)
        Me.PaneL_12meses.PerformLayout()
        Me.Panelmes.ResumeLayout(False)
        Me.Panelmes.PerformLayout()
        Me.PaneL_sinFlicker1.ResumeLayout(False)
        Me.PaneL_sinFlicker1.PerformLayout()
        CType(Me.Nro_Transferencia_numericupdown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelSplitGeneal.Panel1.ResumeLayout(False)
        CType(Me.PanelSplitGeneal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelSplitGeneal.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents Encabezado_groupbox As GroupBox
    Friend WithEvents Beneficiario_label As Label
    Friend WithEvents Responsabletipo_boton As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Cuitdelbeneficiario_textbox As MaskedTextBox
    Friend WithEvents Cuit_boton As Button
    Friend WithEvents Constancia_Boton As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents IVA_boton As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents BotonAgregarMov As Button
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents PaneL_aniocalendario As PANEL_sinFlicker
    Friend WithEvents label445 As Label
    Friend WithEvents Facturadoanio_label As Label
    Friend WithEvents PaneL_12meses As PANEL_sinFlicker
    Friend WithEvents label444 As Label
    Friend WithEvents Facturado12meses_label As Label
    Friend WithEvents Panelmes As PANEL_sinFlicker
    Friend WithEvents Facturadomes_label As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Fecha_factura As DateTimePicker
    Friend WithEvents Label18 As Label
    Friend WithEvents IVA_PORCENTAJE_LABEL As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Nro_Transferencia_numericupdown As Flicker_Numericcontrol_Dinero
    Friend WithEvents Cuentas_combobox As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents PaneL_sinFlicker1 As PANEL_sinFlicker
    Friend WithEvents Label2 As Label
    Friend WithEvents PanelSplitGeneal As Flicker_Split_panel
End Class
