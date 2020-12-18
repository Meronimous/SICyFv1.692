<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Presentacion
    'Inherits ComponentFactory.Krypton.Toolkit.KryptonForm
    Inherits System.Windows.Forms.Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Presentacion))
        Me.ElementHost1 = New System.Windows.Forms.Integration.ElementHost()
        Me.Fondopicturebox = New System.Windows.Forms.PictureBox()
        Me.Label_desarrollo = New System.Windows.Forms.Label()
        CType(Me.Fondopicturebox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ElementHost1
        '
        Me.ElementHost1.Location = New System.Drawing.Point(0, 0)
        Me.ElementHost1.Name = "ElementHost1"
        Me.ElementHost1.Size = New System.Drawing.Size(1, 1)
        Me.ElementHost1.TabIndex = 0
        Me.ElementHost1.Text = "ElementHost1"
        Me.ElementHost1.Child = Nothing
        '
        'Fondopicturebox
        '
        Me.Fondopicturebox.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Fondopicturebox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fondopicturebox.Image = CType(resources.GetObject("Fondopicturebox.Image"), System.Drawing.Image)
        Me.Fondopicturebox.Location = New System.Drawing.Point(0, 0)
        Me.Fondopicturebox.Name = "Fondopicturebox"
        Me.Fondopicturebox.Size = New System.Drawing.Size(694, 398)
        Me.Fondopicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Fondopicturebox.TabIndex = 1
        Me.Fondopicturebox.TabStop = False
        Me.Fondopicturebox.Visible = False
        '
        'Label_desarrollo
        '
        Me.Label_desarrollo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_desarrollo.AutoSize = True
        Me.Label_desarrollo.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label_desarrollo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label_desarrollo.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_desarrollo.ForeColor = System.Drawing.Color.White
        Me.Label_desarrollo.Location = New System.Drawing.Point(436, 377)
        Me.Label_desarrollo.Name = "Label_desarrollo"
        Me.Label_desarrollo.Size = New System.Drawing.Size(246, 12)
        Me.Label_desarrollo.TabIndex = 2
        Me.Label_desarrollo.Text = "Desarrollo por: Cra. Galia Levitt y Exp. Roberto Romero" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Presentacion
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.LightBlue
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(694, 398)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label_desarrollo)
        Me.Controls.Add(Me.Fondopicturebox)
        Me.Controls.Add(Me.ElementHost1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Transparent
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Presentacion"
        Me.Opacity = 0.54R
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Presentacion"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Fondopicturebox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
    Friend WithEvents ElementHost1 As Integration.ElementHost
    Friend WithEvents Fondopicturebox As PictureBox
    Friend WithEvents Label_desarrollo As Label
End Class
