<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cuentabancaria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cuentabancaria))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Boton_busqueda = New System.Windows.Forms.Button()
        Me.Busqueda = New System.Windows.Forms.TextBox()
        Me.Datoscuenta_datagridview = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Cuenta_textbox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panelicono = New System.Windows.Forms.Panel()
        Me.Cuenta_label = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Descripcion_textbox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Instrumento_legal_textbox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ElementHost1 = New System.Windows.Forms.Integration.ElementHost()
        Me.Control_DatetimepickerFechaapertura = New System.Windows.Forms.DateTimePicker()
        Me.Ejercicio_numeric = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Boton_borrar = New System.Windows.Forms.Button()
        Me.Boton_aceptar = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Tipodecuenta_Combobox = New System.Windows.Forms.ComboBox()
        Me.Chequeinicial_textbox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Caracter_combobox = New System.Windows.Forms.ComboBox()
        CType(Me.Datoscuenta_datagridview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ejercicio_numeric, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Boton_busqueda
        '
        Me.Boton_busqueda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Boton_busqueda.AutoSize = True
        Me.Boton_busqueda.BackgroundImage = CType(resources.GetObject("Boton_busqueda.BackgroundImage"), System.Drawing.Image)
        Me.Boton_busqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Boton_busqueda.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Boton_busqueda.Location = New System.Drawing.Point(481, 35)
        Me.Boton_busqueda.Name = "Boton_busqueda"
        Me.Boton_busqueda.Size = New System.Drawing.Size(54, 24)
        Me.Boton_busqueda.TabIndex = 99
        Me.Boton_busqueda.UseVisualStyleBackColor = True
        '
        'Busqueda
        '
        Me.Busqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Busqueda.BackColor = System.Drawing.Color.White
        Me.Busqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Busqueda.Font = New System.Drawing.Font("Garamond", 10.0!)
        Me.Busqueda.ForeColor = System.Drawing.Color.Black
        Me.Busqueda.Location = New System.Drawing.Point(6, 35)
        Me.Busqueda.Margin = New System.Windows.Forms.Padding(0)
        Me.Busqueda.Name = "Busqueda"
        Me.Busqueda.Size = New System.Drawing.Size(472, 22)
        Me.Busqueda.TabIndex = 97
        '
        'Datoscuenta_datagridview
        '
        Me.Datoscuenta_datagridview.AllowUserToAddRows = False
        Me.Datoscuenta_datagridview.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Datoscuenta_datagridview.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Datoscuenta_datagridview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Datoscuenta_datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Datoscuenta_datagridview.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.Datoscuenta_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Datoscuenta_datagridview.Location = New System.Drawing.Point(6, 60)
        Me.Datoscuenta_datagridview.MultiSelect = False
        Me.Datoscuenta_datagridview.Name = "Datoscuenta_datagridview"
        Me.Datoscuenta_datagridview.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
        Me.Datoscuenta_datagridview.ReadOnly = True
        Me.Datoscuenta_datagridview.RowHeadersVisible = False
        Me.Datoscuenta_datagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Datoscuenta_datagridview.Size = New System.Drawing.Size(529, 421)
        Me.Datoscuenta_datagridview.TabIndex = 98
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Garamond", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(3, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(118, 30)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Detalle de cuentas " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "actuales"
        '
        'Cuenta_textbox
        '
        Me.Cuenta_textbox.BackColor = System.Drawing.Color.White
        Me.Cuenta_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cuenta_textbox.Font = New System.Drawing.Font("Garamond", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cuenta_textbox.ForeColor = System.Drawing.Color.Black
        Me.Cuenta_textbox.Location = New System.Drawing.Point(116, 58)
        Me.Cuenta_textbox.Name = "Cuenta_textbox"
        Me.Cuenta_textbox.Size = New System.Drawing.Size(351, 24)
        Me.Cuenta_textbox.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Garamond", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(173, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(261, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CUENTA BANCARIA"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panelicono
        '
        Me.Panelicono.BackColor = System.Drawing.Color.LightGreen
        Me.Panelicono.BackgroundImage = CType(resources.GetObject("Panelicono.BackgroundImage"), System.Drawing.Image)
        Me.Panelicono.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panelicono.Location = New System.Drawing.Point(7, 4)
        Me.Panelicono.Margin = New System.Windows.Forms.Padding(4)
        Me.Panelicono.Name = "Panelicono"
        Me.Panelicono.Size = New System.Drawing.Size(127, 53)
        Me.Panelicono.TabIndex = 0
        '
        'Cuenta_label
        '
        Me.Cuenta_label.AutoSize = True
        Me.Cuenta_label.Font = New System.Drawing.Font("Garamond", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cuenta_label.ForeColor = System.Drawing.Color.Black
        Me.Cuenta_label.Location = New System.Drawing.Point(6, 62)
        Me.Cuenta_label.Name = "Cuenta_label"
        Me.Cuenta_label.Size = New System.Drawing.Size(105, 15)
        Me.Cuenta_label.TabIndex = 1
        Me.Cuenta_label.Text = "Num. de Cuenta"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Garamond", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(6, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Descripción"
        '
        'Descripcion_textbox
        '
        Me.Descripcion_textbox.BackColor = System.Drawing.Color.White
        Me.Descripcion_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Descripcion_textbox.Font = New System.Drawing.Font("Garamond", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Descripcion_textbox.ForeColor = System.Drawing.Color.Black
        Me.Descripcion_textbox.Location = New System.Drawing.Point(116, 88)
        Me.Descripcion_textbox.Multiline = True
        Me.Descripcion_textbox.Name = "Descripcion_textbox"
        Me.Descripcion_textbox.Size = New System.Drawing.Size(351, 48)
        Me.Descripcion_textbox.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Garamond", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(5, 220)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 28)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Instrumento legal" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " que crea"
        '
        'Instrumento_legal_textbox
        '
        Me.Instrumento_legal_textbox.BackColor = System.Drawing.Color.White
        Me.Instrumento_legal_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Instrumento_legal_textbox.Font = New System.Drawing.Font("Garamond", 13.0!)
        Me.Instrumento_legal_textbox.ForeColor = System.Drawing.Color.Black
        Me.Instrumento_legal_textbox.Location = New System.Drawing.Point(116, 220)
        Me.Instrumento_legal_textbox.Name = "Instrumento_legal_textbox"
        Me.Instrumento_legal_textbox.Size = New System.Drawing.Size(351, 27)
        Me.Instrumento_legal_textbox.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Garamond", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(6, 164)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 15)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Fecha de apertura"
        '
        'ElementHost1
        '
        Me.ElementHost1.Location = New System.Drawing.Point(116, 142)
        Me.ElementHost1.Name = "ElementHost1"
        Me.ElementHost1.Size = New System.Drawing.Size(351, 42)
        Me.ElementHost1.TabIndex = 6
        Me.ElementHost1.Text = "ElementHost1"
        Me.ElementHost1.Child = Nothing
        '
        'Control_DatetimepickerFechaapertura
        '
        Me.Control_DatetimepickerFechaapertura.Location = New System.Drawing.Point(0, 0)
        Me.Control_DatetimepickerFechaapertura.Name = "Control_DatetimepickerFechaapertura"
        Me.Control_DatetimepickerFechaapertura.Size = New System.Drawing.Size(200, 20)
        Me.Control_DatetimepickerFechaapertura.TabIndex = 0
        '
        'Ejercicio_numeric
        '
        Me.Ejercicio_numeric.Location = New System.Drawing.Point(177, 187)
        Me.Ejercicio_numeric.Maximum = New Decimal(New Integer() {2200, 0, 0, 0})
        Me.Ejercicio_numeric.Minimum = New Decimal(New Integer() {1990, 0, 0, 0})
        Me.Ejercicio_numeric.Name = "Ejercicio_numeric"
        Me.Ejercicio_numeric.Size = New System.Drawing.Size(120, 25)
        Me.Ejercicio_numeric.TabIndex = 4
        Me.Ejercicio_numeric.Value = New Decimal(New Integer() {1990, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Garamond", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(113, 192)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 15)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Ejercicio"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Boton_borrar, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Boton_aceptar, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(4, 346)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(462, 46)
        Me.TableLayoutPanel2.TabIndex = 17
        '
        'Boton_borrar
        '
        Me.Boton_borrar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Boton_borrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Boton_borrar.Image = CType(resources.GetObject("Boton_borrar.Image"), System.Drawing.Image)
        Me.Boton_borrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Boton_borrar.Location = New System.Drawing.Point(234, 3)
        Me.Boton_borrar.Name = "Boton_borrar"
        Me.Boton_borrar.Size = New System.Drawing.Size(225, 40)
        Me.Boton_borrar.TabIndex = 102
        Me.Boton_borrar.Text = "Borrar"
        Me.Boton_borrar.UseVisualStyleBackColor = True
        '
        'Boton_aceptar
        '
        Me.Boton_aceptar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Boton_aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Boton_aceptar.Image = CType(resources.GetObject("Boton_aceptar.Image"), System.Drawing.Image)
        Me.Boton_aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Boton_aceptar.Location = New System.Drawing.Point(3, 3)
        Me.Boton_aceptar.Name = "Boton_aceptar"
        Me.Boton_aceptar.Size = New System.Drawing.Size(225, 40)
        Me.Boton_aceptar.TabIndex = 100
        Me.Boton_aceptar.Text = "Agregar o Modificar"
        Me.Boton_aceptar.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Garamond", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(6, 259)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 15)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Tipo de Cuenta"
        '
        'Tipodecuenta_Combobox
        '
        Me.Tipodecuenta_Combobox.FormattingEnabled = True
        Me.Tipodecuenta_Combobox.Location = New System.Drawing.Point(116, 253)
        Me.Tipodecuenta_Combobox.Name = "Tipodecuenta_Combobox"
        Me.Tipodecuenta_Combobox.Size = New System.Drawing.Size(351, 26)
        Me.Tipodecuenta_Combobox.TabIndex = 6
        '
        'Chequeinicial_textbox
        '
        Me.Chequeinicial_textbox.BackColor = System.Drawing.Color.White
        Me.Chequeinicial_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Chequeinicial_textbox.Font = New System.Drawing.Font("Garamond", 11.0!)
        Me.Chequeinicial_textbox.ForeColor = System.Drawing.Color.Black
        Me.Chequeinicial_textbox.Location = New System.Drawing.Point(115, 317)
        Me.Chequeinicial_textbox.Name = "Chequeinicial_textbox"
        Me.Chequeinicial_textbox.Size = New System.Drawing.Size(349, 24)
        Me.Chequeinicial_textbox.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Garamond", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(6, 321)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Cheque Inicial"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.AutoScroll = True
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Caracter_combobox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Cuenta_label)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Descripcion_textbox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Instrumento_legal_textbox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ElementHost1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Ejercicio_numeric)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Cuenta_textbox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panelicono)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Chequeinicial_textbox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Tipodecuenta_Combobox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Boton_busqueda)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Busqueda)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Datoscuenta_datagridview)
        Me.SplitContainer1.Size = New System.Drawing.Size(1011, 490)
        Me.SplitContainer1.SplitterDistance = 469
        Me.SplitContainer1.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Garamond", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(6, 291)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 15)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Caracter"
        '
        'Caracter_combobox
        '
        Me.Caracter_combobox.FormattingEnabled = True
        Me.Caracter_combobox.Items.AddRange(New Object() {"0", "2-01", "2-02", "2-03", "2-04", "2-05", "2-06", "2-07", "2-08", "2-09", "2-10", "2-11", "2-12", "2-13", "2-14", "2-15", "2-16", "2-17", "2-18", "2-19", "2-20"})
        Me.Caracter_combobox.Location = New System.Drawing.Point(116, 285)
        Me.Caracter_combobox.Name = "Caracter_combobox"
        Me.Caracter_combobox.Size = New System.Drawing.Size(181, 26)
        Me.Caracter_combobox.TabIndex = 18
        '
        'Cuentabancaria
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1011, 490)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Garamond", 12.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Cuentabancaria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cuentabancaria"
        CType(Me.Datoscuenta_datagridview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ejercicio_numeric, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents Boton_busqueda As Button
    Friend WithEvents Busqueda As TextBox
    Friend WithEvents Datoscuenta_datagridview As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents Label7 As Label
    Friend WithEvents Chequeinicial_textbox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Instrumento_legal_textbox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Descripcion_textbox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Cuenta_label As Label
    Friend WithEvents Panelicono As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Boton_borrar As Button
    Friend WithEvents Boton_aceptar As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Tipodecuenta_Combobox As ComboBox
    Friend WithEvents ElementHost1 As Integration.ElementHost
    Friend Control_DatetimepickerFechaapertura As DateTimePicker
    Friend WithEvents Cuenta_textbox As TextBox
    Friend WithEvents Ejercicio_numeric As NumericUpDown
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Label9 As Label
    Friend WithEvents Caracter_combobox As ComboBox
End Class
