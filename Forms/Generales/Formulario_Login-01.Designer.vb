<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class INGRESO
    Inherits System.Windows.Forms.Form
    'Inherits ComponentFactory.Krypton.Toolkit.KryptonForm
    'Inherits MaterialSkin.Controls.MaterialForm
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
    Friend WithEvents UsernameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(INGRESO))
        Me.UsernameTextBox = New System.Windows.Forms.TextBox()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.OK = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.Panel_CENTRAL = New System.Windows.Forms.Panel()
        Me.Conectando_panel = New SICyF.PANEL_sinFlicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Mododepuracion = New System.Windows.Forms.CheckBox()
        Me.Paneldatoslogin = New System.Windows.Forms.Panel()
        Me.Refresh = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.PaneL_sinFlicker2 = New SICyF.PANEL_sinFlicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Servidor2_label = New System.Windows.Forms.Label()
        Me.PaneL_sinFlicker1 = New SICyF.PANEL_sinFlicker()
        Me.Servidor1_label = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Pwdidpic = New System.Windows.Forms.PictureBox()
        Me.Useridpic = New System.Windows.Forms.PictureBox()
        Me.Nuevousuario_boton = New System.Windows.Forms.Button()
        Me.Labeltitulo = New System.Windows.Forms.Label()
        Me.Messagetooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Workerinicial = New System.ComponentModel.BackgroundWorker()
        Me.Versionlabel = New System.Windows.Forms.Label()
        Me.Panel_CENTRAL.SuspendLayout()
        Me.Conectando_panel.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Paneldatoslogin.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.PaneL_sinFlicker2.SuspendLayout()
        Me.PaneL_sinFlicker1.SuspendLayout()
        CType(Me.Pwdidpic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Useridpic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UsernameTextBox
        '
        Me.UsernameTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UsernameTextBox.BackColor = System.Drawing.Color.White
        Me.UsernameTextBox.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameTextBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.UsernameTextBox.Location = New System.Drawing.Point(148, 2)
        Me.UsernameTextBox.Margin = New System.Windows.Forms.Padding(0)
        Me.UsernameTextBox.Name = "UsernameTextBox"
        Me.UsernameTextBox.Size = New System.Drawing.Size(198, 39)
        Me.UsernameTextBox.TabIndex = 0
        Me.UsernameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.UsernameTextBox.Visible = False
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PasswordTextBox.BackColor = System.Drawing.Color.White
        Me.PasswordTextBox.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.PasswordTextBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.PasswordTextBox.Location = New System.Drawing.Point(148, 43)
        Me.PasswordTextBox.Margin = New System.Windows.Forms.Padding(0)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordTextBox.Size = New System.Drawing.Size(198, 27)
        Me.PasswordTextBox.TabIndex = 1
        Me.PasswordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.PasswordTextBox.UseSystemPasswordChar = True
        Me.PasswordTextBox.Visible = False
        '
        'OK
        '
        Me.OK.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK.BackColor = System.Drawing.Color.Green
        Me.OK.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.OK.FlatAppearance.BorderSize = 2
        Me.OK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue
        Me.OK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue
        Me.OK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.OK.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK.ForeColor = System.Drawing.Color.White
        Me.OK.Location = New System.Drawing.Point(-2, 92)
        Me.OK.Margin = New System.Windows.Forms.Padding(0)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(480, 38)
        Me.OK.TabIndex = 2
        Me.OK.Text = "&CONECTAR"
        Me.OK.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.OK.UseVisualStyleBackColor = False
        Me.OK.Visible = False
        '
        'Cancel
        '
        Me.Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Cancel.BackgroundImage = CType(resources.GetObject("Cancel.BackgroundImage"), System.Drawing.Image)
        Me.Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.FlatAppearance.BorderSize = 0
        Me.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancel.Location = New System.Drawing.Point(442, 2)
        Me.Cancel.Margin = New System.Windows.Forms.Padding(0)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(30, 33)
        Me.Cancel.TabIndex = 3
        Me.Cancel.UseVisualStyleBackColor = False
        Me.Cancel.Visible = False
        '
        'Panel_CENTRAL
        '
        Me.Panel_CENTRAL.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Panel_CENTRAL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel_CENTRAL.Controls.Add(Me.Conectando_panel)
        Me.Panel_CENTRAL.Controls.Add(Me.Mododepuracion)
        Me.Panel_CENTRAL.Location = New System.Drawing.Point(-1, 56)
        Me.Panel_CENTRAL.Name = "Panel_CENTRAL"
        Me.Panel_CENTRAL.Size = New System.Drawing.Size(486, 223)
        Me.Panel_CENTRAL.TabIndex = 4
        '
        'Conectando_panel
        '
        Me.Conectando_panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Conectando_panel.BackColor = System.Drawing.Color.Transparent
        Me.Conectando_panel.Controls.Add(Me.Label2)
        Me.Conectando_panel.Controls.Add(Me.PictureBox1)
        Me.Conectando_panel.Location = New System.Drawing.Point(0, 0)
        Me.Conectando_panel.Name = "Conectando_panel"
        Me.Conectando_panel.Size = New System.Drawing.Size(480, 220)
        Me.Conectando_panel.TabIndex = 14
        Me.Conectando_panel.Visible = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(119, 186)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(244, 32)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "CONECTANDO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(-15, -3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(512, 201)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Mododepuracion
        '
        Me.Mododepuracion.AutoSize = True
        Me.Mododepuracion.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mododepuracion.Location = New System.Drawing.Point(20, 223)
        Me.Mododepuracion.Name = "Mododepuracion"
        Me.Mododepuracion.Size = New System.Drawing.Size(209, 34)
        Me.Mododepuracion.TabIndex = 13
        Me.Mododepuracion.Text = "Modo Depuración?"
        Me.Mododepuracion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Mododepuracion.UseVisualStyleBackColor = True
        Me.Mododepuracion.Visible = False
        '
        'Paneldatoslogin
        '
        Me.Paneldatoslogin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Paneldatoslogin.BackColor = System.Drawing.Color.Transparent
        Me.Paneldatoslogin.Controls.Add(Me.Cancel)
        Me.Paneldatoslogin.Controls.Add(Me.Refresh)
        Me.Paneldatoslogin.Controls.Add(Me.Label1)
        Me.Paneldatoslogin.Controls.Add(Me.TableLayoutPanel1)
        Me.Paneldatoslogin.Controls.Add(Me.Pwdidpic)
        Me.Paneldatoslogin.Controls.Add(Me.PasswordTextBox)
        Me.Paneldatoslogin.Controls.Add(Me.Useridpic)
        Me.Paneldatoslogin.Controls.Add(Me.UsernameTextBox)
        Me.Paneldatoslogin.Controls.Add(Me.OK)
        Me.Paneldatoslogin.Controls.Add(Me.Nuevousuario_boton)
        Me.Paneldatoslogin.Location = New System.Drawing.Point(3, 48)
        Me.Paneldatoslogin.Margin = New System.Windows.Forms.Padding(0)
        Me.Paneldatoslogin.Name = "Paneldatoslogin"
        Me.Paneldatoslogin.Size = New System.Drawing.Size(478, 226)
        Me.Paneldatoslogin.TabIndex = 12
        '
        'Refresh
        '
        Me.Refresh.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Refresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Refresh.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Refresh.FlatAppearance.BorderSize = 2
        Me.Refresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue
        Me.Refresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue
        Me.Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Refresh.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Refresh.ForeColor = System.Drawing.Color.White
        Me.Refresh.Image = CType(resources.GetObject("Refresh.Image"), System.Drawing.Image)
        Me.Refresh.Location = New System.Drawing.Point(450, 146)
        Me.Refresh.Margin = New System.Windows.Forms.Padding(0)
        Me.Refresh.Name = "Refresh"
        Me.Refresh.Size = New System.Drawing.Size(24, 30)
        Me.Refresh.TabIndex = 14
        Me.Refresh.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Refresh.UseVisualStyleBackColor = False
        Me.Refresh.Visible = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(145, 70)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(201, 21)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "FORTALECIMIENTO INSTITUCIONAL"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.PaneL_sinFlicker2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PaneL_sinFlicker1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 179)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(478, 47)
        Me.TableLayoutPanel1.TabIndex = 13
        '
        'PaneL_sinFlicker2
        '
        Me.PaneL_sinFlicker2.Controls.Add(Me.Label6)
        Me.PaneL_sinFlicker2.Controls.Add(Me.Servidor2_label)
        Me.PaneL_sinFlicker2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PaneL_sinFlicker2.Location = New System.Drawing.Point(242, 3)
        Me.PaneL_sinFlicker2.Name = "PaneL_sinFlicker2"
        Me.PaneL_sinFlicker2.Size = New System.Drawing.Size(233, 41)
        Me.PaneL_sinFlicker2.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(83, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 15)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Servidor 2"
        '
        'Servidor2_label
        '
        Me.Servidor2_label.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Servidor2_label.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Servidor2_label.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Servidor2_label.ForeColor = System.Drawing.Color.White
        Me.Servidor2_label.Location = New System.Drawing.Point(0, 16)
        Me.Servidor2_label.Name = "Servidor2_label"
        Me.Servidor2_label.Size = New System.Drawing.Size(227, 25)
        Me.Servidor2_label.TabIndex = 7
        Me.Servidor2_label.Text = "..."
        Me.Servidor2_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PaneL_sinFlicker1
        '
        Me.PaneL_sinFlicker1.Controls.Add(Me.Servidor1_label)
        Me.PaneL_sinFlicker1.Controls.Add(Me.Label5)
        Me.PaneL_sinFlicker1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PaneL_sinFlicker1.Location = New System.Drawing.Point(3, 3)
        Me.PaneL_sinFlicker1.Name = "PaneL_sinFlicker1"
        Me.PaneL_sinFlicker1.Size = New System.Drawing.Size(233, 41)
        Me.PaneL_sinFlicker1.TabIndex = 0
        '
        'Servidor1_label
        '
        Me.Servidor1_label.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Servidor1_label.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Servidor1_label.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Servidor1_label.ForeColor = System.Drawing.Color.White
        Me.Servidor1_label.Location = New System.Drawing.Point(0, 16)
        Me.Servidor1_label.Margin = New System.Windows.Forms.Padding(0)
        Me.Servidor1_label.Name = "Servidor1_label"
        Me.Servidor1_label.Size = New System.Drawing.Size(227, 25)
        Me.Servidor1_label.TabIndex = 6
        Me.Servidor1_label.Text = "..."
        Me.Servidor1_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(72, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 15)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Servidor 1"
        '
        'Pwdidpic
        '
        Me.Pwdidpic.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.Pwdidpic.Image = CType(resources.GetObject("Pwdidpic.Image"), System.Drawing.Image)
        Me.Pwdidpic.Location = New System.Drawing.Point(114, 41)
        Me.Pwdidpic.Margin = New System.Windows.Forms.Padding(0)
        Me.Pwdidpic.Name = "Pwdidpic"
        Me.Pwdidpic.Size = New System.Drawing.Size(34, 30)
        Me.Pwdidpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Pwdidpic.TabIndex = 12
        Me.Pwdidpic.TabStop = False
        Me.Pwdidpic.Visible = False
        '
        'Useridpic
        '
        Me.Useridpic.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.Useridpic.Image = CType(resources.GetObject("Useridpic.Image"), System.Drawing.Image)
        Me.Useridpic.Location = New System.Drawing.Point(114, 5)
        Me.Useridpic.Margin = New System.Windows.Forms.Padding(0)
        Me.Useridpic.Name = "Useridpic"
        Me.Useridpic.Size = New System.Drawing.Size(34, 36)
        Me.Useridpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Useridpic.TabIndex = 11
        Me.Useridpic.TabStop = False
        Me.Useridpic.Visible = False
        '
        'Nuevousuario_boton
        '
        Me.Nuevousuario_boton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Nuevousuario_boton.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Nuevousuario_boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Nuevousuario_boton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nuevousuario_boton.ForeColor = System.Drawing.Color.White
        Me.Nuevousuario_boton.Location = New System.Drawing.Point(354, 41)
        Me.Nuevousuario_boton.Margin = New System.Windows.Forms.Padding(0)
        Me.Nuevousuario_boton.Name = "Nuevousuario_boton"
        Me.Nuevousuario_boton.Size = New System.Drawing.Size(115, 27)
        Me.Nuevousuario_boton.TabIndex = 10
        Me.Nuevousuario_boton.Text = "Nuevo Usuario"
        Me.Nuevousuario_boton.UseVisualStyleBackColor = True
        Me.Nuevousuario_boton.Visible = False
        '
        'Labeltitulo
        '
        Me.Labeltitulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Labeltitulo.BackColor = System.Drawing.Color.Transparent
        Me.Labeltitulo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labeltitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.Labeltitulo.Location = New System.Drawing.Point(-1, -2)
        Me.Labeltitulo.Name = "Labeltitulo"
        Me.Labeltitulo.Size = New System.Drawing.Size(482, 55)
        Me.Labeltitulo.TabIndex = 5
        Me.Labeltitulo.Text = "CONTADURÍA GENERAL" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sistema Integrado de Información Contable y Financiera      "
        Me.Labeltitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Messagetooltip
        '
        Me.Messagetooltip.AutoPopDelay = 5000
        Me.Messagetooltip.BackColor = System.Drawing.Color.RoyalBlue
        Me.Messagetooltip.ForeColor = System.Drawing.Color.White
        Me.Messagetooltip.InitialDelay = 700
        Me.Messagetooltip.ReshowDelay = 100
        Me.Messagetooltip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'Workerinicial
        '
        '
        'Versionlabel
        '
        Me.Versionlabel.AutoSize = True
        Me.Versionlabel.BackColor = System.Drawing.Color.Transparent
        Me.Versionlabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Versionlabel.ForeColor = System.Drawing.Color.White
        Me.Versionlabel.Location = New System.Drawing.Point(3, 282)
        Me.Versionlabel.Name = "Versionlabel"
        Me.Versionlabel.Size = New System.Drawing.Size(18, 15)
        Me.Versionlabel.TabIndex = 9
        Me.Versionlabel.Text = "V:"
        '
        'INGRESO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(482, 304)
        Me.ControlBox = False
        Me.Controls.Add(Me.Paneldatoslogin)
        Me.Controls.Add(Me.Panel_CENTRAL)
        Me.Controls.Add(Me.Versionlabel)
        Me.Controls.Add(Me.Labeltitulo)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "INGRESO"
        Me.Opacity = 0.85R
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Por favor ingrese sus datos"
        Me.Panel_CENTRAL.ResumeLayout(False)
        Me.Panel_CENTRAL.PerformLayout()
        Me.Conectando_panel.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Paneldatoslogin.ResumeLayout(False)
        Me.Paneldatoslogin.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.PaneL_sinFlicker2.ResumeLayout(False)
        Me.PaneL_sinFlicker2.PerformLayout()
        Me.PaneL_sinFlicker1.ResumeLayout(False)
        Me.PaneL_sinFlicker1.PerformLayout()
        CType(Me.Pwdidpic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Useridpic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
    Friend WithEvents Panel_CENTRAL As Panel
    Friend WithEvents Labeltitulo As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Servidor2_label As Label
    Friend WithEvents Servidor1_label As Label
    Friend WithEvents Nuevousuario_boton As Button
    Friend WithEvents Paneldatoslogin As Panel
    Friend WithEvents Pwdidpic As PictureBox
    Friend WithEvents Useridpic As PictureBox
    Friend WithEvents Messagetooltip As ToolTip
    Friend WithEvents Workerinicial As System.ComponentModel.BackgroundWorker
    Friend WithEvents Mododepuracion As CheckBox
    Friend WithEvents Conectando_panel As PANEL_sinFlicker
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents PaneL_sinFlicker2 As PANEL_sinFlicker
    Friend WithEvents PaneL_sinFlicker1 As PANEL_sinFlicker
    Friend WithEvents Refresh As Button
    Friend WithEvents Versionlabel As Label
End Class
