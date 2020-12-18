<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Cuit_Expedientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cuit_Expedientes))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.Datosasociados_datagridview = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.ElementHost1 = New System.Windows.Forms.Integration.ElementHost()
        Me.Sumadelexpedientelocal = New SICyF.Control_currency_textboxWPF()
        Me.Quitarasociacion_boton = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Boton_Nuevo = New System.Windows.Forms.Button()
        Me.DatosNOasociados_datagridview = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.Asociarexpediente_boton = New System.Windows.Forms.Button()
        Me.Labelexpedientessinasociar = New System.Windows.Forms.Label()
        Me.BusquedaexpedientesNOasociados_textbox = New System.Windows.Forms.TextBox()
        Me.Label_expedienteasociados = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Cerrar_boton = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.Datosasociados_datagridview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatosNOasociados_datagridview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 455)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1024, 42)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.BackColor = System.Drawing.Color.SkyBlue
        Me.OK_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OK_Button.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(1018, 36)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Finalizar Cambios"
        Me.OK_Button.UseVisualStyleBackColor = False
        '
        'Cancel_Button
        '
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.FlatAppearance.BorderSize = 0
        Me.Cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancel_Button.Image = CType(resources.GetObject("Cancel_Button.Image"), System.Drawing.Image)
        Me.Cancel_Button.Location = New System.Drawing.Point(1073, 0)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(40, 42)
        Me.Cancel_Button.TabIndex = 1
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer3.BackColor = System.Drawing.Color.White
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 47)
        Me.SplitContainer3.Margin = New System.Windows.Forms.Padding(0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.AutoScroll = True
        Me.SplitContainer3.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainer3.Panel1.Controls.Add(Me.Datosasociados_datagridview)
        Me.SplitContainer3.Panel1.Controls.Add(Me.ElementHost1)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Quitarasociacion_boton)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label17)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.Boton_Nuevo)
        Me.SplitContainer3.Panel2.Controls.Add(Me.DatosNOasociados_datagridview)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Asociarexpediente_boton)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Labelexpedientessinasociar)
        Me.SplitContainer3.Panel2.Controls.Add(Me.BusquedaexpedientesNOasociados_textbox)
        Me.SplitContainer3.Size = New System.Drawing.Size(1021, 403)
        Me.SplitContainer3.SplitterDistance = 510
        Me.SplitContainer3.TabIndex = 105
        '
        'Datosasociados_datagridview
        '
        Me.Datosasociados_datagridview.AllowUserToAddRows = False
        Me.Datosasociados_datagridview.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Datosasociados_datagridview.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Datosasociados_datagridview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Datosasociados_datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Datosasociados_datagridview.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Datosasociados_datagridview.ColumnHeadersHeight = 33
        Me.Datosasociados_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Datosasociados_datagridview.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.Datosasociados_datagridview.Location = New System.Drawing.Point(8, 49)
        Me.Datosasociados_datagridview.Name = "Datosasociados_datagridview"
        Me.Datosasociados_datagridview.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
        Me.Datosasociados_datagridview.RowHeadersVisible = False
        Me.Datosasociados_datagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Datosasociados_datagridview.Size = New System.Drawing.Size(421, 312)
        Me.Datosasociados_datagridview.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.Datosasociados_datagridview.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Datosasociados_datagridview.StateCommon.HeaderColumn.Content.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.Datosasociados_datagridview.TabIndex = 99
        '
        'ElementHost1
        '
        Me.ElementHost1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ElementHost1.Enabled = False
        Me.ElementHost1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ElementHost1.Location = New System.Drawing.Point(274, 367)
        Me.ElementHost1.Name = "ElementHost1"
        Me.ElementHost1.Size = New System.Drawing.Size(231, 26)
        Me.ElementHost1.TabIndex = 30
        Me.ElementHost1.Text = "ElementHost1"
        Me.ElementHost1.Child = Me.Sumadelexpedientelocal
        '
        'Quitarasociacion_boton
        '
        Me.Quitarasociacion_boton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Quitarasociacion_boton.BackColor = System.Drawing.Color.MistyRose
        Me.Quitarasociacion_boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Quitarasociacion_boton.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Quitarasociacion_boton.Image = CType(resources.GetObject("Quitarasociacion_boton.Image"), System.Drawing.Image)
        Me.Quitarasociacion_boton.Location = New System.Drawing.Point(432, 49)
        Me.Quitarasociacion_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Quitarasociacion_boton.Name = "Quitarasociacion_boton"
        Me.Quitarasociacion_boton.Size = New System.Drawing.Size(73, 313)
        Me.Quitarasociacion_boton.TabIndex = 104
        Me.Quitarasociacion_boton.Text = "Quitar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Asociación"
        Me.Quitarasociacion_boton.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Quitarasociacion_boton.UseVisualStyleBackColor = False
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Garamond", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(98, 373)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(170, 14)
        Me.Label17.TabIndex = 100
        Me.Label17.Text = "Total Acumulado Expediente"
        '
        'Boton_Nuevo
        '
        Me.Boton_Nuevo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Boton_Nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Boton_Nuevo.Font = New System.Drawing.Font("Segoe UI", 8.999999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Boton_Nuevo.Image = CType(resources.GetObject("Boton_Nuevo.Image"), System.Drawing.Image)
        Me.Boton_Nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Boton_Nuevo.Location = New System.Drawing.Point(3, 365)
        Me.Boton_Nuevo.Name = "Boton_Nuevo"
        Me.Boton_Nuevo.Size = New System.Drawing.Size(501, 35)
        Me.Boton_Nuevo.TabIndex = 104
        Me.Boton_Nuevo.Text = "AGREGAR NUEVO CUIT AL LISTADO"
        Me.Boton_Nuevo.UseVisualStyleBackColor = True
        '
        'DatosNOasociados_datagridview
        '
        Me.DatosNOasociados_datagridview.AllowUserToAddRows = False
        Me.DatosNOasociados_datagridview.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.NullValue = Nothing
        Me.DatosNOasociados_datagridview.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DatosNOasociados_datagridview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DatosNOasociados_datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DatosNOasociados_datagridview.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DatosNOasociados_datagridview.ColumnHeadersHeight = 33
        Me.DatosNOasociados_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DatosNOasociados_datagridview.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DatosNOasociados_datagridview.Location = New System.Drawing.Point(80, 49)
        Me.DatosNOasociados_datagridview.Name = "DatosNOasociados_datagridview"
        Me.DatosNOasociados_datagridview.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
        Me.DatosNOasociados_datagridview.ReadOnly = True
        Me.DatosNOasociados_datagridview.RowHeadersVisible = False
        Me.DatosNOasociados_datagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DatosNOasociados_datagridview.Size = New System.Drawing.Size(424, 313)
        Me.DatosNOasociados_datagridview.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.DatosNOasociados_datagridview.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatosNOasociados_datagridview.StateCommon.HeaderColumn.Content.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.DatosNOasociados_datagridview.StateCommon.HeaderColumn.Content.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.DatosNOasociados_datagridview.TabIndex = 102
        '
        'Asociarexpediente_boton
        '
        Me.Asociarexpediente_boton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Asociarexpediente_boton.BackColor = System.Drawing.Color.MintCream
        Me.Asociarexpediente_boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Asociarexpediente_boton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Asociarexpediente_boton.Image = CType(resources.GetObject("Asociarexpediente_boton.Image"), System.Drawing.Image)
        Me.Asociarexpediente_boton.Location = New System.Drawing.Point(2, 49)
        Me.Asociarexpediente_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Asociarexpediente_boton.Name = "Asociarexpediente_boton"
        Me.Asociarexpediente_boton.Size = New System.Drawing.Size(75, 313)
        Me.Asociarexpediente_boton.TabIndex = 103
        Me.Asociarexpediente_boton.Text = "Asociar a " & Global.Microsoft.VisualBasic.ChrW(13) & "Expediente"
        Me.Asociarexpediente_boton.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Asociarexpediente_boton.UseVisualStyleBackColor = False
        '
        'Labelexpedientessinasociar
        '
        Me.Labelexpedientessinasociar.AutoSize = True
        Me.Labelexpedientessinasociar.Font = New System.Drawing.Font("Garamond", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labelexpedientessinasociar.ForeColor = System.Drawing.Color.Black
        Me.Labelexpedientessinasociar.Location = New System.Drawing.Point(484, 860)
        Me.Labelexpedientessinasociar.Name = "Labelexpedientessinasociar"
        Me.Labelexpedientessinasociar.Size = New System.Drawing.Size(239, 14)
        Me.Labelexpedientessinasociar.TabIndex = 100
        Me.Labelexpedientessinasociar.Text = "Proveedores sin asociar en este expediente"
        '
        'BusquedaexpedientesNOasociados_textbox
        '
        Me.BusquedaexpedientesNOasociados_textbox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BusquedaexpedientesNOasociados_textbox.BackColor = System.Drawing.Color.White
        Me.BusquedaexpedientesNOasociados_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BusquedaexpedientesNOasociados_textbox.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BusquedaexpedientesNOasociados_textbox.ForeColor = System.Drawing.Color.Black
        Me.BusquedaexpedientesNOasociados_textbox.Location = New System.Drawing.Point(21, 12)
        Me.BusquedaexpedientesNOasociados_textbox.Margin = New System.Windows.Forms.Padding(0)
        Me.BusquedaexpedientesNOasociados_textbox.Name = "BusquedaexpedientesNOasociados_textbox"
        Me.BusquedaexpedientesNOasociados_textbox.Size = New System.Drawing.Size(483, 33)
        Me.BusquedaexpedientesNOasociados_textbox.TabIndex = 101
        Me.BusquedaexpedientesNOasociados_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label_expedienteasociados
        '
        Me.Label_expedienteasociados.AutoSize = True
        Me.Label_expedienteasociados.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_expedienteasociados.ForeColor = System.Drawing.Color.White
        Me.Label_expedienteasociados.Location = New System.Drawing.Point(400, 2)
        Me.Label_expedienteasociados.Name = "Label_expedienteasociados"
        Me.Label_expedienteasociados.Size = New System.Drawing.Size(261, 25)
        Me.Label_expedienteasociados.TabIndex = 29
        Me.Label_expedienteasociados.Text = "Proveedores Asociados"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Panel1.Controls.Add(Me.Cerrar_boton)
        Me.Panel1.Controls.Add(Me.Label_expedienteasociados)
        Me.Panel1.Controls.Add(Me.Cancel_Button)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1024, 42)
        Me.Panel1.TabIndex = 106
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
        Me.Cerrar_boton.Location = New System.Drawing.Point(982, 0)
        Me.Cerrar_boton.Name = "Cerrar_boton"
        Me.Cerrar_boton.Size = New System.Drawing.Size(42, 42)
        Me.Cerrar_boton.TabIndex = 31
        Me.Cerrar_boton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cerrar_boton.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 100000
        Me.ToolTip1.BackColor = System.Drawing.Color.NavajoWhite
        Me.ToolTip1.ForeColor = System.Drawing.Color.Black
        Me.ToolTip1.InitialDelay = 200
        Me.ToolTip1.ReshowDelay = 100
        Me.ToolTip1.StripAmpersands = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'Cuit_Expedientes
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(1024, 497)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.SplitContainer3)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Cuit_Expedientes"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuit_expedientes"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.Panel2.PerformLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.Datosasociados_datagridview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatosNOasociados_datagridview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents Datosasociados_datagridview As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents Label_expedienteasociados As Label
    Friend WithEvents ElementHost1 As Integration.ElementHost
    Friend Sumadelexpedientelocal As Control_currency_textboxWPF
    Friend WithEvents Quitarasociacion_boton As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents DatosNOasociados_datagridview As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents Asociarexpediente_boton As Button
    Friend WithEvents Labelexpedientessinasociar As Label
    Friend WithEvents BusquedaexpedientesNOasociados_textbox As TextBox
    Friend WithEvents Boton_Nuevo As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Cerrar_boton As Button
    Friend WithEvents ToolTip1 As ToolTip
End Class
