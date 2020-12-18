<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Informatica_Servicioadministrativo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Informatica_Servicioadministrativo))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel_superior = New System.Windows.Forms.Panel()
        Me.Cerrar_boton = New System.Windows.Forms.Button()
        Me.Label_detalle = New System.Windows.Forms.Label()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Serv_Adm_datagridview = New SICyF.Flicker_Datagridview()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Panel_superior.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Serv_Adm_datagridview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel_superior
        '
        Me.Panel_superior.BackColor = System.Drawing.Color.SaddleBrown
        Me.Panel_superior.Controls.Add(Me.Cerrar_boton)
        Me.Panel_superior.Controls.Add(Me.Label_detalle)
        Me.Panel_superior.Controls.Add(Me.Cancel_Button)
        Me.Panel_superior.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_superior.Location = New System.Drawing.Point(0, 0)
        Me.Panel_superior.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel_superior.Name = "Panel_superior"
        Me.Panel_superior.Size = New System.Drawing.Size(551, 42)
        Me.Panel_superior.TabIndex = 107
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
        Me.Cerrar_boton.Location = New System.Drawing.Point(509, 0)
        Me.Cerrar_boton.Name = "Cerrar_boton"
        Me.Cerrar_boton.Size = New System.Drawing.Size(42, 42)
        Me.Cerrar_boton.TabIndex = 31
        Me.Cerrar_boton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cerrar_boton.UseVisualStyleBackColor = True
        '
        'Label_detalle
        '
        Me.Label_detalle.AutoSize = True
        Me.Label_detalle.Font = New System.Drawing.Font("Raleway Black", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_detalle.ForeColor = System.Drawing.Color.White
        Me.Label_detalle.Location = New System.Drawing.Point(137, 9)
        Me.Label_detalle.Name = "Label_detalle"
        Me.Label_detalle.Size = New System.Drawing.Size(263, 30)
        Me.Label_detalle.TabIndex = 29
        Me.Label_detalle.Text = "Servicio Administrativos"
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
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 42)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Serv_Adm_datagridview)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.OK_Button)
        Me.SplitContainer1.Size = New System.Drawing.Size(551, 388)
        Me.SplitContainer1.SplitterDistance = 325
        Me.SplitContainer1.TabIndex = 108
        '
        'Serv_Adm_datagridview
        '
        Me.Serv_Adm_datagridview.AllowUserToAddRows = False
        Me.Serv_Adm_datagridview.AllowUserToDeleteRows = False
        Me.Serv_Adm_datagridview.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Serv_Adm_datagridview.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Serv_Adm_datagridview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Serv_Adm_datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Serv_Adm_datagridview.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.Serv_Adm_datagridview.BackgroundColor = System.Drawing.Color.SandyBrown
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Raleway Black", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Serv_Adm_datagridview.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Serv_Adm_datagridview.ColumnHeadersHeight = 33
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Serv_Adm_datagridview.DefaultCellStyle = DataGridViewCellStyle3
        Me.Serv_Adm_datagridview.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.Serv_Adm_datagridview.GridColor = System.Drawing.Color.Maroon
        Me.Serv_Adm_datagridview.Location = New System.Drawing.Point(3, 3)
        Me.Serv_Adm_datagridview.MultiSelect = False
        Me.Serv_Adm_datagridview.Name = "Serv_Adm_datagridview"
        Me.Serv_Adm_datagridview.ReadOnly = True
        Me.Serv_Adm_datagridview.RowHeadersVisible = False
        Me.Serv_Adm_datagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Serv_Adm_datagridview.ShowEditingIcon = False
        Me.Serv_Adm_datagridview.Size = New System.Drawing.Size(545, 320)
        Me.Serv_Adm_datagridview.TabIndex = 1
        Me.Serv_Adm_datagridview.VirtualMode = True
        '
        'OK_Button
        '
        Me.OK_Button.BackColor = System.Drawing.Color.SaddleBrown
        Me.OK_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OK_Button.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.ForeColor = System.Drawing.Color.White
        Me.OK_Button.Location = New System.Drawing.Point(0, 0)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(551, 59)
        Me.OK_Button.TabIndex = 33
        Me.OK_Button.Text = "Seleccionar Servicio Administrativo"
        Me.OK_Button.UseVisualStyleBackColor = False
        '
        'Informatica_Servicioadministrativo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(551, 430)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel_superior)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Informatica_Servicioadministrativo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selecciondeservicioadministrativo"
        Me.Panel_superior.ResumeLayout(False)
        Me.Panel_superior.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Serv_Adm_datagridview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents Panel_superior As Panel
    Friend WithEvents Label_detalle As Label
    Friend WithEvents Cancel_Button As Button
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents OK_Button As Button
    Private WithEvents Serv_Adm_datagridview As SICyF.Flicker_Datagridview
    Friend WithEvents Cerrar_boton As Button
End Class
