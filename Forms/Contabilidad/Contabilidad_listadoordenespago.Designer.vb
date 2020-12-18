<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Contabilidad_listadoordenespago
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_listadoordenespago))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Busqueda_OP = New System.Windows.Forms.TextBox()
        Me.Refresh_op = New System.Windows.Forms.Button()
        Me.Datos_ordenpago = New SICyF.Flicker_Datagridview()
        Me.Flicker_Split_panel1 = New SICyF.Flicker_Split_panel()
        Me.IMPRIMIR_BOTON = New System.Windows.Forms.Button()
        Me.Datos_ordenpago_detalle = New SICyF.Flicker_Datagridview()
        CType(Me.Datos_ordenpago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Flicker_Split_panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Flicker_Split_panel1.Panel1.SuspendLayout()
        Me.Flicker_Split_panel1.Panel2.SuspendLayout()
        Me.Flicker_Split_panel1.SuspendLayout()
        CType(Me.Datos_ordenpago_detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Busqueda_OP
        '
        Me.Busqueda_OP.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.Busqueda_OP.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Busqueda_OP.ForeColor = System.Drawing.Color.Black
        Me.Busqueda_OP.Location = New System.Drawing.Point(3, 3)
        Me.Busqueda_OP.Name = "Busqueda_OP"
        Me.Busqueda_OP.Size = New System.Drawing.Size(279, 23)
        Me.Busqueda_OP.TabIndex = 34
        Me.Busqueda_OP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Refresh_op
        '
        Me.Refresh_op.BackColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Refresh_op.BackgroundImage = CType(resources.GetObject("Refresh_op.BackgroundImage"), System.Drawing.Image)
        Me.Refresh_op.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Refresh_op.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Refresh_op.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Refresh_op.ForeColor = System.Drawing.Color.Black
        Me.Refresh_op.Location = New System.Drawing.Point(285, 3)
        Me.Refresh_op.Margin = New System.Windows.Forms.Padding(0)
        Me.Refresh_op.Name = "Refresh_op"
        Me.Refresh_op.Size = New System.Drawing.Size(32, 26)
        Me.Refresh_op.TabIndex = 35
        Me.Refresh_op.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Refresh_op.UseVisualStyleBackColor = False
        '
        'Datos_ordenpago
        '
        Me.Datos_ordenpago.AllowUserToAddRows = False
        Me.Datos_ordenpago.AllowUserToOrderColumns = True
        Me.Datos_ordenpago.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Datos_ordenpago.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Datos_ordenpago.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_ordenpago.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Datos_ordenpago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(198, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_ordenpago.DefaultCellStyle = DataGridViewCellStyle2
        Me.Datos_ordenpago.Location = New System.Drawing.Point(3, 32)
        Me.Datos_ordenpago.Name = "Datos_ordenpago"
        Me.Datos_ordenpago.RowHeadersVisible = False
        Me.Datos_ordenpago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Datos_ordenpago.Size = New System.Drawing.Size(452, 365)
        Me.Datos_ordenpago.TabIndex = 33
        '
        'Flicker_Split_panel1
        '
        Me.Flicker_Split_panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Flicker_Split_panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flicker_Split_panel1.Location = New System.Drawing.Point(0, 0)
        Me.Flicker_Split_panel1.Name = "Flicker_Split_panel1"
        '
        'Flicker_Split_panel1.Panel1
        '
        Me.Flicker_Split_panel1.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.Flicker_Split_panel1.Panel1.Controls.Add(Me.IMPRIMIR_BOTON)
        Me.Flicker_Split_panel1.Panel1.Controls.Add(Me.Datos_ordenpago)
        Me.Flicker_Split_panel1.Panel1.Controls.Add(Me.Refresh_op)
        Me.Flicker_Split_panel1.Panel1.Controls.Add(Me.Busqueda_OP)
        '
        'Flicker_Split_panel1.Panel2
        '
        Me.Flicker_Split_panel1.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.Flicker_Split_panel1.Panel2.Controls.Add(Me.Datos_ordenpago_detalle)
        Me.Flicker_Split_panel1.Size = New System.Drawing.Size(804, 400)
        Me.Flicker_Split_panel1.SplitterDistance = 458
        Me.Flicker_Split_panel1.TabIndex = 37
        '
        'IMPRIMIR_BOTON
        '
        Me.IMPRIMIR_BOTON.BackColor = System.Drawing.Color.Snow
        Me.IMPRIMIR_BOTON.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.IMPRIMIR_BOTON.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IMPRIMIR_BOTON.Image = CType(resources.GetObject("IMPRIMIR_BOTON.Image"), System.Drawing.Image)
        Me.IMPRIMIR_BOTON.Location = New System.Drawing.Point(331, 3)
        Me.IMPRIMIR_BOTON.Margin = New System.Windows.Forms.Padding(0)
        Me.IMPRIMIR_BOTON.Name = "IMPRIMIR_BOTON"
        Me.IMPRIMIR_BOTON.Size = New System.Drawing.Size(127, 26)
        Me.IMPRIMIR_BOTON.TabIndex = 36
        Me.IMPRIMIR_BOTON.Text = "IMPRIMIR"
        Me.IMPRIMIR_BOTON.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IMPRIMIR_BOTON.UseVisualStyleBackColor = False
        '
        'Datos_ordenpago_detalle
        '
        Me.Datos_ordenpago_detalle.AllowUserToAddRows = False
        Me.Datos_ordenpago_detalle.AllowUserToDeleteRows = False
        Me.Datos_ordenpago_detalle.AllowUserToOrderColumns = True
        Me.Datos_ordenpago_detalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Datos_ordenpago_detalle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Datos_ordenpago_detalle.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_ordenpago_detalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Datos_ordenpago_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(198, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_ordenpago_detalle.DefaultCellStyle = DataGridViewCellStyle4
        Me.Datos_ordenpago_detalle.Location = New System.Drawing.Point(3, 32)
        Me.Datos_ordenpago_detalle.Name = "Datos_ordenpago_detalle"
        Me.Datos_ordenpago_detalle.RowHeadersVisible = False
        Me.Datos_ordenpago_detalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Datos_ordenpago_detalle.Size = New System.Drawing.Size(336, 365)
        Me.Datos_ordenpago_detalle.TabIndex = 18
        '
        'Contabilidad_listadoordenespago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 400)
        Me.Controls.Add(Me.Flicker_Split_panel1)
        Me.Name = "Contabilidad_listadoordenespago"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ordenes de Pago"
        CType(Me.Datos_ordenpago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Flicker_Split_panel1.Panel1.ResumeLayout(False)
        Me.Flicker_Split_panel1.Panel1.PerformLayout()
        Me.Flicker_Split_panel1.Panel2.ResumeLayout(False)
        CType(Me.Flicker_Split_panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Flicker_Split_panel1.ResumeLayout(False)
        CType(Me.Datos_ordenpago_detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents Busqueda_OP As TextBox
    Friend WithEvents Refresh_op As Button
    Friend WithEvents Datos_ordenpago As Flicker_Datagridview
    Friend WithEvents Flicker_Split_panel1 As Flicker_Split_panel
    Friend WithEvents Datos_ordenpago_detalle As Flicker_Datagridview
    Friend WithEvents IMPRIMIR_BOTON As Button
End Class
