<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Dialogo_Solicitarnumero
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dialogo_Solicitarnumero))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Cerrar_boton = New System.Windows.Forms.Button()
        Me.Label_expedienteasociados = New System.Windows.Forms.Label()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Cancelar_boton = New System.Windows.Forms.Button()
        Me.Modificar_boton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Numerodetransaccionnuevo_numeric = New SICyF.Flicker_Numericcontrol_Numero()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.Numerodetransaccionnuevo_numeric, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 94)
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
        Me.Modificar_boton.Text = "Modificar Número"
        Me.Modificar_boton.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(185, 25)
        Me.Label1.TabIndex = 143
        Me.Label1.Text = "Número Actualizado"
        '
        'Numerodetransaccionnuevo_numeric
        '
        Me.Numerodetransaccionnuevo_numeric.BackColor = System.Drawing.Color.White
        Me.Numerodetransaccionnuevo_numeric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Numerodetransaccionnuevo_numeric.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Numerodetransaccionnuevo_numeric.ForeColor = System.Drawing.Color.Black
        Me.Numerodetransaccionnuevo_numeric.Location = New System.Drawing.Point(217, 45)
        Me.Numerodetransaccionnuevo_numeric.Margin = New System.Windows.Forms.Padding(0)
        Me.Numerodetransaccionnuevo_numeric.Maximum = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.Numerodetransaccionnuevo_numeric.Name = "Numerodetransaccionnuevo_numeric"
        Me.Numerodetransaccionnuevo_numeric.Size = New System.Drawing.Size(372, 29)
        Me.Numerodetransaccionnuevo_numeric.Suffix = Nothing
        Me.Numerodetransaccionnuevo_numeric.TabIndex = 142
        Me.Numerodetransaccionnuevo_numeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Numerodetransaccionnuevo_numeric.ThousandsSeparator = True
        '
        'Dialogo_Solicitarnumero
        '
        Me.AcceptButton = Me.Modificar_boton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSkyBlue
        Me.ClientSize = New System.Drawing.Size(598, 148)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Numerodetransaccionnuevo_numeric)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Dialogo_Solicitarnumero"
        Me.Opacity = 0.9R
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Dialogo_Movimientoscambio"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.Numerodetransaccionnuevo_numeric, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Cerrar_boton As Button
    Friend WithEvents Label_expedienteasociados As Label
    Friend WithEvents Cancel_Button As Button
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Cancelar_boton As Button
    Friend WithEvents Modificar_boton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Numerodetransaccionnuevo_numeric As Flicker_Numericcontrol_Numero
End Class
