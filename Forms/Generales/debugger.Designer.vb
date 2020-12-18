<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class debugger
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
        Me.COMMANDSQLrich = New System.Windows.Forms.RichTextBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.INSERTCOMMANDSQLrich = New System.Windows.Forms.RichTextBox()
        Me.Conexionconsulta = New System.Windows.Forms.RichTextBox()
        Me.Conexioninsercion = New System.Windows.Forms.RichTextBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'COMMANDSQLrich
        '
        Me.COMMANDSQLrich.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.COMMANDSQLrich.Location = New System.Drawing.Point(0, 30)
        Me.COMMANDSQLrich.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.COMMANDSQLrich.Name = "COMMANDSQLrich"
        Me.COMMANDSQLrich.Size = New System.Drawing.Size(439, 494)
        Me.COMMANDSQLrich.TabIndex = 0
        Me.COMMANDSQLrich.Text = ""
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Conexionconsulta)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.COMMANDSQLrich)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Conexioninsercion)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.INSERTCOMMANDSQLrich)
        Me.SplitContainer1.Size = New System.Drawing.Size(933, 588)
        Me.SplitContainer1.SplitterDistance = 439
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(160, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "COMMANDSQL"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(168, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(140, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "INSERTCOMMANDSQL"
        '
        'INSERTCOMMANDSQLrich
        '
        Me.INSERTCOMMANDSQLrich.Location = New System.Drawing.Point(0, 30)
        Me.INSERTCOMMANDSQLrich.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.INSERTCOMMANDSQLrich.Name = "INSERTCOMMANDSQLrich"
        Me.INSERTCOMMANDSQLrich.Size = New System.Drawing.Size(489, 494)
        Me.INSERTCOMMANDSQLrich.TabIndex = 1
        Me.INSERTCOMMANDSQLrich.Text = ""
        '
        'Conexionconsulta
        '
        Me.Conexionconsulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Conexionconsulta.Location = New System.Drawing.Point(0, 525)
        Me.Conexionconsulta.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Conexionconsulta.Name = "Conexionconsulta"
        Me.Conexionconsulta.Size = New System.Drawing.Size(439, 63)
        Me.Conexionconsulta.TabIndex = 2
        Me.Conexionconsulta.Text = ""
        '
        'Conexioninsercion
        '
        Me.Conexioninsercion.Location = New System.Drawing.Point(3, 525)
        Me.Conexioninsercion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Conexioninsercion.Name = "Conexioninsercion"
        Me.Conexioninsercion.Size = New System.Drawing.Size(486, 63)
        Me.Conexioninsercion.TabIndex = 3
        Me.Conexioninsercion.Text = ""
        '
        'debugger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(933, 588)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "debugger"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Datos de la consulta SQL en ejecución"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents COMMANDSQLrich As RichTextBox
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents INSERTCOMMANDSQLrich As RichTextBox
    Friend WithEvents Conexionconsulta As RichTextBox
    Friend WithEvents Conexioninsercion As RichTextBox
End Class
