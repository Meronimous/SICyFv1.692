Imports System.ComponentModel
Imports System.Globalization
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Windows.Media

Public Class Controls_Sicyf
End Class

Public Module CopyPasteFunctions

    Public Function GetTopLeftSelectedCell(ByVal cells As DataGridViewSelectedCellCollection) As DataGridViewCell
        If Not IsNothing(cells) AndAlso cells.Count > 0 Then
            Dim cellList = (From c In cells.Cast(Of DataGridViewCell)()
                            Order By c.RowIndex, c.ColumnIndex
                            Select c).ToList
            Return cellList(0)
        End If
        Return Nothing
    End Function

End Module

'/////////////////////////////////////////////////////////*************************************************************************************************************************
Public Class FlickerTabcontrol
    Inherits System.Windows.Forms.TabControl
    Public Event PaintToBuffer(ByVal g As Graphics)

    Protected Overrides Sub OnPaintBackground(ByVal e As System.Windows.Forms.PaintEventArgs)
        If Me.DesignMode Then
            MyBase.OnPaintBackground(e)
        Else
            '-- Prevent MyBase from painting the background.
        End If
    End Sub

    ''' <summary> Do your painting in the handler for this event.  </summary>
    Private Sub DoubleBufferPanel_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Using backBuffer As New Bitmap(Me.Width, Me.Height)
            Using gBuffer As Graphics = Graphics.FromImage(backBuffer)
                RaiseEvent PaintToBuffer(gBuffer)
            End Using
            e.Graphics.DrawImageUnscaled(backBuffer, 0, 0)
        End Using
    End Sub

End Class

'/////////////////////////////////////////////////////////*************************************************************************************************************************
Public Class Flicker_Numericcontrol_Dinero
    Inherits System.Windows.Forms.NumericUpDown
    Public Property Suffix As String

    Public Sub New()
        ' Me.AutoSize = False
        With Me
            .Width = Me.Width - 25
            .Controls(0).BackColor = (System.Drawing.Color.White)
            .ThousandsSeparator = True
        End With
    End Sub

End Class

'/////////////////////////////////////////////////////////*************************************************************************************************************************
Public Class Flicker_Numericcontrol_Numero
    Inherits System.Windows.Forms.NumericUpDown
    Public Property Suffix As String

    Public Sub New()
        ' Me.AutoSize = False
        With Me
            .Width = Me.Width - 25
            .Controls(0).BackColor = (System.Drawing.Color.White)
        End With
    End Sub

    Private Sub keys(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Inicio.SIGUIENTECONTROL(Me.ParentForm, sender, e)
    End Sub

End Class

'/////////////////////////////////////////////////////////*************************************************************************************************************************
Public Class Flicker_Split_panel
    Inherits SplitContainer

    Public Sub New()
        With Me
            .SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.Selectable Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.SupportsTransparentBackColor, True)
            .BackColor = (System.Drawing.Color.LightBlue)
            .Panel1.BackColor = (System.Drawing.Color.White)
            .Panel2.BackColor = (System.Drawing.Color.White)
        End With
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Me.BackgroundImage IsNot Nothing Then
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
            e.Graphics.DrawImage(Me.BackgroundImage, New System.Drawing.Rectangle(0, 0, Me.Width, Me.Height), 0, 0, Me.BackgroundImage.Width, Me.BackgroundImage.Height, System.Drawing.GraphicsUnit.Pixel)
        End If
        MyBase.OnPaint(e)
    End Sub

End Class

'/////////////////////////////////////////////////////////*************************************************************************************************************************
''' <summary>
'''Datagridview con
'''1)doble buffer
'''2)con zoom
'''3) teclas especiales (Escape para no seleccionar nada
'''4) Fuente dependiente de la resolución de la pantalla
'''5) habilidad para cambiar de orden las columnas
''' </summary>
Public Class Flicker_Datagridview
    Inherits DataGridView

    Public Sub New()
        Me.DoubleBuffered = True
        Dim culture As CultureInfo
        culture = CultureInfo.CreateSpecificCulture("es-AR")
        CultureInfo.DefaultThreadCurrentCulture = culture
        Thread.CurrentThread.CurrentCulture = culture
        Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ","
        Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = "."
        Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ","
        Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = "."
        'Datos de Estilo
        With Me
            .SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.Selectable Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.SupportsTransparentBackColor, True)
            '   .RowHeadersVisible = False
            .BackColor = (System.Drawing.Color.White)
            .BackgroundColor = (System.Drawing.Color.White)
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            'formato de las celdas
            With .DefaultCellStyle
                .Font = Fuenteresolucion()
                .WrapMode = DataGridViewTriState.True
                .Padding = New Windows.Forms.Padding(0, 0, 0, 0)
            End With
            '  .AlternatingRowsDefaultCellStyle = .DefaultCellStyle
            '  .RowsDefaultCellStyle = .DefaultCellStyle
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
            'formato del encabezado de las columnas
            With .ColumnHeadersDefaultCellStyle
                .Font = Fuenteresolucion()
                .WrapMode = DataGridViewTriState.True
                .Padding = New Windows.Forms.Padding(0, 0, 0, 0)
            End With
            .AllowUserToOrderColumns = True
        End With
    End Sub

    Private Sub Mouse_MouseWheel(ByVal sender As Flicker_Datagridview, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        Flicker_Datagrid_MouseWheel(sender, e)
    End Sub

    Private Sub Teclasespeciales(ByVal sender As Flicker_Datagridview, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyValue
            Case Is = Keys.Escape
                Me.CurrentCell = Nothing
                e.Handled = True
            Case Else
                If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.V Then
                    PasteFromClipboard(sender, e)
                End If
        End Select
    End Sub

    'Mouse y asociados///////////////////////////////////////////////////////////////////////////////////////////////////////////
    Public Shared Sub Flicker_Datagrid_MouseWheel(ByVal sender As Flicker_Datagridview, ByVal e As System.Windows.Forms.MouseEventArgs)
        'el form debe estar con keypreview activado.
        If sender.Enabled Then
            If Control.ModifierKeys = (Keys.Control) Then
                '     Inicio.OBJETOCARGANDO(sender, sender.FindForm, "Modificando tamaño...")
                If sender.Enabled = True Then
                    sender.SuspendLayout()
                    sender.UseWaitCursor = True
                    sender.Enabled = False
                    sender.Visible = False
                    Dim scrollLines As Integer = SystemInformation.MouseWheelScrollLines
                    Dim valorfuente As Integer = sender.DefaultCellStyle.Font.Size
                    Dim fuente As System.Drawing.Font = New System.Drawing.Font(sender.DefaultCellStyle.Font.Name, valorfuente, FontStyle.Regular)
                    Inicio.ToolStripDebug.Text = e.Delta.ToString
                    Select Case e.Delta
                        Case Is > 0 'Scrolling up.
                            fuente = New System.Drawing.Font(sender.DefaultCellStyle.Font.Name, valorfuente + 1, FontStyle.Regular)
                            sender.DefaultCellStyle.Font = fuente
                           ' sender.AlternatingRowsDefaultCellStyle.Font = fuente
                        Case Is < 0  'Scrolling down
                            If valorfuente > 1 Then
                                fuente = New System.Drawing.Font(sender.DefaultCellStyle.Font.Name, valorfuente - 1, FontStyle.Regular)
                                sender.DefaultCellStyle.Font = fuente
                                ' sender.AlternatingRowsDefaultCellStyle.Font = fuente
                            Else
                                MsgBox("El valor de la fuente es demasiado pequeño")
                            End If
                    End Select
                    '   sender.Refresh()
                    '   Me.AutoResizeRows()
                    sender.Enabled = True
                    sender.ResumeLayout()
                    sender.UseWaitCursor = False
                    sender.Visible = True
                Else
                End If
                '   Inicio.OBJETOFINALIZAR(sender, sender.FindForm)
            End If
        Else
        End If
    End Sub

End Class

'/////////////////////////////////////////////////////////*************************************************************************************************************************
Public Class Flicker_Tablelayout
    Inherits TableLayoutPanel

    'Public Sub New()
    '    'InitializeComponent()
    '    SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.UserPaint, True)
    'End Sub
    Public Sub New(ByVal container As IContainer)
        container.Add(Me)
        '  InitializeComponent()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.UserPaint, True)
    End Sub

End Class

'/////////////////////////////////////////////////////////*************************************************************************************************************************
Class SplitContainerEx
    Inherits SplitContainer

    Public Sub New()
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.Selectable Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.SupportsTransparentBackColor, True)
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        Return
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Me.BackgroundImage IsNot Nothing Then
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
            e.Graphics.DrawImage(Me.BackgroundImage, New System.Drawing.Rectangle(0, 0, Me.Width, Me.Height), 0, 0, Me.BackgroundImage.Width, Me.BackgroundImage.Height, System.Drawing.GraphicsUnit.Pixel)
        End If
        MyBase.OnPaint(e)
    End Sub

End Class

'/////////////////////////////////////////////////////////*************************************************************************************************************************
Public Class PANEL_sinFlicker
    Inherits Panel

    Public Sub New()
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        '  Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Me.BackgroundImage IsNot Nothing Then
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
            e.Graphics.DrawImage(Me.BackgroundImage, New System.Drawing.Rectangle(0, 0, Me.Width, Me.Height), 0, 0, Me.BackgroundImage.Width, Me.BackgroundImage.Height, System.Drawing.GraphicsUnit.Pixel)
        End If
        MyBase.OnPaint(e)
    End Sub

End Class

'/////////////////////////////////////////////////////////*************************************************************************************************************************
''' <summary>
''' Original author
''' http://social.msdn.microsoft.com/Forums/en-US/winformsdatacontrols/thread/a44622c0-74e1-463b-97b9-27b87513747e#faq8
''' </summary>
''' <remarks>
''' Original code was in C Sharp, I converted and tweaked some code
''' which did not compile under VB.NET
''' </remarks>
Public Class GroupByGrid
    Inherits DataGridView

    Protected Overrides Sub OnCellFormatting(ByVal args As DataGridViewCellFormattingEventArgs)
        MyBase.OnCellFormatting(args)
        ' First row always displays
        If args.RowIndex = 0 Then
            Return
        End If
        If IsRepeatedCellValue(args.RowIndex, args.ColumnIndex) Then
            args.Value = String.Empty
            args.FormattingApplied = True
        End If
    End Sub

    Private Function IsRepeatedCellValue(ByVal rowIndex As Integer, ByVal colIndex As Integer) As Boolean
        Dim currCell As DataGridViewCell = Rows(rowIndex).Cells(colIndex)
        Dim prevCell As DataGridViewCell = Rows(rowIndex - 1).Cells(colIndex)
        If (currCell.Value Is prevCell.Value) OrElse (currCell.Value IsNot Nothing AndAlso prevCell.Value IsNot Nothing AndAlso currCell.Value.ToString() = prevCell.Value.ToString()) Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Overrides Sub OnCellPainting(ByVal args As DataGridViewCellPaintingEventArgs)
        MyBase.OnCellPainting(args)
        args.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None
        ' Ignore column and row headers and first row
        If args.RowIndex < 1 OrElse args.ColumnIndex < 0 Then
            Return
        End If
        If IsRepeatedCellValue(args.RowIndex, args.ColumnIndex) Then
            args.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None
        Else
            args.AdvancedBorderStyle.Top = AdvancedCellBorderStyle.Top
        End If
    End Sub

End Class

Module Extensions

    <Extension()>
    Function ToBrush(ByVal HexColorString As String) As SolidColorBrush
        Return CType((New BrushConverter().ConvertFrom(HexColorString)), SolidColorBrush)
    End Function

    <Extension()>
    Function ToDataTable(Of T)(ByVal self As IEnumerable(Of T)) As DataTable
        Dim properties = GetType(T).GetProperties()
        Dim dataTable = New DataTable()
        For Each info In properties
            dataTable.Columns.Add(info.Name, If(Nullable.GetUnderlyingType(info.PropertyType), info.PropertyType))
        Next
        For Each entity In self
            dataTable.Rows.Add(properties.[Select](Function(p) p.GetValue(entity)).ToArray())
        Next
        Return dataTable
    End Function

End Module