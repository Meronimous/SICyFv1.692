<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Tesoreria_Conciliacion2
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tesoreria_Conciliacion2))
        Me.Kripton_containergeneral = New SICyF.Flicker_Split_panel()
        Me.Label_detalleCuentabancaria = New System.Windows.Forms.Label()
        Me.Seleccionarcuenta_boton = New System.Windows.Forms.Button()
        Me.Datagrid_Selector = New SICyF.Flicker_Datagridview()
        Me.Label_Cuentabancaria = New System.Windows.Forms.Label()
        Me.Desde_monthcalendarA = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Hasta_monthcalendarA = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Splitcontainer_Datos = New SICyF.Flicker_Split_panel()
        Me.Descripcion_General_label = New System.Windows.Forms.Label()
        Me.Buscador_general = New System.Windows.Forms.TextBox()
        Me.Mostrarsolonoconciliado_checkbox = New System.Windows.Forms.CheckBox()
        Me.Datagrid_General = New SICyF.Flicker_Datagridview()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Imagen_General = New System.Windows.Forms.PictureBox()
        Me.Descripcion_Detallado_label = New System.Windows.Forms.Label()
        Me.Sugerencias_Tabcontrol = New System.Windows.Forms.TabControl()
        Me.Valores_actuales_tabpage = New System.Windows.Forms.TabPage()
        Me.Datagrid_Detalles = New SICyF.Flicker_Datagridview()
        Me.Buscador_detallado = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Sugerencias_tabpage = New System.Windows.Forms.TabPage()
        Me.Generarpedidodefondo_boton = New System.Windows.Forms.Button()
        Me.Imagen_detallado = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.Kripton_containergeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Kripton_containergeneral.Panel1.SuspendLayout()
        Me.Kripton_containergeneral.Panel2.SuspendLayout()
        Me.Kripton_containergeneral.SuspendLayout()
        CType(Me.Datagrid_Selector, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Splitcontainer_Datos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Splitcontainer_Datos.Panel1.SuspendLayout()
        Me.Splitcontainer_Datos.Panel2.SuspendLayout()
        Me.Splitcontainer_Datos.SuspendLayout()
        CType(Me.Datagrid_General, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Imagen_General, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Sugerencias_Tabcontrol.SuspendLayout()
        Me.Valores_actuales_tabpage.SuspendLayout()
        CType(Me.Datagrid_Detalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Sugerencias_tabpage.SuspendLayout()
        CType(Me.Imagen_detallado, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Kripton_containergeneral.Panel1.Controls.Add(Me.Label_detalleCuentabancaria)
        Me.Kripton_containergeneral.Panel1.Controls.Add(Me.Seleccionarcuenta_boton)
        Me.Kripton_containergeneral.Panel1.Controls.Add(Me.Datagrid_Selector)
        Me.Kripton_containergeneral.Panel1.Controls.Add(Me.Label_Cuentabancaria)
        Me.Kripton_containergeneral.Panel1.Controls.Add(Me.Desde_monthcalendarA)
        Me.Kripton_containergeneral.Panel1.Controls.Add(Me.Label2)
        Me.Kripton_containergeneral.Panel1.Controls.Add(Me.Hasta_monthcalendarA)
        Me.Kripton_containergeneral.Panel1.Controls.Add(Me.Label5)
        '
        'Kripton_containergeneral.Panel2
        '
        Me.Kripton_containergeneral.Panel2.Controls.Add(Me.Splitcontainer_Datos)
        Me.Kripton_containergeneral.Size = New System.Drawing.Size(933, 565)
        Me.Kripton_containergeneral.SplitterDistance = 61
        Me.Kripton_containergeneral.TabIndex = 0
        '
        'Label_detalleCuentabancaria
        '
        Me.Label_detalleCuentabancaria.AutoSize = True
        Me.Label_detalleCuentabancaria.BackColor = System.Drawing.Color.Transparent
        Me.Label_detalleCuentabancaria.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_detalleCuentabancaria.Location = New System.Drawing.Point(98, 26)
        Me.Label_detalleCuentabancaria.Name = "Label_detalleCuentabancaria"
        Me.Label_detalleCuentabancaria.Size = New System.Drawing.Size(13, 17)
        Me.Label_detalleCuentabancaria.TabIndex = 138
        Me.Label_detalleCuentabancaria.Text = "-"
        '
        'Seleccionarcuenta_boton
        '
        Me.Seleccionarcuenta_boton.BackColor = System.Drawing.Color.SkyBlue
        Me.Seleccionarcuenta_boton.Font = New System.Drawing.Font("Raleway Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Seleccionarcuenta_boton.Location = New System.Drawing.Point(3, 26)
        Me.Seleccionarcuenta_boton.Name = "Seleccionarcuenta_boton"
        Me.Seleccionarcuenta_boton.Size = New System.Drawing.Size(89, 36)
        Me.Seleccionarcuenta_boton.TabIndex = 137
        Me.Seleccionarcuenta_boton.Text = "Seleccionar Cuenta"
        Me.Seleccionarcuenta_boton.UseVisualStyleBackColor = False
        '
        'Datagrid_Selector
        '
        Me.Datagrid_Selector.AllowUserToAddRows = False
        Me.Datagrid_Selector.AllowUserToDeleteRows = False
        Me.Datagrid_Selector.AllowUserToOrderColumns = True
        Me.Datagrid_Selector.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Datagrid_Selector.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Datagrid_Selector.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.Datagrid_Selector.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datagrid_Selector.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datagrid_Selector.DefaultCellStyle = DataGridViewCellStyle2
        Me.Datagrid_Selector.Location = New System.Drawing.Point(343, 0)
        Me.Datagrid_Selector.Name = "Datagrid_Selector"
        Me.Datagrid_Selector.ReadOnly = True
        Me.Datagrid_Selector.RowHeadersVisible = False
        Me.Datagrid_Selector.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datagrid_Selector.RowTemplate.ReadOnly = True
        Me.Datagrid_Selector.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Datagrid_Selector.Size = New System.Drawing.Size(590, 51)
        Me.Datagrid_Selector.TabIndex = 112
        '
        'Label_Cuentabancaria
        '
        Me.Label_Cuentabancaria.AutoSize = True
        Me.Label_Cuentabancaria.BackColor = System.Drawing.Color.Transparent
        Me.Label_Cuentabancaria.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label_Cuentabancaria.Location = New System.Drawing.Point(98, 46)
        Me.Label_Cuentabancaria.Name = "Label_Cuentabancaria"
        Me.Label_Cuentabancaria.Size = New System.Drawing.Size(13, 17)
        Me.Label_Cuentabancaria.TabIndex = 26
        Me.Label_Cuentabancaria.Text = "-"
        '
        'Desde_monthcalendarA
        '
        Me.Desde_monthcalendarA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Desde_monthcalendarA.Location = New System.Drawing.Point(73, 0)
        Me.Desde_monthcalendarA.Name = "Desde_monthcalendarA"
        Me.Desde_monthcalendarA.Size = New System.Drawing.Size(98, 22)
        Me.Desde_monthcalendarA.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 16)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Desde"
        '
        'Hasta_monthcalendarA
        '
        Me.Hasta_monthcalendarA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Hasta_monthcalendarA.Location = New System.Drawing.Point(232, 0)
        Me.Hasta_monthcalendarA.Name = "Hasta_monthcalendarA"
        Me.Hasta_monthcalendarA.Size = New System.Drawing.Size(105, 22)
        Me.Hasta_monthcalendarA.TabIndex = 24
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(177, 0)
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
        Me.Splitcontainer_Datos.Panel1.Controls.Add(Me.Descripcion_General_label)
        Me.Splitcontainer_Datos.Panel1.Controls.Add(Me.Buscador_general)
        Me.Splitcontainer_Datos.Panel1.Controls.Add(Me.Mostrarsolonoconciliado_checkbox)
        Me.Splitcontainer_Datos.Panel1.Controls.Add(Me.Datagrid_General)
        Me.Splitcontainer_Datos.Panel1.Controls.Add(Me.Label3)
        Me.Splitcontainer_Datos.Panel1.Controls.Add(Me.Imagen_General)
        '
        'Splitcontainer_Datos.Panel2
        '
        Me.Splitcontainer_Datos.Panel2.BackColor = System.Drawing.Color.White
        Me.Splitcontainer_Datos.Panel2.Controls.Add(Me.Descripcion_Detallado_label)
        Me.Splitcontainer_Datos.Panel2.Controls.Add(Me.Sugerencias_Tabcontrol)
        Me.Splitcontainer_Datos.Panel2.Controls.Add(Me.Imagen_detallado)
        Me.Splitcontainer_Datos.Size = New System.Drawing.Size(933, 500)
        Me.Splitcontainer_Datos.SplitterDistance = 486
        Me.Splitcontainer_Datos.TabIndex = 1
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
        Me.Buscador_general.Size = New System.Drawing.Size(151, 22)
        Me.Buscador_general.TabIndex = 114
        '
        'Mostrarsolonoconciliado_checkbox
        '
        Me.Mostrarsolonoconciliado_checkbox.AutoSize = True
        Me.Mostrarsolonoconciliado_checkbox.Location = New System.Drawing.Point(209, 1)
        Me.Mostrarsolonoconciliado_checkbox.Name = "Mostrarsolonoconciliado_checkbox"
        Me.Mostrarsolonoconciliado_checkbox.Size = New System.Drawing.Size(178, 17)
        Me.Mostrarsolonoconciliado_checkbox.TabIndex = 123
        Me.Mostrarsolonoconciliado_checkbox.Text = "Mostrar Solo lo no conciliado"
        Me.Mostrarsolonoconciliado_checkbox.UseVisualStyleBackColor = True
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datagrid_General.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Datagrid_General.ColumnHeadersHeight = 40
        Me.Datagrid_General.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datagrid_General.DefaultCellStyle = DataGridViewCellStyle4
        Me.Datagrid_General.Location = New System.Drawing.Point(3, 40)
        Me.Datagrid_General.Name = "Datagrid_General"
        Me.Datagrid_General.ReadOnly = True
        Me.Datagrid_General.RowHeadersWidth = 22
        Me.Datagrid_General.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Datagrid_General.Size = New System.Drawing.Size(480, 457)
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
        'Descripcion_Detallado_label
        '
        Me.Descripcion_Detallado_label.AutoSize = True
        Me.Descripcion_Detallado_label.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Descripcion_Detallado_label.Location = New System.Drawing.Point(88, 9)
        Me.Descripcion_Detallado_label.Name = "Descripcion_Detallado_label"
        Me.Descripcion_Detallado_label.Size = New System.Drawing.Size(14, 17)
        Me.Descripcion_Detallado_label.TabIndex = 124
        Me.Descripcion_Detallado_label.Text = "-"
        '
        'Sugerencias_Tabcontrol
        '
        Me.Sugerencias_Tabcontrol.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Sugerencias_Tabcontrol.Controls.Add(Me.Valores_actuales_tabpage)
        Me.Sugerencias_Tabcontrol.Controls.Add(Me.Sugerencias_tabpage)
        Me.Sugerencias_Tabcontrol.Location = New System.Drawing.Point(10, 40)
        Me.Sugerencias_Tabcontrol.Name = "Sugerencias_Tabcontrol"
        Me.Sugerencias_Tabcontrol.Padding = New System.Drawing.Point(0, 0)
        Me.Sugerencias_Tabcontrol.SelectedIndex = 0
        Me.Sugerencias_Tabcontrol.Size = New System.Drawing.Size(430, 461)
        Me.Sugerencias_Tabcontrol.TabIndex = 122
        '
        'Valores_actuales_tabpage
        '
        Me.Valores_actuales_tabpage.BackColor = System.Drawing.Color.White
        Me.Valores_actuales_tabpage.Controls.Add(Me.Datagrid_Detalles)
        Me.Valores_actuales_tabpage.Controls.Add(Me.Buscador_detallado)
        Me.Valores_actuales_tabpage.Controls.Add(Me.Label1)
        Me.Valores_actuales_tabpage.Location = New System.Drawing.Point(4, 22)
        Me.Valores_actuales_tabpage.Name = "Valores_actuales_tabpage"
        Me.Valores_actuales_tabpage.Padding = New System.Windows.Forms.Padding(3)
        Me.Valores_actuales_tabpage.Size = New System.Drawing.Size(422, 435)
        Me.Valores_actuales_tabpage.TabIndex = 0
        Me.Valores_actuales_tabpage.Text = "Valores Actuales"
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
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datagrid_Detalles.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.Datagrid_Detalles.ColumnHeadersHeight = 40
        Me.Datagrid_Detalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datagrid_Detalles.DefaultCellStyle = DataGridViewCellStyle6
        Me.Datagrid_Detalles.Location = New System.Drawing.Point(3, 34)
        Me.Datagrid_Detalles.Name = "Datagrid_Detalles"
        Me.Datagrid_Detalles.ReadOnly = True
        Me.Datagrid_Detalles.RowHeadersWidth = 22
        Me.Datagrid_Detalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Datagrid_Detalles.Size = New System.Drawing.Size(413, 395)
        Me.Datagrid_Detalles.TabIndex = 121
        '
        'Buscador_detallado
        '
        Me.Buscador_detallado.Location = New System.Drawing.Point(216, 6)
        Me.Buscador_detallado.Name = "Buscador_detallado"
        Me.Buscador_detallado.Size = New System.Drawing.Size(151, 22)
        Me.Buscador_detallado.TabIndex = 116
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 7.25!)
        Me.Label1.Location = New System.Drawing.Point(176, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 12)
        Me.Label1.TabIndex = 117
        Me.Label1.Text = "Buscar"
        '
        'Sugerencias_tabpage
        '
        Me.Sugerencias_tabpage.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Sugerencias_tabpage.Controls.Add(Me.Generarpedidodefondo_boton)
        Me.Sugerencias_tabpage.Location = New System.Drawing.Point(4, 22)
        Me.Sugerencias_tabpage.Name = "Sugerencias_tabpage"
        Me.Sugerencias_tabpage.Padding = New System.Windows.Forms.Padding(3)
        Me.Sugerencias_tabpage.Size = New System.Drawing.Size(422, 435)
        Me.Sugerencias_tabpage.TabIndex = 1
        Me.Sugerencias_tabpage.Text = "SUGERENCIAS"
        '
        'Generarpedidodefondo_boton
        '
        Me.Generarpedidodefondo_boton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Generarpedidodefondo_boton.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Generarpedidodefondo_boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Generarpedidodefondo_boton.Font = New System.Drawing.Font("Segoe UI", 8.999999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Generarpedidodefondo_boton.Image = CType(resources.GetObject("Generarpedidodefondo_boton.Image"), System.Drawing.Image)
        Me.Generarpedidodefondo_boton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Generarpedidodefondo_boton.Location = New System.Drawing.Point(6, 394)
        Me.Generarpedidodefondo_boton.Name = "Generarpedidodefondo_boton"
        Me.Generarpedidodefondo_boton.Size = New System.Drawing.Size(298, 32)
        Me.Generarpedidodefondo_boton.TabIndex = 118
        Me.Generarpedidodefondo_boton.UseVisualStyleBackColor = False
        '
        'Imagen_detallado
        '
        Me.Imagen_detallado.BackColor = System.Drawing.Color.Transparent
        Me.Imagen_detallado.Location = New System.Drawing.Point(13, 3)
        Me.Imagen_detallado.Name = "Imagen_detallado"
        Me.Imagen_detallado.Size = New System.Drawing.Size(69, 31)
        Me.Imagen_detallado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Imagen_detallado.TabIndex = 123
        Me.Imagen_detallado.TabStop = False
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 100000
        Me.ToolTip1.BackColor = System.Drawing.Color.Gold
        Me.ToolTip1.ForeColor = System.Drawing.Color.Black
        Me.ToolTip1.InitialDelay = 200
        Me.ToolTip1.ReshowDelay = 500
        Me.ToolTip1.StripAmpersands = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'Tesoreria_Conciliacion2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(933, 565)
        Me.Controls.Add(Me.Kripton_containergeneral)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Tesoreria_Conciliacion2"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tesoreria_Conciliacion2"
        Me.Kripton_containergeneral.Panel1.ResumeLayout(False)
        Me.Kripton_containergeneral.Panel1.PerformLayout()
        Me.Kripton_containergeneral.Panel2.ResumeLayout(False)
        CType(Me.Kripton_containergeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Kripton_containergeneral.ResumeLayout(False)
        CType(Me.Datagrid_Selector, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Splitcontainer_Datos.Panel1.ResumeLayout(False)
        Me.Splitcontainer_Datos.Panel1.PerformLayout()
        Me.Splitcontainer_Datos.Panel2.ResumeLayout(False)
        Me.Splitcontainer_Datos.Panel2.PerformLayout()
        CType(Me.Splitcontainer_Datos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Splitcontainer_Datos.ResumeLayout(False)
        CType(Me.Datagrid_General, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Imagen_General, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Sugerencias_Tabcontrol.ResumeLayout(False)
        Me.Valores_actuales_tabpage.ResumeLayout(False)
        Me.Valores_actuales_tabpage.PerformLayout()
        CType(Me.Datagrid_Detalles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Sugerencias_tabpage.ResumeLayout(False)
        CType(Me.Imagen_detallado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents Kripton_containergeneral As Flicker_Split_panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Hasta_monthcalendarA As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Datagrid_Selector As SICyF.Flicker_Datagridview
    Friend WithEvents Label_Cuentabancaria As Label
    Friend WithEvents Desde_monthcalendarA As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Buscador_general As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Buscador_detallado As TextBox
    Friend WithEvents Generarpedidodefondo_boton As Button
    Friend WithEvents Seleccionarcuenta_boton As Button
    Friend WithEvents Label_detalleCuentabancaria As Label
    Friend WithEvents Imagen_General As PictureBox
    Friend WithEvents Datagrid_General As SICyF.Flicker_Datagridview
    Friend WithEvents Datagrid_Detalles As SICyF.Flicker_Datagridview
    Friend WithEvents Sugerencias_Tabcontrol As TabControl
    Friend WithEvents Valores_actuales_tabpage As TabPage
    Friend WithEvents Sugerencias_tabpage As TabPage
    Friend WithEvents Imagen_detallado As PictureBox
    Friend WithEvents Mostrarsolonoconciliado_checkbox As CheckBox
    Friend WithEvents Splitcontainer_Datos As Flicker_Split_panel
    Friend WithEvents Descripcion_General_label As Label
    Friend WithEvents Descripcion_Detallado_label As Label
    Friend WithEvents ToolTip1 As ToolTip
End Class
