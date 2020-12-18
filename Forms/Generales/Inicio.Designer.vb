<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Inicio
    Inherits System.Windows.Forms.Form
    'Inherits ComponentFactory.Krypton.Toolkit.KryptonForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inicio))
        Me.MessageTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStripgeneral = New System.Windows.Forms.ToolStrip()
        Me.Menuboton_cheques = New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton()
        Me.KryptonManager1 = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.StatusSiciyf = New System.Windows.Forms.StatusStrip()
        Me.Servidor1toolstrip_label = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Servidor2toolstrip_label = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Serveractivotoolstrip = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Usuariotoolstrip_label = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Direcciontoolstrip_label = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripDebug = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Resultadotoolstrip_label = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label_EJERCICIOFINANCIERO = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.Tiempodetecleogeneral = New System.Windows.Forms.Timer(Me.components)
        Me.RibbonMenu = New System.Windows.Forms.Ribbon()
        Me.RibbonColorChooser1 = New System.Windows.Forms.RibbonColorChooser()
        Me.RibbonButton1 = New System.Windows.Forms.RibbonButton()
        Me.RibbonButton7 = New System.Windows.Forms.RibbonButton()
        Me.RibbonButton9 = New System.Windows.Forms.RibbonButton()
        Me.RibbonButton10 = New System.Windows.Forms.RibbonButton()
        Me.Tesoreriamenu = New System.Windows.Forms.RibbonTab()
        Me.PanelTesoreria = New System.Windows.Forms.RibbonPanel()
        Me.Tesoreriamenu_Expedientes = New System.Windows.Forms.RibbonButton()
        Me.Tesoreriamenu_PedidodeFondos = New System.Windows.Forms.RibbonButton()
        Me.Tesoreriamenu_Movimientos = New System.Windows.Forms.RibbonButton()
        Me.Tesoreriamenu_Liquidaciones = New System.Windows.Forms.RibbonButton()
        Me.Recibos_retenciones = New System.Windows.Forms.RibbonButton()
        Me.Retencionescheque = New System.Windows.Forms.RibbonButton()
        Me.Tesoreriamenu_Conciliación = New System.Windows.Forms.RibbonButton()
        Me.Conciliacion1 = New System.Windows.Forms.RibbonButton()
        Me.Conciliacion2 = New System.Windows.Forms.RibbonButton()
        Me.ConciliacionMFyV = New System.Windows.Forms.RibbonButton()
        Me.Tesoreriamenu_CuentaBancaria = New System.Windows.Forms.RibbonButton()
        Me.CuentaBancaria_menu = New System.Windows.Forms.RibbonButton()
        Me.Tesoreria_Cheques_menu = New System.Windows.Forms.RibbonButton()
        Me.Tesoreriamenu_Reportes2 = New System.Windows.Forms.RibbonButton()
        Me.Conciliacion_reporte = New System.Windows.Forms.RibbonButton()
        Me.ReportesDiarios_reporte = New System.Windows.Forms.RibbonButton()
        Me.Otros_reportes = New System.Windows.Forms.RibbonButton()
        Me.Contabilidadmenu = New System.Windows.Forms.RibbonTab()
        Me.Panel_Contabilidad = New System.Windows.Forms.RibbonPanel()
        Me.Contabilidadmenu_Expedientes = New System.Windows.Forms.RibbonButton()
        Me.Contabilidadmenu_Ordenpago = New System.Windows.Forms.RibbonButton()
        Me.RibbonButton4 = New System.Windows.Forms.RibbonButton()
        Me.SuministrosMenu = New System.Windows.Forms.RibbonTab()
        Me.Suministros_panel = New System.Windows.Forms.RibbonPanel()
        Me.Suministros_Expedientes_button = New System.Windows.Forms.RibbonButton()
        Me.Suministros_Ordenprovision_button = New System.Windows.Forms.RibbonButton()
        Me.Mesaentradasmenu = New System.Windows.Forms.RibbonTab()
        Me.Panel_mesadeentradas = New System.Windows.Forms.RibbonPanel()
        Me.Mesaentradasmenu_Expedientes = New System.Windows.Forms.RibbonButton()
        Me.DireccionMenu = New System.Windows.Forms.RibbonTab()
        Me.Direccion_panel = New System.Windows.Forms.RibbonPanel()
        Me.Direccion_menu_boton = New System.Windows.Forms.RibbonButton()
        Me.RibbonPanel1 = New System.Windows.Forms.RibbonPanel()
        Me.RibbonButton8 = New System.Windows.Forms.RibbonButton()
        Me.Usuariomenu = New System.Windows.Forms.RibbonTab()
        Me.Panel_usuario = New System.Windows.Forms.RibbonPanel()
        Me.Usuariomenu_Usuario = New System.Windows.Forms.RibbonButton()
        Me.Informaticamenu = New System.Windows.Forms.RibbonTab()
        Me.Informaticapanel1 = New System.Windows.Forms.RibbonPanel()
        Me.EstadoServidores_Menu = New System.Windows.Forms.RibbonButton()
        Me.RibbonPanel2 = New System.Windows.Forms.RibbonPanel()
        Me.Tesoreriamenu_Reportes = New System.Windows.Forms.RibbonButton()
        Me.Tesoreriamenu_Experimental = New System.Windows.Forms.RibbonButton()
        Me.Tesoreriamenu_Conciliacion = New System.Windows.Forms.RibbonButton()
        Me.RibbonButton2 = New System.Windows.Forms.RibbonButton()
        Me.RibbonButton3 = New System.Windows.Forms.RibbonButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_menu = New System.Windows.Forms.Timer(Me.components)
        Me.Suministros_expedientes_boton = New System.Windows.Forms.RibbonButton()
        Me.Suministros_ordenprovision_boton = New System.Windows.Forms.RibbonButton()
        Me.Reportesdireccion_button = New System.Windows.Forms.RibbonButton()
        Me.RibbonButton5 = New System.Windows.Forms.RibbonButton()
        Me.RibbonButton6 = New System.Windows.Forms.RibbonButton()
        Me.Contabilidadmenu_Ordencargo = New System.Windows.Forms.RibbonButton()
        Me.NotifyIconSICyF = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.StatusSiciyf.SuspendLayout()
        Me.SuspendLayout()
        '
        'MessageTooltip
        '
        Me.MessageTooltip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'ToolStripgeneral
        '
        Me.ToolStripgeneral.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStripgeneral.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.ToolStripgeneral.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripgeneral.Name = "ToolStripgeneral"
        Me.ToolStripgeneral.Size = New System.Drawing.Size(810, 0)
        Me.ToolStripgeneral.TabIndex = 2
        Me.ToolStripgeneral.Text = "tips"
        '
        'Menuboton_cheques
        '
        Me.Menuboton_cheques.ImageLarge = CType(resources.GetObject("Menuboton_cheques.ImageLarge"), System.Drawing.Image)
        Me.Menuboton_cheques.KeyTip = "4"
        Me.Menuboton_cheques.TextLine1 = "Cheques"
        Me.Menuboton_cheques.Visible = False
        '
        'KryptonManager1
        '
        Me.KryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Black
        Me.KryptonManager1.GlobalStrings.Abort = "Abortar"
        Me.KryptonManager1.GlobalStrings.Cancel = "Cancelar"
        Me.KryptonManager1.GlobalStrings.Close = "Cerrar"
        Me.KryptonManager1.GlobalStrings.Ignore = "Ignorar"
        Me.KryptonManager1.GlobalStrings.Retry = "Reintentar"
        Me.KryptonManager1.GlobalStrings.Today = "Hoy"
        Me.KryptonManager1.GlobalStrings.Yes = "Si"
        '
        'StatusSiciyf
        '
        Me.StatusSiciyf.AutoSize = False
        Me.StatusSiciyf.BackColor = System.Drawing.Color.White
        Me.StatusSiciyf.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.StatusSiciyf.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Servidor1toolstrip_label, Me.Servidor2toolstrip_label, Me.Serveractivotoolstrip, Me.Usuariotoolstrip_label, Me.Direcciontoolstrip_label, Me.ToolStripDebug, Me.Resultadotoolstrip_label, Me.Label_EJERCICIOFINANCIERO, Me.ToolStripSplitButton1})
        Me.StatusSiciyf.Location = New System.Drawing.Point(0, 508)
        Me.StatusSiciyf.Name = "StatusSiciyf"
        Me.StatusSiciyf.Size = New System.Drawing.Size(810, 22)
        Me.StatusSiciyf.TabIndex = 4
        '
        'Servidor1toolstrip_label
        '
        Me.Servidor1toolstrip_label.Name = "Servidor1toolstrip_label"
        Me.Servidor1toolstrip_label.Size = New System.Drawing.Size(19, 17)
        Me.Servidor1toolstrip_label.Text = "S1"
        '
        'Servidor2toolstrip_label
        '
        Me.Servidor2toolstrip_label.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.Servidor2toolstrip_label.Name = "Servidor2toolstrip_label"
        Me.Servidor2toolstrip_label.Size = New System.Drawing.Size(19, 17)
        Me.Servidor2toolstrip_label.Text = "S2"
        '
        'Serveractivotoolstrip
        '
        Me.Serveractivotoolstrip.Name = "Serveractivotoolstrip"
        Me.Serveractivotoolstrip.Size = New System.Drawing.Size(0, 17)
        '
        'Usuariotoolstrip_label
        '
        Me.Usuariotoolstrip_label.Name = "Usuariotoolstrip_label"
        Me.Usuariotoolstrip_label.Size = New System.Drawing.Size(0, 17)
        '
        'Direcciontoolstrip_label
        '
        Me.Direcciontoolstrip_label.Name = "Direcciontoolstrip_label"
        Me.Direcciontoolstrip_label.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripDebug
        '
        Me.ToolStripDebug.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripDebug.ForeColor = System.Drawing.Color.DarkGray
        Me.ToolStripDebug.Name = "ToolStripDebug"
        Me.ToolStripDebug.Size = New System.Drawing.Size(14, 17)
        Me.ToolStripDebug.Text = ":)"
        Me.ToolStripDebug.Visible = False
        '
        'Resultadotoolstrip_label
        '
        Me.Resultadotoolstrip_label.BackColor = System.Drawing.Color.Transparent
        Me.Resultadotoolstrip_label.ForeColor = System.Drawing.Color.DarkGray
        Me.Resultadotoolstrip_label.Name = "Resultadotoolstrip_label"
        Me.Resultadotoolstrip_label.Size = New System.Drawing.Size(14, 17)
        Me.Resultadotoolstrip_label.Text = ":)"
        Me.Resultadotoolstrip_label.Visible = False
        '
        'Label_EJERCICIOFINANCIERO
        '
        Me.Label_EJERCICIOFINANCIERO.BackColor = System.Drawing.Color.White
        Me.Label_EJERCICIOFINANCIERO.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_EJERCICIOFINANCIERO.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label_EJERCICIOFINANCIERO.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.Label_EJERCICIOFINANCIERO.Name = "Label_EJERCICIOFINANCIERO"
        Me.Label_EJERCICIOFINANCIERO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label_EJERCICIOFINANCIERO.Size = New System.Drawing.Size(725, 17)
        Me.Label_EJERCICIOFINANCIERO.Spring = True
        Me.Label_EJERCICIOFINANCIERO.Text = "         "
        Me.Label_EJERCICIOFINANCIERO.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton1.Image = CType(resources.GetObject("ToolStripSplitButton1.Image"), System.Drawing.Image)
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(32, 20)
        Me.ToolStripSplitButton1.Text = "Buscar Actualizacion"
        '
        'RibbonMenu
        '
        Me.RibbonMenu.BackColor = System.Drawing.Color.White
        Me.RibbonMenu.CaptionBarVisible = False
        Me.RibbonMenu.Cursor = System.Windows.Forms.Cursors.Default
        Me.RibbonMenu.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RibbonMenu.HideSingleTabIfTextEmpty = False
        Me.RibbonMenu.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.RibbonMenu.Location = New System.Drawing.Point(0, 0)
        Me.RibbonMenu.Margin = New System.Windows.Forms.Padding(0)
        Me.RibbonMenu.Minimized = False
        Me.RibbonMenu.Name = "RibbonMenu"
        '
        '
        '
        Me.RibbonMenu.OrbDropDown.BackgroundImage = CType(resources.GetObject("RibbonMenu.OrbDropDown.BackgroundImage"), System.Drawing.Image)
        Me.RibbonMenu.OrbDropDown.BorderRoundness = 8
        Me.RibbonMenu.OrbDropDown.Location = New System.Drawing.Point(0, 0)
        Me.RibbonMenu.OrbDropDown.Name = ""
        Me.RibbonMenu.OrbDropDown.OptionItems.Add(Me.RibbonColorChooser1)
        Me.RibbonMenu.OrbDropDown.OptionItemsPadding = 2
        Me.RibbonMenu.OrbDropDown.Size = New System.Drawing.Size(527, 447)
        Me.RibbonMenu.OrbDropDown.TabIndex = 0
        Me.RibbonMenu.OrbDropDown.Visible = False
        Me.RibbonMenu.OrbText = "SICyF"
        Me.RibbonMenu.PanelCaptionHeight = 1
        '
        '
        '
        Me.RibbonMenu.QuickAccessToolbar.Checked = True
        Me.RibbonMenu.QuickAccessToolbar.Enabled = False
        Me.RibbonMenu.QuickAccessToolbar.Items.Add(Me.RibbonButton1)
        Me.RibbonMenu.QuickAccessToolbar.Items.Add(Me.RibbonButton7)
        Me.RibbonMenu.QuickAccessToolbar.Items.Add(Me.RibbonButton9)
        Me.RibbonMenu.QuickAccessToolbar.Items.Add(Me.RibbonButton10)
        Me.RibbonMenu.QuickAccessToolbar.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.DropDown
        Me.RibbonMenu.QuickAccessToolbar.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Right
        Me.RibbonMenu.RibbonTabFont = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RibbonMenu.Size = New System.Drawing.Size(810, 108)
        Me.RibbonMenu.TabIndex = 1
        Me.RibbonMenu.Tabs.Add(Me.Tesoreriamenu)
        Me.RibbonMenu.Tabs.Add(Me.Contabilidadmenu)
        Me.RibbonMenu.Tabs.Add(Me.SuministrosMenu)
        Me.RibbonMenu.Tabs.Add(Me.Mesaentradasmenu)
        Me.RibbonMenu.Tabs.Add(Me.DireccionMenu)
        Me.RibbonMenu.Tabs.Add(Me.Usuariomenu)
        Me.RibbonMenu.Tabs.Add(Me.Informaticamenu)
        Me.RibbonMenu.TabsMargin = New System.Windows.Forms.Padding(12, 2, 20, 0)
        Me.RibbonMenu.Text = "SICIyF Menu"
        '
        'RibbonColorChooser1
        '
        Me.RibbonColorChooser1.Color = System.Drawing.Color.Transparent
        Me.RibbonColorChooser1.Image = CType(resources.GetObject("RibbonColorChooser1.Image"), System.Drawing.Image)
        Me.RibbonColorChooser1.LargeImage = CType(resources.GetObject("RibbonColorChooser1.LargeImage"), System.Drawing.Image)
        Me.RibbonColorChooser1.Name = "RibbonColorChooser1"
        Me.RibbonColorChooser1.SmallImage = CType(resources.GetObject("RibbonColorChooser1.SmallImage"), System.Drawing.Image)
        '
        'RibbonButton1
        '
        Me.RibbonButton1.Enabled = False
        Me.RibbonButton1.Image = CType(resources.GetObject("RibbonButton1.Image"), System.Drawing.Image)
        Me.RibbonButton1.LargeImage = CType(resources.GetObject("RibbonButton1.LargeImage"), System.Drawing.Image)
        Me.RibbonButton1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact
        Me.RibbonButton1.Name = "RibbonButton1"
        Me.RibbonButton1.SmallImage = CType(resources.GetObject("RibbonButton1.SmallImage"), System.Drawing.Image)
        Me.RibbonButton1.Text = "RibbonButton1"
        '
        'RibbonButton7
        '
        Me.RibbonButton7.Enabled = False
        Me.RibbonButton7.Image = CType(resources.GetObject("RibbonButton7.Image"), System.Drawing.Image)
        Me.RibbonButton7.LargeImage = CType(resources.GetObject("RibbonButton7.LargeImage"), System.Drawing.Image)
        Me.RibbonButton7.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact
        Me.RibbonButton7.Name = "RibbonButton7"
        Me.RibbonButton7.SmallImage = CType(resources.GetObject("RibbonButton7.SmallImage"), System.Drawing.Image)
        Me.RibbonButton7.Text = "RibbonButton7"
        '
        'RibbonButton9
        '
        Me.RibbonButton9.Enabled = False
        Me.RibbonButton9.Image = CType(resources.GetObject("RibbonButton9.Image"), System.Drawing.Image)
        Me.RibbonButton9.LargeImage = CType(resources.GetObject("RibbonButton9.LargeImage"), System.Drawing.Image)
        Me.RibbonButton9.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact
        Me.RibbonButton9.Name = "RibbonButton9"
        Me.RibbonButton9.SmallImage = CType(resources.GetObject("RibbonButton9.SmallImage"), System.Drawing.Image)
        Me.RibbonButton9.Text = "RibbonButton9"
        '
        'RibbonButton10
        '
        Me.RibbonButton10.Enabled = False
        Me.RibbonButton10.Image = CType(resources.GetObject("RibbonButton10.Image"), System.Drawing.Image)
        Me.RibbonButton10.LargeImage = CType(resources.GetObject("RibbonButton10.LargeImage"), System.Drawing.Image)
        Me.RibbonButton10.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact
        Me.RibbonButton10.Name = "RibbonButton10"
        Me.RibbonButton10.SmallImage = CType(resources.GetObject("RibbonButton10.SmallImage"), System.Drawing.Image)
        Me.RibbonButton10.Text = "RibbonButton10"
        '
        'Tesoreriamenu
        '
        Me.Tesoreriamenu.Name = "Tesoreriamenu"
        Me.Tesoreriamenu.Panels.Add(Me.PanelTesoreria)
        Me.Tesoreriamenu.Text = "Tesoreria"
        Me.Tesoreriamenu.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'PanelTesoreria
        '
        Me.PanelTesoreria.ButtonMoreEnabled = False
        Me.PanelTesoreria.ButtonMoreVisible = False
        Me.PanelTesoreria.Items.Add(Me.Tesoreriamenu_Expedientes)
        Me.PanelTesoreria.Items.Add(Me.Tesoreriamenu_PedidodeFondos)
        Me.PanelTesoreria.Items.Add(Me.Tesoreriamenu_Movimientos)
        Me.PanelTesoreria.Items.Add(Me.Tesoreriamenu_Liquidaciones)
        Me.PanelTesoreria.Items.Add(Me.Tesoreriamenu_Conciliación)
        Me.PanelTesoreria.Items.Add(Me.Tesoreriamenu_CuentaBancaria)
        Me.PanelTesoreria.Items.Add(Me.Tesoreriamenu_Reportes2)
        Me.PanelTesoreria.Name = "PanelTesoreria"
        Me.PanelTesoreria.Text = Nothing
        '
        'Tesoreriamenu_Expedientes
        '
        Me.Tesoreriamenu_Expedientes.Image = CType(resources.GetObject("Tesoreriamenu_Expedientes.Image"), System.Drawing.Image)
        Me.Tesoreriamenu_Expedientes.LargeImage = CType(resources.GetObject("Tesoreriamenu_Expedientes.LargeImage"), System.Drawing.Image)
        Me.Tesoreriamenu_Expedientes.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.Tesoreriamenu_Expedientes.Name = "Tesoreriamenu_Expedientes"
        Me.Tesoreriamenu_Expedientes.SmallImage = CType(resources.GetObject("Tesoreriamenu_Expedientes.SmallImage"), System.Drawing.Image)
        Me.Tesoreriamenu_Expedientes.Text = "Expedientes"
        '
        'Tesoreriamenu_PedidodeFondos
        '
        Me.Tesoreriamenu_PedidodeFondos.Image = CType(resources.GetObject("Tesoreriamenu_PedidodeFondos.Image"), System.Drawing.Image)
        Me.Tesoreriamenu_PedidodeFondos.LargeImage = CType(resources.GetObject("Tesoreriamenu_PedidodeFondos.LargeImage"), System.Drawing.Image)
        Me.Tesoreriamenu_PedidodeFondos.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.Tesoreriamenu_PedidodeFondos.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.Tesoreriamenu_PedidodeFondos.Name = "Tesoreriamenu_PedidodeFondos"
        Me.Tesoreriamenu_PedidodeFondos.SmallImage = CType(resources.GetObject("Tesoreriamenu_PedidodeFondos.SmallImage"), System.Drawing.Image)
        Me.Tesoreriamenu_PedidodeFondos.Text = "Ped. de Fondos  "
        Me.Tesoreriamenu_PedidodeFondos.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Right
        '
        'Tesoreriamenu_Movimientos
        '
        Me.Tesoreriamenu_Movimientos.Image = CType(resources.GetObject("Tesoreriamenu_Movimientos.Image"), System.Drawing.Image)
        Me.Tesoreriamenu_Movimientos.LargeImage = CType(resources.GetObject("Tesoreriamenu_Movimientos.LargeImage"), System.Drawing.Image)
        Me.Tesoreriamenu_Movimientos.Name = "Tesoreriamenu_Movimientos"
        Me.Tesoreriamenu_Movimientos.SmallImage = CType(resources.GetObject("Tesoreriamenu_Movimientos.SmallImage"), System.Drawing.Image)
        Me.Tesoreriamenu_Movimientos.Text = "Movimientos"
        '
        'Tesoreriamenu_Liquidaciones
        '
        Me.Tesoreriamenu_Liquidaciones.DropDownItems.Add(Me.Recibos_retenciones)
        Me.Tesoreriamenu_Liquidaciones.DropDownItems.Add(Me.Retencionescheque)
        Me.Tesoreriamenu_Liquidaciones.Image = CType(resources.GetObject("Tesoreriamenu_Liquidaciones.Image"), System.Drawing.Image)
        Me.Tesoreriamenu_Liquidaciones.LargeImage = CType(resources.GetObject("Tesoreriamenu_Liquidaciones.LargeImage"), System.Drawing.Image)
        Me.Tesoreriamenu_Liquidaciones.Name = "Tesoreriamenu_Liquidaciones"
        Me.Tesoreriamenu_Liquidaciones.SmallImage = CType(resources.GetObject("Tesoreriamenu_Liquidaciones.SmallImage"), System.Drawing.Image)
        Me.Tesoreriamenu_Liquidaciones.Style = System.Windows.Forms.RibbonButtonStyle.DropDown
        Me.Tesoreriamenu_Liquidaciones.Text = "Retenciones"
        '
        'Recibos_retenciones
        '
        Me.Recibos_retenciones.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.Recibos_retenciones.Image = CType(resources.GetObject("Recibos_retenciones.Image"), System.Drawing.Image)
        Me.Recibos_retenciones.LargeImage = CType(resources.GetObject("Recibos_retenciones.LargeImage"), System.Drawing.Image)
        Me.Recibos_retenciones.Name = "Recibos_retenciones"
        Me.Recibos_retenciones.SmallImage = CType(resources.GetObject("Recibos_retenciones.SmallImage"), System.Drawing.Image)
        Me.Recibos_retenciones.Text = "RECIBOS"
        '
        'Retencionescheque
        '
        Me.Retencionescheque.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.Retencionescheque.Image = CType(resources.GetObject("Retencionescheque.Image"), System.Drawing.Image)
        Me.Retencionescheque.LargeImage = CType(resources.GetObject("Retencionescheque.LargeImage"), System.Drawing.Image)
        Me.Retencionescheque.Name = "Retencionescheque"
        Me.Retencionescheque.SmallImage = CType(resources.GetObject("Retencionescheque.SmallImage"), System.Drawing.Image)
        Me.Retencionescheque.Text = "RETENCIONES CHEQUE"
        '
        'Tesoreriamenu_Conciliación
        '
        Me.Tesoreriamenu_Conciliación.DropDownItems.Add(Me.Conciliacion1)
        Me.Tesoreriamenu_Conciliación.DropDownItems.Add(Me.Conciliacion2)
        Me.Tesoreriamenu_Conciliación.DropDownItems.Add(Me.ConciliacionMFyV)
        Me.Tesoreriamenu_Conciliación.Image = CType(resources.GetObject("Tesoreriamenu_Conciliación.Image"), System.Drawing.Image)
        Me.Tesoreriamenu_Conciliación.LargeImage = CType(resources.GetObject("Tesoreriamenu_Conciliación.LargeImage"), System.Drawing.Image)
        Me.Tesoreriamenu_Conciliación.Name = "Tesoreriamenu_Conciliación"
        Me.Tesoreriamenu_Conciliación.SmallImage = CType(resources.GetObject("Tesoreriamenu_Conciliación.SmallImage"), System.Drawing.Image)
        Me.Tesoreriamenu_Conciliación.Style = System.Windows.Forms.RibbonButtonStyle.SplitDropDown
        Me.Tesoreriamenu_Conciliación.Text = "Conciliación"
        '
        'Conciliacion1
        '
        Me.Conciliacion1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.Conciliacion1.Image = CType(resources.GetObject("Conciliacion1.Image"), System.Drawing.Image)
        Me.Conciliacion1.LargeImage = CType(resources.GetObject("Conciliacion1.LargeImage"), System.Drawing.Image)
        Me.Conciliacion1.Name = "Conciliacion1"
        Me.Conciliacion1.SmallImage = CType(resources.GetObject("Conciliacion1.SmallImage"), System.Drawing.Image)
        Me.Conciliacion1.Text = "Conciliación Básica"
        '
        'Conciliacion2
        '
        Me.Conciliacion2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.Conciliacion2.Image = CType(resources.GetObject("Conciliacion2.Image"), System.Drawing.Image)
        Me.Conciliacion2.LargeImage = CType(resources.GetObject("Conciliacion2.LargeImage"), System.Drawing.Image)
        Me.Conciliacion2.Name = "Conciliacion2"
        Me.Conciliacion2.SmallImage = CType(resources.GetObject("Conciliacion2.SmallImage"), System.Drawing.Image)
        Me.Conciliacion2.Text = "Conciliación Detallada"
        '
        'ConciliacionMFyV
        '
        Me.ConciliacionMFyV.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.ConciliacionMFyV.Image = CType(resources.GetObject("ConciliacionMFyV.Image"), System.Drawing.Image)
        Me.ConciliacionMFyV.LargeImage = CType(resources.GetObject("ConciliacionMFyV.LargeImage"), System.Drawing.Image)
        Me.ConciliacionMFyV.Name = "ConciliacionMFyV"
        Me.ConciliacionMFyV.SmallImage = CType(resources.GetObject("ConciliacionMFyV.SmallImage"), System.Drawing.Image)
        Me.ConciliacionMFyV.Text = "Listado MFyV"
        '
        'Tesoreriamenu_CuentaBancaria
        '
        Me.Tesoreriamenu_CuentaBancaria.DropDownItems.Add(Me.CuentaBancaria_menu)
        Me.Tesoreriamenu_CuentaBancaria.DropDownItems.Add(Me.Tesoreria_Cheques_menu)
        Me.Tesoreriamenu_CuentaBancaria.Image = CType(resources.GetObject("Tesoreriamenu_CuentaBancaria.Image"), System.Drawing.Image)
        Me.Tesoreriamenu_CuentaBancaria.LargeImage = CType(resources.GetObject("Tesoreriamenu_CuentaBancaria.LargeImage"), System.Drawing.Image)
        Me.Tesoreriamenu_CuentaBancaria.Name = "Tesoreriamenu_CuentaBancaria"
        Me.Tesoreriamenu_CuentaBancaria.SmallImage = CType(resources.GetObject("Tesoreriamenu_CuentaBancaria.SmallImage"), System.Drawing.Image)
        Me.Tesoreriamenu_CuentaBancaria.Style = System.Windows.Forms.RibbonButtonStyle.DropDown
        Me.Tesoreriamenu_CuentaBancaria.Text = "Cuenta Bancaria"
        '
        'CuentaBancaria_menu
        '
        Me.CuentaBancaria_menu.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.CuentaBancaria_menu.Image = CType(resources.GetObject("CuentaBancaria_menu.Image"), System.Drawing.Image)
        Me.CuentaBancaria_menu.LargeImage = CType(resources.GetObject("CuentaBancaria_menu.LargeImage"), System.Drawing.Image)
        Me.CuentaBancaria_menu.Name = "CuentaBancaria_menu"
        Me.CuentaBancaria_menu.SmallImage = CType(resources.GetObject("CuentaBancaria_menu.SmallImage"), System.Drawing.Image)
        Me.CuentaBancaria_menu.Text = "Cuentas Bancarias"
        '
        'Tesoreria_Cheques_menu
        '
        Me.Tesoreria_Cheques_menu.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.Tesoreria_Cheques_menu.Image = CType(resources.GetObject("Tesoreria_Cheques_menu.Image"), System.Drawing.Image)
        Me.Tesoreria_Cheques_menu.LargeImage = CType(resources.GetObject("Tesoreria_Cheques_menu.LargeImage"), System.Drawing.Image)
        Me.Tesoreria_Cheques_menu.Name = "Tesoreria_Cheques_menu"
        Me.Tesoreria_Cheques_menu.SmallImage = CType(resources.GetObject("Tesoreria_Cheques_menu.SmallImage"), System.Drawing.Image)
        Me.Tesoreria_Cheques_menu.Text = "Chequeras"
        '
        'Tesoreriamenu_Reportes2
        '
        Me.Tesoreriamenu_Reportes2.DropDownItems.Add(Me.Conciliacion_reporte)
        Me.Tesoreriamenu_Reportes2.DropDownItems.Add(Me.ReportesDiarios_reporte)
        Me.Tesoreriamenu_Reportes2.DropDownItems.Add(Me.Otros_reportes)
        Me.Tesoreriamenu_Reportes2.DropDownResizable = True
        Me.Tesoreriamenu_Reportes2.Image = CType(resources.GetObject("Tesoreriamenu_Reportes2.Image"), System.Drawing.Image)
        Me.Tesoreriamenu_Reportes2.LargeImage = CType(resources.GetObject("Tesoreriamenu_Reportes2.LargeImage"), System.Drawing.Image)
        Me.Tesoreriamenu_Reportes2.Name = "Tesoreriamenu_Reportes2"
        Me.Tesoreriamenu_Reportes2.SmallImage = CType(resources.GetObject("Tesoreriamenu_Reportes2.SmallImage"), System.Drawing.Image)
        Me.Tesoreriamenu_Reportes2.Style = System.Windows.Forms.RibbonButtonStyle.DropDown
        Me.Tesoreriamenu_Reportes2.Text = "Reportes"
        '
        'Conciliacion_reporte
        '
        Me.Conciliacion_reporte.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.Conciliacion_reporte.Image = CType(resources.GetObject("Conciliacion_reporte.Image"), System.Drawing.Image)
        Me.Conciliacion_reporte.LargeImage = CType(resources.GetObject("Conciliacion_reporte.LargeImage"), System.Drawing.Image)
        Me.Conciliacion_reporte.Name = "Conciliacion_reporte"
        Me.Conciliacion_reporte.SmallImage = CType(resources.GetObject("Conciliacion_reporte.SmallImage"), System.Drawing.Image)
        Me.Conciliacion_reporte.Text = "Conciliación"
        '
        'ReportesDiarios_reporte
        '
        Me.ReportesDiarios_reporte.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.ReportesDiarios_reporte.Image = CType(resources.GetObject("ReportesDiarios_reporte.Image"), System.Drawing.Image)
        Me.ReportesDiarios_reporte.LargeImage = CType(resources.GetObject("ReportesDiarios_reporte.LargeImage"), System.Drawing.Image)
        Me.ReportesDiarios_reporte.Name = "ReportesDiarios_reporte"
        Me.ReportesDiarios_reporte.SmallImage = CType(resources.GetObject("ReportesDiarios_reporte.SmallImage"), System.Drawing.Image)
        Me.ReportesDiarios_reporte.Text = "Reportes Diarios"
        '
        'Otros_reportes
        '
        Me.Otros_reportes.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.Otros_reportes.Image = CType(resources.GetObject("Otros_reportes.Image"), System.Drawing.Image)
        Me.Otros_reportes.LargeImage = CType(resources.GetObject("Otros_reportes.LargeImage"), System.Drawing.Image)
        Me.Otros_reportes.Name = "Otros_reportes"
        Me.Otros_reportes.SmallImage = CType(resources.GetObject("Otros_reportes.SmallImage"), System.Drawing.Image)
        Me.Otros_reportes.Text = "Otros Reportes"
        '
        'Contabilidadmenu
        '
        Me.Contabilidadmenu.Name = "Contabilidadmenu"
        Me.Contabilidadmenu.Panels.Add(Me.Panel_Contabilidad)
        Me.Contabilidadmenu.Text = "Contabilidad"
        '
        'Panel_Contabilidad
        '
        Me.Panel_Contabilidad.ButtonMoreEnabled = False
        Me.Panel_Contabilidad.Items.Add(Me.Contabilidadmenu_Expedientes)
        Me.Panel_Contabilidad.Items.Add(Me.Contabilidadmenu_Ordenpago)
        Me.Panel_Contabilidad.Name = "Panel_Contabilidad"
        Me.Panel_Contabilidad.Text = " "
        '
        'Contabilidadmenu_Expedientes
        '
        Me.Contabilidadmenu_Expedientes.Image = CType(resources.GetObject("Contabilidadmenu_Expedientes.Image"), System.Drawing.Image)
        Me.Contabilidadmenu_Expedientes.LargeImage = CType(resources.GetObject("Contabilidadmenu_Expedientes.LargeImage"), System.Drawing.Image)
        Me.Contabilidadmenu_Expedientes.Name = "Contabilidadmenu_Expedientes"
        Me.Contabilidadmenu_Expedientes.SmallImage = CType(resources.GetObject("Contabilidadmenu_Expedientes.SmallImage"), System.Drawing.Image)
        Me.Contabilidadmenu_Expedientes.Text = "Expedientes"
        '
        'Contabilidadmenu_Ordenpago
        '
        Me.Contabilidadmenu_Ordenpago.DropDownItems.Add(Me.RibbonButton4)
        Me.Contabilidadmenu_Ordenpago.Image = CType(resources.GetObject("Contabilidadmenu_Ordenpago.Image"), System.Drawing.Image)
        Me.Contabilidadmenu_Ordenpago.LargeImage = CType(resources.GetObject("Contabilidadmenu_Ordenpago.LargeImage"), System.Drawing.Image)
        Me.Contabilidadmenu_Ordenpago.Name = "Contabilidadmenu_Ordenpago"
        Me.Contabilidadmenu_Ordenpago.SmallImage = CType(resources.GetObject("Contabilidadmenu_Ordenpago.SmallImage"), System.Drawing.Image)
        Me.Contabilidadmenu_Ordenpago.Text = "Ordenes de Pago"
        Me.Contabilidadmenu_Ordenpago.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center
        '
        'RibbonButton4
        '
        Me.RibbonButton4.Image = CType(resources.GetObject("RibbonButton4.Image"), System.Drawing.Image)
        Me.RibbonButton4.LargeImage = CType(resources.GetObject("RibbonButton4.LargeImage"), System.Drawing.Image)
        Me.RibbonButton4.Name = "RibbonButton4"
        Me.RibbonButton4.SmallImage = CType(resources.GetObject("RibbonButton4.SmallImage"), System.Drawing.Image)
        Me.RibbonButton4.Text = "RibbonButton4"
        '
        'SuministrosMenu
        '
        Me.SuministrosMenu.Name = "SuministrosMenu"
        Me.SuministrosMenu.Panels.Add(Me.Suministros_panel)
        Me.SuministrosMenu.Text = "Suministros"
        '
        'Suministros_panel
        '
        Me.Suministros_panel.Items.Add(Me.Suministros_Expedientes_button)
        Me.Suministros_panel.Items.Add(Me.Suministros_Ordenprovision_button)
        Me.Suministros_panel.Name = "Suministros_panel"
        Me.Suministros_panel.Text = ""
        '
        'Suministros_Expedientes_button
        '
        Me.Suministros_Expedientes_button.Image = CType(resources.GetObject("Suministros_Expedientes_button.Image"), System.Drawing.Image)
        Me.Suministros_Expedientes_button.LargeImage = CType(resources.GetObject("Suministros_Expedientes_button.LargeImage"), System.Drawing.Image)
        Me.Suministros_Expedientes_button.Name = "Suministros_Expedientes_button"
        Me.Suministros_Expedientes_button.SmallImage = CType(resources.GetObject("Suministros_Expedientes_button.SmallImage"), System.Drawing.Image)
        Me.Suministros_Expedientes_button.Text = "Expedientes"
        '
        'Suministros_Ordenprovision_button
        '
        Me.Suministros_Ordenprovision_button.Image = CType(resources.GetObject("Suministros_Ordenprovision_button.Image"), System.Drawing.Image)
        Me.Suministros_Ordenprovision_button.LargeImage = CType(resources.GetObject("Suministros_Ordenprovision_button.LargeImage"), System.Drawing.Image)
        Me.Suministros_Ordenprovision_button.Name = "Suministros_Ordenprovision_button"
        Me.Suministros_Ordenprovision_button.SmallImage = CType(resources.GetObject("Suministros_Ordenprovision_button.SmallImage"), System.Drawing.Image)
        Me.Suministros_Ordenprovision_button.Text = "Orden Provision"
        Me.Suministros_Ordenprovision_button.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Right
        '
        'Mesaentradasmenu
        '
        Me.Mesaentradasmenu.Name = "Mesaentradasmenu"
        Me.Mesaentradasmenu.Panels.Add(Me.Panel_mesadeentradas)
        Me.Mesaentradasmenu.Text = "Mesa de Entradas"
        '
        'Panel_mesadeentradas
        '
        Me.Panel_mesadeentradas.Items.Add(Me.Mesaentradasmenu_Expedientes)
        Me.Panel_mesadeentradas.Name = "Panel_mesadeentradas"
        Me.Panel_mesadeentradas.Text = " "
        '
        'Mesaentradasmenu_Expedientes
        '
        Me.Mesaentradasmenu_Expedientes.Image = CType(resources.GetObject("Mesaentradasmenu_Expedientes.Image"), System.Drawing.Image)
        Me.Mesaentradasmenu_Expedientes.LargeImage = CType(resources.GetObject("Mesaentradasmenu_Expedientes.LargeImage"), System.Drawing.Image)
        Me.Mesaentradasmenu_Expedientes.Name = "Mesaentradasmenu_Expedientes"
        Me.Mesaentradasmenu_Expedientes.SmallImage = CType(resources.GetObject("Mesaentradasmenu_Expedientes.SmallImage"), System.Drawing.Image)
        Me.Mesaentradasmenu_Expedientes.Text = "Expedientes"
        '
        'DireccionMenu
        '
        Me.DireccionMenu.Name = "DireccionMenu"
        Me.DireccionMenu.Panels.Add(Me.Direccion_panel)
        Me.DireccionMenu.Panels.Add(Me.RibbonPanel1)
        Me.DireccionMenu.Text = "Dirección"
        '
        'Direccion_panel
        '
        Me.Direccion_panel.Items.Add(Me.Direccion_menu_boton)
        Me.Direccion_panel.Name = "Direccion_panel"
        Me.Direccion_panel.Text = ""
        '
        'Direccion_menu_boton
        '
        Me.Direccion_menu_boton.Image = CType(resources.GetObject("Direccion_menu_boton.Image"), System.Drawing.Image)
        Me.Direccion_menu_boton.LargeImage = CType(resources.GetObject("Direccion_menu_boton.LargeImage"), System.Drawing.Image)
        Me.Direccion_menu_boton.Name = "Direccion_menu_boton"
        Me.Direccion_menu_boton.SmallImage = CType(resources.GetObject("Direccion_menu_boton.SmallImage"), System.Drawing.Image)
        Me.Direccion_menu_boton.Text = "Reportes"
        '
        'RibbonPanel1
        '
        Me.RibbonPanel1.Items.Add(Me.RibbonButton8)
        Me.RibbonPanel1.Name = "RibbonPanel1"
        Me.RibbonPanel1.Text = "RibbonPanel1"
        '
        'RibbonButton8
        '
        Me.RibbonButton8.Image = Global.SICyF.My.Resources.Resources.cross
        Me.RibbonButton8.LargeImage = Global.SICyF.My.Resources.Resources.cross
        Me.RibbonButton8.Name = "RibbonButton8"
        Me.RibbonButton8.SmallImage = Global.SICyF.My.Resources.Resources.cross
        '
        'Usuariomenu
        '
        Me.Usuariomenu.Name = "Usuariomenu"
        Me.Usuariomenu.Panels.Add(Me.Panel_usuario)
        Me.Usuariomenu.Text = "Usuario"
        '
        'Panel_usuario
        '
        Me.Panel_usuario.Items.Add(Me.Usuariomenu_Usuario)
        Me.Panel_usuario.Name = "Panel_usuario"
        Me.Panel_usuario.Text = " "
        '
        'Usuariomenu_Usuario
        '
        Me.Usuariomenu_Usuario.Image = CType(resources.GetObject("Usuariomenu_Usuario.Image"), System.Drawing.Image)
        Me.Usuariomenu_Usuario.LargeImage = CType(resources.GetObject("Usuariomenu_Usuario.LargeImage"), System.Drawing.Image)
        Me.Usuariomenu_Usuario.Name = "Usuariomenu_Usuario"
        Me.Usuariomenu_Usuario.SmallImage = CType(resources.GetObject("Usuariomenu_Usuario.SmallImage"), System.Drawing.Image)
        Me.Usuariomenu_Usuario.Text = "Usuario"
        '
        'Informaticamenu
        '
        Me.Informaticamenu.Name = "Informaticamenu"
        Me.Informaticamenu.Panels.Add(Me.Informaticapanel1)
        Me.Informaticamenu.Panels.Add(Me.RibbonPanel2)
        Me.Informaticamenu.Text = "Control Informatico"
        Me.Informaticamenu.Visible = False
        '
        'Informaticapanel1
        '
        Me.Informaticapanel1.Items.Add(Me.EstadoServidores_Menu)
        Me.Informaticapanel1.Name = "Informaticapanel1"
        Me.Informaticapanel1.Text = " "
        '
        'EstadoServidores_Menu
        '
        Me.EstadoServidores_Menu.Image = CType(resources.GetObject("EstadoServidores_Menu.Image"), System.Drawing.Image)
        Me.EstadoServidores_Menu.LargeImage = CType(resources.GetObject("EstadoServidores_Menu.LargeImage"), System.Drawing.Image)
        Me.EstadoServidores_Menu.Name = "EstadoServidores_Menu"
        Me.EstadoServidores_Menu.SmallImage = CType(resources.GetObject("EstadoServidores_Menu.SmallImage"), System.Drawing.Image)
        Me.EstadoServidores_Menu.Text = "Servidores"
        '
        'RibbonPanel2
        '
        Me.RibbonPanel2.Name = "RibbonPanel2"
        Me.RibbonPanel2.Text = "RibbonPanel2"
        '
        'Tesoreriamenu_Reportes
        '
        Me.Tesoreriamenu_Reportes.Image = CType(resources.GetObject("Tesoreriamenu_Reportes.Image"), System.Drawing.Image)
        Me.Tesoreriamenu_Reportes.LargeImage = CType(resources.GetObject("Tesoreriamenu_Reportes.LargeImage"), System.Drawing.Image)
        Me.Tesoreriamenu_Reportes.Name = "Tesoreriamenu_Reportes"
        Me.Tesoreriamenu_Reportes.SmallImage = CType(resources.GetObject("Tesoreriamenu_Reportes.SmallImage"), System.Drawing.Image)
        Me.Tesoreriamenu_Reportes.Text = "Reportes"
        '
        'Tesoreriamenu_Experimental
        '
        Me.Tesoreriamenu_Experimental.Image = CType(resources.GetObject("Tesoreriamenu_Experimental.Image"), System.Drawing.Image)
        Me.Tesoreriamenu_Experimental.LargeImage = CType(resources.GetObject("Tesoreriamenu_Experimental.LargeImage"), System.Drawing.Image)
        Me.Tesoreriamenu_Experimental.Name = "Tesoreriamenu_Experimental"
        Me.Tesoreriamenu_Experimental.SmallImage = CType(resources.GetObject("Tesoreriamenu_Experimental.SmallImage"), System.Drawing.Image)
        Me.Tesoreriamenu_Experimental.Text = "Experimental"
        '
        'Tesoreriamenu_Conciliacion
        '
        Me.Tesoreriamenu_Conciliacion.Image = CType(resources.GetObject("Tesoreriamenu_Conciliacion.Image"), System.Drawing.Image)
        Me.Tesoreriamenu_Conciliacion.LargeImage = CType(resources.GetObject("Tesoreriamenu_Conciliacion.LargeImage"), System.Drawing.Image)
        Me.Tesoreriamenu_Conciliacion.Name = "Tesoreriamenu_Conciliacion"
        Me.Tesoreriamenu_Conciliacion.SmallImage = CType(resources.GetObject("Tesoreriamenu_Conciliacion.SmallImage"), System.Drawing.Image)
        Me.Tesoreriamenu_Conciliacion.Text = "Conciliación"
        '
        'RibbonButton2
        '
        Me.RibbonButton2.Image = CType(resources.GetObject("RibbonButton2.Image"), System.Drawing.Image)
        Me.RibbonButton2.LargeImage = CType(resources.GetObject("RibbonButton2.LargeImage"), System.Drawing.Image)
        Me.RibbonButton2.Name = "RibbonButton2"
        Me.RibbonButton2.SmallImage = CType(resources.GetObject("RibbonButton2.SmallImage"), System.Drawing.Image)
        Me.RibbonButton2.Text = "Expedientes"
        '
        'RibbonButton3
        '
        Me.RibbonButton3.Image = CType(resources.GetObject("RibbonButton3.Image"), System.Drawing.Image)
        Me.RibbonButton3.LargeImage = CType(resources.GetObject("RibbonButton3.LargeImage"), System.Drawing.Image)
        Me.RibbonButton3.Name = "RibbonButton3"
        Me.RibbonButton3.SmallImage = CType(resources.GetObject("RibbonButton3.SmallImage"), System.Drawing.Image)
        Me.RibbonButton3.Text = "Expedientes"
        '
        'Timer1
        '
        Me.Timer1.Interval = 150
        '
        'Timer_menu
        '
        Me.Timer_menu.Interval = 10800
        '
        'Suministros_expedientes_boton
        '
        Me.Suministros_expedientes_boton.Image = CType(resources.GetObject("Suministros_expedientes_boton.Image"), System.Drawing.Image)
        Me.Suministros_expedientes_boton.LargeImage = CType(resources.GetObject("Suministros_expedientes_boton.LargeImage"), System.Drawing.Image)
        Me.Suministros_expedientes_boton.Name = "Suministros_expedientes_boton"
        Me.Suministros_expedientes_boton.SmallImage = CType(resources.GetObject("Suministros_expedientes_boton.SmallImage"), System.Drawing.Image)
        Me.Suministros_expedientes_boton.Style = System.Windows.Forms.RibbonButtonStyle.SplitDropDown
        Me.Suministros_expedientes_boton.Text = "Expedientes"
        '
        'Suministros_ordenprovision_boton
        '
        Me.Suministros_ordenprovision_boton.Image = CType(resources.GetObject("Suministros_ordenprovision_boton.Image"), System.Drawing.Image)
        Me.Suministros_ordenprovision_boton.LargeImage = CType(resources.GetObject("Suministros_ordenprovision_boton.LargeImage"), System.Drawing.Image)
        Me.Suministros_ordenprovision_boton.Name = "Suministros_ordenprovision_boton"
        Me.Suministros_ordenprovision_boton.SmallImage = CType(resources.GetObject("Suministros_ordenprovision_boton.SmallImage"), System.Drawing.Image)
        '
        'Reportesdireccion_button
        '
        Me.Reportesdireccion_button.Image = CType(resources.GetObject("Reportesdireccion_button.Image"), System.Drawing.Image)
        Me.Reportesdireccion_button.LargeImage = CType(resources.GetObject("Reportesdireccion_button.LargeImage"), System.Drawing.Image)
        Me.Reportesdireccion_button.Name = "Reportesdireccion_button"
        Me.Reportesdireccion_button.SmallImage = CType(resources.GetObject("Reportesdireccion_button.SmallImage"), System.Drawing.Image)
        Me.Reportesdireccion_button.Style = System.Windows.Forms.RibbonButtonStyle.DropDown
        Me.Reportesdireccion_button.Text = "Reportes"
        '
        'RibbonButton5
        '
        Me.RibbonButton5.Image = CType(resources.GetObject("RibbonButton5.Image"), System.Drawing.Image)
        Me.RibbonButton5.LargeImage = CType(resources.GetObject("RibbonButton5.LargeImage"), System.Drawing.Image)
        Me.RibbonButton5.Name = "RibbonButton5"
        Me.RibbonButton5.SmallImage = CType(resources.GetObject("RibbonButton5.SmallImage"), System.Drawing.Image)
        Me.RibbonButton5.Style = System.Windows.Forms.RibbonButtonStyle.DropDown
        Me.RibbonButton5.Text = "Reportes"
        '
        'RibbonButton6
        '
        Me.RibbonButton6.Image = CType(resources.GetObject("RibbonButton6.Image"), System.Drawing.Image)
        Me.RibbonButton6.LargeImage = CType(resources.GetObject("RibbonButton6.LargeImage"), System.Drawing.Image)
        Me.RibbonButton6.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.RibbonButton6.Name = "RibbonButton6"
        Me.RibbonButton6.SmallImage = CType(resources.GetObject("RibbonButton6.SmallImage"), System.Drawing.Image)
        Me.RibbonButton6.Text = "Expedientes"
        '
        'Contabilidadmenu_Ordencargo
        '
        Me.Contabilidadmenu_Ordencargo.Image = CType(resources.GetObject("Contabilidadmenu_Ordencargo.Image"), System.Drawing.Image)
        Me.Contabilidadmenu_Ordencargo.LargeImage = CType(resources.GetObject("Contabilidadmenu_Ordencargo.LargeImage"), System.Drawing.Image)
        Me.Contabilidadmenu_Ordencargo.Name = "Contabilidadmenu_Ordencargo"
        Me.Contabilidadmenu_Ordencargo.SmallImage = CType(resources.GetObject("Contabilidadmenu_Ordencargo.SmallImage"), System.Drawing.Image)
        Me.Contabilidadmenu_Ordencargo.Text = "Orden_de_Cargo"
        '
        'NotifyIconSICyF
        '
        Me.NotifyIconSICyF.Icon = CType(resources.GetObject("NotifyIconSICyF.Icon"), System.Drawing.Icon)
        Me.NotifyIconSICyF.Text = "SICyF"
        Me.NotifyIconSICyF.Visible = True
        '
        'Inicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(810, 530)
        Me.Controls.Add(Me.RibbonMenu)
        Me.Controls.Add(Me.StatusSiciyf)
        Me.Controls.Add(Me.ToolStripgeneral)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.Name = "Inicio"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "-"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusSiciyf.ResumeLayout(False)
        Me.StatusSiciyf.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
    Friend WithEvents MessageTooltip As ToolTip
    Friend WithEvents ToolStripgeneral As ToolStrip
    Friend WithEvents Menuboton_cheques As ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton
    Friend WithEvents KryptonManager1 As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents StatusSiciyf As StatusStrip
    Friend WithEvents Servidor1toolstrip_label As ToolStripStatusLabel
    Friend WithEvents Servidor2toolstrip_label As ToolStripStatusLabel
    Friend WithEvents Serveractivotoolstrip As ToolStripStatusLabel
    Friend WithEvents Usuariotoolstrip_label As ToolStripStatusLabel
    Friend WithEvents Direcciontoolstrip_label As ToolStripStatusLabel
    Friend WithEvents Resultadotoolstrip_label As ToolStripStatusLabel
    Friend WithEvents Tiempodetecleogeneral As Timer
    Friend WithEvents RibbonMenu As Ribbon
    Friend WithEvents Tesoreriamenu As RibbonTab
    Friend WithEvents Contabilidadmenu As RibbonTab
    Friend WithEvents Mesaentradasmenu As RibbonTab
    Friend WithEvents Usuariomenu As RibbonTab
    Friend WithEvents RibbonColorChooser1 As RibbonColorChooser
    Friend WithEvents Tesoreriamenu_Reportes As RibbonButton
    Friend WithEvents Tesoreriamenu_Experimental As RibbonButton
    Friend WithEvents Tesoreriamenu_Conciliacion As RibbonButton
    Friend WithEvents PanelTesoreria As RibbonPanel
    Friend WithEvents Tesoreriamenu_Expedientes As RibbonButton
    Friend WithEvents Tesoreriamenu_PedidodeFondos As RibbonButton
    Friend WithEvents Tesoreriamenu_Liquidaciones As RibbonButton
    Friend WithEvents Tesoreriamenu_Movimientos As RibbonButton
    Friend WithEvents Tesoreriamenu_CuentaBancaria As RibbonButton
    Friend WithEvents Tesoreriamenu_Conciliación As RibbonButton
    Friend WithEvents Tesoreriamenu_Reportes2 As RibbonButton
    Friend WithEvents RibbonButton1 As RibbonButton
    Friend WithEvents Panel_Contabilidad As RibbonPanel
    Friend WithEvents Contabilidadmenu_Expedientes As RibbonButton
    Friend WithEvents Panel_mesadeentradas As RibbonPanel
    Friend WithEvents Mesaentradasmenu_Expedientes As RibbonButton
    Friend WithEvents Panel_usuario As RibbonPanel
    Friend WithEvents Usuariomenu_Usuario As RibbonButton
    Friend WithEvents PanelControl As RibbonPanel
    Friend WithEvents Informaticamenu As RibbonTab
    Friend WithEvents Informaticapanel1 As RibbonPanel
    Friend WithEvents EstadoServidores_Menu As RibbonButton
    Friend WithEvents Contabilidadmenu_Ordenpago As RibbonButton
    Friend WithEvents RibbonButton2 As RibbonButton
    Friend WithEvents RibbonButton3 As RibbonButton
    Friend WithEvents RibbonButton4 As RibbonButton
    Friend WithEvents ToolStripDebug As ToolStripStatusLabel
    Friend WithEvents SuministrosMenu As RibbonTab
    Friend WithEvents Label_EJERCICIOFINANCIERO As ToolStripStatusLabel
    Friend WithEvents ToolStripSplitButton1 As ToolStripSplitButton
    Friend WithEvents Conciliacion_reporte As RibbonButton
    Friend WithEvents ReportesDiarios_reporte As RibbonButton
    Friend WithEvents Otros_reportes As RibbonButton
    Friend WithEvents Recibos_retenciones As RibbonButton
    Friend WithEvents Retencionescheque As RibbonButton
    Friend WithEvents Conciliacion1 As RibbonButton
    Friend WithEvents Conciliacion2 As RibbonButton
    Friend WithEvents ConciliacionMFyV As RibbonButton
    Friend WithEvents CuentaBancaria_menu As RibbonButton
    Friend WithEvents Tesoreria_Cheques_menu As RibbonButton
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer_menu As Timer
    Friend WithEvents DireccionMenu As RibbonTab
    Friend WithEvents Suministros_panel As RibbonPanel
    Friend WithEvents Suministros_Expedientes_button As RibbonButton
    Friend WithEvents Suministros_Ordenprovision_button As RibbonButton
    Friend WithEvents Direccion_panel As RibbonPanel
    Friend WithEvents Suministros_expedientes_boton As RibbonButton
    Friend WithEvents Suministros_ordenprovision_boton As RibbonButton
    Friend WithEvents Reportesdireccion_button As RibbonButton
    Friend WithEvents RibbonButton5 As RibbonButton
    Friend WithEvents RibbonButton6 As RibbonButton
    Friend WithEvents Direccion_menu_boton As RibbonButton
    Friend WithEvents RibbonPanel1 As RibbonPanel
    Friend WithEvents RibbonButton8 As RibbonButton
    Friend WithEvents Contabilidadmenu_Ordencargo As RibbonButton
    Friend WithEvents RibbonButton7 As RibbonButton
    Friend WithEvents RibbonButton9 As RibbonButton
    Friend WithEvents RibbonButton10 As RibbonButton
    Friend WithEvents RibbonPanel2 As RibbonPanel
    Friend WithEvents NotifyIconSICyF As NotifyIcon
End Class
