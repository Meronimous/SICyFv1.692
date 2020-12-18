<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialogo_nuevopedidofondo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dialogo_nuevopedidofondo))
        Me.Cerrar_boton = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label_pedidofondo = New System.Windows.Forms.Label()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Pedidoparcial_checkbox = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Year_pedidofondo_numeric = New System.Windows.Forms.NumericUpDown()
        Me.Fecha_pedido = New System.Windows.Forms.DateTimePicker()
        Me.Descripcion_textbox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.N_pedidofondo_numeric = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Year_numericupdown = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Numeroexpediente_numericupdown = New System.Windows.Forms.NumericUpDown()
        Me.Organismo_numericupdown = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Pedidohaberes_checkbox = New System.Windows.Forms.CheckBox()
        Me.Ejercicioactual_checkbox = New System.Windows.Forms.CheckBox()
        Me.Residuospasivos_checkbox = New System.Windows.Forms.CheckBox()
        Me.Residuosopasivos_groupbox = New System.Windows.Forms.GroupBox()
        Me.Anioejecucion = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Cuentas_datagrid = New System.Windows.Forms.DataGridView()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.Year_pedidofondo_numeric, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.N_pedidofondo_numeric, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Year_numericupdown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Numeroexpediente_numericupdown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Organismo_numericupdown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Residuosopasivos_groupbox.SuspendLayout()
        CType(Me.Anioejecucion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.Cuentas_datagrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.Cerrar_boton.Location = New System.Drawing.Point(812, 0)
        Me.Cerrar_boton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cerrar_boton.Name = "Cerrar_boton"
        Me.Cerrar_boton.Size = New System.Drawing.Size(56, 42)
        Me.Cerrar_boton.TabIndex = 31
        Me.Cerrar_boton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cerrar_boton.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Panel1.Controls.Add(Me.Cerrar_boton)
        Me.Panel1.Controls.Add(Me.Label_pedidofondo)
        Me.Panel1.Controls.Add(Me.Cancel_Button)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(868, 45)
        Me.Panel1.TabIndex = 108
        '
        'Label_pedidofondo
        '
        Me.Label_pedidofondo.AutoSize = True
        Me.Label_pedidofondo.Font = New System.Drawing.Font("Raleway Black", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_pedidofondo.ForeColor = System.Drawing.Color.White
        Me.Label_pedidofondo.Location = New System.Drawing.Point(195, 9)
        Me.Label_pedidofondo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_pedidofondo.Name = "Label_pedidofondo"
        Me.Label_pedidofondo.Size = New System.Drawing.Size(304, 30)
        Me.Label_pedidofondo.TabIndex = 29
        Me.Label_pedidofondo.Text = "NUEVO PEDIDO DE FONDOS"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.FlatAppearance.BorderSize = 0
        Me.Cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancel_Button.Image = CType(resources.GetObject("Cancel_Button.Image"), System.Drawing.Image)
        Me.Cancel_Button.Location = New System.Drawing.Point(1431, 0)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(53, 65)
        Me.Cancel_Button.TabIndex = 1
        '
        'Pedidoparcial_checkbox
        '
        Me.Pedidoparcial_checkbox.AutoSize = True
        Me.Pedidoparcial_checkbox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pedidoparcial_checkbox.Location = New System.Drawing.Point(270, 28)
        Me.Pedidoparcial_checkbox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Pedidoparcial_checkbox.Name = "Pedidoparcial_checkbox"
        Me.Pedidoparcial_checkbox.Size = New System.Drawing.Size(98, 34)
        Me.Pedidoparcial_checkbox.TabIndex = 9
        Me.Pedidoparcial_checkbox.Text = "Pedido de " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Fondo Parcial"
        Me.Pedidoparcial_checkbox.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(152, 26)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 20)
        Me.Label8.TabIndex = 121
        Me.Label8.Text = "Año"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(9, 90)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 20)
        Me.Label3.TabIndex = 111
        Me.Label3.Text = "Descripción"
        '
        'Year_pedidofondo_numeric
        '
        Me.Year_pedidofondo_numeric.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Year_pedidofondo_numeric.Location = New System.Drawing.Point(131, 46)
        Me.Year_pedidofondo_numeric.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Year_pedidofondo_numeric.Maximum = New Decimal(New Integer() {2200, 0, 0, 0})
        Me.Year_pedidofondo_numeric.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.Year_pedidofondo_numeric.Name = "Year_pedidofondo_numeric"
        Me.Year_pedidofondo_numeric.Size = New System.Drawing.Size(100, 35)
        Me.Year_pedidofondo_numeric.TabIndex = 1
        Me.Year_pedidofondo_numeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Year_pedidofondo_numeric.Value = New Decimal(New Integer() {2018, 0, 0, 0})
        '
        'Fecha_pedido
        '
        Me.Fecha_pedido.CalendarFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fecha_pedido.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Fecha_pedido.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Fecha_pedido.Location = New System.Drawing.Point(239, 46)
        Me.Fecha_pedido.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Fecha_pedido.Name = "Fecha_pedido"
        Me.Fecha_pedido.Size = New System.Drawing.Size(128, 27)
        Me.Fecha_pedido.TabIndex = 2
        '
        'Descripcion_textbox
        '
        Me.Descripcion_textbox.BackColor = System.Drawing.Color.White
        Me.Descripcion_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Descripcion_textbox.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Descripcion_textbox.ForeColor = System.Drawing.Color.Black
        Me.Descripcion_textbox.Location = New System.Drawing.Point(3, 110)
        Me.Descripcion_textbox.Margin = New System.Windows.Forms.Padding(0)
        Me.Descripcion_textbox.Multiline = True
        Me.Descripcion_textbox.Name = "Descripcion_textbox"
        Me.Descripcion_textbox.Size = New System.Drawing.Size(364, 53)
        Me.Descripcion_textbox.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(3, 26)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 20)
        Me.Label2.TabIndex = 120
        Me.Label2.Text = "Número"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'N_pedidofondo_numeric
        '
        Me.N_pedidofondo_numeric.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold)
        Me.N_pedidofondo_numeric.ForeColor = System.Drawing.Color.Black
        Me.N_pedidofondo_numeric.Location = New System.Drawing.Point(3, 46)
        Me.N_pedidofondo_numeric.Margin = New System.Windows.Forms.Padding(0)
        Me.N_pedidofondo_numeric.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.N_pedidofondo_numeric.Name = "N_pedidofondo_numeric"
        Me.N_pedidofondo_numeric.Size = New System.Drawing.Size(124, 35)
        Me.N_pedidofondo_numeric.TabIndex = 0
        Me.N_pedidofondo_numeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1, 37)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 132
        Me.Label1.Text = "Organismo"
        '
        'Year_numericupdown
        '
        Me.Year_numericupdown.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Year_numericupdown.Location = New System.Drawing.Point(299, 35)
        Me.Year_numericupdown.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Year_numericupdown.Maximum = New Decimal(New Integer() {2100, 0, 0, 0})
        Me.Year_numericupdown.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.Year_numericupdown.Name = "Year_numericupdown"
        Me.Year_numericupdown.Size = New System.Drawing.Size(57, 27)
        Me.Year_numericupdown.TabIndex = 7
        Me.Year_numericupdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Year_numericupdown.Value = New Decimal(New Integer() {2000, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(262, 35)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 134
        Me.Label4.Text = "Año"
        '
        'Numeroexpediente_numericupdown
        '
        Me.Numeroexpediente_numericupdown.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Numeroexpediente_numericupdown.Location = New System.Drawing.Point(184, 35)
        Me.Numeroexpediente_numericupdown.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Numeroexpediente_numericupdown.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.Numeroexpediente_numericupdown.Name = "Numeroexpediente_numericupdown"
        Me.Numeroexpediente_numericupdown.Size = New System.Drawing.Size(70, 27)
        Me.Numeroexpediente_numericupdown.TabIndex = 6
        Me.Numeroexpediente_numericupdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Organismo_numericupdown
        '
        Me.Organismo_numericupdown.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Organismo_numericupdown.Location = New System.Drawing.Point(66, 35)
        Me.Organismo_numericupdown.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Organismo_numericupdown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.Organismo_numericupdown.Name = "Organismo_numericupdown"
        Me.Organismo_numericupdown.Size = New System.Drawing.Size(62, 27)
        Me.Organismo_numericupdown.TabIndex = 5
        Me.Organismo_numericupdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Organismo_numericupdown.Value = New Decimal(New Integer() {3888, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(129, 35)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 133
        Me.Label7.Text = "Número"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(243, 23)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 21)
        Me.Label5.TabIndex = 135
        Me.Label5.Text = "Fecha"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightCyan
        Me.GroupBox1.Controls.Add(Me.Fecha_pedido)
        Me.GroupBox1.Controls.Add(Me.N_pedidofondo_numeric)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Year_pedidofondo_numeric)
        Me.GroupBox1.Controls.Add(Me.Descripcion_textbox)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 47)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(386, 170)
        Me.GroupBox1.TabIndex = 136
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pedido de Fondo"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.LightCyan
        Me.GroupBox2.Controls.Add(Me.Pedidohaberes_checkbox)
        Me.GroupBox2.Controls.Add(Me.Ejercicioactual_checkbox)
        Me.GroupBox2.Controls.Add(Me.Residuospasivos_checkbox)
        Me.GroupBox2.Controls.Add(Me.Pedidoparcial_checkbox)
        Me.GroupBox2.Controls.Add(Me.Residuosopasivos_groupbox)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 218)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(387, 117)
        Me.GroupBox2.TabIndex = 137
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo de Pedido de Fondo"
        '
        'Pedidohaberes_checkbox
        '
        Me.Pedidohaberes_checkbox.AutoSize = True
        Me.Pedidohaberes_checkbox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pedidohaberes_checkbox.Location = New System.Drawing.Point(184, 36)
        Me.Pedidohaberes_checkbox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Pedidohaberes_checkbox.Name = "Pedidohaberes_checkbox"
        Me.Pedidohaberes_checkbox.Size = New System.Drawing.Size(69, 19)
        Me.Pedidohaberes_checkbox.TabIndex = 141
        Me.Pedidohaberes_checkbox.Text = "Haberes"
        Me.Pedidohaberes_checkbox.UseVisualStyleBackColor = True
        '
        'Ejercicioactual_checkbox
        '
        Me.Ejercicioactual_checkbox.AutoSize = True
        Me.Ejercicioactual_checkbox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ejercicioactual_checkbox.Location = New System.Drawing.Point(4, 28)
        Me.Ejercicioactual_checkbox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Ejercicioactual_checkbox.Name = "Ejercicioactual_checkbox"
        Me.Ejercicioactual_checkbox.Size = New System.Drawing.Size(66, 34)
        Me.Ejercicioactual_checkbox.TabIndex = 140
        Me.Ejercicioactual_checkbox.Text = "Ejecicio" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Actual"
        Me.Ejercicioactual_checkbox.UseVisualStyleBackColor = True
        '
        'Residuospasivos_checkbox
        '
        Me.Residuospasivos_checkbox.AutoSize = True
        Me.Residuospasivos_checkbox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Residuospasivos_checkbox.Location = New System.Drawing.Point(106, 28)
        Me.Residuospasivos_checkbox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Residuospasivos_checkbox.Name = "Residuospasivos_checkbox"
        Me.Residuospasivos_checkbox.Size = New System.Drawing.Size(73, 34)
        Me.Residuospasivos_checkbox.TabIndex = 139
        Me.Residuospasivos_checkbox.Text = "Residuos" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pasivos"
        Me.Residuospasivos_checkbox.UseVisualStyleBackColor = True
        '
        'Residuosopasivos_groupbox
        '
        Me.Residuosopasivos_groupbox.BackColor = System.Drawing.Color.LightBlue
        Me.Residuosopasivos_groupbox.Controls.Add(Me.Anioejecucion)
        Me.Residuosopasivos_groupbox.Controls.Add(Me.Label9)
        Me.Residuosopasivos_groupbox.Location = New System.Drawing.Point(1, 67)
        Me.Residuosopasivos_groupbox.Margin = New System.Windows.Forms.Padding(0)
        Me.Residuosopasivos_groupbox.Name = "Residuosopasivos_groupbox"
        Me.Residuosopasivos_groupbox.Padding = New System.Windows.Forms.Padding(0)
        Me.Residuosopasivos_groupbox.Size = New System.Drawing.Size(386, 47)
        Me.Residuosopasivos_groupbox.TabIndex = 138
        Me.Residuosopasivos_groupbox.TabStop = False
        Me.Residuosopasivos_groupbox.Text = "RESIDUOS PASIVOS"
        Me.Residuosopasivos_groupbox.Visible = False
        '
        'Anioejecucion
        '
        Me.Anioejecucion.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Anioejecucion.Location = New System.Drawing.Point(157, 17)
        Me.Anioejecucion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Anioejecucion.Maximum = New Decimal(New Integer() {2100, 0, 0, 0})
        Me.Anioejecucion.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.Anioejecucion.Name = "Anioejecucion"
        Me.Anioejecucion.Size = New System.Drawing.Size(96, 27)
        Me.Anioejecucion.TabIndex = 135
        Me.Anioejecucion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Anioejecucion.Value = New Decimal(New Integer() {2000, 0, 0, 0})
        '
        'Label9
        '
        Me.Label9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(116, 24)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 13)
        Me.Label9.TabIndex = 115
        Me.Label9.Text = "AÑO"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.LightCyan
        Me.GroupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox3.Controls.Add(Me.Organismo_numericupdown)
        Me.GroupBox3.Controls.Add(Me.Numeroexpediente_numericupdown)
        Me.GroupBox3.Controls.Add(Me.Year_numericupdown)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 335)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(386, 70)
        Me.GroupBox3.TabIndex = 138
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Expediente del pedido de Fondos"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.LightCyan
        Me.GroupBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox4.Controls.Add(Me.Cuentas_datagrid)
        Me.GroupBox4.Location = New System.Drawing.Point(395, 48)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(473, 357)
        Me.GroupBox4.TabIndex = 139
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Cuenta Bancaria"
        '
        'Cuentas_datagrid
        '
        Me.Cuentas_datagrid.AllowUserToAddRows = False
        Me.Cuentas_datagrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cuentas_datagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Cuentas_datagrid.BackgroundColor = System.Drawing.Color.White
        Me.Cuentas_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Cuentas_datagrid.GridColor = System.Drawing.Color.Black
        Me.Cuentas_datagrid.Location = New System.Drawing.Point(2, 25)
        Me.Cuentas_datagrid.MultiSelect = False
        Me.Cuentas_datagrid.Name = "Cuentas_datagrid"
        Me.Cuentas_datagrid.ReadOnly = True
        Me.Cuentas_datagrid.RowHeadersVisible = False
        Me.Cuentas_datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Cuentas_datagrid.Size = New System.Drawing.Size(465, 326)
        Me.Cuentas_datagrid.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.BackColor = System.Drawing.Color.SkyBlue
        Me.OK_Button.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.OK_Button.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.Location = New System.Drawing.Point(0, 405)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(868, 36)
        Me.OK_Button.TabIndex = 10
        Me.OK_Button.Text = "Guardar Pedido Fondo"
        Me.OK_Button.UseVisualStyleBackColor = False
        '
        'Dialogo_nuevopedidofondo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(868, 441)
        Me.ControlBox = False
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Dialogo_nuevopedidofondo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "General_nuevopedidofondo"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Year_pedidofondo_numeric, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.N_pedidofondo_numeric, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Year_numericupdown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Numeroexpediente_numericupdown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Organismo_numericupdown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Residuosopasivos_groupbox.ResumeLayout(False)
        Me.Residuosopasivos_groupbox.PerformLayout()
        CType(Me.Anioejecucion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.Cuentas_datagrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents Cerrar_boton As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label_pedidofondo As Label
    Friend WithEvents Cancel_Button As Button
    Friend WithEvents Pedidoparcial_checkbox As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Year_pedidofondo_numeric As NumericUpDown
    Friend WithEvents Fecha_pedido As DateTimePicker
    Friend WithEvents Descripcion_textbox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents N_pedidofondo_numeric As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents Year_numericupdown As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents Numeroexpediente_numericupdown As NumericUpDown
    Friend WithEvents Organismo_numericupdown As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents OK_Button As Button
    Friend WithEvents Anioejecucion As NumericUpDown
    Friend WithEvents Residuosopasivos_groupbox As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Ejercicioactual_checkbox As CheckBox
    Friend WithEvents Residuospasivos_checkbox As CheckBox
    Friend WithEvents Cuentas_datagrid As DataGridView
    Friend WithEvents Pedidohaberes_checkbox As CheckBox
End Class
