<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Usuarios_nuevousuario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Usuarios_nuevousuario))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Apellido_textbox = New System.Windows.Forms.TextBox()
        Me.Nombres_textbox = New System.Windows.Forms.TextBox()
        Me.Password1_textbox = New System.Windows.Forms.TextBox()
        Me.Password2_textbox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Cerrar_boton = New System.Windows.Forms.Button()
        Me.Label_pedidofondo = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DNI_usuario_textbox = New System.Windows.Forms.NumericUpDown()
        Me.AsignarDIRECCION_boton = New System.Windows.Forms.Button()
        Me.Direccion_label = New System.Windows.Forms.Label()
        Me.Pass_image = New System.Windows.Forms.PictureBox()
        Me.Nombre_Direccionlabel = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DNI_usuario_textbox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pass_image, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.SkyBlue
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 278)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(328, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.BackColor = System.Drawing.Color.White
        Me.OK_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(158, 23)
        Me.OK_Button.TabIndex = 7
        Me.OK_Button.Text = "OK"
        Me.OK_Button.UseVisualStyleBackColor = False
        '
        'Cancel_Button
        '
        Me.Cancel_Button.BackColor = System.Drawing.Color.White
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Cancel_Button.Location = New System.Drawing.Point(167, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(158, 23)
        Me.Cancel_Button.TabIndex = 8
        Me.Cancel_Button.Text = "Cancel"
        Me.Cancel_Button.UseVisualStyleBackColor = False
        '
        'Apellido_textbox
        '
        Me.Apellido_textbox.BackColor = System.Drawing.Color.White
        Me.Apellido_textbox.Location = New System.Drawing.Point(76, 81)
        Me.Apellido_textbox.Name = "Apellido_textbox"
        Me.Apellido_textbox.Size = New System.Drawing.Size(223, 20)
        Me.Apellido_textbox.TabIndex = 2
        Me.Apellido_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Nombres_textbox
        '
        Me.Nombres_textbox.BackColor = System.Drawing.Color.White
        Me.Nombres_textbox.Location = New System.Drawing.Point(76, 111)
        Me.Nombres_textbox.Name = "Nombres_textbox"
        Me.Nombres_textbox.Size = New System.Drawing.Size(223, 20)
        Me.Nombres_textbox.TabIndex = 3
        Me.Nombres_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Password1_textbox
        '
        Me.Password1_textbox.BackColor = System.Drawing.Color.White
        Me.Password1_textbox.Location = New System.Drawing.Point(112, 139)
        Me.Password1_textbox.Name = "Password1_textbox"
        Me.Password1_textbox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Password1_textbox.Size = New System.Drawing.Size(167, 20)
        Me.Password1_textbox.TabIndex = 5
        Me.Password1_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Password1_textbox.UseSystemPasswordChar = True
        '
        'Password2_textbox
        '
        Me.Password2_textbox.BackColor = System.Drawing.Color.White
        Me.Password2_textbox.Location = New System.Drawing.Point(112, 165)
        Me.Password2_textbox.Name = "Password2_textbox"
        Me.Password2_textbox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Password2_textbox.Size = New System.Drawing.Size(167, 20)
        Me.Password2_textbox.TabIndex = 6
        Me.Password2_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Password2_textbox.UseSystemPasswordChar = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(9, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Apellidos"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(9, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 15)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Nombres"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(26, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 15)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Contraseña"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(26, 155)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 30)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Repetir " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Contraseña"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(12, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 15)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "DNI"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Panel1.Controls.Add(Me.Cerrar_boton)
        Me.Panel1.Controls.Add(Me.Label_pedidofondo)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(328, 45)
        Me.Panel1.TabIndex = 109
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
        Me.Cerrar_boton.Location = New System.Drawing.Point(272, 0)
        Me.Cerrar_boton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cerrar_boton.Name = "Cerrar_boton"
        Me.Cerrar_boton.Size = New System.Drawing.Size(56, 42)
        Me.Cerrar_boton.TabIndex = 31
        Me.Cerrar_boton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cerrar_boton.UseVisualStyleBackColor = True
        '
        'Label_pedidofondo
        '
        Me.Label_pedidofondo.AutoSize = True
        Me.Label_pedidofondo.Font = New System.Drawing.Font("Raleway Black", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_pedidofondo.ForeColor = System.Drawing.Color.White
        Me.Label_pedidofondo.Location = New System.Drawing.Point(71, 2)
        Me.Label_pedidofondo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_pedidofondo.Name = "Label_pedidofondo"
        Me.Label_pedidofondo.Size = New System.Drawing.Size(192, 30)
        Me.Label_pedidofondo.TabIndex = 29
        Me.Label_pedidofondo.Text = "NUEVO USUARIO"
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(1431, 0)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(53, 65)
        Me.Button1.TabIndex = 1
        '
        'DNI_usuario_textbox
        '
        Me.DNI_usuario_textbox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DNI_usuario_textbox.ForeColor = System.Drawing.Color.Black
        Me.DNI_usuario_textbox.Location = New System.Drawing.Point(76, 50)
        Me.DNI_usuario_textbox.Margin = New System.Windows.Forms.Padding(0)
        Me.DNI_usuario_textbox.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.DNI_usuario_textbox.Name = "DNI_usuario_textbox"
        Me.DNI_usuario_textbox.Size = New System.Drawing.Size(223, 25)
        Me.DNI_usuario_textbox.TabIndex = 0
        Me.DNI_usuario_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.DNI_usuario_textbox.ThousandsSeparator = True
        '
        'AsignarDIRECCION_boton
        '
        Me.AsignarDIRECCION_boton.BackColor = System.Drawing.Color.SkyBlue
        Me.AsignarDIRECCION_boton.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AsignarDIRECCION_boton.Location = New System.Drawing.Point(12, 191)
        Me.AsignarDIRECCION_boton.Name = "AsignarDIRECCION_boton"
        Me.AsignarDIRECCION_boton.Size = New System.Drawing.Size(287, 33)
        Me.AsignarDIRECCION_boton.TabIndex = 137
        Me.AsignarDIRECCION_boton.Text = "SELECCIONAR DIRECCIÓN"
        Me.AsignarDIRECCION_boton.UseVisualStyleBackColor = False
        '
        'Direccion_label
        '
        Me.Direccion_label.AutoSize = True
        Me.Direccion_label.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Direccion_label.ForeColor = System.Drawing.Color.Black
        Me.Direccion_label.Location = New System.Drawing.Point(12, 227)
        Me.Direccion_label.Name = "Direccion_label"
        Me.Direccion_label.Size = New System.Drawing.Size(11, 15)
        Me.Direccion_label.TabIndex = 138
        Me.Direccion_label.Text = ":"
        '
        'Pass_image
        '
        Me.Pass_image.Image = Global.SICyF.My.Resources.Resources.checkmark
        Me.Pass_image.Location = New System.Drawing.Point(285, 139)
        Me.Pass_image.Name = "Pass_image"
        Me.Pass_image.Size = New System.Drawing.Size(35, 35)
        Me.Pass_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Pass_image.TabIndex = 139
        Me.Pass_image.TabStop = False
        '
        'Nombre_Direccionlabel
        '
        Me.Nombre_Direccionlabel.AutoSize = True
        Me.Nombre_Direccionlabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre_Direccionlabel.ForeColor = System.Drawing.Color.Black
        Me.Nombre_Direccionlabel.Location = New System.Drawing.Point(12, 254)
        Me.Nombre_Direccionlabel.Name = "Nombre_Direccionlabel"
        Me.Nombre_Direccionlabel.Size = New System.Drawing.Size(11, 15)
        Me.Nombre_Direccionlabel.TabIndex = 140
        Me.Nombre_Direccionlabel.Text = ":"
        '
        'Usuarios_nuevousuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(328, 307)
        Me.Controls.Add(Me.Nombre_Direccionlabel)
        Me.Controls.Add(Me.Pass_image)
        Me.Controls.Add(Me.Direccion_label)
        Me.Controls.Add(Me.AsignarDIRECCION_boton)
        Me.Controls.Add(Me.DNI_usuario_textbox)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Password2_textbox)
        Me.Controls.Add(Me.Password1_textbox)
        Me.Controls.Add(Me.Nombres_textbox)
        Me.Controls.Add(Me.Apellido_textbox)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Usuarios_nuevousuario"
        Me.Opacity = 0.95R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Nuevousuario"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DNI_usuario_textbox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pass_image, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Apellido_textbox As TextBox
    Friend WithEvents Nombres_textbox As TextBox
    Friend WithEvents Password1_textbox As TextBox
    Friend WithEvents Password2_textbox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Cerrar_boton As Button
    Friend WithEvents Label_pedidofondo As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents DNI_usuario_textbox As NumericUpDown
    Friend WithEvents AsignarDIRECCION_boton As Button
    Friend WithEvents Direccion_label As Label
    Friend WithEvents Pass_image As PictureBox
    Friend WithEvents Nombre_Direccionlabel As Label
End Class
