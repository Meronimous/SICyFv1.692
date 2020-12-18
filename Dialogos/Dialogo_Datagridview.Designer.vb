<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DialogDialogo_Datagridview
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DialogDialogo_Datagridview))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label_seleccionactiva = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FullScreen_boton = New System.Windows.Forms.Button()
        Me.Cerrar_boton = New System.Windows.Forms.Button()
        Me.NombredelMessage_label = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Busqueda_dialogo = New System.Windows.Forms.TextBox()
        Me.Datosdialogo_datagridview = New SICyF.Flicker_Datagridview()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Datosdialogo_datagridview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 401)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(525, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.BackColor = System.Drawing.Color.DarkGreen
        Me.OK_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OK_Button.Enabled = False
        Me.OK_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OK_Button.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.ForeColor = System.Drawing.Color.White
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(256, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        Me.OK_Button.UseVisualStyleBackColor = False
        '
        'Cancel_Button
        '
        Me.Cancel_Button.BackColor = System.Drawing.Color.Brown
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancel_Button.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.ForeColor = System.Drawing.Color.White
        Me.Cancel_Button.Location = New System.Drawing.Point(265, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(257, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "CANCELAR"
        Me.Cancel_Button.UseVisualStyleBackColor = False
        '
        'Label_seleccionactiva
        '
        Me.Label_seleccionactiva.AutoSize = True
        Me.Label_seleccionactiva.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_seleccionactiva.ForeColor = System.Drawing.Color.Black
        Me.Label_seleccionactiva.Location = New System.Drawing.Point(3, 309)
        Me.Label_seleccionactiva.Name = "Label_seleccionactiva"
        Me.Label_seleccionactiva.Size = New System.Drawing.Size(17, 21)
        Me.Label_seleccionactiva.TabIndex = 109
        Me.Label_seleccionactiva.Text = "_"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.FullScreen_boton)
        Me.Panel1.Controls.Add(Me.Cerrar_boton)
        Me.Panel1.Controls.Add(Me.NombredelMessage_label)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.ForeColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(525, 40)
        Me.Panel1.TabIndex = 110
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
        Me.FullScreen_boton.Location = New System.Drawing.Point(432, 4)
        Me.FullScreen_boton.Name = "FullScreen_boton"
        Me.FullScreen_boton.Size = New System.Drawing.Size(42, 33)
        Me.FullScreen_boton.TabIndex = 33
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
        Me.Cerrar_boton.Location = New System.Drawing.Point(480, 3)
        Me.Cerrar_boton.Name = "Cerrar_boton"
        Me.Cerrar_boton.Size = New System.Drawing.Size(42, 34)
        Me.Cerrar_boton.TabIndex = 32
        Me.Cerrar_boton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cerrar_boton.UseVisualStyleBackColor = False
        '
        'NombredelMessage_label
        '
        Me.NombredelMessage_label.AutoSize = True
        Me.NombredelMessage_label.BackColor = System.Drawing.Color.Transparent
        Me.NombredelMessage_label.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NombredelMessage_label.ForeColor = System.Drawing.Color.White
        Me.NombredelMessage_label.Location = New System.Drawing.Point(3, 4)
        Me.NombredelMessage_label.Name = "NombredelMessage_label"
        Me.NombredelMessage_label.Size = New System.Drawing.Size(166, 21)
        Me.NombredelMessage_label.TabIndex = 29
        Me.NombredelMessage_label.Text = "NUEVO EXPEDIENTE"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Image = CType(resources.GetObject("Label3.Image"), System.Drawing.Image)
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New System.Drawing.Point(12, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 22)
        Me.Label3.TabIndex = 115
        Me.Label3.Text = "Buscar"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Busqueda_dialogo
        '
        Me.Busqueda_dialogo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Busqueda_dialogo.Location = New System.Drawing.Point(90, 43)
        Me.Busqueda_dialogo.Name = "Busqueda_dialogo"
        Me.Busqueda_dialogo.Size = New System.Drawing.Size(235, 23)
        Me.Busqueda_dialogo.TabIndex = 0
        '
        'Datosdialogo_datagridview
        '
        Me.Datosdialogo_datagridview.AllowUserToAddRows = False
        Me.Datosdialogo_datagridview.AllowUserToDeleteRows = False
        Me.Datosdialogo_datagridview.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Datosdialogo_datagridview.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Datosdialogo_datagridview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Datosdialogo_datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.Datosdialogo_datagridview.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Datosdialogo_datagridview.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datosdialogo_datagridview.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Datosdialogo_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datosdialogo_datagridview.DefaultCellStyle = DataGridViewCellStyle3
        Me.Datosdialogo_datagridview.GridColor = System.Drawing.Color.Black
        Me.Datosdialogo_datagridview.Location = New System.Drawing.Point(7, 66)
        Me.Datosdialogo_datagridview.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.Datosdialogo_datagridview.Name = "Datosdialogo_datagridview"
        Me.Datosdialogo_datagridview.ReadOnly = True
        Me.Datosdialogo_datagridview.RowHeadersVisible = False
        Me.Datosdialogo_datagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Datosdialogo_datagridview.Size = New System.Drawing.Size(506, 326)
        Me.Datosdialogo_datagridview.TabIndex = 1
        '
        'DialogDialogo_Datagridview
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(525, 430)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Busqueda_dialogo)
        Me.Controls.Add(Me.Datosdialogo_datagridview)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label_seleccionactiva)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogDialogo_Datagridview"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Dialogo_listbox"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Datosdialogo_datagridview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Label_seleccionactiva As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents NombredelMessage_label As Label
    Friend WithEvents Datosdialogo_datagridview As SICyF.Flicker_Datagridview
    Friend WithEvents Label3 As Label
    Friend WithEvents Busqueda_dialogo As TextBox
    Friend WithEvents Cancel_Button As Button
    Friend WithEvents FullScreen_boton As Button
    Friend WithEvents Cerrar_boton As Button
End Class
