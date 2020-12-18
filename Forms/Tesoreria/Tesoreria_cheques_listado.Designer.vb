<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tesoreria_cheques_listado
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tesoreria_cheques_listado))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panelsplit_general = New SICyF.Flicker_Split_panel()
        Me.TABCONTROLGENERAL = New SICyF.FlickerTabcontrol()
        Me.NUMTRANSF_TAB = New System.Windows.Forms.TabPage()
        Me.CHEQUES_DATAGRIDVIEW = New SICyF.Flicker_Datagridview()
        Me.EXPEDIENTES_TAB = New System.Windows.Forms.TabPage()
        Me.EXPEDIENTES_DATAGRIDVIEW = New SICyF.Flicker_Datagridview()
        Me.Refresh_boton = New System.Windows.Forms.Button()
        Me.Modoconciliacion = New System.Windows.Forms.CheckBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Hasta_datetimepicker = New System.Windows.Forms.DateTimePicker()
        Me.Desde_datetimepicker = New System.Windows.Forms.DateTimePicker()
        Me.Busqueda_textbox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Cuentas_combobox = New System.Windows.Forms.ComboBox()
        Me.LABEL22 = New System.Windows.Forms.Label()
        Me.Detalles_tablelayout = New SICyF.Flicker_Tablelayout(Me.components)
        Me.SICYF_PANEL = New SICyF.PANEL_sinFlicker()
        Me.SoloseleccionadoMFyV_checkbox = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Detalle_Cheques_SICYF = New SICyF.Flicker_Datagridview()
        Me.MFyV_Panel = New SICyF.PANEL_sinFlicker()
        Me.SoloSeleccionadoSicyf_checkbox = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Detalle_Cheques_mfyv = New SICyF.Flicker_Datagridview()
        Me.BANCO_PANEL = New SICyF.PANEL_sinFlicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Detalle_Cheques_banco = New SICyF.Flicker_Datagridview()
        Me.PaneL_sinFlicker4 = New SICyF.PANEL_sinFlicker()
        Me.Agregacheques_button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Busqueda_detallada_textbox = New System.Windows.Forms.TextBox()
        CType(Me.Panelsplit_general, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panelsplit_general.Panel1.SuspendLayout()
        Me.Panelsplit_general.Panel2.SuspendLayout()
        Me.Panelsplit_general.SuspendLayout()
        Me.TABCONTROLGENERAL.SuspendLayout()
        Me.NUMTRANSF_TAB.SuspendLayout()
        CType(Me.CHEQUES_DATAGRIDVIEW, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EXPEDIENTES_TAB.SuspendLayout()
        CType(Me.EXPEDIENTES_DATAGRIDVIEW, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Detalles_tablelayout.SuspendLayout()
        Me.SICYF_PANEL.SuspendLayout()
        CType(Me.Detalle_Cheques_SICYF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MFyV_Panel.SuspendLayout()
        CType(Me.Detalle_Cheques_mfyv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BANCO_PANEL.SuspendLayout()
        CType(Me.Detalle_Cheques_banco, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PaneL_sinFlicker4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panelsplit_general
        '
        Me.Panelsplit_general.BackColor = System.Drawing.Color.LightBlue
        Me.Panelsplit_general.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panelsplit_general.Location = New System.Drawing.Point(0, 0)
        Me.Panelsplit_general.Name = "Panelsplit_general"
        '
        'Panelsplit_general.Panel1
        '
        Me.Panelsplit_general.Panel1.BackColor = System.Drawing.Color.White
        Me.Panelsplit_general.Panel1.Controls.Add(Me.TABCONTROLGENERAL)
        Me.Panelsplit_general.Panel1.Controls.Add(Me.Refresh_boton)
        Me.Panelsplit_general.Panel1.Controls.Add(Me.Modoconciliacion)
        Me.Panelsplit_general.Panel1.Controls.Add(Me.Label18)
        Me.Panelsplit_general.Panel1.Controls.Add(Me.Label19)
        Me.Panelsplit_general.Panel1.Controls.Add(Me.Hasta_datetimepicker)
        Me.Panelsplit_general.Panel1.Controls.Add(Me.Desde_datetimepicker)
        Me.Panelsplit_general.Panel1.Controls.Add(Me.Busqueda_textbox)
        Me.Panelsplit_general.Panel1.Controls.Add(Me.Label6)
        Me.Panelsplit_general.Panel1.Controls.Add(Me.Cuentas_combobox)
        Me.Panelsplit_general.Panel1.Controls.Add(Me.LABEL22)
        Me.Panelsplit_general.Panel1MinSize = 400
        '
        'Panelsplit_general.Panel2
        '
        Me.Panelsplit_general.Panel2.BackColor = System.Drawing.Color.White
        Me.Panelsplit_general.Panel2.Controls.Add(Me.Detalles_tablelayout)
        Me.Panelsplit_general.Size = New System.Drawing.Size(1125, 583)
        Me.Panelsplit_general.SplitterDistance = 563
        Me.Panelsplit_general.TabIndex = 0
        '
        'TABCONTROLGENERAL
        '
        Me.TABCONTROLGENERAL.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TABCONTROLGENERAL.Controls.Add(Me.NUMTRANSF_TAB)
        Me.TABCONTROLGENERAL.Controls.Add(Me.EXPEDIENTES_TAB)
        Me.TABCONTROLGENERAL.Location = New System.Drawing.Point(0, 52)
        Me.TABCONTROLGENERAL.Margin = New System.Windows.Forms.Padding(0)
        Me.TABCONTROLGENERAL.Name = "TABCONTROLGENERAL"
        Me.TABCONTROLGENERAL.SelectedIndex = 0
        Me.TABCONTROLGENERAL.Size = New System.Drawing.Size(561, 531)
        Me.TABCONTROLGENERAL.TabIndex = 160
        '
        'NUMTRANSF_TAB
        '
        Me.NUMTRANSF_TAB.Controls.Add(Me.CHEQUES_DATAGRIDVIEW)
        Me.NUMTRANSF_TAB.Location = New System.Drawing.Point(4, 22)
        Me.NUMTRANSF_TAB.Name = "NUMTRANSF_TAB"
        Me.NUMTRANSF_TAB.Padding = New System.Windows.Forms.Padding(3)
        Me.NUMTRANSF_TAB.Size = New System.Drawing.Size(553, 505)
        Me.NUMTRANSF_TAB.TabIndex = 0
        Me.NUMTRANSF_TAB.Text = "Nº TRANSF."
        Me.NUMTRANSF_TAB.UseVisualStyleBackColor = True
        '
        'CHEQUES_DATAGRIDVIEW
        '
        Me.CHEQUES_DATAGRIDVIEW.AllowUserToAddRows = False
        Me.CHEQUES_DATAGRIDVIEW.AllowUserToDeleteRows = False
        Me.CHEQUES_DATAGRIDVIEW.AllowUserToOrderColumns = True
        Me.CHEQUES_DATAGRIDVIEW.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CHEQUES_DATAGRIDVIEW.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.CHEQUES_DATAGRIDVIEW.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CHEQUES_DATAGRIDVIEW.DefaultCellStyle = DataGridViewCellStyle2
        Me.CHEQUES_DATAGRIDVIEW.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CHEQUES_DATAGRIDVIEW.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.CHEQUES_DATAGRIDVIEW.GridColor = System.Drawing.Color.Black
        Me.CHEQUES_DATAGRIDVIEW.Location = New System.Drawing.Point(3, 3)
        Me.CHEQUES_DATAGRIDVIEW.Margin = New System.Windows.Forms.Padding(0)
        Me.CHEQUES_DATAGRIDVIEW.Name = "CHEQUES_DATAGRIDVIEW"
        Me.CHEQUES_DATAGRIDVIEW.ReadOnly = True
        Me.CHEQUES_DATAGRIDVIEW.RowHeadersVisible = False
        Me.CHEQUES_DATAGRIDVIEW.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.CHEQUES_DATAGRIDVIEW.Size = New System.Drawing.Size(547, 499)
        Me.CHEQUES_DATAGRIDVIEW.TabIndex = 150
        '
        'EXPEDIENTES_TAB
        '
        Me.EXPEDIENTES_TAB.Controls.Add(Me.EXPEDIENTES_DATAGRIDVIEW)
        Me.EXPEDIENTES_TAB.Location = New System.Drawing.Point(4, 22)
        Me.EXPEDIENTES_TAB.Name = "EXPEDIENTES_TAB"
        Me.EXPEDIENTES_TAB.Padding = New System.Windows.Forms.Padding(3)
        Me.EXPEDIENTES_TAB.Size = New System.Drawing.Size(553, 505)
        Me.EXPEDIENTES_TAB.TabIndex = 1
        Me.EXPEDIENTES_TAB.Text = "EXPEDIENTES"
        Me.EXPEDIENTES_TAB.UseVisualStyleBackColor = True
        '
        'EXPEDIENTES_DATAGRIDVIEW
        '
        Me.EXPEDIENTES_DATAGRIDVIEW.AllowUserToAddRows = False
        Me.EXPEDIENTES_DATAGRIDVIEW.AllowUserToDeleteRows = False
        Me.EXPEDIENTES_DATAGRIDVIEW.AllowUserToOrderColumns = True
        Me.EXPEDIENTES_DATAGRIDVIEW.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.EXPEDIENTES_DATAGRIDVIEW.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EXPEDIENTES_DATAGRIDVIEW.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.EXPEDIENTES_DATAGRIDVIEW.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EXPEDIENTES_DATAGRIDVIEW.DefaultCellStyle = DataGridViewCellStyle4
        Me.EXPEDIENTES_DATAGRIDVIEW.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EXPEDIENTES_DATAGRIDVIEW.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.EXPEDIENTES_DATAGRIDVIEW.GridColor = System.Drawing.Color.Black
        Me.EXPEDIENTES_DATAGRIDVIEW.Location = New System.Drawing.Point(3, 3)
        Me.EXPEDIENTES_DATAGRIDVIEW.Margin = New System.Windows.Forms.Padding(0)
        Me.EXPEDIENTES_DATAGRIDVIEW.Name = "EXPEDIENTES_DATAGRIDVIEW"
        Me.EXPEDIENTES_DATAGRIDVIEW.ReadOnly = True
        Me.EXPEDIENTES_DATAGRIDVIEW.RowHeadersVisible = False
        Me.EXPEDIENTES_DATAGRIDVIEW.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.EXPEDIENTES_DATAGRIDVIEW.Size = New System.Drawing.Size(547, 499)
        Me.EXPEDIENTES_DATAGRIDVIEW.TabIndex = 151
        '
        'Refresh_boton
        '
        Me.Refresh_boton.BackColor = System.Drawing.Color.Green
        Me.Refresh_boton.BackgroundImage = CType(resources.GetObject("Refresh_boton.BackgroundImage"), System.Drawing.Image)
        Me.Refresh_boton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Refresh_boton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Refresh_boton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Refresh_boton.ForeColor = System.Drawing.Color.Black
        Me.Refresh_boton.Location = New System.Drawing.Point(259, 26)
        Me.Refresh_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Refresh_boton.Name = "Refresh_boton"
        Me.Refresh_boton.Size = New System.Drawing.Size(32, 26)
        Me.Refresh_boton.TabIndex = 159
        Me.Refresh_boton.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Refresh_boton.UseVisualStyleBackColor = False
        '
        'Modoconciliacion
        '
        Me.Modoconciliacion.AutoSize = True
        Me.Modoconciliacion.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Modoconciliacion.Location = New System.Drawing.Point(300, 26)
        Me.Modoconciliacion.Name = "Modoconciliacion"
        Me.Modoconciliacion.Size = New System.Drawing.Size(158, 25)
        Me.Modoconciliacion.TabIndex = 158
        Me.Modoconciliacion.Text = "Modo Conciliación"
        Me.Modoconciliacion.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(9, 5)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(36, 13)
        Me.Label18.TabIndex = 156
        Me.Label18.Text = "desde"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(156, 6)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(33, 13)
        Me.Label19.TabIndex = 157
        Me.Label19.Text = "hasta"
        '
        'Hasta_datetimepicker
        '
        Me.Hasta_datetimepicker.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Hasta_datetimepicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Hasta_datetimepicker.Location = New System.Drawing.Point(195, 3)
        Me.Hasta_datetimepicker.Name = "Hasta_datetimepicker"
        Me.Hasta_datetimepicker.Size = New System.Drawing.Size(96, 20)
        Me.Hasta_datetimepicker.TabIndex = 155
        '
        'Desde_datetimepicker
        '
        Me.Desde_datetimepicker.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Desde_datetimepicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Desde_datetimepicker.Location = New System.Drawing.Point(48, 3)
        Me.Desde_datetimepicker.Name = "Desde_datetimepicker"
        Me.Desde_datetimepicker.Size = New System.Drawing.Size(96, 20)
        Me.Desde_datetimepicker.TabIndex = 154
        '
        'Busqueda_textbox
        '
        Me.Busqueda_textbox.BackColor = System.Drawing.Color.White
        Me.Busqueda_textbox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Busqueda_textbox.ForeColor = System.Drawing.Color.Black
        Me.Busqueda_textbox.Location = New System.Drawing.Point(70, 27)
        Me.Busqueda_textbox.Name = "Busqueda_textbox"
        Me.Busqueda_textbox.Size = New System.Drawing.Size(181, 23)
        Me.Busqueda_textbox.TabIndex = 153
        Me.Busqueda_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(297, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 13)
        Me.Label6.TabIndex = 152
        Me.Label6.Text = "Cuenta Bancaria"
        '
        'Cuentas_combobox
        '
        Me.Cuentas_combobox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cuentas_combobox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cuentas_combobox.FormattingEnabled = True
        Me.Cuentas_combobox.Location = New System.Drawing.Point(389, 3)
        Me.Cuentas_combobox.Name = "Cuentas_combobox"
        Me.Cuentas_combobox.Size = New System.Drawing.Size(168, 23)
        Me.Cuentas_combobox.TabIndex = 149
        '
        'LABEL22
        '
        Me.LABEL22.AutoSize = True
        Me.LABEL22.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LABEL22.ForeColor = System.Drawing.Color.Black
        Me.LABEL22.Location = New System.Drawing.Point(-1, 26)
        Me.LABEL22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LABEL22.Name = "LABEL22"
        Me.LABEL22.Size = New System.Drawing.Size(64, 20)
        Me.LABEL22.TabIndex = 151
        Me.LABEL22.Text = "BUSCAR"
        '
        'Detalles_tablelayout
        '
        Me.Detalles_tablelayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial
        Me.Detalles_tablelayout.ColumnCount = 1
        Me.Detalles_tablelayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Detalles_tablelayout.Controls.Add(Me.SICYF_PANEL, 0, 1)
        Me.Detalles_tablelayout.Controls.Add(Me.MFyV_Panel, 0, 2)
        Me.Detalles_tablelayout.Controls.Add(Me.BANCO_PANEL, 0, 3)
        Me.Detalles_tablelayout.Controls.Add(Me.PaneL_sinFlicker4, 0, 0)
        Me.Detalles_tablelayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Detalles_tablelayout.Location = New System.Drawing.Point(0, 0)
        Me.Detalles_tablelayout.Name = "Detalles_tablelayout"
        Me.Detalles_tablelayout.RowCount = 4
        Me.Detalles_tablelayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39.0!))
        Me.Detalles_tablelayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.34201!))
        Me.Detalles_tablelayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.97026!))
        Me.Detalles_tablelayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.50186!))
        Me.Detalles_tablelayout.Size = New System.Drawing.Size(558, 583)
        Me.Detalles_tablelayout.TabIndex = 163
        '
        'SICYF_PANEL
        '
        Me.SICYF_PANEL.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SICYF_PANEL.Controls.Add(Me.SoloseleccionadoMFyV_checkbox)
        Me.SICYF_PANEL.Controls.Add(Me.Label2)
        Me.SICYF_PANEL.Controls.Add(Me.Detalle_Cheques_SICYF)
        Me.SICYF_PANEL.Location = New System.Drawing.Point(6, 48)
        Me.SICYF_PANEL.Name = "SICYF_PANEL"
        Me.SICYF_PANEL.Size = New System.Drawing.Size(546, 165)
        Me.SICYF_PANEL.TabIndex = 0
        '
        'SoloseleccionadoMFyV_checkbox
        '
        Me.SoloseleccionadoMFyV_checkbox.AutoSize = True
        Me.SoloseleccionadoMFyV_checkbox.BackColor = System.Drawing.Color.Transparent
        Me.SoloseleccionadoMFyV_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SoloseleccionadoMFyV_checkbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SoloseleccionadoMFyV_checkbox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SoloseleccionadoMFyV_checkbox.Location = New System.Drawing.Point(290, 2)
        Me.SoloseleccionadoMFyV_checkbox.Name = "SoloseleccionadoMFyV_checkbox"
        Me.SoloseleccionadoMFyV_checkbox.Size = New System.Drawing.Size(179, 17)
        Me.SoloseleccionadoMFyV_checkbox.TabIndex = 164
        Me.SoloseleccionadoMFyV_checkbox.Text = "Ver Solo lo seleccionado MFyV"
        Me.SoloseleccionadoMFyV_checkbox.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(1, 4)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 159
        Me.Label2.Text = "SICyF"
        '
        'Detalle_Cheques_SICYF
        '
        Me.Detalle_Cheques_SICYF.AllowUserToAddRows = False
        Me.Detalle_Cheques_SICYF.AllowUserToOrderColumns = True
        Me.Detalle_Cheques_SICYF.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Detalle_Cheques_SICYF.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Detalle_Cheques_SICYF.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Detalle_Cheques_SICYF.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Detalle_Cheques_SICYF.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.Detalle_Cheques_SICYF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Detalle_Cheques_SICYF.DefaultCellStyle = DataGridViewCellStyle6
        Me.Detalle_Cheques_SICYF.GridColor = System.Drawing.Color.Black
        Me.Detalle_Cheques_SICYF.Location = New System.Drawing.Point(1, 17)
        Me.Detalle_Cheques_SICYF.Name = "Detalle_Cheques_SICYF"
        Me.Detalle_Cheques_SICYF.ReadOnly = True
        Me.Detalle_Cheques_SICYF.RowHeadersVisible = False
        Me.Detalle_Cheques_SICYF.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Detalle_Cheques_SICYF.Size = New System.Drawing.Size(542, 145)
        Me.Detalle_Cheques_SICYF.TabIndex = 154
        '
        'MFyV_Panel
        '
        Me.MFyV_Panel.Controls.Add(Me.SoloSeleccionadoSicyf_checkbox)
        Me.MFyV_Panel.Controls.Add(Me.Label4)
        Me.MFyV_Panel.Controls.Add(Me.Detalle_Cheques_mfyv)
        Me.MFyV_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MFyV_Panel.Location = New System.Drawing.Point(6, 222)
        Me.MFyV_Panel.Name = "MFyV_Panel"
        Me.MFyV_Panel.Size = New System.Drawing.Size(546, 163)
        Me.MFyV_Panel.TabIndex = 1
        '
        'SoloSeleccionadoSicyf_checkbox
        '
        Me.SoloSeleccionadoSicyf_checkbox.AutoSize = True
        Me.SoloSeleccionadoSicyf_checkbox.BackColor = System.Drawing.Color.Transparent
        Me.SoloSeleccionadoSicyf_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SoloSeleccionadoSicyf_checkbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SoloSeleccionadoSicyf_checkbox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SoloSeleccionadoSicyf_checkbox.Location = New System.Drawing.Point(306, 0)
        Me.SoloSeleccionadoSicyf_checkbox.Name = "SoloSeleccionadoSicyf_checkbox"
        Me.SoloSeleccionadoSicyf_checkbox.Size = New System.Drawing.Size(178, 17)
        Me.SoloSeleccionadoSicyf_checkbox.TabIndex = 163
        Me.SoloSeleccionadoSicyf_checkbox.Text = "Ver Solo lo seleccionado SICyF"
        Me.SoloSeleccionadoSicyf_checkbox.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(1, 0)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 162
        Me.Label4.Text = "MFyV"
        '
        'Detalle_Cheques_mfyv
        '
        Me.Detalle_Cheques_mfyv.AllowUserToAddRows = False
        Me.Detalle_Cheques_mfyv.AllowUserToOrderColumns = True
        Me.Detalle_Cheques_mfyv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Detalle_Cheques_mfyv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Detalle_Cheques_mfyv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Detalle_Cheques_mfyv.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Detalle_Cheques_mfyv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.Detalle_Cheques_mfyv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Detalle_Cheques_mfyv.DefaultCellStyle = DataGridViewCellStyle8
        Me.Detalle_Cheques_mfyv.GridColor = System.Drawing.Color.Black
        Me.Detalle_Cheques_mfyv.Location = New System.Drawing.Point(3, 16)
        Me.Detalle_Cheques_mfyv.Name = "Detalle_Cheques_mfyv"
        Me.Detalle_Cheques_mfyv.ReadOnly = True
        Me.Detalle_Cheques_mfyv.RowHeadersVisible = False
        Me.Detalle_Cheques_mfyv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Detalle_Cheques_mfyv.Size = New System.Drawing.Size(540, 144)
        Me.Detalle_Cheques_mfyv.TabIndex = 161
        '
        'BANCO_PANEL
        '
        Me.BANCO_PANEL.Controls.Add(Me.Label3)
        Me.BANCO_PANEL.Controls.Add(Me.Detalle_Cheques_banco)
        Me.BANCO_PANEL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BANCO_PANEL.Location = New System.Drawing.Point(6, 394)
        Me.BANCO_PANEL.Name = "BANCO_PANEL"
        Me.BANCO_PANEL.Size = New System.Drawing.Size(546, 183)
        Me.BANCO_PANEL.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(1, 0)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 160
        Me.Label3.Text = "BANCO"
        '
        'Detalle_Cheques_banco
        '
        Me.Detalle_Cheques_banco.AllowUserToAddRows = False
        Me.Detalle_Cheques_banco.AllowUserToOrderColumns = True
        Me.Detalle_Cheques_banco.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Detalle_Cheques_banco.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Detalle_Cheques_banco.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Detalle_Cheques_banco.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Detalle_Cheques_banco.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.Detalle_Cheques_banco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Detalle_Cheques_banco.DefaultCellStyle = DataGridViewCellStyle10
        Me.Detalle_Cheques_banco.GridColor = System.Drawing.Color.Black
        Me.Detalle_Cheques_banco.Location = New System.Drawing.Point(3, 23)
        Me.Detalle_Cheques_banco.Name = "Detalle_Cheques_banco"
        Me.Detalle_Cheques_banco.ReadOnly = True
        Me.Detalle_Cheques_banco.RowHeadersVisible = False
        Me.Detalle_Cheques_banco.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Detalle_Cheques_banco.Size = New System.Drawing.Size(540, 157)
        Me.Detalle_Cheques_banco.TabIndex = 157
        '
        'PaneL_sinFlicker4
        '
        Me.PaneL_sinFlicker4.Controls.Add(Me.Agregacheques_button)
        Me.PaneL_sinFlicker4.Controls.Add(Me.Label1)
        Me.PaneL_sinFlicker4.Controls.Add(Me.Busqueda_detallada_textbox)
        Me.PaneL_sinFlicker4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PaneL_sinFlicker4.Location = New System.Drawing.Point(6, 6)
        Me.PaneL_sinFlicker4.Name = "PaneL_sinFlicker4"
        Me.PaneL_sinFlicker4.Size = New System.Drawing.Size(546, 33)
        Me.PaneL_sinFlicker4.TabIndex = 3
        '
        'Agregacheques_button
        '
        Me.Agregacheques_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Agregacheques_button.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Agregacheques_button.Image = CType(resources.GetObject("Agregacheques_button.Image"), System.Drawing.Image)
        Me.Agregacheques_button.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Agregacheques_button.Location = New System.Drawing.Point(329, 2)
        Me.Agregacheques_button.Margin = New System.Windows.Forms.Padding(0)
        Me.Agregacheques_button.Name = "Agregacheques_button"
        Me.Agregacheques_button.Size = New System.Drawing.Size(152, 28)
        Me.Agregacheques_button.TabIndex = 158
        Me.Agregacheques_button.Text = "Agregar Cheques"
        Me.Agregacheques_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Agregacheques_button.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(4, 7)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 20)
        Me.Label1.TabIndex = 156
        Me.Label1.Text = "BUSCAR"
        '
        'Busqueda_detallada_textbox
        '
        Me.Busqueda_detallada_textbox.BackColor = System.Drawing.Color.White
        Me.Busqueda_detallada_textbox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Busqueda_detallada_textbox.ForeColor = System.Drawing.Color.Black
        Me.Busqueda_detallada_textbox.Location = New System.Drawing.Point(75, 4)
        Me.Busqueda_detallada_textbox.Name = "Busqueda_detallada_textbox"
        Me.Busqueda_detallada_textbox.Size = New System.Drawing.Size(189, 23)
        Me.Busqueda_detallada_textbox.TabIndex = 155
        Me.Busqueda_detallada_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Tesoreria_cheques_listado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1125, 583)
        Me.Controls.Add(Me.Panelsplit_general)
        Me.Name = "Tesoreria_cheques_listado"
        Me.Text = "Chequera Modo Normal"
        Me.Panelsplit_general.Panel1.ResumeLayout(False)
        Me.Panelsplit_general.Panel1.PerformLayout()
        Me.Panelsplit_general.Panel2.ResumeLayout(False)
        CType(Me.Panelsplit_general, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panelsplit_general.ResumeLayout(False)
        Me.TABCONTROLGENERAL.ResumeLayout(False)
        Me.NUMTRANSF_TAB.ResumeLayout(False)
        CType(Me.CHEQUES_DATAGRIDVIEW, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EXPEDIENTES_TAB.ResumeLayout(False)
        CType(Me.EXPEDIENTES_DATAGRIDVIEW, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Detalles_tablelayout.ResumeLayout(False)
        Me.SICYF_PANEL.ResumeLayout(False)
        Me.SICYF_PANEL.PerformLayout()
        CType(Me.Detalle_Cheques_SICYF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MFyV_Panel.ResumeLayout(False)
        Me.MFyV_Panel.PerformLayout()
        CType(Me.Detalle_Cheques_mfyv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BANCO_PANEL.ResumeLayout(False)
        Me.BANCO_PANEL.PerformLayout()
        CType(Me.Detalle_Cheques_banco, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PaneL_sinFlicker4.ResumeLayout(False)
        Me.PaneL_sinFlicker4.PerformLayout()
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents Panelsplit_general As Flicker_Split_panel
    Friend WithEvents Busqueda_textbox As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Cuentas_combobox As ComboBox
    Friend WithEvents LABEL22 As Label
    Friend WithEvents CHEQUES_DATAGRIDVIEW As SICyF.Flicker_Datagridview
    Friend WithEvents Detalle_Cheques_SICYF As SICyF.Flicker_Datagridview
    Friend WithEvents Label1 As Label
    Friend WithEvents Busqueda_detallada_textbox As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Hasta_datetimepicker As DateTimePicker
    Friend WithEvents Desde_datetimepicker As DateTimePicker
    Friend WithEvents Detalle_Cheques_banco As SICyF.Flicker_Datagridview
    Friend WithEvents Label4 As Label
    Friend WithEvents Detalle_Cheques_mfyv As SICyF.Flicker_Datagridview
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Detalles_tablelayout As Flicker_Tablelayout
    Friend WithEvents SICYF_PANEL As PANEL_sinFlicker
    Friend WithEvents MFyV_Panel As PANEL_sinFlicker
    Friend WithEvents BANCO_PANEL As PANEL_sinFlicker
    Friend WithEvents PaneL_sinFlicker4 As PANEL_sinFlicker
    Friend WithEvents Agregacheques_button As Button
    Friend WithEvents SoloSeleccionadoSicyf_checkbox As CheckBox
    Friend WithEvents SoloseleccionadoMFyV_checkbox As CheckBox
    Friend WithEvents Modoconciliacion As CheckBox
    Friend WithEvents Refresh_boton As Button
    Friend WithEvents TABCONTROLGENERAL As FlickerTabcontrol
    Friend WithEvents NUMTRANSF_TAB As TabPage
    Friend WithEvents EXPEDIENTES_TAB As TabPage
    Friend WithEvents EXPEDIENTES_DATAGRIDVIEW As Flicker_Datagridview
End Class
