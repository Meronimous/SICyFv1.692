<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tesoreria_Control_Retenciones
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
        Me.Boton_expediente = New System.Windows.Forms.Button()
        Me.PaneL_impuestos = New SICyF.PANEL_sinFlicker()
        Me.RetencionesMovimientos_textbox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.IngresosMovimientos_textbox = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.EgresosMovimientos_textbox = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Monto_factura_textbox = New SICyF.Flicker_Numericcontrol_Dinero()
        Me.GANANCIAS_tipo_boton = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SUSS_tipo_boton = New System.Windows.Forms.Button()
        Me.Chequetotal_numeric = New SICyF.Flicker_Numericcontrol_Dinero()
        Me.DGR_tipo_boton = New System.Windows.Forms.Button()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Ordendeentrega_integerupdown = New SICyF.Flicker_Numericcontrol_Numero()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.IVA_tipo_boton = New System.Windows.Forms.Button()
        Me.Ordendeentregayear_integerupdown = New SICyF.Flicker_Numericcontrol_Numero()
        Me.Ganancias_Flicker_Numericupdown = New SICyF.Flicker_Numericcontrol_Dinero()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SUSS_Flicker_Numericupdown = New SICyF.Flicker_Numericcontrol_Dinero()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DGR_Flicker_Numericupdown = New SICyF.Flicker_Numericcontrol_Dinero()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.IVA_Flicker_Numericupdown = New SICyF.Flicker_Numericcontrol_Dinero()
        Me.Guardar_boton = New System.Windows.Forms.Button()
        Me.Descripcion_textbox = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PaneL_impuestos.SuspendLayout()
        CType(Me.Monto_factura_textbox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chequetotal_numeric, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ordendeentrega_integerupdown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ordendeentregayear_integerupdown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ganancias_Flicker_Numericupdown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SUSS_Flicker_Numericupdown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGR_Flicker_Numericupdown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IVA_Flicker_Numericupdown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Boton_expediente
        '
        Me.Boton_expediente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Boton_expediente.BackColor = System.Drawing.Color.DarkGreen
        Me.Boton_expediente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Boton_expediente.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Boton_expediente.ForeColor = System.Drawing.Color.White
        Me.Boton_expediente.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Boton_expediente.Location = New System.Drawing.Point(0, 2)
        Me.Boton_expediente.Margin = New System.Windows.Forms.Padding(0)
        Me.Boton_expediente.Name = "Boton_expediente"
        Me.Boton_expediente.Size = New System.Drawing.Size(1000, 25)
        Me.Boton_expediente.TabIndex = 160
        Me.Boton_expediente.Text = "Expte:"
        Me.Boton_expediente.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.Boton_expediente.UseVisualStyleBackColor = False
        '
        'PaneL_impuestos
        '
        Me.PaneL_impuestos.Controls.Add(Me.Label6)
        Me.PaneL_impuestos.Controls.Add(Me.Descripcion_textbox)
        Me.PaneL_impuestos.Controls.Add(Me.Guardar_boton)
        Me.PaneL_impuestos.Controls.Add(Me.RetencionesMovimientos_textbox)
        Me.PaneL_impuestos.Controls.Add(Me.Label7)
        Me.PaneL_impuestos.Controls.Add(Me.IngresosMovimientos_textbox)
        Me.PaneL_impuestos.Controls.Add(Me.Label21)
        Me.PaneL_impuestos.Controls.Add(Me.EgresosMovimientos_textbox)
        Me.PaneL_impuestos.Controls.Add(Me.Label22)
        Me.PaneL_impuestos.Controls.Add(Me.Monto_factura_textbox)
        Me.PaneL_impuestos.Controls.Add(Me.GANANCIAS_tipo_boton)
        Me.PaneL_impuestos.Controls.Add(Me.Label5)
        Me.PaneL_impuestos.Controls.Add(Me.SUSS_tipo_boton)
        Me.PaneL_impuestos.Controls.Add(Me.Chequetotal_numeric)
        Me.PaneL_impuestos.Controls.Add(Me.DGR_tipo_boton)
        Me.PaneL_impuestos.Controls.Add(Me.Label34)
        Me.PaneL_impuestos.Controls.Add(Me.Ordendeentrega_integerupdown)
        Me.PaneL_impuestos.Controls.Add(Me.Label4)
        Me.PaneL_impuestos.Controls.Add(Me.Label23)
        Me.PaneL_impuestos.Controls.Add(Me.IVA_tipo_boton)
        Me.PaneL_impuestos.Controls.Add(Me.Ordendeentregayear_integerupdown)
        Me.PaneL_impuestos.Controls.Add(Me.Ganancias_Flicker_Numericupdown)
        Me.PaneL_impuestos.Controls.Add(Me.Label2)
        Me.PaneL_impuestos.Controls.Add(Me.SUSS_Flicker_Numericupdown)
        Me.PaneL_impuestos.Controls.Add(Me.Label1)
        Me.PaneL_impuestos.Controls.Add(Me.DGR_Flicker_Numericupdown)
        Me.PaneL_impuestos.Controls.Add(Me.Label3)
        Me.PaneL_impuestos.Controls.Add(Me.IVA_Flicker_Numericupdown)
        Me.PaneL_impuestos.Location = New System.Drawing.Point(0, 30)
        Me.PaneL_impuestos.Name = "PaneL_impuestos"
        Me.PaneL_impuestos.Size = New System.Drawing.Size(997, 177)
        Me.PaneL_impuestos.TabIndex = 161
        Me.PaneL_impuestos.Visible = False
        '
        'RetencionesMovimientos_textbox
        '
        Me.RetencionesMovimientos_textbox.BackColor = System.Drawing.Color.White
        Me.RetencionesMovimientos_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RetencionesMovimientos_textbox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RetencionesMovimientos_textbox.ForeColor = System.Drawing.Color.Black
        Me.RetencionesMovimientos_textbox.Location = New System.Drawing.Point(874, 4)
        Me.RetencionesMovimientos_textbox.Margin = New System.Windows.Forms.Padding(0)
        Me.RetencionesMovimientos_textbox.Name = "RetencionesMovimientos_textbox"
        Me.RetencionesMovimientos_textbox.ReadOnly = True
        Me.RetencionesMovimientos_textbox.Size = New System.Drawing.Size(109, 23)
        Me.RetencionesMovimientos_textbox.TabIndex = 167
        Me.RetencionesMovimientos_textbox.TabStop = False
        Me.RetencionesMovimientos_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(818, 1)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 30)
        Me.Label7.TabIndex = 166
        Me.Label7.Text = "Ret. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sin Pagar"
        '
        'IngresosMovimientos_textbox
        '
        Me.IngresosMovimientos_textbox.BackColor = System.Drawing.Color.White
        Me.IngresosMovimientos_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.IngresosMovimientos_textbox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IngresosMovimientos_textbox.ForeColor = System.Drawing.Color.Black
        Me.IngresosMovimientos_textbox.Location = New System.Drawing.Point(555, 4)
        Me.IngresosMovimientos_textbox.Margin = New System.Windows.Forms.Padding(0)
        Me.IngresosMovimientos_textbox.Name = "IngresosMovimientos_textbox"
        Me.IngresosMovimientos_textbox.ReadOnly = True
        Me.IngresosMovimientos_textbox.Size = New System.Drawing.Size(109, 23)
        Me.IngresosMovimientos_textbox.TabIndex = 161
        Me.IngresosMovimientos_textbox.TabStop = False
        Me.IngresosMovimientos_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(524, 6)
        Me.Label21.Margin = New System.Windows.Forms.Padding(0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(31, 15)
        Me.Label21.TabIndex = 160
        Me.Label21.Text = "Ingr."
        '
        'EgresosMovimientos_textbox
        '
        Me.EgresosMovimientos_textbox.BackColor = System.Drawing.Color.White
        Me.EgresosMovimientos_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EgresosMovimientos_textbox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EgresosMovimientos_textbox.ForeColor = System.Drawing.Color.Black
        Me.EgresosMovimientos_textbox.Location = New System.Drawing.Point(698, 4)
        Me.EgresosMovimientos_textbox.Margin = New System.Windows.Forms.Padding(0)
        Me.EgresosMovimientos_textbox.Name = "EgresosMovimientos_textbox"
        Me.EgresosMovimientos_textbox.ReadOnly = True
        Me.EgresosMovimientos_textbox.Size = New System.Drawing.Size(109, 23)
        Me.EgresosMovimientos_textbox.TabIndex = 163
        Me.EgresosMovimientos_textbox.TabStop = False
        Me.EgresosMovimientos_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(671, 6)
        Me.Label22.Margin = New System.Windows.Forms.Padding(0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(27, 15)
        Me.Label22.TabIndex = 162
        Me.Label22.Text = "Egr."
        '
        'Monto_factura_textbox
        '
        Me.Monto_factura_textbox.BackColor = System.Drawing.Color.SpringGreen
        Me.Monto_factura_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Monto_factura_textbox.CausesValidation = False
        Me.Monto_factura_textbox.DecimalPlaces = 2
        Me.Monto_factura_textbox.Font = New System.Drawing.Font("Raleway Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Monto_factura_textbox.ForeColor = System.Drawing.Color.Black
        Me.Monto_factura_textbox.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.Monto_factura_textbox.Location = New System.Drawing.Point(248, 1)
        Me.Monto_factura_textbox.Margin = New System.Windows.Forms.Padding(0)
        Me.Monto_factura_textbox.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 131072})
        Me.Monto_factura_textbox.Minimum = New Decimal(New Integer() {1316134911, 2328, 0, -2147352576})
        Me.Monto_factura_textbox.Name = "Monto_factura_textbox"
        Me.Monto_factura_textbox.Size = New System.Drawing.Size(178, 25)
        Me.Monto_factura_textbox.Suffix = Nothing
        Me.Monto_factura_textbox.TabIndex = 156
        Me.Monto_factura_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Monto_factura_textbox.ThousandsSeparator = True
        '
        'GANANCIAS_tipo_boton
        '
        Me.GANANCIAS_tipo_boton.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.GANANCIAS_tipo_boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GANANCIAS_tipo_boton.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GANANCIAS_tipo_boton.ForeColor = System.Drawing.Color.Black
        Me.GANANCIAS_tipo_boton.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.GANANCIAS_tipo_boton.Location = New System.Drawing.Point(452, 32)
        Me.GANANCIAS_tipo_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.GANANCIAS_tipo_boton.Name = "GANANCIAS_tipo_boton"
        Me.GANANCIAS_tipo_boton.Size = New System.Drawing.Size(324, 30)
        Me.GANANCIAS_tipo_boton.TabIndex = 14
        Me.GANANCIAS_tipo_boton.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.GANANCIAS_tipo_boton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.GANANCIAS_tipo_boton.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(197, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 15)
        Me.Label5.TabIndex = 157
        Me.Label5.Text = "BRUTO"
        '
        'SUSS_tipo_boton
        '
        Me.SUSS_tipo_boton.BackColor = System.Drawing.Color.SkyBlue
        Me.SUSS_tipo_boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SUSS_tipo_boton.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SUSS_tipo_boton.ForeColor = System.Drawing.Color.Black
        Me.SUSS_tipo_boton.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.SUSS_tipo_boton.Location = New System.Drawing.Point(452, 62)
        Me.SUSS_tipo_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.SUSS_tipo_boton.Name = "SUSS_tipo_boton"
        Me.SUSS_tipo_boton.Size = New System.Drawing.Size(324, 30)
        Me.SUSS_tipo_boton.TabIndex = 17
        Me.SUSS_tipo_boton.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.SUSS_tipo_boton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.SUSS_tipo_boton.UseVisualStyleBackColor = False
        '
        'Chequetotal_numeric
        '
        Me.Chequetotal_numeric.BackColor = System.Drawing.Color.SpringGreen
        Me.Chequetotal_numeric.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Chequetotal_numeric.CausesValidation = False
        Me.Chequetotal_numeric.DecimalPlaces = 2
        Me.Chequetotal_numeric.Font = New System.Drawing.Font("Raleway Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chequetotal_numeric.ForeColor = System.Drawing.Color.Black
        Me.Chequetotal_numeric.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.Chequetotal_numeric.Location = New System.Drawing.Point(245, 146)
        Me.Chequetotal_numeric.Margin = New System.Windows.Forms.Padding(0)
        Me.Chequetotal_numeric.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 131072})
        Me.Chequetotal_numeric.Minimum = New Decimal(New Integer() {1316134911, 2328, 0, -2147352576})
        Me.Chequetotal_numeric.Name = "Chequetotal_numeric"
        Me.Chequetotal_numeric.Size = New System.Drawing.Size(173, 25)
        Me.Chequetotal_numeric.Suffix = Nothing
        Me.Chequetotal_numeric.TabIndex = 158
        Me.Chequetotal_numeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Chequetotal_numeric.ThousandsSeparator = True
        '
        'DGR_tipo_boton
        '
        Me.DGR_tipo_boton.BackColor = System.Drawing.Color.LightSkyBlue
        Me.DGR_tipo_boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DGR_tipo_boton.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGR_tipo_boton.ForeColor = System.Drawing.Color.Black
        Me.DGR_tipo_boton.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.DGR_tipo_boton.Location = New System.Drawing.Point(452, 92)
        Me.DGR_tipo_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.DGR_tipo_boton.Name = "DGR_tipo_boton"
        Me.DGR_tipo_boton.Size = New System.Drawing.Size(324, 30)
        Me.DGR_tipo_boton.TabIndex = 21
        Me.DGR_tipo_boton.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.DGR_tipo_boton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.DGR_tipo_boton.UseVisualStyleBackColor = False
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Black
        Me.Label34.Location = New System.Drawing.Point(204, 150)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(41, 15)
        Me.Label34.TabIndex = 159
        Me.Label34.Text = "NETO "
        '
        'Ordendeentrega_integerupdown
        '
        Me.Ordendeentrega_integerupdown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Ordendeentrega_integerupdown.CausesValidation = False
        Me.Ordendeentrega_integerupdown.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ordendeentrega_integerupdown.Location = New System.Drawing.Point(68, 1)
        Me.Ordendeentrega_integerupdown.Margin = New System.Windows.Forms.Padding(0)
        Me.Ordendeentrega_integerupdown.Maximum = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.Ordendeentrega_integerupdown.Name = "Ordendeentrega_integerupdown"
        Me.Ordendeentrega_integerupdown.Size = New System.Drawing.Size(67, 23)
        Me.Ordendeentrega_integerupdown.Suffix = Nothing
        Me.Ordendeentrega_integerupdown.TabIndex = 143
        Me.Ordendeentrega_integerupdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Ordendeentrega_integerupdown.ThousandsSeparator = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(416, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 15)
        Me.Label4.TabIndex = 155
        Me.Label4.Text = "IVA"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(3, 1)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(62, 26)
        Me.Label23.TabIndex = 144
        Me.Label23.Text = "ORDEN DE" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " PAGO Nº"
        '
        'IVA_tipo_boton
        '
        Me.IVA_tipo_boton.BackColor = System.Drawing.Color.PowderBlue
        Me.IVA_tipo_boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IVA_tipo_boton.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IVA_tipo_boton.ForeColor = System.Drawing.Color.Black
        Me.IVA_tipo_boton.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.IVA_tipo_boton.Location = New System.Drawing.Point(452, 122)
        Me.IVA_tipo_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.IVA_tipo_boton.Name = "IVA_tipo_boton"
        Me.IVA_tipo_boton.Size = New System.Drawing.Size(324, 30)
        Me.IVA_tipo_boton.TabIndex = 154
        Me.IVA_tipo_boton.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.IVA_tipo_boton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.IVA_tipo_boton.UseVisualStyleBackColor = False
        '
        'Ordendeentregayear_integerupdown
        '
        Me.Ordendeentregayear_integerupdown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Ordendeentregayear_integerupdown.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ordendeentregayear_integerupdown.Location = New System.Drawing.Point(137, 1)
        Me.Ordendeentregayear_integerupdown.Margin = New System.Windows.Forms.Padding(0)
        Me.Ordendeentregayear_integerupdown.Maximum = New Decimal(New Integer() {2999, 0, 0, 0})
        Me.Ordendeentregayear_integerupdown.Name = "Ordendeentregayear_integerupdown"
        Me.Ordendeentregayear_integerupdown.Size = New System.Drawing.Size(50, 23)
        Me.Ordendeentregayear_integerupdown.Suffix = Nothing
        Me.Ordendeentregayear_integerupdown.TabIndex = 145
        Me.Ordendeentregayear_integerupdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Ordendeentregayear_integerupdown.Value = New Decimal(New Integer() {2000, 0, 0, 0})
        '
        'Ganancias_Flicker_Numericupdown
        '
        Me.Ganancias_Flicker_Numericupdown.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Ganancias_Flicker_Numericupdown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Ganancias_Flicker_Numericupdown.CausesValidation = False
        Me.Ganancias_Flicker_Numericupdown.DecimalPlaces = 2
        Me.Ganancias_Flicker_Numericupdown.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ganancias_Flicker_Numericupdown.ForeColor = System.Drawing.Color.White
        Me.Ganancias_Flicker_Numericupdown.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.Ganancias_Flicker_Numericupdown.Location = New System.Drawing.Point(776, 33)
        Me.Ganancias_Flicker_Numericupdown.Margin = New System.Windows.Forms.Padding(0)
        Me.Ganancias_Flicker_Numericupdown.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 131072})
        Me.Ganancias_Flicker_Numericupdown.Minimum = New Decimal(New Integer() {1316134911, 2328, 0, -2147352576})
        Me.Ganancias_Flicker_Numericupdown.Name = "Ganancias_Flicker_Numericupdown"
        Me.Ganancias_Flicker_Numericupdown.Size = New System.Drawing.Size(207, 29)
        Me.Ganancias_Flicker_Numericupdown.Suffix = Nothing
        Me.Ganancias_Flicker_Numericupdown.TabIndex = 150
        Me.Ganancias_Flicker_Numericupdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Ganancias_Flicker_Numericupdown.ThousandsSeparator = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(376, 39)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 15)
        Me.Label2.TabIndex = 146
        Me.Label2.Text = "GANANCIAS"
        '
        'SUSS_Flicker_Numericupdown
        '
        Me.SUSS_Flicker_Numericupdown.BackColor = System.Drawing.Color.DarkSlateGray
        Me.SUSS_Flicker_Numericupdown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SUSS_Flicker_Numericupdown.CausesValidation = False
        Me.SUSS_Flicker_Numericupdown.DecimalPlaces = 2
        Me.SUSS_Flicker_Numericupdown.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SUSS_Flicker_Numericupdown.ForeColor = System.Drawing.Color.White
        Me.SUSS_Flicker_Numericupdown.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.SUSS_Flicker_Numericupdown.Location = New System.Drawing.Point(776, 63)
        Me.SUSS_Flicker_Numericupdown.Margin = New System.Windows.Forms.Padding(0)
        Me.SUSS_Flicker_Numericupdown.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 131072})
        Me.SUSS_Flicker_Numericupdown.Minimum = New Decimal(New Integer() {1316134911, 2328, 0, -2147352576})
        Me.SUSS_Flicker_Numericupdown.Name = "SUSS_Flicker_Numericupdown"
        Me.SUSS_Flicker_Numericupdown.Size = New System.Drawing.Size(207, 29)
        Me.SUSS_Flicker_Numericupdown.Suffix = Nothing
        Me.SUSS_Flicker_Numericupdown.TabIndex = 151
        Me.SUSS_Flicker_Numericupdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.SUSS_Flicker_Numericupdown.ThousandsSeparator = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(412, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 15)
        Me.Label1.TabIndex = 147
        Me.Label1.Text = "SUSS"
        '
        'DGR_Flicker_Numericupdown
        '
        Me.DGR_Flicker_Numericupdown.BackColor = System.Drawing.Color.DarkSlateGray
        Me.DGR_Flicker_Numericupdown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DGR_Flicker_Numericupdown.CausesValidation = False
        Me.DGR_Flicker_Numericupdown.DecimalPlaces = 2
        Me.DGR_Flicker_Numericupdown.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGR_Flicker_Numericupdown.ForeColor = System.Drawing.Color.White
        Me.DGR_Flicker_Numericupdown.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.DGR_Flicker_Numericupdown.Location = New System.Drawing.Point(776, 92)
        Me.DGR_Flicker_Numericupdown.Margin = New System.Windows.Forms.Padding(0)
        Me.DGR_Flicker_Numericupdown.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 131072})
        Me.DGR_Flicker_Numericupdown.Minimum = New Decimal(New Integer() {1316134911, 2328, 0, -2147352576})
        Me.DGR_Flicker_Numericupdown.Name = "DGR_Flicker_Numericupdown"
        Me.DGR_Flicker_Numericupdown.Size = New System.Drawing.Size(207, 29)
        Me.DGR_Flicker_Numericupdown.Suffix = Nothing
        Me.DGR_Flicker_Numericupdown.TabIndex = 152
        Me.DGR_Flicker_Numericupdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.DGR_Flicker_Numericupdown.ThousandsSeparator = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(412, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 15)
        Me.Label3.TabIndex = 148
        Me.Label3.Text = "DGR"
        '
        'IVA_Flicker_Numericupdown
        '
        Me.IVA_Flicker_Numericupdown.BackColor = System.Drawing.Color.DarkSlateGray
        Me.IVA_Flicker_Numericupdown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.IVA_Flicker_Numericupdown.CausesValidation = False
        Me.IVA_Flicker_Numericupdown.DecimalPlaces = 2
        Me.IVA_Flicker_Numericupdown.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IVA_Flicker_Numericupdown.ForeColor = System.Drawing.Color.White
        Me.IVA_Flicker_Numericupdown.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.IVA_Flicker_Numericupdown.Location = New System.Drawing.Point(776, 122)
        Me.IVA_Flicker_Numericupdown.Margin = New System.Windows.Forms.Padding(0)
        Me.IVA_Flicker_Numericupdown.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 131072})
        Me.IVA_Flicker_Numericupdown.Minimum = New Decimal(New Integer() {1316134911, 2328, 0, -2147352576})
        Me.IVA_Flicker_Numericupdown.Name = "IVA_Flicker_Numericupdown"
        Me.IVA_Flicker_Numericupdown.Size = New System.Drawing.Size(207, 29)
        Me.IVA_Flicker_Numericupdown.Suffix = Nothing
        Me.IVA_Flicker_Numericupdown.TabIndex = 153
        Me.IVA_Flicker_Numericupdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.IVA_Flicker_Numericupdown.ThousandsSeparator = True
        '
        'Guardar_boton
        '
        Me.Guardar_boton.BackColor = System.Drawing.Color.SeaGreen
        Me.Guardar_boton.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guardar_boton.ForeColor = System.Drawing.Color.White
        Me.Guardar_boton.Location = New System.Drawing.Point(843, 150)
        Me.Guardar_boton.Margin = New System.Windows.Forms.Padding(1)
        Me.Guardar_boton.Name = "Guardar_boton"
        Me.Guardar_boton.Size = New System.Drawing.Size(140, 30)
        Me.Guardar_boton.TabIndex = 717
        Me.Guardar_boton.Text = "Guardar"
        Me.Guardar_boton.UseVisualStyleBackColor = False
        '
        'Descripcion_textbox
        '
        Me.Descripcion_textbox.AcceptsReturn = True
        Me.Descripcion_textbox.BackColor = System.Drawing.Color.OldLace
        Me.Descripcion_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Descripcion_textbox.Location = New System.Drawing.Point(3, 40)
        Me.Descripcion_textbox.Multiline = True
        Me.Descripcion_textbox.Name = "Descripcion_textbox"
        Me.Descripcion_textbox.Size = New System.Drawing.Size(370, 73)
        Me.Descripcion_textbox.TabIndex = 718
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(21, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 15)
        Me.Label6.TabIndex = 719
        Me.Label6.Text = "Descripción"
        '
        'Tesoreria_Control_Retenciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.Khaki
        Me.Controls.Add(Me.Boton_expediente)
        Me.Controls.Add(Me.PaneL_impuestos)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "Tesoreria_Control_Retenciones"
        Me.Size = New System.Drawing.Size(1000, 211)
        Me.PaneL_impuestos.ResumeLayout(False)
        Me.PaneL_impuestos.PerformLayout()
        CType(Me.Monto_factura_textbox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chequetotal_numeric, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ordendeentrega_integerupdown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ordendeentregayear_integerupdown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ganancias_Flicker_Numericupdown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SUSS_Flicker_Numericupdown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGR_Flicker_Numericupdown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IVA_Flicker_Numericupdown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents GANANCIAS_tipo_boton As Button
    Friend WithEvents SUSS_tipo_boton As Button
    Friend WithEvents DGR_tipo_boton As Button
    Friend WithEvents Ordendeentregayear_integerupdown As Flicker_Numericcontrol_Numero
    Friend WithEvents Label23 As Label
    Friend WithEvents Ordendeentrega_integerupdown As Flicker_Numericcontrol_Numero
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Ganancias_Flicker_Numericupdown As Flicker_Numericcontrol_Dinero
    Friend WithEvents SUSS_Flicker_Numericupdown As Flicker_Numericcontrol_Dinero
    Friend WithEvents DGR_Flicker_Numericupdown As Flicker_Numericcontrol_Dinero
    Friend WithEvents IVA_Flicker_Numericupdown As Flicker_Numericcontrol_Dinero
    Friend WithEvents Label4 As Label
    Friend WithEvents IVA_tipo_boton As Button
    Friend WithEvents Monto_factura_textbox As Flicker_Numericcontrol_Dinero
    Friend WithEvents Label5 As Label
    Friend WithEvents Chequetotal_numeric As Flicker_Numericcontrol_Dinero
    Friend WithEvents Label34 As Label
    Friend WithEvents Boton_expediente As Button
    Friend WithEvents PaneL_impuestos As PANEL_sinFlicker
    Friend WithEvents Guardar_boton As Button
    Friend WithEvents RetencionesMovimientos_textbox As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents IngresosMovimientos_textbox As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents EgresosMovimientos_textbox As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Descripcion_textbox As TextBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
End Class
