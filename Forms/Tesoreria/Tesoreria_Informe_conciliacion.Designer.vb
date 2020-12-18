<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tesoreria_Informe_conciliacion
    Inherits System.Windows.Forms.Form
    'Inherits ComponentFactory.Krypton.Toolkit.KryptonForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tesoreria_Informe_conciliacion))
        Me.Panelconciliacion = New System.Windows.Forms.Panel()
        Me.Servicioadministrativoconciliacion_label = New System.Windows.Forms.TextBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Conciliacion_datagridview = New System.Windows.Forms.DataGridView()
        Me.Datosconciliacion_label = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.PanelFirma = New System.Windows.Forms.Panel()
        Me.Panelconciliacion.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.Conciliacion_datagridview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelFirma.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panelconciliacion
        '
        Me.Panelconciliacion.AutoScroll = True
        Me.Panelconciliacion.BackColor = System.Drawing.Color.White
        Me.Panelconciliacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panelconciliacion.Controls.Add(Me.Servicioadministrativoconciliacion_label)
        Me.Panelconciliacion.Controls.Add(Me.Panel7)
        Me.Panelconciliacion.Controls.Add(Me.PictureBox1)
        Me.Panelconciliacion.Controls.Add(Me.PictureBox3)
        Me.Panelconciliacion.Controls.Add(Me.Label37)
        Me.Panelconciliacion.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panelconciliacion.Location = New System.Drawing.Point(12, 12)
        Me.Panelconciliacion.Name = "Panelconciliacion"
        Me.Panelconciliacion.Size = New System.Drawing.Size(834, 1347)
        Me.Panelconciliacion.TabIndex = 4
        Me.Panelconciliacion.Visible = False
        '
        'Servicioadministrativoconciliacion_label
        '
        Me.Servicioadministrativoconciliacion_label.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Servicioadministrativoconciliacion_label.BackColor = System.Drawing.Color.White
        Me.Servicioadministrativoconciliacion_label.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Servicioadministrativoconciliacion_label.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Servicioadministrativoconciliacion_label.ForeColor = System.Drawing.Color.Black
        Me.Servicioadministrativoconciliacion_label.Location = New System.Drawing.Point(204, 19)
        Me.Servicioadministrativoconciliacion_label.Multiline = True
        Me.Servicioadministrativoconciliacion_label.Name = "Servicioadministrativoconciliacion_label"
        Me.Servicioadministrativoconciliacion_label.Size = New System.Drawing.Size(605, 71)
        Me.Servicioadministrativoconciliacion_label.TabIndex = 35
        '
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.PanelFirma)
        Me.Panel7.Controls.Add(Me.Conciliacion_datagridview)
        Me.Panel7.Controls.Add(Me.Datosconciliacion_label)
        Me.Panel7.Location = New System.Drawing.Point(41, 142)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(764, 1099)
        Me.Panel7.TabIndex = 34
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(3, -2)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(274, 48)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "________________________" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Tesorero/a"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(483, -2)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(274, 48)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "________________________" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Director/a"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(242, 95)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(274, 48)
        Me.Label21.TabIndex = 2
        Me.Label21.Text = "________________________" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Delegado Fiscal"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Conciliacion_datagridview
        '
        Me.Conciliacion_datagridview.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.Conciliacion_datagridview.AllowUserToAddRows = False
        Me.Conciliacion_datagridview.AllowUserToDeleteRows = False
        Me.Conciliacion_datagridview.AllowUserToResizeColumns = False
        Me.Conciliacion_datagridview.AllowUserToResizeRows = False
        Me.Conciliacion_datagridview.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Conciliacion_datagridview.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.Conciliacion_datagridview.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Conciliacion_datagridview.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Conciliacion_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Conciliacion_datagridview.DefaultCellStyle = DataGridViewCellStyle2
        Me.Conciliacion_datagridview.GridColor = System.Drawing.Color.Black
        Me.Conciliacion_datagridview.Location = New System.Drawing.Point(7, 60)
        Me.Conciliacion_datagridview.MultiSelect = False
        Me.Conciliacion_datagridview.Name = "Conciliacion_datagridview"
        Me.Conciliacion_datagridview.ReadOnly = True
        Me.Conciliacion_datagridview.RowHeadersVisible = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Adobe Garamond Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Conciliacion_datagridview.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.Conciliacion_datagridview.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Conciliacion_datagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Conciliacion_datagridview.Size = New System.Drawing.Size(752, 165)
        Me.Conciliacion_datagridview.TabIndex = 2
        Me.Conciliacion_datagridview.VirtualMode = True
        '
        'Datosconciliacion_label
        '
        Me.Datosconciliacion_label.BackColor = System.Drawing.Color.White
        Me.Datosconciliacion_label.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Datosconciliacion_label.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Datosconciliacion_label.ForeColor = System.Drawing.Color.Black
        Me.Datosconciliacion_label.Location = New System.Drawing.Point(2, 2)
        Me.Datosconciliacion_label.Margin = New System.Windows.Forms.Padding(0)
        Me.Datosconciliacion_label.Name = "Datosconciliacion_label"
        Me.Datosconciliacion_label.Size = New System.Drawing.Size(758, 44)
        Me.Datosconciliacion_label.TabIndex = 1
        Me.Datosconciliacion_label.Text = "CONCILIACION BANCARIA"
        Me.Datosconciliacion_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Datosconciliacion_label.UseCompatibleTextRendering = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(22, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(164, 97)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 31
        Me.PictureBox1.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Location = New System.Drawing.Point(384, 1253)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(74, 67)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 29
        Me.PictureBox3.TabStop = False
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label37.Location = New System.Drawing.Point(79, 110)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(0, 13)
        Me.Label37.TabIndex = 24
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label37.Visible = False
        '
        'PanelFirma
        '
        Me.PanelFirma.Controls.Add(Me.Label15)
        Me.PanelFirma.Controls.Add(Me.Label21)
        Me.PanelFirma.Controls.Add(Me.Label13)
        Me.PanelFirma.Location = New System.Drawing.Point(2, 937)
        Me.PanelFirma.Name = "PanelFirma"
        Me.PanelFirma.Size = New System.Drawing.Size(761, 161)
        Me.PanelFirma.TabIndex = 5
        '
        'Informe_conciliacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(888, 1061)
        Me.Controls.Add(Me.Panelconciliacion)
        Me.Name = "Informe_conciliacion"
        Me.Text = "Informe_conciliacion"
        Me.Panelconciliacion.ResumeLayout(False)
        Me.Panelconciliacion.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        CType(Me.Conciliacion_datagridview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelFirma.ResumeLayout(False)
        Me.PanelFirma.PerformLayout()
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents Panelconciliacion As Panel
    Friend WithEvents Servicioadministrativoconciliacion_label As TextBox
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label15 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Conciliacion_datagridview As DataGridView
    Friend WithEvents Datosconciliacion_label As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label37 As Label
    Friend WithEvents PanelFirma As Panel
End Class
