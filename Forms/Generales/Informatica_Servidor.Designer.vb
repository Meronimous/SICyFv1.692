<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Informatica_Servidor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Informatica_Servidor))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.PRUEBAAPITESO = New System.Windows.Forms.Button()
        Me.Backup_Bd = New System.Windows.Forms.Button()
        Me.Refresh2 = New System.Windows.Forms.Button()
        Me.Servidor1_imagen = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.DatosServidor = New SICyF.Flicker_Datagridview()
        Me.PingServer2 = New System.Windows.Forms.Button()
        Me.PingServer1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Puerto2direccion = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Servidor2direccion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Servidor1puerto = New System.Windows.Forms.TextBox()
        Me.labe2l = New System.Windows.Forms.Label()
        Me.Servidor1direccion = New System.Windows.Forms.TextBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Servidor1_imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.DatosServidor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SplitContainer1.Panel1.Controls.Add(Me.PRUEBAAPITESO)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Backup_Bd)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Refresh2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Servidor1_imagen)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(831, 597)
        Me.SplitContainer1.SplitterDistance = 101
        Me.SplitContainer1.TabIndex = 0
        '
        'PRUEBAAPITESO
        '
        Me.PRUEBAAPITESO.Location = New System.Drawing.Point(22, 429)
        Me.PRUEBAAPITESO.Name = "PRUEBAAPITESO"
        Me.PRUEBAAPITESO.Size = New System.Drawing.Size(75, 23)
        Me.PRUEBAAPITESO.TabIndex = 10
        Me.PRUEBAAPITESO.Text = "Prueba APi"
        Me.PRUEBAAPITESO.UseVisualStyleBackColor = True
        '
        'Backup_Bd
        '
        Me.Backup_Bd.Location = New System.Drawing.Point(13, 287)
        Me.Backup_Bd.Name = "Backup_Bd"
        Me.Backup_Bd.Size = New System.Drawing.Size(75, 23)
        Me.Backup_Bd.TabIndex = 9
        Me.Backup_Bd.Text = "Backup BD"
        Me.Backup_Bd.UseVisualStyleBackColor = True
        '
        'Refresh2
        '
        Me.Refresh2.Location = New System.Drawing.Point(12, 147)
        Me.Refresh2.Name = "Refresh2"
        Me.Refresh2.Size = New System.Drawing.Size(75, 23)
        Me.Refresh2.TabIndex = 8
        Me.Refresh2.Text = "Actualizar"
        Me.Refresh2.UseVisualStyleBackColor = True
        '
        'Servidor1_imagen
        '
        Me.Servidor1_imagen.Image = CType(resources.GetObject("Servidor1_imagen.Image"), System.Drawing.Image)
        Me.Servidor1_imagen.Location = New System.Drawing.Point(8, 25)
        Me.Servidor1_imagen.Name = "Servidor1_imagen"
        Me.Servidor1_imagen.Size = New System.Drawing.Size(88, 51)
        Me.Servidor1_imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Servidor1_imagen.TabIndex = 1
        Me.Servidor1_imagen.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Servidores"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.BackColor = System.Drawing.Color.CornflowerBlue
        Me.SplitContainer2.Panel1.Controls.Add(Me.DatosServidor)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.SplitContainer2.Panel2.Controls.Add(Me.PingServer2)
        Me.SplitContainer2.Panel2.Controls.Add(Me.PingServer1)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label5)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Puerto2direccion)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label6)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Servidor2direccion)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Servidor1puerto)
        Me.SplitContainer2.Panel2.Controls.Add(Me.labe2l)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Servidor1direccion)
        Me.SplitContainer2.Size = New System.Drawing.Size(726, 597)
        Me.SplitContainer2.SplitterDistance = 486
        Me.SplitContainer2.TabIndex = 0
        '
        'DatosServidor
        '
        Me.DatosServidor.AllowUserToAddRows = False
        Me.DatosServidor.AllowUserToDeleteRows = False
        Me.DatosServidor.AllowUserToOrderColumns = True
        Me.DatosServidor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DatosServidor.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DatosServidor.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DatosServidor.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DatosServidor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DatosServidor.DefaultCellStyle = DataGridViewCellStyle2
        Me.DatosServidor.Location = New System.Drawing.Point(0, 0)
        Me.DatosServidor.Name = "DatosServidor"
        Me.DatosServidor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DatosServidor.Size = New System.Drawing.Size(723, 483)
        Me.DatosServidor.TabIndex = 0
        '
        'PingServer2
        '
        Me.PingServer2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PingServer2.Location = New System.Drawing.Point(581, 46)
        Me.PingServer2.Name = "PingServer2"
        Me.PingServer2.Size = New System.Drawing.Size(37, 22)
        Me.PingServer2.TabIndex = 13
        Me.PingServer2.Text = "Ping"
        Me.PingServer2.UseVisualStyleBackColor = True
        '
        'PingServer1
        '
        Me.PingServer1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PingServer1.Location = New System.Drawing.Point(235, 43)
        Me.PingServer1.Name = "PingServer1"
        Me.PingServer1.Size = New System.Drawing.Size(37, 22)
        Me.PingServer1.TabIndex = 9
        Me.PingServer1.Text = "Ping"
        Me.PingServer1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(425, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "SERVIDOR 2"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(364, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Puerto"
        '
        'Puerto2direccion
        '
        Me.Puerto2direccion.Location = New System.Drawing.Point(428, 72)
        Me.Puerto2direccion.Name = "Puerto2direccion"
        Me.Puerto2direccion.Size = New System.Drawing.Size(147, 20)
        Me.Puerto2direccion.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(364, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Direccion"
        '
        'Servidor2direccion
        '
        Me.Servidor2direccion.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Servidor2direccion.Location = New System.Drawing.Point(428, 46)
        Me.Servidor2direccion.Name = "Servidor2direccion"
        Me.Servidor2direccion.Size = New System.Drawing.Size(147, 22)
        Me.Servidor2direccion.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(79, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "SERVIDOR 1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Puerto"
        '
        'Servidor1puerto
        '
        Me.Servidor1puerto.Location = New System.Drawing.Point(82, 69)
        Me.Servidor1puerto.Name = "Servidor1puerto"
        Me.Servidor1puerto.Size = New System.Drawing.Size(147, 20)
        Me.Servidor1puerto.TabIndex = 5
        '
        'labe2l
        '
        Me.labe2l.AutoSize = True
        Me.labe2l.Location = New System.Drawing.Point(18, 46)
        Me.labe2l.Name = "labe2l"
        Me.labe2l.Size = New System.Drawing.Size(52, 13)
        Me.labe2l.TabIndex = 4
        Me.labe2l.Text = "Direccion"
        '
        'Servidor1direccion
        '
        Me.Servidor1direccion.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Servidor1direccion.Location = New System.Drawing.Point(82, 43)
        Me.Servidor1direccion.Name = "Servidor1direccion"
        Me.Servidor1direccion.Size = New System.Drawing.Size(147, 22)
        Me.Servidor1direccion.TabIndex = 3
        '
        'Informatica_Servidor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(831, 597)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Informatica_Servidor"
        Me.Text = "Informatica_Servidor"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Servidor1_imagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.DatosServidor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Servidor1_imagen As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents Label3 As Label
    Friend WithEvents Servidor1puerto As TextBox
    Friend WithEvents labe2l As Label
    Friend WithEvents Servidor1direccion As TextBox
    Friend WithEvents Refresh2 As Button
    Friend WithEvents PingServer2 As Button
    Friend WithEvents PingServer1 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Puerto2direccion As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Servidor2direccion As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DatosServidor As Flicker_Datagridview
    Friend WithEvents Backup_Bd As Button
    Friend WithEvents PRUEBAAPITESO As Button
End Class
