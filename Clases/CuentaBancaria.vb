Public Class Cuenta_Bancaria
    Private _CuentaN As String
    Public Property CuentaN() As String
        Get
            Return _CuentaN
        End Get
        Set(ByVal value As String)
            _CuentaN = value
        End Set
    End Property
    Private _nombrecuenta As String
    Public Property nombrecuenta() As String
        Get
            Return _nombrecuenta
        End Get
        Set(ByVal value As String)
            _nombrecuenta = value
        End Set
    End Property
    Private _year As String
    Public Property year() As String
        Get
            Return _year
        End Get
        Set(ByVal value As String)
            _year = value
        End Set
    End Property

    Public Sub New()
        _CuentaN = "-1"
        _nombrecuenta = "-1"
        _year = "0"
    End Sub

    Public Function nombre() As String
        For Each row As DataRow In Autocompletetables.Cuentas.Rows
            If row.Item(0).ToString = Me._CuentaN Then
                Me._nombrecuenta = row.Item(1).ToString.ToString
                Return Me.nombrecuenta
            End If
        Next
        Return ""
    End Function

End Class