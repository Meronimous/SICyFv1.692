<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MesadeEntradas_expedientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MesadeEntradas_expedientes))
        Me.ElementHost1 = New System.Windows.Forms.Integration.ElementHost()
        Me.BusquedaWPF1 = New TextBox
        Me.SuspendLayout()
        '
        'ElementHost1
        '
        Me.ElementHost1.AutoSize = True
        Me.ElementHost1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ElementHost1.Location = New System.Drawing.Point(0, 0)
        Me.ElementHost1.Name = "ElementHost1"
        Me.ElementHost1.Size = New System.Drawing.Size(811, 539)
        Me.ElementHost1.TabIndex = 0
        Me.ElementHost1.Text = "ElementHost1"
        'Me.ElementHost1.Child = Me.BusquedaWPF1
        '
        'MesadeEntradas_expedientes
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(811, 539)
        Me.Controls.Add(Me.ElementHost1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MesadeEntradas_expedientes"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Mesa de Entradas y Salidas"
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
    Friend WithEvents ElementHost1 As Integration.ElementHost
    Friend BusquedaWPF1 As TextBox
End Class
