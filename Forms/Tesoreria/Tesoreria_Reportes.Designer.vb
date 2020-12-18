<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Tesoreria_Reportes
    Inherits System.Windows.Forms.Form
    'Inherits ComponentFactory.Krypton.Toolkit.KryptonForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tesoreria_Reportes))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Year_numeric = New System.Windows.Forms.NumericUpDown()
        Me.Cuentas_combobox = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SplitContainergeneral = New System.Windows.Forms.SplitContainer()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Boton_Seleccionreporte = New System.Windows.Forms.Button()
        Me.Panelfechas = New System.Windows.Forms.Panel()
        Me.Busqueda_textbox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Hasta_DateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Desde_datetimepicker = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Buscar = New System.Windows.Forms.Button()
        Me.Reportes_datagridview = New SICyF.Flicker_Datagridview()
        Me.TipoReporte = New System.Windows.Forms.Label()
        CType(Me.Year_numeric, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainergeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainergeneral.Panel1.SuspendLayout()
        Me.SplitContainergeneral.Panel2.SuspendLayout()
        Me.SplitContainergeneral.SuspendLayout()
        Me.Panelfechas.SuspendLayout()
        CType(Me.Reportes_datagridview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(603, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Año"
        '
        'Year_numeric
        '
        Me.Year_numeric.Font = New System.Drawing.Font("Garamond", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Year_numeric.Location = New System.Drawing.Point(638, 2)
        Me.Year_numeric.Maximum = New Decimal(New Integer() {2200, 0, 0, 0})
        Me.Year_numeric.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.Year_numeric.Name = "Year_numeric"
        Me.Year_numeric.Size = New System.Drawing.Size(87, 24)
        Me.Year_numeric.TabIndex = 11
        Me.Year_numeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Year_numeric.Value = New Decimal(New Integer() {2000, 0, 0, 0})
        '
        'Cuentas_combobox
        '
        Me.Cuentas_combobox.FormattingEnabled = True
        Me.Cuentas_combobox.Location = New System.Drawing.Point(352, 4)
        Me.Cuentas_combobox.Name = "Cuentas_combobox"
        Me.Cuentas_combobox.Size = New System.Drawing.Size(247, 21)
        Me.Cuentas_combobox.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Tipo de Reporte"
        '
        'SplitContainergeneral
        '
        Me.SplitContainergeneral.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.SplitContainergeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainergeneral.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainergeneral.IsSplitterFixed = True
        Me.SplitContainergeneral.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainergeneral.Name = "SplitContainergeneral"
        Me.SplitContainergeneral.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainergeneral.Panel1
        '
        Me.SplitContainergeneral.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SplitContainergeneral.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainergeneral.Panel1.Controls.Add(Me.Boton_Seleccionreporte)
        Me.SplitContainergeneral.Panel1.Controls.Add(Me.Panelfechas)
        Me.SplitContainergeneral.Panel1.Controls.Add(Me.Year_numeric)
        Me.SplitContainergeneral.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainergeneral.Panel1.Controls.Add(Me.Cuentas_combobox)
        Me.SplitContainergeneral.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainergeneral.Panel1MinSize = 80
        '
        'SplitContainergeneral.Panel2
        '
        Me.SplitContainergeneral.Panel2.BackColor = System.Drawing.Color.White
        Me.SplitContainergeneral.Panel2.Controls.Add(Me.Reportes_datagridview)
        Me.SplitContainergeneral.Panel2.Controls.Add(Me.TipoReporte)
        Me.SplitContainergeneral.Size = New System.Drawing.Size(787, 477)
        Me.SplitContainergeneral.SplitterDistance = 80
        Me.SplitContainergeneral.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(265, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Cuenta Bancaria"
        '
        'Boton_Seleccionreporte
        '
        Me.Boton_Seleccionreporte.BackColor = System.Drawing.Color.SpringGreen
        Me.Boton_Seleccionreporte.Location = New System.Drawing.Point(93, 2)
        Me.Boton_Seleccionreporte.Name = "Boton_Seleccionreporte"
        Me.Boton_Seleccionreporte.Size = New System.Drawing.Size(166, 23)
        Me.Boton_Seleccionreporte.TabIndex = 22
        Me.Boton_Seleccionreporte.Text = "Seleccionar Reporte"
        Me.Boton_Seleccionreporte.UseVisualStyleBackColor = False
        '
        'Panelfechas
        '
        Me.Panelfechas.Controls.Add(Me.Busqueda_textbox)
        Me.Panelfechas.Controls.Add(Me.Label4)
        Me.Panelfechas.Controls.Add(Me.Hasta_DateTimePicker)
        Me.Panelfechas.Controls.Add(Me.Label2)
        Me.Panelfechas.Controls.Add(Me.Desde_datetimepicker)
        Me.Panelfechas.Controls.Add(Me.Label1)
        Me.Panelfechas.Controls.Add(Me.Buscar)
        Me.Panelfechas.Location = New System.Drawing.Point(12, 23)
        Me.Panelfechas.Margin = New System.Windows.Forms.Padding(0)
        Me.Panelfechas.Name = "Panelfechas"
        Me.Panelfechas.Size = New System.Drawing.Size(772, 55)
        Me.Panelfechas.TabIndex = 21
        Me.Panelfechas.Visible = False
        '
        'Busqueda_textbox
        '
        Me.Busqueda_textbox.BackColor = System.Drawing.Color.White
        Me.Busqueda_textbox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Busqueda_textbox.ForeColor = System.Drawing.Color.Black
        Me.Busqueda_textbox.Location = New System.Drawing.Point(81, 30)
        Me.Busqueda_textbox.Name = "Busqueda_textbox"
        Me.Busqueda_textbox.Size = New System.Drawing.Size(189, 23)
        Me.Busqueda_textbox.TabIndex = 117
        Me.Busqueda_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Image = CType(resources.GetObject("Label4.Image"), System.Drawing.Image)
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label4.Location = New System.Drawing.Point(3, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 22)
        Me.Label4.TabIndex = 118
        Me.Label4.Text = "Buscar"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Hasta_DateTimePicker
        '
        Me.Hasta_DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Hasta_DateTimePicker.Location = New System.Drawing.Point(192, 4)
        Me.Hasta_DateTimePicker.Name = "Hasta_DateTimePicker"
        Me.Hasta_DateTimePicker.Size = New System.Drawing.Size(98, 22)
        Me.Hasta_DateTimePicker.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(151, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Hasta"
        '
        'Desde_datetimepicker
        '
        Me.Desde_datetimepicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Desde_datetimepicker.Location = New System.Drawing.Point(47, 4)
        Me.Desde_datetimepicker.Name = "Desde_datetimepicker"
        Me.Desde_datetimepicker.Size = New System.Drawing.Size(98, 22)
        Me.Desde_datetimepicker.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Desde"
        '
        'Buscar
        '
        Me.Buscar.BackColor = System.Drawing.Color.LightYellow
        Me.Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Buscar.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Buscar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Buscar.Image = CType(resources.GetObject("Buscar.Image"), System.Drawing.Image)
        Me.Buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Buscar.Location = New System.Drawing.Point(340, 6)
        Me.Buscar.Margin = New System.Windows.Forms.Padding(0)
        Me.Buscar.Name = "Buscar"
        Me.Buscar.Size = New System.Drawing.Size(382, 33)
        Me.Buscar.TabIndex = 15
        Me.Buscar.Text = "Buscar"
        Me.Buscar.UseVisualStyleBackColor = False
        '
        'Reportes_datagridview
        '
        Me.Reportes_datagridview.AllowUserToAddRows = False
        Me.Reportes_datagridview.AllowUserToDeleteRows = False
        Me.Reportes_datagridview.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Reportes_datagridview.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Reportes_datagridview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Reportes_datagridview.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Reportes_datagridview.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.Reportes_datagridview.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(198, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Reportes_datagridview.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Reportes_datagridview.ColumnHeadersHeight = 40
        Me.Reportes_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(198, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Reportes_datagridview.DefaultCellStyle = DataGridViewCellStyle3
        Me.Reportes_datagridview.Location = New System.Drawing.Point(0, 1)
        Me.Reportes_datagridview.Name = "Reportes_datagridview"
        Me.Reportes_datagridview.RowHeadersVisible = False
        Me.Reportes_datagridview.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Reportes_datagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Reportes_datagridview.Size = New System.Drawing.Size(787, 392)
        Me.Reportes_datagridview.TabIndex = 28
        '
        'TipoReporte
        '
        Me.TipoReporte.AutoSize = True
        Me.TipoReporte.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TipoReporte.Location = New System.Drawing.Point(3, 1)
        Me.TipoReporte.Name = "TipoReporte"
        Me.TipoReporte.Size = New System.Drawing.Size(13, 17)
        Me.TipoReporte.TabIndex = 23
        Me.TipoReporte.Text = "_"
        '
        'Tesoreria_Reportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(787, 477)
        Me.Controls.Add(Me.SplitContainergeneral)
        Me.Name = "Tesoreria_Reportes"
        Me.Text = "Reportes"
        CType(Me.Year_numeric, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainergeneral.Panel1.ResumeLayout(False)
        Me.SplitContainergeneral.Panel1.PerformLayout()
        Me.SplitContainergeneral.Panel2.ResumeLayout(False)
        Me.SplitContainergeneral.Panel2.PerformLayout()
        CType(Me.SplitContainergeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainergeneral.ResumeLayout(False)
        Me.Panelfechas.ResumeLayout(False)
        Me.Panelfechas.PerformLayout()
        CType(Me.Reportes_datagridview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents Cuentas_combobox As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Reportes_datagridview As Flicker_Datagridview
    Friend WithEvents Label8 As Label
    Friend WithEvents Year_numeric As NumericUpDown
    Friend WithEvents SplitContainergeneral As SplitContainer
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Hasta_DateTimePicker As DateTimePicker
    Friend WithEvents Desde_datetimepicker As DateTimePicker
    Friend WithEvents Panelfechas As Panel
    Friend WithEvents Boton_Seleccionreporte As Button
    Friend WithEvents TipoReporte As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Buscar As Button
    Friend WithEvents Busqueda_textbox As TextBox
    Friend WithEvents Label4 As Label
End Class
