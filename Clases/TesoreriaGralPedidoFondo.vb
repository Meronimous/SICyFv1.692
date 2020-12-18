Public Class TesoreriaGralPedidoFondo
    Private _NumeroPedido As Integer
    Public Property NumeroPedido() As Integer
        Get
            Return _NumeroPedido
        End Get
        Set(ByVal value As Integer)
            _NumeroPedido = value
        End Set
    End Property
    Private _YearPedidoFondo As Integer
    Public Property YearPedidoFondo() As Integer
        Get
            Return _YearPedidoFondo
        End Get
        Set(ByVal value As Integer)
            _YearPedidoFondo = value
        End Set
    End Property
    Private _Descripcion As String
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property
    Private _Observaciones As String
    Public Property Observaciones() As String
        Get
            Return _Observaciones
        End Get
        Set(ByVal value As String)
            _Observaciones = value
        End Set
    End Property
    Private _Fecha As Date
    Public Property Fecha() As Date
        Get
            Return _Fecha
        End Get
        Set(ByVal value As Date)
            _Fecha = value
        End Set
    End Property
    Private _MontoPedidoFondo As Decimal
    Public Property MontoPedidoFondo() As Decimal
        Get
            Return _MontoPedidoFondo
        End Get
        Set(ByVal value As Decimal)
            _MontoPedidoFondo = value
        End Set
    End Property
    Private _NroOrdenEntrega As Integer
    Public Property NroOrdenEntrega() As Integer
        Get
            Return _NroOrdenEntrega
        End Get
        Set(ByVal value As Integer)
            _NroOrdenEntrega = value
        End Set
    End Property
    Private _YearOrdenEntrega As Integer
    Public Property YearOrdenEntrega() As Integer
        Get
            Return _YearOrdenEntrega
        End Get
        Set(ByVal value As Integer)
            _YearOrdenEntrega = value
        End Set
    End Property
    Private _Expediente_N As String
    Public Property Expediente_N() As String
        Get
            Return _Expediente_N
        End Get
        Set(ByVal value As String)
            _Expediente_N = value
        End Set
    End Property
    Private _FechaConsulta As Date
    Public Property FechaConsulta() As Date
        Get
            Return _FechaConsulta
        End Get
        Set(ByVal value As Date)
            _FechaConsulta = value
        End Set
    End Property
    Private _Saldo As Decimal
    Public Property Saldo() As Decimal
        Get
            Return _Saldo
        End Get
        Set(ByVal value As Decimal)
            _Saldo = value
        End Set
    End Property

    Public Sub New()
        _NumeroPedido = 0
        _YearPedidoFondo = Date.Now.Year - 1
        _MontoPedidoFondo = 0
        _NroOrdenEntrega = 0
        _YearOrdenEntrega = Date.Now.Year - 1
        _ExpedientePedidoFondo = Autorizaciones.Organismo & "00000" & Date.Now.Year
        _FechaConsulta = Date.Now
        _Fecha = Date.Now
        _Descripcion = ""
        _Observaciones = ""
        _Saldo = 0
    End Sub

    Private _ExpedientePedidoFondo As String
    Public Property ExpedientePedidoFondo() As String
        Get
            Return _ExpedientePedidoFondo
        End Get
        Set(ByVal value As String)
            _ExpedientePedidoFondo = value
        End Set
    End Property

    Public Sub InsertarBaseDatos(ByVal PedfondTes As TesoreriaGralPedidoFondo, ByVal M As MySql.Data.MySqlClient.MySqlCommand)
        'M.Parameters.Clear()
        M.Parameters.AddWithValue("@Clave_pedidofondo" & PedfondTes._NumeroPedido, _YearPedidoFondo & Autorizaciones.Organismo & _NumeroPedido.ToString("00000"))
        M.Parameters.AddWithValue("@N_pedidofondo" & PedfondTes._NumeroPedido, _NumeroPedido)
        M.Parameters.AddWithValue("@Year_pedidofondo" & PedfondTes._NumeroPedido, _YearPedidoFondo)
        M.Parameters.AddWithValue("@Fecha" & PedfondTes._NumeroPedido, _Fecha)
        M.Parameters.AddWithValue("@Descripcion" & PedfondTes._NumeroPedido, _Descripcion)
        M.Parameters.AddWithValue("@Observaciones" & PedfondTes._NumeroPedido, _Observaciones)
        M.Parameters.AddWithValue("@Monto_pedidofondo" & PedfondTes._NumeroPedido, _MontoPedidoFondo)
        M.Parameters.AddWithValue("@Saldo" & PedfondTes._NumeroPedido, _Saldo)
        M.Parameters.AddWithValue("@N_ordenentrega" & PedfondTes._NumeroPedido, _NroOrdenEntrega)
        M.Parameters.AddWithValue("@Year_ordenentrega" & PedfondTes._NumeroPedido, _YearOrdenEntrega)
        M.Parameters.AddWithValue("@Expediente_N" & PedfondTes._NumeroPedido, _ExpedientePedidoFondo)
        M.Parameters.AddWithValue("@FechaConsulta" & PedfondTes._NumeroPedido, _FechaConsulta)
        M.Parameters.AddWithValue("@Fecha_pedido" & PedfondTes._NumeroPedido, _Fecha)
        M.CommandText = "
INSERT INTO pedido_fondos_TG
(
Clave_pedidofondo,
N_pedidofondo,
Year_pedidofondo,
Fecha,
Descripcion,
Observaciones,
Monto_pedidofondo,
Saldo,
N_ordenentrega,
Year_ordenentrega,
Expediente_N,
FechaConsulta,
Fecha_pedido
)
VALUES
(
@Clave_pedidofondo" & PedfondTes._NumeroPedido & ",
@N_pedidofondo" & PedfondTes._NumeroPedido & ",
@Year_pedidofondo" & PedfondTes._NumeroPedido & ",
@Fecha" & PedfondTes._NumeroPedido & ",
@Descripcion" & PedfondTes._NumeroPedido & ",
@Observaciones" & PedfondTes._NumeroPedido & ",
@Monto_pedidofondo" & PedfondTes._NumeroPedido & ",
@Saldo" & PedfondTes._NumeroPedido & ",
@N_ordenentrega" & PedfondTes._NumeroPedido & ",
@Year_ordenentrega" & PedfondTes._NumeroPedido & ",
@Expediente_N" & PedfondTes._NumeroPedido & ",
@FechaConsulta" & PedfondTes._NumeroPedido & ",
@Fecha_pedido" & PedfondTes._NumeroPedido & "
)
ON DUPLICATE KEY UPDATE
Descripcion=@Descripcion" & PedfondTes._NumeroPedido & ",
Observaciones=@Observaciones" & PedfondTes._NumeroPedido & ",
Monto_pedidofondo=@Monto_pedidofondo" & PedfondTes._NumeroPedido & ",
Saldo=@Saldo" & PedfondTes._NumeroPedido & ",
N_ordenentrega=@N_ordenentrega" & PedfondTes._NumeroPedido & ",
Year_ordenentrega=@Year_ordenentrega" & PedfondTes._NumeroPedido & ",
Expediente_N=@Expediente_N" & PedfondTes._NumeroPedido & ",
FechaConsulta=@FechaConsulta" & PedfondTes._NumeroPedido & ",
Fecha_pedido=@Fecha_pedido" & PedfondTes._NumeroPedido & ";"
        If M.CommandText = "" Then
        Else
            Inicio.InsertSQLFunction(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name, M)
            System.Threading.Thread.Sleep(CInt(Math.Ceiling(Rnd() * 150)) + 150)
        End If
    End Sub

End Class