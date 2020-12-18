<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tesoreria_Retenciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tesoreria_Retenciones))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Flicker_Split_General = New SICyF.Flicker_Split_panel()
        Me.Flicker_Tablelayout1 = New SICyF.Flicker_Tablelayout(Me.components)
        Me.Retenciones_numero = New System.Windows.Forms.Button()
        Me.Recibos_boton = New System.Windows.Forms.Button()
        Me.Generacion_AFIP_boton = New System.Windows.Forms.Button()
        Me.Flicker_Split_Superior = New SICyF.Flicker_Split_panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Busqueda_textbox = New System.Windows.Forms.TextBox()
        Me.Refresh_boton = New System.Windows.Forms.Button()
        Me.Datos_Generales = New SICyF.Flicker_Datagridview()
        Me.Datos_Detallados = New SICyF.Flicker_Datagridview()
        CType(Me.Flicker_Split_General, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Flicker_Split_General.Panel1.SuspendLayout()
        Me.Flicker_Split_General.Panel2.SuspendLayout()
        Me.Flicker_Split_General.SuspendLayout()
        Me.Flicker_Tablelayout1.SuspendLayout()
        CType(Me.Flicker_Split_Superior, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Flicker_Split_Superior.Panel1.SuspendLayout()
        Me.Flicker_Split_Superior.Panel2.SuspendLayout()
        Me.Flicker_Split_Superior.SuspendLayout()
        CType(Me.Datos_Generales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Datos_Detallados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Flicker_Split_General
        '
        Me.Flicker_Split_General.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Flicker_Split_General.BackColor = System.Drawing.Color.LightBlue
        Me.Flicker_Split_General.Location = New System.Drawing.Point(2, 4)
        Me.Flicker_Split_General.Name = "Flicker_Split_General"
        Me.Flicker_Split_General.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'Flicker_Split_General.Panel1
        '
        Me.Flicker_Split_General.Panel1.BackColor = System.Drawing.Color.White
        Me.Flicker_Split_General.Panel1.Controls.Add(Me.Flicker_Tablelayout1)
        '
        'Flicker_Split_General.Panel2
        '
        Me.Flicker_Split_General.Panel2.BackColor = System.Drawing.Color.White
        Me.Flicker_Split_General.Panel2.Controls.Add(Me.Flicker_Split_Superior)
        Me.Flicker_Split_General.Size = New System.Drawing.Size(815, 479)
        Me.Flicker_Split_General.SplitterDistance = 27
        Me.Flicker_Split_General.TabIndex = 1
        '
        'Flicker_Tablelayout1
        '
        Me.Flicker_Tablelayout1.ColumnCount = 4
        Me.Flicker_Tablelayout1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.Flicker_Tablelayout1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.Flicker_Tablelayout1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.Flicker_Tablelayout1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.Flicker_Tablelayout1.Controls.Add(Me.Retenciones_numero, 0, 0)
        Me.Flicker_Tablelayout1.Controls.Add(Me.Recibos_boton, 0, 0)
        Me.Flicker_Tablelayout1.Controls.Add(Me.Generacion_AFIP_boton, 1, 0)
        Me.Flicker_Tablelayout1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flicker_Tablelayout1.Location = New System.Drawing.Point(0, 0)
        Me.Flicker_Tablelayout1.Name = "Flicker_Tablelayout1"
        Me.Flicker_Tablelayout1.RowCount = 1
        Me.Flicker_Tablelayout1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Flicker_Tablelayout1.Size = New System.Drawing.Size(815, 27)
        Me.Flicker_Tablelayout1.TabIndex = 0
        '
        'Retenciones_numero
        '
        Me.Retenciones_numero.BackColor = System.Drawing.Color.White
        Me.Retenciones_numero.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Retenciones_numero.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Retenciones_numero.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Retenciones_numero.ForeColor = System.Drawing.Color.ForestGreen
        Me.Retenciones_numero.Image = CType(resources.GetObject("Retenciones_numero.Image"), System.Drawing.Image)
        Me.Retenciones_numero.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Retenciones_numero.Location = New System.Drawing.Point(203, 0)
        Me.Retenciones_numero.Margin = New System.Windows.Forms.Padding(0)
        Me.Retenciones_numero.Name = "Retenciones_numero"
        Me.Retenciones_numero.Size = New System.Drawing.Size(203, 27)
        Me.Retenciones_numero.TabIndex = 10
        Me.Retenciones_numero.Text = "Movimientos de Retenciones"
        Me.Retenciones_numero.UseVisualStyleBackColor = False
        '
        'Recibos_boton
        '
        Me.Recibos_boton.BackColor = System.Drawing.Color.White
        Me.Recibos_boton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Recibos_boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Recibos_boton.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Recibos_boton.ForeColor = System.Drawing.Color.ForestGreen
        Me.Recibos_boton.Image = CType(resources.GetObject("Recibos_boton.Image"), System.Drawing.Image)
        Me.Recibos_boton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Recibos_boton.Location = New System.Drawing.Point(0, 0)
        Me.Recibos_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Recibos_boton.Name = "Recibos_boton"
        Me.Recibos_boton.Size = New System.Drawing.Size(203, 27)
        Me.Recibos_boton.TabIndex = 9
        Me.Recibos_boton.Text = "Cargar Recibos"
        Me.Recibos_boton.UseVisualStyleBackColor = False
        '
        'Generacion_AFIP_boton
        '
        Me.Generacion_AFIP_boton.BackColor = System.Drawing.Color.White
        Me.Generacion_AFIP_boton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Generacion_AFIP_boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Generacion_AFIP_boton.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Generacion_AFIP_boton.ForeColor = System.Drawing.Color.ForestGreen
        Me.Generacion_AFIP_boton.Image = Global.SICyF.My.Resources.Resources.logo_afip
        Me.Generacion_AFIP_boton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Generacion_AFIP_boton.Location = New System.Drawing.Point(406, 0)
        Me.Generacion_AFIP_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Generacion_AFIP_boton.Name = "Generacion_AFIP_boton"
        Me.Generacion_AFIP_boton.Size = New System.Drawing.Size(203, 27)
        Me.Generacion_AFIP_boton.TabIndex = 8
        Me.Generacion_AFIP_boton.Text = "Movimientos de Retenciones"
        Me.Generacion_AFIP_boton.UseVisualStyleBackColor = False
        '
        'Flicker_Split_Superior
        '
        Me.Flicker_Split_Superior.BackColor = System.Drawing.Color.LightBlue
        Me.Flicker_Split_Superior.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flicker_Split_Superior.Location = New System.Drawing.Point(0, 0)
        Me.Flicker_Split_Superior.Name = "Flicker_Split_Superior"
        '
        'Flicker_Split_Superior.Panel1
        '
        Me.Flicker_Split_Superior.Panel1.BackColor = System.Drawing.Color.White
        Me.Flicker_Split_Superior.Panel1.Controls.Add(Me.Button1)
        Me.Flicker_Split_Superior.Panel1.Controls.Add(Me.Busqueda_textbox)
        Me.Flicker_Split_Superior.Panel1.Controls.Add(Me.Refresh_boton)
        Me.Flicker_Split_Superior.Panel1.Controls.Add(Me.Datos_Generales)
        '
        'Flicker_Split_Superior.Panel2
        '
        Me.Flicker_Split_Superior.Panel2.BackColor = System.Drawing.Color.White
        Me.Flicker_Split_Superior.Panel2.Controls.Add(Me.Datos_Detallados)
        Me.Flicker_Split_Superior.Size = New System.Drawing.Size(815, 448)
        Me.Flicker_Split_Superior.SplitterDistance = 379
        Me.Flicker_Split_Superior.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Green
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(318, 2)
        Me.Button1.Margin = New System.Windows.Forms.Padding(0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 26)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Busqueda_textbox
        '
        Me.Busqueda_textbox.BackColor = System.Drawing.Color.White
        Me.Busqueda_textbox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Busqueda_textbox.ForeColor = System.Drawing.Color.Black
        Me.Busqueda_textbox.Location = New System.Drawing.Point(7, 5)
        Me.Busqueda_textbox.Name = "Busqueda_textbox"
        Me.Busqueda_textbox.Size = New System.Drawing.Size(263, 23)
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
        Me.Refresh_boton.Location = New System.Drawing.Point(273, 2)
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_Generales.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Datos_Generales.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Datos_Generales.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Datos_Generales.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_Generales.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Datos_Generales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_Generales.DefaultCellStyle = DataGridViewCellStyle3
        Me.Datos_Generales.Location = New System.Drawing.Point(3, 29)
        Me.Datos_Generales.Name = "Datos_Generales"
        Me.Datos_Generales.RowHeadersVisible = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_Generales.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.Datos_Generales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Datos_Generales.Size = New System.Drawing.Size(373, 416)
        Me.Datos_Generales.TabIndex = 1
        '
        'Datos_Detallados
        '
        Me.Datos_Detallados.AllowUserToAddRows = False
        Me.Datos_Detallados.AllowUserToDeleteRows = False
        Me.Datos_Detallados.AllowUserToOrderColumns = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_Detallados.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.Datos_Detallados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Datos_Detallados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Datos_Detallados.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_Detallados.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Datos_Detallados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_Detallados.DefaultCellStyle = DataGridViewCellStyle7
        Me.Datos_Detallados.Location = New System.Drawing.Point(3, 29)
        Me.Datos_Detallados.Name = "Datos_Detallados"
        Me.Datos_Detallados.RowHeadersVisible = False
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_Detallados.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.Datos_Detallados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Datos_Detallados.Size = New System.Drawing.Size(426, 415)
        Me.Datos_Detallados.TabIndex = 0
        '
        'Tesoreria_Retenciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(819, 486)
        Me.Controls.Add(Me.Flicker_Split_General)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Tesoreria_Retenciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Retenciones"
        Me.Flicker_Split_General.Panel1.ResumeLayout(False)
        Me.Flicker_Split_General.Panel2.ResumeLayout(False)
        CType(Me.Flicker_Split_General, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Flicker_Split_General.ResumeLayout(False)
        Me.Flicker_Tablelayout1.ResumeLayout(False)
        Me.Flicker_Split_Superior.Panel1.ResumeLayout(False)
        Me.Flicker_Split_Superior.Panel1.PerformLayout()
        Me.Flicker_Split_Superior.Panel2.ResumeLayout(False)
        CType(Me.Flicker_Split_Superior, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Flicker_Split_Superior.ResumeLayout(False)
        CType(Me.Datos_Generales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Datos_Detallados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents Flicker_Split_Superior As Flicker_Split_panel
    Friend WithEvents Datos_Generales As Flicker_Datagridview
    Friend WithEvents Datos_Detallados As Flicker_Datagridview
    Friend WithEvents Flicker_Split_General As Flicker_Split_panel
    Friend WithEvents Busqueda_textbox As TextBox
    Friend WithEvents Refresh_boton As Button
    Friend WithEvents Generacion_AFIP_boton As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Flicker_Tablelayout1 As Flicker_Tablelayout
    Friend WithEvents Recibos_boton As Button
    Friend WithEvents Retenciones_numero As Button
End Class
