<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CUIT_agregarnuevo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CUIT_agregarnuevo))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.AgregarCUIT_boton = New System.Windows.Forms.Button()
        Me.CancelarCUIT_boton = New System.Windows.Forms.Button()
        Me.DatosnuevoCUIT_panel = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Domicilio_textbox = New System.Windows.Forms.TextBox()
        Me.CUITLABELMASCULINO = New System.Windows.Forms.Label()
        Me.CUITLABELTEORICOfEMENINO = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Nombrefantasiabeneficiario_textbox = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label_expedienteasociados = New System.Windows.Forms.Label()
        Me.CUIT_verificador = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CBU_alias = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CBU_Nro = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Nombrebeneficiario_textbox = New System.Windows.Forms.TextBox()
        Me.Cuitadd_textbox = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.DatosnuevoCUIT_panel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.CUIT_verificador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.AgregarCUIT_boton, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 423)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(394, 52)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'AgregarCUIT_boton
        '
        Me.AgregarCUIT_boton.AutoSize = True
        Me.AgregarCUIT_boton.BackColor = System.Drawing.Color.SteelBlue
        Me.AgregarCUIT_boton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.TableLayoutPanel1.SetColumnSpan(Me.AgregarCUIT_boton, 2)
        Me.AgregarCUIT_boton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AgregarCUIT_boton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.AgregarCUIT_boton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AgregarCUIT_boton.ForeColor = System.Drawing.Color.White
        Me.AgregarCUIT_boton.Image = CType(resources.GetObject("AgregarCUIT_boton.Image"), System.Drawing.Image)
        Me.AgregarCUIT_boton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.AgregarCUIT_boton.Location = New System.Drawing.Point(3, 3)
        Me.AgregarCUIT_boton.Name = "AgregarCUIT_boton"
        Me.AgregarCUIT_boton.Size = New System.Drawing.Size(388, 46)
        Me.AgregarCUIT_boton.TabIndex = 4
        Me.AgregarCUIT_boton.Text = "CARGAR DATOS"
        Me.AgregarCUIT_boton.UseVisualStyleBackColor = False
        '
        'CancelarCUIT_boton
        '
        Me.CancelarCUIT_boton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CancelarCUIT_boton.AutoSize = True
        Me.CancelarCUIT_boton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CancelarCUIT_boton.FlatAppearance.BorderSize = 0
        Me.CancelarCUIT_boton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CancelarCUIT_boton.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CancelarCUIT_boton.Image = CType(resources.GetObject("CancelarCUIT_boton.Image"), System.Drawing.Image)
        Me.CancelarCUIT_boton.Location = New System.Drawing.Point(353, 0)
        Me.CancelarCUIT_boton.Name = "CancelarCUIT_boton"
        Me.CancelarCUIT_boton.Size = New System.Drawing.Size(42, 42)
        Me.CancelarCUIT_boton.TabIndex = 5
        Me.CancelarCUIT_boton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CancelarCUIT_boton.UseVisualStyleBackColor = True
        '
        'DatosnuevoCUIT_panel
        '
        Me.DatosnuevoCUIT_panel.BackColor = System.Drawing.Color.White
        Me.DatosnuevoCUIT_panel.Controls.Add(Me.Label4)
        Me.DatosnuevoCUIT_panel.Controls.Add(Me.Domicilio_textbox)
        Me.DatosnuevoCUIT_panel.Controls.Add(Me.CUITLABELMASCULINO)
        Me.DatosnuevoCUIT_panel.Controls.Add(Me.CUITLABELTEORICOfEMENINO)
        Me.DatosnuevoCUIT_panel.Controls.Add(Me.Label3)
        Me.DatosnuevoCUIT_panel.Controls.Add(Me.Nombrefantasiabeneficiario_textbox)
        Me.DatosnuevoCUIT_panel.Controls.Add(Me.Panel1)
        Me.DatosnuevoCUIT_panel.Controls.Add(Me.CUIT_verificador)
        Me.DatosnuevoCUIT_panel.Controls.Add(Me.Label6)
        Me.DatosnuevoCUIT_panel.Controls.Add(Me.TableLayoutPanel1)
        Me.DatosnuevoCUIT_panel.Controls.Add(Me.CBU_alias)
        Me.DatosnuevoCUIT_panel.Controls.Add(Me.Label5)
        Me.DatosnuevoCUIT_panel.Controls.Add(Me.CBU_Nro)
        Me.DatosnuevoCUIT_panel.Controls.Add(Me.Label2)
        Me.DatosnuevoCUIT_panel.Controls.Add(Me.Label1)
        Me.DatosnuevoCUIT_panel.Controls.Add(Me.Nombrebeneficiario_textbox)
        Me.DatosnuevoCUIT_panel.Controls.Add(Me.Cuitadd_textbox)
        Me.DatosnuevoCUIT_panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DatosnuevoCUIT_panel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatosnuevoCUIT_panel.Location = New System.Drawing.Point(0, 0)
        Me.DatosnuevoCUIT_panel.Name = "DatosnuevoCUIT_panel"
        Me.DatosnuevoCUIT_panel.Size = New System.Drawing.Size(397, 478)
        Me.DatosnuevoCUIT_panel.TabIndex = 106
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(33, 243)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 21)
        Me.Label4.TabIndex = 118
        Me.Label4.Text = "DOMICILIO"
        '
        'Domicilio_textbox
        '
        Me.Domicilio_textbox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Domicilio_textbox.BackColor = System.Drawing.Color.White
        Me.Domicilio_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Domicilio_textbox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Domicilio_textbox.ForeColor = System.Drawing.Color.Black
        Me.Domicilio_textbox.Location = New System.Drawing.Point(3, 264)
        Me.Domicilio_textbox.Margin = New System.Windows.Forms.Padding(0)
        Me.Domicilio_textbox.Multiline = True
        Me.Domicilio_textbox.Name = "Domicilio_textbox"
        Me.Domicilio_textbox.Size = New System.Drawing.Size(386, 54)
        Me.Domicilio_textbox.TabIndex = 117
        '
        'CUITLABELMASCULINO
        '
        Me.CUITLABELMASCULINO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CUITLABELMASCULINO.AutoSize = True
        Me.CUITLABELMASCULINO.BackColor = System.Drawing.Color.Transparent
        Me.CUITLABELMASCULINO.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CUITLABELMASCULINO.ForeColor = System.Drawing.Color.RoyalBlue
        Me.CUITLABELMASCULINO.Location = New System.Drawing.Point(9, 164)
        Me.CUITLABELMASCULINO.Margin = New System.Windows.Forms.Padding(0)
        Me.CUITLABELMASCULINO.Name = "CUITLABELMASCULINO"
        Me.CUITLABELMASCULINO.Size = New System.Drawing.Size(16, 21)
        Me.CUITLABELMASCULINO.TabIndex = 116
        Me.CUITLABELMASCULINO.Text = "-"
        '
        'CUITLABELTEORICOfEMENINO
        '
        Me.CUITLABELTEORICOfEMENINO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CUITLABELTEORICOfEMENINO.AutoSize = True
        Me.CUITLABELTEORICOfEMENINO.BackColor = System.Drawing.Color.Transparent
        Me.CUITLABELTEORICOfEMENINO.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CUITLABELTEORICOfEMENINO.ForeColor = System.Drawing.Color.Magenta
        Me.CUITLABELTEORICOfEMENINO.Location = New System.Drawing.Point(9, 145)
        Me.CUITLABELTEORICOfEMENINO.Margin = New System.Windows.Forms.Padding(0)
        Me.CUITLABELTEORICOfEMENINO.Name = "CUITLABELTEORICOfEMENINO"
        Me.CUITLABELTEORICOfEMENINO.Size = New System.Drawing.Size(16, 21)
        Me.CUITLABELTEORICOfEMENINO.TabIndex = 115
        Me.CUITLABELTEORICOfEMENINO.Text = "-"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(36, 186)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(250, 21)
        Me.Label3.TabIndex = 114
        Me.Label3.Text = "Nombre de Fantasía del proveedor"
        '
        'Nombrefantasiabeneficiario_textbox
        '
        Me.Nombrefantasiabeneficiario_textbox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Nombrefantasiabeneficiario_textbox.BackColor = System.Drawing.Color.White
        Me.Nombrefantasiabeneficiario_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Nombrefantasiabeneficiario_textbox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombrefantasiabeneficiario_textbox.ForeColor = System.Drawing.Color.Black
        Me.Nombrefantasiabeneficiario_textbox.Location = New System.Drawing.Point(3, 207)
        Me.Nombrefantasiabeneficiario_textbox.Margin = New System.Windows.Forms.Padding(0)
        Me.Nombrefantasiabeneficiario_textbox.Name = "Nombrefantasiabeneficiario_textbox"
        Me.Nombrefantasiabeneficiario_textbox.Size = New System.Drawing.Size(389, 29)
        Me.Nombrefantasiabeneficiario_textbox.TabIndex = 113
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.CancelarCUIT_boton)
        Me.Panel1.Controls.Add(Me.Label_expedienteasociados)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(397, 42)
        Me.Panel1.TabIndex = 112
        '
        'Label_expedienteasociados
        '
        Me.Label_expedienteasociados.AutoSize = True
        Me.Label_expedienteasociados.Font = New System.Drawing.Font("Raleway Black", 33.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.Label_expedienteasociados.ForeColor = System.Drawing.Color.White
        Me.Label_expedienteasociados.Location = New System.Drawing.Point(100, -4)
        Me.Label_expedienteasociados.Name = "Label_expedienteasociados"
        Me.Label_expedienteasociados.Size = New System.Drawing.Size(107, 45)
        Me.Label_expedienteasociados.TabIndex = 29
        Me.Label_expedienteasociados.Text = " CUIT"
        Me.Label_expedienteasociados.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'CUIT_verificador
        '
        Me.CUIT_verificador.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CUIT_verificador.Image = Global.SICyF.My.Resources.Resources.checkbox_cross
        Me.CUIT_verificador.Location = New System.Drawing.Point(360, 116)
        Me.CUIT_verificador.Name = "CUIT_verificador"
        Me.CUIT_verificador.Size = New System.Drawing.Size(34, 29)
        Me.CUIT_verificador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CUIT_verificador.TabIndex = 111
        Me.CUIT_verificador.TabStop = False
        Me.CUIT_verificador.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(61, 368)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(181, 21)
        Me.Label6.TabIndex = 110
        Me.Label6.Text = "ALIAS DE CBU (opcional)"
        '
        'CBU_alias
        '
        Me.CBU_alias.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CBU_alias.BackColor = System.Drawing.Color.White
        Me.CBU_alias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CBU_alias.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBU_alias.ForeColor = System.Drawing.Color.Black
        Me.CBU_alias.Location = New System.Drawing.Point(0, 389)
        Me.CBU_alias.Margin = New System.Windows.Forms.Padding(0)
        Me.CBU_alias.Name = "CBU_alias"
        Me.CBU_alias.Size = New System.Drawing.Size(389, 29)
        Me.CBU_alias.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(46, 318)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(196, 21)
        Me.Label5.TabIndex = 108
        Me.Label5.Text = "Número de CBU (opcional)"
        '
        'CBU_Nro
        '
        Me.CBU_Nro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CBU_Nro.BackColor = System.Drawing.Color.White
        Me.CBU_Nro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CBU_Nro.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBU_Nro.ForeColor = System.Drawing.Color.Black
        Me.CBU_Nro.Location = New System.Drawing.Point(0, 339)
        Me.CBU_Nro.Margin = New System.Windows.Forms.Padding(0)
        Me.CBU_Nro.Name = "CBU_Nro"
        Me.CBU_Nro.Size = New System.Drawing.Size(389, 29)
        Me.CBU_Nro.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(39, 45)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(242, 21)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "Apellido y Nombre del Proveedor"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(81, 95)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 21)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "Número de CUIT"
        '
        'Nombrebeneficiario_textbox
        '
        Me.Nombrebeneficiario_textbox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Nombrebeneficiario_textbox.BackColor = System.Drawing.Color.White
        Me.Nombrebeneficiario_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Nombrebeneficiario_textbox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombrebeneficiario_textbox.ForeColor = System.Drawing.Color.Black
        Me.Nombrebeneficiario_textbox.Location = New System.Drawing.Point(3, 66)
        Me.Nombrebeneficiario_textbox.Margin = New System.Windows.Forms.Padding(0)
        Me.Nombrebeneficiario_textbox.Name = "Nombrebeneficiario_textbox"
        Me.Nombrebeneficiario_textbox.Size = New System.Drawing.Size(389, 29)
        Me.Nombrebeneficiario_textbox.TabIndex = 0
        '
        'Cuitadd_textbox
        '
        Me.Cuitadd_textbox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cuitadd_textbox.BackColor = System.Drawing.Color.White
        Me.Cuitadd_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cuitadd_textbox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cuitadd_textbox.ForeColor = System.Drawing.Color.Black
        Me.Cuitadd_textbox.Location = New System.Drawing.Point(3, 116)
        Me.Cuitadd_textbox.Margin = New System.Windows.Forms.Padding(0)
        Me.Cuitadd_textbox.Name = "Cuitadd_textbox"
        Me.Cuitadd_textbox.Size = New System.Drawing.Size(356, 29)
        Me.Cuitadd_textbox.TabIndex = 1
        '
        'CUIT_agregarnuevo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(397, 478)
        Me.Controls.Add(Me.DatosnuevoCUIT_panel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CUIT_agregarnuevo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CUIT_agregarnuevo"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.DatosnuevoCUIT_panel.ResumeLayout(False)
        Me.DatosnuevoCUIT_panel.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.CUIT_verificador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents DatosnuevoCUIT_panel As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents CBU_alias As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents CBU_Nro As TextBox
    Friend WithEvents CancelarCUIT_boton As Button
    Friend WithEvents AgregarCUIT_boton As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Nombrebeneficiario_textbox As TextBox
    Friend WithEvents Cuitadd_textbox As TextBox
    Friend WithEvents CUIT_verificador As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label_expedienteasociados As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Nombrefantasiabeneficiario_textbox As TextBox
    Friend WithEvents CUITLABELMASCULINO As Label
    Friend WithEvents CUITLABELTEORICOfEMENINO As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Domicilio_textbox As TextBox
End Class
