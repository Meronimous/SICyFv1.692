<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialogo_CUIT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dialogo_CUIT))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Boton_busqueda = New System.Windows.Forms.Button()
        Me.Busqueda = New System.Windows.Forms.TextBox()
        Me.Datosbeneficiarios_datagridview = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.BotondevolverCuit = New System.Windows.Forms.Button()
        Me.CUITadevolver_textbox = New System.Windows.Forms.TextBox()
        Me.Botoncancelardevolver = New System.Windows.Forms.Button()
        Me.DatosnuevoCUIT_panel = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CBU_alias = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CBU_Nro = New System.Windows.Forms.TextBox()
        Me.CancelarCUIT_boton = New System.Windows.Forms.Button()
        Me.AgregarCUIT_boton = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Nombrebeneficiario_textbox = New System.Windows.Forms.TextBox()
        Me.Cuitadd_textbox = New System.Windows.Forms.TextBox()
        Me.Cargarnuevocuit_boton = New System.Windows.Forms.Button()
        Me.Datosbeneficiarios_Panel = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Cerrar_boton = New System.Windows.Forms.Button()
        Me.Label_expedienteasociados = New System.Windows.Forms.Label()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.registroproveedores = New System.Windows.Forms.Button()
        CType(Me.Datosbeneficiarios_datagridview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DatosnuevoCUIT_panel.SuspendLayout()
        Me.Datosbeneficiarios_Panel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Boton_busqueda
        '
        Me.Boton_busqueda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Boton_busqueda.AutoSize = True
        Me.Boton_busqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Boton_busqueda.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Boton_busqueda.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Boton_busqueda.ForeColor = System.Drawing.Color.White
        Me.Boton_busqueda.Image = CType(resources.GetObject("Boton_busqueda.Image"), System.Drawing.Image)
        Me.Boton_busqueda.Location = New System.Drawing.Point(258, 3)
        Me.Boton_busqueda.Name = "Boton_busqueda"
        Me.Boton_busqueda.Size = New System.Drawing.Size(119, 38)
        Me.Boton_busqueda.TabIndex = 1
        Me.Boton_busqueda.Text = "Buscar"
        Me.Boton_busqueda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Boton_busqueda.UseVisualStyleBackColor = True
        '
        'Busqueda
        '
        Me.Busqueda.BackColor = System.Drawing.Color.White
        Me.Busqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Busqueda.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Busqueda.ForeColor = System.Drawing.Color.Black
        Me.Busqueda.Location = New System.Drawing.Point(6, 19)
        Me.Busqueda.Margin = New System.Windows.Forms.Padding(0)
        Me.Busqueda.Name = "Busqueda"
        Me.Busqueda.Size = New System.Drawing.Size(205, 20)
        Me.Busqueda.TabIndex = 0
        '
        'Datosbeneficiarios_datagridview
        '
        Me.Datosbeneficiarios_datagridview.AllowUserToAddRows = False
        Me.Datosbeneficiarios_datagridview.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Datosbeneficiarios_datagridview.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.Datosbeneficiarios_datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.Datosbeneficiarios_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Datosbeneficiarios_datagridview.Location = New System.Drawing.Point(3, 43)
        Me.Datosbeneficiarios_datagridview.MultiSelect = False
        Me.Datosbeneficiarios_datagridview.Name = "Datosbeneficiarios_datagridview"
        Me.Datosbeneficiarios_datagridview.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
        Me.Datosbeneficiarios_datagridview.ReadOnly = True
        Me.Datosbeneficiarios_datagridview.RowHeadersVisible = False
        Me.Datosbeneficiarios_datagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Datosbeneficiarios_datagridview.Size = New System.Drawing.Size(488, 305)
        Me.Datosbeneficiarios_datagridview.TabIndex = 2
        '
        'BotondevolverCuit
        '
        Me.BotondevolverCuit.AutoSize = True
        Me.BotondevolverCuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BotondevolverCuit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BotondevolverCuit.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BotondevolverCuit.ForeColor = System.Drawing.Color.White
        Me.BotondevolverCuit.Image = CType(resources.GetObject("BotondevolverCuit.Image"), System.Drawing.Image)
        Me.BotondevolverCuit.Location = New System.Drawing.Point(258, 348)
        Me.BotondevolverCuit.Name = "BotondevolverCuit"
        Me.BotondevolverCuit.Size = New System.Drawing.Size(119, 38)
        Me.BotondevolverCuit.TabIndex = 4
        Me.BotondevolverCuit.Text = "Cargar CUIT"
        Me.BotondevolverCuit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BotondevolverCuit.UseVisualStyleBackColor = True
        '
        'CUITadevolver_textbox
        '
        Me.CUITadevolver_textbox.BackColor = System.Drawing.Color.White
        Me.CUITadevolver_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CUITadevolver_textbox.Font = New System.Drawing.Font("Garamond", 10.0!)
        Me.CUITadevolver_textbox.ForeColor = System.Drawing.Color.Black
        Me.CUITadevolver_textbox.Location = New System.Drawing.Point(14, 367)
        Me.CUITadevolver_textbox.Margin = New System.Windows.Forms.Padding(0)
        Me.CUITadevolver_textbox.Name = "CUITadevolver_textbox"
        Me.CUITadevolver_textbox.Size = New System.Drawing.Size(193, 22)
        Me.CUITadevolver_textbox.TabIndex = 3
        '
        'Botoncancelardevolver
        '
        Me.Botoncancelardevolver.AutoSize = True
        Me.Botoncancelardevolver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Botoncancelardevolver.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Botoncancelardevolver.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Botoncancelardevolver.ForeColor = System.Drawing.Color.White
        Me.Botoncancelardevolver.Image = CType(resources.GetObject("Botoncancelardevolver.Image"), System.Drawing.Image)
        Me.Botoncancelardevolver.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Botoncancelardevolver.Location = New System.Drawing.Point(383, 348)
        Me.Botoncancelardevolver.Name = "Botoncancelardevolver"
        Me.Botoncancelardevolver.Size = New System.Drawing.Size(104, 38)
        Me.Botoncancelardevolver.TabIndex = 5
        Me.Botoncancelardevolver.Text = "Cancelar"
        Me.Botoncancelardevolver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Botoncancelardevolver.UseVisualStyleBackColor = True
        '
        'DatosnuevoCUIT_panel
        '
        Me.DatosnuevoCUIT_panel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DatosnuevoCUIT_panel.BackColor = System.Drawing.Color.SteelBlue
        Me.DatosnuevoCUIT_panel.Controls.Add(Me.Label6)
        Me.DatosnuevoCUIT_panel.Controls.Add(Me.CBU_alias)
        Me.DatosnuevoCUIT_panel.Controls.Add(Me.Label5)
        Me.DatosnuevoCUIT_panel.Controls.Add(Me.CBU_Nro)
        Me.DatosnuevoCUIT_panel.Controls.Add(Me.CancelarCUIT_boton)
        Me.DatosnuevoCUIT_panel.Controls.Add(Me.AgregarCUIT_boton)
        Me.DatosnuevoCUIT_panel.Controls.Add(Me.Label2)
        Me.DatosnuevoCUIT_panel.Controls.Add(Me.Label1)
        Me.DatosnuevoCUIT_panel.Controls.Add(Me.Nombrebeneficiario_textbox)
        Me.DatosnuevoCUIT_panel.Controls.Add(Me.Cuitadd_textbox)
        Me.DatosnuevoCUIT_panel.Location = New System.Drawing.Point(500, 44)
        Me.DatosnuevoCUIT_panel.Name = "DatosnuevoCUIT_panel"
        Me.DatosnuevoCUIT_panel.Size = New System.Drawing.Size(239, 394)
        Me.DatosnuevoCUIT_panel.TabIndex = 105
        Me.DatosnuevoCUIT_panel.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(11, 133)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 110
        Me.Label6.Text = "ALIAS DE CBU"
        '
        'CBU_alias
        '
        Me.CBU_alias.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CBU_alias.BackColor = System.Drawing.Color.White
        Me.CBU_alias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CBU_alias.Font = New System.Drawing.Font("Garamond", 10.0!)
        Me.CBU_alias.ForeColor = System.Drawing.Color.Black
        Me.CBU_alias.Location = New System.Drawing.Point(1, 149)
        Me.CBU_alias.Margin = New System.Windows.Forms.Padding(0)
        Me.CBU_alias.Name = "CBU_alias"
        Me.CBU_alias.Size = New System.Drawing.Size(238, 22)
        Me.CBU_alias.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(11, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 13)
        Me.Label5.TabIndex = 108
        Me.Label5.Text = "Número de CBU"
        '
        'CBU_Nro
        '
        Me.CBU_Nro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CBU_Nro.BackColor = System.Drawing.Color.White
        Me.CBU_Nro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CBU_Nro.Font = New System.Drawing.Font("Garamond", 10.0!)
        Me.CBU_Nro.ForeColor = System.Drawing.Color.Black
        Me.CBU_Nro.Location = New System.Drawing.Point(1, 110)
        Me.CBU_Nro.Margin = New System.Windows.Forms.Padding(0)
        Me.CBU_Nro.Name = "CBU_Nro"
        Me.CBU_Nro.Size = New System.Drawing.Size(238, 22)
        Me.CBU_Nro.TabIndex = 8
        '
        'CancelarCUIT_boton
        '
        Me.CancelarCUIT_boton.AutoSize = True
        Me.CancelarCUIT_boton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CancelarCUIT_boton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CancelarCUIT_boton.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CancelarCUIT_boton.ForeColor = System.Drawing.Color.White
        Me.CancelarCUIT_boton.Image = CType(resources.GetObject("CancelarCUIT_boton.Image"), System.Drawing.Image)
        Me.CancelarCUIT_boton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CancelarCUIT_boton.Location = New System.Drawing.Point(125, 190)
        Me.CancelarCUIT_boton.Name = "CancelarCUIT_boton"
        Me.CancelarCUIT_boton.Size = New System.Drawing.Size(111, 38)
        Me.CancelarCUIT_boton.TabIndex = 11
        Me.CancelarCUIT_boton.Text = "Cancelar"
        Me.CancelarCUIT_boton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CancelarCUIT_boton.UseVisualStyleBackColor = True
        '
        'AgregarCUIT_boton
        '
        Me.AgregarCUIT_boton.AutoSize = True
        Me.AgregarCUIT_boton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.AgregarCUIT_boton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.AgregarCUIT_boton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AgregarCUIT_boton.ForeColor = System.Drawing.Color.White
        Me.AgregarCUIT_boton.Image = CType(resources.GetObject("AgregarCUIT_boton.Image"), System.Drawing.Image)
        Me.AgregarCUIT_boton.Location = New System.Drawing.Point(4, 190)
        Me.AgregarCUIT_boton.Name = "AgregarCUIT_boton"
        Me.AgregarCUIT_boton.Size = New System.Drawing.Size(115, 38)
        Me.AgregarCUIT_boton.TabIndex = 10
        Me.AgregarCUIT_boton.Text = "Cargar Datos"
        Me.AgregarCUIT_boton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AgregarCUIT_boton.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(11, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 13)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "Nombre del Beneficiario"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(11, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "Número de CUIT"
        '
        'Nombrebeneficiario_textbox
        '
        Me.Nombrebeneficiario_textbox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Nombrebeneficiario_textbox.BackColor = System.Drawing.Color.White
        Me.Nombrebeneficiario_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Nombrebeneficiario_textbox.Font = New System.Drawing.Font("Garamond", 10.0!)
        Me.Nombrebeneficiario_textbox.ForeColor = System.Drawing.Color.Black
        Me.Nombrebeneficiario_textbox.Location = New System.Drawing.Point(1, 27)
        Me.Nombrebeneficiario_textbox.Margin = New System.Windows.Forms.Padding(0)
        Me.Nombrebeneficiario_textbox.Name = "Nombrebeneficiario_textbox"
        Me.Nombrebeneficiario_textbox.Size = New System.Drawing.Size(238, 22)
        Me.Nombrebeneficiario_textbox.TabIndex = 6
        '
        'Cuitadd_textbox
        '
        Me.Cuitadd_textbox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cuitadd_textbox.BackColor = System.Drawing.Color.White
        Me.Cuitadd_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cuitadd_textbox.Font = New System.Drawing.Font("Garamond", 10.0!)
        Me.Cuitadd_textbox.ForeColor = System.Drawing.Color.Black
        Me.Cuitadd_textbox.Location = New System.Drawing.Point(1, 69)
        Me.Cuitadd_textbox.Margin = New System.Windows.Forms.Padding(0)
        Me.Cuitadd_textbox.Name = "Cuitadd_textbox"
        Me.Cuitadd_textbox.Size = New System.Drawing.Size(238, 22)
        Me.Cuitadd_textbox.TabIndex = 7
        '
        'Cargarnuevocuit_boton
        '
        Me.Cargarnuevocuit_boton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cargarnuevocuit_boton.AutoSize = True
        Me.Cargarnuevocuit_boton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Cargarnuevocuit_boton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cargarnuevocuit_boton.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Cargarnuevocuit_boton.ForeColor = System.Drawing.Color.White
        Me.Cargarnuevocuit_boton.Image = CType(resources.GetObject("Cargarnuevocuit_boton.Image"), System.Drawing.Image)
        Me.Cargarnuevocuit_boton.Location = New System.Drawing.Point(383, 3)
        Me.Cargarnuevocuit_boton.Name = "Cargarnuevocuit_boton"
        Me.Cargarnuevocuit_boton.Size = New System.Drawing.Size(108, 38)
        Me.Cargarnuevocuit_boton.TabIndex = 5
        Me.Cargarnuevocuit_boton.Text = "Nuevo CUIT"
        Me.Cargarnuevocuit_boton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cargarnuevocuit_boton.UseVisualStyleBackColor = True
        '
        'Datosbeneficiarios_Panel
        '
        Me.Datosbeneficiarios_Panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Datosbeneficiarios_Panel.BackColor = System.Drawing.Color.SteelBlue
        Me.Datosbeneficiarios_Panel.Controls.Add(Me.registroproveedores)
        Me.Datosbeneficiarios_Panel.Controls.Add(Me.Label4)
        Me.Datosbeneficiarios_Panel.Controls.Add(Me.Label3)
        Me.Datosbeneficiarios_Panel.Controls.Add(Me.Busqueda)
        Me.Datosbeneficiarios_Panel.Controls.Add(Me.Cargarnuevocuit_boton)
        Me.Datosbeneficiarios_Panel.Controls.Add(Me.Datosbeneficiarios_datagridview)
        Me.Datosbeneficiarios_Panel.Controls.Add(Me.Boton_busqueda)
        Me.Datosbeneficiarios_Panel.Controls.Add(Me.Botoncancelardevolver)
        Me.Datosbeneficiarios_Panel.Controls.Add(Me.CUITadevolver_textbox)
        Me.Datosbeneficiarios_Panel.Controls.Add(Me.BotondevolverCuit)
        Me.Datosbeneficiarios_Panel.Location = New System.Drawing.Point(3, 44)
        Me.Datosbeneficiarios_Panel.Name = "Datosbeneficiarios_Panel"
        Me.Datosbeneficiarios_Panel.Size = New System.Drawing.Size(494, 397)
        Me.Datosbeneficiarios_Panel.TabIndex = 106
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(15, 354)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 13)
        Me.Label4.TabIndex = 108
        Me.Label4.Text = "CUIT seleccionado"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(11, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(216, 13)
        Me.Label3.TabIndex = 107
        Me.Label3.Text = "Buscar por Nombre, Rubro o Documento"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.Cerrar_boton)
        Me.Panel1.Controls.Add(Me.Label_expedienteasociados)
        Me.Panel1.Controls.Add(Me.Cancel_Button)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(743, 42)
        Me.Panel1.TabIndex = 107
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
        Me.Cerrar_boton.Location = New System.Drawing.Point(701, 0)
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
        Me.Label_expedienteasociados.Location = New System.Drawing.Point(212, 9)
        Me.Label_expedienteasociados.Name = "Label_expedienteasociados"
        Me.Label_expedienteasociados.Size = New System.Drawing.Size(312, 30)
        Me.Label_expedienteasociados.TabIndex = 29
        Me.Label_expedienteasociados.Text = "CUIT asociados al expediente"
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
        'registroproveedores
        '
        Me.registroproveedores.AutoSize = True
        Me.registroproveedores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.registroproveedores.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.registroproveedores.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.registroproveedores.ForeColor = System.Drawing.Color.White
        Me.registroproveedores.Image = CType(resources.GetObject("registroproveedores.Image"), System.Drawing.Image)
        Me.registroproveedores.Location = New System.Drawing.Point(137, 351)
        Me.registroproveedores.Name = "registroproveedores"
        Me.registroproveedores.Size = New System.Drawing.Size(115, 38)
        Me.registroproveedores.TabIndex = 111
        Me.registroproveedores.Text = "Cargar Datos"
        Me.registroproveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.registroproveedores.UseVisualStyleBackColor = True
        '
        'Dialogo_CUIT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(743, 445)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Datosbeneficiarios_Panel)
        Me.Controls.Add(Me.DatosnuevoCUIT_panel)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Dialogo_CUIT"
        Me.ShowInTaskbar = False
        Me.Text = "Dialogo_Beneficiario"
        CType(Me.Datosbeneficiarios_datagridview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DatosnuevoCUIT_panel.ResumeLayout(False)
        Me.DatosnuevoCUIT_panel.PerformLayout()
        Me.Datosbeneficiarios_Panel.ResumeLayout(False)
        Me.Datosbeneficiarios_Panel.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents Boton_busqueda As Button
    Friend WithEvents Busqueda As TextBox
    Friend WithEvents Datosbeneficiarios_datagridview As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents BotondevolverCuit As Button
    Friend WithEvents CUITadevolver_textbox As TextBox
    Friend WithEvents Botoncancelardevolver As Button
    Friend WithEvents DatosnuevoCUIT_panel As Panel
    Friend WithEvents Nombrebeneficiario_textbox As TextBox
    Friend WithEvents Cuitadd_textbox As TextBox
    Friend WithEvents Cargarnuevocuit_boton As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Datosbeneficiarios_Panel As Panel
    Friend WithEvents CancelarCUIT_boton As Button
    Friend WithEvents AgregarCUIT_boton As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents CBU_Nro As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents CBU_alias As TextBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label_expedienteasociados As Label
    Friend WithEvents Cancel_Button As Button
    Friend WithEvents Cerrar_boton As Button
    Friend WithEvents registroproveedores As Button
End Class
