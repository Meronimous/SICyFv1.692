<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Dialogo_Movimientoscambio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dialogo_Movimientoscambio))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Cerrar_boton = New System.Windows.Forms.Button()
        Me.Label_expedienteasociados = New System.Windows.Forms.Label()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Cancelar_boton = New System.Windows.Forms.Button()
        Me.Modificar_boton = New System.Windows.Forms.Button()
        Me.Datos_datagridview = New SICyF.Flicker_Datagridview()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.Datos_datagridview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(598, 42)
        Me.Panel1.TabIndex = 108
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
        Me.Cerrar_boton.Location = New System.Drawing.Point(556, 0)
        Me.Cerrar_boton.Name = "Cerrar_boton"
        Me.Cerrar_boton.Size = New System.Drawing.Size(42, 42)
        Me.Cerrar_boton.TabIndex = 30
        Me.Cerrar_boton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cerrar_boton.UseVisualStyleBackColor = True
        '
        'Label_expedienteasociados
        '
        Me.Label_expedienteasociados.AutoSize = True
        Me.Label_expedienteasociados.Font = New System.Drawing.Font("Raleway Black", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_expedienteasociados.ForeColor = System.Drawing.Color.White
        Me.Label_expedienteasociados.Location = New System.Drawing.Point(177, 9)
        Me.Label_expedienteasociados.Name = "Label_expedienteasociados"
        Me.Label_expedienteasociados.Size = New System.Drawing.Size(243, 30)
        Me.Label_expedienteasociados.TabIndex = 29
        Me.Label_expedienteasociados.Text = "Modificar Movimiento"
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
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Cancelar_boton, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Modificar_boton, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 153)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(598, 54)
        Me.TableLayoutPanel2.TabIndex = 123
        '
        'Cancelar_boton
        '
        Me.Cancelar_boton.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Cancelar_boton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Cancelar_boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancelar_boton.Font = New System.Drawing.Font("Raleway Light", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Cancelar_boton.Image = Global.SICyF.My.Resources.Resources.close
        Me.Cancelar_boton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cancelar_boton.Location = New System.Drawing.Point(299, 0)
        Me.Cancelar_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Cancelar_boton.Name = "Cancelar_boton"
        Me.Cancelar_boton.Size = New System.Drawing.Size(299, 54)
        Me.Cancelar_boton.TabIndex = 4
        Me.Cancelar_boton.Text = "Cancelar"
        Me.Cancelar_boton.UseVisualStyleBackColor = False
        '
        'Modificar_boton
        '
        Me.Modificar_boton.BackColor = System.Drawing.Color.White
        Me.Modificar_boton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Modificar_boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Modificar_boton.Font = New System.Drawing.Font("Raleway Light", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Modificar_boton.Image = Global.SICyF.My.Resources.Resources.checkmark
        Me.Modificar_boton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Modificar_boton.Location = New System.Drawing.Point(0, 0)
        Me.Modificar_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Modificar_boton.Name = "Modificar_boton"
        Me.Modificar_boton.Size = New System.Drawing.Size(299, 54)
        Me.Modificar_boton.TabIndex = 3
        Me.Modificar_boton.Text = "Modificar seleccionado"
        Me.Modificar_boton.UseVisualStyleBackColor = False
        '
        'Datos_datagridview
        '
        Me.Datos_datagridview.AllowUserToAddRows = False
        Me.Datos_datagridview.AllowUserToOrderColumns = True
        Me.Datos_datagridview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Datos_datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Datos_datagridview.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.Datos_datagridview.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_datagridview.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Datos_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datos_datagridview.DefaultCellStyle = DataGridViewCellStyle2
        Me.Datos_datagridview.Location = New System.Drawing.Point(12, 48)
        Me.Datos_datagridview.Name = "Datos_datagridview"
        Me.Datos_datagridview.RowHeadersVisible = False
        Me.Datos_datagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Datos_datagridview.Size = New System.Drawing.Size(573, 102)
        Me.Datos_datagridview.TabIndex = 124
        '
        'Dialogo_Movimientoscambio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSkyBlue
        Me.ClientSize = New System.Drawing.Size(598, 207)
        Me.ControlBox = False
        Me.Controls.Add(Me.Datos_datagridview)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Dialogo_Movimientoscambio"
        Me.Opacity = 0.9R
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Dialogo_Movimientoscambio"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.Datos_datagridview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Cerrar_boton As Button
    Friend WithEvents Label_expedienteasociados As Label
    Friend WithEvents Cancel_Button As Button
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Cancelar_boton As Button
    Friend WithEvents Modificar_boton As Button
    Friend WithEvents Datos_datagridview As Flicker_Datagridview
End Class
