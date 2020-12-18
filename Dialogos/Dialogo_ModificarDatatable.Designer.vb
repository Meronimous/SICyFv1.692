<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialogo_ModificarDatatable
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dialogo_ModificarDatatable))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panelsuperior = New System.Windows.Forms.Panel()
        Me.FullScreen_boton = New System.Windows.Forms.Button()
        Me.Cerrar_boton = New System.Windows.Forms.Button()
        Me.Label_titulo = New System.Windows.Forms.Label()
        Me.Flicker_Tablelayout1 = New SICyF.Flicker_Tablelayout(Me.components)
        Me.Guardar_boton = New System.Windows.Forms.Button()
        Me.Cancelar_boton = New System.Windows.Forms.Button()
        Me.Datos_datagridview = New SICyF.Flicker_Datagridview()
        Me.Panelsuperior.SuspendLayout()
        Me.Flicker_Tablelayout1.SuspendLayout()
        CType(Me.Datos_datagridview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panelsuperior
        '
        Me.Panelsuperior.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(134, Byte), Integer))
        Me.Panelsuperior.Controls.Add(Me.FullScreen_boton)
        Me.Panelsuperior.Controls.Add(Me.Cerrar_boton)
        Me.Panelsuperior.Controls.Add(Me.Label_titulo)
        Me.Panelsuperior.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panelsuperior.Location = New System.Drawing.Point(0, 0)
        Me.Panelsuperior.Margin = New System.Windows.Forms.Padding(0)
        Me.Panelsuperior.Name = "Panelsuperior"
        Me.Panelsuperior.Size = New System.Drawing.Size(825, 44)
        Me.Panelsuperior.TabIndex = 112
        '
        'FullScreen_boton
        '
        Me.FullScreen_boton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FullScreen_boton.BackColor = System.Drawing.Color.Azure
        Me.FullScreen_boton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.FullScreen_boton.FlatAppearance.BorderSize = 0
        Me.FullScreen_boton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.FullScreen_boton.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.FullScreen_boton.Image = CType(resources.GetObject("FullScreen_boton.Image"), System.Drawing.Image)
        Me.FullScreen_boton.Location = New System.Drawing.Point(702, 0)
        Me.FullScreen_boton.Name = "FullScreen_boton"
        Me.FullScreen_boton.Size = New System.Drawing.Size(60, 41)
        Me.FullScreen_boton.TabIndex = 31
        Me.FullScreen_boton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.FullScreen_boton.UseVisualStyleBackColor = False
        '
        'Cerrar_boton
        '
        Me.Cerrar_boton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cerrar_boton.BackColor = System.Drawing.Color.Azure
        Me.Cerrar_boton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Cerrar_boton.FlatAppearance.BorderSize = 0
        Me.Cerrar_boton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cerrar_boton.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Cerrar_boton.Image = CType(resources.GetObject("Cerrar_boton.Image"), System.Drawing.Image)
        Me.Cerrar_boton.Location = New System.Drawing.Point(760, 0)
        Me.Cerrar_boton.Name = "Cerrar_boton"
        Me.Cerrar_boton.Size = New System.Drawing.Size(60, 41)
        Me.Cerrar_boton.TabIndex = 30
        Me.Cerrar_boton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cerrar_boton.UseVisualStyleBackColor = False
        '
        'Label_titulo
        '
        Me.Label_titulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_titulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(134, Byte), Integer))
        Me.Label_titulo.Font = New System.Drawing.Font("Raleway Black", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_titulo.ForeColor = System.Drawing.Color.White
        Me.Label_titulo.Location = New System.Drawing.Point(4, 0)
        Me.Label_titulo.Name = "Label_titulo"
        Me.Label_titulo.Size = New System.Drawing.Size(692, 41)
        Me.Label_titulo.TabIndex = 29
        Me.Label_titulo.Text = "MOD"
        Me.Label_titulo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Flicker_Tablelayout1
        '
        Me.Flicker_Tablelayout1.ColumnCount = 2
        Me.Flicker_Tablelayout1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Flicker_Tablelayout1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Flicker_Tablelayout1.Controls.Add(Me.Guardar_boton, 0, 0)
        Me.Flicker_Tablelayout1.Controls.Add(Me.Cancelar_boton, 1, 0)
        Me.Flicker_Tablelayout1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Flicker_Tablelayout1.Location = New System.Drawing.Point(0, 564)
        Me.Flicker_Tablelayout1.Name = "Flicker_Tablelayout1"
        Me.Flicker_Tablelayout1.RowCount = 1
        Me.Flicker_Tablelayout1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Flicker_Tablelayout1.Size = New System.Drawing.Size(825, 39)
        Me.Flicker_Tablelayout1.TabIndex = 718
        '
        'Guardar_boton
        '
        Me.Guardar_boton.BackColor = System.Drawing.Color.DarkGreen
        Me.Guardar_boton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Guardar_boton.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guardar_boton.ForeColor = System.Drawing.Color.White
        Me.Guardar_boton.Location = New System.Drawing.Point(0, 0)
        Me.Guardar_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Guardar_boton.Name = "Guardar_boton"
        Me.Guardar_boton.Size = New System.Drawing.Size(412, 39)
        Me.Guardar_boton.TabIndex = 716
        Me.Guardar_boton.Text = "Guardar"
        Me.Guardar_boton.UseVisualStyleBackColor = False
        '
        'Cancelar_boton
        '
        Me.Cancelar_boton.BackColor = System.Drawing.Color.DarkRed
        Me.Cancelar_boton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Cancelar_boton.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancelar_boton.ForeColor = System.Drawing.Color.White
        Me.Cancelar_boton.Location = New System.Drawing.Point(412, 0)
        Me.Cancelar_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Cancelar_boton.Name = "Cancelar_boton"
        Me.Cancelar_boton.Size = New System.Drawing.Size(413, 39)
        Me.Cancelar_boton.TabIndex = 18
        Me.Cancelar_boton.Text = "Cancelar"
        Me.Cancelar_boton.UseVisualStyleBackColor = False
        '
        'Datos_datagridview
        '
        Me.Datos_datagridview.AllowUserToOrderColumns = True
        Me.Datos_datagridview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Datos_datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.Datos_datagridview.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.Datos_datagridview.BackgroundColor = System.Drawing.Color.White
        Me.Datos_datagridview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_datagridview.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Datos_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_datagridview.DefaultCellStyle = DataGridViewCellStyle2
        Me.Datos_datagridview.EnableHeadersVisualStyles = False
        Me.Datos_datagridview.Location = New System.Drawing.Point(0, 47)
        Me.Datos_datagridview.Name = "Datos_datagridview"
        Me.Datos_datagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Datos_datagridview.Size = New System.Drawing.Size(825, 511)
        Me.Datos_datagridview.TabIndex = 0
        Me.Datos_datagridview.VirtualMode = True
        '
        'Dialogo_ModificarDatatable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(134, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(825, 603)
        Me.ControlBox = False
        Me.Controls.Add(Me.Flicker_Tablelayout1)
        Me.Controls.Add(Me.Datos_datagridview)
        Me.Controls.Add(Me.Panelsuperior)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Dialogo_ModificarDatatable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panelsuperior.ResumeLayout(False)
        Me.Flicker_Tablelayout1.ResumeLayout(False)
        CType(Me.Datos_datagridview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents Panelsuperior As Panel
    Friend WithEvents Cerrar_boton As Button
    Friend WithEvents Label_titulo As Label
    Friend WithEvents Datos_datagridview As Flicker_Datagridview
    Friend WithEvents Flicker_Tablelayout1 As Flicker_Tablelayout
    Friend WithEvents Guardar_boton As Button
    Friend WithEvents Cancelar_boton As Button
    Friend WithEvents FullScreen_boton As Button
End Class
