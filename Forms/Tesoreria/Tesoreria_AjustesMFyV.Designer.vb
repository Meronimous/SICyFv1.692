<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tesoreria_AjustesMFyV
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tesoreria_AjustesMFyV))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Flicker_Split_General = New SICyF.Flicker_Split_panel()
        Me.Cuenta_N_Label = New System.Windows.Forms.Label()
        Me.Formavisualizacion = New System.Windows.Forms.Button()
        Me.Panelfechas = New System.Windows.Forms.Panel()
        Me.Hasta_DateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Desde_datetimepicker = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cuentas_combobox = New System.Windows.Forms.ComboBox()
        Me.Busqueda_textbox = New System.Windows.Forms.TextBox()
        Me.Refresh_boton = New System.Windows.Forms.Button()
        Me.Datos_Generales = New SICyF.Flicker_Datagridview()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Flicker_Split_Superior = New SICyF.Flicker_Split_panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Busqueda_SICyF = New System.Windows.Forms.TextBox()
        Me.Datos_SICyF = New SICyF.Flicker_Datagridview()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Busqueda_MFyV = New System.Windows.Forms.TextBox()
        Me.Datos_MFyV = New SICyF.Flicker_Datagridview()
        CType(Me.Flicker_Split_General, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Flicker_Split_General.Panel1.SuspendLayout()
        Me.Flicker_Split_General.Panel2.SuspendLayout()
        Me.Flicker_Split_General.SuspendLayout()
        Me.Panelfechas.SuspendLayout()
        CType(Me.Datos_Generales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Flicker_Split_Superior, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Flicker_Split_Superior.Panel1.SuspendLayout()
        Me.Flicker_Split_Superior.Panel2.SuspendLayout()
        Me.Flicker_Split_Superior.SuspendLayout()
        CType(Me.Datos_SICyF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Datos_MFyV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Flicker_Split_General
        '
        Me.Flicker_Split_General.BackColor = System.Drawing.Color.LightBlue
        Me.Flicker_Split_General.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flicker_Split_General.Location = New System.Drawing.Point(0, 0)
        Me.Flicker_Split_General.Name = "Flicker_Split_General"
        Me.Flicker_Split_General.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'Flicker_Split_General.Panel1
        '
        Me.Flicker_Split_General.Panel1.BackColor = System.Drawing.Color.White
        Me.Flicker_Split_General.Panel1.Controls.Add(Me.Cuenta_N_Label)
        Me.Flicker_Split_General.Panel1.Controls.Add(Me.Formavisualizacion)
        Me.Flicker_Split_General.Panel1.Controls.Add(Me.Panelfechas)
        Me.Flicker_Split_General.Panel1.Controls.Add(Me.Cuentas_combobox)
        Me.Flicker_Split_General.Panel1.Controls.Add(Me.Busqueda_textbox)
        Me.Flicker_Split_General.Panel1.Controls.Add(Me.Refresh_boton)
        Me.Flicker_Split_General.Panel1.Controls.Add(Me.Datos_Generales)
        Me.Flicker_Split_General.Panel1.Controls.Add(Me.Label4)
        '
        'Flicker_Split_General.Panel2
        '
        Me.Flicker_Split_General.Panel2.BackColor = System.Drawing.Color.White
        Me.Flicker_Split_General.Panel2.Controls.Add(Me.Flicker_Split_Superior)
        Me.Flicker_Split_General.Size = New System.Drawing.Size(927, 780)
        Me.Flicker_Split_General.SplitterDistance = 390
        Me.Flicker_Split_General.TabIndex = 2
        '
        'Cuenta_N_Label
        '
        Me.Cuenta_N_Label.AutoSize = True
        Me.Cuenta_N_Label.BackColor = System.Drawing.Color.Transparent
        Me.Cuenta_N_Label.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cuenta_N_Label.Location = New System.Drawing.Point(528, 38)
        Me.Cuenta_N_Label.Name = "Cuenta_N_Label"
        Me.Cuenta_N_Label.Size = New System.Drawing.Size(0, 17)
        Me.Cuenta_N_Label.TabIndex = 30
        '
        'Formavisualizacion
        '
        Me.Formavisualizacion.BackColor = System.Drawing.Color.LightBlue
        Me.Formavisualizacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Formavisualizacion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Formavisualizacion.Location = New System.Drawing.Point(13, 3)
        Me.Formavisualizacion.Name = "Formavisualizacion"
        Me.Formavisualizacion.Size = New System.Drawing.Size(214, 23)
        Me.Formavisualizacion.TabIndex = 29
        Me.Formavisualizacion.Text = "Forma de Visualización"
        Me.Formavisualizacion.UseVisualStyleBackColor = False
        '
        'Panelfechas
        '
        Me.Panelfechas.BackColor = System.Drawing.Color.Transparent
        Me.Panelfechas.Controls.Add(Me.Hasta_DateTimePicker)
        Me.Panelfechas.Controls.Add(Me.Label2)
        Me.Panelfechas.Controls.Add(Me.Desde_datetimepicker)
        Me.Panelfechas.Controls.Add(Me.Label1)
        Me.Panelfechas.Location = New System.Drawing.Point(233, 3)
        Me.Panelfechas.Name = "Panelfechas"
        Me.Panelfechas.Size = New System.Drawing.Size(295, 30)
        Me.Panelfechas.TabIndex = 27
        '
        'Hasta_DateTimePicker
        '
        Me.Hasta_DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Hasta_DateTimePicker.Location = New System.Drawing.Point(195, 4)
        Me.Hasta_DateTimePicker.Name = "Hasta_DateTimePicker"
        Me.Hasta_DateTimePicker.Size = New System.Drawing.Size(98, 20)
        Me.Hasta_DateTimePicker.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(154, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Hasta"
        '
        'Desde_datetimepicker
        '
        Me.Desde_datetimepicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Desde_datetimepicker.Location = New System.Drawing.Point(47, 4)
        Me.Desde_datetimepicker.Name = "Desde_datetimepicker"
        Me.Desde_datetimepicker.Size = New System.Drawing.Size(98, 20)
        Me.Desde_datetimepicker.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Desde"
        '
        'Cuentas_combobox
        '
        Me.Cuentas_combobox.FormattingEnabled = True
        Me.Cuentas_combobox.Location = New System.Drawing.Point(531, 14)
        Me.Cuentas_combobox.Name = "Cuentas_combobox"
        Me.Cuentas_combobox.Size = New System.Drawing.Size(296, 21)
        Me.Cuentas_combobox.TabIndex = 26
        '
        'Busqueda_textbox
        '
        Me.Busqueda_textbox.BackColor = System.Drawing.Color.White
        Me.Busqueda_textbox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Busqueda_textbox.ForeColor = System.Drawing.Color.Black
        Me.Busqueda_textbox.Location = New System.Drawing.Point(12, 27)
        Me.Busqueda_textbox.Name = "Busqueda_textbox"
        Me.Busqueda_textbox.Size = New System.Drawing.Size(215, 23)
        Me.Busqueda_textbox.TabIndex = 24
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
        Me.Refresh_boton.Location = New System.Drawing.Point(830, 7)
        Me.Refresh_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Refresh_boton.Name = "Refresh_boton"
        Me.Refresh_boton.Size = New System.Drawing.Size(32, 26)
        Me.Refresh_boton.TabIndex = 25
        Me.Refresh_boton.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Refresh_boton.UseVisualStyleBackColor = False
        '
        'Datos_Generales
        '
        Me.Datos_Generales.AllowUserToAddRows = False
        Me.Datos_Generales.AllowUserToDeleteRows = False
        Me.Datos_Generales.AllowUserToOrderColumns = True
        Me.Datos_Generales.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Datos_Generales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.Datos_Generales.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Datos_Generales.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_Generales.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Datos_Generales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_Generales.DefaultCellStyle = DataGridViewCellStyle2
        Me.Datos_Generales.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.Datos_Generales.Location = New System.Drawing.Point(3, 56)
        Me.Datos_Generales.Name = "Datos_Generales"
        Me.Datos_Generales.RowHeadersVisible = False
        Me.Datos_Generales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Datos_Generales.Size = New System.Drawing.Size(921, 331)
        Me.Datos_Generales.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(531, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 17)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Cuenta Bancaria"
        '
        'Flicker_Split_Superior
        '
        Me.Flicker_Split_Superior.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Flicker_Split_Superior.BackColor = System.Drawing.Color.LightBlue
        Me.Flicker_Split_Superior.Location = New System.Drawing.Point(6, 3)
        Me.Flicker_Split_Superior.Name = "Flicker_Split_Superior"
        '
        'Flicker_Split_Superior.Panel1
        '
        Me.Flicker_Split_Superior.Panel1.BackColor = System.Drawing.Color.White
        Me.Flicker_Split_Superior.Panel1.Controls.Add(Me.Label3)
        Me.Flicker_Split_Superior.Panel1.Controls.Add(Me.Busqueda_SICyF)
        Me.Flicker_Split_Superior.Panel1.Controls.Add(Me.Datos_SICyF)
        '
        'Flicker_Split_Superior.Panel2
        '
        Me.Flicker_Split_Superior.Panel2.BackColor = System.Drawing.Color.White
        Me.Flicker_Split_Superior.Panel2.Controls.Add(Me.Label5)
        Me.Flicker_Split_Superior.Panel2.Controls.Add(Me.Busqueda_MFyV)
        Me.Flicker_Split_Superior.Panel2.Controls.Add(Me.Datos_MFyV)
        Me.Flicker_Split_Superior.Size = New System.Drawing.Size(921, 384)
        Me.Flicker_Split_Superior.SplitterDistance = 429
        Me.Flicker_Split_Superior.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label3.Location = New System.Drawing.Point(211, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 17)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "SICyF"
        '
        'Busqueda_SICyF
        '
        Me.Busqueda_SICyF.BackColor = System.Drawing.Color.White
        Me.Busqueda_SICyF.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Busqueda_SICyF.ForeColor = System.Drawing.Color.Black
        Me.Busqueda_SICyF.Location = New System.Drawing.Point(6, 3)
        Me.Busqueda_SICyF.Name = "Busqueda_SICyF"
        Me.Busqueda_SICyF.Size = New System.Drawing.Size(199, 23)
        Me.Busqueda_SICyF.TabIndex = 25
        Me.Busqueda_SICyF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Datos_SICyF
        '
        Me.Datos_SICyF.AllowUserToAddRows = False
        Me.Datos_SICyF.AllowUserToDeleteRows = False
        Me.Datos_SICyF.AllowUserToOrderColumns = True
        Me.Datos_SICyF.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Datos_SICyF.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.Datos_SICyF.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Datos_SICyF.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_SICyF.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Datos_SICyF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_SICyF.DefaultCellStyle = DataGridViewCellStyle4
        Me.Datos_SICyF.Location = New System.Drawing.Point(6, 29)
        Me.Datos_SICyF.Name = "Datos_SICyF"
        Me.Datos_SICyF.RowHeadersVisible = False
        Me.Datos_SICyF.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Datos_SICyF.Size = New System.Drawing.Size(420, 351)
        Me.Datos_SICyF.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label5.Location = New System.Drawing.Point(220, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 17)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "MFyV"
        '
        'Busqueda_MFyV
        '
        Me.Busqueda_MFyV.BackColor = System.Drawing.Color.White
        Me.Busqueda_MFyV.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Busqueda_MFyV.ForeColor = System.Drawing.Color.Black
        Me.Busqueda_MFyV.Location = New System.Drawing.Point(3, 3)
        Me.Busqueda_MFyV.Name = "Busqueda_MFyV"
        Me.Busqueda_MFyV.Size = New System.Drawing.Size(211, 23)
        Me.Busqueda_MFyV.TabIndex = 26
        Me.Busqueda_MFyV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Datos_MFyV
        '
        Me.Datos_MFyV.AllowUserToAddRows = False
        Me.Datos_MFyV.AllowUserToDeleteRows = False
        Me.Datos_MFyV.AllowUserToOrderColumns = True
        Me.Datos_MFyV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Datos_MFyV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.Datos_MFyV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Datos_MFyV.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_MFyV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.Datos_MFyV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_MFyV.DefaultCellStyle = DataGridViewCellStyle6
        Me.Datos_MFyV.Location = New System.Drawing.Point(3, 29)
        Me.Datos_MFyV.Name = "Datos_MFyV"
        Me.Datos_MFyV.RowHeadersVisible = False
        Me.Datos_MFyV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Datos_MFyV.Size = New System.Drawing.Size(482, 352)
        Me.Datos_MFyV.TabIndex = 0
        '
        'Tesoreria_AjustesMFyV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 780)
        Me.Controls.Add(Me.Flicker_Split_General)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "Tesoreria_AjustesMFyV"
        Me.Text = "Tesoreria_AjustesMFyV"
        Me.Flicker_Split_General.Panel1.ResumeLayout(False)
        Me.Flicker_Split_General.Panel1.PerformLayout()
        Me.Flicker_Split_General.Panel2.ResumeLayout(False)
        CType(Me.Flicker_Split_General, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Flicker_Split_General.ResumeLayout(False)
        Me.Panelfechas.ResumeLayout(False)
        Me.Panelfechas.PerformLayout()
        CType(Me.Datos_Generales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Flicker_Split_Superior.Panel1.ResumeLayout(False)
        Me.Flicker_Split_Superior.Panel1.PerformLayout()
        Me.Flicker_Split_Superior.Panel2.ResumeLayout(False)
        Me.Flicker_Split_Superior.Panel2.PerformLayout()
        CType(Me.Flicker_Split_Superior, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Flicker_Split_Superior.ResumeLayout(False)
        CType(Me.Datos_SICyF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Datos_MFyV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents Flicker_Split_General As Flicker_Split_panel
    Friend WithEvents Flicker_Split_Superior As Flicker_Split_panel
    Friend WithEvents Busqueda_textbox As TextBox
    Friend WithEvents Refresh_boton As Button
    Friend WithEvents Datos_Generales As Flicker_Datagridview
    Friend WithEvents Datos_MFyV As Flicker_Datagridview
    Friend WithEvents Panelfechas As Panel
    Friend WithEvents Hasta_DateTimePicker As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Desde_datetimepicker As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Cuentas_combobox As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Busqueda_SICyF As TextBox
    Friend WithEvents Datos_SICyF As Flicker_Datagridview
    Friend WithEvents Busqueda_MFyV As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Formavisualizacion As Button
    Friend WithEvents Cuenta_N_Label As Label
End Class
