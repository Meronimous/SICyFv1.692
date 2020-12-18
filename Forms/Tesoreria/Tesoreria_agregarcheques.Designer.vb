<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tesoreria_agregarcheques
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Listadocheques_valores = New SICyF.Flicker_Datagridview()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Cuentas_combobox = New System.Windows.Forms.ComboBox()
        Me.PaneL_sinFlicker1 = New SICyF.PANEL_sinFlicker()
        Me.agregar50_boton = New System.Windows.Forms.Button()
        Me.Inicial = New System.Windows.Forms.NumericUpDown()
        Me.Final = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.sgte_chequera_boton = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Listadocheques_valores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PaneL_sinFlicker1.SuspendLayout()
        CType(Me.Inicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Final, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 320)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(299, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OK_Button.Location = New System.Drawing.Point(0, 0)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(0)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(149, 29)
        Me.OK_Button.TabIndex = 3
        Me.OK_Button.Text = "Agregar Cheques"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Cancel_Button.Location = New System.Drawing.Point(149, 0)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(0)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(150, 29)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Salir"
        '
        'Listadocheques_valores
        '
        Me.Listadocheques_valores.AllowUserToOrderColumns = True
        Me.Listadocheques_valores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Listadocheques_valores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Listadocheques_valores.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Listadocheques_valores.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Listadocheques_valores.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Listadocheques_valores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Listadocheques_valores.DefaultCellStyle = DataGridViewCellStyle4
        Me.Listadocheques_valores.Location = New System.Drawing.Point(308, 10)
        Me.Listadocheques_valores.Name = "Listadocheques_valores"
        Me.Listadocheques_valores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Listadocheques_valores.Size = New System.Drawing.Size(218, 340)
        Me.Listadocheques_valores.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 13)
        Me.Label6.TabIndex = 154
        Me.Label6.Text = "Cuenta Bancaria"
        '
        'Cuentas_combobox
        '
        Me.Cuentas_combobox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cuentas_combobox.FormattingEnabled = True
        Me.Cuentas_combobox.Location = New System.Drawing.Point(98, 5)
        Me.Cuentas_combobox.Name = "Cuentas_combobox"
        Me.Cuentas_combobox.Size = New System.Drawing.Size(439, 23)
        Me.Cuentas_combobox.TabIndex = 0
        '
        'PaneL_sinFlicker1
        '
        Me.PaneL_sinFlicker1.Controls.Add(Me.sgte_chequera_boton)
        Me.PaneL_sinFlicker1.Controls.Add(Me.agregar50_boton)
        Me.PaneL_sinFlicker1.Controls.Add(Me.Inicial)
        Me.PaneL_sinFlicker1.Controls.Add(Me.Final)
        Me.PaneL_sinFlicker1.Controls.Add(Me.Listadocheques_valores)
        Me.PaneL_sinFlicker1.Controls.Add(Me.Label2)
        Me.PaneL_sinFlicker1.Controls.Add(Me.TableLayoutPanel1)
        Me.PaneL_sinFlicker1.Controls.Add(Me.Label1)
        Me.PaneL_sinFlicker1.Location = New System.Drawing.Point(9, 31)
        Me.PaneL_sinFlicker1.Margin = New System.Windows.Forms.Padding(0)
        Me.PaneL_sinFlicker1.Name = "PaneL_sinFlicker1"
        Me.PaneL_sinFlicker1.Size = New System.Drawing.Size(528, 353)
        Me.PaneL_sinFlicker1.TabIndex = 160
        '
        'agregar50_boton
        '
        Me.agregar50_boton.Location = New System.Drawing.Point(238, 83)
        Me.agregar50_boton.Name = "agregar50_boton"
        Me.agregar50_boton.Size = New System.Drawing.Size(64, 23)
        Me.agregar50_boton.TabIndex = 164
        Me.agregar50_boton.Text = "+50"
        Me.agregar50_boton.UseVisualStyleBackColor = True
        '
        'Inicial
        '
        Me.Inicial.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Inicial.ForeColor = System.Drawing.Color.Black
        Me.Inicial.Location = New System.Drawing.Point(15, 26)
        Me.Inicial.Margin = New System.Windows.Forms.Padding(0)
        Me.Inicial.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.Inicial.Name = "Inicial"
        Me.Inicial.Size = New System.Drawing.Size(220, 29)
        Me.Inicial.TabIndex = 1
        Me.Inicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Final
        '
        Me.Final.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Final.ForeColor = System.Drawing.Color.Black
        Me.Final.Location = New System.Drawing.Point(15, 80)
        Me.Final.Margin = New System.Windows.Forms.Padding(0)
        Me.Final.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.Final.Name = "Final"
        Me.Final.Size = New System.Drawing.Size(220, 29)
        Me.Final.TabIndex = 2
        Me.Final.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(42, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 161
        Me.Label2.Text = "Cheque inicial"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 160
        Me.Label1.Text = "Cheque Final"
        '
        'sgte_chequera_boton
        '
        Me.sgte_chequera_boton.Location = New System.Drawing.Point(15, 137)
        Me.sgte_chequera_boton.Name = "sgte_chequera_boton"
        Me.sgte_chequera_boton.Size = New System.Drawing.Size(220, 23)
        Me.sgte_chequera_boton.TabIndex = 165
        Me.sgte_chequera_boton.Text = "Siguiente Chequera consecutiva"
        Me.sgte_chequera_boton.UseVisualStyleBackColor = True
        '
        'Tesoreria_agregarcheques
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(542, 393)
        Me.Controls.Add(Me.PaneL_sinFlicker1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Cuentas_combobox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Tesoreria_agregarcheques"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agregar cheques"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Listadocheques_valores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PaneL_sinFlicker1.ResumeLayout(False)
        Me.PaneL_sinFlicker1.PerformLayout()
        CType(Me.Inicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Final, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Listadocheques_valores As Flicker_Datagridview
    Friend WithEvents Label6 As Label
    Friend WithEvents Cuentas_combobox As ComboBox
    Friend WithEvents PaneL_sinFlicker1 As PANEL_sinFlicker
    Friend WithEvents agregar50_boton As Button
    Friend WithEvents Inicial As NumericUpDown
    Friend WithEvents Final As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents sgte_chequera_boton As Button
End Class
